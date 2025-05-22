using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000018 RID: 24
	public partial class ConfigInternet : FormConfig
	{
		// Token: 0x06000195 RID: 405 RVA: 0x0000CF68 File Offset: 0x0000BF68
		public ConfigInternet(Internet i, SuiteOk p_siOk)
		{
			base.Owner = Form.ActiveForm;
			this.InitializeComponent();
			this.siOk = p_siOk;
			base.Location = i.posDialogueDemo();
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000D7CC File Offset: 0x0000C7CC
		private void tb_adrFai1_Leave(object sender, EventArgs e)
		{
			if (this.tb_adrFai1.Text == "")
			{
				this.tb_adrFai1.Text = "0.0.0.0";
			}
			if (Ip_adresse.Ok(this.tb_adrFai1.Text) && (this.tb_masqueFai1.Text == "0.0.0.0" || this.tb_masqueFai1.Text == ""))
			{
				this.tb_masqueFai1.Text = Ip_masque.GetMasqueDefaut(this.tb_adrFai1.Text);
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0000D85C File Offset: 0x0000C85C
		private void tb_adrFai2_Leave(object sender, EventArgs e)
		{
			if (this.tb_adrFai2.Text == "")
			{
				this.tb_adrFai2.Text = "0.0.0.0";
			}
			if (Ip_adresse.Ok(this.tb_adrFai2.Text) && (this.tb_masqueFai2.Text == "0.0.0.0" || this.tb_masqueFai2.Text == ""))
			{
				this.tb_masqueFai2.Text = Ip_masque.GetMasqueDefaut(this.tb_adrFai2.Text);
			}
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0000D8EC File Offset: 0x0000C8EC
		private void bt_ok_Click(object sender, EventArgs e)
		{
			this.tb_adrFai1_Leave(null, null);
			this.tb_adrFai2_Leave(null, null);
			this.siOk(this);
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0000D918 File Offset: 0x0000C918
		private void bt_annuler_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600019C RID: 412 RVA: 0x0000D92C File Offset: 0x0000C92C
		// (set) Token: 0x0600019D RID: 413 RVA: 0x0000D944 File Offset: 0x0000C944
		public string AdrFai1
		{
			get
			{
				return this.tb_adrFai1.Text;
			}
			set
			{
				this.tb_adrFai1.Text = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600019E RID: 414 RVA: 0x0000D960 File Offset: 0x0000C960
		// (set) Token: 0x0600019F RID: 415 RVA: 0x0000D978 File Offset: 0x0000C978
		public string MasqueFai1
		{
			get
			{
				return this.tb_masqueFai1.Text;
			}
			set
			{
				this.tb_masqueFai1.Text = value;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x0000D994 File Offset: 0x0000C994
		// (set) Token: 0x060001A1 RID: 417 RVA: 0x0000D9AC File Offset: 0x0000C9AC
		public string AdrFai2
		{
			get
			{
				return this.tb_adrFai2.Text;
			}
			set
			{
				this.tb_adrFai2.Text = value;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x0000D9C8 File Offset: 0x0000C9C8
		// (set) Token: 0x060001A3 RID: 419 RVA: 0x0000D9E0 File Offset: 0x0000C9E0
		public string MasqueFai2
		{
			get
			{
				return this.tb_masqueFai2.Text;
			}
			set
			{
				this.tb_masqueFai2.Text = value;
			}
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0000D9FC File Offset: 0x0000C9FC
		public void Afficher()
		{
			base.Show();
			this.tb_adrFai1.Focus();
		}

		// Token: 0x040000D4 RID: 212
		private SuiteOk siOk;
	}
}
