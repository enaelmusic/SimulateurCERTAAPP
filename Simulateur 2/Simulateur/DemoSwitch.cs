using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000029 RID: 41
	public partial class DemoSwitch : DemoDialogue
	{
		// Token: 0x060002A0 RID: 672 RVA: 0x00021E24 File Offset: 0x00020E24
		public DemoSwitch()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x000226B8 File Offset: 0x000216B8
		private void chercherEmetteurDestinataire()
		{
			this.itemDestinataire = this.macPortEdit1.IndexOf(this.trame.MacDestinataire);
			this.itemEmetteur = this.macPortEdit1.IndexOf(this.trame.MacEmetteur);
			this.itemEmetteurMacVlan = this.macVlanEdit1.IndexOf(this.trame.MacEmetteur);
			this.itemDestinataireMacVlan = this.macVlanEdit1.IndexOf(this.trame.MacDestinataire);
			this.itemPortEmetteur = this.portVlanEdit1.IndexOf(PortVlanEdit.numPortFormat(((PortSwitch)this.sender).NumeroOrdre));
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0002275C File Offset: 0x0002175C
		protected override void init()
		{
			this.initLibPhases();
			this.tb_portReception.Text = ((PointConnexion)this.sender).NumeroOrdre.ToString();
			this.tb_emetteur.Text = this.trame.MacEmetteur;
			this.tb_destinataire.Text = this.trame.MacDestinataire;
			this.macPortEdit1.init((Switch)this.elt, true);
			this.portVlanEdit1.init((Switch)this.elt, true);
			this.macVlanEdit1.init((Switch)this.elt, true);
			this.chercherEmetteurDestinataire();
			if (this.itemDestinataire != -1)
			{
				this.portDestinataire = this.macPortEdit1.htLigne(this.itemDestinataire)[1].ToString();
				this.etatPortDestinataire = ((PortSwitch)this.macPortEdit1.htLigne(this.itemDestinataire)[1]).EtatConnexion;
				this.itemPortDestinataire = this.portVlanEdit1.IndexOf(PortVlanEdit.numPortFormat(int.Parse(this.portDestinataire)));
				if (this.itemPortDestinataire == -1)
				{
					this.vlanPortDestinataire = -1;
				}
				else
				{
					this.vlanPortDestinataire = int.Parse(this.portVlanEdit1.htLigne(this.itemPortDestinataire)[1].ToString());
				}
			}
			if (this.itemEmetteur != -1)
			{
				this.portEmetteur = this.macPortEdit1.htLigne(this.itemEmetteur)[1].ToString();
			}
			if (this.itemEmetteurMacVlan != -1)
			{
				this.vlanEmetteur = this.macVlanEdit1.htLigne(this.itemEmetteurMacVlan)[1].ToString();
			}
			if (this.itemDestinataireMacVlan != -1)
			{
				this.vlanDestinataire = this.macVlanEdit1.htLigne(this.itemDestinataireMacVlan)[1].ToString();
			}
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0002293C File Offset: 0x0002193C
		private void ajouterEmetteur()
		{
			this.macPortEdit1.AjouterLigne(this.trame.MacEmetteur, (PortSwitch)this.sender);
			this.macPortEdit1.Maj();
			this.chercherEmetteurDestinataire();
			this.macPortEdit1.selectIndex(this.itemEmetteur);
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0002298C File Offset: 0x0002198C
		private void ajouterPortReception()
		{
			this.portVlanEdit1.AjouterLigne(((PortSwitch)this.sender).NumeroOrdre, this.numeroVlan);
			this.portVlanEdit1.Maj();
			this.chercherEmetteurDestinataire();
			this.portVlanEdit1.selectIndex(this.itemPortEmetteur);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x000229DC File Offset: 0x000219DC
		private void aiguillageSelonVlan(int numPhaseVlan0, int numPhaseVlan1, int numPhaseVlan2)
		{
			switch (this.niveauVlan)
			{
			case 0:
				this.numPhaseSuivante = numPhaseVlan0;
				return;
			case 1:
				this.numPhaseSuivante = numPhaseVlan1;
				return;
			case 2:
				this.numPhaseSuivante = numPhaseVlan2;
				return;
			default:
				return;
			}
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00022A1C File Offset: 0x00021A1C
		private string getLibellePhase(int numPhase)
		{
			return this.libPhases[numPhase];
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00022A34 File Offset: 0x00021A34
		private void initLibPhases()
		{
			for (int i = 0; i < 6; i++)
			{
				this.libPhases[i] = "Maj table mac/port";
			}
			this.libPhases[6] = "Sélection ports de réémission";
			this.libPhases[7] = "Réémission de la trame";
			this.libPhases[8] = "Réémission de la trame";
			this.libPhases[9] = "Réémission de la trame";
			this.libPhases[10] = (base.LibellePhase = "");
			for (int i = 11; i < 15; i++)
			{
				this.libPhases[i] = "Recherche du vlan de la trame";
			}
			this.libPhases[15] = "Réémettre la trame";
			this.libPhases[16] = "Réémission de la trame";
			this.libPhases[17] = "Réémission de la trame";
			this.libPhases[18] = "Recherche du vlan de la trame";
			this.libPhases[19] = "Maj table port/vlan";
			this.libPhases[20] = "Maj table port/vlan";
			this.libPhases[21] = "Vérification vlan destinataire";
			this.libPhases[22] = "Réémission de la trame";
			this.libPhases[23] = "Réémission de la trame";
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00022B40 File Offset: 0x00021B40
		protected override void executerPhase()
		{
			this.tb_resultat.Text = "";
			this.cacherTable();
			base.LibellePhase = this.getLibellePhase(this.numPhaseSuivante);
			switch (this.numPhaseSuivante)
			{
			case 0:
				this.niveauVlan = ((Switch)this.elt).NiveauVlan;
				this.tb_resultat.Text = "Mac émetteur:" + this.tb_emetteur.Text;
				this.numPhaseSuivante = 1;
				return;
			case 1:
				this.tb_resultat.Text = "Port d'origine:" + this.tb_portReception.Text;
				this.numPhaseSuivante = 2;
				return;
			case 2:
				this.MontrerTable(this.macPortEdit1, false);
				if (this.itemEmetteur == -1)
				{
					this.tb_resultat.Text = "Port de l'émetteur inconnu";
					this.numPhaseSuivante = 3;
					return;
				}
				this.macPortEdit1.selectIndex(this.itemEmetteur);
				if (this.portEmetteur != this.tb_portReception.Text)
				{
					this.tb_resultat.Text = "Port de l'émetteur erroné";
					this.numPhaseSuivante = 4;
					return;
				}
				this.tb_resultat.Text = "Port de l'émetteur connu et correct";
				this.numPhaseSuivante = 5;
				return;
			case 3:
				base.TablesModifiees = true;
				this.ajouterEmetteur();
				this.MontrerTable(this.macPortEdit1, false);
				this.tb_resultat.Text = "Port émetteur ajouté";
				this.aiguillageSelonVlan(6, 11, 11);
				return;
			case 4:
				base.TablesModifiees = true;
				this.ajouterEmetteur();
				this.MontrerTable(this.macPortEdit1, false);
				this.tb_resultat.Text = "Port émetteur modifié";
				this.aiguillageSelonVlan(6, 11, 11);
				return;
			case 5:
				this.ajouterEmetteur();
				this.MontrerTable(this.macPortEdit1, false);
				this.tb_resultat.Text = "TTL réinitialisé";
				this.aiguillageSelonVlan(6, 11, 11);
				return;
			case 6:
			{
				if (this.trame.MacDestinataire == this.elt.Reseau.Pref.AdrMacBroadcast)
				{
					this.macPortEdit1.selectIndex(-1);
					this.tb_resultat.Text = "Adresse de broadcast";
					this.aiguillageSelonVlan(9, 17, 17);
					return;
				}
				this.MontrerTable(this.macPortEdit1, false);
				this.macPortEdit1.selectIndex(this.itemDestinataire);
				if (this.itemDestinataire == -1)
				{
					this.tb_resultat.Text = "Destinataire inconnu";
					this.aiguillageSelonVlan(9, 17, 21);
					return;
				}
				if (((PortSwitch)this.elt.Controls[int.Parse(this.portDestinataire) - 1]).GetType() == typeof(Port8021qSwitch))
				{
					this.tb_resultat.Text = "Destinataire port " + this.portDestinataire + " (802.1q)";
				}
				else
				{
					this.tb_resultat.Text = "Destinataire port " + this.portDestinataire;
				}
				if (!(this.portDestinataire != this.tb_portReception.Text))
				{
					TextBox tb_resultat = this.tb_resultat;
					tb_resultat.Text += " (port d'origine)";
					this.numPhaseSuivante = 7;
					return;
				}
				if (this.etatPortDestinataire == PointConnexion.EtatsConnexion.actif)
				{
					this.aiguillageSelonVlan(8, 16, 23);
					return;
				}
				TextBox tb_resultat2 = this.tb_resultat;
				tb_resultat2.Text += " (inactif)";
				this.numPhaseSuivante = 7;
				return;
			}
			case 7:
				this.tb_resultat.Text = "Pas de réémission";
				this.numPhaseSuivante = 10;
				return;
			case 8:
				this.tb_resultat.Text = "Réémission port:" + this.portDestinataire;
				this.numPhaseSuivante = 10;
				return;
			case 9:
				if (((Noeud)this.elt).nbPointsConnexionActifs() > 1)
				{
					this.tb_resultat.Text = "Réémission autres ports actifs";
				}
				else
				{
					this.tb_resultat.Text = "Pas de réémission (ports inactifs)";
				}
				this.numPhaseSuivante = 10;
				return;
			case 10:
				this.numPhaseSuivante = this.actions.Count;
				return;
			case 11:
				if (((PortSwitch)this.sender).GetType() == typeof(Port8021qSwitch))
				{
					this.tb_resultat.Text = "Port 802.1q";
					this.numPhaseSuivante = 12;
					return;
				}
				this.tb_resultat.Text = "Port normal";
				this.aiguillageSelonVlan(0, 14, 18);
				return;
			case 12:
				this.numeroVlan = this.trame.Vlan;
				if (this.numeroVlan == 1)
				{
					this.tb_resultat.Text = "Vlan invité";
				}
				else
				{
					this.tb_resultat.Text = "Numéro de vlan:" + this.numeroVlan;
				}
				this.numPhaseSuivante = 13;
				return;
			case 13:
				this.tb_resultat.Text = "Marque de la trame supprimée";
				this.numPhaseSuivante = 6;
				return;
			case 14:
			{
				this.MontrerTable(this.portVlanEdit1, false);
				this.portVlanEdit1.selectIndex(this.itemPortEmetteur);
				string key = PortVlanEdit.numPortFormat(((PortSwitch)this.sender).NumeroOrdre);
				this.numeroVlan = int.Parse(((ArrayList)((Switch)this.elt).PortVlanNiv1[key])[1].ToString());
				if (this.numeroVlan == 1)
				{
					this.tb_resultat.Text = "Vlan invité";
				}
				else
				{
					this.tb_resultat.Text = "Numéro de vlan:" + this.numeroVlan;
				}
				this.numPhaseSuivante = 6;
				return;
			}
			case 15:
				this.tb_resultat.Text = "Pas de réémission";
				this.numPhaseSuivante = 10;
				return;
			case 16:
				if (this.vlanPortDestinataire == -1)
				{
					this.tb_resultat.Text = "Réémission port:" + this.portDestinataire + "(Port 802.1q)";
				}
				else
				{
					this.MontrerTable(this.portVlanEdit1, false);
					this.portVlanEdit1.selectIndex(this.itemPortDestinataire);
					if (this.vlanPortDestinataire == -1 || this.vlanPortDestinataire == this.numeroVlan)
					{
						this.tb_resultat.Text = "Vlan ok, réémission port:" + this.portDestinataire;
					}
					else
					{
						this.tb_resultat.Text = "Vlan incorrect, cas impossible !";
					}
				}
				this.numPhaseSuivante = 10;
				return;
			case 17:
				if (((Noeud)this.elt).nbPointsConnexionActifs() > 1)
				{
					this.tb_resultat.Text = "Ports du vlan et ports 802.1q";
				}
				else
				{
					this.tb_resultat.Text = "Pas de réémission (ports inactifs)";
				}
				this.numPhaseSuivante = 10;
				return;
			case 18:
				this.MontrerTable(this.macVlanEdit1, false);
				if (this.itemEmetteurMacVlan == -1)
				{
					this.tb_resultat.Text = "Vlan invité";
					this.numeroVlan = 1;
					this.numPhaseSuivante = 19;
					return;
				}
				this.macVlanEdit1.selectIndex(this.itemEmetteurMacVlan);
				this.numeroVlan = int.Parse(this.vlanEmetteur);
				this.tb_resultat.Text = "Numéro de vlan:" + this.numeroVlan;
				this.numPhaseSuivante = 19;
				return;
			case 19:
			{
				this.MontrerTable(this.portVlanEdit1, false);
				this.portVlanEdit1.selectIndex(this.itemPortEmetteur);
				string key = PortVlanEdit.numPortFormat(((PortSwitch)this.sender).NumeroOrdre);
				int num = int.Parse(((ArrayList)((Switch)this.elt).PortVlanNiv1[key])[1].ToString());
				if (num != this.numeroVlan)
				{
					this.tb_resultat.Text = "Vlan du port origine erroné";
					this.numPhaseSuivante = 20;
					return;
				}
				this.tb_resultat.Text = "Vlan port origine connu et correct";
				this.numPhaseSuivante = 6;
				return;
			}
			case 20:
				base.TablesModifiees = true;
				this.ajouterPortReception();
				this.MontrerTable(this.portVlanEdit1, false);
				this.tb_resultat.Text = "Port d'origine modifié";
				this.numPhaseSuivante = 6;
				return;
			case 21:
				this.MontrerTable(this.macVlanEdit1, false);
				this.macVlanEdit1.selectIndex(this.itemDestinataireMacVlan);
				if (this.itemDestinataireMacVlan == -1)
				{
					if (this.numeroVlan == 1)
					{
						this.tb_resultat.Text = "Dest. inconnu, vlan invité";
						this.textPorts = "Ports du vlan et ports 802.1q";
					}
					else
					{
						this.tb_resultat.Text = "Dest. géré par un autre switch";
						this.textPorts = "Ports 802.1q uniquement";
					}
					this.numPhaseSuivante = 22;
					return;
				}
				if (this.vlanDestinataire == this.numeroVlan.ToString())
				{
					this.tb_resultat.Text = "Destinataire géré localement";
					this.textPorts = "Ports du vlan uniquement";
					this.numPhaseSuivante = 22;
					return;
				}
				this.tb_resultat.Text = "Vlan incorrect, cas impossible !";
				this.numPhaseSuivante = 10;
				return;
			case 22:
				this.tb_resultat.Text = this.textPorts;
				this.numPhaseSuivante = 10;
				return;
			case 23:
				this.MontrerTable(this.macVlanEdit1, false);
				this.macVlanEdit1.selectIndex(this.itemDestinataireMacVlan);
				if (this.itemDestinataireMacVlan == -1)
				{
					this.tb_resultat.Text = "Vlan inconnu, réémission port:" + this.portDestinataire;
				}
				else if (this.vlanDestinataire == this.numeroVlan.ToString())
				{
					if (((PortSwitch)this.elt.Controls[int.Parse(this.portDestinataire) - 1]).GetType() == typeof(Port8021qSwitch))
					{
						this.tb_resultat.Text = "Pas de réémission 802.1q, dest local";
					}
					else
					{
						this.tb_resultat.Text = "Vlan ok, réémission port:" + this.portDestinataire;
					}
				}
				else
				{
					this.tb_resultat.Text = "Vlan incorrect, cas impossible !";
				}
				this.numPhaseSuivante = 10;
				return;
			default:
				return;
			}
		}

		// Token: 0x060002AB RID: 683 RVA: 0x000234CC File Offset: 0x000224CC
		public DemoSwitch(Form f) : base(f)
		{
			this.InitializeComponent();
			base.Owner = f;
			this.actions = new ArrayList();
			this.actions.Add("Examiner mac émetteur");
			this.actions.Add("Examiner le port d'origine");
			this.actions.Add("Chercher émet. ds mac/port");
			this.actions.Add("Ajouter émet. ds mac/port");
			this.actions.Add("Modifier émet. ds mac/port");
			this.actions.Add("Réinitialiser TTL émetteur");
			this.actions.Add("Sélect. dest. ds mac/port");
			this.actions.Add("Ne pas réémettre");
			this.actions.Add("Réémettre sur le port dest.");
			this.actions.Add("Réémettre sur les autres ports");
			this.actions.Add("Fin de la démonstration");
			this.actions.Add("Examiner type port origine");
			this.actions.Add("Lire la marque de la trame");
			this.actions.Add("Enlever la marque de la trame");
			this.actions.Add("Examiner table port/vlan");
			this.actions.Add("Ne pas réémettre");
			this.actions.Add("Examiner table port/vlan");
			this.actions.Add("Réémettre sur les autres ports");
			this.actions.Add("Chercher émet. ds mac/vlan");
			this.actions.Add("Ch. port orig. ds port/vlan");
			this.actions.Add("Maj port orig. ds port/vlan");
			this.actions.Add("Vérifier vlan destinataire");
			this.actions.Add("Réémettre sur les autres ports");
			this.actions.Add("Examiner table mac/vlan");
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0002371C File Offset: 0x0002271C
		private void MontrerTable(Control c, bool modifiable)
		{
			if (c.GetType() == typeof(TextBox))
			{
				base.Size = new Size(230, 136);
			}
			else
			{
				base.Size = new Size(230, 210);
			}
			this.macPortEdit1.Visible = false;
			this.portVlanEdit1.Visible = false;
			this.macVlanEdit1.Visible = false;
			this.lb_ports.Visible = false;
			if (c.GetType().BaseType == typeof(HashTableEdit))
			{
				if (modifiable)
				{
					c.Width = 220;
				}
				else
				{
					c.Width = 240;
				}
			}
			c.Visible = true;
			base.InScreen();
		}

		// Token: 0x060002AD RID: 685 RVA: 0x000237D8 File Offset: 0x000227D8
		private void cacherTable()
		{
			base.Size = new Size(230, 110);
			this.macPortEdit1.Visible = false;
			this.portVlanEdit1.Visible = false;
			this.macVlanEdit1.Visible = false;
			this.lb_ports.Visible = false;
			this.tb_vlanMarque.Visible = false;
			base.InScreen();
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0002383C File Offset: 0x0002283C
		private ArrayList autresPorts()
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.elt.Controls)
			{
				PortSwitch portSwitch = (PortSwitch)obj;
				if (portSwitch.EtatConnexion == PointConnexion.EtatsConnexion.actif && portSwitch.ToString() != this.portEmet)
				{
					arrayList.Add(portSwitch.ToString());
				}
			}
			return arrayList;
		}

		// Token: 0x060002AF RID: 687 RVA: 0x000238D0 File Offset: 0x000228D0
		private ArrayList autresPortsVlanNiv1(int vlan)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.elt.Controls)
			{
				PortSwitch portSwitch = (PortSwitch)obj;
				if (portSwitch.EtatConnexion == PointConnexion.EtatsConnexion.actif && portSwitch.ToString() != this.portEmet)
				{
					int num = portSwitch.Vlan(this.portVlanEdit1.GetTable());
					if (num == -1 || num == vlan)
					{
						arrayList.Add(portSwitch.ToString());
					}
				}
			}
			return arrayList;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00023980 File Offset: 0x00022980
		private ArrayList autresPortsVlanNiv2(int vlan, bool portsDuVlan, bool ports8021q)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.elt.Controls)
			{
				PortSwitch portSwitch = (PortSwitch)obj;
				if (portSwitch.EtatConnexion == PointConnexion.EtatsConnexion.actif && portSwitch.ToString() != this.portEmet)
				{
					int num = portSwitch.Vlan(this.portVlanEdit1.GetTable());
					if (num == -1 && ports8021q)
					{
						arrayList.Add(portSwitch.ToString());
					}
					else if (num == vlan && portsDuVlan)
					{
						arrayList.Add(portSwitch.ToString());
					}
				}
			}
			return arrayList;
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00023A48 File Offset: 0x00022A48
		protected override void initManuel()
		{
			this.init();
			this.Text = "Switch : " + ((Switch)this.elt).NomNoeud;
			switch (((Switch)this.elt).NiveauVlan)
			{
			case 0:
				this.nbPhasesManuelles = 4;
				base.initManuel();
				this.cb_action.Items.Clear();
				this.cb_action.Items.Add("Editer la table mac/port...");
				this.cb_action.Items.Add("Sélectionner ports de réémission...");
				this.cb_action.Items.Add("Réémettre sur ports sélectionnés -->");
				this.cb_action.Items.Add("Ne pas réémettre -->");
				this.initManuelVlan0();
				return;
			case 1:
				this.nbPhasesManuelles = 6;
				base.initManuel();
				this.cb_action.Items.Clear();
				this.cb_action.Items.Add("Editer la table mac/port...");
				this.cb_action.Items.Add("Consulter la table port/vlan...");
				this.cb_action.Items.Add("Examiner la marque 802.1q...");
				this.cb_action.Items.Add("Sélectionner ports de réémission...");
				this.cb_action.Items.Add("Réémettre sur ports sélectionnés -->");
				this.cb_action.Items.Add("Ne pas réémettre -->");
				this.initManuelVlan1();
				return;
			case 2:
				this.nbPhasesManuelles = 7;
				base.initManuel();
				this.cb_action.Items.Clear();
				this.cb_action.Items.Add("Editer la table mac/port...");
				this.cb_action.Items.Add("Consulter la table mac/vlan...");
				this.cb_action.Items.Add("Editer la table port/vlan...");
				this.cb_action.Items.Add("Examiner la marque 802.1q...");
				this.cb_action.Items.Add("Sélectionner ports de réémission...");
				this.cb_action.Items.Add("Réémettre sur ports sélectionnés -->");
				this.cb_action.Items.Add("Ne pas réémettre -->");
				this.initManuelVlan2();
				return;
			default:
				return;
			}
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00023C80 File Offset: 0x00022C80
		private void initManuelVlan0()
		{
			this.macPortEdit1.ChangerMode(false);
			this.cacherTable();
			this.tableOk = (SortedList)((Switch)this.elt).PortAdresseMac.Clone();
			Switch.AjouterTableMacPort(this.tableOk, this.trame.MacEmetteur, (PortSwitch)this.sender);
			this.portEmet = ((ArrayList)this.tableOk[this.trame.MacEmetteur])[1].ToString();
			if (this.trame.MacDestinataire == this.elt.Reseau.Pref.AdrMacBroadcast)
			{
				if (((Noeud)this.elt).nbPointsConnexionActifs() > 1)
				{
					this.portsOk = this.autresPorts();
					this.phasesAValider.Add(2);
				}
				else
				{
					this.phasesAValider.Add(3);
				}
			}
			else
			{
				if (this.tableOk.ContainsKey(this.trame.MacDestinataire))
				{
					this.portDest = ((ArrayList)this.tableOk[this.trame.MacDestinataire])[1].ToString();
					this.etatPortDest = ((PortSwitch)((ArrayList)this.tableOk[this.trame.MacDestinataire])[1]).EtatConnexion;
				}
				else
				{
					this.portDest = "inconnu";
					this.etatPortDest = PointConnexion.EtatsConnexion.erreur;
				}
				if (this.portDest == this.portEmet)
				{
					this.phasesAValider.Add(3);
				}
				else if (this.portDest == "inconnu")
				{
					if (((Noeud)this.elt).nbPointsConnexionActifs() > 1)
					{
						this.portsOk = this.autresPorts();
						this.phasesAValider.Add(2);
					}
					else
					{
						this.phasesAValider.Add(3);
					}
				}
				else if (this.etatPortDest == PointConnexion.EtatsConnexion.actif)
				{
					this.portsOk.Add(this.portDest);
					this.phasesAValider.Add(2);
				}
				else
				{
					this.phasesAValider.Add(3);
				}
			}
			foreach (object obj in ((Switch)this.elt).Controls)
			{
				PortSwitch portSwitch = (PortSwitch)obj;
				string item = string.Concat(new object[]
				{
					"Port n°",
					portSwitch.ToString(),
					" (",
					portSwitch.EtatConnexion,
					")"
				});
				this.lb_ports.Items.Add(item, false);
			}
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00023F7C File Offset: 0x00022F7C
		private void initManuelVlan1()
		{
			this.macPortEdit1.ChangerMode(false);
			this.cacherTable();
			this.tableOk = (SortedList)((Switch)this.elt).PortAdresseMac.Clone();
			Switch.AjouterTableMacPort(this.tableOk, this.trame.MacEmetteur, (PortSwitch)this.sender);
			PortSwitch portSwitch = (PortSwitch)((ArrayList)this.tableOk[this.trame.MacEmetteur])[1];
			this.portEmet = portSwitch.ToString();
			int num = portSwitch.Vlan(this.portVlanEdit1.GetTable());
			if (num == -1)
			{
				num = this.trame.Vlan;
			}
			if (this.trame.MacDestinataire == this.elt.Reseau.Pref.AdrMacBroadcast)
			{
				this.portsOk = this.autresPortsVlanNiv1(num);
				if (this.portsOk.Count > 0)
				{
					this.phasesAValider.Add(4);
				}
				else
				{
					this.phasesAValider.Add(5);
				}
			}
			else if (this.tableOk.ContainsKey(this.trame.MacDestinataire))
			{
				PortSwitch portSwitch2 = (PortSwitch)((ArrayList)this.tableOk[this.trame.MacDestinataire])[1];
				this.portDest = portSwitch2.ToString();
				this.etatPortDest = ((PortSwitch)((ArrayList)this.tableOk[this.trame.MacDestinataire])[1]).EtatConnexion;
				if ((portSwitch2.Vlan(this.portVlanEdit1.GetTable()) == num || portSwitch2.Vlan(this.portVlanEdit1.GetTable()) == -1) && this.etatPortDest == PointConnexion.EtatsConnexion.actif && this.portDest != this.portEmet)
				{
					this.portsOk.Add(this.portDest);
					this.phasesAValider.Add(4);
				}
				else
				{
					this.phasesAValider.Add(5);
				}
			}
			else
			{
				this.portsOk = this.autresPortsVlanNiv1(num);
				if (this.portsOk.Count > 0)
				{
					this.phasesAValider.Add(4);
				}
				else
				{
					this.phasesAValider.Add(5);
				}
			}
			foreach (object obj in ((Switch)this.elt).Controls)
			{
				PortSwitch portSwitch3 = (PortSwitch)obj;
				string item;
				if (portSwitch3.GetType() == typeof(Port8021qSwitch))
				{
					item = string.Concat(new object[]
					{
						"Port n°",
						portSwitch3.ToString(),
						" (",
						portSwitch3.EtatConnexion,
						", 802.1q)"
					});
				}
				else
				{
					item = string.Concat(new object[]
					{
						"Port n°",
						portSwitch3.ToString(),
						" (",
						portSwitch3.EtatConnexion,
						")"
					});
				}
				this.lb_ports.Items.Add(item, false);
			}
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x000242FC File Offset: 0x000232FC
		private void initManuelVlan2()
		{
			this.macPortEdit1.ChangerMode(false);
			this.portVlanEdit1.ChangerMode(false);
			this.cacherTable();
			this.tableOk = (SortedList)((Switch)this.elt).PortAdresseMac.Clone();
			Switch.AjouterTableMacPort(this.tableOk, this.trame.MacEmetteur, (PortSwitch)this.sender);
			PortSwitch portSwitch = (PortSwitch)((ArrayList)this.tableOk[this.trame.MacEmetteur])[1];
			this.tablePortVlanOk = (SortedList)((Switch)this.elt).PortVlanNiv1.Clone();
			if (portSwitch.Vlan(this.tablePortVlanOk) != -1 && this.vlanEmetteur != "")
			{
				Switch.AjouterTablePortVlan(this.tablePortVlanOk, portSwitch.NumeroOrdre, this.vlanEmetteur);
			}
			this.portEmet = portSwitch.ToString();
			int num = portSwitch.Vlan(this.tablePortVlanOk);
			if (num == -1)
			{
				num = this.trame.Vlan;
			}
			if (this.trame.MacDestinataire == this.elt.Reseau.Pref.AdrMacBroadcast)
			{
				this.portsOk = this.autresPortsVlanNiv2(num, true, true);
				if (this.portsOk.Count > 0)
				{
					this.phasesAValider.Add(5);
				}
				else
				{
					this.phasesAValider.Add(6);
				}
			}
			else if (this.tableOk.ContainsKey(this.trame.MacDestinataire))
			{
				PortSwitch portSwitch2 = (PortSwitch)((ArrayList)this.tableOk[this.trame.MacDestinataire])[1];
				this.portDest = portSwitch2.ToString();
				this.etatPortDest = ((PortSwitch)((ArrayList)this.tableOk[this.trame.MacDestinataire])[1]).EtatConnexion;
				if ((this.vlanDestinataire == num.ToString() || this.itemDestinataireMacVlan == -1) && this.etatPortDest == PointConnexion.EtatsConnexion.actif && this.portDest != this.portEmet)
				{
					if (this.itemDestinataireMacVlan != -1 && portSwitch2.GetType() == typeof(Port8021qSwitch))
					{
						this.phasesAValider.Add(6);
					}
					else
					{
						this.portsOk.Add(this.portDest);
						this.phasesAValider.Add(5);
					}
				}
				else
				{
					this.phasesAValider.Add(6);
				}
			}
			else if (this.macVlanEdit1.GetTable().ContainsKey(this.trame.MacDestinataire))
			{
				if (((ArrayList)this.macVlanEdit1.GetTable()[this.trame.MacDestinataire])[1].ToString() == num.ToString())
				{
					this.portsOk = this.autresPortsVlanNiv2(num, true, false);
					if (this.portsOk.Count > 0)
					{
						this.phasesAValider.Add(5);
					}
					else
					{
						this.phasesAValider.Add(6);
					}
				}
				else
				{
					this.phasesAValider.Add(6);
				}
			}
			else
			{
				if (num == 1)
				{
					this.portsOk = this.autresPortsVlanNiv2(num, true, true);
				}
				else
				{
					this.portsOk = this.autresPortsVlanNiv2(num, false, true);
				}
				if (this.portsOk.Count > 0)
				{
					this.phasesAValider.Add(5);
				}
				else
				{
					this.phasesAValider.Add(6);
				}
			}
			foreach (object obj in ((Switch)this.elt).Controls)
			{
				PortSwitch portSwitch3 = (PortSwitch)obj;
				string item;
				if (portSwitch3.GetType() == typeof(Port8021qSwitch))
				{
					item = string.Concat(new object[]
					{
						"Port n°",
						portSwitch3.ToString(),
						" (",
						portSwitch3.EtatConnexion,
						", 802.1q)"
					});
				}
				else
				{
					item = string.Concat(new object[]
					{
						"Port n°",
						portSwitch3.ToString(),
						" (",
						portSwitch3.EtatConnexion,
						")"
					});
				}
				this.lb_ports.Items.Add(item, false);
			}
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x000247D8 File Offset: 0x000237D8
		protected override void executerPhaseManuelle(int numPhaseManuelle)
		{
			this.cacherTable();
			switch (((Switch)this.elt).NiveauVlan)
			{
			case 0:
				this.executerPhaseManuelleVlan0(numPhaseManuelle);
				return;
			case 1:
				this.executerPhaseManuelleVlan1(numPhaseManuelle);
				return;
			case 2:
				this.executerPhaseManuelleVlan2(numPhaseManuelle);
				return;
			default:
				return;
			}
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00024828 File Offset: 0x00023828
		private void executerPhaseManuelleVlan0(int numPhaseManuelle)
		{
			switch (numPhaseManuelle)
			{
			case 0:
				this.MontrerTable(this.macPortEdit1, true);
				this.messageManuelOk = "Mettez la table à jour...";
				this.okManuel = true;
				return;
			case 1:
				this.MontrerTable(this.lb_ports, true);
				this.messageManuelOk = "Sélectionnez les ports...";
				this.okManuel = true;
				return;
			case 2:
				if (this.phasesAValider.Contains(2))
				{
					if (HashTableEdit.Identiques(this.tableOk, this.macPortEdit1.GetTable()))
					{
						this.okManuel = true;
						this.messageManuelErreur = "Ports sélectionnés incorrects !";
						using (IEnumerator enumerator = this.elt.Controls.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								object obj = enumerator.Current;
								PortSwitch portSwitch = (PortSwitch)obj;
								if (this.portsOk.Contains(portSwitch.ToString()))
								{
									this.okManuel = (this.okManuel && this.lb_ports.GetItemChecked(portSwitch.NumeroOrdre - 1));
								}
								else
								{
									this.okManuel = (this.okManuel && !this.lb_ports.GetItemChecked(portSwitch.NumeroOrdre - 1));
								}
							}
							break;
						}
					}
					this.messageManuelErreur = "Table mac/port incorrecte !";
					return;
				}
				break;
			case 3:
				if (this.phasesAValider.Contains(3))
				{
					if (HashTableEdit.Identiques(this.tableOk, this.macPortEdit1.GetTable()))
					{
						this.okManuel = true;
						return;
					}
					this.messageManuelErreur = "Table mac/port incorrecte !";
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x000249D4 File Offset: 0x000239D4
		private void executerPhaseManuelleVlan1(int numPhaseManuelle)
		{
			switch (numPhaseManuelle)
			{
			case 0:
				this.MontrerTable(this.macPortEdit1, true);
				this.messageManuelOk = "Mettez la table à jour...";
				this.okManuel = true;
				return;
			case 1:
				this.MontrerTable(this.portVlanEdit1, false);
				this.messageManuelOk = "Consultez la table...";
				this.okManuel = true;
				return;
			case 2:
				if (this.trame.Marque8021q)
				{
					this.tb_vlanMarque.Text = "Vlan indiqué dans la marque 802.1q : " + this.trame.Vlan;
					this.messageManuelOk = "Voici la marque...";
				}
				else
				{
					this.tb_vlanMarque.Text = "";
					this.messageManuelOk = "Trame non marquée !";
				}
				this.MontrerTable(this.tb_vlanMarque, false);
				this.okManuel = true;
				return;
			case 3:
				this.MontrerTable(this.lb_ports, true);
				this.messageManuelOk = "Sélectionnez les ports...";
				this.okManuel = true;
				return;
			case 4:
				if (this.phasesAValider.Contains(4))
				{
					if (HashTableEdit.Identiques(this.tableOk, this.macPortEdit1.GetTable()))
					{
						this.okManuel = true;
						this.messageManuelErreur = "Ports sélectionnés incorrects !";
						using (IEnumerator enumerator = this.elt.Controls.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								object obj = enumerator.Current;
								PortSwitch portSwitch = (PortSwitch)obj;
								if (this.portsOk.Contains(portSwitch.ToString()))
								{
									this.okManuel = (this.okManuel && this.lb_ports.GetItemChecked(portSwitch.NumeroOrdre - 1));
								}
								else
								{
									this.okManuel = (this.okManuel && !this.lb_ports.GetItemChecked(portSwitch.NumeroOrdre - 1));
								}
							}
							break;
						}
					}
					this.messageManuelErreur = "Table mac/port incorrecte !";
					return;
				}
				break;
			case 5:
				if (this.phasesAValider.Contains(5))
				{
					if (HashTableEdit.Identiques(this.tableOk, this.macPortEdit1.GetTable()))
					{
						this.okManuel = true;
						return;
					}
					this.messageManuelErreur = "Table mac/port incorrecte !";
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00024C14 File Offset: 0x00023C14
		private void executerPhaseManuelleVlan2(int numPhaseManuelle)
		{
			switch (numPhaseManuelle)
			{
			case 0:
				this.MontrerTable(this.macPortEdit1, true);
				this.messageManuelOk = "Mettez la table à jour...";
				this.okManuel = true;
				return;
			case 1:
				this.MontrerTable(this.macVlanEdit1, false);
				this.messageManuelOk = "Consultez la table...";
				this.okManuel = true;
				return;
			case 2:
				this.MontrerTable(this.portVlanEdit1, true);
				this.messageManuelOk = "Mettez la table à jour...";
				this.okManuel = true;
				return;
			case 3:
				if (this.trame.Marque8021q)
				{
					this.tb_vlanMarque.Text = "Vlan indiqué dans la marque 802.1q : " + this.trame.Vlan;
					this.messageManuelOk = "Voici la marque...";
				}
				else
				{
					this.tb_vlanMarque.Text = "";
					this.messageManuelOk = "Trame non marquée !";
				}
				this.MontrerTable(this.tb_vlanMarque, false);
				this.okManuel = true;
				return;
			case 4:
				this.MontrerTable(this.lb_ports, true);
				this.messageManuelOk = "Sélectionnez les ports...";
				this.okManuel = true;
				return;
			case 5:
				if (this.phasesAValider.Contains(5))
				{
					if (HashTableEdit.Identiques(this.tableOk, this.macPortEdit1.GetTable()))
					{
						if (HashTableEdit.Identiques(this.tablePortVlanOk, this.portVlanEdit1.GetTable()))
						{
							this.okManuel = true;
							this.messageManuelErreur = "Ports sélectionnés incorrects !";
							using (IEnumerator enumerator = this.elt.Controls.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									object obj = enumerator.Current;
									PortSwitch portSwitch = (PortSwitch)obj;
									if (this.portsOk.Contains(portSwitch.ToString()))
									{
										this.okManuel = (this.okManuel && this.lb_ports.GetItemChecked(portSwitch.NumeroOrdre - 1));
									}
									else
									{
										this.okManuel = (this.okManuel && !this.lb_ports.GetItemChecked(portSwitch.NumeroOrdre - 1));
									}
								}
								break;
							}
						}
						this.messageManuelErreur = "Table port/vlan incorrecte !";
						return;
					}
					this.messageManuelErreur = "Table mac/port incorrecte !";
					return;
				}
				break;
			case 6:
				if (this.phasesAValider.Contains(6))
				{
					if (HashTableEdit.Identiques(this.tableOk, this.macPortEdit1.GetTable()))
					{
						if (HashTableEdit.Identiques(this.tablePortVlanOk, this.portVlanEdit1.GetTable()))
						{
							this.okManuel = true;
							return;
						}
						this.messageManuelErreur = "Table port/vlan incorrecte !";
						return;
					}
					else
					{
						this.messageManuelErreur = "Table mac/port incorrecte !";
					}
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00024EC8 File Offset: 0x00023EC8
		private void DemoSwitch_Activated(object sender, EventArgs e)
		{
			this.macPortEdit1.MacAttenteOn();
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00024EE0 File Offset: 0x00023EE0
		private void DemoSwitch_Closed(object sender, EventArgs e)
		{
			this.macPortEdit1.MacAttenteOff();
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00024EF8 File Offset: 0x00023EF8
		protected override ArrayList getTables()
		{
			SortedList sortedList = new SortedList();
			sortedList["itemDestinataire"] = this.itemDestinataire;
			sortedList["itemEmetteur"] = this.itemEmetteur;
			sortedList["itemEmetteurMacVlan"] = this.itemEmetteurMacVlan;
			sortedList["itemDestinataireMacVlan"] = this.itemDestinataireMacVlan;
			sortedList["itemPortEmetteur"] = this.itemPortEmetteur;
			ArrayList arrayList = new ArrayList();
			arrayList.Add(sortedList.Clone());
			switch (((Switch)this.elt).NiveauVlan)
			{
			case 0:
				arrayList.Add(this.macPortEdit1.GetTable().Clone());
				break;
			case 1:
				arrayList.Add(this.macPortEdit1.GetTable().Clone());
				arrayList.Add(this.portVlanEdit1.GetTable().Clone());
				break;
			case 2:
				arrayList.Add(this.macPortEdit1.GetTable().Clone());
				arrayList.Add(this.portVlanEdit1.GetTable().Clone());
				arrayList.Add(this.macVlanEdit1.GetTable().Clone());
				break;
			}
			return arrayList;
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00025044 File Offset: 0x00024044
		protected override void setTables(ArrayList p_tables)
		{
			SortedList sortedList = (SortedList)p_tables[0];
			this.itemDestinataire = int.Parse(sortedList["itemDestinataire"].ToString());
			this.itemEmetteur = int.Parse(sortedList["itemEmetteur"].ToString());
			this.itemEmetteurMacVlan = int.Parse(sortedList["itemEmetteurMacVlan"].ToString());
			this.itemDestinataireMacVlan = int.Parse(sortedList["itemDestinataireMacVlan"].ToString());
			this.itemPortEmetteur = int.Parse(sortedList["itemPortEmetteur"].ToString());
			switch (((Switch)this.elt).NiveauVlan)
			{
			case 0:
				this.macPortEdit1.SetTable((SortedList)((SortedList)p_tables[1]).Clone());
				return;
			case 1:
				this.macPortEdit1.SetTable((SortedList)((SortedList)p_tables[1]).Clone());
				this.portVlanEdit1.SetTable((SortedList)((SortedList)p_tables[2]).Clone());
				return;
			case 2:
				this.macPortEdit1.SetTable((SortedList)((SortedList)p_tables[1]).Clone());
				this.portVlanEdit1.SetTable((SortedList)((SortedList)p_tables[2]).Clone());
				this.macVlanEdit1.SetTable((SortedList)((SortedList)p_tables[3]).Clone());
				return;
			default:
				return;
			}
		}

		// Token: 0x0400025E RID: 606
		private int niveauVlan = 0;

		// Token: 0x0400025F RID: 607
		private int itemPortEmetteur = -1;

		// Token: 0x04000260 RID: 608
		private int itemPortDestinataire = -1;

		// Token: 0x04000261 RID: 609
		private int itemDestinataire = -1;

		// Token: 0x04000262 RID: 610
		private int itemEmetteur = -1;

		// Token: 0x04000263 RID: 611
		private int itemEmetteurMacVlan = -1;

		// Token: 0x04000264 RID: 612
		private int itemDestinataireMacVlan = -1;

		// Token: 0x04000265 RID: 613
		private string portDestinataire = "";

		// Token: 0x04000266 RID: 614
		private string portEmetteur = "";

		// Token: 0x04000267 RID: 615
		private string vlanEmetteur = "";

		// Token: 0x04000268 RID: 616
		private string vlanDestinataire = "";

		// Token: 0x04000269 RID: 617
		private PointConnexion.EtatsConnexion etatPortDestinataire = PointConnexion.EtatsConnexion.erreur;

		// Token: 0x0400026A RID: 618
		private int vlanPortDestinataire = 0;

		// Token: 0x0400026B RID: 619
		private string[] libPhases = new string[24];

		// Token: 0x0400026C RID: 620
		private string textPorts;

		// Token: 0x0400026D RID: 621
		private int numeroVlan;

		// Token: 0x0400026E RID: 622
		private SortedList tableOk;

		// Token: 0x0400026F RID: 623
		private ArrayList portsOk = new ArrayList();

		// Token: 0x04000270 RID: 624
		private SortedList tablePortVlanOk;

		// Token: 0x04000271 RID: 625
		private string portDest;

		// Token: 0x04000272 RID: 626
		private string portEmet;

		// Token: 0x04000273 RID: 627
		private PointConnexion.EtatsConnexion etatPortDest;
	}
}
