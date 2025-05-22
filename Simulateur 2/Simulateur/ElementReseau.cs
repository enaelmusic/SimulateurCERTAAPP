using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Simulateur
{
	// Token: 0x02000002 RID: 2
	public class ElementReseau : UserControl
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
		public ElementReseau(Simulation s)
		{
			this.InitializeComponent();
			this.reseau = s;
			this.initialiser();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000208C File Offset: 0x0000108C
		public ElementReseau()
		{
			this.InitializeComponent();
			this.stylo = new Pen(Brushes.Black, 1f);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020D0 File Offset: 0x000010D0
		private void initialiser()
		{
			this.stylo = this.reseau.Pref.NormalStylo;
			this.styloRelief = new Pen(this.BackColor);
			this.police = this.reseau.Pref.Police;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000211C File Offset: 0x0000111C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002148 File Offset: 0x00001148
		private void InitializeComponent()
		{
			this.components = new Container();
			this.cm_conception = new ContextMenu();
			this.mi_configurer = new MenuItem();
			this.cm_ethernet = new ContextMenu();
			this.infoBulle = new ToolTip(this.components);
			this.cm_ip = new ContextMenu();
			this.cm_appl = new ContextMenu();
			this.cm_conception.MenuItems.AddRange(new MenuItem[]
			{
				this.mi_configurer
			});
			this.mi_configurer.Index = 0;
			this.mi_configurer.Text = "Configurer";
			this.mi_configurer.Click += this.mi_configurer_Click;
			this.infoBulle.Active = false;
			this.infoBulle.AutomaticDelay = 1;
			this.infoBulle.AutoPopDelay = 2500;
			this.infoBulle.InitialDelay = 1;
			this.infoBulle.ReshowDelay = 0;
			this.infoBulle.ShowAlways = true;
			base.Name = "ElementReseau";
			base.Size = new Size(96, 39);
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000006 RID: 6 RVA: 0x00002264 File Offset: 0x00001264
		public ToolTip InfoBulle
		{
			get
			{
				return this.infoBulle;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002278 File Offset: 0x00001278
		public Simulation Reseau
		{
			get
			{
				return this.reseau;
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000228C File Offset: 0x0000128C
		public virtual void ModifierCouleurConnexions()
		{
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000009 RID: 9 RVA: 0x0000229C File Offset: 0x0000129C
		// (set) Token: 0x0600000A RID: 10 RVA: 0x000022B0 File Offset: 0x000012B0
		public Pen Stylo
		{
			get
			{
				return this.stylo;
			}
			set
			{
				this.stylo = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000022C4 File Offset: 0x000012C4
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000022D8 File Offset: 0x000012D8
		public Pen StyloRelief
		{
			get
			{
				return this.styloRelief;
			}
			set
			{
				this.styloRelief = value;
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000022EC File Offset: 0x000012EC
		public virtual void Allumer()
		{
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000022FC File Offset: 0x000012FC
		public virtual void Eteindre()
		{
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000230C File Offset: 0x0000130C
		private void mi_configurer_Click(object sender, EventArgs e)
		{
			this.Configurer();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002320 File Offset: 0x00001320
		public virtual void Configurer()
		{
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002330 File Offset: 0x00001330
		protected virtual ContextMenu menuConception()
		{
			return null;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002340 File Offset: 0x00001340
		protected virtual ContextMenu menuEthernet()
		{
			return this.cm_ethernet;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002354 File Offset: 0x00001354
		public ContextMenu GetContextMenu()
		{
			ContextMenu result;
			switch (this.reseau.ModeActif)
			{
			case Simulation.Mode.conceptionReseau:
				result = this.menuConception();
				break;
			case Simulation.Mode.ethernet:
				result = this.menuEthernet();
				break;
			case Simulation.Mode.ip:
				result = this.menuIp();
				break;
			case Simulation.Mode.appl:
				result = this.menuAppl();
				break;
			default:
				result = null;
				break;
			}
			return result;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000023AC File Offset: 0x000013AC
		public virtual void InstallerGestionEvenements()
		{
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000023BC File Offset: 0x000013BC
		public virtual void DesinstallerGestionEvenements()
		{
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000016 RID: 22 RVA: 0x000023CC File Offset: 0x000013CC
		// (remove) Token: 0x06000017 RID: 23 RVA: 0x000023F0 File Offset: 0x000013F0
		public event TrameEventHandler TrameTransmise;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000018 RID: 24 RVA: 0x00002414 File Offset: 0x00001414
		// (remove) Token: 0x06000019 RID: 25 RVA: 0x00002438 File Offset: 0x00001438
		public static event TrameEventHandler TransmissionTrameAchevee;

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600001A RID: 26 RVA: 0x0000245C File Offset: 0x0000145C
		public bool Libre
		{
			get
			{
				return this.trameEnCours == null;
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002474 File Offset: 0x00001474
		public virtual void Liberer()
		{
			this.trameEnCours = null;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002488 File Offset: 0x00001488
		protected void transmettreTrame(TrameEthernet trame, ElementReseau cible)
		{
			this.TrameTransmise(this, new TrameEventArgs(trame, cible));
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000024A8 File Offset: 0x000014A8
		protected void receptionnerTrame(TrameEthernet trame)
		{
			trame.NbTransmissionsEnCours--;
			this.reseau.NbTransmissionsTotales--;
			if (trame.NbTransmissionsEnCours == 0)
			{
				ElementReseau.TransmissionTrameAchevee(null, new TrameEventArgs(trame, null));
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000024F0 File Offset: 0x000014F0
		public virtual bool Occupe()
		{
			return this.trameEnCours != null;
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001F RID: 31 RVA: 0x0000250C File Offset: 0x0000150C
		// (set) Token: 0x06000020 RID: 32 RVA: 0x00002520 File Offset: 0x00001520
		public DemoDialogue Demo
		{
			get
			{
				return this.demo;
			}
			set
			{
				this.demo = value;
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002534 File Offset: 0x00001534
		public virtual Point posDialogueDemo()
		{
			return new Point(0, 0);
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002548 File Offset: 0x00001548
		public bool ReceptionEnCours
		{
			get
			{
				return this.senderEnCours != null;
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002564 File Offset: 0x00001564
		public virtual void Tracer(Graphics g)
		{
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002574 File Offset: 0x00001574
		public virtual void Effacer(Graphics g)
		{
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000025 RID: 37 RVA: 0x00002584 File Offset: 0x00001584
		// (remove) Token: 0x06000026 RID: 38 RVA: 0x000025A8 File Offset: 0x000015A8
		public event TrameEventHandler DebutTrameTransmis;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000027 RID: 39 RVA: 0x000025CC File Offset: 0x000015CC
		// (remove) Token: 0x06000028 RID: 40 RVA: 0x000025F0 File Offset: 0x000015F0
		public event TrameEventHandler FinTrameTransmis;

		// Token: 0x06000029 RID: 41 RVA: 0x00002614 File Offset: 0x00001614
		protected void transmettreDebutTrame(TrameEthernet trame, ElementReseau cible)
		{
			this.DebutTrameTransmis(this, new TrameEventArgs(trame, cible));
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002634 File Offset: 0x00001634
		protected void transmettreFinTrame(TrameEthernet trame, ElementReseau cible)
		{
			if (this.FinTrameTransmis != null)
			{
				this.FinTrameTransmis(this, new TrameEventArgs(trame, cible));
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000265C File Offset: 0x0000165C
		protected void receptionnerFinTrame(TrameEthernet trame, string avirer)
		{
			if (!trame.Annulee)
			{
				trame.NbTransmissionsEnCours--;
				this.reseau.NbTransmissionsTotales--;
				if (trame.NbTransmissionsEnCours == 0 && ElementReseau.TransmissionFinTrameAchevee != null)
				{
					ElementReseau.TransmissionFinTrameAchevee(null, new TrameEventArgs(trame, null));
				}
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000026B4 File Offset: 0x000016B4
		public void annulerTrame(TrameEthernet trame)
		{
			trame.NbTransmissionsEnCours = 0;
			trame.Annulee = true;
			trame.GenererAnnulation();
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600002D RID: 45 RVA: 0x000026D8 File Offset: 0x000016D8
		// (remove) Token: 0x0600002E RID: 46 RVA: 0x000026FC File Offset: 0x000016FC
		public static event TrameEventHandler TransmissionFinTrameAchevee;

		// Token: 0x0600002F RID: 47 RVA: 0x00002720 File Offset: 0x00001720
		public virtual void StockerXml(XmlTextWriter writer)
		{
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002730 File Offset: 0x00001730
		public virtual void ReinitEthernet()
		{
			this.trameEnCours = null;
			this.senderEnCours = null;
			this.demo = null;
			this.DesinstallerGestionEvenements();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002758 File Offset: 0x00001758
		public virtual void ChangerMode(Simulation.Mode nouveauMode)
		{
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002768 File Offset: 0x00001768
		public virtual void SetContenuInfoBulle()
		{
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002778 File Offset: 0x00001778
		protected virtual ContextMenu menuIp()
		{
			if (this.reseau.EtatIpActif == Simulation.EtatIp.attente)
			{
				return this.cm_ip;
			}
			return null;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000279C File Offset: 0x0000179C
		protected virtual ContextMenu menuAppl()
		{
			return this.cm_appl;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000027B0 File Offset: 0x000017B0
		public virtual Point GetCentre()
		{
			return new Point(base.Location.X + base.Size.Width / 2, base.Location.Y + base.Size.Height / 2);
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00002800 File Offset: 0x00001800
		// (set) Token: 0x06000037 RID: 55 RVA: 0x00002810 File Offset: 0x00001810
		public virtual int Longueur
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		// Token: 0x04000001 RID: 1
		private IContainer components;

		// Token: 0x04000002 RID: 2
		protected ToolTip infoBulle;

		// Token: 0x04000003 RID: 3
		protected ContextMenu cm_ip;

		// Token: 0x04000004 RID: 4
		protected ContextMenu cm_appl;

		// Token: 0x04000005 RID: 5
		protected Simulation reseau = null;

		// Token: 0x04000006 RID: 6
		protected Pen stylo;

		// Token: 0x04000007 RID: 7
		protected Pen styloRelief;

		// Token: 0x04000008 RID: 8
		protected ContextMenu cm_conception;

		// Token: 0x04000009 RID: 9
		protected MenuItem mi_configurer;

		// Token: 0x0400000A RID: 10
		protected ContextMenu cm_ethernet;

		// Token: 0x0400000B RID: 11
		protected Font police;

		// Token: 0x0400000E RID: 14
		protected TrameEventArgs trameEnCours = null;

		// Token: 0x0400000F RID: 15
		protected DemoDialogue demo;

		// Token: 0x04000010 RID: 16
		protected ElementReseau senderEnCours = null;
	}
}
