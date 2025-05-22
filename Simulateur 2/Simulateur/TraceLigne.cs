using System;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000096 RID: 150
	public class TraceLigne
	{
		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000969 RID: 2409 RVA: 0x0005A098 File Offset: 0x00059098
		// (set) Token: 0x0600096A RID: 2410 RVA: 0x0005A0AC File Offset: 0x000590AC
		public PointF Pos
		{
			get
			{
				return this.pos;
			}
			set
			{
				this.pos = value;
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x0600096B RID: 2411 RVA: 0x0005A0C0 File Offset: 0x000590C0
		// (set) Token: 0x0600096C RID: 2412 RVA: 0x0005A0D4 File Offset: 0x000590D4
		public PointF Old
		{
			get
			{
				return this.old;
			}
			set
			{
				this.old = value;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x0600096E RID: 2414 RVA: 0x0005A0FC File Offset: 0x000590FC
		// (set) Token: 0x0600096D RID: 2413 RVA: 0x0005A0E8 File Offset: 0x000590E8
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

		// Token: 0x1700019C RID: 412
		// (set) Token: 0x0600096F RID: 2415 RVA: 0x0005A110 File Offset: 0x00059110
		public bool Gomme
		{
			set
			{
				this.gomme = value;
			}
		}

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x06000970 RID: 2416 RVA: 0x0005A124 File Offset: 0x00059124
		// (remove) Token: 0x06000971 RID: 2417 RVA: 0x0005A148 File Offset: 0x00059148
		public event EtatTransitionEventHandler Rencontre;

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x06000972 RID: 2418 RVA: 0x0005A16C File Offset: 0x0005916C
		// (remove) Token: 0x06000973 RID: 2419 RVA: 0x0005A190 File Offset: 0x00059190
		public event EtatTransitionEventHandler Arrivee;

		// Token: 0x06000974 RID: 2420 RVA: 0x0005A1B4 File Offset: 0x000591B4
		public TraceLigne(Control p_icone, bool p_marque8021q, Timer p_t, TraceCable p_trace, PointF p_depart, PointF p_arrivee, float p_a, float p_b, TraceCable.CasDroite p_cas, int p_sensX, int p_sensY, float p_vitesse)
		{
			this.icone = p_icone;
			this.trace = p_trace;
			this.arrivee = p_arrivee;
			this.a = p_a;
			this.b = p_b;
			this.vitesse = p_vitesse;
			this.cas = p_cas;
			this.sensX = p_sensX;
			this.sensY = p_sensY;
			this.t = p_t;
			this.pos = p_depart;
			this.old = (this.oldPrecedent = this.pos);
			if (p_marque8021q)
			{
				this.delegueTrace = new MethodeTracer(this.TracerEtMarquer);
				return;
			}
			if (this.icone == null)
			{
				this.delegueTrace = new MethodeTracer(this.Tracer);
				return;
			}
			this.delegueTrace = new MethodeTracer(this.TracerIcone);
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x0005A278 File Offset: 0x00059278
		public void Inverser()
		{
			PointF pointF = this.arrivee;
			this.arrivee = this.pos;
			this.pos = pointF;
			this.old = (this.oldPrecedent = this.pos);
			this.sensX = -this.sensX;
			this.sensY = -this.sensY;
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x0005A2D0 File Offset: 0x000592D0
		public void Init(Pen p_stylo, bool p_gomme)
		{
			this.stylo = p_stylo;
			this.collision = (this.stylo == this.trace.StyloCollision);
			this.gomme = p_gomme;
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x0005A304 File Offset: 0x00059304
		public void SetNoEvent(Pen p_stylo, bool p_gomme)
		{
			this.Init(p_stylo, p_gomme);
			this.t.Tick += this.AvancerNoEvent;
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x0005A330 File Offset: 0x00059330
		public void SetRencontreEvent(Pen p_stylo, bool p_gomme, TraceLigne p_concurrent, int p_etatSuivant)
		{
			this.Init(p_stylo, p_gomme);
			this.concurrent = p_concurrent;
			this.etatSuivant = p_etatSuivant;
			this.t.Tick += this.AvancerRencontreEvent;
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x0005A36C File Offset: 0x0005936C
		public void SetArriveeEvent(Pen p_stylo, bool p_gomme, int p_etatSuivant)
		{
			this.Init(p_stylo, p_gomme);
			this.etatSuivant = p_etatSuivant;
			this.t.Tick += this.AvancerArriveeEvent;
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x0005A3A0 File Offset: 0x000593A0
		public void Stop()
		{
			this.t.Tick -= this.AvancerArriveeEvent;
			this.t.Tick -= this.AvancerRencontreEvent;
			this.t.Tick -= this.AvancerNoEvent;
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x0005A3F4 File Offset: 0x000593F4
		public void AvancerNoEvent(object sender, EventArgs e)
		{
			this.calculerSuivant(this.arrivee);
			this.delegueTrace();
			if (this == this.arrivee)
			{
				this.t.Tick -= this.AvancerNoEvent;
			}
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x0005A440 File Offset: 0x00059440
		public void AvancerRencontreEvent(object sender, EventArgs e)
		{
			PointF butoir = this % this.concurrent;
			this.calculerSuivant(butoir);
			this.concurrent.calculerSuivant(butoir);
			this.delegueTrace();
			this.concurrent.delegueTrace();
			if (this.concurrent == this)
			{
				this.t.Tick -= this.AvancerRencontreEvent;
				if (this.Rencontre != null)
				{
					this.Rencontre(this, new EtatTransitionEventArgs(this.etatSuivant));
				}
			}
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x0005A4CC File Offset: 0x000594CC
		public void AvancerArriveeEvent(object sender, EventArgs e)
		{
			this.calculerSuivant(this.arrivee);
			this.delegueTrace();
			if (this == this.arrivee)
			{
				this.t.Tick -= this.AvancerArriveeEvent;
				this.genererEvent(this.collision, this.gomme);
				if (this.Arrivee != null)
				{
					this.Arrivee(this, new EtatTransitionEventArgs(this.etatSuivant));
				}
			}
		}

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x0600097E RID: 2430 RVA: 0x0005A548 File Offset: 0x00059548
		// (remove) Token: 0x0600097F RID: 2431 RVA: 0x0005A56C File Offset: 0x0005956C
		public event EventHandler DebutTrameArrive;

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x06000980 RID: 2432 RVA: 0x0005A590 File Offset: 0x00059590
		// (remove) Token: 0x06000981 RID: 2433 RVA: 0x0005A5B4 File Offset: 0x000595B4
		public event EventHandler FinTrameArrivee;

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x06000982 RID: 2434 RVA: 0x0005A5D8 File Offset: 0x000595D8
		// (remove) Token: 0x06000983 RID: 2435 RVA: 0x0005A5FC File Offset: 0x000595FC
		public event EventHandler Collision;

		// Token: 0x06000984 RID: 2436 RVA: 0x0005A620 File Offset: 0x00059620
		private void genererEvent(bool p_collision, bool p_gomme)
		{
			if (p_collision)
			{
				if (this.Collision != null)
				{
					this.Collision(this, new EventArgs());
					return;
				}
			}
			else if (p_gomme)
			{
				if (this.FinTrameArrivee != null)
				{
					this.FinTrameArrivee(this, new EventArgs());
					return;
				}
			}
			else if (this.DebutTrameArrive != null)
			{
				this.DebutTrameArrive(this, new EventArgs());
			}
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x0005A680 File Offset: 0x00059680
		private void calculerSuivant(PointF butoir)
		{
			this.oldPrecedent = this.old;
			this.old = this.pos;
			float x = this.old.X;
			float y = this.old.Y;
			float num;
			float num2;
			switch (this.cas)
			{
			case TraceCable.CasDroite.dteVerticale:
				num = x;
				num2 = y + this.vitesse * (float)this.sensY;
				num2 = ((this.sensY == 1) ? Math.Min(num2, butoir.Y) : Math.Max(num2, butoir.Y));
				break;
			case TraceCable.CasDroite.dteHorizontale:
				num2 = y;
				num = x + this.vitesse * (float)this.sensX;
				num = ((this.sensX == 1) ? Math.Min(num, butoir.X) : Math.Max(num, butoir.X));
				break;
			default:
				num = x + this.vitesse * (float)this.sensX / (float)Math.Sqrt((double)(1f + this.a * this.a));
				num2 = this.a * num + this.b;
				if (this.sensX == 1)
				{
					if (num >= butoir.X)
					{
						num = butoir.X;
						num2 = butoir.Y;
					}
				}
				else if (num <= butoir.X)
				{
					num = butoir.X;
					num2 = butoir.Y;
				}
				break;
			}
			this.pos = new PointF(num, num2);
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x0005A7D8 File Offset: 0x000597D8
		public void Tracer()
		{
			if (this.gomme || this.collision)
			{
				this.trace.GraphicsCable.DrawLine(this.trace.StyloGomme, this.old, this.pos);
			}
			this.trace.GraphicsCable.DrawLine(this.stylo, this.old, this.pos);
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x0005A840 File Offset: 0x00059840
		public void TracerIcone()
		{
			this.icone.Location = new Point((int)this.pos.X, (int)this.pos.Y);
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x0005A878 File Offset: 0x00059878
		public void TracerEtMarquer()
		{
			if (this.gomme)
			{
				this.trace.GraphicsCable.DrawLine(this.trace.StyloGomme, this.old, this.pos);
				this.trace.GraphicsCable.DrawLine(this.stylo, this.old, this.pos);
				return;
			}
			this.trace.GraphicsCable.DrawLine(this.trace.StyloGomme, this.oldPrecedent, this.old);
			this.trace.GraphicsCable.DrawLine(this.stylo, this.oldPrecedent, this.old);
			this.trace.GraphicsCable.DrawLine(this.trace.Stylo8021q, this.old, this.pos);
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x0005A948 File Offset: 0x00059948
		public static PointF operator %(TraceLigne t1, TraceLigne t2)
		{
			return new PointF((t1.pos.X + t2.pos.X) / 2f, (t1.pos.Y + t2.pos.Y) / 2f);
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x0005A994 File Offset: 0x00059994
		public static bool operator <=(TraceLigne t1, TraceLigne t2)
		{
			if (t1.trace.Cas == TraceCable.CasDroite.dteVerticale)
			{
				if (t1.trace.SensY == 1)
				{
					return t1.pos.Y <= t2.pos.Y;
				}
				return t1.pos.Y >= t2.pos.Y;
			}
			else
			{
				if (t1.trace.SensX == 1)
				{
					return t1.pos.X <= t2.pos.X;
				}
				return t1.pos.X >= t2.pos.X;
			}
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x0005AA3C File Offset: 0x00059A3C
		public static bool operator >=(TraceLigne t1, TraceLigne t2)
		{
			if (t1.trace.Cas == TraceCable.CasDroite.dteVerticale)
			{
				if (t1.trace.SensY == 1)
				{
					return t1.pos.Y >= t2.pos.Y;
				}
				return t1.pos.Y <= t2.pos.Y;
			}
			else
			{
				if (t1.trace.SensX == 1)
				{
					return t1.pos.X >= t2.pos.X;
				}
				return t1.pos.X <= t2.pos.X;
			}
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x0005AAE4 File Offset: 0x00059AE4
		public static bool operator <=(TraceLigne t1, PointF p)
		{
			if (t1.trace.Cas == TraceCable.CasDroite.dteVerticale)
			{
				if (t1.trace.SensY == 1)
				{
					return t1.pos.Y <= p.Y;
				}
				return t1.pos.Y >= p.Y;
			}
			else
			{
				if (t1.trace.SensX == 1)
				{
					return t1.pos.X <= p.X;
				}
				return t1.pos.X >= p.X;
			}
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x0005AB7C File Offset: 0x00059B7C
		public static bool operator >=(TraceLigne t1, PointF p)
		{
			if (t1.trace.Cas == TraceCable.CasDroite.dteVerticale)
			{
				if (t1.trace.SensY == 1)
				{
					return t1.pos.Y >= p.Y;
				}
				return t1.pos.Y <= p.Y;
			}
			else
			{
				if (t1.trace.SensX == 1)
				{
					return t1.pos.X >= p.X;
				}
				return t1.pos.X <= p.X;
			}
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x0005AC14 File Offset: 0x00059C14
		public static bool operator <(TraceLigne t1, TraceLigne t2)
		{
			if (t1.trace.Cas == TraceCable.CasDroite.dteVerticale)
			{
				if (t1.trace.SensY == 1)
				{
					return t1.pos.Y < t2.pos.Y;
				}
				return t1.pos.Y > t2.pos.Y;
			}
			else
			{
				if (t1.trace.SensX == 1)
				{
					return t1.pos.X < t2.pos.X;
				}
				return t1.pos.X > t2.pos.X;
			}
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x0005ACB0 File Offset: 0x00059CB0
		public static bool operator >(TraceLigne t1, TraceLigne t2)
		{
			if (t1.trace.Cas == TraceCable.CasDroite.dteVerticale)
			{
				if (t1.trace.SensY == 1)
				{
					return t1.pos.Y > t2.pos.Y;
				}
				return t1.pos.Y < t2.pos.Y;
			}
			else
			{
				if (t1.trace.SensX == 1)
				{
					return t1.pos.X > t2.pos.X;
				}
				return t1.pos.X < t2.pos.X;
			}
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x0005AD4C File Offset: 0x00059D4C
		public static bool operator <(TraceLigne t1, PointF p)
		{
			if (t1.trace.Cas == TraceCable.CasDroite.dteVerticale)
			{
				if (t1.trace.SensY == 1)
				{
					return t1.pos.Y < p.Y;
				}
				return t1.pos.Y > p.Y;
			}
			else
			{
				if (t1.trace.SensX == 1)
				{
					return t1.pos.X < p.X;
				}
				return t1.pos.X > p.X;
			}
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x0005ADD8 File Offset: 0x00059DD8
		public static bool operator >(TraceLigne t1, PointF p)
		{
			if (t1.trace.Cas == TraceCable.CasDroite.dteVerticale)
			{
				if (t1.trace.SensY == 1)
				{
					return t1.pos.Y > p.Y;
				}
				return t1.pos.Y < p.Y;
			}
			else
			{
				if (t1.trace.SensX == 1)
				{
					return t1.pos.X > p.X;
				}
				return t1.pos.X < p.X;
			}
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x0005AE64 File Offset: 0x00059E64
		public static bool operator ==(TraceLigne t1, TraceLigne t2)
		{
			return t1.pos == t2.pos;
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x0005AE84 File Offset: 0x00059E84
		public static bool operator !=(TraceLigne t1, TraceLigne t2)
		{
			return t1.pos != t2.pos;
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x0005AEA4 File Offset: 0x00059EA4
		public static bool operator ==(TraceLigne t1, PointF p)
		{
			return t1.pos == p;
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x0005AEC0 File Offset: 0x00059EC0
		public static bool operator !=(TraceLigne t1, PointF p)
		{
			return t1.pos != p;
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x0005AEDC File Offset: 0x00059EDC
		public override int GetHashCode()
		{
			return this.pos.GetHashCode();
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x0005AEF4 File Offset: 0x00059EF4
		public override bool Equals(object o)
		{
			return false;
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x0005AF04 File Offset: 0x00059F04
		public void ReinitEthernet()
		{
			this.t.Tick -= this.AvancerArriveeEvent;
			this.t.Tick -= this.AvancerRencontreEvent;
			this.t.Tick -= this.AvancerNoEvent;
			this.t.Tick -= this.AvancerNoEvent;
			this.t.Tick -= this.AvancerRencontreEvent;
			this.t.Tick -= this.AvancerArriveeEvent;
			this.t = null;
		}

		// Token: 0x04000610 RID: 1552
		private TraceCable.CasDroite cas;

		// Token: 0x04000611 RID: 1553
		private float a;

		// Token: 0x04000612 RID: 1554
		private float b;

		// Token: 0x04000613 RID: 1555
		private float vitesse;

		// Token: 0x04000614 RID: 1556
		private int sensX;

		// Token: 0x04000615 RID: 1557
		private int sensY;

		// Token: 0x04000616 RID: 1558
		private PointF arrivee;

		// Token: 0x04000617 RID: 1559
		private TraceLigne concurrent;

		// Token: 0x04000618 RID: 1560
		private int etatSuivant;

		// Token: 0x04000619 RID: 1561
		private PointF pos;

		// Token: 0x0400061A RID: 1562
		private PointF old;

		// Token: 0x0400061B RID: 1563
		private Pen stylo;

		// Token: 0x0400061C RID: 1564
		private bool collision;

		// Token: 0x0400061D RID: 1565
		private bool gomme;

		// Token: 0x0400061E RID: 1566
		private TraceCable trace;

		// Token: 0x0400061F RID: 1567
		private Timer t;

		// Token: 0x04000620 RID: 1568
		private Control icone;

		// Token: 0x04000626 RID: 1574
		private MethodeTracer delegueTrace;

		// Token: 0x04000627 RID: 1575
		private PointF oldPrecedent;
	}
}
