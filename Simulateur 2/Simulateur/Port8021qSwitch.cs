using System;
using System.ComponentModel;
using System.Drawing;

namespace Simulateur
{
	// Token: 0x02000073 RID: 115
	public class Port8021qSwitch : PortSwitch
	{
		// Token: 0x0600072B RID: 1835 RVA: 0x00043E84 File Offset: 0x00042E84
		public Port8021qSwitch()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x00043EA4 File Offset: 0x00042EA4
		public Port8021qSwitch(Simulation s) : base(s)
		{
			this.InitializeComponent();
			base.Size = new Size(11, 11);
			base.initialiser8021q(s);
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x00043EDC File Offset: 0x00042EDC
		protected override void initOkCables()
		{
			this.typePointConnexion = PointConnexion.TypesPointConnexion.port8021qSwitch;
			base.initOkCables8021q();
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x00043EF8 File Offset: 0x00042EF8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x00043F24 File Offset: 0x00042F24
		private void InitializeComponent()
		{
			base.Name = "Port8021qSwitch";
			base.Paint += base.PortDeCascade_Paint;
		}

		// Token: 0x04000480 RID: 1152
		private IContainer components = null;
	}
}
