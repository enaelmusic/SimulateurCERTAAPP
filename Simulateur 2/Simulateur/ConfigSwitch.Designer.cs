namespace Simulateur
{
	// Token: 0x0200001A RID: 26
	public partial class ConfigSwitch : global::Simulateur.ConfigInterConnexion
	{
		// Token: 0x060001B5 RID: 437 RVA: 0x0000E0E8 File Offset: 0x0000D0E8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0000E114 File Offset: 0x0000D114
		private void InitializeComponent()
		{
			this.gb_typeSwitch = new global::System.Windows.Forms.GroupBox();
			this.rb_storeAndForward = new global::System.Windows.Forms.RadioButton();
			this.rb_onTheFly = new global::System.Windows.Forms.RadioButton();
			this.cb_spanningTree = new global::System.Windows.Forms.CheckBox();
			this.ud_niveauVlan = new global::System.Windows.Forms.NumericUpDown();
			this.label4 = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.ud_nbPortsCascade).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.ud_nbPorts).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.ud_nbPorts8021q).BeginInit();
			this.gb_typeSwitch.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.ud_niveauVlan).BeginInit();
			base.SuspendLayout();
			this.label2.Location = new global::System.Drawing.Point(8, 50);
			this.label2.Name = "label2";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_nom.Location = new global::System.Drawing.Point(72, 16);
			this.tb_nom.Name = "tb_nom";
			this.label1.Location = new global::System.Drawing.Point(32, 18);
			this.label1.Name = "label1";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.ud_nbPortsCascade.Location = new global::System.Drawing.Point(152, 72);
			this.ud_nbPortsCascade.Name = "ud_nbPortsCascade";
			this.label3.Location = new global::System.Drawing.Point(8, 74);
			this.label3.Name = "label3";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.ud_nbPorts.Location = new global::System.Drawing.Point(152, 48);
			this.ud_nbPorts.Name = "ud_nbPorts";
			this.ud_nbPorts8021q.Location = new global::System.Drawing.Point(152, 96);
			this.ud_nbPorts8021q.Name = "ud_nbPorts8021q";
			this.lbl_8021q.Location = new global::System.Drawing.Point(8, 98);
			this.lbl_8021q.Name = "lbl_8021q";
			this.lbl_8021q.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.bt_annuler.Location = new global::System.Drawing.Point(40, 240);
			this.bt_annuler.Name = "bt_annuler";
			this.bt_ok.Location = new global::System.Drawing.Point(128, 240);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			this.gb_typeSwitch.Controls.Add(this.rb_storeAndForward);
			this.gb_typeSwitch.Controls.Add(this.rb_onTheFly);
			this.gb_typeSwitch.Location = new global::System.Drawing.Point(8, 152);
			this.gb_typeSwitch.Name = "gb_typeSwitch";
			this.gb_typeSwitch.Size = new global::System.Drawing.Size(216, 48);
			this.gb_typeSwitch.TabIndex = 15;
			this.gb_typeSwitch.TabStop = false;
			this.gb_typeSwitch.Text = "Type de switch";
			this.rb_storeAndForward.Location = new global::System.Drawing.Point(96, 16);
			this.rb_storeAndForward.Name = "rb_storeAndForward";
			this.rb_storeAndForward.Size = new global::System.Drawing.Size(112, 24);
			this.rb_storeAndForward.TabIndex = 1;
			this.rb_storeAndForward.Text = "store and forward";
			this.rb_onTheFly.Checked = true;
			this.rb_onTheFly.Location = new global::System.Drawing.Point(16, 16);
			this.rb_onTheFly.Name = "rb_onTheFly";
			this.rb_onTheFly.Size = new global::System.Drawing.Size(72, 24);
			this.rb_onTheFly.TabIndex = 0;
			this.rb_onTheFly.TabStop = true;
			this.rb_onTheFly.Text = "on the fly";
			this.cb_spanningTree.Location = new global::System.Drawing.Point(16, 208);
			this.cb_spanningTree.Name = "cb_spanningTree";
			this.cb_spanningTree.Size = new global::System.Drawing.Size(208, 24);
			this.cb_spanningTree.TabIndex = 16;
			this.cb_spanningTree.Text = "gestion spanning tree";
			this.ud_niveauVlan.Location = new global::System.Drawing.Point(152, 120);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.ud_niveauVlan;
			int[] array = new int[4];
			array[0] = 2;
			numericUpDown.Maximum = new decimal(array);
			this.ud_niveauVlan.Name = "ud_niveauVlan";
			this.ud_niveauVlan.Size = new global::System.Drawing.Size(80, 20);
			this.ud_niveauVlan.TabIndex = 22;
			this.label4.Location = new global::System.Drawing.Point(9, 120);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(135, 16);
			this.label4.TabIndex = 21;
			this.label4.Text = "Niveau vlan (0 si  aucun) :";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(242, 271);
			base.Controls.Add(this.ud_niveauVlan);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.cb_spanningTree);
			base.Controls.Add(this.gb_typeSwitch);
			base.Name = "ConfigSwitch";
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.label3, 0);
			base.Controls.SetChildIndex(this.gb_typeSwitch, 0);
			base.Controls.SetChildIndex(this.cb_spanningTree, 0);
			base.Controls.SetChildIndex(this.bt_ok, 0);
			base.Controls.SetChildIndex(this.bt_annuler, 0);
			base.Controls.SetChildIndex(this.tb_nom, 0);
			base.Controls.SetChildIndex(this.ud_nbPorts, 0);
			base.Controls.SetChildIndex(this.ud_nbPortsCascade, 0);
			base.Controls.SetChildIndex(this.lbl_8021q, 0);
			base.Controls.SetChildIndex(this.ud_nbPorts8021q, 0);
			base.Controls.SetChildIndex(this.label4, 0);
			base.Controls.SetChildIndex(this.ud_niveauVlan, 0);
			((global::System.ComponentModel.ISupportInitialize)this.ud_nbPortsCascade).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.ud_nbPorts).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.ud_nbPorts8021q).EndInit();
			this.gb_typeSwitch.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.ud_niveauVlan).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040000DB RID: 219
		private global::System.Windows.Forms.GroupBox gb_typeSwitch;

		// Token: 0x040000DC RID: 220
		private global::System.Windows.Forms.RadioButton rb_onTheFly;

		// Token: 0x040000DD RID: 221
		private global::System.Windows.Forms.RadioButton rb_storeAndForward;

		// Token: 0x040000DE RID: 222
		private global::System.Windows.Forms.CheckBox cb_spanningTree;

		// Token: 0x040000DF RID: 223
		protected global::System.Windows.Forms.NumericUpDown ud_niveauVlan;

		// Token: 0x040000E0 RID: 224
		protected global::System.Windows.Forms.Label label4;

		// Token: 0x040000E1 RID: 225
		private global::System.ComponentModel.IContainer components = null;
	}
}
