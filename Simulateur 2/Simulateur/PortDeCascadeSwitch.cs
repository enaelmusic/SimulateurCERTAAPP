using System;
using System.ComponentModel;
using System.Drawing;

namespace Simulateur
{
	// Token: 0x02000076 RID: 118
	public class PortDeCascadeSwitch : PortSwitch
	{
		// Token: 0x06000745 RID: 1861 RVA: 0x000447CC File Offset: 0x000437CC
		public PortDeCascadeSwitch()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x000447EC File Offset: 0x000437EC
		public PortDeCascadeSwitch(Simulation s) : base(s)
		{
			this.InitializeComponent();
			base.Size = new Size(11, 11);
			base.initialiserCascade(s);
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x00044824 File Offset: 0x00043824
		protected override void initOkCables()
		{
			this.typePointConnexion = PointConnexion.TypesPointConnexion.portCascadeSwitch;
			base.initOkCablesMDIX();
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x00044840 File Offset: 0x00043840
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x0004486C File Offset: 0x0004386C
		public override void Dessiner(Graphics g)
		{
			base.dessinerFond(g);
			g.DrawRectangle(this.stylo, base.NoeudAttache.Location.X + base.Location.X + 1, base.NoeudAttache.Location.Y + base.Location.Y + 1, base.Width - 2, base.Height - 2);
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x000448E4 File Offset: 0x000438E4
		private void InitializeComponent()
		{
			base.Name = "PortDeCascadeSwitch";
			base.Paint += base.PortDeCascade_Paint;
		}

		// Token: 0x04000485 RID: 1157
		private IContainer components = null;
	}
}
