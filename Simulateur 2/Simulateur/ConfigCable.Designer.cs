namespace Simulateur
{
	// Token: 0x02000014 RID: 20
	public partial class ConfigCable : global::Simulateur.Dialogue
	{
		// Token: 0x06000173 RID: 371 RVA: 0x0000BEE4 File Offset: 0x0000AEE4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000BF10 File Offset: 0x0000AF10
		private void InitializeComponent()
		{
			this.gb_typeCable = new global::System.Windows.Forms.GroupBox();
			this.rb_telecom = new global::System.Windows.Forms.RadioButton();
			this.rb_coaxial = new global::System.Windows.Forms.RadioButton();
			this.rb_croise = new global::System.Windows.Forms.RadioButton();
			this.rb_droit = new global::System.Windows.Forms.RadioButton();
			this.ud_longueur = new global::System.Windows.Forms.NumericUpDown();
			this.label1 = new global::System.Windows.Forms.Label();
			this.gb_typeCable.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.ud_longueur).BeginInit();
			base.SuspendLayout();
			this.bt_annuler.Location = new global::System.Drawing.Point(32, 176);
			this.bt_annuler.Name = "bt_annuler";
			this.bt_ok.Location = new global::System.Drawing.Point(120, 176);
			this.bt_ok.Name = "bt_ok";
			this.gb_typeCable.Controls.Add(this.rb_telecom);
			this.gb_typeCable.Controls.Add(this.rb_coaxial);
			this.gb_typeCable.Controls.Add(this.rb_croise);
			this.gb_typeCable.Controls.Add(this.rb_droit);
			this.gb_typeCable.Location = new global::System.Drawing.Point(24, 8);
			this.gb_typeCable.Name = "gb_typeCable";
			this.gb_typeCable.Size = new global::System.Drawing.Size(176, 124);
			this.gb_typeCable.TabIndex = 10;
			this.gb_typeCable.TabStop = false;
			this.gb_typeCable.Text = "Type de câble";
			this.rb_telecom.Location = new global::System.Drawing.Point(16, 92);
			this.rb_telecom.Name = "rb_telecom";
			this.rb_telecom.TabIndex = 3;
			this.rb_telecom.Text = "Ligne télécom";
			this.rb_coaxial.Location = new global::System.Drawing.Point(16, 68);
			this.rb_coaxial.Name = "rb_coaxial";
			this.rb_coaxial.TabIndex = 2;
			this.rb_coaxial.Text = "Câble coaxial";
			this.rb_croise.Location = new global::System.Drawing.Point(16, 44);
			this.rb_croise.Name = "rb_croise";
			this.rb_croise.Size = new global::System.Drawing.Size(144, 24);
			this.rb_croise.TabIndex = 1;
			this.rb_croise.Text = "Paires torsadées croisé";
			this.rb_droit.Location = new global::System.Drawing.Point(16, 20);
			this.rb_droit.Name = "rb_droit";
			this.rb_droit.Size = new global::System.Drawing.Size(144, 24);
			this.rb_droit.TabIndex = 0;
			this.rb_droit.Text = "Paires torsadées droit";
			this.ud_longueur.Location = new global::System.Drawing.Point(104, 144);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.ud_longueur;
			int[] array = new int[4];
			array[0] = 500;
			numericUpDown.Maximum = new decimal(array);
			this.ud_longueur.Name = "ud_longueur";
			this.ud_longueur.Size = new global::System.Drawing.Size(88, 20);
			this.ud_longueur.TabIndex = 11;
			this.label1.Location = new global::System.Drawing.Point(32, 144);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(64, 23);
			this.label1.TabIndex = 12;
			this.label1.Text = "Longueur :";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(226, 207);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.ud_longueur);
			base.Controls.Add(this.gb_typeCable);
			base.Name = "ConfigCable";
			this.Text = "Configuration d'un câble";
			base.Controls.SetChildIndex(this.bt_ok, 0);
			base.Controls.SetChildIndex(this.bt_annuler, 0);
			base.Controls.SetChildIndex(this.gb_typeCable, 0);
			base.Controls.SetChildIndex(this.ud_longueur, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			this.gb_typeCable.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.ud_longueur).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040000B0 RID: 176
		private global::System.Windows.Forms.GroupBox gb_typeCable;

		// Token: 0x040000B1 RID: 177
		private global::System.Windows.Forms.RadioButton rb_droit;

		// Token: 0x040000B2 RID: 178
		private global::System.Windows.Forms.RadioButton rb_croise;

		// Token: 0x040000B3 RID: 179
		private global::System.Windows.Forms.NumericUpDown ud_longueur;

		// Token: 0x040000B4 RID: 180
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000B5 RID: 181
		private global::System.Windows.Forms.RadioButton rb_coaxial;

		// Token: 0x040000B6 RID: 182
		private global::System.Windows.Forms.RadioButton rb_telecom;

		// Token: 0x040000B7 RID: 183
		private global::System.ComponentModel.IContainer components = null;
	}
}
