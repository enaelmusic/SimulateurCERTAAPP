using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000077 RID: 119
	public class PortFai : CarteReseau
	{
		// Token: 0x0600074B RID: 1867 RVA: 0x00044910 File Offset: 0x00043910
		public PortFai()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x00044930 File Offset: 0x00043930
		public PortFai(Simulation s) : base(s)
		{
			this.InitializeComponent();
			base.Size = new Size(11, 11);
			base.Protocole = "ppp";
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x0004496C File Offset: 0x0004396C
		protected override void initOkCables()
		{
			this.typePointConnexion = PointConnexion.TypesPointConnexion.portFai;
			this.initOkCablesFai();
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x00044988 File Offset: 0x00043988
		protected void initOkCablesFai()
		{
			this.okCableTelecom.Add(PointConnexion.TypesPointConnexion.carteAccesDistant);
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x000449A8 File Offset: 0x000439A8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x000449D4 File Offset: 0x000439D4
		private void InitializeComponent()
		{
			this.mi_configurer.Enabled = false;
			this.mi_configurer.Visible = false;
			base.Name = "PortFai";
			base.Size = new Size(88, 216);
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x00044A18 File Offset: 0x00043A18
		protected override ContextMenu menuIp()
		{
			return null;
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x00044A28 File Offset: 0x00043A28
		protected override ContextMenu menuEthernet()
		{
			return null;
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x00044A38 File Offset: 0x00043A38
		public override bool EstSurStation()
		{
			return true;
		}

		// Token: 0x04000486 RID: 1158
		private IContainer components = null;
	}
}
