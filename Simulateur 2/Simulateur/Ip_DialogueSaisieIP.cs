using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200005D RID: 93
	public partial class Ip_DialogueSaisieIP : Dialogue
	{
		// Token: 0x06000512 RID: 1298 RVA: 0x00034E10 File Offset: 0x00033E10
		public Ip_DialogueSaisieIP()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x00034E30 File Offset: 0x00033E30
		public Ip_DialogueSaisieIP(SuiteOk p_siOk, SuiteAnnuler p_siAnnuler, Noeud p_n)
		{
			this.InitializeComponent();
			this.n = p_n;
			this.siOk = p_siOk;
			this.siAnnuler = p_siAnnuler;
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x00035158 File Offset: 0x00034158
		public void bt_ok_Click(object sender, EventArgs e)
		{
			string infos = this.tb_adrIp.Text.Trim();
			if (this.n.Reseau.Pref.MemoriserPosDemo)
			{
				this.n.FixerPosition(base.Location.X, base.Location.Y);
			}
			base.Close();
			this.siOk(infos);
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x000351C8 File Offset: 0x000341C8
		private void bt_annuler_Click(object sender, EventArgs e)
		{
			this.siAnnuler();
			base.Close();
		}

		// Token: 0x170000A0 RID: 160
		// (set) Token: 0x06000518 RID: 1304 RVA: 0x000351E8 File Offset: 0x000341E8
		public string AdrIpSaisie
		{
			set
			{
				this.tb_adrIp.Text = value;
			}
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x00035204 File Offset: 0x00034204
		public void BloquerSaisie()
		{
			this.tb_adrIp.Enabled = false;
			this.bt_annuler.Enabled = false;
			this.bt_ok.Enabled = false;
		}

		// Token: 0x04000388 RID: 904
		private Noeud n;

		// Token: 0x04000389 RID: 905
		private SuiteOk siOk;

		// Token: 0x0400038A RID: 906
		private SuiteAnnuler siAnnuler;
	}
}
