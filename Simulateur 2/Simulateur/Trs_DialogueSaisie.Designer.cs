namespace Simulateur
{
	// Token: 0x02000099 RID: 153
	public partial class Trs_DialogueSaisie : global::Simulateur.Dialogue
	{
		// Token: 0x060009CB RID: 2507 RVA: 0x0005C6F8 File Offset: 0x0005B6F8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x0005C724 File Offset: 0x0005B724
		private void InitializeComponent()
		{
			this.tb_adrIp = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.cb_protocole = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.tb_numPort = new global::System.Windows.Forms.TextBox();
			this.lbl_numPort = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.bt_annuler.Location = new global::System.Drawing.Point(24, 112);
			this.bt_annuler.Name = "bt_annuler";
			this.bt_annuler.TabIndex = 4;
			this.bt_annuler.Click += new global::System.EventHandler(this.bt_annuler_Click);
			this.bt_ok.Location = new global::System.Drawing.Point(112, 112);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.TabIndex = 3;
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			this.tb_adrIp.Location = new global::System.Drawing.Point(80, 40);
			this.tb_adrIp.Name = "tb_adrIp";
			this.tb_adrIp.Size = new global::System.Drawing.Size(104, 20);
			this.tb_adrIp.TabIndex = 1;
			this.tb_adrIp.Text = "";
			this.label1.Location = new global::System.Drawing.Point(8, 40);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(72, 23);
			this.label1.TabIndex = 11;
			this.label1.Text = "Adresse IP :";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.cb_protocole.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_protocole.Items.AddRange(new object[]
			{
				"TCP",
				"UDP",
				"ICMP"
			});
			this.cb_protocole.Location = new global::System.Drawing.Point(76, 8);
			this.cb_protocole.Name = "cb_protocole";
			this.cb_protocole.Size = new global::System.Drawing.Size(108, 21);
			this.cb_protocole.TabIndex = 0;
			this.cb_protocole.SelectedIndexChanged += new global::System.EventHandler(this.cb_protocole_SelectedIndexChanged);
			this.label2.Location = new global::System.Drawing.Point(8, 12);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(64, 16);
			this.label2.TabIndex = 13;
			this.label2.Text = "Protocole :";
			this.tb_numPort.Location = new global::System.Drawing.Point(80, 72);
			this.tb_numPort.Name = "tb_numPort";
			this.tb_numPort.Size = new global::System.Drawing.Size(104, 20);
			this.tb_numPort.TabIndex = 2;
			this.tb_numPort.Text = "";
			this.lbl_numPort.Location = new global::System.Drawing.Point(8, 72);
			this.lbl_numPort.Name = "lbl_numPort";
			this.lbl_numPort.Size = new global::System.Drawing.Size(72, 23);
			this.lbl_numPort.TabIndex = 15;
			this.lbl_numPort.Text = "N° de port :";
			this.lbl_numPort.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(198, 151);
			base.Controls.Add(this.tb_numPort);
			base.Controls.Add(this.lbl_numPort);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.cb_protocole);
			base.Controls.Add(this.tb_adrIp);
			base.Controls.Add(this.label1);
			base.Name = "Trs_DialogueSaisie";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Paramétrage de l'envoi";
			base.TopMost = true;
			base.Controls.SetChildIndex(this.bt_ok, 0);
			base.Controls.SetChildIndex(this.bt_annuler, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.tb_adrIp, 0);
			base.Controls.SetChildIndex(this.cb_protocole, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.lbl_numPort, 0);
			base.Controls.SetChildIndex(this.tb_numPort, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x04000651 RID: 1617
		private global::System.Windows.Forms.TextBox tb_adrIp;

		// Token: 0x04000652 RID: 1618
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000653 RID: 1619
		private global::System.Windows.Forms.ComboBox cb_protocole;

		// Token: 0x04000654 RID: 1620
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000655 RID: 1621
		private global::System.Windows.Forms.TextBox tb_numPort;

		// Token: 0x04000656 RID: 1622
		private global::System.Windows.Forms.Label lbl_numPort;

		// Token: 0x04000657 RID: 1623
		private global::System.ComponentModel.IContainer components = null;
	}
}
