using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Resources;
using System.Windows.Forms;
using System.Xml;
using IAppliParam;

namespace Simulateur
{
	// Token: 0x02000080 RID: 128
	public partial class Simulation : Form, IAppliParam
	{
		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060007BA RID: 1978 RVA: 0x00049EC0 File Offset: 0x00048EC0
		// (set) Token: 0x060007BB RID: 1979 RVA: 0x00049EDC File Offset: 0x00048EDC
		public bool CablesVirtuelIp
		{
			get
			{
				return this.cb_trajetPaquet.SelectedIndex == 1;
			}
			set
			{
				if (value)
				{
					this.cb_trajetPaquet.SelectedIndex = 1;
					return;
				}
				this.cb_trajetPaquet.SelectedIndex = 0;
			}
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x00049F08 File Offset: 0x00048F08
		public Simulation()
		{
			this.InitializeComponent();
			this.pref = new Param(this);
			try
			{
				this.pref.ChargerXml(Application.StartupPath + "\\param.xml");
			}
			catch
			{
				this.pref.RestaurerParamDefaut();
				this.PrendreEnCompteParams(false);
			}
			this.styloEfface = new Pen(this.schema.BackColor, 1f);
			this.styloGomme = new Pen(this.schema.BackColor, 3f);
			this.modeActif = Simulation.Mode.conceptionReseau;
			this.etatConceptionActif = Simulation.EtatConception.consultationSchema;
			this.etatEthernetActif = Simulation.EtatEthernet.aucun;
			this.afficherOutils(this.modeActif);
			this.simulationEthernet = Simulation.TypeDeSimulationEthernet.circulationTrame;
			this.cb_typeDemo.SelectedIndex = 0;
			this.cb_typeSimulIp.SelectedIndex = 0;
			this.timerTraceTrame.Interval = this.pref.DelaiTickTraceLigne;
			Switch.TimerTampon = new Timer(this.components);
			Switch.TimerTampon.Interval = 30;
			Switch.TimerTampon.Start();
			Simulation.timerEmissionTrame = new Timer();
			Simulation.timerEmissionTrame.Interval = 1;
			Simulation.timerEmissionTrame.Start();
			this.gereDoc.Init(new DelegueAction(this.nouveauDoc), new DelegueConfirmation(this.ouvrirDoc), new DelegueConfirmation(this.enregistrerDoc), new DelegueAction(this.enregistrerSchema), "Enregistrer le schéma");
			this.derniereSimulation = new DonneesSimulation(this);
			this.derniereSimulationIp = new DonneesSimulationIp(this);
			if (!Simulation.ModeDebug)
			{
				this.bt_debugBis.Visible = false;
			}
			this.iconeMessage.BackColor = this.pref.StyloMessage.Color;
			this.iconeMessage.Visible = false;
			Trs_station.RndPort = new Random();
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x0004A22C File Offset: 0x0004922C
		public void PrendreEnCompteParams(bool ancienCablesVirtuel)
		{
			if (ancienCablesVirtuel != this.pref.CablesVirtuelIp)
			{
				this.CablesVirtuelIp = this.pref.CablesVirtuelIp;
			}
			if (!this.pref.MemoriserPosDemo)
			{
				this.setPosDemoDefaut();
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060007BE RID: 1982 RVA: 0x0004A26C File Offset: 0x0004926C
		public Ap_Message IconeMessage
		{
			get
			{
				return this.iconeMessage;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060007BF RID: 1983 RVA: 0x0004A280 File Offset: 0x00049280
		public static Timer TimerEmissionTrame
		{
			get
			{
				return Simulation.timerEmissionTrame;
			}
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x0004D038 File Offset: 0x0004C038
		[STAThread]
		private static void Main()
		{
			Application.Run(new Simulation());
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060007C3 RID: 1987 RVA: 0x0004D050 File Offset: 0x0004C050
		public Pen StyloEfface
		{
			get
			{
				return this.styloEfface;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x060007C4 RID: 1988 RVA: 0x0004D064 File Offset: 0x0004C064
		public Pen StyloGomme
		{
			get
			{
				return this.styloGomme;
			}
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x0004D078 File Offset: 0x0004C078
		private void ajouterNoeud(Noeud n, MouseEventArgs e)
		{
			n.IdNoeud = ++this.dernierIdNoeud;
			int x = e.X - n.Width / 2;
			int y = e.Y - n.Height / 2;
			Point pos = new Point(x, y);
			n.Location = this.positionOk(n.Size, pos);
			this.schema.Controls.Add(n);
			this.noeuds.Add(n.NomNoeud, n);
			if (!this.pref.TraceParDefaut)
			{
				this.noeudsNonDemo.Add(n.NomNoeud, n);
			}
			this.gereDoc.FaireAction(ActionDocument.modifier);
		}

		// Token: 0x17000138 RID: 312
		// (set) Token: 0x060007C6 RID: 1990 RVA: 0x0004D128 File Offset: 0x0004C128
		public int DernierIdNoeud
		{
			set
			{
				this.dernierIdNoeud = value;
			}
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x0004D13C File Offset: 0x0004C13C
		private void supprimerCreationNoeuds()
		{
			this.schema.MouseDown -= this.creerStation;
			this.schema.MouseDown -= this.creerHub;
			this.schema.MouseDown -= this.creerSwitch;
			this.schema.MouseDown -= this.creerInternet;
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x0004D1A8 File Offset: 0x0004C1A8
		public Point positionOk(Size taille, Point pos)
		{
			if (pos.X < 0)
			{
				pos.X = 0;
			}
			else if (pos.X + taille.Width > this.schema.ClientSize.Width)
			{
				pos.X = this.schema.ClientSize.Width - taille.Width;
			}
			if (pos.Y < 0)
			{
				pos.Y = 0;
			}
			else if (pos.Y + taille.Height > this.schema.ClientSize.Height)
			{
				pos.Y = this.schema.ClientSize.Height - taille.Height;
			}
			return pos;
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x0004D26C File Offset: 0x0004C26C
		public void creerStation(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Station station = new Station(this);
				do
				{
					Noeud noeud = station;
					string str = "st";
					int num = ++this.nbStations;
					noeud.NomNoeud = str + num.ToString();
				}
				while (this.noeuds.Contains(station.NomNoeud));
				this.ajouterNoeud(station, e);
			}
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x0004D2D4 File Offset: 0x0004C2D4
		public void creerHub(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				string text;
				do
				{
					string str = "hb";
					int num = ++this.nbHubs;
					text = str + num.ToString();
				}
				while (this.noeuds.Contains(text));
				Hub n = new Hub(this, text);
				this.ajouterNoeud(n, e);
			}
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x0004D330 File Offset: 0x0004C330
		public void creerSwitch(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				string text;
				do
				{
					string str = "sw";
					int num = ++this.nbSwitchs;
					text = str + num.ToString();
				}
				while (this.noeuds.Contains(text));
				Switch n = new Switch(this, text);
				this.ajouterNoeud(n, e);
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x060007CC RID: 1996 RVA: 0x0004D38C File Offset: 0x0004C38C
		public Internet ReseauInternet
		{
			get
			{
				return this.reseauInternet;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060007CD RID: 1997 RVA: 0x0004D3A0 File Offset: 0x0004C3A0
		// (set) Token: 0x060007CE RID: 1998 RVA: 0x0004D3B4 File Offset: 0x0004C3B4
		public Ip_adresse AdrReseauInternet1
		{
			get
			{
				return this.adrReseauInternet1;
			}
			set
			{
				this.adrReseauInternet1 = value;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060007CF RID: 1999 RVA: 0x0004D3C8 File Offset: 0x0004C3C8
		// (set) Token: 0x060007D0 RID: 2000 RVA: 0x0004D3DC File Offset: 0x0004C3DC
		public Ip_adresse AdrReseauInternet2
		{
			get
			{
				return this.adrReseauInternet2;
			}
			set
			{
				this.adrReseauInternet2 = value;
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060007D1 RID: 2001 RVA: 0x0004D3F0 File Offset: 0x0004C3F0
		// (set) Token: 0x060007D2 RID: 2002 RVA: 0x0004D404 File Offset: 0x0004C404
		public Ip_adresse AdrReseauInternet3
		{
			get
			{
				return this.adrReseauInternet3;
			}
			set
			{
				this.adrReseauInternet3 = value;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060007D3 RID: 2003 RVA: 0x0004D418 File Offset: 0x0004C418
		// (set) Token: 0x060007D4 RID: 2004 RVA: 0x0004D42C File Offset: 0x0004C42C
		public Ip_adresse AdrReseauInternet4
		{
			get
			{
				return this.adrReseauInternet4;
			}
			set
			{
				this.adrReseauInternet4 = value;
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060007D5 RID: 2005 RVA: 0x0004D440 File Offset: 0x0004C440
		// (set) Token: 0x060007D6 RID: 2006 RVA: 0x0004D454 File Offset: 0x0004C454
		public Ip_adresse AdrReseauInternet5
		{
			get
			{
				return this.adrReseauInternet5;
			}
			set
			{
				this.adrReseauInternet5 = value;
			}
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x0004D468 File Offset: 0x0004C468
		public void SetAdrReseauInternet(int i, Ip_adresse adr)
		{
			switch (i)
			{
			case 1:
				this.adrReseauInternet1 = adr;
				return;
			case 2:
				this.adrReseauInternet2 = adr;
				return;
			case 3:
				this.adrReseauInternet3 = adr;
				return;
			case 4:
				this.adrReseauInternet4 = adr;
				return;
			case 5:
				this.adrReseauInternet5 = adr;
				return;
			default:
				return;
			}
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x0004D4BC File Offset: 0x0004C4BC
		public Ip_adresse GetAdrReseauInternet(int i)
		{
			Ip_adresse result = new Ip_adresse("0.0.0.0");
			switch (i)
			{
			case 1:
				result = this.adrReseauInternet1;
				break;
			case 2:
				result = this.adrReseauInternet2;
				break;
			case 3:
				result = this.adrReseauInternet3;
				break;
			case 4:
				result = this.adrReseauInternet4;
				break;
			case 5:
				result = this.adrReseauInternet5;
				break;
			}
			return result;
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x0004D520 File Offset: 0x0004C520
		public bool IsAdrReseauInternet(Ip_adresse adrIp)
		{
			for (int i = 1; i < 6; i++)
			{
				if (Ip_quartet.MemeReseau(adrIp, this.GetAdrReseauInternet(i), new Ip_quartet("255.255.0.0")))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x0004D558 File Offset: 0x0004C558
		private void creerInternet(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.reseauInternet = new Internet(this);
				this.ajouterNoeud(this.reseauInternet, e);
				this.reseauInternet.Initialiser(this);
				this.internetPresent = true;
				this.rb_internet.Enabled = false;
				this.rb_fleche.Checked = true;
				this.rb_fleche_Click(null, null);
			}
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x0004D5C0 File Offset: 0x0004C5C0
		public void SupprimerInternet()
		{
			this.internetPresent = false;
			this.reseauInternet = null;
			this.rb_internet.Enabled = true;
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x0004D5E8 File Offset: 0x0004C5E8
		public void TracerCables()
		{
			foreach (object obj in this.schema.Controls)
			{
				Control control = (Control)obj;
				if (control.GetType().BaseType.Equals(typeof(TraceManuel)))
				{
					control.Invalidate();
				}
			}
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x0004D670 File Offset: 0x0004C670
		private void schema_Paint(object sender, PaintEventArgs e)
		{
			this.TracerCables();
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x0004D684 File Offset: 0x0004C684
		private void rb_fleche_Click(object sender, EventArgs e)
		{
			switch (this.etatConceptionActif)
			{
			case Simulation.EtatConception.creationNoeud:
				this.supprimerCreationNoeuds();
				break;
			case Simulation.EtatConception.creationCableEnCours:
				this.AbandonCableEnCours();
				break;
			}
			this.etatConceptionActif = Simulation.EtatConception.consultationSchema;
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x0004D6C4 File Offset: 0x0004C6C4
		public void rb_cable_Click(object sender, EventArgs e)
		{
			this.ToutDeSelectionner();
			Simulation.EtatConception etatConception = this.etatConceptionActif;
			if (etatConception == Simulation.EtatConception.creationNoeud)
			{
				this.supprimerCreationNoeuds();
			}
			this.etatConceptionActif = Simulation.EtatConception.creationCable;
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x0004D6F0 File Offset: 0x0004C6F0
		private void rb_noeud_Click(MouseEventHandler meh)
		{
			this.ToutDeSelectionner();
			switch (this.etatConceptionActif)
			{
			case Simulation.EtatConception.creationNoeud:
				this.supprimerCreationNoeuds();
				break;
			case Simulation.EtatConception.creationCableEnCours:
				this.AbandonCableEnCours();
				break;
			}
			this.schema.MouseDown += meh.Invoke;
			this.etatConceptionActif = Simulation.EtatConception.creationNoeud;
		}

		// Token: 0x060007E1 RID: 2017 RVA: 0x0004D74C File Offset: 0x0004C74C
		public void ToutDeSelectionner()
		{
			ArrayList arrayList = (ArrayList)this.NoeudsSelectionnes.Clone();
			for (int i = 0; i < arrayList.Count; i++)
			{
				((Noeud)arrayList[i]).deSelectionner();
			}
			arrayList.Clear();
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x0004D794 File Offset: 0x0004C794
		private void rb_station_Click(object sender, EventArgs e)
		{
			this.rb_noeud_Click(new MouseEventHandler(this.creerStation));
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x0004D7B4 File Offset: 0x0004C7B4
		private void rb_hub_Click(object sender, EventArgs e)
		{
			this.rb_noeud_Click(new MouseEventHandler(this.creerHub));
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x0004D7D4 File Offset: 0x0004C7D4
		private void rb_switch_Click(object sender, EventArgs e)
		{
			this.rb_noeud_Click(new MouseEventHandler(this.creerSwitch));
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x0004D7F4 File Offset: 0x0004C7F4
		private void rb_internet_Click(object sender, EventArgs e)
		{
			this.rb_noeud_Click(new MouseEventHandler(this.creerInternet));
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x0004D814 File Offset: 0x0004C814
		private void schema_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.etatConceptionActif == Simulation.EtatConception.creationCableEnCours)
			{
				Graphics graphics = this.schema.CreateGraphics();
				Rectangle rectInvalide = this.TraceNouveauCable.RectangleTrace();
				this.TraceNouveauCable.Effacer(graphics);
				this.TraceNouveauCable.B = new Point(e.X, e.Y);
				this.TracerCablesManuel(graphics, rectInvalide);
				graphics.Dispose();
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060007E7 RID: 2023 RVA: 0x0004D878 File Offset: 0x0004C878
		// (set) Token: 0x060007E8 RID: 2024 RVA: 0x0004D88C File Offset: 0x0004C88C
		public Simulation.Mode ModeActif
		{
			get
			{
				return this.modeActif;
			}
			set
			{
				this.modeActif = value;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060007E9 RID: 2025 RVA: 0x0004D8A0 File Offset: 0x0004C8A0
		// (set) Token: 0x060007EA RID: 2026 RVA: 0x0004D8B4 File Offset: 0x0004C8B4
		public Simulation.EtatConception EtatConceptionActif
		{
			get
			{
				return this.etatConceptionActif;
			}
			set
			{
				this.etatConceptionActif = value;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060007EB RID: 2027 RVA: 0x0004D8C8 File Offset: 0x0004C8C8
		// (set) Token: 0x060007EC RID: 2028 RVA: 0x0004D8DC File Offset: 0x0004C8DC
		public Simulation.EtatEthernet EtatEthernetActif
		{
			get
			{
				return this.etatEthernetActif;
			}
			set
			{
				this.etatEthernetActif = value;
			}
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x0004D8F0 File Offset: 0x0004C8F0
		private void cocherMenuMode(MenuItem m)
		{
			foreach (object obj in this.mi_mode.MenuItems)
			{
				MenuItem menuItem = (MenuItem)obj;
				menuItem.Checked = false;
			}
			m.Checked = true;
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x0004D964 File Offset: 0x0004C964
		private void mi_conceptionReseau_Click(object sender, EventArgs e)
		{
			if (this.modeActif != Simulation.Mode.conceptionReseau)
			{
				this.changerMode(Simulation.Mode.conceptionReseau);
				this.cocherMenuMode((MenuItem)sender);
				foreach (object obj in this.sommetsSwitch)
				{
					Switch @switch = (Switch)obj;
					@switch.DebloquerPorts();
				}
				foreach (object obj2 in this.schema.Controls)
				{
					ElementReseau elementReseau = (ElementReseau)obj2;
					elementReseau.Eteindre();
					elementReseau.ChangerMode(Simulation.Mode.conceptionReseau);
				}
				this.etatConceptionActif = Simulation.EtatConception.consultationSchema;
				this.etatEthernetActif = Simulation.EtatEthernet.aucun;
			}
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x0004DA54 File Offset: 0x0004CA54
		private void setContenuInfoBulle(Simulation.Mode nouveauMode)
		{
			switch (nouveauMode)
			{
			case Simulation.Mode.conceptionReseau:
				this.infoBulle.Active = false;
				return;
			case Simulation.Mode.ethernet:
				this.infoBulle.Active = true;
				this.infoBulle.SetToolTip(this.lbl_crc, "contrôle de la trame");
				this.infoBulle.SetToolTip(this.lbl_destinataire, "MAC destinataire");
				this.infoBulle.SetToolTip(this.lbl_donnees, "Données transportées");
				this.infoBulle.SetToolTip(this.lbl_emetteur, "MAC émetteur");
				this.infoBulle.SetToolTip(this.lbl_preambule, "Préambule Ethernet");
				this.infoBulle.SetToolTip(this.lbl_type, "Type de paquet transporté");
				return;
			case Simulation.Mode.ip:
				this.infoBulle.Active = true;
				this.infoBulle.SetToolTip(this.lbl_macDest, "MAC destinataire");
				this.infoBulle.SetToolTip(this.lbl_donneesIp, "Données transportées");
				this.infoBulle.SetToolTip(this.lbl_macSource, "MAC émetteur");
				this.infoBulle.SetToolTip(this.lbl_typePaquet, "Type de paquet transporté");
				this.infoBulle.SetToolTip(this.lbl_ttlPaquet, "TTL du paquet IP");
				this.infoBulle.SetToolTip(this.lbl_IpSource, "Adr IP de l'émetteur");
				this.infoBulle.SetToolTip(this.lbl_IpDest, "Adr IP du destinataire");
				return;
			case Simulation.Mode.appl:
				this.infoBulle.Active = false;
				return;
			default:
				return;
			}
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x0004DBCC File Offset: 0x0004CBCC
		private void afficherOutils(Simulation.Mode nouveauMode)
		{
			this.setContenuInfoBulle(nouveauMode);
			this.boutonsConception.Size = new Size(this.boutonsConception.Width, 0);
			this.panelEthernet.Size = new Size(this.panelEthernet.Width, 0);
			this.panelIp.Size = new Size(this.panelIp.Width, 0);
			this.panelApplication.Size = new Size(this.panelApplication.Width, 0);
			switch (nouveauMode)
			{
			case Simulation.Mode.conceptionReseau:
				this.boutonsConception.Size = new Size(this.boutonsConception.Width, this.pref.HauteurOutils);
				this.rb_fleche.Checked = true;
				this.mi_tablesIp.Visible = false;
				return;
			case Simulation.Mode.ethernet:
				this.panelEthernet.Size = new Size(this.panelEthernet.Width, this.pref.HauteurOutils);
				this.panelTrameEthernet.Size = new Size(this.panelTrameEthernet.Width, 0);
				this.panelReglagesEthernet.Size = new Size(this.panelReglagesEthernet.Width, 36);
				this.PreparerBis();
				if (this.nbSwitchEtStationsDemo() == 0)
				{
					this.cb_demoEmission.Checked = (this.cb_demoEmission.Enabled = false);
				}
				this.mi_tablesIp.Visible = false;
				return;
			case Simulation.Mode.ip:
				this.panelIp.Size = new Size(this.panelIp.Width, this.pref.HauteurOutils);
				this.panelTrameIp.Size = new Size(this.panelTrameIp.Width, 0);
				this.panelReglagesIp.Size = new Size(this.panelReglagesIp.Width, 36);
				this.panelReglagesIp.Enabled = true;
				this.mi_tablesIp.Visible = true;
				return;
			case Simulation.Mode.appl:
				this.panelApplication.Size = new Size(this.panelApplication.Width, this.pref.HauteurOutils);
				this.panelTrameAp.Size = new Size(this.panelTrameAp.Width, 0);
				this.panelReglagesAp.Size = new Size(this.panelReglagesAp.Width, 36);
				this.panelReglagesAp.Enabled = true;
				this.mi_tablesIp.Visible = false;
				return;
			default:
				return;
			}
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x0004DE2C File Offset: 0x0004CE2C
		public void MontrerTrame(int numeroTrame, string destinataire, string emetteur)
		{
			this.panelReglagesEthernet.Size = new Size(this.panelReglagesEthernet.Width, 0);
			this.panelTrameEthernet.Size = new Size(this.panelTrameEthernet.Width, 30);
			if (numeroTrame == 1)
			{
				this.panelTrameEthernet.BackColor = this.pref.CableActifStylo1.Color;
			}
			else
			{
				this.panelTrameEthernet.BackColor = this.pref.CableActifStylo2.Color;
			}
			this.lbl_destinataire.Text = destinataire;
			this.lbl_emetteur.Text = emetteur;
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x0004DEC8 File Offset: 0x0004CEC8
		public void CacherTrame()
		{
			if (this.pref.MontrerTrame)
			{
				this.panelTrameEthernet.Size = new Size(this.panelTrameEthernet.Width, 0);
				this.panelReglagesEthernet.Size = new Size(this.panelReglagesEthernet.Width, this.pref.HauteurOutils);
			}
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x0004DF24 File Offset: 0x0004CF24
		private void mi_ethernet_Click(object sender, EventArgs e)
		{
			if (this.modeActif != Simulation.Mode.ethernet)
			{
				this.ensHub = null;
				this.changerMode(Simulation.Mode.ethernet);
				this.cocherMenuMode((MenuItem)sender);
				foreach (object obj in this.noeuds.Values)
				{
					Noeud noeud = (Noeud)obj;
					if (noeud.EnFonction)
					{
						noeud.Allumer();
					}
					noeud.ChangerMode(Simulation.Mode.ethernet);
				}
				this.setLibelleBt_noeudsDemo();
				this.etatConceptionActif = Simulation.EtatConception.aucun;
				this.EtatEthernetActif = Simulation.EtatEthernet.attente;
				this.SpanningTree();
				if (this.pref.AnnonceStations)
				{
					foreach (object obj2 in this.schema.Controls)
					{
						ElementReseau elementReseau = (ElementReseau)obj2;
						if (elementReseau.GetType() == typeof(Switch))
						{
							((Switch)elementReseau).DecouvrirReseau();
						}
					}
				}
			}
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x0004E058 File Offset: 0x0004D058
		public void NoFocus()
		{
			this.outils.Focus();
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x0004E074 File Offset: 0x0004D074
		private void changerMode(Simulation.Mode nouveauMode)
		{
			switch (this.etatConceptionActif)
			{
			case Simulation.EtatConception.consultationSchema:
				this.ToutDeSelectionner();
				break;
			case Simulation.EtatConception.creationNoeud:
				this.supprimerCreationNoeuds();
				break;
			case Simulation.EtatConception.creationCableEnCours:
				this.AbandonCableEnCours();
				break;
			}
			this.NoFocus();
			this.etatConceptionActif = Simulation.EtatConception.aucun;
			this.EtatEthernetActif = Simulation.EtatEthernet.aucun;
			this.EtatIpActif = Simulation.EtatIp.aucun;
			if (this.modeActif == Simulation.Mode.ip)
			{
				this.desinstallerGestionEvenementsIp();
			}
			else if (nouveauMode == Simulation.Mode.ip)
			{
				this.installerGestionEvenementsIp();
			}
			this.modeActif = nouveauMode;
			this.okBis = false;
			this.bt_stopBisIp.Enabled = false;
			this.afficherOutils(this.modeActif);
			this.iconeMessage.Visible = false;
			foreach (FormConfig formConfig in base.OwnedForms)
			{
				formConfig.Close();
			}
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x0004E144 File Offset: 0x0004D144
		private void installerGestionEvenementsIp()
		{
			foreach (object obj in this.schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Station) || elementReseau.GetType() == typeof(Internet))
				{
					((Station)elementReseau).Ip.InstallerGestionEvenements();
					((Station)elementReseau).Trs.InstallerGestionEvenements();
					elementReseau.Invalidate();
				}
			}
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x0004E1F4 File Offset: 0x0004D1F4
		private void desinstallerGestionEvenementsIp()
		{
			foreach (object obj in this.schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Station) || elementReseau.GetType() == typeof(Internet))
				{
					((Station)elementReseau).Ip.DesinstallerGestionEvenements();
					((Station)elementReseau).Trs.DesinstallerGestionEvenements();
					elementReseau.Invalidate();
				}
			}
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x0004E2A4 File Offset: 0x0004D2A4
		public void EffacerCablesManuel(Graphics g, Rectangle rectInvalide)
		{
			foreach (object obj in this.schema.Controls)
			{
				Control control = (Control)obj;
				if (control.GetType().BaseType.Equals(typeof(TraceManuel)) && rectInvalide.IntersectsWith(((TraceManuel)control).RectangleTrace()))
				{
					((TraceManuel)control).Effacer(g);
				}
			}
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x0004E344 File Offset: 0x0004D344
		public void TracerCablesManuel(Graphics g, Rectangle rectInvalide)
		{
			foreach (object obj in this.schema.Controls)
			{
				Control control = (Control)obj;
				if (control.GetType().BaseType.Equals(typeof(TraceManuel)) && rectInvalide.IntersectsWith(((TraceManuel)control).RectangleTrace()))
				{
					((TraceManuel)control).Tracer(g);
				}
			}
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x0004E3E4 File Offset: 0x0004D3E4
		private void traceRectangleSelection(object sender, MouseEventArgs e)
		{
			Graphics graphics = this.schema.CreateGraphics();
			Point location = new Point(Math.Min(e.X, this.debutRectangleSelection.X), Math.Min(e.Y, this.debutRectangleSelection.Y));
			Size size = new Size(Math.Abs(e.X - this.debutRectangleSelection.X), Math.Abs(e.Y - this.debutRectangleSelection.Y));
			Rectangle rectangle = new Rectangle(new Point(this.RectangleSelection.Left - 1, this.RectangleSelection.Top - 1), new Size(this.RectangleSelection.Width + 2, this.RectangleSelection.Height + 2));
			graphics.DrawRectangle(this.styloEfface, this.RectangleSelection);
			this.RectangleSelection = new Rectangle(location, size);
			graphics.DrawRectangle(this.pref.SelectionStylo, this.RectangleSelection);
			rectangle = Rectangle.Union(rectangle, new Rectangle(new Point(this.RectangleSelection.Left - 1, this.RectangleSelection.Top - 1), new Size(this.RectangleSelection.Width + 2, this.RectangleSelection.Height + 2)));
			this.TracerCablesManuel(graphics, rectangle);
			graphics.Dispose();
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x0004E538 File Offset: 0x0004D538
		private void finTraceRectangleSelection(object sender, MouseEventArgs e)
		{
			if (this.rectangleSelectionEnCours)
			{
				Rectangle rc = new Rectangle(new Point(this.RectangleSelection.Left - 1, this.RectangleSelection.Top - 1), new Size(this.RectangleSelection.Width + 2, this.RectangleSelection.Height + 2));
				this.rectangleSelectionEnCours = false;
				this.schema.MouseUp -= this.finTraceRectangleSelection;
				this.schema.MouseMove -= this.traceRectangleSelection;
				this.schema.Invalidate(rc, false);
				foreach (object obj in this.schema.Controls)
				{
					Control control = (Control)obj;
					if ((control.GetType().BaseType.Equals(typeof(Noeud)) || control.GetType().BaseType.Equals(typeof(Interconnexion)) || control.GetType() == typeof(Internet)) && this.RectangleSelection.IntersectsWith(new Rectangle(control.Location, control.Size)))
					{
						((Noeud)control).selectionner();
						control.Focus();
					}
				}
				this.RectangleSelection = new Rectangle(0, 0, 0, 0);
			}
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x0004E6BC File Offset: 0x0004D6BC
		private void schema_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.ToutDeSelectionner();
				switch (this.modeActif)
				{
				case Simulation.Mode.conceptionReseau:
					switch (this.etatConceptionActif)
					{
					case Simulation.EtatConception.consultationSchema:
						this.ToutDeSelectionner();
						this.rectangleSelectionEnCours = true;
						this.debutRectangleSelection = new Point(e.X, e.Y);
						this.schema.MouseUp += this.finTraceRectangleSelection;
						this.schema.MouseMove += this.traceRectangleSelection;
						break;
					case Simulation.EtatConception.creationCable:
						this.rb_fleche.Checked = true;
						this.rb_fleche_Click(null, null);
						this.ToutDeSelectionner();
						this.rectangleSelectionEnCours = true;
						this.debutRectangleSelection = new Point(e.X, e.Y);
						this.schema.MouseUp += this.finTraceRectangleSelection;
						this.schema.MouseMove += this.traceRectangleSelection;
						break;
					case Simulation.EtatConception.creationCableEnCours:
						this.AbandonCableEnCours();
						this.etatConceptionActif = Simulation.EtatConception.creationCable;
						break;
					}
					this.NoFocus();
					break;
				case Simulation.Mode.ethernet:
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060007FD RID: 2045 RVA: 0x0004E7EC File Offset: 0x0004D7EC
		public Simulation.TypeDeDemo TypeDemo
		{
			get
			{
				return this.typeDemo;
			}
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x0004E800 File Offset: 0x0004D800
		private void typeDemoChanged(object sender, EventArgs e)
		{
			this.okBis = false;
			this.PreparerBis();
			this.simulationEthernet = Simulation.TypeDeSimulationEthernet.circulationTrame;
			this.cb_demoEmission.Enabled = false;
			this.cb_ralenti.Enabled = false;
			this.cb_fullDuplex.Enabled = false;
			switch (this.cb_typeDemo.SelectedIndex)
			{
			case 0:
				this.typeDemo = Simulation.TypeDeDemo.pasAPas;
				return;
			case 1:
				this.typeDemo = Simulation.TypeDeDemo.automatique;
				this.cb_ralenti.Enabled = true;
				return;
			case 2:
				this.typeDemo = Simulation.TypeDeDemo.manuel;
				return;
			case 3:
				this.typeDemo = Simulation.TypeDeDemo.automatique;
				this.simulationEthernet = Simulation.TypeDeSimulationEthernet.trameReelle;
				if (this.nbSwitchEtStationsDemo() > 0)
				{
					this.cb_demoEmission.Enabled = true;
				}
				this.cb_ralenti.Enabled = true;
				this.cb_fullDuplex.Enabled = true;
				return;
			default:
				return;
			}
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x0004E8C8 File Offset: 0x0004D8C8
		public void SetTypeDemo(Simulation.TypeDeDemo p_demo, Simulation.TypeDeSimulationEthernet p_simul)
		{
			switch (p_demo)
			{
			case Simulation.TypeDeDemo.automatique:
				if (p_simul == Simulation.TypeDeSimulationEthernet.trameReelle)
				{
					this.cb_typeDemo.SelectedIndex = 3;
					return;
				}
				this.cb_typeDemo.SelectedIndex = 0;
				return;
			case Simulation.TypeDeDemo.pasAPas:
				this.cb_typeDemo.SelectedIndex = 1;
				return;
			case Simulation.TypeDeDemo.manuel:
				this.cb_typeDemo.SelectedIndex = 2;
				return;
			default:
				return;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000800 RID: 2048 RVA: 0x0004E924 File Offset: 0x0004D924
		// (set) Token: 0x06000801 RID: 2049 RVA: 0x0004E93C File Offset: 0x0004D93C
		public bool MessageReception
		{
			get
			{
				return this.cb_messageReception.Checked;
			}
			set
			{
				this.cb_messageReception.Checked = value;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000802 RID: 2050 RVA: 0x0004E958 File Offset: 0x0004D958
		// (set) Token: 0x06000803 RID: 2051 RVA: 0x0004E970 File Offset: 0x0004D970
		public bool DemoEmission
		{
			get
			{
				return this.cb_demoEmission.Checked;
			}
			set
			{
				this.cb_demoEmission.Checked = value;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000804 RID: 2052 RVA: 0x0004E98C File Offset: 0x0004D98C
		// (set) Token: 0x06000805 RID: 2053 RVA: 0x0004E9A4 File Offset: 0x0004D9A4
		public bool FullDuplex
		{
			get
			{
				return this.cb_fullDuplex.Checked;
			}
			set
			{
				this.cb_fullDuplex.Checked = value;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000806 RID: 2054 RVA: 0x0004E9C0 File Offset: 0x0004D9C0
		// (set) Token: 0x06000807 RID: 2055 RVA: 0x0004EA58 File Offset: 0x0004DA58
		public float CoefVitesseDemo
		{
			get
			{
				float result = 1f;
				switch (this.ModeActif)
				{
				case Simulation.Mode.ethernet:
					if (this.cb_ralenti.Checked)
					{
						result = (float)this.pref.TauxRalenti / 100f;
					}
					break;
				case Simulation.Mode.ip:
					if (this.cb_ralentiIp.Checked)
					{
						result = (float)this.pref.TauxRalenti / 100f;
					}
					break;
				case Simulation.Mode.appl:
					if (this.cb_ralentiAp.Checked)
					{
						result = (float)this.pref.TauxRalenti / 100f;
					}
					break;
				}
				return result;
			}
			set
			{
				switch (this.ModeActif)
				{
				case Simulation.Mode.ethernet:
					if (value == 1f)
					{
						this.cb_ralenti.Checked = false;
						return;
					}
					this.cb_ralenti.Checked = true;
					return;
				case Simulation.Mode.ip:
					if (value == 1f)
					{
						this.cb_ralentiIp.Checked = false;
						return;
					}
					this.cb_ralentiIp.Checked = true;
					return;
				default:
					return;
				}
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000808 RID: 2056 RVA: 0x0004EAC0 File Offset: 0x0004DAC0
		public Simulation.TypeDeSimulationEthernet SimulationEthernet
		{
			get
			{
				return this.simulationEthernet;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000809 RID: 2057 RVA: 0x0004EAD4 File Offset: 0x0004DAD4
		// (set) Token: 0x0600080A RID: 2058 RVA: 0x0004EAE8 File Offset: 0x0004DAE8
		public bool DeuxTrames
		{
			get
			{
				return this.deuxTrames;
			}
			set
			{
				this.deuxTrames = value;
			}
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x0004EAFC File Offset: 0x0004DAFC
		public void ReinitTimers()
		{
			this.timerTraceTrame.Start();
			Switch.TimerTampon.Start();
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x0004EB20 File Offset: 0x0004DB20
		private void bt_stopBis_Click(object sender, EventArgs e)
		{
			if (this.bt_stopBis.Text == "stop")
			{
				this.CacherTrame();
				this.tBis1.Stop();
				this.tBis2.Stop();
				this.tBis1.Tick -= this.tBis1_Tick;
				this.tBis2.Tick -= this.tBis2_Tick;
				this.bisEnCours = false;
				this.timerTraceTrame.Stop();
				foreach (Form form in base.OwnedForms)
				{
					if (form.GetType().BaseType.Equals(typeof(DemoDialogue)))
					{
						((DemoDialogue)form).Attente.Stop();
						((DemoDialogue)form).Close();
					}
					else if (form.GetType().Equals(typeof(DDialogPlusEmissionTrame)))
					{
						((DDialogPlusEmissionTrame)form).Attente.Stop();
						((DDialogPlusEmissionTrame)form).FixerPosition();
					}
				}
				Switch.TimerTampon.Stop();
				foreach (object obj in this.schema.Controls)
				{
					ElementReseau elementReseau = (ElementReseau)obj;
					if (elementReseau.GetType() == typeof(Hub))
					{
						((Hub)elementReseau).DelaiTransmissionTrame.Stop();
						((Hub)elementReseau).DelaiTransmissionDebutTrame.Stop();
						((Hub)elementReseau).DelaiTransmissionFinTrame.Stop();
					}
					else if (elementReseau.GetType() == typeof(Switch))
					{
						((Switch)elementReseau).DelaiTransmissionTrame.Stop();
						((Switch)elementReseau).DelaiTransmissionDebutTrame0.Stop();
						((Switch)elementReseau).DelaiTransmissionDebutTrame1.Stop();
						((Switch)elementReseau).DelaiTransmissionFinTrame0.Stop();
						((Switch)elementReseau).DelaiTransmissionFinTrame1.Stop();
						((Switch)elementReseau).DelaiReemissionTrameComplete.Stop();
						((Switch)elementReseau).DelaiReemissionTrameComplete1.Stop();
						((Switch)elementReseau).Ram.DelaiReemissionTrameComplete0.Stop();
						((Switch)elementReseau).Ram.DelaiReemissionTrameComplete1.Stop();
					}
				}
				this.attenteSecurite.Interval = 100;
				this.attenteSecurite.Start();
				this.attenteSecurite.Tick += this.suiteStopEthernet;
				return;
			}
			this.derniereSimulation.Sauvegarder();
			this.bisEnCours = true;
			if (this.derniereSimulation.DeuxEmissions)
			{
				if (!this.derniereSimulation.DeuxTramesEmises)
				{
					this.derniereSimulation.Trames[this.derniereSimulation.SecondeTrame].Envoyee = false;
				}
				this.derniereSimulation.PremiereCarte.mi_emettreTrame_Click(this, new EventArgs());
				this.derniereSimulation.SecondeCarte.mi_emettreTrame_Click(this, new EventArgs());
				if (this.derniereSimulation.PremiereTrame == 0)
				{
					this.derniereSimulation.Trames[this.derniereSimulation.PremiereTrame].DialogueEmission = this.dialogueEmissionTrame1;
					this.derniereSimulation.Trames[this.derniereSimulation.SecondeTrame].DialogueEmission = this.dialogueEmissionTrame2;
				}
				else
				{
					this.derniereSimulation.Trames[this.derniereSimulation.PremiereTrame].DialogueEmission = this.dialogueEmissionTrame2;
					this.derniereSimulation.Trames[this.derniereSimulation.SecondeTrame].DialogueEmission = this.dialogueEmissionTrame1;
				}
				this.tBis1.Interval = 2000;
				this.tBis1.Tick += this.tBis1_Tick;
				if (this.derniereSimulation.DeuxTramesEmises)
				{
					int num = (int)(this.derniereSimulation.Trames[this.derniereSimulation.SecondeTrame].MomentEmission - this.derniereSimulation.Trames[this.derniereSimulation.PremiereTrame].MomentEmission).TotalMilliseconds;
					this.tBis2.Interval = 2000 + num;
					this.tBis2.Tick += this.tBis2_Tick;
					this.tBis2.Start();
				}
				this.tBis1.Start();
				return;
			}
			this.tBis1 = new Timer();
			this.tBis1.Interval = 2000;
			this.tBis1.Tick += this.tBis1_Tick;
			this.tBis1.Start();
			this.derniereSimulation.Trames[this.derniereSimulation.PremiereTrame].Emetteur.mi_emettreTrame_Click(this, new EventArgs());
			this.derniereSimulation.Trames[this.derniereSimulation.PremiereTrame].DialogueEmission = this.dialogueEmissionTrame1;
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x0004F014 File Offset: 0x0004E014
		private void suiteStopEthernet(object sender, EventArgs e)
		{
			this.attenteSecurite.Stop();
			this.attenteSecurite.Tick -= this.suiteStopEthernet;
			foreach (object obj in this.schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				elementReseau.ReinitEthernet();
			}
			this.bt_stopBis.Text = "bis";
			this.bt_pauseReprise.ImageIndex = 0;
			this.bt_pauseReprise.Enabled = false;
			this.SetEnabledMenus(true);
			this.panelReglagesEthernet.Enabled = true;
			this.EtatEthernetActif = Simulation.EtatEthernet.attente;
			this.nbTrameCarte = (this.nbTransmissionsTotales = (this.nbTrameEnCours = (this.nbCollisionsDeuxPaires = 0)));
			this.deuxTrames = false;
			this.trameBienRecue = false;
			if (this.dialogueEmissionTrame1 != null)
			{
				this.dialogueEmissionTrame1.Close();
				this.dialogueEmissionTrame1 = null;
			}
			if (this.dialogueEmissionTrame2 != null)
			{
				this.dialogueEmissionTrame2.Close();
				this.dialogueEmissionTrame2 = null;
			}
			this.schema.Invalidate(true);
			this.reinitEthernetTramesCreees();
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x0004F158 File Offset: 0x0004E158
		public void SetEnabledMenus(bool actifs)
		{
			foreach (object obj in this.gereDoc.MenuItems)
			{
				MenuItem menuItem = (MenuItem)obj;
				menuItem.Enabled = actifs;
			}
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x0004F1C4 File Offset: 0x0004E1C4
		public void BloquerReglages()
		{
			this.panelReglagesIp.Enabled = false;
			this.panelReglagesAp.Enabled = false;
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x0004F1EC File Offset: 0x0004E1EC
		public void LibererReglages()
		{
			this.panelReglagesIp.Enabled = true;
			this.panelReglagesAp.Enabled = true;
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x0004F214 File Offset: 0x0004E214
		public void PreparerSimulation()
		{
			this.etatEthernetActif = Simulation.EtatEthernet.simulationEnPreparation;
			this.panelReglagesEthernet.Enabled = false;
			this.SetEnabledMenus(false);
			this.tramesCreees = new ArrayList();
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x0004F248 File Offset: 0x0004E248
		public void DemarrerSimulation()
		{
			foreach (FormConfig formConfig in base.OwnedForms)
			{
				formConfig.Close();
			}
			foreach (object obj in this.schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				elementReseau.InstallerGestionEvenements();
			}
			this.ReinitTimers();
			this.nbCollisionsDeuxPaires = 0;
			this.etatEthernetActif = Simulation.EtatEthernet.simulationEnCours;
			this.nbTransmissionsTotales = 0;
			this.nbTrameCarte = 0;
			this.nbTrameEnCours = 0;
			this.bt_stopBis.Enabled = true;
			this.bt_stopBis.Text = "stop";
			this.okBis = true;
			if (!this.bisEnCours)
			{
				this.derniereSimulation.InitTablesSwitch();
				this.derniereSimulation.initDelaisReemission();
				return;
			}
			this.derniereSimulation.RelireTablesSwitch();
			this.derniereSimulation.ResetDelaisReemission();
		}

		// Token: 0x17000149 RID: 329
		// (set) Token: 0x06000813 RID: 2067 RVA: 0x0004F360 File Offset: 0x0004E360
		public bool TrameBienRecue
		{
			set
			{
				this.trameBienRecue = value;
			}
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x0004F374 File Offset: 0x0004E374
		public void decrementerCollisionsDeuxPaires(CarteReseau carte)
		{
			this.nbCollisionsDeuxPaires--;
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x0004F390 File Offset: 0x0004E390
		public void PreparerStop()
		{
			this.bt_stopBis.Text = "stop";
			this.bt_stopBis.Enabled = false;
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x0004F3BC File Offset: 0x0004E3BC
		public void PreparerBis()
		{
			this.bt_stopBis.Text = "bis";
			if (!this.debugEncours)
			{
				this.bt_stopBis.Enabled = this.okBis;
				return;
			}
			this.bt_stopBis.Enabled = true;
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000817 RID: 2071 RVA: 0x0004F400 File Offset: 0x0004E400
		// (set) Token: 0x06000818 RID: 2072 RVA: 0x0004F414 File Offset: 0x0004E414
		public bool OkBis
		{
			get
			{
				return this.okBis;
			}
			set
			{
				this.okBis = value;
			}
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x0004F428 File Offset: 0x0004E428
		public void ArreterSimulation(CarteReseau unEmetteur)
		{
			this.CacherTrame();
			foreach (object obj in this.schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				elementReseau.DesinstallerGestionEvenements();
			}
			if (!this.trameBienRecue && this.MessageReception && !this.deuxTrames)
			{
				MessageBox.Show("Trame perdue !", "Erreur");
			}
			if (this.deuxTrames)
			{
				unEmetteur.ModeCableSimple();
			}
			this.bt_stopBis.Text = "bis";
			this.bt_pauseReprise.ImageIndex = 0;
			this.bt_pauseReprise.Enabled = false;
			this.bisEnCours = false;
			this.SetEnabledMenus(true);
			this.panelReglagesEthernet.Enabled = true;
			this.EtatEthernetActif = Simulation.EtatEthernet.attente;
			this.nbTrameCarte = (this.nbTransmissionsTotales = (this.nbTrameEnCours = 0));
			if (this.dialogueEmissionTrame1 != null)
			{
				this.dialogueEmissionTrame1.Close();
				this.dialogueEmissionTrame1 = null;
			}
			if (this.dialogueEmissionTrame2 != null)
			{
				this.dialogueEmissionTrame2.Close();
				this.dialogueEmissionTrame2 = null;
			}
			this.reinitEthernetTramesCreees();
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x0600081A RID: 2074 RVA: 0x0004F56C File Offset: 0x0004E56C
		// (set) Token: 0x0600081B RID: 2075 RVA: 0x0004F580 File Offset: 0x0004E580
		public Hashtable Noeuds
		{
			get
			{
				return this.noeuds;
			}
			set
			{
				this.noeuds = value;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x0600081C RID: 2076 RVA: 0x0004F594 File Offset: 0x0004E594
		public SortedList NoeudsDemo
		{
			get
			{
				return this.noeudsDemo;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x0600081D RID: 2077 RVA: 0x0004F5A8 File Offset: 0x0004E5A8
		// (set) Token: 0x0600081E RID: 2078 RVA: 0x0004F5BC File Offset: 0x0004E5BC
		public SortedList NoeudsNonDemo
		{
			get
			{
				return this.noeudsNonDemo;
			}
			set
			{
				this.noeudsNonDemo = value;
			}
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x0004F5D0 File Offset: 0x0004E5D0
		private void chargerNoeudsDemo()
		{
			this.noeudsDemo.Clear();
			foreach (object obj in this.noeuds.Values)
			{
				Noeud noeud = (Noeud)obj;
				if (!this.noeudsNonDemo.Contains(noeud.NomNoeud))
				{
					this.noeudsDemo.Add(noeud.NomNoeud, noeud);
				}
			}
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x0004F664 File Offset: 0x0004E664
		public void setLibelleBt_noeudsDemo()
		{
			int num = this.noeuds.Count - this.noeudsNonDemo.Count;
			if (num > 1)
			{
				this.bt_noeudsDemo.Text = num.ToString() + " noeuds tracés";
				return;
			}
			if (num == 1)
			{
				this.bt_noeudsDemo.Text = num.ToString() + " noeud tracé";
				return;
			}
			this.bt_noeudsDemo.Text = "aucun noeud tracé";
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x0004F6DC File Offset: 0x0004E6DC
		private void bt_noeudsDemo_Click(object sender, EventArgs e)
		{
			this.okBis = false;
			this.PreparerBis();
			this.chargerNoeudsDemo();
			NoeudsDemoDialogue noeudsDemoDialogue = new NoeudsDemoDialogue(this.noeudsDemo, this.noeudsNonDemo, this);
			noeudsDemoDialogue.ShowDialog();
			this.setLibelleBt_noeudsDemo();
			if (this.simulationEthernet == Simulation.TypeDeSimulationEthernet.trameReelle)
			{
				if (this.nbSwitchEtStationsDemo() > 0)
				{
					this.cb_demoEmission.Enabled = true;
					return;
				}
				this.cb_demoEmission.Checked = false;
				this.cb_demoEmission.Enabled = false;
			}
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x0004F754 File Offset: 0x0004E754
		private int nbSwitchEtStationsDemo()
		{
			this.chargerNoeudsDemo();
			int num = 0;
			foreach (object obj in this.noeudsDemo.Values)
			{
				Noeud noeud = (Noeud)obj;
				if (noeud.GetType() == typeof(Station) || noeud.GetType() == typeof(Switch))
				{
					num++;
				}
			}
			this.noeudsDemo.Clear();
			return num;
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000823 RID: 2083 RVA: 0x0004F7F4 File Offset: 0x0004E7F4
		// (set) Token: 0x06000824 RID: 2084 RVA: 0x0004F808 File Offset: 0x0004E808
		public Control AdrMacAttente
		{
			get
			{
				return this.adrMacAttente;
			}
			set
			{
				this.adrMacAttente = value;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000825 RID: 2085 RVA: 0x0004F81C File Offset: 0x0004E81C
		// (set) Token: 0x06000826 RID: 2086 RVA: 0x0004F830 File Offset: 0x0004E830
		public int NbTrameCarte
		{
			get
			{
				return this.nbTrameCarte;
			}
			set
			{
				this.nbTrameCarte = value;
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000827 RID: 2087 RVA: 0x0004F844 File Offset: 0x0004E844
		// (set) Token: 0x06000828 RID: 2088 RVA: 0x0004F858 File Offset: 0x0004E858
		public int NbTransmissionsTotales
		{
			get
			{
				return this.nbTransmissionsTotales;
			}
			set
			{
				this.nbTransmissionsTotales = value;
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000829 RID: 2089 RVA: 0x0004F86C File Offset: 0x0004E86C
		// (set) Token: 0x0600082A RID: 2090 RVA: 0x0004F880 File Offset: 0x0004E880
		public int NbTrameEnCours
		{
			get
			{
				return this.nbTrameEnCours;
			}
			set
			{
				this.nbTrameEnCours = value;
			}
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x0004F894 File Offset: 0x0004E894
		public void DecrementerNbTramesEnCours(string avirer)
		{
			this.nbTrameEnCours--;
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x0004F8B0 File Offset: 0x0004E8B0
		public void IncrementerNbTramesEnCours(string avirer)
		{
			this.nbTrameEnCours++;
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x0600082D RID: 2093 RVA: 0x0004F8CC File Offset: 0x0004E8CC
		// (set) Token: 0x0600082E RID: 2094 RVA: 0x0004F8E0 File Offset: 0x0004E8E0
		public EmissionTrameDialogue DialogueEmissionTrame1
		{
			get
			{
				return this.dialogueEmissionTrame1;
			}
			set
			{
				this.dialogueEmissionTrame1 = value;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x0600082F RID: 2095 RVA: 0x0004F8F4 File Offset: 0x0004E8F4
		// (set) Token: 0x06000830 RID: 2096 RVA: 0x0004F908 File Offset: 0x0004E908
		public EmissionTrameDialogue DialogueEmissionTrame2
		{
			get
			{
				return this.dialogueEmissionTrame2;
			}
			set
			{
				this.dialogueEmissionTrame2 = value;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000831 RID: 2097 RVA: 0x0004F91C File Offset: 0x0004E91C
		// (set) Token: 0x06000832 RID: 2098 RVA: 0x0004F930 File Offset: 0x0004E930
		public Cable NouveauCable
		{
			get
			{
				return this.nouveauCable;
			}
			set
			{
				this.nouveauCable = value;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000833 RID: 2099 RVA: 0x0004F944 File Offset: 0x0004E944
		// (set) Token: 0x06000834 RID: 2100 RVA: 0x0004F958 File Offset: 0x0004E958
		public CableEnCours TraceNouveauCable
		{
			get
			{
				return this.traceNouveauCable;
			}
			set
			{
				this.traceNouveauCable = value;
			}
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x0004F96C File Offset: 0x0004E96C
		public void AbandonCableEnCours()
		{
			this.nouveauCable.Origine.Deconnecter();
			this.traceNouveauCable.Supprimer();
			this.gereDoc.FaireAction(ActionDocument.modifier);
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x0004F9A4 File Offset: 0x0004E9A4
		public void CreerCable(PointConnexion origine)
		{
			this.nouveauCable = new Cable(this);
			this.nouveauCable.DebuterLiaison(origine);
			origine.Lien = this.nouveauCable;
			origine.BackColor = this.pref.CouleurConnexionConception;
			this.traceNouveauCable = new CableEnCours(this);
			this.traceNouveauCable.A = origine.Centre;
			this.traceNouveauCable.B = new Point(origine.Centre.X, origine.Centre.Y);
			this.schema.Controls.Add(this.traceNouveauCable);
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x0004FA48 File Offset: 0x0004EA48
		public void TerminerCable(PointConnexion extremite)
		{
			this.nouveauCable.terminerLiaison(extremite);
			this.schema.Controls.Add(this.nouveauCable);
			extremite.Lien = this.nouveauCable;
			this.schema.Controls.Remove(this.traceNouveauCable);
			Graphics graphics = this.schema.CreateGraphics();
			this.traceNouveauCable.Effacer(graphics);
			this.nouveauCable.Tracer(graphics);
			graphics.Dispose();
			this.traceNouveauCable = null;
			this.nouveauCable = null;
			extremite.BackColor = this.pref.CouleurConnexionConception;
			this.gereDoc.FaireAction(ActionDocument.modifier);
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x0004FAF0 File Offset: 0x0004EAF0
		public void DeplacerCable(PointConnexion extremite)
		{
			this.schema.Controls.Remove(extremite.Lien);
			this.DeconfigurerClientInternet(extremite.Lien);
			this.nouveauCable = extremite.Lien;
			if (this.nouveauCable.Origine == extremite)
			{
				this.nouveauCable.Origine = this.nouveauCable.Extremite;
			}
			this.nouveauCable.Extremite = null;
			extremite.Lien = null;
			extremite.BackColor = this.schema.BackColor;
			this.traceNouveauCable = new CableEnCours(this);
			this.traceNouveauCable.A = this.nouveauCable.Origine.Centre;
			this.traceNouveauCable.B = new Point(extremite.Centre.X, extremite.Centre.Y);
			this.schema.Controls.Add(this.traceNouveauCable);
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x0004FBDC File Offset: 0x0004EBDC
		public void SupprimerCable(Cable c)
		{
			this.gereDoc.FaireAction(ActionDocument.modifier);
			this.schema.Controls.Remove(c);
			this.DeconfigurerClientInternet(c);
			c.Deconnecter();
			Graphics graphics = this.schema.CreateGraphics();
			c.Effacer(graphics);
			graphics.Dispose();
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x0004FC30 File Offset: 0x0004EC30
		public void DeconfigurerClientInternet(Cable c)
		{
			CarteAccesDistant carteAccesDistant = null;
			bool flag = false;
			if (c.Origine.GetType() == typeof(CarteAccesDistant))
			{
				carteAccesDistant = (CarteAccesDistant)c.Origine;
				if (this.IsAdrReseauInternet(carteAccesDistant.Ip.Adresse))
				{
					flag = true;
				}
			}
			else if (c.Extremite.GetType() == typeof(CarteAccesDistant))
			{
				carteAccesDistant = (CarteAccesDistant)c.Extremite;
				if (this.IsAdrReseauInternet(carteAccesDistant.Ip.Adresse))
				{
					flag = true;
				}
			}
			if (flag)
			{
				Ip_station ip = ((Station)carteAccesDistant.NoeudAttache).Ip;
				ip.MajRoutesCarteSupprimee(carteAccesDistant);
				carteAccesDistant.Ip.Adresse = new Ip_adresse("0.0.0.0");
				carteAccesDistant.Ip.Masque = new Ip_masque("0.0.0.0");
			}
		}

		// Token: 0x17000156 RID: 342
		// (set) Token: 0x0600083B RID: 2107 RVA: 0x0004FCF8 File Offset: 0x0004ECF8
		public int NbHubs
		{
			set
			{
				this.nbHubs = value;
			}
		}

		// Token: 0x17000157 RID: 343
		// (set) Token: 0x0600083C RID: 2108 RVA: 0x0004FD0C File Offset: 0x0004ED0C
		public int Nbswitchs
		{
			set
			{
				this.nbSwitchs = value;
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x0600083E RID: 2110 RVA: 0x0004FD34 File Offset: 0x0004ED34
		// (set) Token: 0x0600083D RID: 2109 RVA: 0x0004FD20 File Offset: 0x0004ED20
		public int NbCartesReseau
		{
			get
			{
				return this.nbCartesReseau;
			}
			set
			{
				this.nbCartesReseau = value;
			}
		}

		// Token: 0x17000159 RID: 345
		// (set) Token: 0x0600083F RID: 2111 RVA: 0x0004FD48 File Offset: 0x0004ED48
		public int NbStations
		{
			set
			{
				this.nbStations = value;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000840 RID: 2112 RVA: 0x0004FD5C File Offset: 0x0004ED5C
		public Param Pref
		{
			get
			{
				return this.pref;
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000841 RID: 2113 RVA: 0x0004FD70 File Offset: 0x0004ED70
		public Panel Schema
		{
			get
			{
				return this.schema;
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000842 RID: 2114 RVA: 0x0004FD84 File Offset: 0x0004ED84
		// (set) Token: 0x06000843 RID: 2115 RVA: 0x0004FD98 File Offset: 0x0004ED98
		public int NbCollisionsDeuxPaires
		{
			get
			{
				return this.nbCollisionsDeuxPaires;
			}
			set
			{
				this.nbCollisionsDeuxPaires = value;
			}
		}

		// Token: 0x1700015D RID: 349
		// (set) Token: 0x06000844 RID: 2116 RVA: 0x0004FDAC File Offset: 0x0004EDAC
		public bool Rb_cableChecked
		{
			set
			{
				this.rb_cable.Checked = value;
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000845 RID: 2117 RVA: 0x0004FDC8 File Offset: 0x0004EDC8
		// (set) Token: 0x06000846 RID: 2118 RVA: 0x0004FDDC File Offset: 0x0004EDDC
		public ArrayList NoeudsSelectionnes
		{
			get
			{
				return this.noeudsSelectionnes;
			}
			set
			{
				this.noeudsSelectionnes = value;
			}
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x0004FDF0 File Offset: 0x0004EDF0
		public void SupprimerNoeudsSelectionnes()
		{
			foreach (object obj in this.noeudsSelectionnes)
			{
				Noeud noeud = (Noeud)obj;
				noeud.supprimerNoeud();
			}
			this.noeudsSelectionnes.Clear();
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000848 RID: 2120 RVA: 0x0004FE60 File Offset: 0x0004EE60
		public Timer TimerTraceTrame
		{
			get
			{
				return this.timerTraceTrame;
			}
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x0004FE74 File Offset: 0x0004EE74
		public bool OkCollision(CarteReseau c)
		{
			ArrayList arrayList = new ArrayList();
			if (this.dialogueEmissionTrame1 == null)
			{
				return c.EstRelie(this.dialogueEmissionTrame2.Emetteur, ref arrayList);
			}
			return c.EstRelie(this.dialogueEmissionTrame1.Emetteur, ref arrayList);
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x0004FEB8 File Offset: 0x0004EEB8
		private void mi_options_Click(object sender, EventArgs e)
		{
			bool cablesVirtuelIp = this.pref.CablesVirtuelIp;
			this.pref.ShowDialog();
			foreach (object obj in this.schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				elementReseau.ModifierCouleurConnexions();
			}
			this.schema.Invalidate(true);
			this.PrendreEnCompteParams(cablesVirtuelIp);
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x0004FF4C File Offset: 0x0004EF4C
		public bool NoBouclesHubGeneral()
		{
			foreach (object obj in this.schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType().BaseType == typeof(Interconnexion) && !this.NoBouclesHub((Noeud)elementReseau))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600084C RID: 2124 RVA: 0x0004FFDC File Offset: 0x0004EFDC
		public bool NoBouclesHub(Noeud n)
		{
			return !this.existeCircuit(n, new ArrayList(), null);
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x0004FFFC File Offset: 0x0004EFFC
		private bool existeCircuit(Noeud n, ArrayList visites, PointConnexion provenance)
		{
			bool flag;
			if (n.GetType() == typeof(Station))
			{
				flag = false;
			}
			else
			{
				int num = 0;
				if (visites.Contains(n))
				{
					flag = true;
				}
				else
				{
					flag = false;
					visites.Add(n);
					while (num < n.Controls.Count && !flag)
					{
						Port port = (Port)n.Controls[num];
						if (port != provenance && port.EtatConnexion == PointConnexion.EtatsConnexion.actif)
						{
							flag = this.existeCircuit(port.Lien.Oppose(port).NoeudAttache, visites, port.Lien.Oppose(port));
						}
						num++;
					}
				}
			}
			return flag;
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x0600084E RID: 2126 RVA: 0x00050094 File Offset: 0x0004F094
		// (set) Token: 0x0600084F RID: 2127 RVA: 0x000500A8 File Offset: 0x0004F0A8
		public ArrayList EnsHub
		{
			get
			{
				return this.ensHub;
			}
			set
			{
				this.ensHub = value;
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06000850 RID: 2128 RVA: 0x000500BC File Offset: 0x0004F0BC
		public ArrayList SommetsSwitch
		{
			get
			{
				return this.sommetsSwitch;
			}
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x000500D0 File Offset: 0x0004F0D0
		private void construireSommetsSwitch()
		{
			this.sommetsSwitch = new ArrayList();
			this.successeursSwitch = new SortedList();
			this.aretesGrapheSwitch = new ArrayList();
			foreach (object obj in this.schema.Controls)
			{
				Control control = (Control)obj;
				if (control.GetType() == typeof(Switch) && ((Switch)control).SpanningTree && ((Switch)control).EnFonction)
				{
					this.sommetsSwitch.Add(control);
					this.successeursSwitch.Add(control.GetHashCode(), new ArrayList());
				}
			}
			foreach (object obj2 in this.sommetsSwitch)
			{
				Switch @switch = (Switch)obj2;
				@switch.DebloquerPorts();
			}
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x000501FC File Offset: 0x0004F1FC
		private void construireGrapheSwitch()
		{
			this.construireSommetsSwitch();
			this.construireSuccesseursSwitch();
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x00050218 File Offset: 0x0004F218
		private void construireSuccesseursSwitch()
		{
			for (int i = 0; i < this.sommetsSwitch.Count; i++)
			{
				for (int j = i + 1; j < this.sommetsSwitch.Count; j++)
				{
					this.calculAretesSwitch((Switch)this.sommetsSwitch[i], (Switch)this.sommetsSwitch[j]);
				}
			}
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x00050280 File Offset: 0x0004F280
		private void calculAretesSwitch(Switch a, Switch b)
		{
			foreach (object obj in a.Controls)
			{
				PortSwitch portSwitch = (PortSwitch)obj;
				if (portSwitch.EtatConnexion == PointConnexion.EtatsConnexion.actif)
				{
					foreach (object obj2 in b.Controls)
					{
						PortSwitch portSwitch2 = (PortSwitch)obj2;
						if (portSwitch2.EtatConnexion == PointConnexion.EtatsConnexion.actif)
						{
							ArrayList arrayList = new ArrayList();
							arrayList.Add(portSwitch);
							if (portSwitch.EstConnecte(portSwitch2, ref arrayList, false))
							{
								Simulation.AreteSwitch value = new Simulation.AreteSwitch(a, b, portSwitch, portSwitch2, arrayList.Count);
								((ArrayList)this.successeursSwitch[a.GetHashCode()]).Add(b);
								((ArrayList)this.successeursSwitch[b.GetHashCode()]).Add(a);
								this.aretesGrapheSwitch.Add(value);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x000503D8 File Offset: 0x0004F3D8
		public void SpanningTree()
		{
			this.construireGrapheSwitch();
			ArrayList arrayList = (ArrayList)this.sommetsSwitch.Clone();
			while (arrayList.Count != 0)
			{
				ArrayList arrayList2 = new ArrayList();
				Switch @switch = (Switch)arrayList[0];
				arrayList.RemoveAt(0);
				arrayList2.Add(@switch);
				ArrayList arrayList3 = new ArrayList();
				foreach (object obj in arrayList)
				{
					Switch switch2 = (Switch)obj;
					if (this.existeChemin(switch2, @switch, new ArrayList()))
					{
						arrayList2.Add(switch2);
						arrayList3.Add(switch2);
					}
				}
				foreach (object obj2 in arrayList3)
				{
					Switch obj3 = (Switch)obj2;
					arrayList.Remove(obj3);
				}
				this.arbreMinimum(arrayList2);
			}
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x0005050C File Offset: 0x0004F50C
		private void arbreMinimum(ArrayList composante)
		{
			ArrayList arrayList = (ArrayList)composante.Clone();
			ArrayList arrayList2 = new ArrayList();
			ArrayList arrayList3 = (ArrayList)this.aretesGrapheSwitch.Clone();
			arrayList2.Add(composante[0]);
			arrayList.RemoveAt(0);
			ArrayList arrayList4 = new ArrayList();
			if (this.connecter(composante, this.aretesGrapheSwitch, (ArrayList)arrayList2.Clone(), (ArrayList)arrayList.Clone(), (ArrayList)arrayList3.Clone(), arrayList4))
			{
				this.epurerAretes(arrayList4, composante);
			}
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x00050590 File Offset: 0x0004F590
		private bool connecter(ArrayList composante, ArrayList aretesGraphe, ArrayList compo1, ArrayList compo2, ArrayList aretesDispo, ArrayList aretes)
		{
			if (aretesDispo.Count == 0 && compo2.Count > 0)
			{
				return false;
			}
			if (compo2.Count == 0)
			{
				return this.okEpurerAretes(composante, aretesGraphe, aretes);
			}
			bool flag = false;
			Simulation.AreteSwitch areteSwitch = this.areteMiniDeVers(compo1, aretesDispo, compo2, ref flag);
			aretesDispo.Remove(areteSwitch);
			if (flag)
			{
				compo1.Add(areteSwitch.Depart);
				compo2.Remove(areteSwitch.Depart);
			}
			else
			{
				compo1.Add(areteSwitch.Arrivee);
				compo2.Remove(areteSwitch.Arrivee);
			}
			aretes.Add(areteSwitch);
			if (!this.connecter(composante, aretesGraphe, (ArrayList)compo1.Clone(), (ArrayList)compo2.Clone(), (ArrayList)aretesDispo.Clone(), aretes))
			{
				aretes.Remove(areteSwitch);
				if (flag)
				{
					compo1.Remove(areteSwitch.Depart);
					compo2.Add(areteSwitch.Depart);
				}
				else
				{
					compo1.Remove(areteSwitch.Arrivee);
					compo2.Add(areteSwitch.Arrivee);
				}
				return this.connecter(composante, aretesGraphe, (ArrayList)compo1.Clone(), (ArrayList)compo2.Clone(), (ArrayList)aretesDispo.Clone(), aretes);
			}
			if (this.okEpurerAretes(composante, aretesGraphe, aretes))
			{
				return true;
			}
			aretes.Remove(areteSwitch);
			if (flag)
			{
				compo1.Remove(areteSwitch.Depart);
				compo2.Add(areteSwitch.Depart);
			}
			else
			{
				compo1.Remove(areteSwitch.Arrivee);
				compo2.Add(areteSwitch.Arrivee);
			}
			return this.connecter(composante, aretesGraphe, (ArrayList)compo1.Clone(), (ArrayList)compo2.Clone(), (ArrayList)aretesDispo.Clone(), aretes);
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x0005073C File Offset: 0x0004F73C
		private bool okEpurerAretes(ArrayList composante, ArrayList aretesGraphe, ArrayList aretesConservees)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in aretesGraphe)
			{
				Simulation.AreteSwitch areteSwitch = (Simulation.AreteSwitch)obj;
				if (composante.Contains(areteSwitch.Depart) && !aretesConservees.Contains(areteSwitch))
				{
					arrayList.Add(areteSwitch);
				}
			}
			ArrayList arrayList2 = new ArrayList();
			foreach (object obj2 in aretesConservees)
			{
				Simulation.AreteSwitch areteSwitch2 = (Simulation.AreteSwitch)obj2;
				if (!arrayList2.Contains(areteSwitch2.PortDepart))
				{
					arrayList2.Add(areteSwitch2.PortDepart);
				}
				if (!arrayList2.Contains(areteSwitch2.PortArrivee))
				{
					arrayList2.Add(areteSwitch2.PortArrivee);
				}
			}
			foreach (object obj3 in arrayList)
			{
				Simulation.AreteSwitch areteSwitch3 = (Simulation.AreteSwitch)obj3;
				if (areteSwitch3.PortDepart.Lien.Oppose(areteSwitch3.PortDepart) == areteSwitch3.PortArrivee)
				{
					if (arrayList2.Contains(areteSwitch3.PortDepart))
					{
						return false;
					}
					if (arrayList2.Contains(areteSwitch3.PortArrivee))
					{
						return false;
					}
				}
				else if (arrayList2.Contains(areteSwitch3.PortDepart))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x00050900 File Offset: 0x0004F900
		private void epurerAretes(ArrayList aretesConservees, ArrayList sommetsComposante)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.aretesGrapheSwitch)
			{
				Simulation.AreteSwitch areteSwitch = (Simulation.AreteSwitch)obj;
				if (sommetsComposante.Contains(areteSwitch.Depart) && !aretesConservees.Contains(areteSwitch))
				{
					arrayList.Add(areteSwitch);
				}
			}
			foreach (object obj2 in arrayList)
			{
				Simulation.AreteSwitch areteSwitch2 = (Simulation.AreteSwitch)obj2;
				if (areteSwitch2.PortDepart.Lien.Oppose(areteSwitch2.PortDepart) == areteSwitch2.PortArrivee)
				{
					areteSwitch2.PortDepart.Bloquer();
					areteSwitch2.PortArrivee.Bloquer();
				}
				else
				{
					areteSwitch2.PortDepart.Bloquer();
				}
			}
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x00050A14 File Offset: 0x0004FA14
		private Simulation.AreteSwitch areteMiniDeVers(ArrayList ensDepart, ArrayList aretesDispo, ArrayList ensArrivee, ref bool inverse)
		{
			int num = int.MaxValue;
			Simulation.AreteSwitch result = null;
			foreach (object obj in aretesDispo)
			{
				Simulation.AreteSwitch areteSwitch = (Simulation.AreteSwitch)obj;
				if (ensDepart.Contains(areteSwitch.Depart))
				{
					if (ensArrivee.Contains(areteSwitch.Arrivee) && areteSwitch.Poids < num)
					{
						inverse = false;
						num = areteSwitch.Poids;
						result = areteSwitch;
					}
				}
				else if (ensArrivee.Contains(areteSwitch.Depart) && ensDepart.Contains(areteSwitch.Arrivee) && areteSwitch.Poids < num)
				{
					inverse = true;
					num = areteSwitch.Poids;
					result = areteSwitch;
				}
			}
			return result;
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x00050AE0 File Offset: 0x0004FAE0
		private bool existeChemin(Switch a, Switch b, ArrayList visites)
		{
			if (visites.Contains(a))
			{
				return false;
			}
			bool flag = false;
			ArrayList arrayList = (ArrayList)this.successeursSwitch[a.GetHashCode()];
			if (arrayList.Contains(b))
			{
				return true;
			}
			visites.Add(a);
			int num = 0;
			int num2 = arrayList.Count;
			while (num2 > 0 && !flag)
			{
				Switch a2 = (Switch)arrayList[num];
				num++;
				num2--;
				flag = this.existeChemin(a2, b, visites);
			}
			return flag;
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x0600085C RID: 2140 RVA: 0x00050B60 File Offset: 0x0004FB60
		public GestionDocument GereDoc
		{
			get
			{
				return this.gereDoc;
			}
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x00050B74 File Offset: 0x0004FB74
		private void timerModifDocConverti_Tick(object sender, EventArgs e)
		{
			this.timerModifDocConverti.Stop();
			this.gereDoc.FaireAction(ActionDocument.modifier);
			this.timerModifDocConverti = null;
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x00050BA0 File Offset: 0x0004FBA0
		private bool ouvrirDoc(string nomFichier)
		{
			this.nouveauDoc();
			bool result;
			try
			{
				bool flag = false;
				bool flag2 = false;
				this.ChargerXml(nomFichier, ref flag, ref flag2);
				if (flag)
				{
					if (flag2)
					{
						this.setTitre(nomFichier);
						this.timerModifDocConverti = new Timer();
						this.timerModifDocConverti.Interval = 300;
						this.timerModifDocConverti.Tick += this.timerModifDocConverti_Tick;
						MessageBox.Show("Enregistrez le réseau pour rendre la conversion définitive," + Environment.NewLine + "choisissez enregistrer sous pour conserver l'ancienne version.", "Conversion terminée");
						this.timerModifDocConverti.Start();
						result = true;
					}
					else
					{
						this.nouveauDoc();
						this.gereDoc.AnnulerOuvrir();
						result = false;
					}
				}
				else
				{
					this.setTitre(nomFichier);
					result = true;
				}
			}
			catch
			{
				MessageBox.Show("Problème pendant le chargement !");
				this.nouveauDoc();
				this.gereDoc.AnnulerOuvrir();
				result = false;
			}
			return result;
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x00050C90 File Offset: 0x0004FC90
		public static void elementXmlSuivant(XmlTextReader reader, bool getValeur)
		{
			while (reader.Read() && reader.NodeType != XmlNodeType.Element)
			{
			}
			if (!reader.HasAttributes && getValeur)
			{
				reader.Read();
			}
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x00050CC0 File Offset: 0x0004FCC0
		private void chargerNoeudXml(XmlTextReader reader, out string p_nom, out int p_id, out int p_nbPtsConn, out Point p_pos, out Point p_posDemo)
		{
			reader.MoveToNextAttribute();
			p_nom = reader.Value;
			Simulation.elementXmlSuivant(reader, true);
			p_id = int.Parse(reader.Value);
			Simulation.elementXmlSuivant(reader, true);
			p_nbPtsConn = int.Parse(reader.Value);
			Simulation.elementXmlSuivant(reader, true);
			int x = int.Parse(reader.Value);
			Simulation.elementXmlSuivant(reader, true);
			int y = int.Parse(reader.Value);
			p_pos = new Point(x, y);
			Simulation.elementXmlSuivant(reader, true);
			int x2 = int.Parse(reader.Value);
			Simulation.elementXmlSuivant(reader, true);
			int y2 = int.Parse(reader.Value);
			p_posDemo = new Point(x2, y2);
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x00050D64 File Offset: 0x0004FD64
		private void chargerPointConnexionXml(XmlTextReader reader, out PointConnexion pt)
		{
			pt = new PointConnexion();
			Simulation.elementXmlSuivant(reader, true);
			int num = int.Parse(reader.Value);
			Simulation.elementXmlSuivant(reader, true);
			int num2 = int.Parse(reader.Value);
			bool flag = false;
			int num3 = 1;
			while (!flag)
			{
				Noeud noeud = (Noeud)this.schema.Controls[num3];
				if (noeud.IdNoeud == num)
				{
					flag = true;
					pt = (PointConnexion)noeud.Controls[num2 - 1];
				}
				else
				{
					num3++;
				}
			}
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x00050DE8 File Offset: 0x0004FDE8
		private bool okNumVersionReseau(string nomFichier, XmlTextReader reader, ref bool conversionOk)
		{
			string value = reader.Value;
			bool result = true;
			string[] array = value.Split(new char[]
			{
				'.'
			});
			int num = int.Parse(array[0]) * 100 + int.Parse(array[1]);
			if (num < this.pref.numVersionDocumentsSimulateur)
			{
				result = false;
				if (MessageBox.Show("Ce réseau a été créé avec une version antérieure du logiciel," + Environment.NewLine + "souhaitez-vous le convertir ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					return result;
				}
				reader.Close();
				try
				{
					ConvertisseurReseau.Convertir(nomFichier, num, this);
					conversionOk = true;
					return result;
				}
				catch
				{
					conversionOk = false;
					MessageBox.Show("Erreur pendant la conversion du réseau !", "Erreur");
					return false;
				}
			}
			if (num > this.pref.numVersionDocumentsSimulateur)
			{
				result = false;
				MessageBox.Show("Ce réseau a été créé avec une version supérieure du logiciel," + Environment.NewLine + "il ne peut pas être ouvert avec celle-ci.");
				this.gereDoc.FaireAction(ActionDocument.nouveau);
			}
			return result;
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x00050EE0 File Offset: 0x0004FEE0
		public void ChargerXml(string nomFichier, ref bool convertir, ref bool conversionOk)
		{
			Hashtable hashtable = new Hashtable();
			SortedList sortedList = new SortedList();
			XmlTextReader xmlTextReader = new XmlTextReader(nomFichier);
			Simulation.elementXmlSuivant(xmlTextReader, false);
			if (xmlTextReader.LocalName != "simRes")
			{
				throw new Exception();
			}
			xmlTextReader.MoveToNextAttribute();
			if (xmlTextReader.LocalName != "version")
			{
				throw new Exception();
			}
			if (this.okNumVersionReseau(nomFichier, xmlTextReader, ref conversionOk))
			{
				xmlTextReader.MoveToNextAttribute();
				int num = int.Parse(xmlTextReader.Value);
				Simulation.elementXmlSuivant(xmlTextReader, true);
				int num2 = int.Parse(xmlTextReader.Value);
				Simulation.elementXmlSuivant(xmlTextReader, true);
				int num3 = int.Parse(xmlTextReader.Value);
				Simulation.elementXmlSuivant(xmlTextReader, true);
				int num4 = int.Parse(xmlTextReader.Value);
				Simulation.elementXmlSuivant(xmlTextReader, true);
				int num5 = int.Parse(xmlTextReader.Value);
				Simulation.elementXmlSuivant(xmlTextReader, true);
				int num6 = int.Parse(xmlTextReader.Value);
				Simulation.elementXmlSuivant(xmlTextReader, true);
				this.adrReseauInternet1 = new Ip_adresse(xmlTextReader.Value);
				Simulation.elementXmlSuivant(xmlTextReader, true);
				this.adrReseauInternet2 = new Ip_adresse(xmlTextReader.Value);
				Simulation.elementXmlSuivant(xmlTextReader, true);
				this.adrReseauInternet3 = new Ip_adresse(xmlTextReader.Value);
				Simulation.elementXmlSuivant(xmlTextReader, true);
				this.adrReseauInternet4 = new Ip_adresse(xmlTextReader.Value);
				Simulation.elementXmlSuivant(xmlTextReader, true);
				this.adrReseauInternet5 = new Ip_adresse(xmlTextReader.Value);
				for (int i = 1; i <= num; i++)
				{
					Simulation.elementXmlSuivant(xmlTextReader, false);
					string text;
					if ((text = xmlTextReader.LocalName) != null)
					{
						text = string.IsInterned(text);
						if (text != "internet")
						{
							if (text != "station")
							{
								if (text != "hub")
								{
									if (text != "switch")
									{
										if (text != "cable")
										{
											if (text == "iconeMessage")
											{
												base.Controls.Add(new Ap_Message());
											}
										}
										else
										{
											Simulation.elementXmlSuivant(xmlTextReader, true);
											Cable.TypeCable type = (Cable.TypeCable)Enum.Parse(typeof(Cable.TypeCable), xmlTextReader.Value, false);
											Simulation.elementXmlSuivant(xmlTextReader, true);
											int longueur = int.Parse(xmlTextReader.Value);
											PointConnexion pointConnexion;
											this.chargerPointConnexionXml(xmlTextReader, out pointConnexion);
											PointConnexion extremite;
											this.chargerPointConnexionXml(xmlTextReader, out extremite);
											this.CreerCable(pointConnexion);
											this.TerminerCable(extremite);
											pointConnexion.Lien.Type = type;
											pointConnexion.Lien.Longueur = longueur;
										}
									}
									else
									{
										string nomNoeud;
										int idNoeud;
										int num7;
										Point point;
										Point point2;
										this.chargerNoeudXml(xmlTextReader, out nomNoeud, out idNoeud, out num7, out point, out point2);
										this.creerSwitch(this, new MouseEventArgs(MouseButtons.Left, 1, point.X, point.Y, 0));
										Switch @switch = (Switch)this.schema.Controls[this.schema.Controls.Count - 1];
										@switch.Location = new Point(point.X, point.Y);
										@switch.PosDemo = new Point(point2.X, point2.Y);
										@switch.Controls.Clear();
										@switch.NomNoeud = nomNoeud;
										@switch.IdNoeud = idNoeud;
										Simulation.elementXmlSuivant(xmlTextReader, true);
										int nbPortsNormaux = int.Parse(xmlTextReader.Value);
										Simulation.elementXmlSuivant(xmlTextReader, true);
										int nbCascade = int.Parse(xmlTextReader.Value);
										@switch.NbPointsConnexion = 0;
										Simulation.elementXmlSuivant(xmlTextReader, true);
										@switch.SpanningTree = bool.Parse(xmlTextReader.Value);
										Simulation.elementXmlSuivant(xmlTextReader, true);
										int nb8021q = int.Parse(xmlTextReader.Value);
										Simulation.elementXmlSuivant(xmlTextReader, true);
										@switch.NiveauVlan = int.Parse(xmlTextReader.Value);
										@switch.InitialiserPorts(nbPortsNormaux, nbCascade, nb8021q);
										Simulation.elementXmlSuivant(xmlTextReader, true);
										@switch.TypeSwitch = (Switch.TypeDeSwitch)Enum.Parse(typeof(Switch.TypeDeSwitch), xmlTextReader.Value, false);
										for (int j = 0; j < num7; j++)
										{
											Simulation.elementXmlSuivant(xmlTextReader, false);
											xmlTextReader.MoveToNextAttribute();
											Simulation.elementXmlSuivant(xmlTextReader, true);
											int x = int.Parse(xmlTextReader.Value);
											Simulation.elementXmlSuivant(xmlTextReader, true);
											int y = int.Parse(xmlTextReader.Value);
											((PortSwitch)@switch.Controls[j]).PosDemoEmission = new Point(x, y);
										}
										@switch.PortVlanNiv1 = new SortedList();
										HashTableEdit.ChargerTableXml(@switch.PortVlanNiv1, xmlTextReader);
										HashTableEdit.ChargerTableXml(@switch.MacVlanNiv2, xmlTextReader);
										hashtable.Add(@switch.NomNoeud, @switch);
										sortedList.Add(@switch.NomNoeud, @switch);
										@switch.SetContenuInfoBulle();
									}
								}
								else
								{
									string nomNoeud;
									int idNoeud;
									int num7;
									Point point;
									Point point2;
									this.chargerNoeudXml(xmlTextReader, out nomNoeud, out idNoeud, out num7, out point, out point2);
									this.creerHub(this, new MouseEventArgs(MouseButtons.Left, 1, point.X, point.Y, 0));
									Hub hub = (Hub)this.schema.Controls[this.schema.Controls.Count - 1];
									hub.Location = new Point(point.X, point.Y);
									hub.PosDemo = new Point(point2.X, point2.Y);
									hub.Controls.Clear();
									hub.NomNoeud = nomNoeud;
									hub.IdNoeud = idNoeud;
									Simulation.elementXmlSuivant(xmlTextReader, true);
									int nbPortsNormaux = int.Parse(xmlTextReader.Value);
									Simulation.elementXmlSuivant(xmlTextReader, true);
									int nbCascade = int.Parse(xmlTextReader.Value);
									hub.NbPointsConnexion = 0;
									hub.InitialiserPorts(nbPortsNormaux, nbCascade, 0);
									hashtable.Add(hub.NomNoeud, hub);
									sortedList.Add(hub.NomNoeud, hub);
								}
							}
							else
							{
								string nomNoeud;
								int idNoeud;
								int num7;
								Point point;
								Point point2;
								this.chargerNoeudXml(xmlTextReader, out nomNoeud, out idNoeud, out num7, out point, out point2);
								this.creerStation(this, new MouseEventArgs(MouseButtons.Left, 1, point.X, point.Y, 0));
								Station station = (Station)this.schema.Controls[this.schema.Controls.Count - 1];
								station.Location = new Point(point.X, point.Y);
								station.PosDemo = new Point(point2.X, point2.Y);
								station.NomNoeud = nomNoeud;
								station.IdNoeud = idNoeud;
								station.Ip.ChargerXml(xmlTextReader);
								Simulation.elementXmlSuivant(xmlTextReader, true);
								bool flag = bool.Parse(xmlTextReader.Value);
								CarteReseau carteReseau = (CarteReseau)station.Controls[0];
								Simulation.elementXmlSuivant(xmlTextReader, false);
								xmlTextReader.MoveToNextAttribute();
								carteReseau.AdresseMac = xmlTextReader.Value;
								Simulation.elementXmlSuivant(xmlTextReader, true);
								int x = int.Parse(xmlTextReader.Value);
								Simulation.elementXmlSuivant(xmlTextReader, true);
								int y = int.Parse(xmlTextReader.Value);
								carteReseau.PosDemoEmission = new Point(x, y);
								carteReseau.Ip.ChargerXml(xmlTextReader);
								int num8 = num7;
								if (flag)
								{
									num8--;
								}
								for (int k = 1; k < num8; k++)
								{
									Simulation.elementXmlSuivant(xmlTextReader, false);
									xmlTextReader.MoveToNextAttribute();
									carteReseau = new CarteReseau(this);
									station.AjouterPointConnexion(carteReseau);
									carteReseau.AdresseMac = xmlTextReader.Value;
									Simulation.elementXmlSuivant(xmlTextReader, true);
									x = int.Parse(xmlTextReader.Value);
									Simulation.elementXmlSuivant(xmlTextReader, true);
									y = int.Parse(xmlTextReader.Value);
									carteReseau.PosDemoEmission = new Point(x, y);
									carteReseau.Ip.ChargerXml(xmlTextReader);
								}
								if (flag)
								{
									Simulation.elementXmlSuivant(xmlTextReader, false);
									xmlTextReader.MoveToNextAttribute();
									carteReseau = new CarteAccesDistant(this);
									station.AjouterPointConnexion(carteReseau);
									carteReseau.AdresseMac = xmlTextReader.Value;
									carteReseau.Ip.ChargerXml(xmlTextReader);
								}
								hashtable.Add(station.NomNoeud, station);
								sortedList.Add(station.NomNoeud, station);
								station.Trs.SetCarteQuiNatSelonNum();
							}
						}
						else
						{
							string nomNoeud;
							int idNoeud;
							int num7;
							Point point;
							Point point2;
							this.chargerNoeudXml(xmlTextReader, out nomNoeud, out idNoeud, out num7, out point, out point2);
							this.creerInternet(this, new MouseEventArgs(MouseButtons.Left, 1, point.X, point.Y, 0));
							Internet internet = (Internet)this.schema.Controls[this.schema.Controls.Count - 1];
							internet.Location = new Point(point.X, point.Y);
							internet.PosDemo = new Point(point2.X, point2.Y);
							internet.IdNoeud = idNoeud;
							Simulation.elementXmlSuivant(xmlTextReader, true);
							((PortFai)this.reseauInternet.Controls[0]).AdresseMac = xmlTextReader.Value;
							Simulation.elementXmlSuivant(xmlTextReader, true);
							((PortFai)this.reseauInternet.Controls[1]).AdresseMac = xmlTextReader.Value;
							Simulation.elementXmlSuivant(xmlTextReader, true);
							((PortFai)this.reseauInternet.Controls[2]).AdresseMac = xmlTextReader.Value;
							Simulation.elementXmlSuivant(xmlTextReader, true);
							((PortFai)this.reseauInternet.Controls[3]).AdresseMac = xmlTextReader.Value;
							hashtable.Add(this.reseauInternet.NomNoeud, this.reseauInternet);
							sortedList.Add(this.reseauInternet.NomNoeud, this.reseauInternet);
						}
					}
				}
				this.nbHubs = num2;
				this.nbCartesReseau = num4;
				this.nbSwitchs = num3;
				this.nbStations = num5;
				this.dernierIdNoeud = num6;
				this.noeuds = hashtable;
				this.noeudsNonDemo = sortedList;
			}
			else
			{
				convertir = true;
			}
			xmlTextReader.Close();
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x000518C8 File Offset: 0x000508C8
		private void nouveauDoc()
		{
			this.changerMode(Simulation.Mode.conceptionReseau);
			this.cocherMenuMode(this.mi_conceptionReseau);
			this.noeuds = new Hashtable();
			this.noeudsDemo = new SortedList();
			this.noeudsNonDemo = new SortedList();
			this.noeudsSelectionnes = new ArrayList();
			this.nbHubs = 0;
			this.nbSwitchs = 0;
			this.nbCartesReseau = 0;
			this.nbStations = 0;
			this.dernierIdNoeud = 0;
			this.iconeMessage.Visible = false;
			this.schema.Controls.Clear();
			this.schema.Controls.Add(this.iconeMessage);
			this.schema.Invalidate();
			this.setTitre("réseau non enregistré");
			this.etatConceptionActif = Simulation.EtatConception.consultationSchema;
			this.SupprimerInternet();
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x0005198C File Offset: 0x0005098C
		private void setTitre(string nomDoc)
		{
			this.Text = "Simulateur Réseau 2.0 (" + nomDoc + ")";
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x000519B0 File Offset: 0x000509B0
		private void enregistrerSchema()
		{
			string text = this.gereDoc.DocumentCourant;
			text = text.Substring(0, text.Length - 3);
			Graphics graphics = this.schema.CreateGraphics();
			IntPtr hdc = graphics.GetHdc();
			Metafile metafile = new Metafile(text + "emf", hdc);
			Graphics graphics2 = Graphics.FromImage(metafile);
			graphics2.Clear(Color.White);
			foreach (object obj in this.schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Cable))
				{
					((Cable)elementReseau).Tracer(graphics2);
				}
			}
			foreach (object obj2 in this.noeuds.Values)
			{
				Noeud noeud = (Noeud)obj2;
				noeud.Dessiner(graphics2);
			}
			graphics2.Dispose();
			Bitmap bitmap = new Bitmap(metafile);
			Clipboard.SetDataObject(bitmap, true);
			bitmap.Dispose();
			metafile.Dispose();
			graphics.ReleaseHdc(hdc);
			graphics.Dispose();
			MessageBox.Show("Le schéma du réseau a été placé dans le presse-papier et enregistré dans le document :" + Environment.NewLine + text + "emf", "Enregistrement du schéma");
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x00051B48 File Offset: 0x00050B48
		private bool enregistrerDoc(string nomFichier)
		{
			bool result;
			try
			{
				this.sauvegarderXml(nomFichier);
				this.setTitre(nomFichier);
				result = true;
			}
			catch
			{
				MessageBox.Show("Problème pendant la sauvegarde !");
				result = false;
			}
			return result;
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x00051B94 File Offset: 0x00050B94
		public void sauvegarderXml(string nomFichier)
		{
			XmlTextWriter xmlTextWriter = new XmlTextWriter(nomFichier, null);
			xmlTextWriter.Formatting = Formatting.Indented;
			xmlTextWriter.WriteStartDocument();
			xmlTextWriter.WriteStartElement("simRes");
			xmlTextWriter.WriteAttributeString("version", "2.00");
			xmlTextWriter.WriteAttributeString("nbElements", this.schema.Controls.Count.ToString());
			xmlTextWriter.WriteElementString("nbHubs", this.nbHubs.ToString());
			xmlTextWriter.WriteElementString("nbSwitch", this.nbSwitchs.ToString());
			xmlTextWriter.WriteElementString("nbCartesReseau", this.nbCartesReseau.ToString());
			xmlTextWriter.WriteElementString("nbStations", this.nbStations.ToString());
			xmlTextWriter.WriteElementString("dernierIdNoeud", this.dernierIdNoeud.ToString());
			xmlTextWriter.WriteElementString("adrReseauInternet1", this.adrReseauInternet1.ToString());
			xmlTextWriter.WriteElementString("adrReseauInternet2", this.adrReseauInternet2.ToString());
			xmlTextWriter.WriteElementString("adrReseauInternet3", this.adrReseauInternet3.ToString());
			xmlTextWriter.WriteElementString("adrReseauInternet4", this.adrReseauInternet4.ToString());
			xmlTextWriter.WriteElementString("adrReseauInternet5", this.adrReseauInternet5.ToString());
			foreach (object obj in this.schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() != typeof(Cable))
				{
					elementReseau.StockerXml(xmlTextWriter);
				}
			}
			foreach (object obj2 in this.schema.Controls)
			{
				ElementReseau elementReseau2 = (ElementReseau)obj2;
				if (elementReseau2.GetType() == typeof(Cable))
				{
					elementReseau2.StockerXml(xmlTextWriter);
				}
			}
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndDocument();
			xmlTextWriter.Close();
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x00051DCC File Offset: 0x00050DCC
		private void mi_sauverOptions_Click(object sender, EventArgs e)
		{
			this.pref.bt_sauvegarder_Click(sender, e);
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x00051DE8 File Offset: 0x00050DE8
		private void mi_chargerOptions_Click(object sender, EventArgs e)
		{
			this.pref.bt_charger_Click(sender, e);
			this.schema.Invalidate(true);
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x00051E10 File Offset: 0x00050E10
		private void mi_aPropos_Click(object sender, EventArgs e)
		{
			APropos apropos = new APropos();
			apropos.ShowDialog();
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x0600086C RID: 2156 RVA: 0x00051E2C File Offset: 0x00050E2C
		// (set) Token: 0x0600086D RID: 2157 RVA: 0x00051E40 File Offset: 0x00050E40
		public bool BisEnCours
		{
			get
			{
				return this.bisEnCours;
			}
			set
			{
				this.bisEnCours = value;
			}
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x00051E54 File Offset: 0x00050E54
		public void BloquerBisIp()
		{
			this.bt_stopBisIp.Enabled = false;
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x0600086F RID: 2159 RVA: 0x00051E70 File Offset: 0x00050E70
		// (set) Token: 0x06000870 RID: 2160 RVA: 0x00051E84 File Offset: 0x00050E84
		public bool BisIpEnCours
		{
			get
			{
				return this.bisIpEnCours;
			}
			set
			{
				this.bisIpEnCours = value;
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06000871 RID: 2161 RVA: 0x00051E98 File Offset: 0x00050E98
		public DonneesSimulation DerniereSimulation
		{
			get
			{
				return this.derniereSimulation;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000872 RID: 2162 RVA: 0x00051EAC File Offset: 0x00050EAC
		public DonneesSimulationIp DerniereSimulationIp
		{
			get
			{
				return this.derniereSimulationIp;
			}
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x00051EC0 File Offset: 0x00050EC0
		private void cb_optionSimulation_CheckedChanged(object sender, EventArgs e)
		{
			this.okBis = false;
			this.PreparerBis();
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x00051EDC File Offset: 0x00050EDC
		public void SetDonneesSimulation(int numTrame, DateTime moment, CarteReseau emetteur, string adrDest, int tailleTrame)
		{
			this.derniereSimulation.Trames[numTrame - 1] = new DonneesTrame(numTrame, moment, emetteur, adrDest, tailleTrame);
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x00051F04 File Offset: 0x00050F04
		private void tBis1_Tick(object sender, EventArgs e)
		{
			this.tBis1.Stop();
			this.tBis1.Tick -= this.tBis1_Tick;
			this.derniereSimulation.Trames[this.derniereSimulation.PremiereTrame].DialogueEmission.bt_ok_Click(this, new EventArgs());
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x00051F5C File Offset: 0x00050F5C
		private void tBis2_Tick(object sender, EventArgs e)
		{
			this.tBis2.Stop();
			this.tBis2.Tick -= this.tBis2_Tick;
			this.derniereSimulation.Trames[this.derniereSimulation.SecondeTrame].DialogueEmission.bt_ok_Click(this, new EventArgs());
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x00051FB4 File Offset: 0x00050FB4
		private void bt_debugBis_Click(object sender, EventArgs e)
		{
			this.debugEncours = true;
			this.derniereSimulation.ChargerDebugBis();
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x00051FD4 File Offset: 0x00050FD4
		private void mi_aide_Click(object sender, EventArgs e)
		{
			try
			{
				Process process = new Process();
				ProcessStartInfo startInfo = new ProcessStartInfo("Simulateur.pdf");
				process.StartInfo = startInfo;
				process.Start();
			}
			catch
			{
				MessageBox.Show("Impossible d'ouvrir le fichier Simulateur.pdf");
			}
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x0005202C File Offset: 0x0005102C
		private void reinitEthernetTramesCreees()
		{
			foreach (object obj in this.tramesCreees)
			{
				TrameEthernet trameEthernet = (TrameEthernet)obj;
				trameEthernet.ReinitEthernet();
			}
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x00052090 File Offset: 0x00051090
		public void AjouterTrameCreee(TrameEthernet t)
		{
			this.tramesCreees.Add(t);
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x000520AC File Offset: 0x000510AC
		public void MontrerPaquet(string typeNiveau2)
		{
			if (typeNiveau2 == "ppp")
			{
				this.lbl_typePaquet.Location = new Point(1, 1);
				this.lbl_typePaquet.Size = new Size(117, 28);
				this.panelTrameIp.BackColor = this.pref.CableActifStylo2.Color;
			}
			else
			{
				this.lbl_typePaquet.Location = new Point(83, 1);
				this.lbl_typePaquet.Size = new Size(35, 28);
				this.panelTrameIp.BackColor = this.pref.CableActifStylo1.Color;
			}
			if (this.panelTrameIp.Height == 0)
			{
				this.panelReglagesIp.Size = new Size(this.panelReglagesIp.Width, 0);
				this.panelTrameIp.Size = new Size(this.panelTrameIp.Width, 30);
				this.panelPaquetIp.BackColor = this.pref.StyloPaquet.Color;
			}
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x000521AC File Offset: 0x000511AC
		public void MontrerMessage()
		{
			if (this.panelTrameAp.Height == 0)
			{
				this.panelReglagesAp.Size = new Size(this.panelReglagesAp.Width, 0);
				this.panelTrameAp.Size = new Size(this.panelTrameAp.Width, 30);
				this.panelTrameAp.BackColor = this.pref.CableActifStylo1.Color;
				this.panelPaquetAp.BackColor = this.pref.StyloPaquet.Color;
				this.panelMessageAp.BackColor = this.pref.StyloMessage.Color;
			}
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x00052254 File Offset: 0x00051254
		public void AfficherPaquet(Ip_PaquetIp paquet, string p_type, string p_donnees)
		{
			if (p_type == "arp")
			{
				this.lbl_ttlPaquet.Visible = false;
				this.lbl_IpSource.Location = new Point(2, 2);
				this.lbl_IpDest.Location = new Point(93, 2);
				this.lbl_donneesIp.Location = new Point(184, 2);
				this.lbl_donneesIp.Size = new Size(312, 22);
			}
			else
			{
				this.lbl_ttlPaquet.Visible = true;
				this.lbl_IpSource.Location = new Point(21, 2);
				this.lbl_IpDest.Location = new Point(112, 2);
				this.lbl_donneesIp.Location = new Point(203, 2);
				this.lbl_donneesIp.Size = new Size(292, 22);
			}
			if (paquet.CarteSource.GetType() == typeof(CarteReseau))
			{
				this.MontrerPaquet("eth");
			}
			else
			{
				this.MontrerPaquet("ppp");
			}
			if (paquet.MacDest == "BCAST")
			{
				this.lbl_macDest.Text = "bcast";
			}
			else
			{
				this.lbl_macDest.Text = paquet.MacDest;
			}
			this.lbl_macSource.Text = paquet.MacSource;
			this.lbl_ttlPaquet.Text = paquet.NbSauts.ToString();
			this.lbl_IpSource.Text = paquet.AdrSource.ToString();
			this.lbl_IpDest.Text = paquet.AdrDest.ToString();
			this.lbl_typePaquet.Text = p_type;
			this.lbl_donneesIp.Text = p_donnees;
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x00052400 File Offset: 0x00051400
		public void CacherPaquet(bool reglagesActif)
		{
			if (this.panelTrameIp.Height != 0)
			{
				this.panelTrameIp.Size = new Size(this.panelTrameIp.Width, 0);
				this.panelReglagesIp.Size = new Size(this.panelReglagesIp.Width, 36);
			}
			this.panelReglagesIp.Enabled = reglagesActif;
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x00052460 File Offset: 0x00051460
		public void AfficherMessage(Ip_PaquetIp paquet)
		{
			this.MontrerMessage();
			this.lbl_ipDestAp.Text = paquet.AdrDest.ToString();
			this.lbl_ipSourceAp.Text = paquet.AdrPasserelle.ToString();
			this.lbl_donneesAp.Text = paquet.Donnees;
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x000524B0 File Offset: 0x000514B0
		public void CacherMessage()
		{
			if (this.panelTrameAp.Height != 0)
			{
				this.panelTrameAp.Size = new Size(this.panelTrameAp.Width, 0);
				this.panelReglagesAp.Size = new Size(this.panelReglagesAp.Width, 36);
			}
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x00052504 File Offset: 0x00051504
		private void mi_transport_Click(object sender, EventArgs e)
		{
			this.cocherMenuMode((MenuItem)sender);
			this.suiteMi_ip_Click();
			this.setOptionsModeIp(false);
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x0005252C File Offset: 0x0005152C
		private void mi_ip_Click(object sender, EventArgs e)
		{
			this.cocherMenuMode((MenuItem)sender);
			this.suiteMi_ip_Click();
			this.setOptionsModeIp(true);
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000883 RID: 2179 RVA: 0x00052554 File Offset: 0x00051554
		public bool PseudoModeTransport
		{
			get
			{
				return this.pseudoModeTransport;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000884 RID: 2180 RVA: 0x00052568 File Offset: 0x00051568
		public bool DemoRoutageSeul
		{
			get
			{
				return this.cb_demoRoutageSeul.Checked;
			}
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x00052580 File Offset: 0x00051580
		private void setOptionsModeIp(bool ipMode)
		{
			this.bt_stopBisIp.Enabled = false;
			this.pseudoModeTransport = !ipMode;
			if (ipMode)
			{
				this.mi_supprimerEchangesEnCours.Visible = false;
				this.mi_viderCachesArp.Visible = true;
				this.mi_remplirCachesArp.Visible = true;
				this.cb_ralentiIp.Location = new Point(220, 18);
				this.cb_demoArp.Visible = true;
				this.cb_demoRoutageSeul.Visible = false;
				this.cb_statiques.Visible = true;
				this.lbl_trajetPaquet.Location = new Point(452, 4);
				this.cb_trajetPaquet.Location = new Point(500, 9);
				this.lbl_SimulIp.Text = "Simulation ARP / IP";
			}
			else
			{
				this.mi_supprimerEchangesEnCours.Visible = true;
				this.mi_viderCachesArp.Visible = false;
				this.mi_remplirCachesArp.Visible = false;
				this.cb_ralentiIp.Location = new Point(220, 12);
				this.cb_demoArp.Visible = false;
				this.cb_demoRoutageSeul.Visible = true;
				this.cb_statiques.Visible = false;
				this.lbl_trajetPaquet.Location = new Point(452, 4);
				this.cb_trajetPaquet.Location = new Point(500, 9);
				this.lbl_SimulIp.Text = "Simulation Transport";
			}
			foreach (object obj in this.noeuds.Values)
			{
				Noeud noeud = (Noeud)obj;
				if (noeud.GetType() == typeof(Station))
				{
					((Station)noeud).SetOptionsModeIp(ipMode);
				}
			}
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x0005275C File Offset: 0x0005175C
		private void suiteMi_ip_Click()
		{
			if (this.modeActif != Simulation.Mode.ip)
			{
				this.ensHub = null;
				this.changerMode(Simulation.Mode.ip);
				foreach (object obj in this.noeuds.Values)
				{
					Noeud noeud = (Noeud)obj;
					if (noeud.EnFonction)
					{
						noeud.Allumer();
					}
				}
				this.etatConceptionActif = Simulation.EtatConception.aucun;
				this.EtatIpActif = Simulation.EtatIp.attente;
				this.SpanningTree();
				foreach (object obj2 in this.schema.Controls)
				{
					ElementReseau elementReseau = (ElementReseau)obj2;
					if (elementReseau.GetType() == typeof(Switch))
					{
						((Switch)elementReseau).DecouvrirReseau();
					}
				}
				foreach (object obj3 in this.noeuds.Values)
				{
					Noeud noeud2 = (Noeud)obj3;
					noeud2.ChangerMode(Simulation.Mode.ip);
				}
				if (this.reseauInternet != null)
				{
					this.reseauInternet.ConfigurerClients();
				}
			}
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x000528E0 File Offset: 0x000518E0
		private void mi_application_Click(object sender, EventArgs e)
		{
			if (this.modeActif != Simulation.Mode.appl)
			{
				this.ensHub = null;
				this.changerMode(Simulation.Mode.appl);
				this.cocherMenuMode((MenuItem)sender);
				foreach (object obj in this.noeuds.Values)
				{
					Noeud noeud = (Noeud)obj;
					if (noeud.EnFonction)
					{
						noeud.Allumer();
					}
					noeud.ChangerMode(Simulation.Mode.appl);
				}
				this.etatConceptionActif = Simulation.EtatConception.aucun;
				this.etatApplActif = Simulation.EtatAppl.attente;
				this.SpanningTree();
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000888 RID: 2184 RVA: 0x00052990 File Offset: 0x00051990
		// (set) Token: 0x06000889 RID: 2185 RVA: 0x000529A4 File Offset: 0x000519A4
		public Simulation.EtatIp EtatIpActif
		{
			get
			{
				return this.etatIpActif;
			}
			set
			{
				this.etatIpActif = value;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x0600088A RID: 2186 RVA: 0x000529B8 File Offset: 0x000519B8
		// (set) Token: 0x0600088B RID: 2187 RVA: 0x000529CC File Offset: 0x000519CC
		public Simulation.EtatAppl EtatApplActif
		{
			get
			{
				return this.etatApplActif;
			}
			set
			{
				this.etatApplActif = value;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x0600088C RID: 2188 RVA: 0x000529E0 File Offset: 0x000519E0
		public string TypeEntreesArp
		{
			get
			{
				if (this.cb_statiques.Checked)
				{
					return "Stat.";
				}
				return "Dyn.";
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x0600088D RID: 2189 RVA: 0x00052A08 File Offset: 0x00051A08
		public Simulation.TypeDeDemo TypeDemoIp
		{
			get
			{
				return this.typeDemoIp;
			}
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x00052A1C File Offset: 0x00051A1C
		private void typeDemoIpChanged(object sender, EventArgs e)
		{
			this.Bt_stopBisIp.Enabled = false;
			this.cb_ralentiIp.Enabled = false;
			this.cb_demoArp.Enabled = true;
			switch (this.cb_typeSimulIp.SelectedIndex)
			{
			case 0:
				this.typeDemoIp = Simulation.TypeDeDemo.pasAPas;
				return;
			case 1:
				this.typeDemoIp = Simulation.TypeDeDemo.automatique;
				this.cb_ralentiIp.Enabled = true;
				return;
			case 2:
				this.typeDemoIp = Simulation.TypeDeDemo.noDemo;
				this.cb_ralentiIp.Enabled = true;
				this.cb_demoArp.Enabled = false;
				return;
			case 3:
				this.typeDemoIp = Simulation.TypeDeDemo.manuel;
				return;
			default:
				return;
			}
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x00052AB4 File Offset: 0x00051AB4
		public void SetTypeDemoIp(Simulation.TypeDeDemo p_demoIp)
		{
			switch (p_demoIp)
			{
			case Simulation.TypeDeDemo.noDemo:
				this.cb_typeSimulIp.SelectedIndex = 0;
				return;
			case Simulation.TypeDeDemo.automatique:
				this.cb_typeSimulIp.SelectedIndex = 2;
				return;
			case Simulation.TypeDeDemo.pasAPas:
				this.cb_typeSimulIp.SelectedIndex = 1;
				return;
			case Simulation.TypeDeDemo.manuel:
				this.cb_typeSimulIp.SelectedIndex = 3;
				return;
			default:
				return;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000890 RID: 2192 RVA: 0x00052B10 File Offset: 0x00051B10
		// (set) Token: 0x06000891 RID: 2193 RVA: 0x00052B28 File Offset: 0x00051B28
		public bool DemoArp
		{
			get
			{
				return this.cb_demoArp.Checked;
			}
			set
			{
				this.cb_demoArp.Checked = false;
			}
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x00052B44 File Offset: 0x00051B44
		private void bt_stopBisIp_Click(object sender, EventArgs e)
		{
			if (this.bt_stopBisIp.Text == "stop")
			{
				this.bt_pauseRepriseIp.ImageIndex = 0;
				this.bt_pauseRepriseIp.Enabled = false;
				this.bt_pauseRepriseIp.ImageIndex = 0;
				this.timerTraceTrame.Stop();
				foreach (object obj in this.schema.Controls)
				{
					ElementReseau elementReseau = (ElementReseau)obj;
					if (elementReseau.GetType() == typeof(Station) || elementReseau.GetType() == typeof(Internet))
					{
						((Station)elementReseau).Ip.StopperSimulation();
					}
					else if (elementReseau.GetType() == typeof(Cable))
					{
						((Cable)elementReseau).ReinitIp();
					}
					else if (elementReseau.GetType() == typeof(Ip_CableVirtuel))
					{
						((Ip_CableVirtuel)elementReseau).ReinitIp();
					}
				}
				foreach (Form form in base.OwnedForms)
				{
					if (form.GetType().BaseType.Equals(typeof(DemoDialogue)))
					{
						((DemoDialogue)form).Attente.Stop();
						((DemoDialogue)form).Close();
					}
				}
				this.schema.Invalidate(true);
				this.attenteSecurite.Interval = 100;
				this.attenteSecurite.Start();
				this.attenteSecurite.Tick += this.suiteStopIp;
				return;
			}
			this.bt_stopBisIp.Enabled = false;
			this.tBis1 = new Timer();
			this.tBis1.Interval = 2000;
			this.tBis1.Tick += this.tBis1_TickIp;
			this.tBis1.Start();
			this.bisIpEnCours = true;
			switch (this.DerniereSimulationIp.DemoIp)
			{
			case TypeSimulationIp.ping:
				this.derniereSimulation.RelireTablesSwitch();
				this.derniereSimulationIp.RelireCachesArpStation();
				this.derniereSimulationIp.StationPing.Ip.EnvoyerPing();
				return;
			case TypeSimulationIp.envoiTrs:
				this.derniereSimulation.RelireTablesSwitch();
				this.derniereSimulationIp.RelireNatPatEtRequetesTrs();
				this.derniereSimulationIp.StationPing.Trs.EnvoyerTrs(false);
				return;
			case TypeSimulationIp.reponseTrs:
				this.derniereSimulation.RelireTablesSwitch();
				this.derniereSimulationIp.RelireNatPatEtRequetesTrs();
				this.derniereSimulationIp.StationPing.Trs.EnvoyerTrs(true);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x00052DF0 File Offset: 0x00051DF0
		private void tBis1_TickIp(object sender, EventArgs e)
		{
			this.tBis1.Stop();
			this.tBis1.Tick -= this.tBis1_TickIp;
			switch (this.DerniereSimulationIp.DemoIp)
			{
			case TypeSimulationIp.ping:
				this.derniereSimulationIp.StationPing.Ip.Dialogue.bt_ok_Click(this, new EventArgs());
				break;
			case TypeSimulationIp.envoiTrs:
				this.derniereSimulationIp.StationPing.Trs.DialogueSaisieTrs.bt_ok_Click(this, new EventArgs());
				break;
			case TypeSimulationIp.reponseTrs:
				this.derniereSimulationIp.StationPing.Trs.DialogueReponseTrs.bt_ok_Click(this, new EventArgs());
				break;
			}
			this.bt_stopBisIp.Enabled = true;
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x00052EB0 File Offset: 0x00051EB0
		private void suiteStopIp(object sender, EventArgs e)
		{
			this.attenteSecurite.Stop();
			this.attenteSecurite.Tick -= this.suiteStopIp;
			this.bt_stopBisIp.Text = "bis";
			this.SetEnabledMenus(true);
			this.CacherPaquet(true);
			this.EtatIpActif = Simulation.EtatIp.attente;
			if (this.dialoguePing != null)
			{
				this.dialoguePing.Close();
				this.dialoguePing = null;
			}
		}

		// Token: 0x1700016E RID: 366
		// (set) Token: 0x06000895 RID: 2197 RVA: 0x00052F20 File Offset: 0x00051F20
		public Ip_DialogueSaisieIP DialoguePing
		{
			set
			{
				this.dialoguePing = value;
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06000896 RID: 2198 RVA: 0x00052F34 File Offset: 0x00051F34
		public Button Bt_stopBisIp
		{
			get
			{
				return this.bt_stopBisIp;
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06000897 RID: 2199 RVA: 0x00052F48 File Offset: 0x00051F48
		public Button Bt_pauseRepriseIp
		{
			get
			{
				return this.bt_pauseRepriseIp;
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06000898 RID: 2200 RVA: 0x00052F5C File Offset: 0x00051F5C
		public Button Bt_pauseReprise
		{
			get
			{
				return this.bt_pauseReprise;
			}
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x00052F70 File Offset: 0x00051F70
		public void FixerTtlPaquetIp(int ttl)
		{
			this.lbl_ttlPaquet.Text = ttl.ToString();
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x00052F90 File Offset: 0x00051F90
		public bool IsAdrInternet(string strAdrIp)
		{
			return this.internetPresent && this.reseauInternet.IsAdrInternet(strAdrIp);
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x0600089B RID: 2203 RVA: 0x00052FB4 File Offset: 0x00051FB4
		// (set) Token: 0x0600089C RID: 2204 RVA: 0x00052FC8 File Offset: 0x00051FC8
		public bool InternetPresent
		{
			get
			{
				return this.internetPresent;
			}
			set
			{
				this.internetPresent = value;
			}
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x00052FDC File Offset: 0x00051FDC
		private void cb_demoArp_CheckedChanged(object sender, EventArgs e)
		{
			this.Bt_stopBisIp.Enabled = false;
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x00052FF8 File Offset: 0x00051FF8
		private void cb_ralentiIp_CheckedChanged(object sender, EventArgs e)
		{
			this.Bt_stopBisIp.Enabled = false;
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x00053014 File Offset: 0x00052014
		private void cb_statiques_CheckedChanged(object sender, EventArgs e)
		{
			this.Bt_stopBisIp.Enabled = false;
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x00053030 File Offset: 0x00052030
		private void mi_remplirCachesArp_Click(object sender, EventArgs e)
		{
			if (this.cb_statiques.Checked)
			{
				Ip_station.RemplirCachesArp(this.schema, "Stat.");
			}
			else
			{
				Ip_station.RemplirCachesArp(this.schema, "Dyn.");
			}
			this.gereDoc.FaireAction(ActionDocument.modifier);
			this.Bt_stopBisIp.Enabled = false;
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x00053088 File Offset: 0x00052088
		private void mi_viderCachesArp_Click(object sender, EventArgs e)
		{
			Ip_station.ViderCachesArp(this.schema);
			this.gereDoc.FaireAction(ActionDocument.modifier);
			this.Bt_stopBisIp.Enabled = false;
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x000530BC File Offset: 0x000520BC
		private void mi_supprimerEchangesEnCours_Click(object sender, EventArgs e)
		{
			Trs_station.SupprimerEchangesEnCours(this.schema);
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x000530D4 File Offset: 0x000520D4
		private void bt_pauseRepriseIp_Click(object sender, EventArgs e)
		{
			if (this.bt_pauseRepriseIp.Tag.ToString() == "pause")
			{
				this.timerTraceTrame.Stop();
				this.bt_pauseRepriseIp.Tag = "reprise";
				this.bt_pauseRepriseIp.ImageIndex = 2;
				return;
			}
			this.timerTraceTrame.Start();
			this.bt_pauseRepriseIp.Tag = "pause";
			this.bt_pauseRepriseIp.ImageIndex = 1;
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x0005314C File Offset: 0x0005214C
		private void bt_pauseReprise_Click(object sender, EventArgs e)
		{
			if (this.bt_pauseReprise.Tag.ToString() == "pause")
			{
				this.timerTraceTrame.Stop();
				Switch.TimerTampon.Stop();
				foreach (Form form in base.OwnedForms)
				{
					if (form.GetType().Equals(typeof(DDialogPlusEmissionTrame)))
					{
						((DDialogPlusEmissionTrame)form).Attente.Stop();
					}
				}
				this.bt_pauseReprise.Tag = "reprise";
				this.bt_pauseReprise.ImageIndex = 2;
				return;
			}
			this.timerTraceTrame.Start();
			Switch.TimerTampon.Start();
			foreach (Form form2 in base.OwnedForms)
			{
				if (form2.GetType().Equals(typeof(DDialogPlusEmissionTrame)))
				{
					((DDialogPlusEmissionTrame)form2).Attente.Start();
				}
			}
			this.bt_pauseReprise.Tag = "pause";
			this.bt_pauseReprise.ImageIndex = 1;
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x00053258 File Offset: 0x00052258
		private static bool derive(Type enfant, Type parent)
		{
			return enfant == parent || (enfant != typeof(object) && Simulation.derive(enfant.BaseType, parent));
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x00053288 File Offset: 0x00052288
		private void setPosDemoDefaut()
		{
			if (this.schema.Controls.Count > 1)
			{
				foreach (object obj in this.schema.Controls)
				{
					ElementReseau elementReseau = (ElementReseau)obj;
					if (Simulation.derive(elementReseau.GetType(), typeof(Noeud)))
					{
						((Noeud)elementReseau).PosDemo = new Point(0, 0);
					}
				}
				this.gereDoc.FaireAction(ActionDocument.modifier);
			}
		}

		// Token: 0x04000527 RID: 1319
		public static bool ModeDebug = false;

		// Token: 0x04000528 RID: 1320
		private static Timer timerEmissionTrame;

		// Token: 0x04000529 RID: 1321
		public static Random Rnd = new Random();

		// Token: 0x0400052A RID: 1322
		private Pen styloEfface;

		// Token: 0x0400052B RID: 1323
		private Pen styloGomme;

		// Token: 0x0400052C RID: 1324
		private int dernierIdNoeud = 0;

		// Token: 0x0400052D RID: 1325
		private Internet reseauInternet = null;

		// Token: 0x0400052E RID: 1326
		private Ip_adresse adrReseauInternet1 = new Ip_adresse("172.11.0.0");

		// Token: 0x0400052F RID: 1327
		private Ip_adresse adrReseauInternet2 = new Ip_adresse("172.12.0.0");

		// Token: 0x04000530 RID: 1328
		private Ip_adresse adrReseauInternet3 = new Ip_adresse("172.13.0.0");

		// Token: 0x04000531 RID: 1329
		private Ip_adresse adrReseauInternet4 = new Ip_adresse("172.14.0.0");

		// Token: 0x04000532 RID: 1330
		private Ip_adresse adrReseauInternet5 = new Ip_adresse("172.15.0.0");

		// Token: 0x04000533 RID: 1331
		private Simulation.Mode modeActif;

		// Token: 0x04000534 RID: 1332
		private Simulation.EtatConception etatConceptionActif;

		// Token: 0x04000535 RID: 1333
		private Simulation.EtatEthernet etatEthernetActif;

		// Token: 0x04000536 RID: 1334
		private Point debutRectangleSelection;

		// Token: 0x04000537 RID: 1335
		private Rectangle RectangleSelection;

		// Token: 0x04000538 RID: 1336
		private bool rectangleSelectionEnCours = false;

		// Token: 0x04000539 RID: 1337
		private Simulation.TypeDeDemo typeDemo;

		// Token: 0x0400053A RID: 1338
		private Simulation.TypeDeSimulationEthernet simulationEthernet;

		// Token: 0x0400053B RID: 1339
		private bool deuxTrames;

		// Token: 0x0400053C RID: 1340
		private Timer attenteSecurite = new Timer();

		// Token: 0x0400053D RID: 1341
		private bool trameBienRecue = false;

		// Token: 0x0400053E RID: 1342
		private bool debugEncours = false;

		// Token: 0x0400053F RID: 1343
		private bool okBis = false;

		// Token: 0x04000540 RID: 1344
		private Hashtable noeuds = new Hashtable();

		// Token: 0x04000541 RID: 1345
		private SortedList noeudsDemo = new SortedList();

		// Token: 0x04000542 RID: 1346
		private SortedList noeudsNonDemo = new SortedList();

		// Token: 0x04000543 RID: 1347
		private Control adrMacAttente = null;

		// Token: 0x04000544 RID: 1348
		private int nbTrameCarte = 0;

		// Token: 0x04000545 RID: 1349
		private int nbTransmissionsTotales = 0;

		// Token: 0x04000546 RID: 1350
		private int nbTrameEnCours = 0;

		// Token: 0x04000547 RID: 1351
		private EmissionTrameDialogue dialogueEmissionTrame1 = null;

		// Token: 0x04000548 RID: 1352
		private EmissionTrameDialogue dialogueEmissionTrame2 = null;

		// Token: 0x04000549 RID: 1353
		private Cable nouveauCable = null;

		// Token: 0x0400054A RID: 1354
		private CableEnCours traceNouveauCable = null;

		// Token: 0x0400054B RID: 1355
		private int nbHubs = 0;

		// Token: 0x0400054C RID: 1356
		private int nbSwitchs = 0;

		// Token: 0x0400054D RID: 1357
		private int nbCartesReseau = 0;

		// Token: 0x0400054E RID: 1358
		private int nbStations = 0;

		// Token: 0x0400054F RID: 1359
		private Param pref;

		// Token: 0x04000550 RID: 1360
		private int nbCollisionsDeuxPaires;

		// Token: 0x04000551 RID: 1361
		private ArrayList noeudsSelectionnes = new ArrayList();

		// Token: 0x04000552 RID: 1362
		private Timer timerTraceTrame = new Timer();

		// Token: 0x04000553 RID: 1363
		private ArrayList ensHub;

		// Token: 0x04000554 RID: 1364
		private ArrayList sommetsSwitch;

		// Token: 0x04000555 RID: 1365
		private SortedList successeursSwitch;

		// Token: 0x04000556 RID: 1366
		private ArrayList aretesGrapheSwitch;

		// Token: 0x04000557 RID: 1367
		public static DebugForm Debug = new DebugForm();

		// Token: 0x04000558 RID: 1368
		private Timer timerModifDocConverti;

		// Token: 0x04000559 RID: 1369
		private Timer tBis1 = new Timer();

		// Token: 0x0400055A RID: 1370
		private Timer tBis2 = new Timer();

		// Token: 0x0400055B RID: 1371
		private bool bisEnCours = false;

		// Token: 0x0400055C RID: 1372
		private bool bisIpEnCours = false;

		// Token: 0x0400055D RID: 1373
		private DonneesSimulation derniereSimulation;

		// Token: 0x0400055E RID: 1374
		private DonneesSimulationIp derniereSimulationIp;

		// Token: 0x0400055F RID: 1375
		private ArrayList tramesCreees;

		// Token: 0x04000560 RID: 1376
		private Simulation.EtatIp etatIpActif;

		// Token: 0x04000561 RID: 1377
		private Simulation.EtatAppl etatApplActif;

		// Token: 0x04000562 RID: 1378
		private bool pseudoModeTransport = false;

		// Token: 0x04000563 RID: 1379
		private Simulation.TypeDeDemo typeDemoIp;

		// Token: 0x04000564 RID: 1380
		private Ip_DialogueSaisieIP dialoguePing;

		// Token: 0x04000565 RID: 1381
		private bool internetPresent = false;

		// Token: 0x02000081 RID: 129
		public enum Mode
		{
			// Token: 0x04000567 RID: 1383
			conceptionReseau,
			// Token: 0x04000568 RID: 1384
			ethernet,
			// Token: 0x04000569 RID: 1385
			ip,
			// Token: 0x0400056A RID: 1386
			appl
		}

		// Token: 0x02000082 RID: 130
		public enum EtatConception
		{
			// Token: 0x0400056C RID: 1388
			aucun,
			// Token: 0x0400056D RID: 1389
			consultationSchema,
			// Token: 0x0400056E RID: 1390
			creationNoeud,
			// Token: 0x0400056F RID: 1391
			creationCable,
			// Token: 0x04000570 RID: 1392
			creationCableEnCours
		}

		// Token: 0x02000083 RID: 131
		public enum EtatEthernet
		{
			// Token: 0x04000572 RID: 1394
			aucun,
			// Token: 0x04000573 RID: 1395
			attente,
			// Token: 0x04000574 RID: 1396
			simulationEnPreparation,
			// Token: 0x04000575 RID: 1397
			simulationEnCours
		}

		// Token: 0x02000084 RID: 132
		public enum TypeDeDemo
		{
			// Token: 0x04000577 RID: 1399
			noDemo,
			// Token: 0x04000578 RID: 1400
			automatique,
			// Token: 0x04000579 RID: 1401
			pasAPas,
			// Token: 0x0400057A RID: 1402
			manuel
		}

		// Token: 0x02000085 RID: 133
		public enum TypeDeSimulationEthernet
		{
			// Token: 0x0400057C RID: 1404
			circulationTrame,
			// Token: 0x0400057D RID: 1405
			trameReelle,
			// Token: 0x0400057E RID: 1406
			monteeCharge
		}

		// Token: 0x02000086 RID: 134
		private class AreteSwitch
		{
			// Token: 0x060008A8 RID: 2216 RVA: 0x0005335C File Offset: 0x0005235C
			public AreteSwitch(Switch p_depart, Switch p_arrivee, PortSwitch p_portDepart, PortSwitch p_portArrivee, int p_poids)
			{
				this.depart = p_depart;
				this.arrivee = p_arrivee;
				this.portDepart = p_portDepart;
				this.portArrivee = p_portArrivee;
				this.poids = p_poids;
			}

			// Token: 0x17000173 RID: 371
			// (get) Token: 0x060008A9 RID: 2217 RVA: 0x0005339C File Offset: 0x0005239C
			public Switch Depart
			{
				get
				{
					return this.depart;
				}
			}

			// Token: 0x17000174 RID: 372
			// (get) Token: 0x060008AA RID: 2218 RVA: 0x000533B0 File Offset: 0x000523B0
			public Switch Arrivee
			{
				get
				{
					return this.arrivee;
				}
			}

			// Token: 0x17000175 RID: 373
			// (get) Token: 0x060008AB RID: 2219 RVA: 0x000533C4 File Offset: 0x000523C4
			public PortSwitch PortDepart
			{
				get
				{
					return this.portDepart;
				}
			}

			// Token: 0x17000176 RID: 374
			// (get) Token: 0x060008AC RID: 2220 RVA: 0x000533D8 File Offset: 0x000523D8
			public PortSwitch PortArrivee
			{
				get
				{
					return this.portArrivee;
				}
			}

			// Token: 0x17000177 RID: 375
			// (get) Token: 0x060008AD RID: 2221 RVA: 0x000533EC File Offset: 0x000523EC
			public int Poids
			{
				get
				{
					return this.poids;
				}
			}

			// Token: 0x0400057F RID: 1407
			private Switch depart;

			// Token: 0x04000580 RID: 1408
			private Switch arrivee;

			// Token: 0x04000581 RID: 1409
			private PortSwitch portDepart;

			// Token: 0x04000582 RID: 1410
			private PortSwitch portArrivee;

			// Token: 0x04000583 RID: 1411
			private int poids = 0;
		}

		// Token: 0x02000087 RID: 135
		public enum EtatIp
		{
			// Token: 0x04000585 RID: 1413
			aucun,
			// Token: 0x04000586 RID: 1414
			attente,
			// Token: 0x04000587 RID: 1415
			simulationEnCours
		}

		// Token: 0x02000088 RID: 136
		public enum EtatAppl
		{
			// Token: 0x04000589 RID: 1417
			aucun,
			// Token: 0x0400058A RID: 1418
			attente,
			// Token: 0x0400058B RID: 1419
			simulationEnCours
		}
	}
}
