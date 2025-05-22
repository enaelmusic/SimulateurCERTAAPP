using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000026 RID: 38
	public partial class DemoPaquetIp : DemoDialogue
	{
		// Token: 0x06000257 RID: 599 RVA: 0x00016FB4 File Offset: 0x00015FB4
		public DemoPaquetIp()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600025A RID: 602 RVA: 0x00018AD8 File Offset: 0x00017AD8
		private Station st
		{
			get
			{
				return (Station)this.elt;
			}
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00018AF0 File Offset: 0x00017AF0
		protected override void init()
		{
			this.cacheArpEdit1.init(this.st.Ip, true);
			this.routeEdit1.init(this.st.Ip, true);
			this.tb_resultat.Text = "";
			this.tb_destination.Text = this.paquet.AdrDest.ToString();
			this.carteLocaleDestFinale = this.st.Ip.TrouverCarteIp(this.tb_destination.Text);
			this.destLocale = (this.carteLocaleDestFinale != null);
			this.tb_ipCarte.Text = this.paquet.CarteDest.Ip.Adresse.ToString() + " (" + this.paquet.CarteDest.Ip.Masque.ToString() + ")";
			this.tb_numCarte.Text = this.st.Ip.TrouverCarteIp(this.paquet.CarteDest.Ip.Adresse.ToString()).NumeroOrdre.ToString();
			if (((Station)this.paquet.CarteDest.NoeudAttache).Ip.RoutageActif)
			{
				this.tb_routage.Text = "Actif";
				this.routageActif = true;
			}
			else
			{
				this.tb_routage.Text = "Non actif";
				this.routageActif = false;
			}
			this.memeReseauDestLocale = Ip_quartet.MemeReseau(this.paquet.CarteDest.Ip.Adresse.ToString(), this.tb_destination.Text, this.paquet.CarteDest.Ip.Masque.ToString());
			if (this.destLocale)
			{
				this.carteLocaleActive = (this.carteLocaleDestFinale.EtatConnexion == PointConnexion.EtatsConnexion.actif);
			}
			if (this.destLocale && this.paquet.Type == TypeDePaquetIp.IcmpEchoRequest)
			{
				this.ipAJoindre = this.paquet.AdrSource.ToString();
			}
			else
			{
				this.ipAJoindre = this.paquet.AdrDest.ToString();
			}
			this.chercherMacEtRoute();
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00018D1C File Offset: 0x00017D1C
		private void chercherMacEtRoute()
		{
			if (Ip_adresse.Ok(this.ipAJoindre))
			{
				this.itemRoute = this.st.Ip.TrouverRoute(new Ip_adresse(this.ipAJoindre), ref this.maCarte, ref this.passerelle);
				if (this.maCarte != null)
				{
					if (this.passerelle != null)
					{
						this.ipAJoindre = this.passerelle;
					}
					if (this.maCarte.GetType() == typeof(CarteAccesDistant) || this.maCarte.GetType() == typeof(PortFai))
					{
						this.ppp = true;
					}
				}
			}
			else
			{
				this.itemRoute = -1;
			}
			if (Ip_adresse.Ok(this.ipAJoindre))
			{
				this.itemMacDest = this.cacheArpEdit1.IndexOf(Ip_quartet.FormatFixe(this.ipAJoindre));
				if (this.itemMacDest != -1)
				{
					this.adrMacDest = CacheArpEdit.GetMac(this.cacheArpEdit1.GetTable(), new Ip_adresse(this.ipAJoindre));
					return;
				}
			}
			else
			{
				this.itemMacDest = -1;
			}
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00018E1C File Offset: 0x00017E1C
		private void MontrerTable(Control c, bool modifiable)
		{
			if (c.GetType() == typeof(TextBox))
			{
				base.Size = new Size(228, 156);
			}
			else if (c.GetType() == typeof(CacheArpEdit))
			{
				base.Size = new Size(328, 188);
			}
			else if (c.GetType() == typeof(RouteEdit))
			{
				base.Size = new Size(480, 188);
			}
			else if (c.GetType() == typeof(Panel))
			{
				if (c.Name == this.pn_configIp.Name)
				{
					base.Size = new Size(476, 192);
				}
				else
				{
					base.Size = new Size(452, 192);
				}
			}
			this.cacheArpEdit1.Visible = false;
			this.routeEdit1.Visible = false;
			this.pn_configIp.Visible = false;
			this.pn_paquetIp.Visible = false;
			this.pn_nouveauPaquetIp.Visible = false;
			c.Visible = true;
			base.InScreen();
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00018F48 File Offset: 0x00017F48
		private void cacherTable()
		{
			base.Size = new Size(228, 156);
			this.cacheArpEdit1.Visible = false;
			this.routeEdit1.Visible = false;
			this.pn_configIp.Visible = false;
			this.pn_paquetIp.Visible = false;
			this.pn_nouveauPaquetIp.Visible = false;
			base.InScreen();
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00018FAC File Offset: 0x00017FAC
		private string getLibellePhase(int numPhase)
		{
			string result = "";
			switch (numPhase)
			{
			case 0:
				result = "Recherche de la destination";
				break;
			case 1:
				result = "Traitement local du paquet";
				break;
			case 2:
				result = "Traitement local du paquet";
				break;
			case 3:
				result = "Traitement local du paquet";
				break;
			case 4:
				result = "Traitement local du paquet";
				break;
			case 5:
				result = "Routage du paquet";
				break;
			case 6:
				result = "Routage du paquet";
				break;
			case 7:
				result = "Routage du paquet";
				break;
			case 8:
				result = "Construction de la réponse";
				break;
			case 9:
				result = "Recherche de la route";
				break;
			case 10:
				result = "Recherche de l'adresse MAC";
				break;
			case 11:
				result = "Envoi du paquet";
				break;
			case 12:
				result = "Préparation du paquet IP";
				break;
			case 13:
				result = "Envoi de la requête ARP";
				break;
			case 14:
				result = "";
				break;
			}
			return result;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0001907C File Offset: 0x0001807C
		protected override void executerPhase()
		{
			base.LibellePhase = this.getLibellePhase(this.numPhaseSuivante);
			this.cacherTable();
			switch (this.numPhaseSuivante)
			{
			case 0:
				if (!this.destLocale)
				{
					this.tb_resultat.Text = "Destination non locale";
					this.numPhaseSuivante = 5;
					return;
				}
				if (this.carteLocaleActive)
				{
					this.tb_resultat.Text = "Destination locale";
					this.numPhaseSuivante = 2;
					return;
				}
				this.tb_resultat.Text = "Destination locale, carte inactive";
				this.numPhaseSuivante = 6;
				return;
			case 1:
				if (this.memeReseauDestLocale)
				{
					this.tb_resultat.Text = "Dest. et carte même réseau";
					this.numPhaseSuivante = 2;
					return;
				}
				this.tb_resultat.Text = "Réseaux dest. et carte différents";
				this.numPhaseSuivante = 4;
				return;
			case 2:
				if (this.paquet.Type == TypeDePaquetIp.IcmpEchoResponse)
				{
					this.tb_resultat.Text = "Paquet Echo Response";
					this.numPhaseSuivante = 3;
					return;
				}
				this.tb_resultat.Text = "Paquet Echo Request";
				this.numPhaseSuivante = 8;
				return;
			case 3:
				this.tb_resultat.Text = "L'hôte a bien renvoyé le paquet";
				this.numPhaseSuivante = 14;
				return;
			case 4:
				if (this.routageActif)
				{
					this.tb_resultat.Text = "Paquet transmis à " + this.carteLocaleDestFinale.AdresseMac;
					this.numPhaseSuivante = 2;
					return;
				}
				this.tb_resultat.Text = "Ne pas transmettre le paquet";
				this.numPhaseSuivante = 6;
				return;
			case 5:
				if (this.routageActif)
				{
					this.tb_resultat.Text = "Router le paquet";
					this.numPhaseSuivante = 7;
					return;
				}
				this.tb_resultat.Text = "Ne pas router le paquet";
				this.numPhaseSuivante = 6;
				return;
			case 6:
				this.tb_resultat.Text = "Paquet non traité";
				this.numPhaseSuivante = 14;
				return;
			case 7:
				base.TablesModifiees = true;
				if (this.paquet.NbSauts > 0)
				{
					this.tb_resultat.Text = "Décrémenter le TTL du paquet (" + (this.paquet.NbSauts - 1) + ")";
					this.st.Reseau.FixerTtlPaquetIp(this.paquet.NbSauts - 1);
					this.numPhaseSuivante = 9;
					return;
				}
				this.tb_resultat.Text = "TTL épuisé, ne pas router le paquet";
				this.numPhaseSuivante = 6;
				return;
			case 8:
				this.tb_resultat.Text = this.paquet.AdrDest + " à " + this.paquet.AdrSource;
				this.numPhaseSuivante = 9;
				return;
			case 9:
				this.MontrerTable(this.routeEdit1, false);
				if (this.itemRoute == -1)
				{
					this.tb_resultat.Text = "Aucune route trouvée";
					this.numPhaseSuivante = 6;
					return;
				}
				this.routeEdit1.selectIndex(this.itemRoute);
				if (!this.ppp)
				{
					this.tb_resultat.Text = "IP à joindre : " + this.ipAJoindre;
					this.numPhaseSuivante = 10;
					return;
				}
				this.tb_resultat.Text = "IP à joindre : " + this.ipAJoindre + " (PPP)";
				this.numPhaseSuivante = 11;
				return;
			case 10:
				this.MontrerTable(this.cacheArpEdit1, false);
				if (this.itemMacDest == -1)
				{
					this.tb_resultat.Text = "Aucune correspondance trouvée";
					this.numPhaseSuivante = 12;
					return;
				}
				this.cacheArpEdit1.selectIndex(this.itemMacDest);
				this.tb_resultat.Text = "Adr MAC : " + this.adrMacDest;
				this.numPhaseSuivante = 11;
				return;
			case 11:
				if (this.ppp)
				{
					this.tb_resultat.Text = "De " + this.maCarte.AdresseMac + " vers liaison PPP";
				}
				else
				{
					this.tb_resultat.Text = "De " + this.maCarte.AdresseMac + " vers " + this.adrMacDest;
				}
				this.numPhaseSuivante = 14;
				return;
			case 12:
				this.tb_resultat.Text = this.paquet.Type.ToString() + " " + this.paquet.AdrDest;
				this.numPhaseSuivante = 13;
				return;
			case 13:
				this.tb_resultat.Text = "De " + this.maCarte.AdresseMac + " vers " + this.st.Reseau.Pref.AdrMacBroadcast;
				this.numPhaseSuivante = 14;
				return;
			case 14:
				this.numPhaseSuivante = 15;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00019504 File Offset: 0x00018504
		private void calculerResultatManuel()
		{
			if (this.destLocale)
			{
				if (!this.carteLocaleActive)
				{
					this.phasesAValider.Add(6);
					return;
				}
				if (this.paquet.Type == TypeDePaquetIp.IcmpEchoResponse)
				{
					this.phasesAValider.Add(8);
					return;
				}
				if (this.itemRoute == -1)
				{
					this.phasesAValider.Add(6);
					return;
				}
				if (this.ppp)
				{
					this.phasesAValider.Add(7);
					this.paquetNouveauOk = new Ip_PaquetIpDemoManuel("ppp", this.maCarte.AdresseMac, this.st.Reseau.Pref.NbSautsMax, this.paquet.AdrDest.ToString(), this.paquet.AdrSource.ToString(), TypeDePaquetIp.IcmpEchoResponse);
					return;
				}
				if (this.itemMacDest == -1)
				{
					this.phasesAValider.Add(7);
					this.paquetNouveauOk = new Ip_PaquetIpDemoManuel(this.st.Reseau.Pref.AdrMacBroadcast, this.maCarte.AdresseMac, -1, this.paquet.AdrDest.ToString(), this.paquet.AdrSource.ToString(), TypeDePaquetIp.ArpRequest);
					return;
				}
				this.phasesAValider.Add(7);
				this.paquetNouveauOk = new Ip_PaquetIpDemoManuel(this.adrMacDest, this.maCarte.AdresseMac, this.st.Reseau.Pref.NbSautsMax, this.paquet.AdrDest.ToString(), this.paquet.AdrSource.ToString(), TypeDePaquetIp.IcmpEchoResponse);
				return;
			}
			else
			{
				if (!this.routageActif)
				{
					this.phasesAValider.Add(6);
					return;
				}
				if (this.paquet.NbSauts <= 0)
				{
					this.phasesAValider.Add(6);
					return;
				}
				if (this.itemRoute == -1)
				{
					this.phasesAValider.Add(6);
					return;
				}
				if (this.ppp)
				{
					this.phasesAValider.Add(5);
					this.paquetRecuOk = new Ip_PaquetIpDemoManuel("ppp", this.maCarte.AdresseMac, this.paquet.NbSauts - 1, this.paquet.AdrSource.ToString(), this.paquet.AdrDest.ToString(), this.paquet.Type);
					return;
				}
				if (this.itemMacDest == -1)
				{
					this.phasesAValider.Add(7);
					this.paquetNouveauOk = new Ip_PaquetIpDemoManuel(this.st.Reseau.Pref.AdrMacBroadcast, this.maCarte.AdresseMac, -1, this.maCarte.Ip.Adresse.ToString(), this.ipAJoindre, TypeDePaquetIp.ArpRequest);
					this.paquetRecuOk = new Ip_PaquetIpDemoManuel("via arp", this.maCarte.AdresseMac, this.paquet.NbSauts - 1, this.paquet.AdrSource.ToString(), this.paquet.AdrDest.ToString(), this.paquet.Type);
					return;
				}
				this.phasesAValider.Add(5);
				this.paquetRecuOk = new Ip_PaquetIpDemoManuel(this.adrMacDest, this.maCarte.AdresseMac, this.paquet.NbSauts - 1, this.paquet.AdrSource.ToString(), this.paquet.AdrDest.ToString(), this.paquet.Type);
				return;
			}
		}

		// Token: 0x06000262 RID: 610 RVA: 0x000198A0 File Offset: 0x000188A0
		protected override void initManuel()
		{
			this.init();
			this.Text = "Station : " + ((Station)this.elt).NomNoeud;
			this.nbPhasesManuelles = 9;
			base.initManuel();
			this.cacherTable();
			this.tb_nomHote.Text = this.st.NomNoeud;
			this.tb_passerelle.Text = this.st.Ip.Passerelle.ToString();
			int num = 1;
			this.lb_interface.Items.Add("Interfaces :");
			foreach (object obj in this.st.Controls)
			{
				CarteReseau carteReseau = (CarteReseau)obj;
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
			this.cb_activerRoutage.Checked = this.st.Ip.RoutageActif;
			this.cb_action.Items.Clear();
			this.cb_action.Items.Add("Consulter configuration IP...");
			this.cb_action.Items.Add("Consulter table de routage...");
			this.cb_action.Items.Add("Consulter cache ARP...");
			this.cb_action.Items.Add("Modifier le paquet reçu...");
			this.cb_action.Items.Add("Préparer nouv. paquet IP/ARP...");
			this.cb_action.Items.Add("Router le paquet reçu -->");
			this.cb_action.Items.Add("Abandonner le paquet reçu -->");
			this.cb_action.Items.Add("Envoyer le nouveau paquet -->");
			this.cb_action.Items.Add("Afficher 'Réponse ping ok' -->");
			this.calculerResultatManuel();
			this.cb_ttl.Items.Clear();
			for (int i = 0; i <= this.st.Reseau.Pref.NbSautsMax; i++)
			{
				this.cb_ttl.Items.Add(i);
			}
			this.cb_ttlNouveau.Items.Clear();
			for (int j = 0; j <= this.st.Reseau.Pref.NbSautsMax; j++)
			{
				this.cb_ttlNouveau.Items.Add(j);
			}
			this.cb_adrMacSource.Items.Clear();
			foreach (object obj2 in this.st.Controls)
			{
				CarteReseau carteReseau2 = (CarteReseau)obj2;
				this.cb_adrMacSource.Items.Add(carteReseau2.AdresseMac);
			}
			this.cb_adrMacSourceNouveau.Items.Clear();
			foreach (object obj3 in this.st.Controls)
			{
				CarteReseau carteReseau3 = (CarteReseau)obj3;
				this.cb_adrMacSourceNouveau.Items.Add(carteReseau3.AdresseMac);
			}
			switch (this.paquet.Type)
			{
			case TypeDePaquetIp.IcmpEchoRequest:
				this.cb_typePaquet.SelectedIndex = 0;
				break;
			case TypeDePaquetIp.IcmpEchoResponse:
				this.cb_typePaquet.SelectedIndex = 1;
				break;
			case TypeDePaquetIp.ArpRequest:
				this.cb_typePaquet.SelectedIndex = 2;
				break;
			case TypeDePaquetIp.ArpReply:
				this.cb_typePaquet.SelectedIndex = 3;
				break;
			}
			this.cb_adrMacSource.SelectedIndex = -1;
			this.tb_adrMacDest.Text = "Clic sur la carte";
			this.tb_adrIpSource.Text = this.paquet.AdrSource.ToString();
			this.tb_adrIpDest.Text = this.paquet.AdrDest.ToString();
			this.cb_ttl.SelectedIndex = this.paquet.NbSauts;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x00019D78 File Offset: 0x00018D78
		protected override void executerPhaseManuelle(int numPhaseManuelle)
		{
			this.cacherTable();
			switch (numPhaseManuelle)
			{
			case 0:
				this.MontrerTable(this.pn_configIp, false);
				this.messageManuelOk = "Configuration IP du poste";
				this.okManuel = true;
				return;
			case 1:
				this.MontrerTable(this.routeEdit1, false);
				this.messageManuelOk = "Table de routage";
				this.okManuel = true;
				return;
			case 2:
				this.MontrerTable(this.cacheArpEdit1, false);
				this.messageManuelOk = "Cache ARP";
				this.okManuel = true;
				return;
			case 3:
				this.paquetRecuModifie = true;
				this.MontrerTable(this.pn_paquetIp, false);
				this.messageManuelOk = "Modifiez le paquet reçu...";
				this.okManuel = true;
				return;
			case 4:
				this.MontrerTable(this.pn_nouveauPaquetIp, false);
				this.messageManuelOk = "Paramétrez le nouveau paquet...";
				this.okManuel = true;
				return;
			case 5:
				if (this.phasesAValider.Contains(5))
				{
					this.messageManuelErreur = "Paquet reçu incorrect !";
					TypeDePaquetIp typeDePaquetIp;
					if (this.cb_typePaquet.SelectedIndex == -1)
					{
						typeDePaquetIp = TypeDePaquetIp.Aucun;
					}
					else
					{
						typeDePaquetIp = (TypeDePaquetIp)Enum.Parse(typeof(TypeDePaquetIp), this.cb_typePaquet.Items[this.cb_typePaquet.SelectedIndex].ToString());
					}
					int p_ttl;
					if (typeDePaquetIp != TypeDePaquetIp.IcmpEchoRequest && typeDePaquetIp != TypeDePaquetIp.IcmpEchoResponse)
					{
						p_ttl = -1;
					}
					else if (this.cb_ttl.SelectedIndex == -1)
					{
						p_ttl = -1;
					}
					else
					{
						p_ttl = (int)this.cb_ttl.Items[this.cb_ttl.SelectedIndex];
					}
					string p_macSource;
					if (this.cb_adrMacSource.SelectedIndex == -1)
					{
						p_macSource = "";
					}
					else
					{
						p_macSource = this.cb_adrMacSource.Items[this.cb_adrMacSource.SelectedIndex].ToString();
					}
					this.paquetRecuPropose = new Ip_PaquetIpDemoManuel(this.tb_adrMacDest.Text, p_macSource, p_ttl, this.tb_adrIpSource.Text, this.tb_adrIpDest.Text, typeDePaquetIp);
					this.okManuel = this.paquetRecuPropose.Idem(this.paquetRecuOk);
					return;
				}
				break;
			case 6:
				if (this.phasesAValider.Contains(6))
				{
					this.okManuel = true;
					return;
				}
				break;
			case 7:
				if (this.phasesAValider.Contains(7))
				{
					TypeDePaquetIp typeDePaquetIp2;
					if (this.cb_typePaquetNouveau.SelectedIndex == -1)
					{
						typeDePaquetIp2 = TypeDePaquetIp.Aucun;
					}
					else
					{
						typeDePaquetIp2 = (TypeDePaquetIp)Enum.Parse(typeof(TypeDePaquetIp), this.cb_typePaquetNouveau.Items[this.cb_typePaquetNouveau.SelectedIndex].ToString());
					}
					if (typeDePaquetIp2 == TypeDePaquetIp.ArpRequest && !this.paquetRecuModifie)
					{
						this.messageManuelErreur = "Paquet IP reçu non modifié !";
						return;
					}
					int p_ttl2;
					if (typeDePaquetIp2 != TypeDePaquetIp.IcmpEchoRequest && typeDePaquetIp2 != TypeDePaquetIp.IcmpEchoResponse)
					{
						p_ttl2 = -1;
					}
					else if (this.cb_ttlNouveau.SelectedIndex == -1)
					{
						p_ttl2 = -1;
					}
					else
					{
						p_ttl2 = (int)this.cb_ttlNouveau.Items[this.cb_ttlNouveau.SelectedIndex];
					}
					string p_macSource2;
					if (this.cb_adrMacSourceNouveau.SelectedIndex == -1)
					{
						p_macSource2 = "";
					}
					else
					{
						p_macSource2 = this.cb_adrMacSourceNouveau.Items[this.cb_adrMacSourceNouveau.SelectedIndex].ToString();
					}
					this.paquetNouveauPropose = new Ip_PaquetIpDemoManuel(this.tb_adrMacDestNouveau.Text, p_macSource2, p_ttl2, this.tb_adrIpSourceNouveau.Text, this.tb_adrIpDestNouveau.Text, typeDePaquetIp2);
					if (!this.paquetNouveauPropose.Idem(this.paquetNouveauOk))
					{
						this.messageManuelErreur = "Nouveau paquet incorrect !";
						return;
					}
					if (this.paquetRecuOk != null)
					{
						this.messageManuelErreur = "Paquet reçu incorrect !";
						if (this.cb_typePaquet.SelectedIndex == -1)
						{
							typeDePaquetIp2 = TypeDePaquetIp.Aucun;
						}
						else
						{
							typeDePaquetIp2 = (TypeDePaquetIp)Enum.Parse(typeof(TypeDePaquetIp), this.cb_typePaquet.Items[this.cb_typePaquet.SelectedIndex].ToString());
						}
						if (typeDePaquetIp2 != TypeDePaquetIp.IcmpEchoRequest && typeDePaquetIp2 != TypeDePaquetIp.IcmpEchoResponse)
						{
							p_ttl2 = -1;
						}
						else if (this.cb_ttl.SelectedIndex == -1)
						{
							p_ttl2 = -1;
						}
						else
						{
							p_ttl2 = (int)this.cb_ttl.Items[this.cb_ttl.SelectedIndex];
						}
						if (this.cb_adrMacSource.SelectedIndex == -1)
						{
							p_macSource2 = "";
						}
						else
						{
							p_macSource2 = this.cb_adrMacSource.Items[this.cb_adrMacSource.SelectedIndex].ToString();
						}
						this.paquetRecuPropose = new Ip_PaquetIpDemoManuel(this.tb_adrMacDest.Text, p_macSource2, p_ttl2, this.tb_adrIpSource.Text, this.tb_adrIpDest.Text, typeDePaquetIp2);
						this.okManuel = this.paquetRecuPropose.Idem(this.paquetRecuOk);
						return;
					}
					this.okManuel = true;
					return;
				}
				break;
			case 8:
				if (this.phasesAValider.Contains(8))
				{
					this.okManuel = true;
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0001A230 File Offset: 0x00019230
		public DemoPaquetIp(Form f) : base(f)
		{
			this.InitializeComponent();
			base.Owner = f;
			this.actions = new ArrayList();
			this.actions.Add("Examiner IP destination");
			this.actions.Add("Examiner réseaux IP");
			this.actions.Add("Examiner type paquet IP");
			this.actions.Add("Afficher message réussite");
			this.actions.Add("Examiner statut routage");
			this.actions.Add("Examiner statut routage");
			this.actions.Add("Abandonner le paquet");
			this.actions.Add("Examiner TTL du paquet");
			this.actions.Add("Créer paquet EchoResponse");
			this.actions.Add("Examiner table de routage");
			this.actions.Add("Examiner cache ARP");
			this.actions.Add("Envoyer paquet IP");
			this.actions.Add("Mettre en attente ce paquet");
			this.actions.Add("Envoyer Arp Request");
			this.actions.Add("Fin de la démonstration");
			base.initTables(null);
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0001A388 File Offset: 0x00019388
		private void cb_typePaquet_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cb_typePaquet.SelectedIndex < 2)
			{
				this.lbl_ttl.Visible = true;
				this.cb_ttl.Visible = true;
				return;
			}
			this.lbl_ttl.Visible = false;
			this.cb_ttl.Visible = false;
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0001A3D4 File Offset: 0x000193D4
		private void cb_typePaquetNouveau_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cb_typePaquetNouveau.SelectedIndex < 2)
			{
				this.lbl_ttlNouveau.Visible = true;
				this.cb_ttlNouveau.Visible = true;
				return;
			}
			this.lbl_ttlNouveau.Visible = false;
			this.cb_ttlNouveau.Visible = false;
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0001A420 File Offset: 0x00019420
		private void cb_viaArp_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cb_viaArp.Checked)
			{
				this.cb_bcast.Checked = false;
				this.cb_ppp.Checked = false;
				this.tb_adrMacDest.Text = "via arp";
				return;
			}
			this.tb_adrMacDest.Text = "Clic sur la carte";
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0001A474 File Offset: 0x00019474
		private void cb_bcast_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cb_bcast.Checked)
			{
				this.cb_viaArp.Checked = false;
				this.cb_ppp.Checked = false;
				this.tb_adrMacDest.Text = this.st.Reseau.Pref.AdrMacBroadcast;
				return;
			}
			this.tb_adrMacDest.Text = "Clic sur la carte";
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0001A4D8 File Offset: 0x000194D8
		private void cb_ppp_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cb_ppp.Checked)
			{
				this.cb_viaArp.Checked = false;
				this.cb_bcast.Checked = false;
				this.tb_adrMacDest.Text = "ppp";
				return;
			}
			this.tb_adrMacDest.Text = "Clic sur la carte";
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0001A52C File Offset: 0x0001952C
		private void cb_bcastNouveau_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cb_bcastNouveau.Checked)
			{
				this.cb_pppNouveau.Checked = false;
				this.tb_adrMacDestNouveau.Text = this.st.Reseau.Pref.AdrMacBroadcast;
				return;
			}
			this.tb_adrMacDestNouveau.Text = "Clic sur la carte";
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0001A584 File Offset: 0x00019584
		private void cb_pppNouveau_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cb_pppNouveau.Checked)
			{
				this.cb_bcastNouveau.Checked = false;
				this.tb_adrMacDestNouveau.Text = "ppp";
				return;
			}
			this.tb_adrMacDestNouveau.Text = "Clic sur la carte";
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0001A5CC File Offset: 0x000195CC
		private void tb_adrMacDest_Enter(object sender, EventArgs e)
		{
			if (this.cb_bcast.Checked)
			{
				this.cb_bcast.Checked = false;
			}
			if (this.cb_viaArp.Checked)
			{
				this.cb_viaArp.Checked = false;
			}
			if (this.cb_ppp.Checked)
			{
				this.cb_ppp.Checked = false;
			}
			this.MacAttenteOn(this.tb_adrMacDest);
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0001A630 File Offset: 0x00019630
		private void tb_adrMacDest_Leave(object sender, EventArgs e)
		{
			this.MacAttenteOff(this.tb_adrMacDest);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0001A64C File Offset: 0x0001964C
		private void tb_adrMacDestNouveau_Enter(object sender, EventArgs e)
		{
			if (this.cb_bcastNouveau.Checked)
			{
				this.cb_bcastNouveau.Checked = false;
			}
			if (this.cb_pppNouveau.Checked)
			{
				this.cb_pppNouveau.Checked = false;
			}
			this.MacAttenteOn(this.tb_adrMacDestNouveau);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0001A698 File Offset: 0x00019698
		private void tb_adrMacDestNouveau_Leave(object sender, EventArgs e)
		{
			this.MacAttenteOff(this.tb_adrMacDestNouveau);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0001A6B4 File Offset: 0x000196B4
		public void MacAttenteOn(Control tb)
		{
			if (tb.Focused)
			{
				this.st.Reseau.AdrMacAttente = tb;
			}
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0001A6DC File Offset: 0x000196DC
		public void MacAttenteOff(Control tb)
		{
			if (this.st.Reseau.AdrMacAttente == tb)
			{
				this.st.Reseau.AdrMacAttente = null;
			}
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0001A710 File Offset: 0x00019710
		protected override ArrayList getTables()
		{
			SortedList sortedList = new SortedList();
			sortedList["nbSauts"] = this.paquet.NbSauts;
			return new ArrayList
			{
				sortedList.Clone()
			};
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0001A754 File Offset: 0x00019754
		protected override void setTables(ArrayList p_tables)
		{
			SortedList sortedList = (SortedList)p_tables[0];
			this.paquet.NbSauts = int.Parse(sortedList["nbSauts"].ToString());
			this.st.Reseau.FixerTtlPaquetIp(this.paquet.NbSauts);
		}

		// Token: 0x040001B6 RID: 438
		private bool routageActif;

		// Token: 0x040001B7 RID: 439
		private bool destLocale;

		// Token: 0x040001B8 RID: 440
		private bool carteLocaleActive;

		// Token: 0x040001B9 RID: 441
		private bool memeReseauDestLocale;

		// Token: 0x040001BA RID: 442
		private CarteReseau carteLocaleDestFinale;

		// Token: 0x040001BB RID: 443
		private int itemMacDest;

		// Token: 0x040001BC RID: 444
		private string adrMacDest;

		// Token: 0x040001BD RID: 445
		private int itemRoute;

		// Token: 0x040001BE RID: 446
		private string ipAJoindre;

		// Token: 0x040001BF RID: 447
		private CarteReseau maCarte = null;

		// Token: 0x040001C0 RID: 448
		private string passerelle = null;

		// Token: 0x040001C1 RID: 449
		private bool ppp = false;

		// Token: 0x040001C2 RID: 450
		private Ip_PaquetIpDemoManuel paquetRecuOk;

		// Token: 0x040001C3 RID: 451
		private Ip_PaquetIpDemoManuel paquetRecuPropose;

		// Token: 0x040001C4 RID: 452
		private Ip_PaquetIpDemoManuel paquetNouveauOk;

		// Token: 0x040001C5 RID: 453
		private Ip_PaquetIpDemoManuel paquetNouveauPropose;

		// Token: 0x040001C6 RID: 454
		private bool paquetRecuModifie = false;
	}
}
