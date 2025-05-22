namespace Simulateur
{
	// Token: 0x02000016 RID: 22
	public partial class ConfigInterConnexion : global::Simulateur.Dialogue
	{
		// Token: 0x0600017F RID: 383 RVA: 0x0000C6DC File Offset: 0x0000B6DC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000C708 File Offset: 0x0000B708
		private void InitializeComponent()
		{
			this.ud_nbPorts = new global::System.Windows.Forms.NumericUpDown();
			this.label2 = new global::System.Windows.Forms.Label();
			this.tb_nom = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.ud_nbPortsCascade = new global::System.Windows.Forms.NumericUpDown();
			this.label3 = new global::System.Windows.Forms.Label();
			this.ud_nbPorts8021q = new global::System.Windows.Forms.NumericUpDown();
			this.lbl_8021q = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.ud_nbPorts).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.ud_nbPortsCascade).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.ud_nbPorts8021q).BeginInit();
			base.SuspendLayout();
			this.bt_annuler.Location = new global::System.Drawing.Point(40, 120);
			this.bt_annuler.Name = "bt_annuler";
			this.bt_ok.Location = new global::System.Drawing.Point(128, 120);
			this.bt_ok.Name = "bt_ok";
			this.ud_nbPorts.Location = new global::System.Drawing.Point(144, 48);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.ud_nbPorts;
			int[] array = new int[4];
			array[0] = 24;
			numericUpDown.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.ud_nbPorts;
			array = new int[4];
			array[0] = 2;
			numericUpDown2.Minimum = new decimal(array);
			this.ud_nbPorts.Name = "ud_nbPorts";
			this.ud_nbPorts.Size = new global::System.Drawing.Size(80, 20);
			this.ud_nbPorts.TabIndex = 12;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.ud_nbPorts;
			array = new int[4];
			array[0] = 2;
			numericUpDown3.Value = new decimal(array);
			this.label2.Location = new global::System.Drawing.Point(8, 50);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(128, 16);
			this.label2.TabIndex = 11;
			this.label2.Text = "Nbre de ports normaux :";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_nom.Location = new global::System.Drawing.Point(72, 16);
			this.tb_nom.Name = "tb_nom";
			this.tb_nom.Size = new global::System.Drawing.Size(136, 20);
			this.tb_nom.TabIndex = 10;
			this.tb_nom.Text = "";
			this.label1.Location = new global::System.Drawing.Point(32, 18);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(40, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "Nom :";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.ud_nbPortsCascade.Location = new global::System.Drawing.Point(144, 72);
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.ud_nbPortsCascade;
			array = new int[4];
			array[0] = 24;
			numericUpDown4.Maximum = new decimal(array);
			this.ud_nbPortsCascade.Name = "ud_nbPortsCascade";
			this.ud_nbPortsCascade.Size = new global::System.Drawing.Size(80, 20);
			this.ud_nbPortsCascade.TabIndex = 14;
			global::System.Windows.Forms.NumericUpDown numericUpDown5 = this.ud_nbPortsCascade;
			array = new int[4];
			array[0] = 2;
			numericUpDown5.Value = new decimal(array);
			this.label3.Location = new global::System.Drawing.Point(8, 74);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(152, 16);
			this.label3.TabIndex = 13;
			this.label3.Text = "Nbre de ports de cascade :";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.ud_nbPorts8021q.Location = new global::System.Drawing.Point(144, 96);
			global::System.Windows.Forms.NumericUpDown numericUpDown6 = this.ud_nbPorts8021q;
			array = new int[4];
			array[0] = 24;
			numericUpDown6.Maximum = new decimal(array);
			this.ud_nbPorts8021q.Name = "ud_nbPorts8021q";
			this.ud_nbPorts8021q.Size = new global::System.Drawing.Size(80, 20);
			this.ud_nbPorts8021q.TabIndex = 20;
			this.lbl_8021q.Location = new global::System.Drawing.Point(8, 98);
			this.lbl_8021q.Name = "lbl_8021q";
			this.lbl_8021q.Size = new global::System.Drawing.Size(152, 16);
			this.lbl_8021q.TabIndex = 19;
			this.lbl_8021q.Text = "Nbre de ports 802.1q :";
			this.lbl_8021q.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(242, 159);
			base.Controls.Add(this.ud_nbPorts8021q);
			base.Controls.Add(this.lbl_8021q);
			base.Controls.Add(this.ud_nbPortsCascade);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.ud_nbPorts);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.tb_nom);
			base.Controls.Add(this.label1);
			base.Name = "ConfigInterConnexion";
			this.Text = "Configuration";
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.tb_nom, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.ud_nbPorts, 0);
			base.Controls.SetChildIndex(this.label3, 0);
			base.Controls.SetChildIndex(this.ud_nbPortsCascade, 0);
			base.Controls.SetChildIndex(this.bt_ok, 0);
			base.Controls.SetChildIndex(this.bt_annuler, 0);
			base.Controls.SetChildIndex(this.lbl_8021q, 0);
			base.Controls.SetChildIndex(this.ud_nbPorts8021q, 0);
			((global::System.ComponentModel.ISupportInitialize)this.ud_nbPorts).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.ud_nbPortsCascade).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.ud_nbPorts8021q).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040000BB RID: 187
		protected global::System.Windows.Forms.Label label2;

		// Token: 0x040000BC RID: 188
		protected global::System.Windows.Forms.TextBox tb_nom;

		// Token: 0x040000BD RID: 189
		protected global::System.Windows.Forms.Label label1;

		// Token: 0x040000BE RID: 190
		protected global::System.Windows.Forms.NumericUpDown ud_nbPortsCascade;

		// Token: 0x040000BF RID: 191
		protected global::System.Windows.Forms.Label label3;

		// Token: 0x040000C0 RID: 192
		protected global::System.Windows.Forms.NumericUpDown ud_nbPorts;

		// Token: 0x040000C1 RID: 193
		protected global::System.Windows.Forms.NumericUpDown ud_nbPorts8021q;

		// Token: 0x040000C2 RID: 194
		protected global::System.Windows.Forms.Label lbl_8021q;

		// Token: 0x040000C3 RID: 195
		private global::System.ComponentModel.IContainer components = null;
	}
}
