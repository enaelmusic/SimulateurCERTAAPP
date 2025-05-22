using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200005C RID: 92
	public partial class Ip_ConfigIpStation : FormConfig
	{
		// Token: 0x060004F9 RID: 1273 RVA: 0x000343A4 File Offset: 0x000333A4
		public Ip_ConfigIpStation()
		{
			this.InitializeComponent();
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x000343C4 File Offset: 0x000333C4
		public Ip_ConfigIpStation(Station s, SuiteOk p_siOk)
		{
			base.Owner = Form.ActiveForm;
			this.InitializeComponent();
			base.Location = s.posDialogueDemo();
			this.siOk = p_siOk;
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00034AB8 File Offset: 0x00033AB8
		private void bt_ok_Click(object sender, EventArgs e)
		{
			this.siOk(this);
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00034AD4 File Offset: 0x00033AD4
		private void bt_annuler_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00034AE8 File Offset: 0x00033AE8
		private void cb_activerRoutage_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cb_activerRoutage.Checked)
			{
				this.cb_natPat.Enabled = true;
				return;
			}
			this.cb_natPat.Checked = false;
			this.cb_natPat.Enabled = false;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00034B28 File Offset: 0x00033B28
		public void SetCarteQuiNat(int numInterface)
		{
			this.lb_interface.SelectedIndex = numInterface;
			this.cb_natPat.CheckedChanged += this.cb_natPat_CheckedChanged;
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x00034B58 File Offset: 0x00033B58
		private void cb_natPat_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cb_natPat.Checked)
			{
				this.lb_interface.SelectedIndex = 0;
				return;
			}
			this.lb_interface.SelectedIndex = -1;
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000502 RID: 1282 RVA: 0x00034B8C File Offset: 0x00033B8C
		// (set) Token: 0x06000503 RID: 1283 RVA: 0x00034BA4 File Offset: 0x00033BA4
		public string NomHote
		{
			get
			{
				return this.tb_nomHote.Text;
			}
			set
			{
				this.tb_nomHote.Text = value;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000504 RID: 1284 RVA: 0x00034BC0 File Offset: 0x00033BC0
		// (set) Token: 0x06000505 RID: 1285 RVA: 0x00034BD8 File Offset: 0x00033BD8
		public string Passerelle
		{
			get
			{
				return this.tb_passerelle.Text;
			}
			set
			{
				this.tb_passerelle.Text = value;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000506 RID: 1286 RVA: 0x00034BF4 File Offset: 0x00033BF4
		// (set) Token: 0x06000507 RID: 1287 RVA: 0x00034C0C File Offset: 0x00033C0C
		public string ServeurDns
		{
			get
			{
				return this.tb_serveurDns.Text;
			}
			set
			{
				this.tb_serveurDns.Text = value;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000508 RID: 1288 RVA: 0x00034C28 File Offset: 0x00033C28
		public ListBox Interfaces
		{
			get
			{
				return this.lb_interface;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000509 RID: 1289 RVA: 0x00034C3C File Offset: 0x00033C3C
		// (set) Token: 0x0600050A RID: 1290 RVA: 0x00034C54 File Offset: 0x00033C54
		public bool ActiverRoutage
		{
			get
			{
				return this.cb_activerRoutage.Checked;
			}
			set
			{
				this.cb_activerRoutage.Checked = value;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x0600050B RID: 1291 RVA: 0x00034C70 File Offset: 0x00033C70
		// (set) Token: 0x0600050C RID: 1292 RVA: 0x00034C88 File Offset: 0x00033C88
		public bool ActiverRoutageEnabled
		{
			get
			{
				return this.cb_activerRoutage.Enabled;
			}
			set
			{
				this.cb_activerRoutage.Enabled = value;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600050D RID: 1293 RVA: 0x00034CA4 File Offset: 0x00033CA4
		// (set) Token: 0x0600050E RID: 1294 RVA: 0x00034CBC File Offset: 0x00033CBC
		public bool ActiverNatPat
		{
			get
			{
				return this.cb_natPat.Checked;
			}
			set
			{
				this.cb_natPat.Checked = value;
			}
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x00034CD8 File Offset: 0x00033CD8
		public void ConfigPseudoMode(bool ipMode)
		{
			if (ipMode)
			{
				this.cb_natPat.Visible = false;
				this.lbl_interfaces.Location = new Point(8, 92);
				this.lb_interface.Location = new Point(4, 116);
				this.bt_annuler.Location = new Point(47, 180);
				this.bt_ok.Location = new Point(135, 180);
				base.Size = new Size(252, 236);
				return;
			}
			this.cb_natPat.Visible = true;
			this.lbl_interfaces.Location = new Point(8, 108);
			this.lb_interface.Location = new Point(4, 132);
			this.bt_annuler.Location = new Point(47, 196);
			this.bt_ok.Location = new Point(135, 196);
			base.Size = new Size(252, 252);
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000510 RID: 1296 RVA: 0x00034DDC File Offset: 0x00033DDC
		// (set) Token: 0x06000511 RID: 1297 RVA: 0x00034DF4 File Offset: 0x00033DF4
		public bool ActiverNatPatEnabled
		{
			get
			{
				return this.cb_natPat.Enabled;
			}
			set
			{
				this.cb_natPat.Enabled = value;
			}
		}

		// Token: 0x04000383 RID: 899
		private SuiteOk siOk;
	}
}
