namespace Simulateur
{
	// Token: 0x0200005B RID: 91
	public partial class Ip_ConfigIpCarte : global::Simulateur.FormConfig
	{
		// Token: 0x060004EA RID: 1258 RVA: 0x00033C94 File Offset: 0x00032C94
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x00033CE8 File Offset: 0x00032CE8
		private void InitializeComponent()
		{
			this.pn_config = new global::System.Windows.Forms.Panel();
			this.tb_masque = new global::System.Windows.Forms.TextBox();
			this.tb_adresse = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.cb_clientDhcp = new global::System.Windows.Forms.CheckBox();
			this.bt_annuler = new global::System.Windows.Forms.Button();
			this.bt_ok = new global::System.Windows.Forms.Button();
			this.pn_config.SuspendLayout();
			base.SuspendLayout();
			this.pn_config.Controls.Add(this.tb_masque);
			this.pn_config.Controls.Add(this.tb_adresse);
			this.pn_config.Controls.Add(this.label2);
			this.pn_config.Controls.Add(this.label1);
			this.pn_config.Location = new global::System.Drawing.Point(8, 16);
			this.pn_config.Name = "pn_config";
			this.pn_config.Size = new global::System.Drawing.Size(232, 64);
			this.pn_config.TabIndex = 10;
			this.tb_masque.Location = new global::System.Drawing.Point(88, 32);
			this.tb_masque.Name = "tb_masque";
			this.tb_masque.Size = new global::System.Drawing.Size(136, 20);
			this.tb_masque.TabIndex = 1;
			this.tb_masque.Text = "";
			this.tb_adresse.Location = new global::System.Drawing.Point(88, 8);
			this.tb_adresse.Name = "tb_adresse";
			this.tb_adresse.Size = new global::System.Drawing.Size(136, 20);
			this.tb_adresse.TabIndex = 0;
			this.tb_adresse.Text = "";
			this.tb_adresse.Leave += new global::System.EventHandler(this.tb_adresse_Leave);
			this.label2.Location = new global::System.Drawing.Point(8, 32);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(56, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Masque :";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Location = new global::System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(56, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Adresse :";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.cb_clientDhcp.Location = new global::System.Drawing.Point(8, 0);
			this.cb_clientDhcp.Name = "cb_clientDhcp";
			this.cb_clientDhcp.RightToLeft = global::System.Windows.Forms.RightToLeft.Yes;
			this.cb_clientDhcp.Size = new global::System.Drawing.Size(88, 24);
			this.cb_clientDhcp.TabIndex = 15;
			this.cb_clientDhcp.Text = "Client DHCP";
			this.cb_clientDhcp.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cb_clientDhcp.Visible = false;
			this.cb_clientDhcp.CheckedChanged += new global::System.EventHandler(this.cb_clientDhcp_CheckedChanged);
			this.bt_annuler.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.bt_annuler.Location = new global::System.Drawing.Point(48, 88);
			this.bt_annuler.Name = "bt_annuler";
			this.bt_annuler.Size = new global::System.Drawing.Size(64, 23);
			this.bt_annuler.TabIndex = 31;
			this.bt_annuler.Text = "annuler";
			this.bt_annuler.Click += new global::System.EventHandler(this.bt_annuler_Click);
			this.bt_ok.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.bt_ok.Location = new global::System.Drawing.Point(136, 88);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.Size = new global::System.Drawing.Size(64, 23);
			this.bt_ok.TabIndex = 30;
			this.bt_ok.Text = "OK";
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			base.AcceptButton = this.bt_ok;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.bt_annuler;
			base.ClientSize = new global::System.Drawing.Size(250, 119);
			base.ControlBox = false;
			base.Controls.Add(this.bt_annuler);
			base.Controls.Add(this.bt_ok);
			base.Controls.Add(this.cb_clientDhcp);
			base.Controls.Add(this.pn_config);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "Ip_ConfigIpCarte";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Configuration IP de la carte";
			base.TopMost = true;
			this.pn_config.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000369 RID: 873
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400036A RID: 874
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400036B RID: 875
		private global::System.Windows.Forms.Panel pn_config;

		// Token: 0x0400036C RID: 876
		private global::System.Windows.Forms.TextBox tb_adresse;

		// Token: 0x0400036D RID: 877
		private global::System.Windows.Forms.TextBox tb_masque;

		// Token: 0x0400036E RID: 878
		private global::System.Windows.Forms.CheckBox cb_clientDhcp;

		// Token: 0x0400036F RID: 879
		protected global::System.Windows.Forms.Button bt_annuler;

		// Token: 0x04000370 RID: 880
		protected global::System.Windows.Forms.Button bt_ok;

		// Token: 0x04000371 RID: 881
		private global::System.ComponentModel.IContainer components = null;
	}
}
