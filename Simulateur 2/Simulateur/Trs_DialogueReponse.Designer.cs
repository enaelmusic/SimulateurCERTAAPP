namespace Simulateur
{
	// Token: 0x02000098 RID: 152
	public partial class Trs_DialogueReponse : global::Simulateur.Dialogue
	{
		// Token: 0x060009C1 RID: 2497 RVA: 0x0005B6D4 File Offset: 0x0005A6D4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x0005B700 File Offset: 0x0005A700
		private void InitializeComponent()
		{
			this.lb_requetes = new global::System.Windows.Forms.ListBox();
			this.tb_numPort = new global::System.Windows.Forms.TextBox();
			this.lbl_numPort = new global::System.Windows.Forms.Label();
			this.tb_adrIp = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.tb_protocole = new global::System.Windows.Forms.TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.tb_numPortServeur = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.tb_ipServeur = new global::System.Windows.Forms.TextBox();
			this.label10 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.bt_annuler.Location = new global::System.Drawing.Point(135, 128);
			this.bt_annuler.Name = "bt_annuler";
			this.bt_annuler.Click += new global::System.EventHandler(this.bt_annuler_Click);
			this.bt_ok.Location = new global::System.Drawing.Point(223, 128);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			this.lb_requetes.Location = new global::System.Drawing.Point(8, 20);
			this.lb_requetes.Name = "lb_requetes";
			this.lb_requetes.Size = new global::System.Drawing.Size(408, 69);
			this.lb_requetes.TabIndex = 9;
			this.lb_requetes.SelectedIndexChanged += new global::System.EventHandler(this.lb_requetes_SelectedIndexChanged);
			this.tb_numPort.Enabled = false;
			this.tb_numPort.Location = new global::System.Drawing.Point(372, 96);
			this.tb_numPort.Name = "tb_numPort";
			this.tb_numPort.Size = new global::System.Drawing.Size(44, 20);
			this.tb_numPort.TabIndex = 17;
			this.tb_numPort.Text = "";
			this.tb_numPort.Visible = false;
			this.lbl_numPort.Location = new global::System.Drawing.Point(300, 95);
			this.lbl_numPort.Name = "lbl_numPort";
			this.lbl_numPort.Size = new global::System.Drawing.Size(68, 23);
			this.lbl_numPort.TabIndex = 19;
			this.lbl_numPort.Text = "N° de port :";
			this.lbl_numPort.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.lbl_numPort.Visible = false;
			this.tb_adrIp.Enabled = false;
			this.tb_adrIp.Location = new global::System.Drawing.Point(196, 96);
			this.tb_adrIp.Name = "tb_adrIp";
			this.tb_adrIp.Size = new global::System.Drawing.Size(92, 20);
			this.tb_adrIp.TabIndex = 16;
			this.tb_adrIp.Text = "";
			this.label3.Location = new global::System.Drawing.Point(124, 95);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(68, 23);
			this.label3.TabIndex = 18;
			this.label3.Text = "Adresse IP :";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.tb_protocole.Enabled = false;
			this.tb_protocole.Location = new global::System.Drawing.Point(80, 96);
			this.tb_protocole.Name = "tb_protocole";
			this.tb_protocole.Size = new global::System.Drawing.Size(36, 20);
			this.tb_protocole.TabIndex = 20;
			this.tb_protocole.Text = "";
			this.label4.Location = new global::System.Drawing.Point(8, 95);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(68, 23);
			this.label4.TabIndex = 21;
			this.label4.Text = "Protocole :";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.tb_numPortServeur.Enabled = false;
			this.tb_numPortServeur.Location = new global::System.Drawing.Point(368, 128);
			this.tb_numPortServeur.Name = "tb_numPortServeur";
			this.tb_numPortServeur.Size = new global::System.Drawing.Size(44, 20);
			this.tb_numPortServeur.TabIndex = 22;
			this.tb_numPortServeur.Text = "";
			this.tb_numPortServeur.Visible = false;
			this.label1.Location = new global::System.Drawing.Point(296, 128);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(68, 23);
			this.label1.TabIndex = 23;
			this.label1.Text = "Port serveur :";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Visible = false;
			this.label5.Location = new global::System.Drawing.Point(344, 4);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(60, 16);
			this.label5.TabIndex = 112;
			this.label5.Text = "Port dest.";
			this.label7.Location = new global::System.Drawing.Point(268, 4);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(56, 16);
			this.label7.TabIndex = 111;
			this.label7.Text = "Ip dest.";
			this.label2.Location = new global::System.Drawing.Point(168, 4);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(88, 16);
			this.label2.TabIndex = 110;
			this.label2.Text = "Port sce/Id Icmp";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label6.Location = new global::System.Drawing.Point(108, 4);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(52, 16);
			this.label6.TabIndex = 109;
			this.label6.Text = "Ip source";
			this.label8.Location = new global::System.Drawing.Point(40, 4);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(52, 16);
			this.label8.TabIndex = 108;
			this.label8.Text = "Protocole";
			this.label9.Location = new global::System.Drawing.Point(12, 4);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(24, 16);
			this.label9.TabIndex = 107;
			this.label9.Text = "N°";
			this.tb_ipServeur.Enabled = false;
			this.tb_ipServeur.Location = new global::System.Drawing.Point(80, 128);
			this.tb_ipServeur.Name = "tb_ipServeur";
			this.tb_ipServeur.Size = new global::System.Drawing.Size(44, 20);
			this.tb_ipServeur.TabIndex = 113;
			this.tb_ipServeur.Text = "";
			this.tb_ipServeur.Visible = false;
			this.label10.Location = new global::System.Drawing.Point(8, 128);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(68, 23);
			this.label10.TabIndex = 114;
			this.label10.Text = "IP serveur :";
			this.label10.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label10.Visible = false;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(422, 159);
			base.Controls.Add(this.tb_ipServeur);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.tb_numPortServeur);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.tb_protocole);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.tb_numPort);
			base.Controls.Add(this.lbl_numPort);
			base.Controls.Add(this.tb_adrIp);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.lb_requetes);
			base.Name = "Trs_DialogueReponse";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Sélection de la requête à traiter";
			base.TopMost = true;
			base.Controls.SetChildIndex(this.lb_requetes, 0);
			base.Controls.SetChildIndex(this.bt_ok, 0);
			base.Controls.SetChildIndex(this.bt_annuler, 0);
			base.Controls.SetChildIndex(this.label3, 0);
			base.Controls.SetChildIndex(this.tb_adrIp, 0);
			base.Controls.SetChildIndex(this.lbl_numPort, 0);
			base.Controls.SetChildIndex(this.tb_numPort, 0);
			base.Controls.SetChildIndex(this.label4, 0);
			base.Controls.SetChildIndex(this.tb_protocole, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.tb_numPortServeur, 0);
			base.Controls.SetChildIndex(this.label9, 0);
			base.Controls.SetChildIndex(this.label8, 0);
			base.Controls.SetChildIndex(this.label6, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.label7, 0);
			base.Controls.SetChildIndex(this.label5, 0);
			base.Controls.SetChildIndex(this.label10, 0);
			base.Controls.SetChildIndex(this.tb_ipServeur, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x0400063A RID: 1594
		private global::System.Windows.Forms.TextBox tb_numPort;

		// Token: 0x0400063B RID: 1595
		private global::System.Windows.Forms.Label lbl_numPort;

		// Token: 0x0400063C RID: 1596
		private global::System.Windows.Forms.TextBox tb_adrIp;

		// Token: 0x0400063D RID: 1597
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400063E RID: 1598
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400063F RID: 1599
		private global::System.Windows.Forms.ListBox lb_requetes;

		// Token: 0x04000640 RID: 1600
		private global::System.Windows.Forms.TextBox tb_protocole;

		// Token: 0x04000641 RID: 1601
		private global::System.Windows.Forms.TextBox tb_numPortServeur;

		// Token: 0x04000642 RID: 1602
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000643 RID: 1603
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000644 RID: 1604
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000645 RID: 1605
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000646 RID: 1606
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000647 RID: 1607
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000648 RID: 1608
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000649 RID: 1609
		private global::System.Windows.Forms.TextBox tb_ipServeur;

		// Token: 0x0400064A RID: 1610
		private global::System.Windows.Forms.Label label10;

		// Token: 0x0400064B RID: 1611
		private global::System.ComponentModel.IContainer components = null;
	}
}
