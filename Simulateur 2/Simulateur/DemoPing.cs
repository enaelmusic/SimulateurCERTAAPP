using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000027 RID: 39
	public partial class DemoPing : DemoDialogue
	{
		// Token: 0x06000274 RID: 628 RVA: 0x0001A7AC File Offset: 0x000197AC
		public DemoPing()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000277 RID: 631 RVA: 0x0001C080 File Offset: 0x0001B080
		private Station st
		{
			get
			{
				return (Station)this.elt;
			}
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0001C098 File Offset: 0x0001B098
		protected override void init()
		{
			this.cacheArpEdit1.init(this.st.Ip, true);
			this.fichierHostsEdit1.init(this.st.Ip, true);
			this.routeEdit1.init(this.st.Ip, true);
			this.tb_resultat.Text = "";
			this.tb_destination.Text = this.adrIpToPing;
			this.ipAJoindre = this.adrIpToPing;
			this.chercherHoteEtMacEtRoute();
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0001C120 File Offset: 0x0001B120
		private void chercherHoteEtMacEtRoute()
		{
			if (!Ip_adresse.Ok(this.adrIpToPing) || Ip_quartet.Isnul(this.adrIpToPing))
			{
				this.itemDestHosts = this.fichierHostsEdit1.IndexOf(this.adrIpToPing);
				if (this.itemDestHosts != -1)
				{
					this.adrDestHosts = FichierHostsEdit.GetAdrIp(this.fichierHostsEdit1.GetTable(), this.adrIpToPing);
					this.ipAJoindre = this.adrDestHosts;
					this.adrIpToPingPrepare = this.adrDestHosts;
				}
			}
			else
			{
				this.itemDestHosts = -1;
				this.adrIpToPingPrepare = this.adrIpToPing;
			}
			if (Ip_adresse.Ok(this.ipAJoindre) && !Ip_quartet.Isnul(this.ipAJoindre))
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
				}
			}
			else
			{
				this.itemRoute = -1;
			}
			if (Ip_adresse.Ok(this.ipAJoindre) && !Ip_quartet.Isnul(this.ipAJoindre))
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

		// Token: 0x0600027A RID: 634 RVA: 0x0001C308 File Offset: 0x0001B308
		private void MontrerTable(Control c, bool modifiable)
		{
			if (c.GetType() == typeof(TextBox))
			{
				base.Size = new Size(228, 112);
			}
			else if (c.GetType() == typeof(FichierHostsEdit))
			{
				base.Size = new Size(308, 192);
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
				base.Size = new Size(476, 192);
			}
			else if (c.GetType() == typeof(GroupBox))
			{
				base.Size = new Size(228, 188);
			}
			this.fichierHostsEdit1.Visible = false;
			this.cacheArpEdit1.Visible = false;
			this.routeEdit1.Visible = false;
			this.pn_configIp.Visible = false;
			this.gb_messageUtilisateur.Visible = false;
			this.pn_paquetIp.Visible = false;
			this.pn_paquetArp.Visible = false;
			c.Visible = true;
			base.InScreen();
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0001C470 File Offset: 0x0001B470
		private void cacherTable()
		{
			base.Size = new Size(228, 112);
			this.fichierHostsEdit1.Visible = false;
			this.cacheArpEdit1.Visible = false;
			this.routeEdit1.Visible = false;
			this.pn_configIp.Visible = false;
			this.gb_messageUtilisateur.Visible = false;
			this.pn_paquetIp.Visible = false;
			this.pn_paquetArp.Visible = false;
			base.InScreen();
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0001C4EC File Offset: 0x0001B4EC
		private string getLibellePhase(int numPhase)
		{
			string result = "";
			switch (numPhase)
			{
			case 0:
				result = "Recherche du destinataire";
				break;
			case 1:
				result = "Recherche de la route";
				break;
			case 2:
				result = "Recherche de l'adresse MAC";
				break;
			case 3:
				result = "Envoi du ping";
				break;
			case 4:
				result = "Affichage du résultat";
				break;
			case 5:
				result = "Recherche du destinataire";
				break;
			case 6:
				result = "Recherche du destinataire";
				break;
			case 7:
				result = "Affichage du résultat";
				break;
			case 8:
				result = "Affichage du résultat";
				break;
			case 9:
				result = "Préparation du paquet IP";
				break;
			case 10:
				result = "Envoi de la requête ARP";
				break;
			case 11:
				result = "";
				break;
			}
			return result;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0001C598 File Offset: 0x0001B598
		protected override void executerPhase()
		{
			this.cacherTable();
			base.LibellePhase = this.getLibellePhase(this.numPhaseSuivante);
			switch (this.numPhaseSuivante)
			{
			case 0:
			{
				this.tb_destination.Text = this.adrIpToPing;
				if (!Ip_adresse.Ok(this.adrIpToPing) || Ip_quartet.Isnul(this.adrIpToPing))
				{
					this.tb_resultat.Text = "Adr. IP incorrecte ou  nom d'hôte";
					this.numPhaseSuivante = 5;
					return;
				}
				if (this.adrIpToPing == "127.0.0.1")
				{
					this.tb_resultat.Text = "Adresse IP locale (loopback)";
					this.numPhaseSuivante = 4;
					return;
				}
				CarteReseau carteReseau = this.st.Ip.TrouverCarteIp(this.adrIpToPing);
				if (carteReseau == null)
				{
					this.tb_resultat.Text = "Adresse IP non locale";
					this.numPhaseSuivante = 1;
					return;
				}
				if (carteReseau.EtatConnexion == PointConnexion.EtatsConnexion.actif)
				{
					this.tb_resultat.Text = "Adresse IP locale";
					this.numPhaseSuivante = 4;
					return;
				}
				this.tb_resultat.Text = "Adresse IP locale, carte HS";
				this.numPhaseSuivante = 8;
				return;
			}
			case 1:
				this.MontrerTable(this.routeEdit1, false);
				if (this.itemRoute == -1)
				{
					this.tb_resultat.Text = "Aucune route trouvée";
					this.numPhaseSuivante = 8;
					return;
				}
				this.routeEdit1.selectIndex(this.itemRoute);
				if (this.adresseReseau)
				{
					this.tb_resultat.Text = "Adresse réseau";
					this.numPhaseSuivante = 7;
					return;
				}
				if (!this.ppp)
				{
					this.tb_resultat.Text = "IP à joindre : " + this.ipAJoindre;
					this.numPhaseSuivante = 2;
					return;
				}
				this.tb_resultat.Text = "IP à joindre : " + this.ipAJoindre + " (PPP)";
				this.numPhaseSuivante = 3;
				return;
			case 2:
				this.MontrerTable(this.cacheArpEdit1, false);
				if (this.itemMacDest == -1)
				{
					this.tb_resultat.Text = "Aucune correspondance trouvée";
					this.numPhaseSuivante = 9;
					return;
				}
				this.cacheArpEdit1.selectIndex(this.itemMacDest);
				this.tb_resultat.Text = "Adr MAC : " + this.adrMacDest;
				this.numPhaseSuivante = 3;
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
				this.numPhaseSuivante = 11;
				return;
			case 4:
				this.tb_resultat.Text = "Afficher 'l'hôte a bien répondu'";
				this.numPhaseSuivante = 11;
				return;
			case 5:
				this.MontrerTable(this.fichierHostsEdit1, false);
				if (this.itemDestHosts == -1)
				{
					this.tb_resultat.Text = "Hôte inconnu";
					this.numPhaseSuivante = 7;
					return;
				}
				this.fichierHostsEdit1.selectIndex(this.itemDestHosts);
				this.tb_resultat.Text = "Adr hôte : " + this.adrDestHosts;
				this.numPhaseSuivante = 6;
				return;
			case 6:
			{
				base.TablesModifiees = true;
				this.tb_destination.Text = this.adrDestHosts;
				if (!Ip_adresse.Ok(this.adrDestHosts) || Ip_quartet.Isnul(this.adrDestHosts))
				{
					this.tb_resultat.Text = "Adresse IP incorrecte";
					this.numPhaseSuivante = 7;
					return;
				}
				if (this.adrDestHosts == "127.0.0.1")
				{
					this.tb_resultat.Text = "Adresse IP locale";
					this.numPhaseSuivante = 4;
					return;
				}
				CarteReseau carteReseau2 = this.st.Ip.TrouverCarteIp(this.adrDestHosts);
				if (carteReseau2 == null)
				{
					this.chercherHoteEtMacEtRoute();
					this.tb_resultat.Text = "Adresse IP non locale";
					this.numPhaseSuivante = 1;
					return;
				}
				if (carteReseau2.EtatConnexion == PointConnexion.EtatsConnexion.actif)
				{
					this.tb_resultat.Text = "Adresse IP locale";
					this.numPhaseSuivante = 4;
					return;
				}
				this.tb_resultat.Text = "Adresse IP locale, carte HS";
				this.numPhaseSuivante = 8;
				return;
			}
			case 7:
				this.tb_resultat.Text = "Adresse IP incorrecte !";
				this.numPhaseSuivante = 11;
				return;
			case 8:
				this.tb_resultat.Text = "Hôte non joignable !";
				this.numPhaseSuivante = 11;
				return;
			case 9:
				this.tb_resultat.Text = TypeDePaquetIp.IcmpEchoRequest.ToString() + " " + this.adrIpToPingPrepare;
				this.numPhaseSuivante = 10;
				return;
			case 10:
				this.tb_resultat.Text = "De " + this.maCarte.AdresseMac + " vers " + this.st.Reseau.Pref.AdrMacBroadcast;
				this.numPhaseSuivante = 11;
				return;
			case 11:
				this.numPhaseSuivante = 12;
				return;
			default:
				return;
			}
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0001CA64 File Offset: 0x0001BA64
		private void calculerPaquetOk(ref Ip_PaquetIpDemoManuel paq, TypeDePaquetIp p_type, string p_adrDest, bool macDestConnue)
		{
			if (p_type == TypeDePaquetIp.ArpRequest)
			{
				paq = new Ip_PaquetIpDemoManuel(this.st.Reseau.Pref.AdrMacBroadcast, this.maCarte.AdresseMac, -1, this.maCarte.Ip.Adresse.ToString(), p_adrDest, p_type);
				return;
			}
			if (macDestConnue)
			{
				paq = new Ip_PaquetIpDemoManuel(this.adrMacDest, this.maCarte.AdresseMac, this.st.Reseau.Pref.NbSautsMax, this.maCarte.Ip.Adresse.ToString(), p_adrDest, p_type);
				return;
			}
			if (this.ppp)
			{
				paq = new Ip_PaquetIpDemoManuel("ppp", this.maCarte.AdresseMac, this.st.Reseau.Pref.NbSautsMax, this.maCarte.Ip.Adresse.ToString(), p_adrDest, p_type);
				return;
			}
			paq = new Ip_PaquetIpDemoManuel("via arp", this.maCarte.AdresseMac, this.st.Reseau.Pref.NbSautsMax, this.maCarte.Ip.Adresse.ToString(), p_adrDest, p_type);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0001CB90 File Offset: 0x0001BB90
		private void calculerResultatManuel()
		{
			if (Ip_adresse.Ok(this.adrIpToPing) && !this.adresseReseau && !Ip_quartet.Isnul(this.adrIpToPing))
			{
				if (this.adrIpToPing == "127.0.0.1")
				{
					this.phasesAValider.Add(7);
					this.numeroMessageOk = 0;
					return;
				}
				CarteReseau carteReseau = this.st.Ip.TrouverCarteIp(this.adrIpToPing);
				if (carteReseau != null)
				{
					if (carteReseau.EtatConnexion == PointConnexion.EtatsConnexion.actif)
					{
						this.phasesAValider.Add(7);
						this.numeroMessageOk = 0;
						return;
					}
					this.phasesAValider.Add(7);
					this.numeroMessageOk = 1;
					return;
				}
				else
				{
					if (this.itemRoute == -1)
					{
						this.phasesAValider.Add(7);
						this.numeroMessageOk = 1;
						return;
					}
					if (this.ppp)
					{
						this.phasesAValider.Add(8);
						this.calculerPaquetOk(ref this.paquetIpOk, TypeDePaquetIp.IcmpEchoRequest, this.adrIpToPing, false);
						return;
					}
					if (this.itemMacDest == -1)
					{
						this.phasesAValider.Add(9);
						this.calculerPaquetOk(ref this.paquetArpOk, TypeDePaquetIp.ArpRequest, this.ipAJoindre, true);
						this.calculerPaquetOk(ref this.paquetIpOk, TypeDePaquetIp.IcmpEchoRequest, this.adrIpToPing, false);
						return;
					}
					this.phasesAValider.Add(8);
					this.calculerPaquetOk(ref this.paquetIpOk, TypeDePaquetIp.IcmpEchoRequest, this.adrIpToPing, true);
					return;
				}
			}
			else
			{
				if (this.itemDestHosts == -1 || this.adresseReseau)
				{
					this.phasesAValider.Add(7);
					this.numeroMessageOk = 2;
					return;
				}
				if (!Ip_adresse.Ok(this.adrDestHosts) || Ip_quartet.Isnul(this.adrDestHosts))
				{
					this.phasesAValider.Add(7);
					this.numeroMessageOk = 2;
					return;
				}
				if (this.adrDestHosts == "127.0.0.1")
				{
					this.phasesAValider.Add(7);
					this.numeroMessageOk = 0;
					return;
				}
				CarteReseau carteReseau2 = this.st.Ip.TrouverCarteIp(this.adrDestHosts);
				if (carteReseau2 != null)
				{
					if (carteReseau2.EtatConnexion == PointConnexion.EtatsConnexion.actif)
					{
						this.phasesAValider.Add(7);
						this.numeroMessageOk = 0;
						return;
					}
					this.phasesAValider.Add(7);
					this.numeroMessageOk = 1;
					return;
				}
				else
				{
					if (this.itemRoute == -1)
					{
						this.phasesAValider.Add(7);
						this.numeroMessageOk = 1;
						return;
					}
					if (this.ppp)
					{
						this.calculerPaquetOk(ref this.paquetIpOk, TypeDePaquetIp.IcmpEchoRequest, this.adrDestHosts, false);
						this.phasesAValider.Add(8);
						return;
					}
					if (this.itemMacDest == -1)
					{
						this.calculerPaquetOk(ref this.paquetArpOk, TypeDePaquetIp.ArpRequest, this.ipAJoindre, true);
						this.calculerPaquetOk(ref this.paquetIpOk, TypeDePaquetIp.IcmpEchoRequest, this.adrDestHosts, false);
						this.phasesAValider.Add(9);
						return;
					}
					this.calculerPaquetOk(ref this.paquetIpOk, TypeDePaquetIp.IcmpEchoRequest, this.adrDestHosts, true);
					this.phasesAValider.Add(8);
					return;
				}
			}
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0001CEB0 File Offset: 0x0001BEB0
		protected override void initManuel()
		{
			this.init();
			this.Text = "Station : " + ((Station)this.elt).NomNoeud;
			this.nbPhasesManuelles = 10;
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
			this.cb_action.Items.Add("Consulter fichier hosts...");
			this.cb_action.Items.Add("Consulter cache ARP...");
			this.cb_action.Items.Add("Préparer message utilisateur...");
			this.cb_action.Items.Add("Préparer nouveau paquet IP...");
			this.cb_action.Items.Add("Préparer nouveau paquet ARP...");
			this.cb_action.Items.Add("Afficher le message préparé -->");
			this.cb_action.Items.Add("Envoyer le paquet IP préparé -->");
			this.cb_action.Items.Add("Envoyer le paquet ARP préparé -->");
			this.calculerResultatManuel();
			this.cb_ttlIp.Items.Clear();
			for (int i = 0; i <= this.st.Reseau.Pref.NbSautsMax; i++)
			{
				this.cb_ttlIp.Items.Add(i);
			}
			this.cb_adrMacSourceArp.Items.Clear();
			this.cb_adrMacSourceIp.Items.Clear();
			foreach (object obj2 in this.st.Controls)
			{
				CarteReseau carteReseau2 = (CarteReseau)obj2;
				this.cb_adrMacSourceArp.Items.Add(carteReseau2.AdresseMac);
				this.cb_adrMacSourceIp.Items.Add(carteReseau2.AdresseMac);
			}
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0001D234 File Offset: 0x0001C234
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
				this.MontrerTable(this.fichierHostsEdit1, false);
				this.messageManuelOk = "Fichier hosts";
				this.okManuel = true;
				return;
			case 3:
				this.MontrerTable(this.cacheArpEdit1, false);
				this.messageManuelOk = "Cache ARP";
				this.okManuel = true;
				return;
			case 4:
				this.MontrerTable(this.gb_messageUtilisateur, false);
				this.messageManuelOk = "Choisissez le message...";
				this.okManuel = true;
				return;
			case 5:
				this.paquetIpPrepare = true;
				this.MontrerTable(this.pn_paquetIp, false);
				this.messageManuelOk = "Paramétrez le paquet IP...";
				this.okManuel = true;
				return;
			case 6:
				this.MontrerTable(this.pn_paquetArp, false);
				this.messageManuelOk = "Paramétrez le paquet ARP...";
				this.okManuel = true;
				return;
			case 7:
				if (this.phasesAValider.Contains(7))
				{
					this.messageManuelErreur = "Message utilisateur incorrect !";
					switch (this.numeroMessageOk)
					{
					case 0:
						this.okManuel = this.rb_ok.Checked;
						return;
					case 1:
						this.okManuel = this.rb_nonJoignable.Checked;
						return;
					case 2:
						this.okManuel = this.rb_adrIpIncorrecte.Checked;
						return;
					default:
						return;
					}
				}
				break;
			case 8:
				if (this.phasesAValider.Contains(8))
				{
					this.messageManuelErreur = "Paquet IP incorrect !";
					TypeDePaquetIp typeDePaquetIp;
					if (this.cb_typePaquetIp.SelectedIndex == -1)
					{
						typeDePaquetIp = TypeDePaquetIp.Aucun;
					}
					else
					{
						typeDePaquetIp = (TypeDePaquetIp)Enum.Parse(typeof(TypeDePaquetIp), this.cb_typePaquetIp.Items[this.cb_typePaquetIp.SelectedIndex].ToString());
					}
					int p_ttl;
					if (typeDePaquetIp != TypeDePaquetIp.IcmpEchoRequest && typeDePaquetIp != TypeDePaquetIp.IcmpEchoResponse)
					{
						p_ttl = -1;
					}
					else if (this.cb_ttlIp.SelectedIndex == -1)
					{
						p_ttl = -1;
					}
					else
					{
						p_ttl = (int)this.cb_ttlIp.Items[this.cb_ttlIp.SelectedIndex];
					}
					string p_macSource;
					if (this.cb_adrMacSourceIp.SelectedIndex == -1)
					{
						p_macSource = "";
					}
					else
					{
						p_macSource = this.cb_adrMacSourceIp.Items[this.cb_adrMacSourceIp.SelectedIndex].ToString();
					}
					this.paquetIpPropose = new Ip_PaquetIpDemoManuel(this.tb_adrMacDestIp.Text, p_macSource, p_ttl, this.tb_adrIpSourceIp.Text, this.tb_adrIpDestIp.Text, typeDePaquetIp);
					this.okManuel = this.paquetIpPropose.Idem(this.paquetIpOk);
					return;
				}
				break;
			case 9:
				if (this.phasesAValider.Contains(9))
				{
					if (this.paquetIpPrepare)
					{
						TypeDePaquetIp typeDePaquetIp2;
						if (this.cb_typePaquetArp.SelectedIndex == -1)
						{
							typeDePaquetIp2 = TypeDePaquetIp.Aucun;
						}
						else
						{
							typeDePaquetIp2 = (TypeDePaquetIp)Enum.Parse(typeof(TypeDePaquetIp), this.cb_typePaquetArp.Items[this.cb_typePaquetArp.SelectedIndex].ToString());
						}
						int p_ttl2 = -1;
						string p_macSource2;
						if (this.cb_adrMacSourceArp.SelectedIndex == -1)
						{
							p_macSource2 = "";
						}
						else
						{
							p_macSource2 = this.cb_adrMacSourceArp.Items[this.cb_adrMacSourceArp.SelectedIndex].ToString();
						}
						this.paquetArpPropose = new Ip_PaquetIpDemoManuel(this.tb_adrMacDestArp.Text, p_macSource2, p_ttl2, this.tb_adrIpSourceArp.Text, this.tb_adrIpDestArp.Text, typeDePaquetIp2);
						if (this.paquetArpPropose.Idem(this.paquetArpOk))
						{
							this.messageManuelErreur = "Paquet IP incorrect !";
							if (this.cb_typePaquetIp.SelectedIndex == -1)
							{
								typeDePaquetIp2 = TypeDePaquetIp.Aucun;
							}
							else
							{
								typeDePaquetIp2 = (TypeDePaquetIp)Enum.Parse(typeof(TypeDePaquetIp), this.cb_typePaquetIp.Items[this.cb_typePaquetIp.SelectedIndex].ToString());
							}
							if (typeDePaquetIp2 != TypeDePaquetIp.IcmpEchoRequest && typeDePaquetIp2 != TypeDePaquetIp.IcmpEchoResponse)
							{
								p_ttl2 = -1;
							}
							else if (this.cb_ttlIp.SelectedIndex == -1)
							{
								p_ttl2 = -1;
							}
							else
							{
								p_ttl2 = (int)this.cb_ttlIp.Items[this.cb_ttlIp.SelectedIndex];
							}
							if (this.cb_adrMacSourceIp.SelectedIndex == -1)
							{
								p_macSource2 = "";
							}
							else
							{
								p_macSource2 = this.cb_adrMacSourceIp.Items[this.cb_adrMacSourceIp.SelectedIndex].ToString();
							}
							this.paquetIpPropose = new Ip_PaquetIpDemoManuel(this.tb_adrMacDestIp.Text, p_macSource2, p_ttl2, this.tb_adrIpSourceIp.Text, this.tb_adrIpDestIp.Text, typeDePaquetIp2);
							this.okManuel = this.paquetIpPropose.Idem(this.paquetIpOk);
							return;
						}
						this.messageManuelErreur = "Paquet ARP incorrect !";
						return;
					}
					else
					{
						this.messageManuelErreur = "Paquet IP non préparé !";
					}
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0001D718 File Offset: 0x0001C718
		public DemoPing(Form f) : base(f)
		{
			this.InitializeComponent();
			base.Owner = f;
			this.actions = new ArrayList();
			this.actions.Add("Contrôler l'adresse IP");
			this.actions.Add("Examiner table de routage");
			this.actions.Add("Examiner cache ARP");
			this.actions.Add("Envoyer Echo Request");
			this.actions.Add("Afficher message réussite");
			this.actions.Add("Examiner fichier hosts");
			this.actions.Add("Contrôler l'adresse IP");
			this.actions.Add("Afficher message échec");
			this.actions.Add("Afficher message échec");
			this.actions.Add("Mettre en attente ce paquet");
			this.actions.Add("Envoyer Arp Request");
			this.actions.Add("Fin de la démonstration");
			base.initTables(null);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0001D844 File Offset: 0x0001C844
		protected override ArrayList getTables()
		{
			SortedList sortedList = new SortedList();
			sortedList["itemDestHosts"] = this.itemDestHosts;
			sortedList["itemMacDest"] = this.itemMacDest;
			sortedList["itemRoute"] = this.itemRoute;
			sortedList["adrIpToPing"] = this.adrIpToPing;
			return new ArrayList
			{
				sortedList.Clone()
			};
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0001D8C0 File Offset: 0x0001C8C0
		protected override void setTables(ArrayList p_tables)
		{
			SortedList sortedList = (SortedList)p_tables[0];
			this.itemDestHosts = int.Parse(sortedList["itemDestHosts"].ToString());
			this.itemMacDest = int.Parse(sortedList["itemMacDest"].ToString());
			this.itemRoute = int.Parse(sortedList["itemRoute"].ToString());
			this.adrIpToPing = sortedList["adrIpToPing"].ToString();
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0001D944 File Offset: 0x0001C944
		private void cb_viaArpIp_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cb_viaArpIp.Checked)
			{
				this.cb_bcastIp.Checked = false;
				this.cb_pppIp.Checked = false;
				this.tb_adrMacDestIp.Text = "via arp";
				return;
			}
			this.tb_adrMacDestIp.Text = "Clic sur la carte";
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0001D998 File Offset: 0x0001C998
		private void cb_bcastIp_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cb_bcastIp.Checked)
			{
				this.cb_viaArpIp.Checked = false;
				this.cb_pppIp.Checked = false;
				this.tb_adrMacDestIp.Text = this.st.Reseau.Pref.AdrMacBroadcast;
				return;
			}
			this.tb_adrMacDestIp.Text = "Clic sur la carte";
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0001D9FC File Offset: 0x0001C9FC
		private void cb_pppIp_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cb_pppIp.Checked)
			{
				this.cb_bcastIp.Checked = false;
				this.cb_viaArpIp.Checked = false;
				this.tb_adrMacDestIp.Text = "ppp";
				return;
			}
			this.tb_adrMacDestIp.Text = "Clic sur la carte";
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0001DA50 File Offset: 0x0001CA50
		private void tb_adrMacDestIp_Enter(object sender, EventArgs e)
		{
			if (this.cb_bcastIp.Checked)
			{
				this.cb_bcastIp.Checked = false;
			}
			if (this.cb_viaArpIp.Checked)
			{
				this.cb_viaArpIp.Checked = false;
			}
			if (this.cb_pppIp.Checked)
			{
				this.cb_pppIp.Checked = false;
			}
			this.MacAttenteOn(this.tb_adrMacDestIp);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0001DAB4 File Offset: 0x0001CAB4
		private void tb_adrMacDestIp_Leave(object sender, EventArgs e)
		{
			this.MacAttenteOff(this.tb_adrMacDestIp);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0001DAD0 File Offset: 0x0001CAD0
		private void cb_bcastArp_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cb_bcastArp.Checked)
			{
				this.tb_adrMacDestArp.Text = this.st.Reseau.Pref.AdrMacBroadcast;
				return;
			}
			this.tb_adrMacDestArp.Text = "Clic sur la carte";
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0001DB1C File Offset: 0x0001CB1C
		private void tb_adrMacDestArp_Enter(object sender, EventArgs e)
		{
			if (this.cb_bcastArp.Checked)
			{
				this.cb_bcastArp.Checked = false;
			}
			this.MacAttenteOn(this.tb_adrMacDestArp);
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0001DB50 File Offset: 0x0001CB50
		private void tb_adrMacDestArp_Leave(object sender, EventArgs e)
		{
			this.MacAttenteOff(this.tb_adrMacDestArp);
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0001DB6C File Offset: 0x0001CB6C
		public void MacAttenteOn(TextBox tb)
		{
			if (tb.Focused)
			{
				this.st.Reseau.AdrMacAttente = tb;
			}
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0001DB94 File Offset: 0x0001CB94
		public void MacAttenteOff(TextBox tb)
		{
			if (this.st.Reseau.AdrMacAttente == tb)
			{
				this.st.Reseau.AdrMacAttente = null;
			}
		}

		// Token: 0x040001F5 RID: 501
		private int itemDestHosts;

		// Token: 0x040001F6 RID: 502
		private string adrDestHosts;

		// Token: 0x040001F7 RID: 503
		private int itemMacDest;

		// Token: 0x040001F8 RID: 504
		private string adrMacDest;

		// Token: 0x040001F9 RID: 505
		private int itemRoute;

		// Token: 0x040001FA RID: 506
		private string ipAJoindre;

		// Token: 0x040001FB RID: 507
		private CarteReseau maCarte = null;

		// Token: 0x040001FC RID: 508
		private string passerelle = null;

		// Token: 0x040001FD RID: 509
		private bool adresseReseau = false;

		// Token: 0x040001FE RID: 510
		private bool ppp = false;

		// Token: 0x040001FF RID: 511
		private int numeroMessageOk;

		// Token: 0x04000200 RID: 512
		private Ip_PaquetIpDemoManuel paquetIpOk;

		// Token: 0x04000201 RID: 513
		private Ip_PaquetIpDemoManuel paquetIpPropose;

		// Token: 0x04000202 RID: 514
		private Ip_PaquetIpDemoManuel paquetArpOk;

		// Token: 0x04000203 RID: 515
		private Ip_PaquetIpDemoManuel paquetArpPropose;

		// Token: 0x04000204 RID: 516
		private string adrIpToPingPrepare;

		// Token: 0x04000205 RID: 517
		private bool paquetIpPrepare = false;
	}
}
