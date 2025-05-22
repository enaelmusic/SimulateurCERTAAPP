namespace Simulateur
{
	// Token: 0x02000018 RID: 24
	public partial class ConfigInternet : global::Simulateur.FormConfig
	{
		// Token: 0x06000196 RID: 406 RVA: 0x0000CFA8 File Offset: 0x0000BFA8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0000CFD4 File Offset: 0x0000BFD4
		private void InitializeComponent()
		{
			this.pn_config = new global::System.Windows.Forms.Panel();
			this.label3 = new global::System.Windows.Forms.Label();
			this.tb_masqueFai1 = new global::System.Windows.Forms.TextBox();
			this.tb_adrFai1 = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.bt_annuler = new global::System.Windows.Forms.Button();
			this.bt_ok = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label4 = new global::System.Windows.Forms.Label();
			this.tb_masqueFai2 = new global::System.Windows.Forms.TextBox();
			this.tb_adrFai2 = new global::System.Windows.Forms.TextBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.pn_config.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.pn_config.Controls.Add(this.label3);
			this.pn_config.Controls.Add(this.tb_masqueFai1);
			this.pn_config.Controls.Add(this.tb_adrFai1);
			this.pn_config.Controls.Add(this.label2);
			this.pn_config.Controls.Add(this.label1);
			this.pn_config.Location = new global::System.Drawing.Point(8, 8);
			this.pn_config.Name = "pn_config";
			this.pn_config.Size = new global::System.Drawing.Size(248, 84);
			this.pn_config.TabIndex = 10;
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new global::System.Drawing.Point(4, 4);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(96, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "FAI 1 :";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_masqueFai1.Location = new global::System.Drawing.Point(96, 56);
			this.tb_masqueFai1.Name = "tb_masqueFai1";
			this.tb_masqueFai1.Size = new global::System.Drawing.Size(136, 20);
			this.tb_masqueFai1.TabIndex = 1;
			this.tb_masqueFai1.Text = "";
			this.tb_adrFai1.Location = new global::System.Drawing.Point(96, 32);
			this.tb_adrFai1.Name = "tb_adrFai1";
			this.tb_adrFai1.Size = new global::System.Drawing.Size(136, 20);
			this.tb_adrFai1.TabIndex = 0;
			this.tb_adrFai1.Text = "";
			this.tb_adrFai1.Leave += new global::System.EventHandler(this.tb_adrFai1_Leave);
			this.label2.Location = new global::System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(56, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Masque :";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Location = new global::System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(96, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Adresse réseau :";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.bt_annuler.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.bt_annuler.Location = new global::System.Drawing.Point(52, 196);
			this.bt_annuler.Name = "bt_annuler";
			this.bt_annuler.Size = new global::System.Drawing.Size(64, 23);
			this.bt_annuler.TabIndex = 5;
			this.bt_annuler.Text = "annuler";
			this.bt_annuler.Click += new global::System.EventHandler(this.bt_annuler_Click);
			this.bt_ok.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.bt_ok.Location = new global::System.Drawing.Point(140, 196);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.Size = new global::System.Drawing.Size(64, 23);
			this.bt_ok.TabIndex = 4;
			this.bt_ok.Text = "OK";
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.tb_masqueFai2);
			this.panel1.Controls.Add(this.tb_adrFai2);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Location = new global::System.Drawing.Point(8, 100);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(248, 84);
			this.panel1.TabIndex = 32;
			this.label4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new global::System.Drawing.Point(4, 4);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(96, 23);
			this.label4.TabIndex = 2;
			this.label4.Text = "FAI 2 :";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_masqueFai2.Location = new global::System.Drawing.Point(96, 56);
			this.tb_masqueFai2.Name = "tb_masqueFai2";
			this.tb_masqueFai2.Size = new global::System.Drawing.Size(136, 20);
			this.tb_masqueFai2.TabIndex = 3;
			this.tb_masqueFai2.Text = "";
			this.tb_adrFai2.Location = new global::System.Drawing.Point(96, 32);
			this.tb_adrFai2.Name = "tb_adrFai2";
			this.tb_adrFai2.Size = new global::System.Drawing.Size(136, 20);
			this.tb_adrFai2.TabIndex = 2;
			this.tb_adrFai2.Text = "";
			this.tb_adrFai2.Leave += new global::System.EventHandler(this.tb_adrFai2_Leave);
			this.label5.Location = new global::System.Drawing.Point(8, 56);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(56, 23);
			this.label5.TabIndex = 1;
			this.label5.Text = "Masque :";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label6.Location = new global::System.Drawing.Point(8, 32);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(96, 23);
			this.label6.TabIndex = 0;
			this.label6.Text = "Adresse réseau :";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			base.AcceptButton = this.bt_ok;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.bt_annuler;
			base.ClientSize = new global::System.Drawing.Size(262, 227);
			base.ControlBox = false;
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.bt_annuler);
			base.Controls.Add(this.bt_ok);
			base.Controls.Add(this.pn_config);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "ConfigInternet";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Configuration des fournisseurs d'accès";
			base.TopMost = true;
			this.pn_config.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.Panel pn_config;

		// Token: 0x040000C8 RID: 200
		protected global::System.Windows.Forms.Button bt_annuler;

		// Token: 0x040000C9 RID: 201
		protected global::System.Windows.Forms.Button bt_ok;

		// Token: 0x040000CA RID: 202
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040000CB RID: 203
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040000CC RID: 204
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040000CD RID: 205
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040000CE RID: 206
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.TextBox tb_masqueFai1;

		// Token: 0x040000D0 RID: 208
		private global::System.Windows.Forms.TextBox tb_adrFai1;

		// Token: 0x040000D1 RID: 209
		private global::System.Windows.Forms.TextBox tb_masqueFai2;

		// Token: 0x040000D2 RID: 210
		private global::System.Windows.Forms.TextBox tb_adrFai2;

		// Token: 0x040000D3 RID: 211
		private global::System.ComponentModel.IContainer components = null;
	}
}
