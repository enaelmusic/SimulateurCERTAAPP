namespace Simulateur
{
	// Token: 0x02000019 RID: 25
	public partial class ConfigStation : global::Simulateur.Dialogue
	{
		// Token: 0x060001A6 RID: 422 RVA: 0x0000DA3C File Offset: 0x0000CA3C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0000DA68 File Offset: 0x0000CA68
		private void InitializeComponent()
		{
			this.ud_nbCartes = new global::System.Windows.Forms.NumericUpDown();
			this.label2 = new global::System.Windows.Forms.Label();
			this.tb_nom = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.cb_accesDistant = new global::System.Windows.Forms.CheckBox();
			((global::System.ComponentModel.ISupportInitialize)this.ud_nbCartes).BeginInit();
			base.SuspendLayout();
			this.bt_annuler.Location = new global::System.Drawing.Point(20, 92);
			this.bt_annuler.Name = "bt_annuler";
			this.bt_ok.Location = new global::System.Drawing.Point(108, 92);
			this.bt_ok.Name = "bt_ok";
			this.ud_nbCartes.Location = new global::System.Drawing.Point(136, 36);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.ud_nbCartes;
			int[] array = new int[4];
			array[0] = 3;
			numericUpDown.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.ud_nbCartes;
			array = new int[4];
			array[0] = 1;
			numericUpDown2.Minimum = new decimal(array);
			this.ud_nbCartes.Name = "ud_nbCartes";
			this.ud_nbCartes.Size = new global::System.Drawing.Size(48, 20);
			this.ud_nbCartes.TabIndex = 12;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.ud_nbCartes;
			array = new int[4];
			array[0] = 1;
			numericUpDown3.Value = new decimal(array);
			this.label2.Location = new global::System.Drawing.Point(8, 38);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(124, 16);
			this.label2.TabIndex = 11;
			this.label2.Text = "Nbre de cartes réseau :";
			this.tb_nom.Location = new global::System.Drawing.Point(48, 8);
			this.tb_nom.Name = "tb_nom";
			this.tb_nom.Size = new global::System.Drawing.Size(136, 20);
			this.tb_nom.TabIndex = 10;
			this.tb_nom.Text = "";
			this.label1.Location = new global::System.Drawing.Point(8, 10);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(40, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "Nom :";
			this.cb_accesDistant.Location = new global::System.Drawing.Point(8, 60);
			this.cb_accesDistant.Name = "cb_accesDistant";
			this.cb_accesDistant.RightToLeft = global::System.Windows.Forms.RightToLeft.Yes;
			this.cb_accesDistant.Size = new global::System.Drawing.Size(132, 24);
			this.cb_accesDistant.TabIndex = 13;
			this.cb_accesDistant.Text = "Carte d'accès distant";
			this.cb_accesDistant.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cb_accesDistant.CheckedChanged += new global::System.EventHandler(this.cb_accesDistant_CheckedChanged);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(194, 123);
			base.Controls.Add(this.cb_accesDistant);
			base.Controls.Add(this.ud_nbCartes);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.tb_nom);
			base.Controls.Add(this.label1);
			base.Name = "ConfigStation";
			this.Text = "Configuration d'une station";
			base.Controls.SetChildIndex(this.bt_ok, 0);
			base.Controls.SetChildIndex(this.bt_annuler, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.tb_nom, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.ud_nbCartes, 0);
			base.Controls.SetChildIndex(this.cb_accesDistant, 0);
			((global::System.ComponentModel.ISupportInitialize)this.ud_nbCartes).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040000D5 RID: 213
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000D6 RID: 214
		private global::System.Windows.Forms.TextBox tb_nom;

		// Token: 0x040000D7 RID: 215
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000D8 RID: 216
		private global::System.Windows.Forms.NumericUpDown ud_nbCartes;

		// Token: 0x040000D9 RID: 217
		private global::System.Windows.Forms.CheckBox cb_accesDistant;

		// Token: 0x040000DA RID: 218
		private global::System.ComponentModel.IContainer components = null;
	}
}
