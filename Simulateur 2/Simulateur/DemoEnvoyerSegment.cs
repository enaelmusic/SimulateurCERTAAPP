using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000024 RID: 36
	public partial class DemoEnvoyerSegment : DemoDialogue
	{
		// Token: 0x0600023B RID: 571 RVA: 0x00013A2C File Offset: 0x00012A2C
		public DemoEnvoyerSegment()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600023E RID: 574 RVA: 0x00014934 File Offset: 0x00013934
		private Station st
		{
			get
			{
				return (Station)this.elt;
			}
		}

		// Token: 0x0600023F RID: 575 RVA: 0x0001494C File Offset: 0x0001394C
		protected override void init()
		{
			if (this.protocoleTransport == ProtocoleTrs.ICMP)
			{
				this.lbl_portSource.Text = "Id Icmp";
				this.lbl_portDest.Visible = false;
				this.tb_portDest.Visible = false;
			}
			else
			{
				this.lbl_portSource.Text = "Port source";
				this.lbl_portDest.Visible = true;
				this.tb_portDest.Visible = true;
			}
			this.portsEcoutesEdit1.init(this.st.Trs, true);
			this.reglesFiltrageEdit1.init(this.st.Trs, true);
			this.reqTrsEditRecues.init(this.st.Trs, this.st.Trs.ReqTrsRecues, true);
			this.reqTrsEditEnvoyees.init(this.st.Trs, this.st.Trs.ReqTrsEnvoyees, true);
			if (Trs_station.TrsReponse)
			{
				this.actions[2] = "Supprimer l'échange en cours";
				this.actions[5] = "Examiner les requêtes envoyées";
			}
			else
			{
				this.actions[2] = "Ajouter l'échange en cours";
				this.actions[5] = "Examiner les ports écoutés";
			}
			this.routeEdit1.init(this.st.Ip, true);
			this.tb_resultat.Text = "";
			this.ipAJoindre = this.adrIpToPing;
			this.calculerResultatAuto();
			this.tb_ipSource.Text = this.adrIpSource.ToString();
			this.tb_portSource.Text = this.numPortClient.ToString();
			this.tb_ipDestination.Text = this.adrIpToPing;
			this.tb_portDest.Text = this.numPortDest.ToString();
			this.tb_protocole.Text = this.protocoleTransport.ToString();
			this.itemFiltrageCourant = 0;
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00014B2C File Offset: 0x00013B2C
		private int itemFiltrage()
		{
			string text;
			if (!Ip_adresse.Ok(this.adrIpToPing))
			{
				if (!this.st.Ip.FichierHosts.ContainsKey(this.adrIpToPing))
				{
					return -1;
				}
				text = FichierHostsEdit.GetAdrIp(this.st.Ip.FichierHosts, this.adrIpToPing);
				if (!Ip_adresse.Ok(text) || Ip_quartet.Isnul(text))
				{
					return -1;
				}
			}
			else
			{
				text = this.adrIpToPing;
			}
			Trs_SegmentTrs trs_SegmentTrs = new Trs_SegmentTrs(this.st, this.protocoleTransport, new Ip_adresse("127.0.0.1"), this.numPortClient, new Ip_adresse(text), this.numPortDest);
			trs_SegmentTrs.MacDepart = this.macDepart;
			trs_SegmentTrs.AdrIpSource = this.adrIpDepart;
			if (this.st.Trs.ReglesFiltrage.Count == 0)
			{
				this.accepterFiltrage = true;
				return -1;
			}
			int i = 0;
			this.accepterFiltrage = false;
			while (i < this.st.Trs.ReglesFiltrage.Count)
			{
				ArrayList arrayList = HashTableEdit.TriGetLignePos(this.st.Trs.ReglesFiltrage, i);
				if (this.st.Trs.RegleApplicable(arrayList, trs_SegmentTrs))
				{
					this.accepterFiltrage = (arrayList[9].ToString() == "Accepter");
					break;
				}
				i++;
			}
			return i;
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00014C74 File Offset: 0x00013C74
		private void calculerResultatAuto()
		{
			if (Trs_station.TrsReponse)
			{
				this.clefRequeteRecue = ReqTrsEdit.GetClef(this.st.Trs.ReqTrsRecues, this.protocoleTransport, new Ip_adresse(this.adrIpToPing), this.numPortDest, new Ip_adresse(this.adrIpSource), this.numPortClient, ref this.itemReqRecue);
				this.clefRequeteEnvoyee = ReqTrsEdit.GetClef(this.st.Trs.ReqTrsEnvoyees, this.protocoleTransport, new Ip_adresse(this.adrIpToPing), this.numPortDest, new Ip_adresse(this.adrIpSource), this.numPortClient, ref this.itemReqEnvoyee);
			}
			this.itemFiltrageOk = this.itemFiltrage();
			object clef = null;
			if (PortsEcoutesEdit.Ecoute(this.st.Trs.PortsEcoutes, this.protocoleTransport.ToString(), this.numPortDest, 1, 2, false, ref clef))
			{
				this.itemPortsEcoutes = this.portsEcoutesEdit1.IndexOf(clef);
			}
			if (!Ip_adresse.Ok(this.adrIpToPing) || Ip_quartet.Isnul(this.adrIpToPing))
			{
				if (this.st.Ip.FichierHosts.ContainsKey(this.adrIpToPing))
				{
					this.itemDestHosts = 1;
					this.adrDestHosts = FichierHostsEdit.GetAdrIp(this.st.Ip.FichierHosts, this.adrIpToPing);
					this.ipAJoindre = this.adrDestHosts;
				}
				else
				{
					this.itemDestHosts = -1;
					this.adrDestHosts = "";
				}
			}
			else
			{
				this.adrDestHosts = "";
			}
			if (this.ipAJoindre != "127.0.0.1" && Ip_adresse.Ok(this.ipAJoindre) && !Ip_quartet.Isnul(this.ipAJoindre))
			{
				this.itemRoute = this.st.Ip.TrouverRoute(new Ip_adresse(this.ipAJoindre), ref this.maCarte, ref this.passerelle);
				if (this.maCarte != null)
				{
					if (Ip_quartet.ValPoste(new Ip_quartet(this.ipAJoindre), this.maCarte.Ip.Masque) == 0U && Ip_quartet.MemeReseau(new Ip_quartet(this.ipAJoindre), this.maCarte.Ip.Adresse, this.maCarte.Ip.Masque))
					{
						this.adresseReseau = true;
					}
					if (this.passerelle != null)
					{
						this.ipAJoindre = this.passerelle;
					}
					if (this.maCarte.GetType() == typeof(CarteAccesDistant))
					{
						this.ppp = true;
					}
					this.ipClient = this.maCarte.Ip.Adresse;
					if (this.st.Ip.TrouverCarteIp(this.ipAJoindre) == null)
					{
						this.adrIpDepart = this.ipClient;
						this.macDepart = this.maCarte.AdresseMac;
					}
					else
					{
						this.adrIpDepart = this.ipClient;
					}
					this.itemFiltrageOk = this.itemFiltrage();
				}
			}
			else
			{
				if (this.ipAJoindre == "127.0.0.1")
				{
					this.ipClient = new Ip_adresse(this.ipAJoindre);
				}
				this.itemRoute = -1;
			}
			if (Ip_adresse.Ok(this.ipAJoindre) && !Ip_quartet.Isnul(this.ipAJoindre))
			{
				this.adrMacDest = CacheArpEdit.GetMac(this.st.Ip.CacheArp, new Ip_adresse(this.ipAJoindre));
				return;
			}
			this.adrMacDest = "";
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00014FD4 File Offset: 0x00013FD4
		private void MontrerTable(Control c, bool modifiable)
		{
			this.lbl_requetes.Visible = false;
			if (c.GetType() == typeof(PortsEcoutesEdit))
			{
				base.Size = new Size(320, 256);
			}
			else if (c.GetType() == typeof(ReglesFiltrageEdit))
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
				if (c.Name == "reqTrsEditRecues")
				{
					this.lbl_requetes.Text = "Requêtes reçues";
				}
				else
				{
					this.lbl_requetes.Text = "Requêtes envoyées";
				}
				this.lbl_requetes.Visible = true;
			}
			else if (c.GetType() == typeof(RouteEdit))
			{
				base.Size = new Size(480, 256);
			}
			else if (c.GetType() == typeof(GroupBox))
			{
				base.Size = new Size(320, 256);
			}
			if (this.typeDemo == Simulation.TypeDeDemo.manuel)
			{
				this.lbl_requetes.Visible = false;
			}
			this.portsEcoutesEdit1.Visible = false;
			this.reglesFiltrageEdit1.Visible = false;
			this.reqTrsEditEnvoyees.Visible = false;
			this.reqTrsEditRecues.Visible = false;
			this.routeEdit1.Visible = false;
			this.gb_messageUtilisateur.Visible = false;
			c.Visible = true;
			base.InScreen();
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00015184 File Offset: 0x00014184
		private void cacherTable()
		{
			this.gb_messageUtilisateur.Visible = false;
			this.lbl_requetes.Visible = false;
			base.Size = new Size(320, 168);
			this.portsEcoutesEdit1.Visible = false;
			this.reglesFiltrageEdit1.Visible = false;
			this.reqTrsEditEnvoyees.Visible = false;
			this.reqTrsEditRecues.Visible = false;
			this.routeEdit1.Visible = false;
			this.gb_messageUtilisateur.Visible = false;
			base.InScreen();
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0001520C File Offset: 0x0001420C
		private string getLibellePhase(int numPhase)
		{
			string result = "";
			switch (numPhase)
			{
			case 0:
				result = "Contrôle de l'adresse IP";
				break;
			case 1:
				result = "Recherche de la route";
				break;
			case 2:
				result = "Mise à jour des échanges";
				break;
			case 3:
				result = "Envoi du paquet";
				break;
			case 4:
				result = "Application des règles de filtrage";
				break;
			case 5:
				result = "Réception du paquet";
				break;
			case 6:
				result = "Affichage du résultat";
				break;
			case 7:
				result = "Affichage du résultat";
				break;
			case 8:
				result = "Affichage du résultat";
				break;
			case 9:
				result = "Affichage du résultat";
				break;
			case 10:
				result = "Affichage du résultat";
				break;
			case 11:
				result = "Réception du paquet";
				break;
			case 12:
				result = "Réception du paquet";
				break;
			case 13:
				result = "";
				break;
			}
			return result;
		}

		// Token: 0x06000245 RID: 581 RVA: 0x000152D0 File Offset: 0x000142D0
		private void ajouterReqEnvoyee()
		{
			ReqTrsEdit.AjouterLigne(this.reqTrsEditEnvoyees.GetTable(), this.protocoleTransport.ToString(), this.ipClient, this.numPortClient, new Ip_adresse(this.adrIpToPing), this.numPortDest);
			this.reqTrsEditEnvoyees.Maj();
			int index = this.reqTrsEditEnvoyees.GetTable().Count - 1;
			this.reqTrsEditEnvoyees.selectIndex(index);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00015344 File Offset: 0x00014344
		private void supprimerReqRecue()
		{
			SortedList table = this.reqTrsEditRecues.GetTable();
			ReqTrsEdit.SupprimerReqTrs(ref table, this.clefRequeteRecue);
			this.reqTrsEditRecues.SetTable(table);
			this.reqTrsEditRecues.selectIndex(-1);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00015384 File Offset: 0x00014384
		protected override void executerPhase()
		{
			this.cacherTable();
			base.LibellePhase = this.getLibellePhase(this.numPhaseSuivante);
			switch (this.numPhaseSuivante)
			{
			case 0:
				if (base.MarcheArriere)
				{
					this.itemFiltrageCourant = 0;
				}
				base.TablesModifiees = true;
				this.tb_ipDestination.Text = this.adrIpToPing;
				if (Ip_adresse.Ok(this.adrIpToPing) && !Ip_quartet.Isnul(this.adrIpToPing))
				{
					if (this.adrIpToPing == "127.0.0.1")
					{
						this.tb_resultat.Text = "Adresse IP locale (loopback)";
						this.tb_ipSource.Text = "127.0.0.1";
						this.numPhaseSuivante = 4;
						this.destinationLocale = true;
						return;
					}
					CarteReseau carteReseau = this.st.Ip.TrouverCarteIp(this.adrIpToPing);
					if (carteReseau == null)
					{
						this.tb_resultat.Text = "Adresse IP non locale";
						this.numPhaseSuivante = 1;
						return;
					}
					this.tb_ipSource.Text = this.adrIpToPing;
					this.destinationLocale = true;
					if (carteReseau.EtatConnexion == PointConnexion.EtatsConnexion.actif)
					{
						this.tb_resultat.Text = "Adresse IP locale";
						this.numPhaseSuivante = 4;
						return;
					}
					this.tb_resultat.Text = "Adresse IP locale, carte HS";
					this.numPhaseSuivante = 6;
					return;
				}
				else
				{
					if (this.itemDestHosts != -1 && !this.fichierHostsConsulte)
					{
						this.fichierHostsConsulte = true;
						this.tb_resultat.Text = "Nom d'hôte (" + this.adrDestHosts.ToString() + ")";
						this.adrIpToPing = this.adrDestHosts;
						this.numPhaseSuivante = 0;
						return;
					}
					this.tb_resultat.Text = "Adr. IP incorrecte";
					this.numPhaseSuivante = 7;
					return;
				}
				break;
			case 1:
				if (base.MarcheArriere)
				{
					this.itemFiltrageCourant = 0;
				}
				base.TablesModifiees = true;
				this.MontrerTable(this.routeEdit1, false);
				if (this.itemRoute == -1)
				{
					this.tb_resultat.Text = "Aucune route trouvée";
					this.numPhaseSuivante = 6;
					return;
				}
				this.routeEdit1.selectIndex(this.itemRoute);
				if (this.adresseReseau)
				{
					this.tb_resultat.Text = "Adresse réseau";
					this.numPhaseSuivante = 7;
					return;
				}
				this.tb_ipSource.Text = this.ipClient.ToString();
				this.tb_carteDepart.Text = this.macDepart;
				if (this.maCarte.EtatConnexion != PointConnexion.EtatsConnexion.actif)
				{
					this.tb_resultat.Text = "IP à joindre : " + this.ipAJoindre + " (non joignable)";
					this.numPhaseSuivante = 6;
					return;
				}
				if (this.ppp)
				{
					this.tb_resultat.Text = "IP à joindre : " + this.ipAJoindre + " (PPP)";
					this.numPhaseSuivante = 4;
					return;
				}
				if (this.adrMacDest == null)
				{
					this.tb_resultat.Text = "IP à joindre : " + this.ipAJoindre + " (non joignable)";
					this.numPhaseSuivante = 6;
					return;
				}
				this.tb_resultat.Text = string.Concat(new string[]
				{
					"IP à joindre : ",
					this.ipAJoindre,
					" (",
					this.adrMacDest,
					")"
				});
				this.numPhaseSuivante = 4;
				return;
			case 2:
				base.TablesModifiees = true;
				if (Trs_station.TrsReponse)
				{
					this.supprimerReqRecue();
					this.tb_resultat.Text = "Requête reçue supprimée";
					this.MontrerTable(this.reqTrsEditRecues, false);
				}
				else
				{
					this.ajouterReqEnvoyee();
					this.tb_resultat.Text = "Requête envoyée ajoutée";
					this.MontrerTable(this.reqTrsEditEnvoyees, false);
				}
				if (!this.destinationLocale)
				{
					this.numPhaseSuivante = 3;
					return;
				}
				if (Trs_station.TrsReponse)
				{
					this.numPhaseSuivante = 5;
					return;
				}
				if (this.protocoleTransport == ProtocoleTrs.ICMP)
				{
					this.numPhaseSuivante = 10;
					return;
				}
				this.numPhaseSuivante = 5;
				return;
			case 3:
				if (this.ppp)
				{
					this.tb_resultat.Text = "De " + this.maCarte.AdresseMac + " vers liaison PPP";
				}
				else
				{
					this.tb_resultat.Text = "De " + this.maCarte.AdresseMac + " vers " + this.adrMacDest;
				}
				this.numPhaseSuivante = 13;
				return;
			case 4:
				if (base.MarcheArriere)
				{
					this.itemFiltrageCourant = 0;
				}
				this.MontrerTable(this.reglesFiltrageEdit1, false);
				if (this.itemFiltrageOk == -1)
				{
					this.tb_resultat.Text = "Aucune règle, accepter";
					this.numPhaseSuivante = 2;
					return;
				}
				if (this.itemFiltrageCourant < this.st.Trs.ReglesFiltrage.Count)
				{
					this.reglesFiltrageEdit1.selectIndex(this.itemFiltrageCourant);
				}
				else
				{
					this.reglesFiltrageEdit1.selectIndex(-1);
				}
				if (this.itemFiltrageCourant != this.itemFiltrageOk)
				{
					this.itemFiltrageCourant++;
					this.tb_resultat.Text = "Règle non applicable";
					return;
				}
				if (this.itemFiltrageOk == this.st.Trs.ReglesFiltrage.Count)
				{
					this.tb_resultat.Text = "Aucune règle applicable, bloquer";
					this.numPhaseSuivante = 8;
					return;
				}
				if (this.accepterFiltrage)
				{
					this.tb_resultat.Text = "Règle applicable : accepter";
					this.numPhaseSuivante = 2;
					return;
				}
				this.tb_resultat.Text = "Règle applicable : bloquer";
				this.numPhaseSuivante = 8;
				return;
			case 5:
				if (Trs_station.TrsReponse)
				{
					this.MontrerTable(this.reqTrsEditEnvoyees, false);
					if (this.itemReqEnvoyee == -1)
					{
						this.reqTrsEditEnvoyees.selectIndex(-1);
						this.tb_resultat.Text = "L'envoi ne correspond à aucune requête";
						this.numPhaseSuivante = 9;
						return;
					}
					this.reqTrsEditEnvoyees.selectIndex(this.itemReqEnvoyee);
					this.tb_resultat.Text = "L'envoi répond à cette requête";
					this.numPhaseSuivante = 11;
					return;
				}
				else
				{
					this.MontrerTable(this.portsEcoutesEdit1, false);
					if (this.itemPortsEcoutes == -1)
					{
						this.tb_resultat.Text = "Port non écouté";
						this.numPhaseSuivante = 9;
						return;
					}
					this.portsEcoutesEdit1.selectIndex(this.itemPortsEcoutes);
					this.tb_resultat.Text = "Port écouté";
					this.numPhaseSuivante = 12;
					return;
				}
				break;
			case 6:
				this.tb_resultat.Text = "Hôte non joignable !";
				this.numPhaseSuivante = 13;
				return;
			case 7:
				this.tb_resultat.Text = "Adresse IP incorrecte !";
				this.numPhaseSuivante = 13;
				return;
			case 8:
				this.tb_resultat.Text = "L'envoi a été filtré !";
				this.numPhaseSuivante = 13;
				return;
			case 9:
				this.tb_resultat.Text = "L'envoi a été refusé !";
				this.numPhaseSuivante = 13;
				return;
			case 10:
				this.tb_resultat.Text = "L'envoi a été accepté !";
				this.numPhaseSuivante = 13;
				return;
			case 11:
			{
				SortedList table = this.reqTrsEditEnvoyees.GetTable();
				ReqTrsEdit.SupprimerReqTrs(ref table, this.clefRequeteEnvoyee);
				this.reqTrsEditEnvoyees.SetTable(table);
				this.reqTrsEditEnvoyees.selectIndex(-1);
				this.tb_resultat.Text = "Requête envoyée supprimée";
				this.MontrerTable(this.reqTrsEditEnvoyees, false);
				this.numPhaseSuivante = 10;
				return;
			}
			case 12:
			{
				ReqTrsEdit.AjouterLigne(this.reqTrsEditRecues.GetTable(), this.protocoleTransport.ToString(), this.ipClient, this.numPortClient, new Ip_adresse(this.adrIpToPing), this.numPortDest);
				this.reqTrsEditRecues.Maj();
				int index = this.reqTrsEditRecues.GetTable().Count - 1;
				this.reqTrsEditRecues.selectIndex(index);
				this.MontrerTable(this.reqTrsEditRecues, false);
				this.tb_resultat.Text = "Requête reçue ajoutée";
				this.numPhaseSuivante = 10;
				return;
			}
			case 13:
				this.numPhaseSuivante = 14;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00015B20 File Offset: 0x00014B20
		private void calculerResultatManuel()
		{
			this.reqTrsEditEnvoyees.ChangerMode(false);
			this.reqTrsEditRecues.ChangerMode(false);
			this.okReqEnvoyees = HashTableEdit.CopieProfonde(this.st.Trs.ReqTrsEnvoyees);
			this.okReqRecues = HashTableEdit.CopieProfonde(this.st.Trs.ReqTrsRecues);
			bool flag = true;
			if (!Ip_adresse.Ok(this.adrIpToPing) && this.itemDestHosts != -1)
			{
				this.adrIpToPing = this.adrDestHosts;
			}
			if (Ip_adresse.Ok(this.adrIpToPing) && !Ip_quartet.Isnul(this.adrIpToPing))
			{
				if (this.adrIpToPing == "127.0.0.1")
				{
					this.destinationLocale = true;
				}
				else
				{
					CarteReseau carteReseau = this.st.Ip.TrouverCarteIp(this.adrIpToPing);
					if (carteReseau != null)
					{
						this.destinationLocale = true;
						if (carteReseau.EtatConnexion != PointConnexion.EtatsConnexion.actif)
						{
							flag = false;
							this.numeroMessage = 1;
							this.phasesAValider.Add(6);
						}
					}
					else if (this.itemRoute == -1)
					{
						this.numeroMessage = 1;
						this.phasesAValider.Add(6);
						flag = false;
					}
					else if (this.adresseReseau)
					{
						this.numeroMessage = 2;
						this.phasesAValider.Add(6);
						flag = false;
					}
					else if (this.maCarte.EtatConnexion == PointConnexion.EtatsConnexion.actif)
					{
						if (!this.ppp && this.adrMacDest == null)
						{
							this.numeroMessage = 1;
							this.phasesAValider.Add(6);
							flag = false;
						}
					}
					else
					{
						this.numeroMessage = 1;
						this.phasesAValider.Add(6);
						flag = false;
					}
				}
			}
			else
			{
				this.numeroMessage = 2;
				this.phasesAValider.Add(6);
				flag = false;
			}
			if (flag)
			{
				if (this.accepterFiltrage)
				{
					if (Trs_station.TrsReponse)
					{
						ReqTrsEdit.SupprimerReqTrs(ref this.okReqRecues, this.clefRequeteRecue);
					}
					else
					{
						ReqTrsEdit.AjouterLigne(this.okReqEnvoyees, this.protocoleTransport.ToString(), this.ipClient, this.numPortClient, new Ip_adresse(this.adrIpToPing), this.numPortDest);
					}
					if (this.destinationLocale)
					{
						if (!Trs_station.TrsReponse && this.protocoleTransport == ProtocoleTrs.ICMP)
						{
							ReqTrsEdit.AjouterLigne(this.okReqRecues, this.protocoleTransport.ToString(), this.ipClient, this.numPortClient, new Ip_adresse(this.adrIpToPing), this.numPortDest);
							this.numeroMessage = 5;
							this.phasesAValider.Add(6);
							flag = false;
						}
					}
					else
					{
						flag = false;
						this.phasesAValider.Add(7);
					}
				}
				else
				{
					this.numeroMessage = 3;
					this.phasesAValider.Add(6);
					flag = false;
				}
			}
			if (flag)
			{
				if (Trs_station.TrsReponse)
				{
					if (this.itemReqEnvoyee == -1)
					{
						this.numeroMessage = 4;
						this.phasesAValider.Add(6);
						return;
					}
					ReqTrsEdit.SupprimerReqTrs(ref this.okReqEnvoyees, this.clefRequeteEnvoyee);
					this.numeroMessage = 5;
					this.phasesAValider.Add(6);
					return;
				}
				else
				{
					if (this.itemPortsEcoutes == -1)
					{
						this.numeroMessage = 4;
						this.phasesAValider.Add(6);
						return;
					}
					ReqTrsEdit.AjouterLigne(this.okReqRecues, this.protocoleTransport.ToString(), this.ipClient, this.numPortClient, new Ip_adresse(this.adrIpToPing), this.numPortDest);
					this.numeroMessage = 5;
					this.phasesAValider.Add(6);
				}
			}
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00015ECC File Offset: 0x00014ECC
		protected override void initManuel()
		{
			this.init();
			this.Text = "Station : " + ((Station)this.elt).NomNoeud;
			this.nbPhasesManuelles = 8;
			base.initManuel();
			this.cacherTable();
			this.cb_action.Items.Clear();
			this.cb_action.Items.Add("Chercher la route...");
			this.cb_action.Items.Add("Consulter règles de filtrage...");
			this.cb_action.Items.Add("Consulter les ports écoutés...");
			this.cb_action.Items.Add("Editer requêtes envoyées...");
			this.cb_action.Items.Add("Editer requêtes reçues...");
			this.cb_action.Items.Add("Préparer message utilisateur...");
			this.cb_action.Items.Add("Afficher le message préparé -->");
			this.cb_action.Items.Add("Envoyer le paquet -->");
			this.calculerResultatManuel();
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00015FD8 File Offset: 0x00014FD8
		protected override void executerPhaseManuelle(int numPhaseManuelle)
		{
			this.cacherTable();
			switch (numPhaseManuelle)
			{
			case 0:
				this.tb_ipDestination.Text = this.adrIpToPing;
				if (Ip_adresse.Ok(this.adrIpToPing) || Ip_quartet.Isnul(this.adrIpToPing))
				{
					if (this.adrIpToPing == "127.0.0.1")
					{
						this.messageManuelOk = "Adresse IP locale (loopback)";
						this.tb_ipSource.Text = "127.0.0.1";
					}
					else
					{
						CarteReseau carteReseau = this.st.Ip.TrouverCarteIp(this.adrIpToPing);
						if (carteReseau != null)
						{
							this.tb_ipSource.Text = this.adrIpToPing;
							if (carteReseau.EtatConnexion != PointConnexion.EtatsConnexion.actif)
							{
								this.messageManuelOk = "Adresse IP locale, carte HS";
							}
							else
							{
								this.messageManuelOk = "Adresse IP locale";
							}
						}
						else if (this.itemRoute == -1)
						{
							this.messageManuelOk = "Aucune route trouvée";
						}
						else if (this.adresseReseau)
						{
							this.messageManuelOk = "Adresse IP incorrecte";
						}
						else
						{
							this.tb_ipSource.Text = this.ipClient.ToString();
							this.tb_carteDepart.Text = this.macDepart;
							if (this.maCarte.EtatConnexion == PointConnexion.EtatsConnexion.actif)
							{
								if (!this.ppp)
								{
									if (this.adrMacDest == null)
									{
										this.messageManuelOk = "IP à joindre : " + this.ipAJoindre + " (non joignable)";
									}
									else
									{
										this.messageManuelOk = string.Concat(new string[]
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
									this.messageManuelOk = "IP à joindre : " + this.ipAJoindre + " (PPP)";
								}
							}
							else
							{
								this.messageManuelOk = "IP à joindre : " + this.ipAJoindre + " (non joignable)";
							}
						}
					}
				}
				else
				{
					this.messageManuelOk = "Adresse IP incorrecte";
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
				this.MontrerTable(this.reqTrsEditEnvoyees, true);
				this.messageManuelOk = "Requêtes envoyées";
				this.okManuel = true;
				return;
			case 4:
				this.MontrerTable(this.reqTrsEditRecues, true);
				this.messageManuelOk = "Requêtes reçues";
				this.okManuel = true;
				return;
			case 5:
				this.MontrerTable(this.gb_messageUtilisateur, false);
				this.messageManuelOk = "Choisissez le message...";
				this.okManuel = true;
				return;
			case 6:
				if (this.phasesAValider.Contains(6))
				{
					switch (this.numeroMessage)
					{
					case 1:
						this.okManuel = this.rb_nonJoignable.Checked;
						break;
					case 2:
						this.okManuel = this.rb_adrIpIncorrecte.Checked;
						break;
					case 3:
						this.okManuel = this.rb_filtre.Checked;
						break;
					case 4:
						this.okManuel = this.rb_refuse.Checked;
						break;
					case 5:
						this.okManuel = this.rb_accepte.Checked;
						break;
					}
					if (!this.okManuel)
					{
						this.messageManuelErreur = "Message utilisateur incorrect !";
						return;
					}
					if (!HashTableEdit.Identiques(this.okReqEnvoyees, this.reqTrsEditEnvoyees.GetTable()))
					{
						this.messageManuelErreur = "requêtes envoyées incorrectes !";
						this.okManuel = false;
						return;
					}
					if (!HashTableEdit.Identiques(this.okReqRecues, this.reqTrsEditRecues.GetTable()))
					{
						this.messageManuelErreur = "requêtes reçues incorrectes !";
						this.okManuel = false;
						return;
					}
				}
				break;
			case 7:
				if (this.phasesAValider.Contains(7))
				{
					if (HashTableEdit.Identiques(this.okReqEnvoyees, this.reqTrsEditEnvoyees.GetTable()))
					{
						if (!HashTableEdit.Identiques(this.okReqRecues, this.reqTrsEditRecues.GetTable()))
						{
							this.messageManuelErreur = "requêtes reçues incorrectes !";
							return;
						}
						if (this.tb_carteDepart.Text != this.macDepart)
						{
							this.messageManuelErreur = "Adresse mac départ incorrecte !";
							return;
						}
						this.okManuel = true;
						return;
					}
					else
					{
						this.messageManuelErreur = "requêtes envoyées incorrectes !";
					}
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00016418 File Offset: 0x00015418
		public DemoEnvoyerSegment(Form f) : base(f)
		{
			this.InitializeComponent();
			base.Owner = f;
			this.actions = new ArrayList();
			this.actions.Add("Contrôler l'adresse IP");
			this.actions.Add("Chercher la route");
			this.actions.Add("");
			this.actions.Add("Envoyer le paquet");
			this.actions.Add("Examiner table de filtrage");
			this.actions.Add("");
			this.actions.Add("Afficher message échec");
			this.actions.Add("Afficher message échec");
			this.actions.Add("Afficher message échec");
			this.actions.Add("Afficher message échec");
			this.actions.Add("Afficher message de réussite");
			this.actions.Add("Supprimer l'entrée");
			this.actions.Add("Ajouter une entrée");
			this.actions.Add("Fin de la démonstration");
			base.initTables(null);
		}

		// Token: 0x0600024C RID: 588 RVA: 0x000165C0 File Offset: 0x000155C0
		protected override ArrayList getTables()
		{
			SortedList sortedList = new SortedList();
			sortedList["ipSource"] = this.tb_ipSource.Text;
			sortedList["macDepart"] = this.tb_carteDepart.Text;
			sortedList["adrIpToPing"] = this.adrIpToPing;
			return new ArrayList
			{
				sortedList.Clone(),
				this.reqTrsEditEnvoyees.GetTable().Clone(),
				this.reqTrsEditRecues.GetTable().Clone()
			};
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00016654 File Offset: 0x00015654
		protected override void setTables(ArrayList p_tables)
		{
			SortedList sortedList = (SortedList)p_tables[0];
			this.tb_ipSource.Text = sortedList["ipSource"].ToString();
			this.tb_carteDepart.Text = sortedList["macDepart"].ToString();
			this.adrIpToPing = sortedList["adrIpToPing"].ToString();
			this.reqTrsEditEnvoyees.SetTable((SortedList)((SortedList)p_tables[1]).Clone());
			this.reqTrsEditRecues.SetTable((SortedList)((SortedList)p_tables[2]).Clone());
		}

		// Token: 0x04000164 RID: 356
		private int itemDestHosts;

		// Token: 0x04000165 RID: 357
		private string adrDestHosts;

		// Token: 0x04000166 RID: 358
		private string adrMacDest;

		// Token: 0x04000167 RID: 359
		private int itemRoute;

		// Token: 0x04000168 RID: 360
		private string ipAJoindre;

		// Token: 0x04000169 RID: 361
		private CarteReseau maCarte = null;

		// Token: 0x0400016A RID: 362
		private string passerelle = null;

		// Token: 0x0400016B RID: 363
		private bool adresseReseau = false;

		// Token: 0x0400016C RID: 364
		private bool ppp = false;

		// Token: 0x0400016D RID: 365
		private bool destinationLocale = false;

		// Token: 0x0400016E RID: 366
		private int itemFiltrageOk = -1;

		// Token: 0x0400016F RID: 367
		private int itemFiltrageCourant = 0;

		// Token: 0x04000170 RID: 368
		private bool accepterFiltrage = false;

		// Token: 0x04000171 RID: 369
		private int itemPortsEcoutes = -1;

		// Token: 0x04000172 RID: 370
		private Ip_adresse ipClient = new Ip_adresse("0.0.0.0");

		// Token: 0x04000173 RID: 371
		private string macDepart = null;

		// Token: 0x04000174 RID: 372
		private Ip_adresse adrIpDepart = null;

		// Token: 0x04000175 RID: 373
		private object clefRequeteRecue = null;

		// Token: 0x04000176 RID: 374
		private object clefRequeteEnvoyee = null;

		// Token: 0x04000177 RID: 375
		private int itemReqEnvoyee = -1;

		// Token: 0x04000178 RID: 376
		private int itemReqRecue = -1;

		// Token: 0x04000179 RID: 377
		private bool fichierHostsConsulte = false;

		// Token: 0x0400017A RID: 378
		private int numeroMessage;

		// Token: 0x0400017B RID: 379
		private SortedList okReqRecues;

		// Token: 0x0400017C RID: 380
		private SortedList okReqEnvoyees;
	}
}
