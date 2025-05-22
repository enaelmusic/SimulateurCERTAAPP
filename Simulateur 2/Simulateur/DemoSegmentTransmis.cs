using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000028 RID: 40
	public partial class DemoSegmentTransmis : DemoDialogue
	{
		// Token: 0x0600028F RID: 655 RVA: 0x0001DBC8 File Offset: 0x0001CBC8
		public DemoSegmentTransmis()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000292 RID: 658 RVA: 0x0001F528 File Offset: 0x0001E528
		private Station st
		{
			get
			{
				return (Station)this.elt;
			}
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0001F540 File Offset: 0x0001E540
		protected override void init()
		{
			if (this.segment.Protocole == ProtocoleTrs.ICMP)
			{
				this.lbl_portSource.Text = "Id Icmp";
				this.lbl_portDest.Visible = false;
				this.tb_portDest.Visible = false;
				this.lbl_newSource.Text = "IP source / Id Icmp";
				this.lbl_newDest.Text = "IP destination";
				this.tb_newPortDest.Visible = false;
			}
			else
			{
				this.lbl_portSource.Text = "Port source";
				this.lbl_portDest.Visible = true;
				this.tb_portDest.Visible = true;
				this.lbl_newSource.Text = "ISource (IP / Port)";
				this.lbl_newDest.Text = "Destination (IP / Port)";
				this.tb_newPortDest.Visible = true;
			}
			this.okReqEnvoyees = HashTableEdit.CopieProfonde(this.st.Trs.ReqTrsEnvoyees);
			this.okReqRecues = HashTableEdit.CopieProfonde(this.st.Trs.ReqTrsRecues);
			this.okNatPat = HashTableEdit.CopieProfonde(this.st.Trs.NatPat);
			this.okSegment = this.segment;
			this.natPatEdit1.init(this.st.Trs, true);
			this.portsEcoutesEdit1.init(this.st.Trs, true);
			this.reglesFiltrageEdit1.init(this.st.Trs, true);
			this.reqTrsEditEnvoyees.init(this.st.Trs, this.st.Trs.ReqTrsEnvoyees, true);
			this.reqTrsEditRecues.init(this.st.Trs, this.st.Trs.ReqTrsRecues, true);
			this.routeEdit1.init(this.st.Ip, true);
			this.tb_resultat.Text = "";
			this.tb_ipDestination.Text = this.segment.AdrIpDest.ToString();
			this.ipAJoindre = this.segment.AdrIpDest.ToString();
			this.tb_ipSource.Text = this.segment.AdrIpSource.ToString();
			this.tb_portDest.Text = this.segment.NumPortDest.ToString();
			this.tb_portSource.Text = this.segment.NumPortSource.ToString();
			this.tb_protocole.Text = this.segment.Protocole.ToString();
			this.tb_carteArrivee.Text = this.segment.MacArrivee;
			this.tb_carteDepart.Text = "";
			this.calculerResultatAuto();
			this.itemFiltrageCourant = 0;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0001F7F8 File Offset: 0x0001E7F8
		private void calculerResultatAuto()
		{
			this.portGenere = this.st.Trs.NumPortGenere;
			this.segmentAffiche = this.segment;
			this.transition = new int[this.actions.Count + 1];
			for (int i = 0; i < this.actions.Count; i++)
			{
				this.transition[i] = 0;
			}
			this.transition[this.actions.Count - 1] = this.actions.Count;
			this.apresNatArrivee = this.segment.Clone();
			this.okSegment = this.apresNatArrivee;
			if (this.st.Trs.NatPatActif && this.segment.MacArrivee == this.st.Trs.CarteQuiNat.AdresseMac)
			{
				this.transition[0] = 1;
				this.st.Trs.NatterSegmentArrivee(this.apresNatArrivee, ref this.clefNatPatSupprimer, ref this.itemNatPatArrivee, ref this.typeNat);
				if (this.itemNatPatArrivee != -1)
				{
					this.transition[1] = 2;
					if (this.typeNat == "natPat")
					{
						this.transition[2] = 3;
						this.transition[3] = 4;
						HashTableEdit.TriRemoveLigne(ref this.okNatPat, this.clefNatPatSupprimer);
					}
					else
					{
						this.transition[2] = 4;
					}
				}
				else
				{
					this.transition[1] = 4;
				}
			}
			else
			{
				this.transition[0] = 4;
			}
			CarteReseau carteReseau = this.st.Ip.TrouverCarteIp(this.apresNatArrivee.AdrIpDest.ToString());
			if (carteReseau != null)
			{
				if (carteReseau.EtatConnexion != PointConnexion.EtatsConnexion.actif)
				{
					this.transition[4] = 13;
					this.okMessage = 1;
					this.messageOkPhase0 = "Adresse IP locale, carte HS";
					this.phasesAValider.Add(10);
				}
				else
				{
					this.messageOkPhase0 = "Adresse IP locale";
					this.transition[4] = 6;
					this.itemFiltrageOk = this.st.Trs.ItemFiltrage(this.apresNatArrivee, ref this.accepterFiltrage);
					if (this.accepterFiltrage)
					{
						if (this.apresNatArrivee.Protocole == ProtocoleTrs.ICMP && !Trs_station.TrsReponse)
						{
							this.suiteFiltrage = 20;
							this.transition[20] = 15;
							ReqTrsEdit.AjouterLigne(this.okReqRecues, this.apresNatArrivee.Protocole.ToString(), this.apresNatArrivee.AdrIpSource, this.apresNatArrivee.NumPortSource, this.apresNatArrivee.AdrIpDest, this.apresNatArrivee.NumPortDest);
							this.okMessage = 6;
							this.phasesAValider.Add(10);
						}
						else
						{
							this.suiteFiltrage = 12;
							object clef = null;
							if (Trs_station.TrsReponse)
							{
								this.clefRequeteEnvoyee = ReqTrsEdit.GetClef(this.st.Trs.ReqTrsEnvoyees, this.apresNatArrivee.Protocole, this.apresNatArrivee.AdrIpDest, this.apresNatArrivee.NumPortDest, this.apresNatArrivee.AdrIpSource, this.apresNatArrivee.NumPortSource, ref this.itemReqEnvoyee);
								this.actions[12] = "Examiner requêtes envoyées";
								if (this.itemReqEnvoyee != -1)
								{
									this.transition[12] = 17;
									this.transition[17] = 15;
									ReqTrsEdit.SupprimerReqTrs(ref this.okReqEnvoyees, this.clefRequeteEnvoyee);
									this.okMessage = 6;
									this.phasesAValider.Add(10);
								}
								else
								{
									this.transition[12] = 16;
									this.okMessage = 3;
									this.phasesAValider.Add(10);
								}
							}
							else
							{
								if (PortsEcoutesEdit.Ecoute(this.st.Trs.PortsEcoutes, this.segment.Protocole.ToString(), this.segment.NumPortDest, 1, 2, false, ref clef))
								{
									this.itemPortsEcoutes = this.portsEcoutesEdit1.IndexOf(clef);
								}
								this.actions[12] = "Examiner les ports écoutés";
								if (this.itemPortsEcoutes != -1)
								{
									this.transition[12] = 20;
									this.transition[20] = 15;
									ReqTrsEdit.AjouterLigne(this.okReqRecues, this.apresNatArrivee.Protocole.ToString(), this.apresNatArrivee.AdrIpSource, this.apresNatArrivee.NumPortSource, this.apresNatArrivee.AdrIpDest, this.apresNatArrivee.NumPortDest);
									this.okMessage = 6;
									this.phasesAValider.Add(10);
								}
								else
								{
									this.transition[12] = 16;
									this.okMessage = 3;
									this.phasesAValider.Add(10);
								}
							}
						}
					}
					else
					{
						this.suiteFiltrage = 14;
						this.okMessage = 2;
						this.phasesAValider.Add(10);
					}
				}
			}
			else if (this.st.Ip.RoutageActif)
			{
				if (this.apresNatArrivee.NbSauts > 0)
				{
					this.apresRoutage = this.apresNatArrivee.Clone();
					this.okSegment = this.apresRoutage;
					this.transition[4] = 5;
					this.ipAJoindre = this.apresNatArrivee.AdrIpDest.ToString();
					this.itemRoute = this.st.Ip.TrouverRoute(new Ip_adresse(this.ipAJoindre), ref this.maCarte, ref this.passerelle);
					if (this.maCarte != null)
					{
						this.macDepart = this.maCarte.AdresseMac;
						if (this.passerelle != null)
						{
							this.ipAJoindre = this.passerelle;
						}
						if (this.maCarte.GetType() == typeof(CarteAccesDistant))
						{
							this.ppp = true;
						}
						this.adrMacDest = CacheArpEdit.GetMac(this.st.Ip.CacheArp, new Ip_adresse(this.ipAJoindre));
						if ((this.adrMacDest == null && !this.ppp) || this.maCarte.EtatConnexion != PointConnexion.EtatsConnexion.actif)
						{
							this.transition[5] = 13;
							this.messageOkPhase0 = "IP à joindre : " + this.ipAJoindre + " (non joignable)";
							this.okMessage = 1;
							this.phasesAValider.Add(10);
						}
						else
						{
							if (this.ppp)
							{
								this.messageOkPhase0 = "IP à joindre : " + this.ipAJoindre + " (PPP)";
							}
							else
							{
								this.messageOkPhase0 = string.Concat(new string[]
								{
									"IP à joindre : ",
									this.ipAJoindre,
									" (",
									this.adrMacDest,
									")"
								});
							}
							this.apresRoutage.MacDepart = this.maCarte.AdresseMac;
							this.transition[5] = 6;
							this.itemFiltrageOk = this.st.Trs.ItemFiltrage(this.apresRoutage, ref this.accepterFiltrage);
							this.apresNatDepart = this.apresRoutage.Clone();
							this.okSegment = this.apresNatDepart;
							if (!this.accepterFiltrage)
							{
								this.suiteFiltrage = 14;
								this.okMessage = 2;
								this.phasesAValider.Add(10);
							}
							else
							{
								this.suiteFiltrage = 7;
								this.phasesAValider.Add(11);
								if (this.st.Trs.NatPatActif && this.apresRoutage.MacDepart == this.st.Trs.CarteQuiNat.AdresseMac && this.apresRoutage.AdrIpSource != this.st.Trs.CarteQuiNat.Ip.Adresse)
								{
									this.transition[7] = 8;
									this.st.Trs.NatterSegmentDepart(this.apresNatDepart, ref this.itemNatPatDepart, this.portGenere);
									if (this.itemNatPatDepart == -1)
									{
										this.transition[8] = 9;
										this.transition[9] = 10;
										NatPatEdit.InsererLigneNat(this.okNatPat, this.apresRoutage.Protocole.ToString(), this.st.Trs.CarteQuiNat.Ip.Adresse, this.portGenere, this.apresRoutage.AdrIpSource, this.apresRoutage.NumPortSource);
									}
									else
									{
										this.transition[8] = 10;
									}
									this.transition[10] = 11;
								}
								else
								{
									this.transition[7] = 11;
								}
							}
						}
					}
					else
					{
						this.transition[5] = 13;
						this.messageOkPhase0 = "Aucune route trouvée";
						this.okMessage = 1;
						this.phasesAValider.Add(10);
					}
				}
				else
				{
					this.transition[4] = 19;
					this.messageOkPhase0 = "Routage impossible";
					this.okMessage = 5;
					this.phasesAValider.Add(10);
				}
			}
			else
			{
				this.messageOkPhase0 = "Routage impossible";
				this.okMessage = 5;
				this.phasesAValider.Add(10);
				this.transition[4] = 18;
			}
			this.transition[6] = 6;
			this.transition[11] = this.actions.Count - 1;
			this.transition[13] = this.actions.Count - 1;
			this.transition[14] = this.actions.Count - 1;
			this.transition[15] = this.actions.Count - 1;
			this.transition[16] = this.actions.Count - 1;
			this.transition[18] = this.actions.Count - 1;
			this.transition[19] = this.actions.Count - 1;
		}

		// Token: 0x06000295 RID: 661 RVA: 0x000201B8 File Offset: 0x0001F1B8
		private void MontrerTable(Control c, bool modifiable)
		{
			bool flag = false;
			if (this.typeDemo == Simulation.TypeDeDemo.manuel)
			{
				flag = true;
			}
			this.lbl_requetes.Visible = false;
			if (c.GetType() == typeof(PortsEcoutesEdit))
			{
				base.Size = new Size(320, 256);
			}
			else
			{
				if (c.GetType() == typeof(ReglesFiltrageEdit))
				{
					base.Size = new Size(572, 256);
				}
				else if (c.GetType() == typeof(ReqTrsEdit))
				{
					if (modifiable)
					{
						base.Size = new Size(416, 256);
					}
					else
					{
						base.Size = new Size(396, 256);
					}
					if (c.Name == "reqTrsEditEnvoyees")
					{
						this.lbl_requetes.Text = "Req envoyées";
					}
					else
					{
						this.lbl_requetes.Text = "Req reçues";
					}
					this.lbl_requetes.Visible = true;
				}
				else if (c.GetType() == typeof(RouteEdit))
				{
					base.Size = new Size(480, 256);
				}
				else if (c.GetType() == typeof(NatPatEdit))
				{
					if (modifiable)
					{
						base.Size = new Size(480, 256);
					}
					else
					{
						base.Size = new Size(460, 256);
					}
					flag = false;
					this.lbl_requetes.Text = this.textePortGenere;
					this.lbl_requetes.Visible = true;
				}
				else if (c.GetType() == typeof(GroupBox))
				{
					base.Size = new Size(320, 256);
				}
				else if (c.GetType() == typeof(Panel))
				{
					if (c.Name == "pn_nouveauSegment")
					{
						base.Size = new Size(320, 240);
					}
					else
					{
						base.Size = new Size(476, 256);
					}
				}
				if (flag)
				{
					this.lbl_requetes.Visible = false;
				}
			}
			this.portsEcoutesEdit1.Visible = false;
			this.reglesFiltrageEdit1.Visible = false;
			this.reqTrsEditEnvoyees.Visible = false;
			this.reqTrsEditRecues.Visible = false;
			this.routeEdit1.Visible = false;
			this.natPatEdit1.Visible = false;
			this.gb_messageUtilisateur.Visible = false;
			this.pn_configIp.Visible = false;
			this.pn_nouveauSegment.Visible = false;
			c.Visible = true;
			base.InScreen();
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0002044C File Offset: 0x0001F44C
		private void cacherTable()
		{
			this.lbl_requetes.Visible = false;
			base.Size = new Size(320, 168);
			this.portsEcoutesEdit1.Visible = false;
			this.reglesFiltrageEdit1.Visible = false;
			this.reqTrsEditEnvoyees.Visible = false;
			this.reqTrsEditRecues.Visible = false;
			this.routeEdit1.Visible = false;
			this.natPatEdit1.Visible = false;
			this.gb_messageUtilisateur.Visible = false;
			this.pn_configIp.Visible = false;
			this.pn_nouveauSegment.Visible = false;
			base.InScreen();
		}

		// Token: 0x06000297 RID: 663 RVA: 0x000204EC File Offset: 0x0001F4EC
		private string getLibellePhase(int numPhase)
		{
			string result = "";
			switch (numPhase)
			{
			case 0:
				result = "Translation de la destination";
				break;
			case 1:
				result = "Translation de la destination";
				break;
			case 2:
				result = "Translation de la destination";
				break;
			case 3:
				result = "Translation de la destination";
				break;
			case 4:
				result = "Routage du paquet";
				break;
			case 5:
				result = "Routage du paquet";
				break;
			case 6:
				result = "Application des règles de filtrage";
				break;
			case 7:
				result = "Translation de la source";
				break;
			case 8:
				result = "Translation de la source";
				break;
			case 9:
				result = "Translation de la source";
				break;
			case 10:
				result = "Translation de la source";
				break;
			case 11:
				result = "Transmission du paquet";
				break;
			case 12:
				result = "Réception du paquet";
				break;
			case 13:
				result = "Affichage du résultat";
				break;
			case 14:
				result = "Affichage du résultat";
				break;
			case 15:
				result = "Affichage du résultat";
				break;
			case 16:
				result = "Affichage du résultat";
				break;
			case 17:
				result = "Réception du paquet";
				break;
			case 18:
				result = "Affichage du résultat";
				break;
			case 19:
				result = "Affichage du résultat";
				break;
			case 20:
				result = "Réception du paquet";
				break;
			case 21:
				result = "";
				break;
			}
			return result;
		}

		// Token: 0x06000298 RID: 664 RVA: 0x00020624 File Offset: 0x0001F624
		private void afficherSegment()
		{
			this.tb_carteArrivee.Text = this.segmentAffiche.MacArrivee;
			this.tb_carteDepart.Text = this.segmentAffiche.MacDepart;
			this.tb_ipSource.Text = this.segmentAffiche.AdrIpSource.ToString();
			this.tb_portSource.Text = this.segmentAffiche.NumPortSource.ToString();
			this.tb_ipDestination.Text = this.segmentAffiche.AdrIpDest.ToString();
			this.tb_portDest.Text = this.segmentAffiche.NumPortDest.ToString();
		}

		// Token: 0x06000299 RID: 665 RVA: 0x000206D0 File Offset: 0x0001F6D0
		protected override void executerPhase()
		{
			this.cacherTable();
			base.LibellePhase = this.getLibellePhase(this.numPhaseSuivante);
			switch (this.numPhaseSuivante)
			{
			case 0:
				if (this.st.Trs.NatPatActif)
				{
					if (this.segment.MacArrivee == this.st.Trs.CarteQuiNat.AdresseMac)
					{
						this.tb_resultat.Text = "Translation active sur la carte d'arrivée";
					}
					else
					{
						this.tb_resultat.Text = "Translation inactive sur la carte d'arrivée";
					}
				}
				else
				{
					this.tb_resultat.Text = "Translation inactive sur la station";
				}
				break;
			case 1:
				this.MontrerTable(this.natPatEdit1, false);
				if (this.itemNatPatArrivee == -1)
				{
					this.tb_resultat.Text = "Aucune translation pour cette destination";
				}
				else
				{
					this.natPatEdit1.selectIndex(this.itemNatPatArrivee);
					this.tb_resultat.Text = string.Concat(new object[]
					{
						"Nouvelle destination : ",
						this.apresNatArrivee.AdrIpDest.ToString(),
						" (",
						this.apresNatArrivee.NumPortDest,
						")"
					});
				}
				break;
			case 2:
				base.TablesModifiees = true;
				this.MontrerTable(this.natPatEdit1, false);
				this.natPatEdit1.selectIndex(this.itemNatPatArrivee);
				this.segmentAffiche = this.apresNatArrivee;
				this.tb_resultat.Text = "Paquet translaté";
				if (this.typeNat == "natPat")
				{
					TextBox tb_resultat = this.tb_resultat;
					tb_resultat.Text += " (\"natPat\", supprimer)";
				}
				else
				{
					TextBox tb_resultat2 = this.tb_resultat;
					tb_resultat2.Text += " (\"mapping\", ne pas supprimer)";
				}
				break;
			case 3:
				base.TablesModifiees = true;
				this.natPatEdit1.supprimerLigne(this.clefNatPatSupprimer);
				this.natPatEdit1.Maj();
				this.MontrerTable(this.natPatEdit1, false);
				this.tb_resultat.Text = "Entrée supprimée de la table NatPat";
				break;
			case 4:
			{
				if (base.MarcheArriere)
				{
					this.itemFiltrageCourant = 0;
					this.transition[6] = 6;
				}
				int num = this.transition[4];
				switch (num)
				{
				case 5:
					this.tb_resultat.Text = "Adresse IP non locale";
					break;
				case 6:
					this.tb_resultat.Text = "Adresse IP locale";
					break;
				default:
					if (num != 13)
					{
						switch (num)
						{
						case 18:
							this.tb_resultat.Text = "Adresse IP non locale, routage inactif";
							break;
						case 19:
							this.tb_resultat.Text = "Adresse IP non locale, TTL épuisé";
							break;
						}
					}
					else
					{
						this.tb_resultat.Text = "Adresse IP locale, carte HS";
					}
					break;
				}
				break;
			}
			case 5:
				base.TablesModifiees = true;
				if (base.MarcheArriere)
				{
					this.itemFiltrageCourant = 0;
					this.transition[6] = 6;
				}
				this.MontrerTable(this.routeEdit1, false);
				if (this.itemRoute == -1)
				{
					this.tb_resultat.Text = "Aucune route trouvée";
				}
				else
				{
					this.routeEdit1.selectIndex(this.itemRoute);
					if (!this.ppp)
					{
						if (this.adrMacDest == null)
						{
							this.tb_resultat.Text = "IP à joindre : " + this.ipAJoindre + " (non joignable)";
						}
						else
						{
							this.tb_resultat.Text = string.Concat(new string[]
							{
								"IP à joindre : ",
								this.ipAJoindre,
								" (",
								this.adrMacDest,
								")"
							});
						}
					}
					else
					{
						this.tb_resultat.Text = "IP à joindre : " + this.ipAJoindre + " (PPP)";
					}
				}
				this.segmentAffiche = this.apresRoutage;
				break;
			case 6:
				if (base.MarcheArriere)
				{
					this.itemFiltrageCourant = 0;
					this.transition[6] = 6;
				}
				this.MontrerTable(this.reglesFiltrageEdit1, false);
				if (this.itemFiltrageOk == -1)
				{
					this.tb_resultat.Text = "Aucune règle, accepter";
					this.transition[6] = this.suiteFiltrage;
				}
				else
				{
					if (this.itemFiltrageCourant < this.st.Trs.ReglesFiltrage.Count)
					{
						this.reglesFiltrageEdit1.selectIndex(this.itemFiltrageCourant);
					}
					else
					{
						this.reglesFiltrageEdit1.selectIndex(-1);
					}
					if (this.itemFiltrageCourant == this.itemFiltrageOk)
					{
						if (this.itemFiltrageOk == this.st.Trs.ReglesFiltrage.Count)
						{
							this.tb_resultat.Text = "Aucune règle applicable, bloquer";
							this.transition[6] = this.suiteFiltrage;
						}
						else if (this.accepterFiltrage)
						{
							this.transition[6] = this.suiteFiltrage;
							this.tb_resultat.Text = "Règle applicable : accepter";
						}
						else
						{
							this.tb_resultat.Text = "Règle applicable : bloquer";
							this.transition[6] = this.suiteFiltrage;
						}
					}
					else
					{
						this.itemFiltrageCourant++;
						this.tb_resultat.Text = "Règle non applicable";
					}
				}
				break;
			case 7:
				if (this.st.Trs.NatPatActif)
				{
					if (this.apresRoutage.MacDepart == this.st.Trs.CarteQuiNat.AdresseMac)
					{
						this.tb_resultat.Text = "Translation active sur la carte de départ";
					}
					else
					{
						this.tb_resultat.Text = "Translation inactive sur la carte de départ";
					}
				}
				else
				{
					this.tb_resultat.Text = "Translation inactive sur la station";
				}
				break;
			case 8:
				this.MontrerTable(this.natPatEdit1, false);
				if (this.itemNatPatDepart == -1)
				{
					this.tb_resultat.Text = "Aucune translation pour cette source";
				}
				else
				{
					this.natPatEdit1.selectIndex(this.itemNatPatDepart);
					this.tb_resultat.Text = string.Concat(new object[]
					{
						"Nouvelle source : ",
						this.apresNatDepart.AdrIpSource.ToString(),
						" (",
						this.apresNatDepart.NumPortSource,
						")"
					});
				}
				break;
			case 9:
				base.TablesModifiees = true;
				NatPatEdit.InsererLigneNat(this.natPatEdit1.GetTable(), this.apresRoutage.Protocole.ToString(), this.st.Trs.CarteQuiNat.Ip.Adresse, this.portGenere, this.apresRoutage.AdrIpSource, this.apresRoutage.NumPortSource);
				this.natPatEdit1.Maj();
				this.itemNatPatDepart = this.natPatEdit1.GetTable().Count - 1;
				this.natPatEdit1.selectIndex(this.itemNatPatDepart);
				this.MontrerTable(this.natPatEdit1, false);
				if (this.segment.Protocole == ProtocoleTrs.ICMP)
				{
					this.tb_resultat.Text = "ID public généré, entrée ajoutée ds la table NatPat";
				}
				else
				{
					this.tb_resultat.Text = "Port public généré, entrée ajoutée ds la table NatPat";
				}
				break;
			case 10:
				base.TablesModifiees = true;
				this.MontrerTable(this.natPatEdit1, false);
				this.natPatEdit1.selectIndex(this.itemNatPatDepart);
				this.segmentAffiche = this.apresNatDepart;
				this.tb_resultat.Text = "Paquet translaté";
				break;
			case 11:
				if (this.ppp)
				{
					this.tb_resultat.Text = "De " + this.apresNatDepart.MacDepart + " vers liaison PPP";
				}
				else
				{
					this.tb_resultat.Text = "De " + this.apresNatDepart.MacDepart + " vers " + this.adrMacDest;
				}
				break;
			case 12:
				if (Trs_station.TrsReponse)
				{
					this.MontrerTable(this.reqTrsEditEnvoyees, false);
					if (this.itemReqEnvoyee == -1)
					{
						this.reqTrsEditEnvoyees.selectIndex(-1);
						this.tb_resultat.Text = "L'envoi ne correspond à aucune requête";
					}
					else
					{
						this.reqTrsEditEnvoyees.selectIndex(this.itemReqEnvoyee);
						this.tb_resultat.Text = "L'envoi répond à cette requête";
					}
				}
				else
				{
					this.MontrerTable(this.portsEcoutesEdit1, false);
					if (this.itemPortsEcoutes == -1)
					{
						this.tb_resultat.Text = "Port non écouté";
					}
					else
					{
						this.portsEcoutesEdit1.selectIndex(this.itemPortsEcoutes);
						this.tb_resultat.Text = "Port écouté";
					}
				}
				break;
			case 13:
				this.tb_resultat.Text = "Hôte non joignable !";
				break;
			case 14:
				this.tb_resultat.Text = "L'envoi a été filtré !";
				break;
			case 15:
				this.tb_resultat.Text = "L'envoi a été accepté !";
				break;
			case 16:
				this.tb_resultat.Text = "L'envoi a été refusé !";
				break;
			case 17:
			{
				base.TablesModifiees = true;
				SortedList table = this.reqTrsEditEnvoyees.GetTable();
				ReqTrsEdit.SupprimerReqTrs(ref table, this.clefRequeteEnvoyee);
				this.reqTrsEditEnvoyees.SetTable(table);
				this.MontrerTable(this.reqTrsEditEnvoyees, false);
				this.tb_resultat.Text = "Requête envoyée supprimée";
				break;
			}
			case 18:
				this.tb_resultat.Text = "Routage inactif !";
				break;
			case 19:
				this.tb_resultat.Text = "TTL du paquet épuisé !";
				break;
			case 20:
			{
				base.TablesModifiees = true;
				ReqTrsEdit.AjouterLigne(this.reqTrsEditRecues.GetTable(), this.apresNatArrivee.Protocole.ToString(), this.apresNatArrivee.AdrIpSource, this.apresNatArrivee.NumPortSource, this.apresNatArrivee.AdrIpDest, this.apresNatArrivee.NumPortDest);
				this.reqTrsEditRecues.Maj();
				int index = this.reqTrsEditRecues.GetTable().Count - 1;
				this.reqTrsEditRecues.selectIndex(index);
				this.MontrerTable(this.reqTrsEditRecues, false);
				this.tb_resultat.Text = "Requête reçue ajoutée";
				break;
			}
			}
			this.afficherSegment();
			this.numPhaseSuivante = this.transition[this.numPhaseSuivante];
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0002111C File Offset: 0x0002011C
		private bool segmentOk()
		{
			bool result = false;
			if (this.tb_newIpSource.Text.Trim() == this.okSegment.AdrIpSource.ToString().Trim() && int.Parse(this.tb_newPortSource.Text) == this.okSegment.NumPortSource && this.tb_newIpDest.Text.Trim() == this.okSegment.AdrIpDest.ToString().Trim())
			{
				if (this.segment.Protocole == ProtocoleTrs.ICMP)
				{
					this.tb_newPortDest.Text = this.tb_newPortSource.Text;
				}
				if (int.Parse(this.tb_newPortDest.Text) == this.okSegment.NumPortDest)
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600029B RID: 667 RVA: 0x000211E8 File Offset: 0x000201E8
		protected override void initManuel()
		{
			this.init();
			this.reqTrsEditEnvoyees.ChangerMode(false);
			this.reqTrsEditRecues.ChangerMode(false);
			this.natPatEdit1.ChangerMode(false);
			this.natPatEdit1.ModeNatPat = true;
			this.tb_newIpSource.Text = this.segment.AdrIpSource.ToString().Trim();
			this.tb_newPortSource.Text = this.segment.NumPortSource.ToString();
			this.tb_newIpDest.Text = this.segment.AdrIpDest.ToString().Trim();
			this.tb_newPortDest.Text = this.segment.NumPortDest.ToString();
			this.Text = "Station : " + ((Station)this.elt).NomNoeud;
			this.nbPhasesManuelles = 12;
			base.initManuel();
			this.cacherTable();
			this.tb_nomHote.Text = this.st.NomNoeud;
			this.tb_passerelle.Text = this.st.Ip.Passerelle.ToString();
			int num = 1;
			this.cb_activerNatPat.Checked = this.st.Trs.NatPatActif;
			if (this.st.Trs.NatPatActif)
			{
				this.lb_interface.Items.Add("Interfaces (translation sur la carte sélectionnée):");
			}
			else
			{
				this.lb_interface.Items.Add("Interfaces :");
			}
			int num2 = 0;
			foreach (object obj in this.st.Controls)
			{
				CarteReseau carteReseau = (CarteReseau)obj;
				if (carteReseau == this.st.Trs.CarteQuiNat)
				{
					num2 = num;
				}
				this.lb_interface.Items.Add(string.Concat(new string[]
				{
					num.ToString(),
					"  ",
					carteReseau.AdresseMac,
					"  ",
					carteReseau.Ip.Adresse.ToString(),
					" (",
					carteReseau.Ip.Masque.ToString(),
					") ",
					carteReseau.Protocole
				}));
				num++;
			}
			if (num2 != 0)
			{
				this.lb_interface.SelectedIndex = num2;
			}
			this.cb_activerRoutage.Checked = this.st.Ip.RoutageActif;
			this.cb_action.Items.Clear();
			this.cb_action.Items.Add("Chercher la route...");
			this.cb_action.Items.Add("Consulter règles de filtrage...");
			this.cb_action.Items.Add("Consulter les ports écoutés...");
			this.cb_action.Items.Add("Consulter la configuration IP...");
			this.cb_action.Items.Add("Editer requêtes envoyées...");
			this.cb_action.Items.Add("Editer requêtes reçues...");
			this.cb_action.Items.Add("Editer la table NatPat...");
			if (this.segment.Protocole == ProtocoleTrs.ICMP)
			{
				this.cb_action.Items.Add("Générer un Id Icmp...");
			}
			else
			{
				this.cb_action.Items.Add("Générer un numéro de port...");
			}
			this.cb_action.Items.Add("Préparer message utilisateur...");
			this.cb_action.Items.Add("Modifier le paquet...");
			this.cb_action.Items.Add("Afficher le message préparé -->");
			this.cb_action.Items.Add("Transmettre le paquet -->");
		}

		// Token: 0x0600029C RID: 668 RVA: 0x000215E0 File Offset: 0x000205E0
		protected override void executerPhaseManuelle(int numPhaseManuelle)
		{
			this.cacherTable();
			switch (numPhaseManuelle)
			{
			case 0:
				if (this.tb_newIpDest.Text.Trim() == this.okSegment.AdrIpDest.ToString().Trim())
				{
					this.messageManuelOk = this.messageOkPhase0;
					this.tb_carteDepart.Text = this.macDepart;
				}
				else
				{
					this.messageManuelOk = "La destination doit être modifiée !";
				}
				this.okManuel = true;
				return;
			case 1:
				this.MontrerTable(this.reglesFiltrageEdit1, false);
				this.messageManuelOk = "Règles de filtrage";
				this.okManuel = true;
				return;
			case 2:
				this.MontrerTable(this.portsEcoutesEdit1, false);
				this.messageManuelOk = "Ports écoutés";
				this.okManuel = true;
				return;
			case 3:
				this.MontrerTable(this.pn_configIp, false);
				this.messageManuelOk = "Configuration IP";
				this.okManuel = true;
				return;
			case 4:
				this.MontrerTable(this.reqTrsEditEnvoyees, true);
				this.messageManuelOk = "Requêtes envoyées";
				this.okManuel = true;
				return;
			case 5:
				this.MontrerTable(this.reqTrsEditRecues, true);
				this.messageManuelOk = "Requêtes reçues";
				this.okManuel = true;
				return;
			case 6:
				this.MontrerTable(this.natPatEdit1, true);
				this.messageManuelOk = "Table NatPat";
				this.okManuel = true;
				return;
			case 7:
				base.desactiverActionIndexChanged();
				if (this.segment.Protocole == ProtocoleTrs.ICMP)
				{
					this.messageManuelOk = "Id Icmp généré : " + this.portGenere;
					this.textePortGenere = "Id Icmp généré : " + this.portGenere;
					this.cb_action.Items[7] = "Voir l'Id Icmp généré...";
				}
				else
				{
					this.messageManuelOk = "Numéro de port généré : " + this.portGenere;
					this.textePortGenere = "N° de port généré : " + this.portGenere;
					this.cb_action.Items[7] = "Voir le N° de port généré...";
				}
				base.activerActionIndexChanged();
				this.okManuel = true;
				return;
			case 8:
				this.MontrerTable(this.gb_messageUtilisateur, false);
				this.messageManuelOk = "Choisissez le message...";
				this.okManuel = true;
				return;
			case 9:
				this.MontrerTable(this.pn_nouveauSegment, false);
				this.messageManuelOk = "Modifiez le paquet...";
				this.tb_newIpSource.Focus();
				this.okManuel = true;
				return;
			case 10:
				if (this.phasesAValider.Contains(10))
				{
					switch (this.okMessage)
					{
					case 1:
						this.okManuel = this.rb_nonJoignable.Checked;
						break;
					case 2:
						this.okManuel = this.rb_filtre.Checked;
						break;
					case 3:
						this.okManuel = this.rb_refuse.Checked;
						break;
					case 4:
						this.okManuel = this.rb_routageInactif.Checked;
						break;
					case 5:
						this.okManuel = this.rb_ttlEpuise.Checked;
						break;
					case 6:
						this.okManuel = this.rb_accepte.Checked;
						break;
					}
					if (!this.okManuel)
					{
						this.messageManuelErreur = "Message utilisateur incorrect !";
						return;
					}
					this.okManuel = false;
					if (!HashTableEdit.Identiques(this.okReqEnvoyees, this.reqTrsEditEnvoyees.GetTable()))
					{
						this.messageManuelErreur = "requêtes envoyées incorrectes !";
						return;
					}
					if (!HashTableEdit.Identiques(this.okReqRecues, this.reqTrsEditRecues.GetTable()))
					{
						this.messageManuelErreur = "requêtes reçues incorrectes !";
						return;
					}
					if (!HashTableEdit.Identiques(this.okNatPat, this.natPatEdit1.GetTable()))
					{
						this.messageManuelErreur = "Table NatPat incorrecte !";
						return;
					}
					if (!this.segmentOk())
					{
						this.messageManuelErreur = "Paquet incorrect !";
						return;
					}
					this.okManuel = true;
					return;
				}
				break;
			case 11:
				if (this.phasesAValider.Contains(11))
				{
					this.okManuel = false;
					if (!HashTableEdit.Identiques(this.okReqEnvoyees, this.reqTrsEditEnvoyees.GetTable()))
					{
						this.messageManuelErreur = "requêtes envoyées incorrectes !";
						return;
					}
					if (!HashTableEdit.Identiques(this.okReqRecues, this.reqTrsEditRecues.GetTable()))
					{
						this.messageManuelErreur = "requêtes reçues incorrectes !";
						return;
					}
					if (!HashTableEdit.Identiques(this.okNatPat, this.natPatEdit1.GetTable()))
					{
						this.messageManuelErreur = "Table NatPat incorrecte !";
						return;
					}
					if (!this.segmentOk())
					{
						this.messageManuelErreur = "Paquet incorrect !";
						return;
					}
					if (this.tb_carteDepart.Text != this.okSegment.MacDepart)
					{
						this.messageManuelErreur = "Adresse mac départ incorrecte !";
						return;
					}
					this.okManuel = true;
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00021A74 File Offset: 0x00020A74
		public DemoSegmentTransmis(Form f) : base(f)
		{
			this.InitializeComponent();
			base.Owner = f;
			this.actions = new ArrayList();
			this.actions.Add("Vérifier s'il faut translater");
			this.actions.Add("Consulter la table NatPat");
			this.actions.Add("Translater la destination");
			this.actions.Add("Supprimer l'entrée");
			this.actions.Add("Examiner IP de destination");
			this.actions.Add("Chercher la route");
			this.actions.Add("Examiner table de filtrage");
			this.actions.Add("Vérifier s'il faut translater");
			this.actions.Add("Consulter la table NatPat");
			this.actions.Add("Ajouter une entrée");
			this.actions.Add("Translater la source");
			this.actions.Add("Transmettre le paquet");
			this.actions.Add("");
			this.actions.Add("Afficher message échec");
			this.actions.Add("Afficher message échec");
			this.actions.Add("Afficher message de réussite");
			this.actions.Add("Afficher message échec");
			this.actions.Add("Supprimer l'entrée");
			this.actions.Add("Afficher message échec");
			this.actions.Add("Afficher message échec");
			this.actions.Add("Ajouter une entrée");
			this.actions.Add("Fin de la démonstration");
			base.initTables(null);
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00021CE0 File Offset: 0x00020CE0
		protected override ArrayList getTables()
		{
			SortedList sortedList = new SortedList();
			sortedList["segmentAffiche"] = this.segmentAffiche;
			sortedList["itemNatPatDepart"] = this.itemNatPatDepart;
			return new ArrayList
			{
				sortedList.Clone(),
				this.reqTrsEditEnvoyees.GetTable().Clone(),
				this.reqTrsEditRecues.GetTable().Clone(),
				this.natPatEdit1.GetTable().Clone()
			};
		}

		// Token: 0x0600029F RID: 671 RVA: 0x00021D74 File Offset: 0x00020D74
		protected override void setTables(ArrayList p_tables)
		{
			SortedList sortedList = (SortedList)p_tables[0];
			this.segmentAffiche = (Trs_SegmentTrs)sortedList["segmentAffiche"];
			this.itemNatPatDepart = int.Parse(sortedList["itemNatPatDepart"].ToString());
			this.reqTrsEditEnvoyees.SetTable((SortedList)((SortedList)p_tables[1]).Clone());
			this.reqTrsEditRecues.SetTable((SortedList)((SortedList)p_tables[2]).Clone());
			this.natPatEdit1.SetTable((SortedList)((SortedList)p_tables[3]).Clone());
		}

		// Token: 0x04000232 RID: 562
		private Trs_SegmentTrs segmentAffiche;

		// Token: 0x04000233 RID: 563
		private string adrMacDest;

		// Token: 0x04000234 RID: 564
		private int itemRoute;

		// Token: 0x04000235 RID: 565
		private string ipAJoindre;

		// Token: 0x04000236 RID: 566
		private CarteReseau maCarte = null;

		// Token: 0x04000237 RID: 567
		private string passerelle = null;

		// Token: 0x04000238 RID: 568
		private bool ppp = false;

		// Token: 0x04000239 RID: 569
		private int itemFiltrageOk = -1;

		// Token: 0x0400023A RID: 570
		private int itemFiltrageCourant = 0;

		// Token: 0x0400023B RID: 571
		private bool accepterFiltrage = false;

		// Token: 0x0400023C RID: 572
		private int itemPortsEcoutes = -1;

		// Token: 0x0400023D RID: 573
		private Ip_adresse ipClient = new Ip_adresse("0.0.0.0");

		// Token: 0x0400023E RID: 574
		private object clefNatPatSupprimer = null;

		// Token: 0x0400023F RID: 575
		private int itemNatPatArrivee = -1;

		// Token: 0x04000240 RID: 576
		private int itemNatPatDepart = -1;

		// Token: 0x04000241 RID: 577
		private string typeNat = "";

		// Token: 0x04000242 RID: 578
		private int portGenere = 0;

		// Token: 0x04000243 RID: 579
		private object clefRequeteEnvoyee = null;

		// Token: 0x04000244 RID: 580
		private int itemReqEnvoyee = -1;

		// Token: 0x04000245 RID: 581
		private Trs_SegmentTrs apresNatArrivee = null;

		// Token: 0x04000246 RID: 582
		private Trs_SegmentTrs apresRoutage = null;

		// Token: 0x04000247 RID: 583
		private Trs_SegmentTrs apresNatDepart = null;

		// Token: 0x04000248 RID: 584
		private int[] transition;

		// Token: 0x04000249 RID: 585
		private int suiteFiltrage = 0;

		// Token: 0x0400024A RID: 586
		private SortedList okReqEnvoyees;

		// Token: 0x0400024B RID: 587
		private SortedList okReqRecues;

		// Token: 0x0400024C RID: 588
		private SortedList okNatPat;

		// Token: 0x0400024D RID: 589
		private Trs_SegmentTrs okSegment;

		// Token: 0x0400024E RID: 590
		private string macDepart = "";

		// Token: 0x0400024F RID: 591
		private int okMessage = 0;

		// Token: 0x04000250 RID: 592
		private string messageOkPhase0 = "";

		// Token: 0x04000251 RID: 593
		private string textePortGenere = "";
	}
}
