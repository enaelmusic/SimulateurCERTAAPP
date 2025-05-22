namespace Simulateur
{
	// Token: 0x02000021 RID: 33
	public partial class DemoArp : global::Simulateur.DemoDialogue
	{
		// Token: 0x06000215 RID: 533 RVA: 0x00011700 File Offset: 0x00010700
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0001172C File Offset: 0x0001072C
		private void InitializeComponent()
		{
			this.cacheArpEdit1 = new global::Simulateur.CacheArpEdit();
			this.pn_paquetArp = new global::System.Windows.Forms.Panel();
			this.cb_adrMacSource = new global::System.Windows.Forms.ComboBox();
			this.cb_bcast = new global::System.Windows.Forms.CheckBox();
			this.tb_adrIpDest = new global::System.Windows.Forms.TextBox();
			this.tb_adrIpSource = new global::System.Windows.Forms.TextBox();
			this.tb_adrMacDest = new global::System.Windows.Forms.TextBox();
			this.label9 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.cb_typePaquet = new global::System.Windows.Forms.ComboBox();
			this.pn_paquetIp = new global::System.Windows.Forms.Panel();
			this.tb_typePaquetIp = new global::System.Windows.Forms.TextBox();
			this.cb_bcastPaquetIp = new global::System.Windows.Forms.CheckBox();
			this.tb_adrMacDestPaquetIp = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.pn_paquetArp.SuspendLayout();
			this.pn_paquetIp.SuspendLayout();
			base.SuspendLayout();
			this.bt_continuer.Name = "bt_continuer";
			this.bt_stop.Name = "bt_stop";
			this.cb_action.Name = "cb_action";
			this.tb_phase.Name = "tb_phase";
			this.lecteur.Name = "lecteur";
			this.tb_resultat.Name = "tb_resultat";
			this.cacheArpEdit1.Location = new global::System.Drawing.Point(4, 60);
			this.cacheArpEdit1.Name = "cacheArpEdit1";
			this.cacheArpEdit1.Size = new global::System.Drawing.Size(336, 80);
			this.cacheArpEdit1.TabIndex = 20;
			this.pn_paquetArp.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pn_paquetArp.Controls.Add(this.cb_adrMacSource);
			this.pn_paquetArp.Controls.Add(this.cb_bcast);
			this.pn_paquetArp.Controls.Add(this.tb_adrIpDest);
			this.pn_paquetArp.Controls.Add(this.tb_adrIpSource);
			this.pn_paquetArp.Controls.Add(this.tb_adrMacDest);
			this.pn_paquetArp.Controls.Add(this.label9);
			this.pn_paquetArp.Controls.Add(this.label10);
			this.pn_paquetArp.Controls.Add(this.label7);
			this.pn_paquetArp.Controls.Add(this.label6);
			this.pn_paquetArp.Controls.Add(this.label5);
			this.pn_paquetArp.Controls.Add(this.cb_typePaquet);
			this.pn_paquetArp.Location = new global::System.Drawing.Point(4, 60);
			this.pn_paquetArp.Name = "pn_paquetArp";
			this.pn_paquetArp.Size = new global::System.Drawing.Size(440, 80);
			this.pn_paquetArp.TabIndex = 42;
			this.cb_adrMacSource.Location = new global::System.Drawing.Point(100, 28);
			this.cb_adrMacSource.Name = "cb_adrMacSource";
			this.cb_adrMacSource.Size = new global::System.Drawing.Size(121, 21);
			this.cb_adrMacSource.TabIndex = 13;
			this.cb_bcast.Location = new global::System.Drawing.Point(100, 52);
			this.cb_bcast.Name = "cb_bcast";
			this.cb_bcast.Size = new global::System.Drawing.Size(64, 20);
			this.cb_bcast.TabIndex = 12;
			this.cb_bcast.Text = "BCAST";
			this.cb_bcast.CheckedChanged += new global::System.EventHandler(this.cb_bcast_CheckedChanged);
			this.tb_adrIpDest.Location = new global::System.Drawing.Point(312, 28);
			this.tb_adrIpDest.Name = "tb_adrIpDest";
			this.tb_adrIpDest.Size = new global::System.Drawing.Size(120, 20);
			this.tb_adrIpDest.TabIndex = 11;
			this.tb_adrIpDest.Text = "";
			this.tb_adrIpSource.Location = new global::System.Drawing.Point(312, 4);
			this.tb_adrIpSource.Name = "tb_adrIpSource";
			this.tb_adrIpSource.Size = new global::System.Drawing.Size(120, 20);
			this.tb_adrIpSource.TabIndex = 10;
			this.tb_adrIpSource.Text = "";
			this.tb_adrMacDest.Location = new global::System.Drawing.Point(164, 52);
			this.tb_adrMacDest.Name = "tb_adrMacDest";
			this.tb_adrMacDest.ReadOnly = true;
			this.tb_adrMacDest.Size = new global::System.Drawing.Size(108, 20);
			this.tb_adrMacDest.TabIndex = 9;
			this.tb_adrMacDest.Text = "Clic sur la carte";
			this.tb_adrMacDest.Leave += new global::System.EventHandler(this.tb_adrMacDest_Leave);
			this.tb_adrMacDest.Enter += new global::System.EventHandler(this.tb_adrMacDest_Enter);
			this.label9.Location = new global::System.Drawing.Point(224, 28);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(84, 20);
			this.label9.TabIndex = 5;
			this.label9.Text = "Adr IP dest :";
			this.label9.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label10.Location = new global::System.Drawing.Point(224, 4);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(84, 20);
			this.label10.TabIndex = 4;
			this.label10.Text = "Adr IP source :";
			this.label10.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label7.Location = new global::System.Drawing.Point(4, 52);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(92, 20);
			this.label7.TabIndex = 3;
			this.label7.Text = "Adr mac dest :";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label6.Location = new global::System.Drawing.Point(4, 28);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(92, 20);
			this.label6.TabIndex = 2;
			this.label6.Text = "Adr mac source :";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label5.Location = new global::System.Drawing.Point(4, 6);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(92, 16);
			this.label5.TabIndex = 1;
			this.label5.Text = "Type de paquet :";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.cb_typePaquet.Items.AddRange(new object[]
			{
				"ArpRequest",
				"ArpReply"
			});
			this.cb_typePaquet.Location = new global::System.Drawing.Point(100, 4);
			this.cb_typePaquet.Name = "cb_typePaquet";
			this.cb_typePaquet.Size = new global::System.Drawing.Size(121, 21);
			this.cb_typePaquet.TabIndex = 0;
			this.pn_paquetIp.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pn_paquetIp.Controls.Add(this.tb_typePaquetIp);
			this.pn_paquetIp.Controls.Add(this.cb_bcastPaquetIp);
			this.pn_paquetIp.Controls.Add(this.tb_adrMacDestPaquetIp);
			this.pn_paquetIp.Controls.Add(this.label3);
			this.pn_paquetIp.Controls.Add(this.label8);
			this.pn_paquetIp.Location = new global::System.Drawing.Point(4, 60);
			this.pn_paquetIp.Name = "pn_paquetIp";
			this.pn_paquetIp.Size = new global::System.Drawing.Size(280, 56);
			this.pn_paquetIp.TabIndex = 43;
			this.tb_typePaquetIp.Enabled = false;
			this.tb_typePaquetIp.Location = new global::System.Drawing.Point(100, 4);
			this.tb_typePaquetIp.Name = "tb_typePaquetIp";
			this.tb_typePaquetIp.Size = new global::System.Drawing.Size(120, 20);
			this.tb_typePaquetIp.TabIndex = 14;
			this.tb_typePaquetIp.Text = "";
			this.cb_bcastPaquetIp.Location = new global::System.Drawing.Point(100, 28);
			this.cb_bcastPaquetIp.Name = "cb_bcastPaquetIp";
			this.cb_bcastPaquetIp.Size = new global::System.Drawing.Size(64, 20);
			this.cb_bcastPaquetIp.TabIndex = 12;
			this.cb_bcastPaquetIp.Text = "BCAST";
			this.cb_bcastPaquetIp.CheckedChanged += new global::System.EventHandler(this.cb_bcastPaquetIp_CheckedChanged);
			this.tb_adrMacDestPaquetIp.Location = new global::System.Drawing.Point(164, 28);
			this.tb_adrMacDestPaquetIp.Name = "tb_adrMacDestPaquetIp";
			this.tb_adrMacDestPaquetIp.ReadOnly = true;
			this.tb_adrMacDestPaquetIp.Size = new global::System.Drawing.Size(108, 20);
			this.tb_adrMacDestPaquetIp.TabIndex = 9;
			this.tb_adrMacDestPaquetIp.Text = "Clic sur la carte";
			this.tb_adrMacDestPaquetIp.Leave += new global::System.EventHandler(this.tb_adrMacDestPaquetIp_Leave);
			this.tb_adrMacDestPaquetIp.Enter += new global::System.EventHandler(this.tb_adrMacDestPaquetIp_Enter);
			this.label3.Location = new global::System.Drawing.Point(4, 28);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(92, 20);
			this.label3.TabIndex = 3;
			this.label3.Text = "Adr mac dest :";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label8.Location = new global::System.Drawing.Point(4, 6);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(92, 16);
			this.label8.TabIndex = 1;
			this.label8.Text = "Type de paquet :";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(286, 119);
			base.Controls.Add(this.pn_paquetIp);
			base.Controls.Add(this.cacheArpEdit1);
			base.Controls.Add(this.pn_paquetArp);
			base.Name = "DemoArp";
			base.Controls.SetChildIndex(this.pn_paquetArp, 0);
			base.Controls.SetChildIndex(this.cacheArpEdit1, 0);
			base.Controls.SetChildIndex(this.tb_phase, 0);
			base.Controls.SetChildIndex(this.lecteur, 0);
			base.Controls.SetChildIndex(this.tb_resultat, 0);
			base.Controls.SetChildIndex(this.cb_action, 0);
			base.Controls.SetChildIndex(this.bt_stop, 0);
			base.Controls.SetChildIndex(this.bt_continuer, 0);
			base.Controls.SetChildIndex(this.pn_paquetIp, 0);
			this.pn_paquetArp.ResumeLayout(false);
			this.pn_paquetIp.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400012A RID: 298
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400012C RID: 300
		private global::Simulateur.CacheArpEdit cacheArpEdit1;

		// Token: 0x0400012D RID: 301
		private global::System.Windows.Forms.Panel pn_paquetArp;

		// Token: 0x0400012E RID: 302
		private global::System.Windows.Forms.ComboBox cb_adrMacSource;

		// Token: 0x0400012F RID: 303
		private global::System.Windows.Forms.CheckBox cb_bcast;

		// Token: 0x04000130 RID: 304
		private global::System.Windows.Forms.TextBox tb_adrIpDest;

		// Token: 0x04000131 RID: 305
		private global::System.Windows.Forms.TextBox tb_adrIpSource;

		// Token: 0x04000132 RID: 306
		private global::System.Windows.Forms.TextBox tb_adrMacDest;

		// Token: 0x04000133 RID: 307
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000134 RID: 308
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000135 RID: 309
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000136 RID: 310
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000137 RID: 311
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000138 RID: 312
		private global::System.Windows.Forms.ComboBox cb_typePaquet;

		// Token: 0x04000139 RID: 313
		private global::System.Windows.Forms.Panel pn_paquetIp;

		// Token: 0x0400013A RID: 314
		private global::System.Windows.Forms.CheckBox cb_bcastPaquetIp;

		// Token: 0x0400013B RID: 315
		private global::System.Windows.Forms.TextBox tb_adrMacDestPaquetIp;

		// Token: 0x0400013C RID: 316
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400013D RID: 317
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400013E RID: 318
		private global::System.Windows.Forms.TextBox tb_typePaquetIp;
	}
}
