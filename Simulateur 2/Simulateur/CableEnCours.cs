using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200000B RID: 11
	public class CableEnCours : TraceManuel
	{
		// Token: 0x06000096 RID: 150 RVA: 0x00006064 File Offset: 0x00005064
		public CableEnCours()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00006084 File Offset: 0x00005084
		public CableEnCours(Simulation s) : base(s)
		{
			this.InitializeComponent();
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000060A8 File Offset: 0x000050A8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000060D4 File Offset: 0x000050D4
		private void InitializeComponent()
		{
			base.Name = "CableEnCours";
			base.Paint += this.CableEnCours_Paint;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00006100 File Offset: 0x00005100
		private void CableEnCours_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = this.reseau.Schema.CreateGraphics();
			graphics.DrawLine(this.stylo, this.a, this.b);
			graphics.Dispose();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000613C File Offset: 0x0000513C
		public void Supprimer()
		{
			Graphics graphics = this.reseau.Schema.CreateGraphics();
			this.reseau.Schema.Controls.Remove(this);
			graphics.Dispose();
			this.reseau.Schema.Invalidate(this.reseau.TraceNouveauCable.RectangleTrace(), false);
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600009C RID: 156 RVA: 0x00006198 File Offset: 0x00005198
		// (set) Token: 0x0600009D RID: 157 RVA: 0x000061AC File Offset: 0x000051AC
		public Point A
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600009E RID: 158 RVA: 0x000061C0 File Offset: 0x000051C0
		// (set) Token: 0x0600009F RID: 159 RVA: 0x000061D4 File Offset: 0x000051D4
		public Point B
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000061E8 File Offset: 0x000051E8
		public override Rectangle RectangleTrace()
		{
			return Rectangle.Union(new Rectangle(this.a.X - 1, this.a.Y - 1, 3, 3), new Rectangle(this.b.X - 1, this.b.Y - 1, 3, 3));
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000623C File Offset: 0x0000523C
		public override void Tracer(Graphics g)
		{
			g.DrawLine(this.stylo, this.a, this.b);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00006264 File Offset: 0x00005264
		public override void Effacer(Graphics g)
		{
			g.DrawLine(this.reseau.StyloEfface, this.a, this.b);
		}

		// Token: 0x04000057 RID: 87
		private Container components = null;

		// Token: 0x04000058 RID: 88
		protected Point a;

		// Token: 0x04000059 RID: 89
		protected Point b;
	}
}
