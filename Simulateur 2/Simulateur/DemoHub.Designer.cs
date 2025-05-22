namespace Simulateur
{
	// Token: 0x02000025 RID: 37
	public partial class DemoHub : global::Simulateur.DemoDialogue
	{
		// Token: 0x06000250 RID: 592 RVA: 0x0001678C File Offset: 0x0001578C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000251 RID: 593 RVA: 0x000167B8 File Offset: 0x000157B8
		private void InitializeComponent()
		{
			global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager(typeof(global::Simulateur.DemoHub));
			this.label3 = new global::System.Windows.Forms.Label();
			this.tb_destinataire = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.tb_emetteur = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.tb_portReception = new global::System.Windows.Forms.TextBox();
			this.lb_ports = new global::System.Windows.Forms.CheckedListBox();
			base.SuspendLayout();
			this.bt_stop.Image = (global::System.Drawing.Bitmap)resourceManager.GetObject("bt_stop.Image");
			this.bt_stop.ImageIndex = -1;
			this.bt_stop.ImageList = null;
			this.bt_stop.Visible = true;
			this.cb_action.ItemHeight = 13;
			this.cb_action.Items.AddRange(new object[]
			{
				"Sélectionner ports de répétition...",
				"Répéter sur ports sélectionnés"
			});
			this.cb_action.Visible = true;
			this.tb_phase.Visible = true;
			this.lecteur.Visible = true;
			this.tb_resultat.Visible = true;
			this.label3.Location = new global::System.Drawing.Point(139, 60);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(28, 20);
			this.label3.TabIndex = 34;
			this.label3.Text = "Vers";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_destinataire.Location = new global::System.Drawing.Point(172, 60);
			this.tb_destinataire.Name = "tb_destinataire";
			this.tb_destinataire.ReadOnly = true;
			this.tb_destinataire.Size = new global::System.Drawing.Size(48, 20);
			this.tb_destinataire.TabIndex = 33;
			this.tb_destinataire.TabStop = false;
			this.tb_destinataire.Text = "";
			this.label2.Location = new global::System.Drawing.Point(63, 60);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(20, 20);
			this.label2.TabIndex = 32;
			this.label2.Text = "De";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_emetteur.Location = new global::System.Drawing.Point(83, 60);
			this.tb_emetteur.Name = "tb_emetteur";
			this.tb_emetteur.ReadOnly = true;
			this.tb_emetteur.Size = new global::System.Drawing.Size(48, 20);
			this.tb_emetteur.TabIndex = 31;
			this.tb_emetteur.TabStop = false;
			this.tb_emetteur.Text = "mac222";
			this.label1.Location = new global::System.Drawing.Point(3, 60);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(28, 20);
			this.label1.TabIndex = 30;
			this.label1.Text = "Port";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_portReception.Location = new global::System.Drawing.Point(31, 60);
			this.tb_portReception.Name = "tb_portReception";
			this.tb_portReception.ReadOnly = true;
			this.tb_portReception.Size = new global::System.Drawing.Size(20, 20);
			this.tb_portReception.TabIndex = 29;
			this.tb_portReception.TabStop = false;
			this.tb_portReception.Text = "24";
			this.lb_ports.CheckOnClick = true;
			this.lb_ports.Location = new global::System.Drawing.Point(4, 88);
			this.lb_ports.Name = "lb_ports";
			this.lb_ports.Size = new global::System.Drawing.Size(215, 94);
			this.lb_ports.TabIndex = 35;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(224, 85);
			base.Controls.AddRange(new global::System.Windows.Forms.Control[]
			{
				this.bt_stop,
				this.cb_action,
				this.tb_resultat,
				this.lecteur,
				this.tb_phase,
				this.lb_ports,
				this.label3,
				this.tb_destinataire,
				this.label2,
				this.tb_emetteur,
				this.label1,
				this.tb_portReception
			});
			base.Name = "DemoHub";
			base.ResumeLayout(false);
		}

		// Token: 0x0400017D RID: 381
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400017E RID: 382
		protected global::System.Windows.Forms.TextBox tb_destinataire;

		// Token: 0x0400017F RID: 383
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000180 RID: 384
		protected global::System.Windows.Forms.TextBox tb_emetteur;

		// Token: 0x04000181 RID: 385
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000182 RID: 386
		protected global::System.Windows.Forms.TextBox tb_portReception;

		// Token: 0x04000183 RID: 387
		private global::System.Windows.Forms.CheckedListBox lb_ports;

		// Token: 0x04000184 RID: 388
		private global::System.ComponentModel.IContainer components = null;
	}
}
