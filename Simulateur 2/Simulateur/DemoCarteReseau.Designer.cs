namespace Simulateur
{
	// Token: 0x02000022 RID: 34
	public partial class DemoCarteReseau : global::Simulateur.DemoDialogue
	{
		// Token: 0x0600022D RID: 557 RVA: 0x00012FC8 File Offset: 0x00011FC8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00012FF4 File Offset: 0x00011FF4
		private void InitializeComponent()
		{
			global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager(typeof(global::Simulateur.DemoCarteReseau));
			this.tb_destinataire = new global::System.Windows.Forms.TextBox();
			this.lb_destinataire = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.bt_stop.Image = (global::System.Drawing.Bitmap)resourceManager.GetObject("bt_stop.Image");
			this.bt_stop.ImageIndex = -1;
			this.bt_stop.ImageList = null;
			this.bt_stop.Visible = true;
			this.cb_action.ItemHeight = 13;
			this.cb_action.Items.AddRange(new object[]
			{
				"Traiter la trame",
				"Ignorer la trame"
			});
			this.cb_action.Visible = true;
			this.tb_phase.Visible = true;
			this.lecteur.Visible = true;
			this.tb_resultat.Visible = true;
			this.tb_destinataire.Location = new global::System.Drawing.Point(80, 60);
			this.tb_destinataire.Name = "tb_destinataire";
			this.tb_destinataire.ReadOnly = true;
			this.tb_destinataire.Size = new global::System.Drawing.Size(140, 20);
			this.tb_destinataire.TabIndex = 13;
			this.tb_destinataire.TabStop = false;
			this.tb_destinataire.Text = "";
			this.lb_destinataire.Location = new global::System.Drawing.Point(7, 62);
			this.lb_destinataire.Name = "lb_destinataire";
			this.lb_destinataire.Size = new global::System.Drawing.Size(72, 16);
			this.lb_destinataire.TabIndex = 12;
			this.lb_destinataire.Text = "Destinataire :";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(224, 85);
			base.Controls.AddRange(new global::System.Windows.Forms.Control[]
			{
				this.bt_stop,
				this.cb_action,
				this.tb_resultat,
				this.lecteur,
				this.tb_phase,
				this.tb_destinataire,
				this.lb_destinataire
			});
			base.Name = "DemoCarteReseau";
			this.Text = "DemoCarteReseau";
			base.ResumeLayout(false);
		}

		// Token: 0x04000144 RID: 324
		protected global::System.Windows.Forms.TextBox tb_destinataire;

		// Token: 0x04000145 RID: 325
		private global::System.Windows.Forms.Label lb_destinataire;

		// Token: 0x04000146 RID: 326
		private global::System.ComponentModel.IContainer components = null;
	}
}
