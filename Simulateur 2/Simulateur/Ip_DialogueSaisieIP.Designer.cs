namespace Simulateur
{
	// Token: 0x0200005D RID: 93
	public partial class Ip_DialogueSaisieIP : global::Simulateur.Dialogue
	{
		// Token: 0x06000514 RID: 1300 RVA: 0x00034E68 File Offset: 0x00033E68
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x00034E94 File Offset: 0x00033E94
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.tb_adrIp = new global::System.Windows.Forms.TextBox();
			this.lbl_attention = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.bt_annuler.Location = new global::System.Drawing.Point(24, 40);
			this.bt_annuler.Name = "bt_annuler";
			this.bt_annuler.TabIndex = 2;
			this.bt_annuler.Click += new global::System.EventHandler(this.bt_annuler_Click);
			this.bt_ok.Location = new global::System.Drawing.Point(112, 40);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.TabIndex = 1;
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			this.label1.Location = new global::System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(72, 23);
			this.label1.TabIndex = 9;
			this.label1.Text = "Adresse IP :";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_adrIp.Location = new global::System.Drawing.Point(80, 8);
			this.tb_adrIp.Name = "tb_adrIp";
			this.tb_adrIp.Size = new global::System.Drawing.Size(104, 20);
			this.tb_adrIp.TabIndex = 0;
			this.tb_adrIp.Text = "";
			this.lbl_attention.ForeColor = global::System.Drawing.Color.Red;
			this.lbl_attention.Location = new global::System.Drawing.Point(0, 64);
			this.lbl_attention.Name = "lbl_attention";
			this.lbl_attention.Size = new global::System.Drawing.Size(192, 64);
			this.lbl_attention.TabIndex = 10;
			this.lbl_attention.Text = "Attention, les règles de filtrage et de translation (nat/pat) ne sont pas prises en compte par cette simulation (utilisez \"Envoyer une requête\")";
			this.lbl_attention.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lbl_attention.Visible = false;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(194, 71);
			base.Controls.Add(this.lbl_attention);
			base.Controls.Add(this.tb_adrIp);
			base.Controls.Add(this.label1);
			base.Name = "Ip_DialogueSaisieIP";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			base.TopMost = true;
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.tb_adrIp, 0);
			base.Controls.SetChildIndex(this.lbl_attention, 0);
			base.Controls.SetChildIndex(this.bt_ok, 0);
			base.Controls.SetChildIndex(this.bt_annuler, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x04000384 RID: 900
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000385 RID: 901
		private global::System.Windows.Forms.TextBox tb_adrIp;

		// Token: 0x04000386 RID: 902
		private global::System.Windows.Forms.Label lbl_attention;

		// Token: 0x04000387 RID: 903
		private global::System.ComponentModel.IContainer components = null;
	}
}
