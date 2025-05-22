namespace Simulateur
{
	// Token: 0x02000023 RID: 35
	public partial class DemoEchecPing : global::Simulateur.DemoDialogue
	{
		// Token: 0x06000235 RID: 565 RVA: 0x00013560 File Offset: 0x00012560
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0001358C File Offset: 0x0001258C
		private void InitializeComponent()
		{
			global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager(typeof(global::Simulateur.DemoEchecPing));
			this.gb_messageUtilisateur = new global::System.Windows.Forms.GroupBox();
			this.rb_nonJoignable = new global::System.Windows.Forms.RadioButton();
			this.rb_delaiDepasse = new global::System.Windows.Forms.RadioButton();
			this.gb_messageUtilisateur.SuspendLayout();
			base.SuspendLayout();
			this.bt_continuer.Name = "bt_continuer";
			this.bt_stop.Image = (global::System.Drawing.Image)resourceManager.GetObject("bt_stop.Image");
			this.bt_stop.ImageIndex = -1;
			this.bt_stop.ImageList = null;
			this.bt_stop.Name = "bt_stop";
			this.cb_action.ItemHeight = 13;
			this.cb_action.Items.AddRange(new object[]
			{
				"Traiter la trame",
				"Ignorer la trame"
			});
			this.cb_action.Name = "cb_action";
			this.tb_phase.Name = "tb_phase";
			this.lecteur.Name = "lecteur";
			this.tb_resultat.Name = "tb_resultat";
			this.gb_messageUtilisateur.Controls.Add(this.rb_nonJoignable);
			this.gb_messageUtilisateur.Controls.Add(this.rb_delaiDepasse);
			this.gb_messageUtilisateur.Location = new global::System.Drawing.Point(4, 60);
			this.gb_messageUtilisateur.Name = "gb_messageUtilisateur";
			this.gb_messageUtilisateur.Size = new global::System.Drawing.Size(216, 59);
			this.gb_messageUtilisateur.TabIndex = 41;
			this.gb_messageUtilisateur.TabStop = false;
			this.rb_nonJoignable.Location = new global::System.Drawing.Point(20, 32);
			this.rb_nonJoignable.Name = "rb_nonJoignable";
			this.rb_nonJoignable.Size = new global::System.Drawing.Size(180, 20);
			this.rb_nonJoignable.TabIndex = 1;
			this.rb_nonJoignable.Text = "hôte non joignable";
			this.rb_delaiDepasse.Location = new global::System.Drawing.Point(20, 12);
			this.rb_delaiDepasse.Name = "rb_delaiDepasse";
			this.rb_delaiDepasse.Size = new global::System.Drawing.Size(180, 20);
			this.rb_delaiDepasse.TabIndex = 0;
			this.rb_delaiDepasse.Text = "Délai d'attente dépassé";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(222, 59);
			base.Controls.Add(this.gb_messageUtilisateur);
			base.Name = "DemoEchecPing";
			this.Text = "DemoCarteReseau";
			base.Controls.SetChildIndex(this.tb_phase, 0);
			base.Controls.SetChildIndex(this.lecteur, 0);
			base.Controls.SetChildIndex(this.tb_resultat, 0);
			base.Controls.SetChildIndex(this.cb_action, 0);
			base.Controls.SetChildIndex(this.bt_stop, 0);
			base.Controls.SetChildIndex(this.bt_continuer, 0);
			base.Controls.SetChildIndex(this.gb_messageUtilisateur, 0);
			this.gb_messageUtilisateur.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000147 RID: 327
		private global::System.Windows.Forms.GroupBox gb_messageUtilisateur;

		// Token: 0x04000148 RID: 328
		private global::System.Windows.Forms.RadioButton rb_nonJoignable;

		// Token: 0x04000149 RID: 329
		private global::System.Windows.Forms.RadioButton rb_delaiDepasse;

		// Token: 0x0400014A RID: 330
		private global::System.ComponentModel.IContainer components = null;
	}
}
