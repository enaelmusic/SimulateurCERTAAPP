using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Simulateur
{
	// Token: 0x02000007 RID: 7
	public class Cable : TraceManuel
	{
		// Token: 0x0600004F RID: 79 RVA: 0x00003B74 File Offset: 0x00002B74
		public Cable()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003BCC File Offset: 0x00002BCC
		public Cable(Simulation s) : base(s)
		{
			this.InitializeComponent();
			this.longueur = s.Pref.LongueurCableDefaut;
			this.routinePaint = new Cable.cableRoutinePaint(this.Cable_PaintSimple);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003C48 File Offset: 0x00002C48
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003C74 File Offset: 0x00002C74
		private void InitializeComponent()
		{
			base.Name = "Cable";
			base.Paint += this.Cable_Paint;
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00003CA0 File Offset: 0x00002CA0
		// (set) Token: 0x06000054 RID: 84 RVA: 0x00003CB4 File Offset: 0x00002CB4
		public PointConnexion Origine
		{
			get
			{
				return this.pointA;
			}
			set
			{
				this.pointA = value;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00003CC8 File Offset: 0x00002CC8
		// (set) Token: 0x06000056 RID: 86 RVA: 0x00003CDC File Offset: 0x00002CDC
		public PointConnexion Extremite
		{
			get
			{
				return this.pointB;
			}
			set
			{
				this.pointB = value;
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003CF0 File Offset: 0x00002CF0
		public PointConnexion Oppose(PointConnexion p)
		{
			if (p == this.pointA)
			{
				return this.pointB;
			}
			return this.pointA;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003D14 File Offset: 0x00002D14
		public void DebuterLiaison(PointConnexion pa)
		{
			this.pointA = pa;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003D28 File Offset: 0x00002D28
		public void terminerLiaison(PointConnexion pb)
		{
			this.pointB = pb;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003D3C File Offset: 0x00002D3C
		public void Deconnecter()
		{
			this.pointA.Deconnecter();
			this.pointB.Deconnecter();
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003D60 File Offset: 0x00002D60
		private void Cable_PaintSimple(object sender, PaintEventArgs e)
		{
			Graphics graphics = this.reseau.Schema.CreateGraphics();
			graphics.DrawLine(this.stylo, this.pointA.Centre, this.pointB.Centre);
			graphics.Dispose();
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003DA8 File Offset: 0x00002DA8
		public void Cable_Paint(object sender, PaintEventArgs e)
		{
			this.routinePaint(sender, e);
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00003DC4 File Offset: 0x00002DC4
		// (set) Token: 0x0600005E RID: 94 RVA: 0x00003DD8 File Offset: 0x00002DD8
		public Cable.TypeCable Type
		{
			get
			{
				return this.type;
			}
			set
			{
				this.type = value;
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003DEC File Offset: 0x00002DEC
		public bool Activable()
		{
			bool result = false;
			switch (this.type)
			{
			case Cable.TypeCable.croise:
				result = this.pointA.OkCableCroise(this.pointB.TypePointConnexion);
				break;
			case Cable.TypeCable.droit:
				result = this.pointA.OkCableDroit(this.pointB.TypePointConnexion);
				break;
			case Cable.TypeCable.coaxial:
				result = this.pointA.OkCableCoaxial(this.pointB.TypePointConnexion);
				break;
			case Cable.TypeCable.telecom:
				result = this.pointA.OkCableTelecom(this.pointB.TypePointConnexion);
				break;
			}
			return result;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003E80 File Offset: 0x00002E80
		public override Rectangle RectangleTrace()
		{
			return Rectangle.Union(this.pointA.RectangleAttache(), this.pointB.RectangleAttache());
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00003EA8 File Offset: 0x00002EA8
		// (set) Token: 0x06000062 RID: 98 RVA: 0x00003EBC File Offset: 0x00002EBC
		public TraceCable Trace
		{
			get
			{
				return this.trace;
			}
			set
			{
				this.trace = value;
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003ED0 File Offset: 0x00002ED0
		public bool OkTypeCable(PointConnexion a, PointConnexion b)
		{
			return this.type != Cable.TypeCable.coaxial || (a.GetType() == typeof(CarteReseau) && b.GetType() == typeof(CarteReseau));
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003F10 File Offset: 0x00002F10
		private void Cable_TrameTransmise(ElementReseau sender, TrameEventArgs e)
		{
			if (e.Cible == this)
			{
				e.Trame.AddCableTraverse(this);
				e.Trame.IncrementerNbTransmissions();
				this.trameEnCours = e;
				this.senderEnCours = sender;
				this.stylo = this.reseau.Pref.CableActifStylo1;
				this.trace = new TraceCable(e.Trame.Marque8021q, TraceCable.TypeDeTrace.ethernetNoCollision, this.reseau.Pref.CableActifStylo1, this.reseau.Pref.CableActifStylo2, this.reseau.Pref.StyloCollision, this.reseau.Pref.StyloCable, this.reseau.Schema.BackColor, this, ((PointConnexion)sender).Centre, this.Oppose((PointConnexion)sender).Centre);
				base.Paint -= this.Cable_Paint;
				base.Paint += this.trace.TracerCable;
				this.trace.TraceTermine += this.FinTraceCable;
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00004028 File Offset: 0x00003028
		public override void Liberer()
		{
			base.Liberer();
			this.trameTransmiseParPointA = null;
			this.trameTransmiseParPointB = null;
			this.trace = null;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00004050 File Offset: 0x00003050
		private void eteindreReceptionCartes()
		{
			if (this.pointA.GetType() == typeof(CarteReseau) && ((CarteReseau)this.pointA).EnReception)
			{
				this.pointA.EteindreReception();
			}
			if (this.pointB.GetType() == typeof(CarteReseau) && ((CarteReseau)this.pointB).EnReception)
			{
				((CarteReseau)this.pointB).EteindreReception();
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000040CC File Offset: 0x000030CC
		public void StopperTrace()
		{
			if (this.trace != null)
			{
				this.trace.Stopper();
				this.eteindreReceptionCartes();
			}
			else if (this.trameTransmiseParPointA != null || this.trameTransmiseParPointB != null)
			{
				this.reseau.Schema.Invalidate(this.RectangleTrace());
				this.eteindreReceptionCartes();
			}
			this.Liberer();
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00004128 File Offset: 0x00003128
		public void FinTraceCable(object sender, EventArgs e)
		{
			ElementReseau senderEnCours = this.senderEnCours;
			this.senderEnCours = null;
			if (this.trace != null)
			{
				this.trace.TraceTermine -= this.FinTraceCable;
				base.Paint -= this.trace.TracerCable;
				base.Paint += this.Cable_Paint;
			}
			this.trace = null;
			base.transmettreTrame(this.trameEnCours.Trame, this.Oppose((PointConnexion)senderEnCours));
			base.receptionnerTrame(this.trameEnCours.Trame);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000041C0 File Offset: 0x000031C0
		public override void InstallerGestionEvenements()
		{
			this.pointA.TrameTransmise += this.Cable_TrameTransmise;
			this.pointB.TrameTransmise += this.Cable_TrameTransmise;
			this.pointA.DebutTrameTransmis += this.Cable_DebutTrameTransmis;
			this.pointB.DebutTrameTransmis += this.Cable_DebutTrameTransmis;
			this.pointA.FinTrameTransmis += this.Cable_FinTrameTransmis;
			this.pointB.FinTrameTransmis += this.Cable_FinTrameTransmis;
			PointConnexion pointConnexion = this.pointA;
			pointConnexion.CollisionDeuxPaires = (EventHandler)Delegate.Combine(pointConnexion.CollisionDeuxPaires, new EventHandler(this.Cable_CollisionDeuxPairesTransmise));
			PointConnexion pointConnexion2 = this.pointB;
			pointConnexion2.CollisionDeuxPaires = (EventHandler)Delegate.Combine(pointConnexion2.CollisionDeuxPaires, new EventHandler(this.Cable_CollisionDeuxPairesTransmise));
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000042A8 File Offset: 0x000032A8
		public override void DesinstallerGestionEvenements()
		{
			this.pointA.TrameTransmise -= this.Cable_TrameTransmise;
			this.pointB.TrameTransmise -= this.Cable_TrameTransmise;
			this.pointA.DebutTrameTransmis -= this.Cable_DebutTrameTransmis;
			this.pointB.DebutTrameTransmis -= this.Cable_DebutTrameTransmis;
			this.pointA.FinTrameTransmis -= this.Cable_FinTrameTransmis;
			this.pointB.FinTrameTransmis -= this.Cable_FinTrameTransmis;
			PointConnexion pointConnexion = this.pointA;
			pointConnexion.CollisionDeuxPaires = (EventHandler)Delegate.Remove(pointConnexion.CollisionDeuxPaires, new EventHandler(this.Cable_CollisionDeuxPairesTransmise));
			PointConnexion pointConnexion2 = this.pointB;
			pointConnexion2.CollisionDeuxPaires = (EventHandler)Delegate.Remove(pointConnexion2.CollisionDeuxPaires, new EventHandler(this.Cable_CollisionDeuxPairesTransmise));
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00004390 File Offset: 0x00003390
		// (set) Token: 0x0600006C RID: 108 RVA: 0x000043A4 File Offset: 0x000033A4
		public override int Longueur
		{
			get
			{
				return this.longueur;
			}
			set
			{
				this.longueur = value;
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000043B8 File Offset: 0x000033B8
		public override void Tracer(Graphics g)
		{
			g.DrawLine(this.stylo, this.pointA.Centre, this.pointB.Centre);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000043E8 File Offset: 0x000033E8
		public override void Effacer(Graphics g)
		{
			g.DrawLine(this.reseau.StyloEfface, this.pointA.Centre, this.pointB.Centre);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000441C File Offset: 0x0000341C
		private void Cable_CollisionDeuxPairesTransmise(object sender, EventArgs e)
		{
			if (sender == this.pointA)
			{
				if (this.traceAtoB == null)
				{
					Point pos = this.pointA.Emetteur.Pos;
					Point pos2 = this.pointB.Recepteur.Pos;
					this.traceAtoB = new TraceCable(false, TraceCable.TypeDeTrace.ethernetNoCollision, this.reseau.Pref.StyloCollision, this.reseau.Pref.StyloCollision, this.reseau.Pref.StyloCollision, this.reseau.Pref.StyloCable, this.reseau.Schema.BackColor, this, pos, pos2);
					base.Paint += this.traceAtoB.TracerCable;
				}
				else
				{
					this.traceAtoB.TraceTermine -= this.FinTraceAtoB;
					this.traceAtoB.AjouterCollision();
				}
				this.traceAtoB.EnCollisionDeuxPaires = true;
				this.traceAtoB.TraceTermine -= this.FinTraceAtoBFinTrameCollisee;
				this.traceAtoB.TraceTermine += this.finCollision;
				this.collisionAtoB = true;
				return;
			}
			if (this.traceBtoA == null)
			{
				Point pos = this.pointB.Emetteur.Pos;
				Point pos2 = this.pointA.Recepteur.Pos;
				this.traceBtoA = new TraceCable(false, TraceCable.TypeDeTrace.ethernetNoCollision, this.reseau.Pref.StyloCollision, this.reseau.Pref.StyloCollision, this.reseau.Pref.StyloCollision, this.reseau.Pref.StyloCable, this.reseau.Schema.BackColor, this, pos, pos2);
				base.Paint += this.traceBtoA.TracerCable;
			}
			else
			{
				this.traceBtoA.TraceTermine -= this.FinTraceBtoA;
				this.traceBtoA.AjouterCollision();
			}
			this.traceBtoA.EnCollisionDeuxPaires = true;
			this.traceBtoA.TraceTermine -= this.FinTraceBtoAFinTrameCollisee;
			this.traceBtoA.TraceTermine += this.finCollision;
			this.collisionAtoB = false;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00004648 File Offset: 0x00003648
		public void EnvoyerFinTrameCollisee(Port p)
		{
			if (p == this.pointA)
			{
				if (this.traceAtoB != null && !this.traceAtoB.EnCollisionDeuxPaires && this.traceAtoB.ReceptifFinTrameCollisee())
				{
					this.traceAtoB.TraceTermine -= this.FinTraceAtoB;
					this.traceAtoB.TraceTermine += this.FinTraceAtoBFinTrameCollisee;
					if (this.traceAtoB.ExisteSuiveur)
					{
						this.traceAtoB.FinirTrame(2);
						return;
					}
					this.traceAtoB.FinirTrame(1);
					return;
				}
			}
			else if (this.traceBtoA != null && !this.traceBtoA.EnCollisionDeuxPaires && this.traceBtoA.ReceptifFinTrameCollisee())
			{
				this.traceBtoA.TraceTermine -= this.FinTraceBtoA;
				this.traceBtoA.TraceTermine += this.FinTraceBtoAFinTrameCollisee;
				if (this.traceBtoA.ExisteSuiveur)
				{
					this.traceBtoA.FinirTrame(2);
					return;
				}
				this.traceBtoA.FinirTrame(1);
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00004758 File Offset: 0x00003758
		public void FinTraceAtoBFinTrameCollisee(object sender, EventArgs e)
		{
			this.traceAtoB.TraceTermine -= this.FinTraceAtoBFinTrameCollisee;
			base.Paint -= this.traceAtoB.TracerCable;
			this.traceAtoB = null;
			if (this.reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.trameReelle)
			{
				this.redessiner(Cable.sensRedessiner.AtoB);
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000047B0 File Offset: 0x000037B0
		public void FinTraceBtoAFinTrameCollisee(object sender, EventArgs e)
		{
			this.traceBtoA.TraceTermine -= this.FinTraceBtoAFinTrameCollisee;
			base.Paint -= this.traceBtoA.TracerCable;
			this.traceBtoA = null;
			if (this.reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.trameReelle)
			{
				this.redessiner(Cable.sensRedessiner.BtoA);
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00004808 File Offset: 0x00003808
		public void EcouterCollisionRepandue(PortHub sender)
		{
			sender.CollisionRepandue = (EventHandler)Delegate.Combine(sender.CollisionRepandue, new EventHandler(this.collisionPortHubRepandue));
			this.portHubEcoutes.Add(sender);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00004844 File Offset: 0x00003844
		public void NePasEcouterCollisionRepandue(PortHub sender)
		{
			sender.CollisionRepandue = (EventHandler)Delegate.Remove(sender.CollisionRepandue, new EventHandler(this.collisionPortHubRepandue));
			this.portHubEcoutes.Remove(sender);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00004880 File Offset: 0x00003880
		private void finCollision(object sender, EventArgs e)
		{
			object sender2;
			if (this.collisionAtoB)
			{
				this.traceAtoB.TraceTermine -= this.finCollision;
				sender2 = this.pointA;
			}
			else
			{
				this.traceBtoA.TraceTermine -= this.finCollision;
				sender2 = this.pointB;
			}
			if (this.CollisionDeuxPaires != null)
			{
				this.CollisionDeuxPaires(sender2, new EventArgs());
			}
			if (this.CollisionRepandueParCable != null)
			{
				this.CollisionRepandueParCable(this, new EventArgs());
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00004908 File Offset: 0x00003908
		private void collisionPortHubRepandue(object sender, EventArgs e)
		{
			PortHub portHub = (PortHub)sender;
			portHub.CollisionRepandue = (EventHandler)Delegate.Remove(portHub.CollisionRepandue, new EventHandler(this.collisionPortHubRepandue));
			if (this.collisionAtoB)
			{
				base.Paint -= this.traceAtoB.TracerCable;
				this.trameAtoB = null;
				this.traceAtoB = null;
				this.redessiner(Cable.sensRedessiner.AtoB);
			}
			else
			{
				base.Paint -= this.traceBtoA.TracerCable;
				this.trameBtoA = null;
				this.traceBtoA = null;
				this.redessiner(Cable.sensRedessiner.BtoA);
			}
			if (this.CollisionRepandue != null)
			{
				this.CollisionRepandue(this, new EventArgs());
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000049B8 File Offset: 0x000039B8
		public void redessiner(Cable.sensRedessiner sens)
		{
			Graphics graphics = this.reseau.Schema.CreateGraphics();
			switch (sens)
			{
			case Cable.sensRedessiner.AtoB:
				graphics.DrawLine(this.reseau.StyloGomme, this.pointA.Emetteur.Pos, this.pointB.Recepteur.Pos);
				if (this.deuxPaires)
				{
					graphics.DrawLine(this.reseau.Pref.NormalStylo, this.pointA.Emetteur.Pos, this.pointB.Recepteur.Pos);
				}
				break;
			case Cable.sensRedessiner.BtoA:
				graphics.DrawLine(this.reseau.StyloGomme, this.pointB.Emetteur.Pos, this.pointA.Recepteur.Pos);
				if (this.deuxPaires)
				{
					graphics.DrawLine(this.reseau.Pref.NormalStylo, this.pointB.Emetteur.Pos, this.pointA.Recepteur.Pos);
				}
				break;
			case Cable.sensRedessiner.milieu:
				graphics.DrawLine(this.reseau.StyloGomme, this.pointA.Centre, this.pointB.Centre);
				graphics.DrawLine(this.reseau.Pref.NormalStylo, this.pointA.Centre, this.pointB.Centre);
				break;
			}
			graphics.Dispose();
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00004B34 File Offset: 0x00003B34
		private void Cable_DebutTrameTransmis(ElementReseau sender, TrameEventArgs e)
		{
			if (e.Cible == this)
			{
				if (this.reseau.DeuxTrames && this.type != Cable.TypeCable.coaxial)
				{
					e.Trame.AddCableTraverse(this);
					if (sender == this.pointA)
					{
						if (this.traceAtoB == null)
						{
							this.numPremiereTrameAtoB = e.Trame.NumeroTrame;
							Point pos = this.pointA.Emetteur.Pos;
							Point pos2 = this.pointB.Recepteur.Pos;
							this.trameAtoB = e;
							if (e.Trame.NumeroTrame == 1)
							{
								this.traceAtoB = new TraceCable(e.Trame.Marque8021q, TraceCable.TypeDeTrace.ethernetAvecCollision, this.reseau.Pref.CableActifStylo1, this.reseau.Pref.CableActifStylo2, this.reseau.Pref.StyloCollision, this.reseau.Pref.StyloCable, this.reseau.Schema.BackColor, this, pos, pos2);
							}
							else
							{
								this.traceAtoB = new TraceCable(e.Trame.Marque8021q, TraceCable.TypeDeTrace.ethernetAvecCollision, this.reseau.Pref.CableActifStylo2, this.reseau.Pref.CableActifStylo1, this.reseau.Pref.StyloCollision, this.reseau.Pref.StyloCable, this.reseau.Schema.BackColor, this, pos, pos2);
							}
							((PointConnexion)sender).Emetteur.Trace = this.traceAtoB;
							((PointConnexion)sender).Emetteur.TrameEnCours = this.trameAtoB;
							base.Paint += this.traceAtoB.TracerCable;
							this.traceAtoB.TraceTermine += this.FinTraceAtoB;
							this.traceAtoB.DebutTrame1Arrive += this.DebutTrameAtoBArrivee;
							this.traceAtoB.FinTrame1Arrive += this.FinTrameAtoBArrivee;
							return;
						}
						this.trameAtoB2 = e;
						this.traceAtoB.AjouterSuiveur();
						this.traceAtoB.DebutTrame2Arrive += this.DebutTrameAtoBArrivee2;
						this.traceAtoB.FinTrame2Arrive += this.FinTrameAtoBArrivee2;
						return;
					}
					else
					{
						if (this.traceBtoA == null)
						{
							this.numPremiereTrameBtoA = e.Trame.NumeroTrame;
							Point pos = this.pointB.Emetteur.Pos;
							Point pos2 = this.pointA.Recepteur.Pos;
							this.trameBtoA = e;
							if (e.Trame.NumeroTrame == 1)
							{
								this.traceBtoA = new TraceCable(e.Trame.Marque8021q, TraceCable.TypeDeTrace.ethernetAvecCollision, this.reseau.Pref.CableActifStylo1, this.reseau.Pref.CableActifStylo2, this.reseau.Pref.StyloCollision, this.reseau.Pref.StyloCable, this.reseau.Schema.BackColor, this, pos, pos2);
							}
							else
							{
								this.traceBtoA = new TraceCable(e.Trame.Marque8021q, TraceCable.TypeDeTrace.ethernetAvecCollision, this.reseau.Pref.CableActifStylo2, this.reseau.Pref.CableActifStylo1, this.reseau.Pref.StyloCollision, this.reseau.Pref.StyloCable, this.reseau.Schema.BackColor, this, pos, pos2);
							}
							((PointConnexion)sender).Emetteur.Trace = this.traceBtoA;
							((PointConnexion)sender).Emetteur.TrameEnCours = this.trameBtoA;
							base.Paint += this.traceBtoA.TracerCable;
							this.traceBtoA.TraceTermine += this.FinTraceBtoA;
							this.traceBtoA.DebutTrame1Arrive += this.DebutTrameBtoAArrivee;
							this.traceBtoA.FinTrame1Arrive += this.FinTrameBtoAArrivee;
							return;
						}
						this.trameBtoA2 = e;
						this.traceBtoA.AjouterSuiveur();
						this.traceBtoA.DebutTrame2Arrive += this.DebutTrameBtoAArrivee2;
						this.traceBtoA.FinTrame2Arrive += this.FinTrameBtoAArrivee2;
						return;
					}
				}
				else
				{
					e.Trame.AddCableTraverse(this);
					this.trameEnCours = e;
					if (sender == this.pointA)
					{
						this.trameTransmiseParPointA = e;
					}
					else
					{
						this.trameTransmiseParPointB = e;
					}
					this.senderEnCours = sender;
					if (this.trace == null)
					{
						this.enCollision = false;
						this.emetteurPremiereTrame = sender;
						if (e.Trame.NumeroTrame == 1)
						{
							this.trace = new TraceCable(e.Trame.Marque8021q, TraceCable.TypeDeTrace.ethernetAvecCollision, this.reseau.Pref.CableActifStylo1, this.reseau.Pref.CableActifStylo2, this.reseau.Pref.StyloCollision, this.reseau.Pref.StyloCable, this.reseau.Schema.BackColor, this, ((PointConnexion)sender).Centre, this.Oppose((PointConnexion)sender).Centre);
						}
						else
						{
							this.trace = new TraceCable(e.Trame.Marque8021q, TraceCable.TypeDeTrace.ethernetAvecCollision, this.reseau.Pref.CableActifStylo2, this.reseau.Pref.CableActifStylo1, this.reseau.Pref.StyloCollision, this.reseau.Pref.StyloCable, this.reseau.Schema.BackColor, this, ((PointConnexion)sender).Centre, this.Oppose((PointConnexion)sender).Centre);
						}
						base.Paint -= this.Cable_Paint;
						base.Paint += this.trace.TracerCable;
						this.trace.TraceTermine += this.FinTraceCableAvecCollision;
						this.trace.DebutTrame1Arrive += this.DebutTrameArrive;
						this.trace.Collision1 += this.collisionTramePoint1;
						this.trace.Collision2 += this.collisionTramePoint2;
						return;
					}
					this.enCollision = true;
					this.trace.AjouterConcurrent();
				}
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000516C File Offset: 0x0000416C
		public void collisionTramePoint1(object sender, EventArgs e)
		{
			this.CollisionRecue(this, new TrameEventArgs(null, this.Oppose((PointConnexion)this.emetteurPremiereTrame)));
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000519C File Offset: 0x0000419C
		public void collisionTramePoint2(object sender, EventArgs e)
		{
			this.CollisionRecue(this, new TrameEventArgs(null, this.emetteurPremiereTrame));
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000051C4 File Offset: 0x000041C4
		public void DebutTrameArrive(object sender, EventArgs e)
		{
			this.trace.DebutTrame1Arrive -= this.DebutTrameArrive;
			base.transmettreDebutTrame(this.trameEnCours.Trame, this.Oppose((PointConnexion)this.emetteurPremiereTrame));
		}

		// Token: 0x0600007C RID: 124 RVA: 0x0000520C File Offset: 0x0000420C
		public void DebutTrameAtoBArrivee(object sender, EventArgs e)
		{
			this.traceAtoB.DebutTrame1Arrive -= this.DebutTrameAtoBArrivee;
			base.transmettreDebutTrame(this.trameAtoB.Trame, this.pointB);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00005248 File Offset: 0x00004248
		public void DebutTrameAtoBArrivee2(object sender, EventArgs e)
		{
			this.traceAtoB.DebutTrame2Arrive -= this.DebutTrameAtoBArrivee2;
			base.transmettreDebutTrame(this.trameAtoB2.Trame, this.pointB);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00005284 File Offset: 0x00004284
		public void FinTrameAtoBArrivee(object sender, EventArgs e)
		{
			this.traceAtoB.FinTrame1Arrive -= this.FinTrameAtoBArrivee;
			base.transmettreFinTrame(this.trameAtoB.Trame, this.pointB);
			if (!this.trameAtoB.Trame.Collisee)
			{
				base.receptionnerFinTrame(this.trameAtoB.Trame, "cable1");
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000052E8 File Offset: 0x000042E8
		public void FinTrameAtoBArrivee2(object sender, EventArgs e)
		{
			this.traceAtoB.FinTrame2Arrive -= this.FinTrameAtoBArrivee2;
			base.transmettreFinTrame(this.trameAtoB2.Trame, this.pointB);
			base.receptionnerFinTrame(this.trameAtoB2.Trame, "cable2");
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000533C File Offset: 0x0000433C
		public void DebutTrameBtoAArrivee(object sender, EventArgs e)
		{
			this.traceBtoA.DebutTrame1Arrive -= this.DebutTrameBtoAArrivee;
			base.transmettreDebutTrame(this.trameBtoA.Trame, this.pointA);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00005378 File Offset: 0x00004378
		public void FinTrameBtoAArrivee(object sender, EventArgs e)
		{
			this.traceBtoA.FinTrame1Arrive -= this.FinTrameBtoAArrivee;
			base.transmettreFinTrame(this.trameBtoA.Trame, this.pointA);
			if (!this.trameBtoA.Trame.Collisee)
			{
				base.receptionnerFinTrame(this.trameBtoA.Trame, "cable3");
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000053DC File Offset: 0x000043DC
		public void DebutTrameBtoAArrivee2(object sender, EventArgs e)
		{
			this.traceBtoA.DebutTrame2Arrive -= this.DebutTrameBtoAArrivee2;
			base.transmettreDebutTrame(this.trameBtoA2.Trame, this.pointA);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00005418 File Offset: 0x00004418
		public void FinTrameBtoAArrivee2(object sender, EventArgs e)
		{
			this.traceBtoA.FinTrame2Arrive -= this.FinTrameBtoAArrivee2;
			base.transmettreFinTrame(this.trameBtoA2.Trame, this.pointA);
			base.receptionnerFinTrame(this.trameBtoA2.Trame, "cable4");
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000546C File Offset: 0x0000446C
		public void FinTraceCableAvecCollision(object sender, EventArgs e)
		{
			if (this.reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.trameReelle)
			{
				this.redessiner(Cable.sensRedessiner.milieu);
			}
			this.trace.Collision1 -= this.collisionTramePoint1;
			this.trace.Collision2 -= this.collisionTramePoint2;
			TrameEthernet trame = this.trameEnCours.Trame;
			ElementReseau elementReseau = this.emetteurPremiereTrame;
			this.trameEnCours = null;
			this.trace.TraceTermine -= this.FinTraceCableAvecCollision;
			base.Paint -= this.trace.TracerCable;
			base.Paint += this.Cable_Paint;
			this.trace = null;
			if (!this.enCollision)
			{
				base.transmettreFinTrame(trame, this.Oppose((PointConnexion)elementReseau));
				base.receptionnerFinTrame(trame, "cable5");
			}
			else
			{
				if (this.trameTransmiseParPointA != null)
				{
					base.receptionnerFinTrame(this.trameTransmiseParPointA.Trame, "cable6");
				}
				if (this.trameTransmiseParPointB != null)
				{
					base.receptionnerFinTrame(this.trameTransmiseParPointB.Trame, "cable7");
				}
				trame.RedessinerCables();
			}
			this.pointA.Liberer();
			this.pointB.Liberer();
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000055A0 File Offset: 0x000045A0
		public void FinTraceAtoB(object sender, EventArgs e)
		{
			base.Paint -= this.traceAtoB.TracerCable;
			this.traceAtoB.TraceTermine -= this.FinTraceAtoB;
			this.pointA.LibererEmission();
			this.pointB.LibererReception();
			this.pointA.Emetteur.Trace = null;
			this.traceAtoB = null;
			this.trameAtoB = null;
			if (this.reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.trameReelle)
			{
				this.redessiner(Cable.sensRedessiner.AtoB);
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00005628 File Offset: 0x00004628
		public void FinTraceBtoA(object sender, EventArgs e)
		{
			base.Paint -= this.traceBtoA.TracerCable;
			this.traceBtoA.TraceTermine -= this.FinTraceBtoA;
			this.pointB.LibererEmission();
			this.pointA.LibererReception();
			this.pointB.Emetteur.Trace = null;
			this.traceBtoA = null;
			this.trameBtoA = null;
			if (this.reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.trameReelle)
			{
				this.redessiner(Cable.sensRedessiner.BtoA);
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000056B0 File Offset: 0x000046B0
		private void Cable_FinTrameTransmis(ElementReseau sender, TrameEventArgs e)
		{
			if (e.Cible == this)
			{
				if (this.reseau.DeuxTrames && this.type != Cable.TypeCable.coaxial)
				{
					if (sender == this.pointA)
					{
						if (this.traceAtoB != null && this.traceAtoB.ReceptifFinTrame())
						{
							if (e.Trame.NumeroTrame == this.numPremiereTrameAtoB)
							{
								this.traceAtoB.FinirTrame(1);
								return;
							}
							this.traceAtoB.FinirTrame(2);
							return;
						}
					}
					else if (this.traceBtoA != null && this.traceBtoA.ReceptifFinTrame())
					{
						if (e.Trame.NumeroTrame == this.numPremiereTrameBtoA)
						{
							this.traceBtoA.FinirTrame(1);
							return;
						}
						this.traceBtoA.FinirTrame(2);
						return;
					}
				}
				else if (this.trace != null)
				{
					if (sender == this.emetteurPremiereTrame)
					{
						this.trace.FinirTrame(1);
						return;
					}
					this.trace.FinirTrame(2);
				}
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000057A4 File Offset: 0x000047A4
		public void ModeDeuxPaires()
		{
			this.deuxPaires = true;
			this.pointA.CreerConnecteurs();
			this.pointB.CreerConnecteurs();
			this.routinePaint = new Cable.cableRoutinePaint(this.Cable_PaintDeuxPaires);
			Graphics graphics = this.reseau.Schema.CreateGraphics();
			graphics.DrawLine(new Pen(this.reseau.BackColor, 1f), this.pointA.Centre, this.pointB.Centre);
			base.Invalidate();
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00005828 File Offset: 0x00004828
		public void ModeCableSimple()
		{
			this.deuxPaires = false;
			this.routinePaint = new Cable.cableRoutinePaint(this.Cable_PaintSimple);
			Graphics graphics = this.reseau.Schema.CreateGraphics();
			graphics.DrawLine(new Pen(this.reseau.BackColor, 1f), this.pointA.Emetteur.Pos, this.pointB.Recepteur.Pos);
			graphics.DrawLine(new Pen(this.reseau.BackColor, 1f), this.pointA.Recepteur.Pos, this.pointB.Emetteur.Pos);
			base.Invalidate();
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000058DC File Offset: 0x000048DC
		private void Cable_PaintDeuxPaires(object sender, PaintEventArgs e)
		{
			Graphics graphics = this.reseau.Schema.CreateGraphics();
			graphics.DrawLine(this.stylo, this.pointA.Emetteur.Pos, this.pointB.Recepteur.Pos);
			graphics.DrawLine(this.stylo, this.pointA.Recepteur.Pos, this.pointB.Emetteur.Pos);
			graphics.Dispose();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00005958 File Offset: 0x00004958
		public override void StockerXml(XmlTextWriter writer)
		{
			writer.WriteStartElement("cable");
			writer.WriteElementString("type", this.type.ToString());
			writer.WriteElementString("longueur", this.longueur.ToString());
			writer.WriteElementString("noeudPointA", this.pointA.NoeudAttache.IdNoeud.ToString());
			writer.WriteElementString("portPointA", this.pointA.NumeroOrdre.ToString());
			writer.WriteElementString("noeudPointB", this.pointB.NoeudAttache.IdNoeud.ToString());
			writer.WriteElementString("portPointB", this.pointB.NumeroOrdre.ToString());
			writer.WriteEndElement();
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00005A2C File Offset: 0x00004A2C
		public override void ReinitEthernet()
		{
			base.ReinitEthernet();
			if (this.trace != null)
			{
				base.Paint -= this.trace.TracerCable;
				this.trace.TraceTermine -= this.FinTraceCable;
				this.trace.TraceTermine -= this.FinTraceCableAvecCollision;
				this.trace.DebutTrame1Arrive -= this.DebutTrameArrive;
				this.trace.Collision1 -= this.collisionTramePoint1;
				this.trace.Collision2 -= this.collisionTramePoint2;
				this.trace.ReinitEthernet();
				this.trace = null;
			}
			if (this.traceAtoB != null)
			{
				base.Paint -= this.traceAtoB.TracerCable;
				this.traceAtoB.TraceTermine -= this.FinTraceAtoB;
				this.traceAtoB.TraceTermine -= this.FinTraceAtoBFinTrameCollisee;
				this.traceAtoB.TraceTermine -= this.finCollision;
				this.traceAtoB.DebutTrame1Arrive -= this.DebutTrameAtoBArrivee;
				this.traceAtoB.FinTrame1Arrive -= this.FinTrameAtoBArrivee;
				this.traceAtoB.DebutTrame2Arrive -= this.DebutTrameAtoBArrivee2;
				this.traceAtoB.FinTrame2Arrive -= this.FinTrameAtoBArrivee2;
				this.traceAtoB.ReinitEthernet();
				this.traceAtoB = null;
			}
			if (this.traceBtoA != null)
			{
				base.Paint -= this.traceBtoA.TracerCable;
				this.traceBtoA.TraceTermine -= this.FinTraceBtoA;
				this.traceBtoA.TraceTermine -= this.FinTraceBtoAFinTrameCollisee;
				this.traceBtoA.TraceTermine -= this.finCollision;
				this.traceBtoA.DebutTrame1Arrive -= this.DebutTrameBtoAArrivee;
				this.traceBtoA.FinTrame1Arrive -= this.FinTrameBtoAArrivee;
				this.traceBtoA.DebutTrame2Arrive -= this.DebutTrameBtoAArrivee2;
				this.traceBtoA.FinTrame2Arrive -= this.FinTrameBtoAArrivee2;
				this.traceBtoA.ReinitEthernet();
				this.traceBtoA = null;
			}
			foreach (object obj in this.portHubEcoutes)
			{
				PortHub portHub = (PortHub)obj;
				PortHub portHub2 = portHub;
				portHub2.CollisionRepandue = (EventHandler)Delegate.Remove(portHub2.CollisionRepandue, new EventHandler(this.collisionPortHubRepandue));
			}
			this.portHubEcoutes = new ArrayList();
			this.enCollision = false;
			this.collisionAtoB = false;
			base.Paint -= this.Cable_Paint;
			base.Paint += this.Cable_Paint;
			this.stylo = this.reseau.Pref.NormalStylo;
			this.routinePaint = new Cable.cableRoutinePaint(this.Cable_PaintSimple);
			this.trace = (this.traceAtoB = (this.traceBtoA = null));
			this.trameAtoB = (this.trameAtoB2 = (this.trameBtoA = (this.trameBtoA2 = null)));
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00005DAC File Offset: 0x00004DAC
		public void TransmissionRapideEthernet(bool demo, PointConnexion demandeur, Ip_PaquetIp paquet, bool suivreLiensPortsEteints, ReactionStation rs, ReactionSwitch rsw)
		{
			if (demo)
			{
				this.demandeurCourant = demandeur;
				this.paquetCourant = paquet;
				this.rsCourant = rs;
				this.rswCourant = rsw;
				this.stylo = this.reseau.Pref.CableActifStylo1;
				this.trace = new TraceCable(false, TraceCable.TypeDeTrace.ethernetNoCollision, this.reseau.Pref.CableActifStylo1, this.reseau.Pref.CableActifStylo2, this.reseau.Pref.StyloCollision, this.reseau.Pref.StyloCable, this.reseau.Schema.BackColor, this, demandeur.Centre, this.Oppose(demandeur).Centre);
				base.Paint -= this.Cable_Paint;
				base.Paint += this.trace.TracerCable;
				this.trace.TraceTermine += this.SuiteTransmissionRapideEthernet;
				return;
			}
			Ip_station.CablesTraverses.Add(this);
			Noeud noeudAttache = this.Oppose(demandeur).NoeudAttache;
			noeudAttache.TransmissionRapideEthernet(demo, this.Oppose(demandeur), paquet, suivreLiensPortsEteints, rs, rsw);
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x0600008E RID: 142 RVA: 0x00005ED4 File Offset: 0x00004ED4
		// (remove) Token: 0x0600008F RID: 143 RVA: 0x00005EF8 File Offset: 0x00004EF8
		public static event EventHandler TransmissionRapideTerminee;

		// Token: 0x06000090 RID: 144 RVA: 0x00005F1C File Offset: 0x00004F1C
		public void SuiteTransmissionRapideEthernet(object sender, EventArgs e)
		{
			if (this.trace != null)
			{
				this.trace.TraceTermine -= this.SuiteTransmissionRapideEthernet;
				base.Paint -= this.trace.TracerCable;
				base.Paint += this.Cable_Paint;
			}
			this.trace = null;
			Noeud noeudAttache = this.Oppose(this.demandeurCourant).NoeudAttache;
			noeudAttache.TransmissionRapideEthernet(true, this.Oppose(this.demandeurCourant), this.paquetCourant, false, this.rsCourant, this.rswCourant);
			Ip_station.CablesTraverses.Add(this);
			if (Ip_station.CablesTraverses.Count == Ip_station.NbcablesConcernes && Cable.TransmissionRapideTerminee != null)
			{
				Cable.TransmissionRapideTerminee(this, new EventArgs());
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00005FE4 File Offset: 0x00004FE4
		public void ReinitIp()
		{
			if (this.trace != null)
			{
				this.trace.TraceTermine -= this.SuiteTransmissionRapideEthernet;
				base.Paint -= this.trace.TracerCable;
				base.Paint += this.Cable_Paint;
				this.trace.ReinitEthernet();
				this.trace = null;
			}
			this.stylo = this.reseau.Pref.NormalStylo;
		}

		// Token: 0x0400002F RID: 47
		private IContainer components = null;

		// Token: 0x04000030 RID: 48
		protected PointConnexion pointA;

		// Token: 0x04000031 RID: 49
		protected PointConnexion pointB;

		// Token: 0x04000032 RID: 50
		private Cable.cableRoutinePaint routinePaint;

		// Token: 0x04000033 RID: 51
		private Cable.TypeCable type = Cable.TypeCable.droit;

		// Token: 0x04000034 RID: 52
		private TraceCable trace = null;

		// Token: 0x04000035 RID: 53
		private TraceCable traceAtoB = null;

		// Token: 0x04000036 RID: 54
		private TraceCable traceBtoA = null;

		// Token: 0x04000037 RID: 55
		private int longueur;

		// Token: 0x04000038 RID: 56
		private TrameEventArgs trameTransmiseParPointA;

		// Token: 0x04000039 RID: 57
		private TrameEventArgs trameTransmiseParPointB;

		// Token: 0x0400003A RID: 58
		private TrameEventArgs trameAtoB;

		// Token: 0x0400003B RID: 59
		private TrameEventArgs trameBtoA;

		// Token: 0x0400003C RID: 60
		private TrameEventArgs trameAtoB2;

		// Token: 0x0400003D RID: 61
		private TrameEventArgs trameBtoA2;

		// Token: 0x0400003E RID: 62
		private ElementReseau emetteurPremiereTrame;

		// Token: 0x0400003F RID: 63
		private bool enCollision = false;

		// Token: 0x04000040 RID: 64
		private bool collisionAtoB;

		// Token: 0x04000041 RID: 65
		private ArrayList portHubEcoutes = new ArrayList();

		// Token: 0x04000042 RID: 66
		public EventHandler CollisionDeuxPaires;

		// Token: 0x04000043 RID: 67
		public EventHandler CollisionRepandueParCable;

		// Token: 0x04000044 RID: 68
		public EventHandler CollisionRepandue;

		// Token: 0x04000045 RID: 69
		private int numPremiereTrameAtoB;

		// Token: 0x04000046 RID: 70
		private int numPremiereTrameBtoA;

		// Token: 0x04000047 RID: 71
		public TrameEventHandler CollisionRecue;

		// Token: 0x04000048 RID: 72
		private bool deuxPaires = false;

		// Token: 0x0400004A RID: 74
		private PointConnexion demandeurCourant;

		// Token: 0x0400004B RID: 75
		private Ip_PaquetIp paquetCourant;

		// Token: 0x0400004C RID: 76
		private ReactionStation rsCourant;

		// Token: 0x0400004D RID: 77
		private ReactionSwitch rswCourant;

		// Token: 0x02000008 RID: 8
		// (Invoke) Token: 0x06000093 RID: 147
		private delegate void cableRoutinePaint(object sender, PaintEventArgs e);

		// Token: 0x02000009 RID: 9
		public enum TypeCable
		{
			// Token: 0x0400004F RID: 79
			croise,
			// Token: 0x04000050 RID: 80
			droit,
			// Token: 0x04000051 RID: 81
			coaxial,
			// Token: 0x04000052 RID: 82
			telecom
		}

		// Token: 0x0200000A RID: 10
		public enum sensRedessiner
		{
			// Token: 0x04000054 RID: 84
			AtoB,
			// Token: 0x04000055 RID: 85
			BtoA,
			// Token: 0x04000056 RID: 86
			milieu
		}
	}
}
