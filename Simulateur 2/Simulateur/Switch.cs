using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Simulateur
{
	// Token: 0x0200008A RID: 138
	public class Switch : Interconnexion
	{
		// Token: 0x060008B2 RID: 2226 RVA: 0x00053400 File Offset: 0x00052400
		public Switch()
		{
			int[] array = new int[2];
			this.numTrameTampon = array;
			this.couleurTampon = new Brush[2];
			this.hauteurTableMacPort = DialogueHashTable.Hauteur;
			this.hauteurTableMacVlan = DialogueHashTable.Hauteur;
			this.hauteurTablePortVlan = DialogueHashTable.Hauteur;
			base..ctor();
			this.InitializeComponent();
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x0005351C File Offset: 0x0005251C
		public Switch(Simulation s, string nom)
		{
			int[] array = new int[2];
			this.numTrameTampon = array;
			this.couleurTampon = new Brush[2];
			this.hauteurTableMacPort = DialogueHashTable.Hauteur;
			this.hauteurTableMacVlan = DialogueHashTable.Hauteur;
			this.hauteurTablePortVlan = DialogueHashTable.Hauteur;
			base..ctor(s, nom);
			this.InitializeComponent();
			this.initialiser();
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x00053640 File Offset: 0x00052640
		private void initialiser()
		{
			base.Height += 2;
			if (this.reseau.Pref.StoreAndForward)
			{
				this.typeSwitch = Switch.TypeDeSwitch.storeAndForward;
			}
			else
			{
				this.typeSwitch = Switch.TypeDeSwitch.onTheFly;
			}
			this.spanningTree = this.reseau.Pref.SpanningTree;
			this.niveauVlan = this.reseau.Pref.NiveauVlanSwitch;
			this.etiquette = "Switch:";
			base.InitialiserPorts(this.reseau.Pref.NbPortsSwitch, this.reseau.Pref.NbPortsCascadeSwitch, this.reseau.Pref.NbPorts8021qSwitch);
			switch (this.niveauVlan)
			{
			case 0:
				this.portVlanNiv1 = new SortedList();
				this.macVlanNiv2 = new SortedList();
				break;
			case 1:
				this.initTablePortVlan1(0, 0);
				this.macVlanNiv2 = new SortedList();
				break;
			case 2:
				this.initTablePortVlan1(0, 0);
				this.macVlanNiv2 = new SortedList();
				break;
			}
			this.delaiTransmissionTrame.Interval = this.reseau.Pref.TempsDelaiTransmissionSwitch;
			this.delaiTransmissionDebutTrame0.Interval = this.reseau.Pref.TempsDelaiTransmissionSwitch;
			this.delaiTransmissionDebutTrame1.Interval = this.reseau.Pref.TempsDelaiTransmissionSwitch;
			this.delaiTransmissionFinTrame0.Interval = this.reseau.Pref.TempsDelaiTransmissionSwitch;
			this.delaiTransmissionFinTrame1.Interval = this.reseau.Pref.TempsDelaiTransmissionSwitch;
			this.couleurTampon[0] = this.reseau.Pref.CableActifStylo1.Brush;
			this.couleurTampon[1] = this.reseau.Pref.CableActifStylo2.Brush;
			this.initTampons();
			this.SetContenuInfoBulle();
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060008B5 RID: 2229 RVA: 0x00053814 File Offset: 0x00052814
		public Timer DelaiTransmissionTrame
		{
			get
			{
				return this.delaiTransmissionTrame;
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060008B6 RID: 2230 RVA: 0x00053828 File Offset: 0x00052828
		public Timer DelaiTransmissionDebutTrame0
		{
			get
			{
				return this.delaiTransmissionDebutTrame0;
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060008B7 RID: 2231 RVA: 0x0005383C File Offset: 0x0005283C
		public Timer DelaiTransmissionDebutTrame1
		{
			get
			{
				return this.delaiTransmissionDebutTrame1;
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x060008B8 RID: 2232 RVA: 0x00053850 File Offset: 0x00052850
		public Timer DelaiTransmissionFinTrame0
		{
			get
			{
				return this.delaiTransmissionFinTrame0;
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060008B9 RID: 2233 RVA: 0x00053864 File Offset: 0x00052864
		public Timer DelaiTransmissionFinTrame1
		{
			get
			{
				return this.delaiTransmissionFinTrame1;
			}
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x00053878 File Offset: 0x00052878
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x000538A4 File Offset: 0x000528A4
		private void InitializeComponent()
		{
			this.mi_tableMacPort = new MenuItem();
			this.mi_voirConfig = new MenuItem();
			this.mi_viderTable = new MenuItem();
			this.mi_decouvrirReseau = new MenuItem();
			this.mi_tablePortVlan = new MenuItem();
			this.mi_tableMacVlan = new MenuItem();
			this.menuItem2 = new MenuItem();
			this.menuItem4 = new MenuItem();
			this.menuItem1 = new MenuItem();
			this.mi_viderTablePortVlan = new MenuItem();
			this.cm_ethernet.MenuItems.AddRange(new MenuItem[]
			{
				this.menuItem2,
				this.mi_decouvrirReseau,
				this.mi_viderTable,
				this.mi_tableMacPort,
				this.menuItem1,
				this.mi_tablePortVlan,
				this.mi_viderTablePortVlan,
				this.mi_tableMacVlan,
				this.menuItem4,
				this.mi_voirConfig
			});
			this.mi_tableMacPort.Index = 5;
			this.mi_tableMacPort.Text = "Editer table mac/port";
			this.mi_tableMacPort.Click += this.mi_tableMacPort_Click;
			this.mi_voirConfig.Index = 11;
			this.mi_voirConfig.Text = "Configurer";
			this.mi_voirConfig.Click += this.mi_voirConfig_Click;
			this.mi_viderTable.Index = 4;
			this.mi_viderTable.Text = "Vider table mac/port";
			this.mi_viderTable.Click += this.mi_viderTable_Click;
			this.mi_decouvrirReseau.Index = 3;
			this.mi_decouvrirReseau.Text = "Découvrir le réseau";
			this.mi_decouvrirReseau.Click += this.mi_decouvrirReseau_Click;
			this.mi_tablePortVlan.Index = 7;
			this.mi_tablePortVlan.Text = "Editer table port/vlan";
			this.mi_tablePortVlan.Click += this.mi_tablePortVlan_Click;
			this.mi_tableMacVlan.Index = 9;
			this.mi_tableMacVlan.Text = "Editer table mac/vlan";
			this.mi_tableMacVlan.Click += this.mi_tableMacVlan_Click;
			this.menuItem2.Index = 2;
			this.menuItem2.Text = "-";
			this.menuItem4.Index = 10;
			this.menuItem4.Text = "-";
			this.menuItem1.Index = 6;
			this.menuItem1.Text = "-";
			this.mi_viderTablePortVlan.Index = 8;
			this.mi_viderTablePortVlan.Text = "Réinitialiser table port/vlan";
			this.mi_viderTablePortVlan.Click += this.mi_viderTablePortVlan_Click;
			base.Name = "Switch";
			base.Paint += this.Interconnexion_Paint;
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x00053B70 File Offset: 0x00052B70
		public int NbPorts8021qConnectes()
		{
			int num = 0;
			for (int i = this.nbPointsConnexion - 1; i >= this.nbPointsConnexion - this.nbPorts8021q; i--)
			{
				Port8021qSwitch port8021qSwitch = (Port8021qSwitch)base.Controls[i];
				if (port8021qSwitch.Lien != null)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x00053BC0 File Offset: 0x00052BC0
		public override void Configurer()
		{
			int nbPorts = this.nbPorts;
			int nbPortsCascade = this.nbPortsCascade;
			ConfigSwitch configSwitch = new ConfigSwitch(this, false);
			configSwitch.Text = "Configuration d'un Switch";
			if (base.ConfigurerGraphique(configSwitch))
			{
				this.typeSwitch = configSwitch.TypeSwitch;
				this.spanningTree = configSwitch.SpanningTree;
				int num = this.niveauVlan;
				this.niveauVlan = configSwitch.NiveauVlan;
				this.portAdresseMac = new SortedList();
				switch (this.niveauVlan)
				{
				case 0:
					this.portVlanNiv1 = new SortedList();
					this.macVlanNiv2 = new SortedList();
					break;
				case 1:
					if (num == 1)
					{
						this.initTablePortVlan1(nbPorts, nbPortsCascade);
					}
					else
					{
						this.initTablePortVlan1(0, 0);
					}
					this.macVlanNiv2 = new SortedList();
					break;
				case 2:
					if (num == 2)
					{
						this.initTablePortVlan1(nbPorts, nbPortsCascade);
					}
					else
					{
						this.initTablePortVlan1(0, 0);
						this.macVlanNiv2 = new SortedList();
					}
					break;
				}
				this.SetContenuInfoBulle();
			}
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x00053CB0 File Offset: 0x00052CB0
		private void initTablePortVlan1(int oldNbPorts, int oldNbPortsCascade)
		{
			SortedList sortedList = (SortedList)this.portVlanNiv1.Clone();
			this.portVlanNiv1 = new SortedList();
			int num = 1;
			int num2 = 1;
			int num3 = Math.Min(this.nbPorts, oldNbPorts);
			for (int i = 1; i <= num3; i++)
			{
				this.portVlanNiv1[PortVlanEdit.numPortFormat(num2)] = new ArrayList();
				((ArrayList)this.portVlanNiv1[PortVlanEdit.numPortFormat(num2)]).Add(PortVlanEdit.numPortFormat(num2));
				((ArrayList)this.portVlanNiv1[PortVlanEdit.numPortFormat(num2)]).Add(((ArrayList)sortedList[PortVlanEdit.numPortFormat(num)])[1]);
				num2++;
				num++;
			}
			for (int j = num3 + 1; j <= this.nbPorts; j++)
			{
				this.portVlanNiv1[PortVlanEdit.numPortFormat(num2)] = new ArrayList();
				((ArrayList)this.portVlanNiv1[PortVlanEdit.numPortFormat(num2)]).Add(PortVlanEdit.numPortFormat(num2));
				((ArrayList)this.portVlanNiv1[PortVlanEdit.numPortFormat(num2)]).Add("1");
				num2++;
			}
			int num4 = Math.Min(this.nbPortsCascade, oldNbPortsCascade);
			num = oldNbPorts + 1;
			for (int k = 1; k <= num4; k++)
			{
				this.portVlanNiv1[PortVlanEdit.numPortFormat(num2)] = new ArrayList();
				((ArrayList)this.portVlanNiv1[PortVlanEdit.numPortFormat(num2)]).Add(PortVlanEdit.numPortFormat(num2));
				((ArrayList)this.portVlanNiv1[PortVlanEdit.numPortFormat(num2)]).Add(((ArrayList)sortedList[PortVlanEdit.numPortFormat(num)])[1]);
				num2++;
				num++;
			}
			for (int l = num4 + 1; l <= this.nbPortsCascade; l++)
			{
				this.portVlanNiv1[PortVlanEdit.numPortFormat(num2)] = new ArrayList();
				((ArrayList)this.portVlanNiv1[PortVlanEdit.numPortFormat(num2)]).Add(PortVlanEdit.numPortFormat(num2));
				((ArrayList)this.portVlanNiv1[PortVlanEdit.numPortFormat(num2)]).Add("1");
				num2++;
			}
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x00053EEC File Offset: 0x00052EEC
		public override Port nouveauPort()
		{
			return new PortSwitch(this.reseau);
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x00053F04 File Offset: 0x00052F04
		public override Port nouveauPortDeCascade()
		{
			return new PortDeCascadeSwitch(this.reseau);
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x00053F1C File Offset: 0x00052F1C
		public override Port nouveauPort8021q()
		{
			return new Port8021qSwitch(this.reseau);
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x00053F34 File Offset: 0x00052F34
		protected override void InterConn_TrameTransmise(ElementReseau sender, TrameEventArgs e)
		{
			if (e.Cible == this)
			{
				this.senderEnCours = sender;
				this.trameEnCours = e;
				this.afficherTampon1();
				if (this.reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.circulationTrame && base.trace())
				{
					this.demo = new DemoSwitch(this.reseau);
					this.demo.TitreDialogue = base.NomNoeud;
					this.demo.DemoTerminee += this.Switch_DemoTerminee;
					this.demo.DemarrerDemo(sender, this, e.Trame, this.reseau.TypeDemo);
					return;
				}
				this.receptionTrameNoDemo();
			}
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x00053FD4 File Offset: 0x00052FD4
		public override Point posDialogueDemo()
		{
			if (this.posDemo == new Point(0, 0))
			{
				int x = this.reseau.Location.X + this.reseau.Schema.Location.X + base.Location.X + 5;
				int y = this.reseau.Location.Y + this.reseau.Schema.Location.Y + base.Location.Y + this.reseau.Pref.HauteurOutils + 7;
				return new Point(x, y);
			}
			return this.posDemo;
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x00054094 File Offset: 0x00053094
		private void Switch_DemoTerminee(object sender, EventArgs e)
		{
			if (this.demo != null)
			{
				this.demo.DemoTerminee -= this.Switch_DemoTerminee;
				this.demo = null;
			}
			this.suiteReceptionTrame(null, null);
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x000540D0 File Offset: 0x000530D0
		private void receptionTrameNoDemo()
		{
			this.delaiTransmissionTrame.Tick += this.FinDelaiTransmissionTrameNoDemo;
			this.delaiTransmissionTrame.Start();
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x00054100 File Offset: 0x00053100
		public void FinDelaiTransmissionTrameNoDemo(object sender, EventArgs e)
		{
			this.delaiTransmissionTrame.Stop();
			this.delaiTransmissionTrame.Tick -= this.FinDelaiTransmissionTrameNoDemo;
			this.suiteReceptionTrame(null, null);
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x060008C7 RID: 2247 RVA: 0x00054138 File Offset: 0x00053138
		// (set) Token: 0x060008C8 RID: 2248 RVA: 0x0005414C File Offset: 0x0005314C
		public SortedList PortAdresseMac
		{
			get
			{
				return this.portAdresseMac;
			}
			set
			{
				this.portAdresseMac = value;
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060008C9 RID: 2249 RVA: 0x00054160 File Offset: 0x00053160
		// (set) Token: 0x060008CA RID: 2250 RVA: 0x00054174 File Offset: 0x00053174
		public SortedList PortVlanNiv1
		{
			get
			{
				return this.portVlanNiv1;
			}
			set
			{
				this.portVlanNiv1 = value;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x060008CB RID: 2251 RVA: 0x00054188 File Offset: 0x00053188
		// (set) Token: 0x060008CC RID: 2252 RVA: 0x0005419C File Offset: 0x0005319C
		public SortedList MacVlanNiv2
		{
			get
			{
				return this.macVlanNiv2;
			}
			set
			{
				this.macVlanNiv2 = value;
			}
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x000541B0 File Offset: 0x000531B0
		public static void AjouterTableMacPort(SortedList table, string adrMac, PortSwitch port)
		{
			table[adrMac] = new ArrayList();
			((ArrayList)table[adrMac]).Add(adrMac);
			((ArrayList)table[adrMac]).Add(port);
			((ArrayList)table[adrMac]).Add(Switch.TtlSwitch.Maximum);
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x00054208 File Offset: 0x00053208
		public static void AjouterTablePortVlan(SortedList table, int port, string vlan)
		{
			string text = PortVlanEdit.numPortFormat(port);
			table[text] = new ArrayList();
			((ArrayList)table[text]).Add(text);
			((ArrayList)table[text]).Add(vlan);
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x00054250 File Offset: 0x00053250
		protected override void mi_eteindre_Click(object sender, EventArgs e)
		{
			base.mi_eteindre_Click(sender, e);
			this.portAdresseMac = new SortedList();
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x00054270 File Offset: 0x00053270
		private void marquerTrameVlan(PortSwitch portEmetteur, TrameEthernet t, int niveauVlan)
		{
			if (niveauVlan == 1)
			{
				if (portEmetteur.GetType() != typeof(Port8021qSwitch))
				{
					t.Vlan = int.Parse(((ArrayList)this.portVlanNiv1[PortVlanEdit.numPortFormat(portEmetteur.NumeroOrdre)])[1].ToString());
					return;
				}
			}
			else if (portEmetteur.GetType() != typeof(Port8021qSwitch))
			{
				if (this.macVlanNiv2.ContainsKey(t.MacEmetteur))
				{
					t.Vlan = int.Parse(((ArrayList)this.macVlanNiv2[t.MacEmetteur])[1].ToString());
					return;
				}
				t.Vlan = 1;
			}
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x00054324 File Offset: 0x00053324
		private void majTablePortVlan(PortSwitch portEmetteur, int vlan)
		{
			if (((ArrayList)this.portVlanNiv1[PortVlanEdit.numPortFormat(portEmetteur.NumeroOrdre)])[1].ToString() != vlan.ToString())
			{
				((ArrayList)this.portVlanNiv1[PortVlanEdit.numPortFormat(portEmetteur.NumeroOrdre)])[1] = vlan.ToString();
				this.reseau.GereDoc.FaireAction(ActionDocument.modifier);
			}
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x000543A0 File Offset: 0x000533A0
		private int vlanMacNiv2(string mac)
		{
			if (mac == null)
			{
				return -1;
			}
			if (this.macVlanNiv2.ContainsKey(mac))
			{
				return int.Parse(((ArrayList)this.macVlanNiv2[mac])[1].ToString());
			}
			return -1;
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x000543E4 File Offset: 0x000533E4
		public void suiteReceptionTrame(object sender, EventArgs e)
		{
			this.nbCablesTrameTransmise = 0;
			this.nbCablesTrameAchevee = 0;
			PortSwitch portSwitch = (PortSwitch)this.senderEnCours;
			this.senderEnCours = null;
			this.majTableMacPort(portSwitch, this.trameEnCours.Trame.MacEmetteur);
			bool ports8021q = false;
			bool portsDuVlan = false;
			if (this.niveauVlan != 0)
			{
				this.marquerTrameVlan(portSwitch, this.trameEnCours.Trame, this.niveauVlan);
				if (this.niveauVlan == 2)
				{
					if (portSwitch.GetType() != typeof(Port8021qSwitch))
					{
						this.majTablePortVlan(portSwitch, this.trameEnCours.Trame.Vlan);
					}
					if (this.macVlanNiv2.ContainsKey(this.trameEnCours.Trame.MacDestinataire))
					{
						ports8021q = false;
						portsDuVlan = true;
					}
					else if (this.trameEnCours.Trame.Vlan == 1)
					{
						ports8021q = true;
						portsDuVlan = true;
					}
					else
					{
						ports8021q = true;
						portsDuVlan = false;
					}
				}
			}
			if (this.trameEnCours.Trame.MacDestinataire == this.reseau.Pref.AdrMacBroadcast)
			{
				this.reemettreSurLesAutresPorts(portSwitch, true, true);
			}
			else
			{
				bool flag = true;
				if (this.niveauVlan == 2)
				{
					int num = this.vlanMacNiv2(this.trameEnCours.Trame.MacDestinataire);
					flag = (num == -1 || num == this.trameEnCours.Trame.Vlan);
				}
				if (flag)
				{
					if (this.portAdresseMac[this.trameEnCours.Trame.MacDestinataire] == null)
					{
						this.reemettreSurLesAutresPorts(portSwitch, portsDuVlan, ports8021q);
					}
					else
					{
						PortSwitch portSwitch2 = (PortSwitch)((ArrayList)this.portAdresseMac[this.trameEnCours.Trame.MacDestinataire])[1];
						if (this.niveauVlan == 1)
						{
							int num2 = portSwitch2.Vlan(this.portVlanNiv1);
							flag = (num2 == -1 || num2 == this.trameEnCours.Trame.Vlan);
						}
						if (flag && portSwitch2 != portSwitch && portSwitch2.EtatConnexion == PointConnexion.EtatsConnexion.actif)
						{
							this.reemettre(portSwitch2, portsDuVlan, ports8021q);
						}
					}
				}
			}
			base.receptionnerTrame(this.trameEnCours.Trame);
			this.trameEnCours = null;
			if (this.nbCablesTrameTransmise == 0)
			{
				this.effacerTampon1();
			}
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x0005460C File Offset: 0x0005360C
		private void majTableMacPort(PortSwitch portEmetteur, string macEmetteur)
		{
			Switch.AjouterTableMacPort(this.portAdresseMac, macEmetteur, portEmetteur);
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.portAdresseMac.Values)
			{
				ArrayList arrayList2 = (ArrayList)obj;
				Switch.TtlSwitch ttlSwitch = (Switch.TtlSwitch)arrayList2[2];
				if (ttlSwitch == Switch.TtlSwitch.Nul)
				{
					arrayList.Add(arrayList2[0]);
				}
				else
				{
					ttlSwitch--;
					arrayList2[2] = ttlSwitch;
				}
			}
			foreach (object obj2 in arrayList)
			{
				string key = (string)obj2;
				this.portAdresseMac.Remove(key);
			}
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x00054718 File Offset: 0x00053718
		private void reemettre(PortSwitch p, bool portsDuVlan, bool ports8021q)
		{
			switch (this.niveauVlan)
			{
			case 0:
				this.reemettreTrame(p);
				return;
			case 1:
			{
				int num = p.Vlan(this.portVlanNiv1);
				if (num == -1)
				{
					this.reemettreTrame(p);
					return;
				}
				if (num == this.trameEnCours.Trame.Vlan)
				{
					this.reemettreTrame(p);
					return;
				}
				break;
			}
			case 2:
			{
				int num = p.Vlan(this.portVlanNiv1);
				if (num == -1)
				{
					if (ports8021q)
					{
						this.reemettreTrame(p);
						return;
					}
				}
				else if (portsDuVlan && num == this.trameEnCours.Trame.Vlan)
				{
					this.reemettreTrame(p);
				}
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x000547B4 File Offset: 0x000537B4
		private void reemettreTrame(PortSwitch p)
		{
			TrameEthernet trameEthernet = new TrameEthernet(this.trameEnCours.Trame.NumeroTrame, this.trameEnCours.Trame.Vlan, this.trameEnCours.Trame.CarteEmetteur, this.trameEnCours.Trame.MacEmetteur, this.trameEnCours.Trame.MacDestinataire, this.trameEnCours.Trame.Info, this.reseau);
			trameEthernet.Marque8021q = (p.GetType() == typeof(Port8021qSwitch));
			trameEthernet.IncrementerNbTransmissions();
			base.transmettreTrame(trameEthernet, p.Lien);
			this.nbCablesTrameTransmise++;
			p.Lien.TrameTransmise += this.lien_TrameTransmise;
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x00054880 File Offset: 0x00053880
		private void lien_TrameTransmise(ElementReseau elt, TrameEventArgs e)
		{
			elt.TrameTransmise -= this.lien_TrameTransmise;
			this.nbCablesTrameAchevee++;
			if (this.nbCablesTrameAchevee == this.nbCablesTrameTransmise)
			{
				this.effacerTampon1();
			}
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x000548C4 File Offset: 0x000538C4
		private void reemettreSurLesAutresPorts(PortSwitch portEmetteur, bool portsDuVlan, bool ports8021q)
		{
			foreach (object obj in base.Controls)
			{
				PortSwitch portSwitch = (PortSwitch)obj;
				if (portSwitch.EtatConnexion == PointConnexion.EtatsConnexion.actif && portSwitch != portEmetteur)
				{
					this.reemettre(portSwitch, portsDuVlan, ports8021q);
				}
			}
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x00054938 File Offset: 0x00053938
		private void mi_tableMacPort_Click(object sender, EventArgs e)
		{
			DialogueMacPort dialogueMacPort = new DialogueMacPort("Table mac/port switch " + this.nomNoeud, this);
			dialogueMacPort.Size = new Size(DialogueMacPort.Largeur, this.hauteurTableMacPort);
			dialogueMacPort.InScreen();
			dialogueMacPort.Show();
			this.reseau.OkBis = false;
			this.reseau.PreparerBis();
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x060008DA RID: 2266 RVA: 0x00054998 File Offset: 0x00053998
		// (set) Token: 0x060008DB RID: 2267 RVA: 0x000549AC File Offset: 0x000539AC
		public Switch.TypeDeSwitch TypeSwitch
		{
			get
			{
				return this.typeSwitch;
			}
			set
			{
				this.typeSwitch = value;
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x060008DC RID: 2268 RVA: 0x000549C0 File Offset: 0x000539C0
		// (set) Token: 0x060008DD RID: 2269 RVA: 0x000549D4 File Offset: 0x000539D4
		public bool SpanningTree
		{
			get
			{
				return this.spanningTree;
			}
			set
			{
				this.spanningTree = value;
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x060008DE RID: 2270 RVA: 0x000549E8 File Offset: 0x000539E8
		// (set) Token: 0x060008DF RID: 2271 RVA: 0x000549FC File Offset: 0x000539FC
		public int NiveauVlan
		{
			get
			{
				return this.niveauVlan;
			}
			set
			{
				this.niveauVlan = value;
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x060008E0 RID: 2272 RVA: 0x00054A10 File Offset: 0x00053A10
		public RamSwitch Ram
		{
			get
			{
				return this.ram;
			}
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x00054A24 File Offset: 0x00053A24
		protected override void InterConn_DebutTrameTransmis(ElementReseau sender, TrameEventArgs e)
		{
			if (e.Cible == this)
			{
				if (this.reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.trameReelle)
				{
					BufferTrame bufferTrame = this.ram.BufferLibre();
					bufferTrame.init((PortSwitch)sender, e, this);
					e.Trame.IncrementerNbTransmissions();
					this.RemplirTampon(e.Trame.NumeroTrame);
					if (this.ram.numeroBuffer(bufferTrame) == 0)
					{
						this.delaiTransmissionDebutTrame0.Tick += this.FinDelaiTransmissionDebutTrameNoDemoDeuxTramesB0;
						this.delaiTransmissionDebutTrame0.Start();
						return;
					}
					this.delaiTransmissionDebutTrame1.Tick += this.FinDelaiTransmissionDebutTrameNoDemoDeuxTramesB1;
					this.delaiTransmissionDebutTrame1.Start();
					return;
				}
				else
				{
					this.tramesRetransmises = new Hashtable();
					if (this.trameEnCours == null)
					{
						this.senderEnCours = sender;
						this.trameEnCours = e;
						e.Trame.IncrementerNbTransmissions();
						this.RemplirTampon(e.Trame.NumeroTrame);
						this.delaiTransmissionTrame.Tick += this.FinDelaiTransmissionDebutTrameNoDemo;
						this.delaiTransmissionTrame.Start();
					}
				}
			}
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x00054B38 File Offset: 0x00053B38
		public void FinDelaiTransmissionDebutTrameNoDemoDeuxTramesB0(object sender, EventArgs e)
		{
			BufferTrame buffer = this.ram.getBuffer(0);
			this.delaiTransmissionDebutTrame0.Stop();
			this.delaiTransmissionDebutTrame0.Tick -= this.FinDelaiTransmissionDebutTrameNoDemoDeuxTramesB0;
			this.suiteReceptionDebutTrameDeuxTrames(buffer);
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x00054B7C File Offset: 0x00053B7C
		public void FinDelaiTransmissionDebutTrameNoDemoDeuxTramesB1(object sender, EventArgs e)
		{
			BufferTrame buffer = this.ram.getBuffer(1);
			this.delaiTransmissionDebutTrame1.Stop();
			this.delaiTransmissionDebutTrame1.Tick -= this.FinDelaiTransmissionDebutTrameNoDemoDeuxTramesB1;
			this.suiteReceptionDebutTrameDeuxTrames(buffer);
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x00054BC0 File Offset: 0x00053BC0
		private int nbPortsActifs()
		{
			int num = 0;
			foreach (object obj in base.Controls)
			{
				Port port = (Port)obj;
				if (port.EtatConnexion == PointConnexion.EtatsConnexion.actif)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x00054C30 File Offset: 0x00053C30
		public void suiteReceptionDebutTrameDeuxTrames(BufferTrame buffer)
		{
			this.majTableMacPort(buffer.PortEmetteur, buffer.Trame.MacEmetteur);
			bool ports8021q = true;
			bool portsDuVlan = true;
			if (this.niveauVlan != 0)
			{
				this.marquerTrameVlan(buffer.PortEmetteur, buffer.Trame, this.niveauVlan);
				if (this.niveauVlan == 2)
				{
					if (buffer.PortEmetteur.GetType() != typeof(Port8021qSwitch))
					{
						this.majTablePortVlan(buffer.PortEmetteur, buffer.Trame.Vlan);
					}
					if (this.macVlanNiv2.ContainsKey(buffer.Trame.MacDestinataire))
					{
						ports8021q = false;
						portsDuVlan = true;
					}
					else if (buffer.Trame.Vlan == 1)
					{
						ports8021q = true;
						portsDuVlan = true;
					}
					else
					{
						ports8021q = true;
						portsDuVlan = false;
					}
				}
			}
			if (buffer.Trame.MacDestinataire == this.reseau.Pref.AdrMacBroadcast)
			{
				this.reemettreDebutTrameSurLesAutresPortsDeuxTrames(buffer, true, true);
				buffer.NbTramesATransmettre = this.nbPortsConcernes(buffer, true, true);
			}
			else
			{
				bool flag = true;
				if (this.niveauVlan == 2)
				{
					int num = this.vlanMacNiv2(buffer.Trame.MacDestinataire);
					flag = (num == -1 || num == buffer.Trame.Vlan);
				}
				if (flag)
				{
					if (this.portAdresseMac[buffer.Trame.MacDestinataire] == null)
					{
						this.reemettreDebutTrameSurLesAutresPortsDeuxTrames(buffer, portsDuVlan, ports8021q);
						buffer.NbTramesATransmettre = this.nbPortsConcernes(buffer, portsDuVlan, ports8021q);
					}
					else
					{
						PortSwitch portSwitch = (PortSwitch)((ArrayList)this.portAdresseMac[buffer.Trame.MacDestinataire])[1];
						if (this.niveauVlan == 1)
						{
							int num2 = portSwitch.Vlan(this.portVlanNiv1);
							flag = (num2 == -1 || num2 == buffer.Trame.Vlan);
						}
						if (flag && portSwitch != buffer.PortEmetteur && portSwitch.EtatConnexion == PointConnexion.EtatsConnexion.actif)
						{
							this.reemettreDebutTrameDeuxTrames(buffer, portSwitch, portsDuVlan, ports8021q);
							buffer.NbTramesATransmettre = 1;
						}
						else
						{
							buffer.NbTramesATransmettre = 0;
						}
					}
				}
			}
			buffer.ReemettreDebutTrame();
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00054E28 File Offset: 0x00053E28
		private int nbPortsConcernes(BufferTrame buffer, bool portsDuVlan, bool ports8021q)
		{
			int num = 0;
			int vlan;
			switch (this.niveauVlan)
			{
			case 0:
			{
				if (buffer.Trame.MacDestinataire == this.reseau.Pref.AdrMacBroadcast)
				{
					return this.nbPortsActifs() - 1;
				}
				if (this.portAdresseMac[buffer.Trame.MacDestinataire] == null)
				{
					return this.nbPortsActifs() - 1;
				}
				PortSwitch portSwitch = (PortSwitch)((ArrayList)this.portAdresseMac[buffer.Trame.MacDestinataire])[1];
				if (portSwitch != buffer.PortEmetteur && portSwitch.EtatConnexion == PointConnexion.EtatsConnexion.actif)
				{
					return 1;
				}
				return 0;
			}
			case 1:
				num = 0;
				vlan = buffer.Trame.Vlan;
				using (IEnumerator enumerator = base.Controls.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						PortSwitch portSwitch2 = (PortSwitch)obj;
						if (portSwitch2 != buffer.PortEmetteur && portSwitch2.EtatConnexion == PointConnexion.EtatsConnexion.actif)
						{
							int num2 = portSwitch2.Vlan(this.portVlanNiv1);
							if (num2 == -1 && ports8021q)
							{
								num++;
							}
							if (num2 == vlan && portsDuVlan)
							{
								num++;
							}
						}
					}
					return num;
				}
				break;
			case 2:
				break;
			default:
				return num;
			}
			num = 0;
			vlan = buffer.Trame.Vlan;
			foreach (object obj2 in base.Controls)
			{
				PortSwitch portSwitch3 = (PortSwitch)obj2;
				if (portSwitch3 != buffer.PortEmetteur && portSwitch3.EtatConnexion == PointConnexion.EtatsConnexion.actif)
				{
					int num2 = portSwitch3.Vlan(this.portVlanNiv1);
					if (num2 == -1 && ports8021q)
					{
						num++;
					}
					if (num2 == vlan && portsDuVlan)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x00055034 File Offset: 0x00054034
		public void FinDelaiTransmissionDebutTrameNoDemo(object sender, EventArgs e)
		{
			this.delaiTransmissionTrame.Stop();
			this.delaiTransmissionTrame.Tick -= this.FinDelaiTransmissionDebutTrameNoDemo;
			this.suiteReceptionDebutTrame(null, null);
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x0005506C File Offset: 0x0005406C
		public void suiteReceptionDebutTrame(object sender, EventArgs e)
		{
			PortSwitch portSwitch = (PortSwitch)this.senderEnCours;
			this.senderEnCours = null;
			this.majTableMacPort(portSwitch, this.trameEnCours.Trame.MacEmetteur);
			if (this.trameEnCours.Trame.MacDestinataire == this.reseau.Pref.AdrMacBroadcast)
			{
				this.reemettreDebutTrameSurLesAutresPorts(portSwitch);
				return;
			}
			if (this.portAdresseMac[this.trameEnCours.Trame.MacDestinataire] == null)
			{
				this.reemettreDebutTrameSurLesAutresPorts(portSwitch);
				return;
			}
			PortSwitch portSwitch2 = (PortSwitch)((ArrayList)this.portAdresseMac[this.trameEnCours.Trame.MacDestinataire])[1];
			if (portSwitch2 != portSwitch && portSwitch2.EtatConnexion == PointConnexion.EtatsConnexion.actif)
			{
				this.reemettreDebutTrame(portSwitch2);
			}
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x00055138 File Offset: 0x00054138
		private void suiteReemettreDebutTrameDeuxTrames(BufferTrame buffer, int vlan, PortSwitch p)
		{
			TrameEthernet trameEthernet = new TrameEthernet(buffer.Trame.NumeroTrame, vlan, buffer.Trame.CarteEmetteur, buffer.Trame.MacEmetteur, buffer.Trame.MacDestinataire, buffer.Trame.Info, this.reseau);
			trameEthernet.TailleTrame = buffer.Trame.TailleTrame;
			trameEthernet.Marque8021q = (p.GetType() == typeof(Port8021qSwitch));
			if (this.reseau.SimulationEthernet != Simulation.TypeDeSimulationEthernet.trameReelle)
			{
				trameEthernet.IncrementerNbTransmissions();
			}
			buffer.TramesRetransmises[p] = trameEthernet;
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x000551D4 File Offset: 0x000541D4
		private void reemettreDebutTrameDeuxTrames(BufferTrame buffer, PortSwitch p, bool portsDuVlan, bool ports8021q)
		{
			switch (this.niveauVlan)
			{
			case 0:
				this.suiteReemettreDebutTrameDeuxTrames(buffer, 0, p);
				return;
			case 1:
			{
				int num = p.Vlan(this.portVlanNiv1);
				if (num == -1)
				{
					this.suiteReemettreDebutTrameDeuxTrames(buffer, buffer.Trame.Vlan, p);
					return;
				}
				if (num == buffer.Trame.Vlan)
				{
					this.suiteReemettreDebutTrameDeuxTrames(buffer, buffer.Trame.Vlan, p);
					return;
				}
				break;
			}
			case 2:
			{
				int num = p.Vlan(this.portVlanNiv1);
				if (num == -1)
				{
					if (ports8021q)
					{
						this.suiteReemettreDebutTrameDeuxTrames(buffer, buffer.Trame.Vlan, p);
						return;
					}
				}
				else if (portsDuVlan && num == buffer.Trame.Vlan)
				{
					this.suiteReemettreDebutTrameDeuxTrames(buffer, buffer.Trame.Vlan, p);
				}
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x0005529C File Offset: 0x0005429C
		public void retransmettreDebutTrameDeuxTrames(TrameEthernet trame, Cable c)
		{
			base.transmettreDebutTrame(trame, c);
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x000552B4 File Offset: 0x000542B4
		public void retransmettreFinTrameDeuxTrames(TrameEthernet trame, Cable c)
		{
			base.transmettreFinTrame(trame, c);
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x000552CC File Offset: 0x000542CC
		public void ReceptionnerTrameDeuxTrames(TrameEthernet trame)
		{
			base.receptionnerFinTrame(trame, "swA");
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x000552E8 File Offset: 0x000542E8
		private void reemettreDebutTrameSurLesAutresPortsDeuxTrames(BufferTrame buffer, bool portsDuVlan, bool ports8021q)
		{
			foreach (object obj in base.Controls)
			{
				PortSwitch portSwitch = (PortSwitch)obj;
				if (portSwitch.EtatConnexion == PointConnexion.EtatsConnexion.actif && portSwitch != buffer.PortEmetteur)
				{
					this.reemettreDebutTrameDeuxTrames(buffer, portSwitch, portsDuVlan, ports8021q);
				}
			}
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x00055364 File Offset: 0x00054364
		private void reemettreDebutTrame(PortSwitch p)
		{
			TrameEthernet trameEthernet = new TrameEthernet(this.trameEnCours.Trame.NumeroTrame, 0, this.trameEnCours.Trame.CarteEmetteur, this.trameEnCours.Trame.MacEmetteur, this.trameEnCours.Trame.MacDestinataire, this.trameEnCours.Trame.Info, this.reseau);
			trameEthernet.TailleTrame = this.trameEnCours.Trame.TailleTrame;
			trameEthernet.IncrementerNbTransmissions();
			if (this.typeSwitch == Switch.TypeDeSwitch.onTheFly)
			{
				base.transmettreDebutTrame(trameEthernet, p.Lien);
			}
			this.tramesRetransmises[p] = trameEthernet;
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x0005540C File Offset: 0x0005440C
		private void reemettreDebutTrameSurLesAutresPorts(PortSwitch portEmetteur)
		{
			foreach (object obj in base.Controls)
			{
				PortSwitch portSwitch = (PortSwitch)obj;
				if (portSwitch.EtatConnexion == PointConnexion.EtatsConnexion.actif && portSwitch != portEmetteur)
				{
					this.reemettreDebutTrame(portSwitch);
				}
			}
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x00055480 File Offset: 0x00054480
		protected override void InterConn_FinTrameTransmis(ElementReseau sender, TrameEventArgs e)
		{
			if (e.Cible == this)
			{
				if (this.reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.trameReelle)
				{
					BufferTrame bufferTrame = this.ram.getBufferTrame(e.Trame.NumeroTrame);
					if (this.ram.numeroBuffer(bufferTrame) == 0)
					{
						this.DelaiTransmissionFinTrame0.Tick += this.FinDelaiTransmissionFinTrameNoDemoDeuxTramesB0;
						this.delaiTransmissionFinTrame0.Start();
						return;
					}
					this.delaiTransmissionFinTrame1.Tick += this.FinDelaiTransmissionFinTrameNoDemoDeuxTramesB1;
					this.delaiTransmissionFinTrame1.Start();
					return;
				}
				else
				{
					this.senderEnCours = sender;
					this.delaiTransmissionTrame.Tick += this.FinDelaiTransmissionFinTrameNoDemo;
					this.delaiTransmissionTrame.Start();
				}
			}
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x0005553C File Offset: 0x0005453C
		public void FinDelaiTransmissionFinTrameNoDemo(object sender, EventArgs e)
		{
			this.delaiTransmissionTrame.Stop();
			this.delaiTransmissionTrame.Tick -= this.FinDelaiTransmissionFinTrameNoDemo;
			this.suiteReceptionFinTrame(null, null);
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x00055574 File Offset: 0x00054574
		public void FinDelaiTransmissionFinTrameNoDemoDeuxTramesB0(object sender, EventArgs e)
		{
			BufferTrame buffer = this.ram.getBuffer(0);
			this.delaiTransmissionFinTrame0.Stop();
			this.delaiTransmissionFinTrame0.Tick -= this.FinDelaiTransmissionFinTrameNoDemoDeuxTramesB0;
			this.suiteReceptionFinTrameDeuxTrames(buffer);
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x000555B8 File Offset: 0x000545B8
		public void FinDelaiTransmissionFinTrameNoDemoDeuxTramesB1(object sender, EventArgs e)
		{
			BufferTrame buffer = this.ram.getBuffer(1);
			this.delaiTransmissionFinTrame1.Stop();
			this.delaiTransmissionFinTrame1.Tick -= this.FinDelaiTransmissionFinTrameNoDemoDeuxTramesB1;
			this.suiteReceptionFinTrameDeuxTrames(buffer);
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x060008F5 RID: 2293 RVA: 0x000555FC File Offset: 0x000545FC
		public Timer DelaiReemissionTrameComplete
		{
			get
			{
				return this.delaiReemissionTrameComplete;
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x060008F6 RID: 2294 RVA: 0x00055610 File Offset: 0x00054610
		public Timer DelaiReemissionTrameComplete1
		{
			get
			{
				return this.delaiReemissionTrameComplete1;
			}
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x00055624 File Offset: 0x00054624
		private void suiteReceptionFinTrameDeuxTrames(BufferTrame buffer)
		{
			if (buffer.NbTramesATransmettre == 0)
			{
				buffer.SuiteReemissionTermineTransmis();
				return;
			}
			buffer.ReemettreFinTrame();
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x00055648 File Offset: 0x00054648
		private void suiteReceptionFinTrame(object sender, EventArgs e)
		{
			if (this.typeSwitch == Switch.TypeDeSwitch.onTheFly)
			{
				this.senderEnCours = null;
				foreach (object obj in this.tramesRetransmises.Keys)
				{
					PortSwitch portSwitch = (PortSwitch)obj;
					base.transmettreFinTrame((TrameEthernet)this.tramesRetransmises[portSwitch], portSwitch.Lien);
				}
				this.ViderTampon(this.trameEnCours.Trame.NumeroTrame);
				if (this.reseau.SimulationEthernet != Simulation.TypeDeSimulationEthernet.trameReelle)
				{
					base.receptionnerFinTrame(this.trameEnCours.Trame, "swB");
				}
				this.trameEnCours = null;
				return;
			}
			this.ArreterTampon(this.trameEnCours.Trame.NumeroTrame);
			foreach (object obj2 in this.tramesRetransmises.Keys)
			{
				PortSwitch portSwitch2 = (PortSwitch)obj2;
				base.transmettreDebutTrame((TrameEthernet)this.tramesRetransmises[portSwitch2], portSwitch2.Lien);
			}
			if (this.tramesRetransmises.Count == 0)
			{
				this.delaiReemissionTrameComplete.Interval = 1;
			}
			else
			{
				this.delaiReemissionTrameComplete.Interval = this.trameEnCours.Trame.TempsEmission();
			}
			this.delaiReemissionTrameComplete.Tick += this.finDelaiReemissionTrameComplete;
			this.delaiReemissionTrameComplete.Start();
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x000557FC File Offset: 0x000547FC
		private void finDelaiReemissionTrameComplete(object sender, EventArgs e)
		{
			this.delaiReemissionTrameComplete.Stop();
			this.delaiReemissionTrameComplete.Tick -= this.finDelaiReemissionTrameComplete;
			this.senderEnCours = null;
			foreach (object obj in this.tramesRetransmises.Keys)
			{
				PortSwitch portSwitch = (PortSwitch)obj;
				base.transmettreFinTrame((TrameEthernet)this.tramesRetransmises[portSwitch], portSwitch.Lien);
			}
			if (this.reseau.SimulationEthernet != Simulation.TypeDeSimulationEthernet.trameReelle)
			{
				base.receptionnerFinTrame(this.trameEnCours.Trame, "swC");
			}
			this.ViderTampon(this.trameEnCours.Trame.NumeroTrame);
			this.trameEnCours = null;
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x000558E8 File Offset: 0x000548E8
		public void DebloquerPorts()
		{
			foreach (object obj in base.Controls)
			{
				PortSwitch portSwitch = (PortSwitch)obj;
				if (portSwitch.EtatConnexion == PointConnexion.EtatsConnexion.bloqué)
				{
					if (portSwitch.Lien.Oppose(portSwitch).EtatConnexion == PointConnexion.EtatsConnexion.allumé)
					{
						portSwitch.changerEtat(PointConnexion.EtatsConnexion.actif);
						portSwitch.Lien.Oppose(portSwitch).changerEtat(PointConnexion.EtatsConnexion.actif);
					}
					else
					{
						portSwitch.changerEtat(PointConnexion.EtatsConnexion.allumé);
					}
				}
			}
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x00055988 File Offset: 0x00054988
		public override void Allumer()
		{
			foreach (object obj in base.Controls)
			{
				PortSwitch portSwitch = (PortSwitch)obj;
				if (portSwitch.BloqueManuel)
				{
					portSwitch.Bloquer();
				}
			}
			base.Allumer();
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x000559FC File Offset: 0x000549FC
		private void mi_voirConfig_Click(object sender, EventArgs e)
		{
			ConfigSwitch configSwitch = new ConfigSwitch(this, true);
			configSwitch.Text = "Configuration d'un Switch";
			if (base.ConfigurerGraphique(configSwitch))
			{
				this.typeSwitch = configSwitch.TypeSwitch;
				this.spanningTree = configSwitch.SpanningTree;
				this.reseau.OkBis = false;
				this.reseau.PreparerBis();
				this.SetContenuInfoBulle();
			}
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x00055A5C File Offset: 0x00054A5C
		protected override void Interconnexion_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.DrawRectangle(this.stylo, 0, 0, base.Width - 1, base.Height - 1);
			graphics.FillRectangle(this.couleurTampon[0], 1, 1, this.posTampon[0], 2);
			graphics.FillRectangle(this.couleurTampon[1], this.debutTampon[1], 1, this.posTampon[1], 2);
			graphics.DrawRectangle(this.stylo, 0, 0, base.Width - 1, 3);
			graphics.DrawLine(this.stylo, base.Width / 2 - 1, 0, base.Width / 2 - 1, 3);
			graphics.DrawString(this.etiquette + this.nomNoeud, this.police, this.stylo.Brush, 1f, 4f);
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x00055B34 File Offset: 0x00054B34
		private void afficherTampon1()
		{
			this.couleurTampon[0] = this.reseau.Pref.CableActifStylo1.Brush;
			this.debutTampon[0] = 1;
			this.limiteTampon[0] = base.Width / 2 - 2;
			this.posTampon[0] = this.limiteTampon[0];
			this.gTampon = base.CreateGraphics();
			this.gTampon.FillRectangle(this.couleurTampon[0], this.debutTampon[0] + this.posTampon[0] - 1, 1, 1, 2);
			base.Invalidate(new Rectangle(0, 0, base.Width - 1, 3));
			this.gTampon.Dispose();
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x00055BE0 File Offset: 0x00054BE0
		private void effacerTampon1()
		{
			this.posTampon[0] = 0;
			this.numTrameTampon[0] = 0;
			base.Invalidate(new Rectangle(0, 0, base.Width - 1, 3));
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000900 RID: 2304 RVA: 0x00055C18 File Offset: 0x00054C18
		// (set) Token: 0x06000901 RID: 2305 RVA: 0x00055C2C File Offset: 0x00054C2C
		public static Timer TimerTampon
		{
			get
			{
				return Switch.timerTampon;
			}
			set
			{
				Switch.timerTampon = value;
			}
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x00055C40 File Offset: 0x00054C40
		private void initTampons()
		{
			this.debutTampon[0] = 1;
			this.debutTampon[1] = base.Width / 2;
			this.limiteTampon[0] = base.Width / 2 - 2;
			if (Math.IEEERemainder((double)base.Width, 2.0) == 0.0)
			{
				this.limiteTampon[1] = base.Width / 2 - 1;
				return;
			}
			this.limiteTampon[1] = base.Width / 2;
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x00055CBC File Offset: 0x00054CBC
		public void RemplirTampon(int numTrame)
		{
			int num;
			if (this.numTrameTampon[0] == 0)
			{
				num = 0;
			}
			else
			{
				num = 1;
			}
			if (this.gTampon != null)
			{
				this.gTampon.Dispose();
			}
			this.gTampon = base.CreateGraphics();
			this.initTampons();
			this.numTrameTampon[num] = numTrame;
			if (numTrame == 1)
			{
				this.couleurTampon[num] = this.reseau.Pref.CableActifStylo1.Brush;
			}
			else
			{
				this.couleurTampon[num] = this.reseau.Pref.CableActifStylo2.Brush;
			}
			this.posTampon[num] = 1;
			base.Invalidate(new Rectangle(0, 0, base.Width - 1, 3));
			if (num == 0)
			{
				Switch.timerTampon.Tick += this.avancerTampon0;
				return;
			}
			Switch.timerTampon.Tick += this.avancerTampon1;
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x00055D98 File Offset: 0x00054D98
		private void avancerTampon0(object sender, EventArgs e)
		{
			this.avancerTampon(0);
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x00055DAC File Offset: 0x00054DAC
		private void avancerTampon1(object sender, EventArgs e)
		{
			this.avancerTampon(1);
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x00055DC0 File Offset: 0x00054DC0
		public void ArreterTampon(int numTrame)
		{
			if (numTrame == this.numTrameTampon[0])
			{
				Switch.timerTampon.Tick -= this.avancerTampon0;
				return;
			}
			Switch.timerTampon.Tick -= this.avancerTampon1;
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x00055E08 File Offset: 0x00054E08
		private void avancerTampon(int numTampon)
		{
			this.tamponSuivant[numTampon] = this.posTampon[numTampon] + 1;
			if (this.tamponSuivant[numTampon] > this.limiteTampon[numTampon])
			{
				this.tamponSuivant[numTampon] = this.limiteTampon[numTampon];
				if (numTampon == 0)
				{
					Switch.timerTampon.Tick -= this.avancerTampon0;
				}
				else
				{
					Switch.timerTampon.Tick -= this.avancerTampon1;
				}
				this.gTampon.FillRectangle(this.couleurTampon[numTampon], this.debutTampon[numTampon] + this.posTampon[numTampon] - 1, 1, 1, 2);
				base.Invalidate(new Rectangle(0, 0, base.Width - 1, 3));
			}
			else
			{
				this.gTampon.FillRectangle(this.couleurTampon[numTampon], this.debutTampon[numTampon] + this.posTampon[numTampon] - 1, 1, 1, 2);
			}
			this.posTampon[numTampon] = this.tamponSuivant[numTampon];
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x00055EF8 File Offset: 0x00054EF8
		public void ViderTampon(int numTrame)
		{
			if (numTrame == this.numTrameTampon[0])
			{
				Switch.timerTampon.Tick -= this.avancerTampon0;
				this.posTampon[0] = 0;
				this.numTrameTampon[0] = 0;
			}
			else
			{
				Switch.timerTampon.Tick -= this.avancerTampon1;
				this.posTampon[1] = 0;
				this.numTrameTampon[1] = 0;
			}
			base.Invalidate(new Rectangle(0, 0, base.Width - 1, 3));
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x00055F78 File Offset: 0x00054F78
		public void StopperTampons()
		{
			Switch.timerTampon.Tick -= this.avancerTampon0;
			Switch.timerTampon.Tick -= this.avancerTampon1;
			this.posTampon[0] = 0;
			this.posTampon[1] = 0;
			this.numTrameTampon[0] = 0;
			this.numTrameTampon[1] = 0;
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x00055FD8 File Offset: 0x00054FD8
		public override void StockerXml(XmlTextWriter writer)
		{
			writer.WriteStartElement("switch");
			base.StockerXml(writer);
			writer.WriteElementString("spanningTree", this.spanningTree.ToString());
			int nbPorts8021q = this.nbPorts8021q;
			writer.WriteElementString("nbPorts802.1q", nbPorts8021q.ToString());
			int num = this.niveauVlan;
			writer.WriteElementString("niveau_vlan", num.ToString());
			writer.WriteElementString("typeSwitch", this.typeSwitch.ToString());
			foreach (object obj in base.Controls)
			{
				PortSwitch portSwitch = (PortSwitch)obj;
				portSwitch.StockerXml(writer);
			}
			HashTableEdit.StockerTableXml(this.portVlanNiv1, writer, "table_port_vlan");
			HashTableEdit.StockerTableXml(this.macVlanNiv2, writer, "table_mac_vlan");
			writer.WriteEndElement();
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x000560E0 File Offset: 0x000550E0
		public override void ReinitEthernet()
		{
			base.ReinitEthernet();
			if (this.tramesRetransmises != null)
			{
				foreach (object obj in this.tramesRetransmises.Values)
				{
					TrameEthernet trameEthernet = (TrameEthernet)obj;
					trameEthernet.ReinitEthernet();
				}
				this.tramesRetransmises = null;
			}
			this.ram.getBuffer(0).ReinitEthernet();
			this.ram.getBuffer(1).ReinitEthernet();
			if (this.demo != null)
			{
				this.demo.DemoTerminee -= this.Switch_DemoTerminee;
				this.demo = null;
			}
			this.delaiTransmissionTrame.Tick -= this.FinDelaiTransmissionTrameNoDemo;
			this.delaiTransmissionTrame.Tick -= this.FinDelaiTransmissionFinTrameNoDemo;
			this.delaiTransmissionTrame.Tick -= this.FinDelaiTransmissionDebutTrameNoDemo;
			this.delaiTransmissionDebutTrame0.Tick -= this.FinDelaiTransmissionDebutTrameNoDemoDeuxTramesB0;
			this.delaiTransmissionFinTrame0.Tick -= this.FinDelaiTransmissionFinTrameNoDemoDeuxTramesB0;
			this.delaiTransmissionDebutTrame1.Tick -= this.FinDelaiTransmissionDebutTrameNoDemoDeuxTramesB1;
			this.delaiTransmissionFinTrame1.Tick -= this.FinDelaiTransmissionFinTrameNoDemoDeuxTramesB1;
			this.delaiReemissionTrameComplete.Tick -= this.finDelaiReemissionTrameComplete;
			this.StopperTampons();
			foreach (object obj2 in base.Controls)
			{
				PortSwitch portSwitch = (PortSwitch)obj2;
				if (portSwitch.Lien != null)
				{
					portSwitch.Lien.TrameTransmise -= this.lien_TrameTransmise;
				}
			}
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x000562D0 File Offset: 0x000552D0
		private void mi_viderTable_Click(object sender, EventArgs e)
		{
			this.PortAdresseMac = new SortedList();
			this.reseau.OkBis = false;
			this.reseau.PreparerBis();
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x00056300 File Offset: 0x00055300
		private PortSwitch portVersCarte(CarteReseau c)
		{
			PortSwitch result = null;
			bool flag = false;
			int num = 0;
			while (!flag && num < base.Controls.Count)
			{
				if (((PortSwitch)base.Controls[num]).OkToCarte(c))
				{
					flag = true;
					result = (PortSwitch)base.Controls[num];
				}
				else
				{
					num++;
				}
			}
			return result;
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x0005635C File Offset: 0x0005535C
		public void DecouvrirReseau()
		{
			this.mi_decouvrirReseau_Click(this, new EventArgs());
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x00056378 File Offset: 0x00055378
		public void DecouvrirReseau(Station s)
		{
			foreach (object obj in s.Controls)
			{
				CarteReseau carteReseau = (CarteReseau)obj;
				PortSwitch portSwitch = this.portVersCarte(carteReseau);
				if (portSwitch != null)
				{
					Switch.AjouterTableMacPort(this.portAdresseMac, carteReseau.AdresseMac, portSwitch);
					((ArrayList)this.portAdresseMac[carteReseau.AdresseMac])[2] = Switch.TtlSwitch.Elevé;
					if (this.niveauVlan == 2)
					{
						ArrayList arrayList = (ArrayList)this.portAdresseMac[carteReseau.AdresseMac];
						if (this.macVlanNiv2.ContainsKey(arrayList[0].ToString()))
						{
							string key = PortVlanEdit.numPortFormat(int.Parse(arrayList[1].ToString()));
							if (this.portVlanNiv1.ContainsKey(key))
							{
								((ArrayList)this.portVlanNiv1[key])[1] = ((ArrayList)this.macVlanNiv2[arrayList[0].ToString()])[1];
							}
						}
						else
						{
							string key = PortVlanEdit.numPortFormat(int.Parse(arrayList[1].ToString()));
							if (this.portVlanNiv1.ContainsKey(key))
							{
								((ArrayList)this.portVlanNiv1[key])[1] = "1";
							}
						}
					}
				}
			}
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x00056504 File Offset: 0x00055504
		private void mi_decouvrirReseau_Click(object sender, EventArgs e)
		{
			this.portAdresseMac = new SortedList();
			foreach (object obj in this.reseau.Schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Station))
				{
					foreach (object obj2 in ((Station)elementReseau).Controls)
					{
						CarteReseau carteReseau = (CarteReseau)obj2;
						PortSwitch portSwitch = this.portVersCarte(carteReseau);
						if (portSwitch != null)
						{
							Switch.AjouterTableMacPort(this.portAdresseMac, carteReseau.AdresseMac, portSwitch);
							((ArrayList)this.portAdresseMac[carteReseau.AdresseMac])[2] = Switch.TtlSwitch.Elevé;
						}
					}
				}
			}
			this.RafraichirTablePortVlan();
			this.reseau.OkBis = false;
			this.reseau.PreparerBis();
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x0005664C File Offset: 0x0005564C
		protected override ContextMenu menuEthernet()
		{
			if (this.reseau.EtatEthernetActif != Simulation.EtatEthernet.attente)
			{
				return null;
			}
			if (this.mi_allumer.Enabled)
			{
				return this.cm_ethernetEteint;
			}
			switch (this.niveauVlan)
			{
			case 0:
				this.mi_tablePortVlan.Enabled = false;
				this.mi_viderTablePortVlan.Enabled = false;
				this.mi_tableMacVlan.Enabled = false;
				break;
			case 1:
				this.mi_tablePortVlan.Text = "Editer table port/vlan";
				this.mi_tablePortVlan.Enabled = true;
				this.mi_viderTablePortVlan.Enabled = false;
				this.mi_tableMacVlan.Enabled = false;
				break;
			case 2:
				this.mi_tablePortVlan.Text = "Consulter table port/vlan";
				this.mi_tablePortVlan.Enabled = true;
				this.mi_viderTablePortVlan.Enabled = true;
				this.mi_tableMacVlan.Enabled = true;
				break;
			}
			return this.cm_ethernet;
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x00056734 File Offset: 0x00055734
		private void mi_tablePortVlan_Click(object sender, EventArgs e)
		{
			DialoguePortVlan dialoguePortVlan = new DialoguePortVlan("Table port/vlan switch " + this.nomNoeud, this);
			dialoguePortVlan.Size = new Size(DialoguePortVlan.Largeur, this.hauteurTablePortVlan);
			dialoguePortVlan.InScreen();
			dialoguePortVlan.Show();
			this.reseau.OkBis = false;
			this.reseau.PreparerBis();
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x00056794 File Offset: 0x00055794
		private void mi_tableMacVlan_Click(object sender, EventArgs e)
		{
			DialogueMacVlan dialogueMacVlan = new DialogueMacVlan("Table mac/vlan switch " + this.nomNoeud, this);
			dialogueMacVlan.Size = new Size(DialogueMacVlan.Largeur, this.hauteurTableMacVlan);
			dialogueMacVlan.InScreen();
			dialogueMacVlan.Show();
			this.reseau.OkBis = false;
			this.reseau.PreparerBis();
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x000567F4 File Offset: 0x000557F4
		private void mi_viderTablePortVlan_Click(object sender, EventArgs e)
		{
			bool flag = true;
			if (this.niveauVlan == 2)
			{
				flag = (MessageBox.Show("Cette opération vide également la table mac/port." + Environment.NewLine + "Voulez-vous continuer ?", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes);
			}
			if (flag)
			{
				this.initTablePortVlan1(0, 0);
				this.reseau.GereDoc.FaireAction(ActionDocument.modifier);
				this.PortAdresseMac = new SortedList();
				this.reseau.OkBis = false;
				this.reseau.PreparerBis();
			}
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x00056870 File Offset: 0x00055870
		public override void ChangerMode(Simulation.Mode nouveauMode)
		{
			this.SetContenuInfoBulle();
			switch (nouveauMode)
			{
			case Simulation.Mode.conceptionReseau:
				this.infoBulle.Active = false;
				break;
			case Simulation.Mode.ethernet:
				this.infoBulle.Active = true;
				break;
			case Simulation.Mode.ip:
				this.infoBulle.Active = true;
				break;
			case Simulation.Mode.appl:
				this.infoBulle.Active = false;
				break;
			}
			foreach (object obj in base.Controls)
			{
				PortSwitch portSwitch = (PortSwitch)obj;
				portSwitch.ChangerMode(nouveauMode);
			}
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x0005692C File Offset: 0x0005592C
		public override void SetContenuInfoBulle()
		{
			string text = "";
			Simulation.Mode modeActif = this.reseau.ModeActif;
			if (modeActif == Simulation.Mode.ip)
			{
				if (this.niveauVlan == 0)
				{
					text += "Vlan : non gérés";
				}
				else
				{
					text = text + "Vlan : niveau " + this.niveauVlan;
				}
			}
			else
			{
				if (this.typeSwitch == Switch.TypeDeSwitch.onTheFly)
				{
					text = "Type : on the fly" + Environment.NewLine;
				}
				else
				{
					text = "Type : store and forward" + Environment.NewLine;
				}
				if (this.spanningTree)
				{
					text = text + "Spanning tree : géré" + Environment.NewLine;
				}
				else
				{
					text = text + "Spanning tree : non géré" + Environment.NewLine;
				}
				if (this.niveauVlan == 0)
				{
					text += "Vlan : non gérés";
				}
				else
				{
					text = text + "Vlan : niveau " + this.niveauVlan;
				}
			}
			this.infoBulle.SetToolTip(this, text);
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x00056A14 File Offset: 0x00055A14
		public void RafraichirTablePortVlan()
		{
			if (this.niveauVlan == 2)
			{
				this.initTablePortVlan1(0, 0);
				foreach (object obj in this.portAdresseMac.Values)
				{
					ArrayList arrayList = (ArrayList)obj;
					if (this.macVlanNiv2.ContainsKey(arrayList[0].ToString()))
					{
						string key = PortVlanEdit.numPortFormat(int.Parse(arrayList[1].ToString()));
						if (this.portVlanNiv1.ContainsKey(key))
						{
							((ArrayList)this.portVlanNiv1[key])[1] = ((ArrayList)this.macVlanNiv2[arrayList[0].ToString()])[1];
						}
					}
				}
			}
		}

		// Token: 0x17000187 RID: 391
		// (set) Token: 0x06000918 RID: 2328 RVA: 0x00056B08 File Offset: 0x00055B08
		public int HauteurTableMacPort
		{
			set
			{
				this.hauteurTableMacPort = value;
			}
		}

		// Token: 0x17000188 RID: 392
		// (set) Token: 0x06000919 RID: 2329 RVA: 0x00056B1C File Offset: 0x00055B1C
		public int HauteurTableMacVlan
		{
			set
			{
				this.hauteurTableMacVlan = value;
			}
		}

		// Token: 0x17000189 RID: 393
		// (set) Token: 0x0600091A RID: 2330 RVA: 0x00056B30 File Offset: 0x00055B30
		public int HauteurTablePortVlan
		{
			set
			{
				this.hauteurTablePortVlan = value;
			}
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x00056B44 File Offset: 0x00055B44
		public override void TransmissionRapideEthernet(bool demo, PointConnexion demandeur, Ip_PaquetIp paquet, bool suivreLiensPortsEteints, ReactionStation rs, ReactionSwitch rsw)
		{
			if (rsw != null)
			{
				rsw(this, (PortSwitch)demandeur, paquet);
			}
			bool ports8021q = false;
			bool portsDuVlan = false;
			if (this.niveauVlan != 0)
			{
				this.marquerPaquetVlan((PortSwitch)demandeur, paquet, this.niveauVlan);
				if (this.niveauVlan == 2)
				{
					if (this.macVlanNiv2.ContainsKey(paquet.MacDest))
					{
						ports8021q = false;
						portsDuVlan = true;
					}
					else if (paquet.Vlan == 1)
					{
						ports8021q = true;
						portsDuVlan = true;
					}
					else
					{
						ports8021q = true;
						portsDuVlan = false;
					}
				}
			}
			if (paquet.MacDest == this.reseau.Pref.AdrMacBroadcast)
			{
				this.TransmissionRapideEthernetAutresPorts(demo, (PortSwitch)demandeur, true, true, paquet, suivreLiensPortsEteints, rs, rsw);
				return;
			}
			bool flag = true;
			if (this.niveauVlan == 2)
			{
				int num = this.vlanMacNiv2(paquet.MacDest);
				flag = (num == -1 || num == paquet.Vlan);
			}
			if (flag && paquet.MacDest != null)
			{
				if (this.portAdresseMac[paquet.MacDest] == null)
				{
					this.TransmissionRapideEthernetAutresPorts(demo, (PortSwitch)demandeur, portsDuVlan, ports8021q, paquet, suivreLiensPortsEteints, rs, rsw);
					return;
				}
				PortSwitch portSwitch = (PortSwitch)((ArrayList)this.portAdresseMac[paquet.MacDest])[1];
				if (this.niveauVlan == 1)
				{
					int num2 = portSwitch.Vlan(this.portVlanNiv1);
					flag = (num2 == -1 || num2 == paquet.Vlan);
				}
				if (flag && portSwitch != demandeur)
				{
					this.TransmissionRapideEthernetSurPort(demo, portSwitch, portsDuVlan, ports8021q, paquet, suivreLiensPortsEteints, rs, rsw);
				}
			}
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x00056CB8 File Offset: 0x00055CB8
		private void marquerPaquetVlan(PortSwitch portEmetteur, Ip_PaquetIp p, int niveauVlan)
		{
			if (niveauVlan == 1)
			{
				if (portEmetteur.GetType() != typeof(Port8021qSwitch))
				{
					p.Vlan = int.Parse(((ArrayList)this.portVlanNiv1[PortVlanEdit.numPortFormat(portEmetteur.NumeroOrdre)])[1].ToString());
					return;
				}
			}
			else if (portEmetteur.GetType() != typeof(Port8021qSwitch))
			{
				if (this.macVlanNiv2.ContainsKey(p.MacSource))
				{
					p.Vlan = int.Parse(((ArrayList)this.macVlanNiv2[p.MacSource])[1].ToString());
					return;
				}
				p.Vlan = 1;
			}
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x00056D6C File Offset: 0x00055D6C
		private void TransmissionRapideEthernetSurPort(bool demo, PortSwitch p, bool portsDuVlan, bool ports8021q, Ip_PaquetIp paquet, bool suivreLiensPortsEteints, ReactionStation rs, ReactionSwitch rsw)
		{
			switch (this.niveauVlan)
			{
			case 0:
				if (p.EtatConnexion == PointConnexion.EtatsConnexion.actif || (suivreLiensPortsEteints && p.Lien != null))
				{
					p.Lien.TransmissionRapideEthernet(demo, p, paquet, suivreLiensPortsEteints, rs, rsw);
					return;
				}
				break;
			case 1:
			{
				int num = p.Vlan(this.portVlanNiv1);
				if (num == -1)
				{
					if (p.EtatConnexion == PointConnexion.EtatsConnexion.actif || (suivreLiensPortsEteints && p.Lien != null))
					{
						p.Lien.TransmissionRapideEthernet(demo, p, paquet, suivreLiensPortsEteints, rs, rsw);
						return;
					}
				}
				else if (num == paquet.Vlan && (p.EtatConnexion == PointConnexion.EtatsConnexion.actif || (suivreLiensPortsEteints && p.Lien != null)))
				{
					p.Lien.TransmissionRapideEthernet(demo, p, paquet, suivreLiensPortsEteints, rs, rsw);
					return;
				}
				break;
			}
			case 2:
			{
				int num = p.Vlan(this.portVlanNiv1);
				if (num == -1)
				{
					if (ports8021q && (p.EtatConnexion == PointConnexion.EtatsConnexion.actif || (suivreLiensPortsEteints && p.Lien != null)))
					{
						p.Lien.TransmissionRapideEthernet(demo, p, paquet, suivreLiensPortsEteints, rs, rsw);
						return;
					}
				}
				else if (portsDuVlan && num == paquet.Vlan && (p.EtatConnexion == PointConnexion.EtatsConnexion.actif || (suivreLiensPortsEteints && p.Lien != null)))
				{
					p.Lien.TransmissionRapideEthernet(demo, p, paquet, suivreLiensPortsEteints, rs, rsw);
				}
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x00056EBC File Offset: 0x00055EBC
		private void TransmissionRapideEthernetAutresPorts(bool demo, PortSwitch portEmetteur, bool portsDuVlan, bool ports8021q, Ip_PaquetIp paquet, bool suivreLiensPortsEteints, ReactionStation rs, ReactionSwitch rsw)
		{
			foreach (object obj in base.Controls)
			{
				PortSwitch portSwitch = (PortSwitch)obj;
				if (portSwitch != portEmetteur)
				{
					this.TransmissionRapideEthernetSurPort(demo, portSwitch, portsDuVlan, ports8021q, paquet, suivreLiensPortsEteints, rs, rsw);
				}
			}
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x00056F34 File Offset: 0x00055F34
		public static void ReactionMajTables(Switch sw, PortSwitch p, Ip_PaquetIp paquet)
		{
			if (p.EtatConnexion == PointConnexion.EtatsConnexion.actif)
			{
				sw.majTableMacPort(p, paquet.MacSource);
				if (sw.niveauVlan == 2 && p.GetType() != typeof(Port8021qSwitch))
				{
					sw.marquerPaquetVlan(p, paquet, sw.niveauVlan);
					sw.majTablePortVlan(p, paquet.Vlan);
				}
			}
		}

		// Token: 0x0400058C RID: 1420
		private IContainer components = null;

		// Token: 0x0400058D RID: 1421
		private MenuItem mi_tableMacPort;

		// Token: 0x0400058E RID: 1422
		private MenuItem mi_voirConfig;

		// Token: 0x0400058F RID: 1423
		private Timer delaiTransmissionTrame = new Timer();

		// Token: 0x04000590 RID: 1424
		private Timer delaiTransmissionDebutTrame0 = new Timer();

		// Token: 0x04000591 RID: 1425
		private Timer delaiTransmissionDebutTrame1 = new Timer();

		// Token: 0x04000592 RID: 1426
		private Timer delaiTransmissionFinTrame0 = new Timer();

		// Token: 0x04000593 RID: 1427
		private MenuItem mi_viderTable;

		// Token: 0x04000594 RID: 1428
		private MenuItem mi_tablePortVlan;

		// Token: 0x04000595 RID: 1429
		private MenuItem mi_tableMacVlan;

		// Token: 0x04000596 RID: 1430
		private MenuItem menuItem2;

		// Token: 0x04000597 RID: 1431
		private MenuItem menuItem4;

		// Token: 0x04000598 RID: 1432
		private MenuItem menuItem1;

		// Token: 0x04000599 RID: 1433
		private MenuItem mi_viderTablePortVlan;

		// Token: 0x0400059A RID: 1434
		private MenuItem mi_decouvrirReseau;

		// Token: 0x0400059B RID: 1435
		private Timer delaiTransmissionFinTrame1 = new Timer();

		// Token: 0x0400059C RID: 1436
		private SortedList portAdresseMac = new SortedList();

		// Token: 0x0400059D RID: 1437
		private SortedList portVlanNiv1 = new SortedList();

		// Token: 0x0400059E RID: 1438
		private SortedList macVlanNiv2 = new SortedList();

		// Token: 0x0400059F RID: 1439
		private int nbCablesTrameTransmise;

		// Token: 0x040005A0 RID: 1440
		private int nbCablesTrameAchevee;

		// Token: 0x040005A1 RID: 1441
		private Switch.TypeDeSwitch typeSwitch = Switch.TypeDeSwitch.storeAndForward;

		// Token: 0x040005A2 RID: 1442
		private bool spanningTree = true;

		// Token: 0x040005A3 RID: 1443
		private int niveauVlan = 0;

		// Token: 0x040005A4 RID: 1444
		private Hashtable tramesRetransmises;

		// Token: 0x040005A5 RID: 1445
		private RamSwitch ram = new RamSwitch();

		// Token: 0x040005A6 RID: 1446
		private Timer delaiReemissionTrameComplete = new Timer();

		// Token: 0x040005A7 RID: 1447
		private Timer delaiReemissionTrameComplete1 = new Timer();

		// Token: 0x040005A8 RID: 1448
		private static Timer timerTampon = new Timer();

		// Token: 0x040005A9 RID: 1449
		private Graphics gTampon;

		// Token: 0x040005AA RID: 1450
		private int[] posTampon = new int[2];

		// Token: 0x040005AB RID: 1451
		private int[] tamponSuivant = new int[2];

		// Token: 0x040005AC RID: 1452
		private int[] debutTampon = new int[2];

		// Token: 0x040005AD RID: 1453
		private int[] limiteTampon = new int[2];

		// Token: 0x040005AE RID: 1454
		private int[] numTrameTampon;

		// Token: 0x040005AF RID: 1455
		private Brush[] couleurTampon;

		// Token: 0x040005B0 RID: 1456
		private int hauteurTableMacPort;

		// Token: 0x040005B1 RID: 1457
		private int hauteurTableMacVlan;

		// Token: 0x040005B2 RID: 1458
		private int hauteurTablePortVlan;

		// Token: 0x0200008B RID: 139
		public enum TtlSwitch
		{
			// Token: 0x040005B4 RID: 1460
			Nul,
			// Token: 0x040005B5 RID: 1461
			Faible,
			// Token: 0x040005B6 RID: 1462
			Moyen,
			// Token: 0x040005B7 RID: 1463
			Elevé,
			// Token: 0x040005B8 RID: 1464
			Maximum
		}

		// Token: 0x0200008C RID: 140
		public enum TypeDeSwitch
		{
			// Token: 0x040005BA RID: 1466
			onTheFly,
			// Token: 0x040005BB RID: 1467
			storeAndForward
		}
	}
}
