using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000058 RID: 88
	public class Ip_CableVirtuel : TraceManuel
	{
		// Token: 0x060004C7 RID: 1223 RVA: 0x00033224 File Offset: 0x00032224
		public Ip_CableVirtuel()
		{
			this.InitializeComponent();
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x00033244 File Offset: 0x00032244
		public Ip_CableVirtuel(Ip_PaquetIp paquet) : base(paquet.StationSource.Reseau)
		{
			this.InitializeComponent();
			this.reseau = paquet.StationSource.Reseau;
			this.st = paquet.StationSource;
			this.longueur = this.reseau.Pref.LongueurRouteIp;
			this.stylo = new Pen(this.reseau.Schema.BackColor);
			if (paquet.StationSource.GetType() == typeof(Internet))
			{
				this.depart = paquet.CarteSource.Centre;
			}
			else
			{
				this.depart = this.st.GetCentre();
			}
			if (paquet.StationDest.GetType() == typeof(Internet))
			{
				this.arrivee = paquet.CarteDest.Centre;
				return;
			}
			this.arrivee = paquet.StationDest.GetCentre();
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x00033334 File Offset: 0x00032334
		public Ip_CableVirtuel(ArrayList stations, Simulation p_reseau, bool actif) : base(p_reseau)
		{
			this.InitializeComponent();
			this.reseau = p_reseau;
			this.longueur = this.reseau.Pref.LongueurCheminAppl;
			if (actif)
			{
				this.stylo = new Pen(this.reseau.Pref.StyloPaquet.Brush, 1f);
				this.points = new Point[stations.Count];
				for (int i = 0; i < stations.Count; i++)
				{
					Point centre = ((Station)stations[i]).GetCentre();
					this.points[i] = centre;
				}
				base.Paint += this.Ip_CableVirtuel_Paint;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060004CA RID: 1226 RVA: 0x000333F4 File Offset: 0x000323F4
		// (set) Token: 0x060004CB RID: 1227 RVA: 0x00033408 File Offset: 0x00032408
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

		// Token: 0x060004CC RID: 1228 RVA: 0x0003341C File Offset: 0x0003241C
		public void Tracer(SuiteTracerCableVirtuelIp p_suite)
		{
			this.suite = p_suite;
			this.reseau.Schema.Controls.Add(this);
			this.trace = new TraceCable(false, TraceCable.TypeDeTrace.paquetIP, this.reseau.Pref.StyloPaquet, this.reseau.Pref.CableActifStylo2, this.reseau.Pref.StyloCollision, this.stylo, this.reseau.Schema.BackColor, this, this.depart, this.arrivee);
			base.Paint += this.trace.TracerCable;
			this.trace.TraceTermine += this.FinTraceCable;
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x000334D4 File Offset: 0x000324D4
		public void Tracer(SuiteTracerCableVirtuelIp p_suite, ArrayList chemin, Pen p_premierStylo)
		{
			this.suite = p_suite;
			this.cheminIp = chemin;
			this.posCheminIp = chemin.Count;
			this.cablesTracesChemin = new ArrayList();
			this.styloCableEtape = p_premierStylo;
			this.etapeCheminSuivante();
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x00033514 File Offset: 0x00032514
		private void etapeCheminSuivante()
		{
			this.posCheminIp--;
			if (this.posCheminIp == 0)
			{
				foreach (object obj in this.cablesTracesChemin)
				{
					Cable cable = (Cable)obj;
					cable.Stylo = this.reseau.Pref.StyloCable;
					cable.Invalidate();
				}
				this.suite(this);
				return;
			}
			if (((PointConnexion)this.cheminIp[this.posCheminIp]).NoeudAttache == ((PointConnexion)this.cheminIp[this.posCheminIp - 1]).NoeudAttache)
			{
				this.posCheminIp--;
			}
			Cable lien = ((PointConnexion)this.cheminIp[this.posCheminIp]).Lien;
			this.cableCheminEnCours = lien;
			this.depart = ((PointConnexion)this.cheminIp[this.posCheminIp]).Centre;
			this.arrivee = ((PointConnexion)this.cheminIp[this.posCheminIp - 1]).Centre;
			lien.Trace = new TraceCable(false, TraceCable.TypeDeTrace.etapeCheminIp, this.reseau.Pref.StyloPaquet, this.reseau.Pref.CableActifStylo2, this.reseau.Pref.StyloCollision, this.styloCableEtape, this.reseau.Schema.BackColor, lien, this.depart, this.arrivee);
			lien.Paint -= lien.Cable_Paint;
			lien.Paint += lien.Trace.TracerCable;
			lien.Trace.TraceTermine += this.FinTraceEtapeChemin;
			this.cablesTracesChemin.Add(lien);
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x00033710 File Offset: 0x00032710
		public void FinTraceEtapeChemin(object sender, EventArgs e)
		{
			if (this.cableCheminEnCours.Trace != null)
			{
				this.cableCheminEnCours.Trace.TraceTermine -= this.FinTraceEtapeChemin;
				this.cableCheminEnCours.Paint -= this.cableCheminEnCours.Trace.TracerCable;
				this.cableCheminEnCours.Paint += this.cableCheminEnCours.Cable_Paint;
				this.cableCheminEnCours.Stylo = this.reseau.Pref.StyloPaquet;
				this.cableCheminEnCours.Trace = null;
			}
			this.etapeCheminSuivante();
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x000337B4 File Offset: 0x000327B4
		public void FinTraceCable(object sender, EventArgs e)
		{
			if (this.trace != null)
			{
				this.trace.TraceTermine -= this.FinTraceCable;
				base.Paint -= this.trace.TracerCable;
			}
			this.reseau.Schema.Controls.Remove(this);
			this.trace = null;
			this.suite(this);
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00033820 File Offset: 0x00032820
		public void ReinitIp()
		{
			if (this.reseau.CablesVirtuelIp)
			{
				if (this.trace != null)
				{
					this.trace.TraceTermine -= this.FinTraceCable;
					base.Paint -= this.trace.TracerCable;
					this.trace.ReinitEthernet();
				}
				this.reseau.Schema.Controls.Remove(this);
				this.trace = null;
			}
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x00033898 File Offset: 0x00032898
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x000338C4 File Offset: 0x000328C4
		private void InitializeComponent()
		{
			base.Name = "Ip_CableVirtuel";
			base.Size = new Size(1, 1);
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x000338EC File Offset: 0x000328EC
		private void Ip_CableVirtuel_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = this.reseau.Schema.CreateGraphics();
			graphics.DrawLines(this.stylo, this.points);
			graphics.Dispose();
		}

		// Token: 0x04000356 RID: 854
		private IContainer components = null;

		// Token: 0x04000357 RID: 855
		private Point[] points;

		// Token: 0x04000358 RID: 856
		private Station st;

		// Token: 0x04000359 RID: 857
		private TraceCable trace;

		// Token: 0x0400035A RID: 858
		private Point depart;

		// Token: 0x0400035B RID: 859
		private Point arrivee;

		// Token: 0x0400035C RID: 860
		private int longueur;

		// Token: 0x0400035D RID: 861
		private SuiteTracerCableVirtuelIp suite;

		// Token: 0x0400035E RID: 862
		private ArrayList cheminIp;

		// Token: 0x0400035F RID: 863
		private int posCheminIp;

		// Token: 0x04000360 RID: 864
		private Cable cableCheminEnCours;

		// Token: 0x04000361 RID: 865
		private ArrayList cablesTracesChemin;

		// Token: 0x04000362 RID: 866
		private Pen styloCableEtape;
	}
}
