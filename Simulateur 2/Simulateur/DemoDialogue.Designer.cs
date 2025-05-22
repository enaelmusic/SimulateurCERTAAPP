namespace Simulateur
{
	// Token: 0x02000020 RID: 32
	public partial class DemoDialogue : global::System.Windows.Forms.Form
	{
		// Token: 0x060001EC RID: 492 RVA: 0x00010608 File Offset: 0x0000F608
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00010634 File Offset: 0x0000F634
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager(typeof(global::Simulateur.DemoDialogue));
			this.tb_phase = new global::System.Windows.Forms.TextBox();
			this.tb_resultat = new global::System.Windows.Forms.TextBox();
			this.il_images = new global::System.Windows.Forms.ImageList(this.components);
			this.bt_stop = new global::System.Windows.Forms.Button();
			this.cb_action = new global::System.Windows.Forms.ComboBox();
			this.lecteur = new global::Simulateur.LecteurDemo();
			this.bt_continuer = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.tb_phase.Location = new global::System.Drawing.Point(72, 5);
			this.tb_phase.Name = "tb_phase";
			this.tb_phase.ReadOnly = true;
			this.tb_phase.Size = new global::System.Drawing.Size(148, 20);
			this.tb_phase.TabIndex = 4;
			this.tb_phase.TabStop = false;
			this.tb_phase.Text = "";
			this.tb_resultat.BackColor = global::System.Drawing.SystemColors.Window;
			this.tb_resultat.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tb_resultat.ForeColor = global::System.Drawing.Color.Black;
			this.tb_resultat.Location = new global::System.Drawing.Point(4, 33);
			this.tb_resultat.Name = "tb_resultat";
			this.tb_resultat.ReadOnly = true;
			this.tb_resultat.Size = new global::System.Drawing.Size(216, 20);
			this.tb_resultat.TabIndex = 15;
			this.tb_resultat.TabStop = false;
			this.tb_resultat.Text = "";
			this.il_images.ImageSize = new global::System.Drawing.Size(16, 16);
			this.il_images.ImageStream = (global::System.Windows.Forms.ImageListStreamer)resourceManager.GetObject("il_images.ImageStream");
			this.il_images.TransparentColor = global::System.Drawing.Color.White;
			this.bt_stop.ImageIndex = 0;
			this.bt_stop.ImageList = this.il_images;
			this.bt_stop.Location = new global::System.Drawing.Point(4, 7);
			this.bt_stop.Name = "bt_stop";
			this.bt_stop.Size = new global::System.Drawing.Size(16, 16);
			this.bt_stop.TabIndex = 18;
			this.bt_stop.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.control_KeyPress);
			this.bt_stop.Click += new global::System.EventHandler(this.bt_stop_Click);
			this.cb_action.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_action.Location = new global::System.Drawing.Point(32, 5);
			this.cb_action.MaxDropDownItems = 10;
			this.cb_action.Name = "cb_action";
			this.cb_action.Size = new global::System.Drawing.Size(188, 21);
			this.cb_action.TabIndex = 17;
			this.cb_action.TabStop = false;
			this.cb_action.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.control_KeyPress);
			this.cb_action.SelectedIndexChanged += new global::System.EventHandler(this.cb_action_SelectedIndexChanged);
			this.lecteur.BackColor = global::System.Drawing.SystemColors.Control;
			this.lecteur.Location = new global::System.Drawing.Point(4, 7);
			this.lecteur.Name = "lecteur";
			this.lecteur.Size = new global::System.Drawing.Size(64, 16);
			this.lecteur.TabIndex = 0;
			this.bt_continuer.Location = new global::System.Drawing.Point(144, 4);
			this.bt_continuer.Name = "bt_continuer";
			this.bt_continuer.TabIndex = 19;
			this.bt_continuer.Text = "continuer";
			this.bt_continuer.Click += new global::System.EventHandler(this.bt_continuer_Click);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(224, 85);
			base.ControlBox = false;
			base.Controls.Add(this.bt_continuer);
			base.Controls.Add(this.bt_stop);
			base.Controls.Add(this.cb_action);
			base.Controls.Add(this.tb_resultat);
			base.Controls.Add(this.tb_phase);
			base.Controls.Add(this.lecteur);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.Name = "DemoDialogue";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "DemoDialogue";
			base.TopMost = true;
			base.Closed += new global::System.EventHandler(this.DemoDialogue_Closed);
			base.ResumeLayout(false);
		}

		// Token: 0x04000104 RID: 260
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000105 RID: 261
		protected global::System.Windows.Forms.Button bt_continuer;

		// Token: 0x04000109 RID: 265
		protected global::System.Windows.Forms.Button bt_stop;

		// Token: 0x0400010A RID: 266
		protected global::System.Windows.Forms.ComboBox cb_action;

		// Token: 0x0400010B RID: 267
		protected global::System.Windows.Forms.TextBox tb_phase;

		// Token: 0x0400010C RID: 268
		protected global::Simulateur.LecteurDemo lecteur;

		// Token: 0x0400010D RID: 269
		protected global::System.Windows.Forms.TextBox tb_resultat;

		// Token: 0x0400010E RID: 270
		private global::System.Windows.Forms.ImageList il_images;
	}
}
