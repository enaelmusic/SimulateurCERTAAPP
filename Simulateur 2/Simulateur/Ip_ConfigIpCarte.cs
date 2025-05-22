using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200005B RID: 91
	public partial class Ip_ConfigIpCarte : FormConfig
	{
		// Token: 0x060004E9 RID: 1257 RVA: 0x00033BFC File Offset: 0x00032BFC
		public Ip_ConfigIpCarte(CarteReseau p_c, SuiteOk p_siOk)
		{
			base.Owner = Form.ActiveForm;
			this.InitializeComponent();
			this.c = p_c;
			this.siOk = p_siOk;
			this.oldAdresse = this.c.Ip.Adresse;
			this.oldMasque = this.c.Ip.Masque;
			base.Location = this.c.posDialogueDemo();
			this.Text = "Configuration IP de la carte n°" + this.c.NumeroOrdre;
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x00033CC0 File Offset: 0x00032CC0
		public Ip_adresse OldAdresse
		{
			get
			{
				return this.oldAdresse;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060004EC RID: 1260 RVA: 0x00033CD4 File Offset: 0x00032CD4
		public Ip_masque OldMasque
		{
			get
			{
				return this.oldMasque;
			}
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x000341C4 File Offset: 0x000331C4
		private void tb_adresse_Leave(object sender, EventArgs e)
		{
			if (this.tb_adresse.Text == "")
			{
				this.tb_adresse.Text = "0.0.0.0";
			}
			if (this.tb_adresse.Text == "0.0.0.0")
			{
				this.tb_masque.Text = "0.0.0.0";
				return;
			}
			if (Ip_adresse.Ok(this.tb_adresse.Text) && (this.tb_masque.Text == "0.0.0.0" || this.tb_masque.Text == ""))
			{
				this.tb_masque.Text = Ip_masque.GetMasqueDefaut(this.tb_adresse.Text);
			}
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x0003427C File Offset: 0x0003327C
		private void cb_clientDhcp_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cb_clientDhcp.Checked)
			{
				this.pn_config.Enabled = false;
				return;
			}
			this.pn_config.Enabled = true;
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x000342B0 File Offset: 0x000332B0
		private void bt_ok_Click(object sender, EventArgs e)
		{
			this.tb_adresse_Leave(null, null);
			this.siOk(this);
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x000342D4 File Offset: 0x000332D4
		private void bt_annuler_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060004F2 RID: 1266 RVA: 0x000342E8 File Offset: 0x000332E8
		// (set) Token: 0x060004F3 RID: 1267 RVA: 0x00034300 File Offset: 0x00033300
		public string Adresse
		{
			get
			{
				return this.tb_adresse.Text;
			}
			set
			{
				this.tb_adresse.Text = value;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060004F4 RID: 1268 RVA: 0x0003431C File Offset: 0x0003331C
		// (set) Token: 0x060004F5 RID: 1269 RVA: 0x00034334 File Offset: 0x00033334
		public string Masque
		{
			get
			{
				return this.tb_masque.Text;
			}
			set
			{
				this.tb_masque.Text = value;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060004F6 RID: 1270 RVA: 0x00034350 File Offset: 0x00033350
		// (set) Token: 0x060004F7 RID: 1271 RVA: 0x00034368 File Offset: 0x00033368
		public bool Dhcp
		{
			get
			{
				return this.cb_clientDhcp.Checked;
			}
			set
			{
				this.cb_clientDhcp.Checked = value;
			}
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00034384 File Offset: 0x00033384
		public void Afficher()
		{
			base.Show();
			this.tb_adresse.Focus();
		}

		// Token: 0x04000372 RID: 882
		private CarteReseau c;

		// Token: 0x04000373 RID: 883
		private SuiteOk siOk;

		// Token: 0x04000374 RID: 884
		private Ip_adresse oldAdresse;

		// Token: 0x04000375 RID: 885
		private Ip_masque oldMasque;
	}
}
