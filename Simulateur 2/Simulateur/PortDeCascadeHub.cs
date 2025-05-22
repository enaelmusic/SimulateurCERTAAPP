using System;
using System.ComponentModel;
using System.Drawing;

namespace Simulateur
{
	// Token: 0x02000075 RID: 117
	public class PortDeCascadeHub : PortHub
	{
		// Token: 0x0600073F RID: 1855 RVA: 0x00044688 File Offset: 0x00043688
		public PortDeCascadeHub()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x000446A8 File Offset: 0x000436A8
		public PortDeCascadeHub(Simulation s) : base(s)
		{
			this.InitializeComponent();
			base.Size = new Size(11, 11);
			base.initialiserCascade(s);
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x000446E0 File Offset: 0x000436E0
		protected override void initOkCables()
		{
			this.typePointConnexion = PointConnexion.TypesPointConnexion.portCascadeHub;
			base.initOkCablesMDIX();
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x000446FC File Offset: 0x000436FC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x00044728 File Offset: 0x00043728
		public override void Dessiner(Graphics g)
		{
			base.dessinerFond(g);
			g.DrawRectangle(this.stylo, base.NoeudAttache.Location.X + base.Location.X + 1, base.NoeudAttache.Location.Y + base.Location.Y + 1, base.Width - 2, base.Height - 2);
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x000447A0 File Offset: 0x000437A0
		private void InitializeComponent()
		{
			base.Name = "PortDeCascadeHub";
			base.Paint += base.PortDeCascade_Paint;
		}

		// Token: 0x04000484 RID: 1156
		private IContainer components = null;
	}
}
