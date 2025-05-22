using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Simulateur
{
	// Token: 0x02000050 RID: 80
	public class Hub : Interconnexion
	{
		// Token: 0x06000436 RID: 1078 RVA: 0x0002E2B8 File Offset: 0x0002D2B8
		public Hub()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x0002E324 File Offset: 0x0002D324
		public Hub(Simulation s, string nom) : base(s, nom)
		{
			this.InitializeComponent();
			this.initialiser();
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x0002E398 File Offset: 0x0002D398
		private void initialiser()
		{
			this.etiquette = "Hub:";
			base.InitialiserPorts(this.reseau.Pref.NbPortsHub, this.reseau.Pref.NbPortsCascadeHub, 0);
			this.delaiTransmissionTrame.Interval = this.reseau.Pref.TempsDelaiTransmissionHub;
			this.delaiTransmissionDebutTrame.Interval = this.reseau.Pref.TempsDelaiTransmissionHub;
			this.delaiTransmissionFinTrame.Interval = this.reseau.Pref.TempsDelaiTransmissionHub;
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x0002E428 File Offset: 0x0002D428
		public Timer DelaiTransmissionTrame
		{
			get
			{
				return this.delaiTransmissionTrame;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600043A RID: 1082 RVA: 0x0002E43C File Offset: 0x0002D43C
		public Timer DelaiTransmissionFinTrame
		{
			get
			{
				return this.delaiTransmissionFinTrame;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x0002E450 File Offset: 0x0002D450
		public Timer DelaiTransmissionDebutTrame
		{
			get
			{
				return this.delaiTransmissionDebutTrame;
			}
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x0002E464 File Offset: 0x0002D464
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x0002E490 File Offset: 0x0002D490
		private void InitializeComponent()
		{
			base.Name = "Hub";
			base.Paint += this.Interconnexion_Paint;
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x0002E4BC File Offset: 0x0002D4BC
		public override void Configurer()
		{
			ConfigInterConnexion configInterConnexion = new ConfigInterConnexion();
			configInterConnexion.Text = "Configuration d'un Hub";
			configInterConnexion.Cacher8021q();
			base.ConfigurerGraphique(configInterConnexion);
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x0002E4E8 File Offset: 0x0002D4E8
		protected override void InterConn_TrameTransmise(ElementReseau sender, TrameEventArgs e)
		{
			if (e.Cible == this)
			{
				this.senderEnCours = sender;
				this.trameEnCours = e;
				if (this.reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.circulationTrame && base.trace())
				{
					this.demo = new DemoHub(this.reseau);
					this.demo.TitreDialogue = base.NomNoeud;
					this.demo.DemoTerminee += this.Hub_DemoTerminee;
					this.demo.DemarrerDemo(sender, this, e.Trame, this.reseau.TypeDemo);
					return;
				}
				this.receptionTrameNoDemo();
			}
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x0002E584 File Offset: 0x0002D584
		protected override void InterConn_DebutTrameTransmis(ElementReseau sender, TrameEventArgs e)
		{
			if (e.Cible == this && this.trameEnCours == null)
			{
				this.senderEnCours = sender;
				this.trameEnCours = e;
				e.Trame.IncrementerNbTransmissions();
				this.delaiTransmissionDebutTrame.Tick += this.FinDelaiTransmissionDebutTrameNoDemo;
				this.delaiTransmissionDebutTrame.Start();
			}
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x0002E5E0 File Offset: 0x0002D5E0
		public void FinDelaiTransmissionDebutTrameNoDemo(object sender, EventArgs e)
		{
			this.delaiTransmissionDebutTrame.Stop();
			this.delaiTransmissionDebutTrame.Tick -= this.FinDelaiTransmissionDebutTrameNoDemo;
			this.suiteReceptionDebutTrame(null, null);
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x0002E618 File Offset: 0x0002D618
		public void suiteReceptionDebutTrame(object sender, EventArgs e)
		{
			if (!this.trameEnCours.Trame.Collisee)
			{
				if (this.enCollision || this.collisionRecue)
				{
					return;
				}
				ElementReseau senderEnCours = this.senderEnCours;
				this.senderEnCours = null;
				using (IEnumerator enumerator = base.Controls.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						PortHub portHub = (PortHub)obj;
						if (portHub.EtatConnexion == PointConnexion.EtatsConnexion.actif && portHub != senderEnCours)
						{
							base.transmettreDebutTrame(this.trameEnCours.Trame, portHub.Lien);
						}
					}
					return;
				}
			}
			this.trameEnCours = null;
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x0002E6D4 File Offset: 0x0002D6D4
		protected override void InterConn_FinTrameTransmis(ElementReseau sender, TrameEventArgs e)
		{
			if (e.Cible == this)
			{
				if (!this.enCollision && !this.collisionRecue)
				{
					this.forcerSuiteFinTrame = true;
				}
				this.trameFinEnCours = e.Trame;
				this.senderEnCours = sender;
				this.delaiTransmissionFinTrame.Tick += this.FinDelaiTransmissionFinTrameNoDemo;
				this.delaiTransmissionFinTrame.Start();
			}
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x0002E738 File Offset: 0x0002D738
		public void FinDelaiTransmissionFinTrameNoDemo(object sender, EventArgs e)
		{
			this.delaiTransmissionFinTrame.Stop();
			this.delaiTransmissionFinTrame.Tick -= this.FinDelaiTransmissionFinTrameNoDemo;
			if (!this.enCollision && !this.collisionRecue)
			{
				this.suiteReceptionFinTrame(null, null);
				return;
			}
			if (this.enCollision)
			{
				base.annulerTrame(this.trameFinEnCours);
				return;
			}
			if (this.forcerSuiteFinTrame)
			{
				this.forcerSuiteFinTrame = false;
				this.suiteReceptionFinTrame(null, null);
			}
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x0002E7AC File Offset: 0x0002D7AC
		private void suiteReceptionFinTrame(object sender, EventArgs e)
		{
			if (this.trameEnCours != null)
			{
				ElementReseau senderEnCours = this.senderEnCours;
				this.senderEnCours = null;
				foreach (object obj in base.Controls)
				{
					PortHub portHub = (PortHub)obj;
					if (portHub.EtatConnexion == PointConnexion.EtatsConnexion.actif && portHub != senderEnCours)
					{
						base.transmettreFinTrame(this.trameEnCours.Trame, portHub.Lien);
					}
				}
				base.receptionnerFinTrame(this.trameEnCours.Trame, "hub");
				this.trameEnCours = null;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000446 RID: 1094 RVA: 0x0002E864 File Offset: 0x0002D864
		// (set) Token: 0x06000447 RID: 1095 RVA: 0x0002E878 File Offset: 0x0002D878
		public bool EnCollision
		{
			get
			{
				return this.enCollision;
			}
			set
			{
				this.enCollision = value;
			}
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0002E88C File Offset: 0x0002D88C
		public void DessinerCollision()
		{
			this.styloEllipse = new Pen(this.reseau.Pref.StyloCollision.Brush, 1.5f);
			this.gCollisionHub = base.CreateGraphics();
			this.gCollisionSchema = this.reseau.Schema.CreateGraphics();
			this.pointCollision = new PointF((float)(base.Location.X + base.Width / 2), (float)base.Location.Y);
			this.centre = new PointF((float)(base.Width / 2), 0f);
			this.collisionEnCours = true;
			this.nbCercles = (int)((double)this.reseau.Pref.DistanceCercleCollision * 0.65);
			this.gCollisionHub.FillEllipse(this.styloEllipse.Brush, this.centre.X - (float)(this.nbCercles / 2 + 1), this.centre.Y - (float)(this.nbCercles / 2 + 1), (float)(this.nbCercles + 2), (float)(this.nbCercles + 2));
			this.gCollisionSchema.FillEllipse(this.styloEllipse.Brush, this.pointCollision.X - (float)(this.nbCercles / 2 + 1), this.pointCollision.Y - (float)(this.nbCercles / 2 + 1), (float)(this.nbCercles + 2), (float)(this.nbCercles + 2));
			this.reseau.TimerTraceTrame.Tick += this.suiteDessinerCollision;
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x0002EA1C File Offset: 0x0002DA1C
		private void suiteDessinerCollision(object sender, EventArgs e)
		{
			this.nbTicksAttente++;
			if (this.nbTicksAttente > this.reseau.Pref.NbTicksAttenteCercleCollision)
			{
				this.nbCercles += this.reseau.Pref.DistanceCercleCollision;
				if (this.nbCercles > this.reseau.Pref.LimiteCercleCollision)
				{
					this.collisionEnCours = false;
					base.Invalidate();
					this.reseau.Schema.Invalidate(new Rectangle((int)(this.pointCollision.X - (float)(this.nbCercles / 2 + 2)), (int)(this.pointCollision.Y - (float)(this.nbCercles / 2 + 2)), this.nbCercles + 5, this.nbCercles + 5), false);
					this.reseau.TimerTraceTrame.Tick -= this.suiteDessinerCollision;
				}
				else
				{
					this.gCollisionHub.DrawEllipse(this.styloEllipse, this.centre.X - (float)(this.nbCercles / 2 + 1), this.centre.Y - (float)(this.nbCercles / 2 + 1), (float)(this.nbCercles + 2), (float)(this.nbCercles + 2));
					this.gCollisionSchema.DrawEllipse(this.styloEllipse, this.pointCollision.X - (float)(this.nbCercles / 2 + 1), this.pointCollision.Y - (float)(this.nbCercles / 2 + 1), (float)(this.nbCercles + 2), (float)(this.nbCercles + 2));
				}
				this.nbTicksAttente = 0;
			}
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x0002EBB8 File Offset: 0x0002DBB8
		protected override void Interconnexion_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.DrawRectangle(this.stylo, 0, 0, base.Width - 1, base.Height - 1);
			graphics.DrawString(this.etiquette + this.nomNoeud, this.police, this.stylo.Brush, 1f, 2f);
			if (this.collisionEnCours)
			{
				int i = (int)((double)this.reseau.Pref.DistanceCercleCollision * 0.65);
				graphics.FillEllipse(this.styloEllipse.Brush, this.centre.X - (float)(i / 2 + 1), this.centre.Y - (float)(i / 2 + 1), (float)(i + 2), (float)(i + 2));
				this.gCollisionSchema.FillEllipse(this.styloEllipse.Brush, this.pointCollision.X - (float)(i / 2 + 1), this.pointCollision.Y - (float)(i / 2 + 1), (float)(i + 2), (float)(i + 2));
				for (i += this.reseau.Pref.DistanceCercleCollision; i <= this.nbCercles; i += this.reseau.Pref.DistanceCercleCollision)
				{
					graphics.DrawEllipse(this.styloEllipse, this.centre.X - (float)(i / 2 + 1), this.centre.Y - (float)(i / 2 + 1), (float)(i + 2), (float)(i + 2));
					this.gCollisionSchema.DrawEllipse(this.styloEllipse, this.pointCollision.X - (float)(i / 2 + 1), this.pointCollision.Y - (float)(i / 2 + 1), (float)(i + 2), (float)(i + 2));
				}
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x0002ED70 File Offset: 0x0002DD70
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x0002ED84 File Offset: 0x0002DD84
		public bool CollisionRecue
		{
			get
			{
				return this.collisionRecue;
			}
			set
			{
				this.collisionRecue = value;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x0002ED98 File Offset: 0x0002DD98
		public TrameEventArgs TrameEnCours
		{
			get
			{
				return this.trameEnCours;
			}
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x0002EDAC File Offset: 0x0002DDAC
		public override void Liberer()
		{
			base.Liberer();
			this.delaiTransmissionDebutTrame.Stop();
			this.delaiTransmissionFinTrame.Stop();
			this.delaiTransmissionFinTrame.Tick -= this.FinDelaiTransmissionFinTrameNoDemo;
			this.delaiTransmissionDebutTrame.Tick -= this.FinDelaiTransmissionDebutTrameNoDemo;
			this.collisionRecue = false;
			this.enCollision = false;
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x0002EE14 File Offset: 0x0002DE14
		public void AnnulerTrameEnCours()
		{
			this.trameEnCours = null;
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x0002EE28 File Offset: 0x0002DE28
		public void ColliserTrameEnCours()
		{
			this.trameEnCours.Trame.Collisee = true;
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0002EE48 File Offset: 0x0002DE48
		private void Hub_DemoTerminee(object sender, EventArgs e)
		{
			if (this.demo != null)
			{
				this.demo.DemoTerminee -= this.Hub_DemoTerminee;
				this.demo = null;
			}
			this.incrementerTransmissionsTrame();
			this.suiteReceptionTrame(null, null);
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x0002EE8C File Offset: 0x0002DE8C
		private void incrementerTransmissionsTrame()
		{
			foreach (object obj in base.Controls)
			{
				PortHub portHub = (PortHub)obj;
				if (portHub.EtatConnexion == PointConnexion.EtatsConnexion.actif && portHub != this.senderEnCours)
				{
					this.trameEnCours.Trame.IncrementerNbTransmissions();
				}
			}
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x0002EF0C File Offset: 0x0002DF0C
		private void receptionTrameNoDemo()
		{
			this.incrementerTransmissionsTrame();
			this.delaiTransmissionTrame.Tick += this.FinDelaiTransmissionTrameNoDemo;
			this.delaiTransmissionTrame.Start();
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x0002EF44 File Offset: 0x0002DF44
		public void FinDelaiTransmissionTrameNoDemo(object sender, EventArgs e)
		{
			this.delaiTransmissionTrame.Stop();
			this.delaiTransmissionTrame.Tick -= this.FinDelaiTransmissionTrameNoDemo;
			this.suiteReceptionTrame(null, null);
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x0002EF7C File Offset: 0x0002DF7C
		public void suiteReceptionTrame(object sender, EventArgs e)
		{
			ElementReseau senderEnCours = this.senderEnCours;
			this.senderEnCours = null;
			foreach (object obj in base.Controls)
			{
				PortHub portHub = (PortHub)obj;
				if (portHub.EtatConnexion == PointConnexion.EtatsConnexion.actif && portHub != senderEnCours)
				{
					base.transmettreTrame(this.trameEnCours.Trame, portHub.Lien);
				}
			}
			base.receptionnerTrame(this.trameEnCours.Trame);
			this.trameEnCours = null;
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x0002F024 File Offset: 0x0002E024
		public override Port nouveauPort()
		{
			return new PortHub(this.reseau);
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x0002F03C File Offset: 0x0002E03C
		public override Port nouveauPortDeCascade()
		{
			return new PortDeCascadeHub(this.reseau);
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x0002F054 File Offset: 0x0002E054
		public override void StockerXml(XmlTextWriter writer)
		{
			writer.WriteStartElement("hub");
			base.StockerXml(writer);
			writer.WriteEndElement();
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x0002F07C File Offset: 0x0002E07C
		public void envoyerCollisionDeuxPaires(PortHub emetteur)
		{
			if (!this.collisionRecue)
			{
				this.collisionRecue = true;
				foreach (object obj in base.Controls)
				{
					PortHub portHub = (PortHub)obj;
					if (portHub != emetteur && portHub.EtatConnexion == PointConnexion.EtatsConnexion.actif)
					{
						portHub.envoyerCollisionDeuxPaires();
					}
				}
			}
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x0002F0FC File Offset: 0x0002E0FC
		public void EnvoyerFinTrameCollisee(PortHub emetteur)
		{
			foreach (object obj in base.Controls)
			{
				PortHub portHub = (PortHub)obj;
				if (portHub != emetteur && portHub.EtatConnexion == PointConnexion.EtatsConnexion.actif)
				{
					portHub.Lien.EnvoyerFinTrameCollisee(portHub);
				}
			}
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x0002F174 File Offset: 0x0002E174
		public override void ReinitEthernet()
		{
			base.ReinitEthernet();
			this.trameFinEnCours = null;
			if (this.demo != null)
			{
				this.demo.DemoTerminee -= this.Hub_DemoTerminee;
				this.demo = null;
			}
			this.trameFinEnCours = null;
			if (this.delaiTransmissionTrame != null)
			{
				this.delaiTransmissionTrame.Tick -= this.FinDelaiTransmissionTrameNoDemo;
			}
			if (this.delaiTransmissionDebutTrame != null)
			{
				this.delaiTransmissionDebutTrame.Tick -= this.FinDelaiTransmissionDebutTrameNoDemo;
			}
			if (this.delaiTransmissionFinTrame != null)
			{
				this.delaiTransmissionFinTrame.Tick -= this.FinDelaiTransmissionFinTrameNoDemo;
			}
			this.reseau.TimerTraceTrame.Tick -= this.suiteDessinerCollision;
			this.collisionEnCours = false;
			this.collisionRecue = false;
			this.enCollision = false;
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x0002F24C File Offset: 0x0002E24C
		public override void TransmissionRapideEthernet(bool demo, PointConnexion demandeur, Ip_PaquetIp paquet, bool suivreLiensPortsEteints, ReactionStation rs, ReactionSwitch rsw)
		{
			foreach (object obj in base.Controls)
			{
				PortHub portHub = (PortHub)obj;
				if (portHub != demandeur && (portHub.EtatConnexion == PointConnexion.EtatsConnexion.actif || (suivreLiensPortsEteints && portHub.Lien != null)))
				{
					portHub.Lien.TransmissionRapideEthernet(demo, portHub, paquet, suivreLiensPortsEteints, rs, rsw);
				}
			}
		}

		// Token: 0x0400031F RID: 799
		private IContainer components = null;

		// Token: 0x04000320 RID: 800
		private TrameEthernet trameFinEnCours;

		// Token: 0x04000321 RID: 801
		private bool forcerSuiteFinTrame = false;

		// Token: 0x04000322 RID: 802
		private bool enCollision = false;

		// Token: 0x04000323 RID: 803
		private int nbTicksAttente = 0;

		// Token: 0x04000324 RID: 804
		private int nbCercles = 0;

		// Token: 0x04000325 RID: 805
		private bool collisionEnCours = false;

		// Token: 0x04000326 RID: 806
		private PointF pointCollision;

		// Token: 0x04000327 RID: 807
		private PointF centre;

		// Token: 0x04000328 RID: 808
		private Graphics gCollisionHub;

		// Token: 0x04000329 RID: 809
		private Graphics gCollisionSchema;

		// Token: 0x0400032A RID: 810
		private Pen styloEllipse;

		// Token: 0x0400032B RID: 811
		private bool collisionRecue = false;

		// Token: 0x0400032C RID: 812
		private Timer delaiTransmissionTrame = new Timer();

		// Token: 0x0400032D RID: 813
		private Timer delaiTransmissionDebutTrame = new Timer();

		// Token: 0x0400032E RID: 814
		private Timer delaiTransmissionFinTrame = new Timer();
	}
}
