namespace Simulateur
{
	// Token: 0x02000029 RID: 41
	public partial class DemoSwitch : global::Simulateur.DemoDialogue
	{
		// Token: 0x060002A1 RID: 673 RVA: 0x00021EC8 File Offset: 0x00020EC8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00021EF4 File Offset: 0x00020EF4
		private void InitializeComponent()
		{
			global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager(typeof(global::Simulateur.DemoSwitch));
			this.tb_portReception = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.tb_emetteur = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.tb_destinataire = new global::System.Windows.Forms.TextBox();
			this.macPortEdit1 = new global::Simulateur.MacPortEdit();
			this.lb_ports = new global::System.Windows.Forms.CheckedListBox();
			this.portVlanEdit1 = new global::Simulateur.PortVlanEdit();
			this.macVlanEdit1 = new global::Simulateur.MacVlanEdit();
			this.tb_vlanMarque = new global::System.Windows.Forms.TextBox();
			base.SuspendLayout();
			this.bt_continuer.Name = "bt_continuer";
			this.bt_stop.Image = (global::System.Drawing.Image)resourceManager.GetObject("bt_stop.Image");
			this.bt_stop.ImageIndex = -1;
			this.bt_stop.ImageList = null;
			this.bt_stop.Name = "bt_stop";
			this.cb_action.ItemHeight = 13;
			this.cb_action.Items.AddRange(new object[]
			{
				"Editer la table mac/port...",
				"Sélectionner ports de réémission...",
				"Réémettre sur ports sélectionnés",
				"Ne pas réémettre"
			});
			this.cb_action.Name = "cb_action";
			this.tb_phase.Name = "tb_phase";
			this.lecteur.Name = "lecteur";
			this.tb_resultat.Name = "tb_resultat";
			this.tb_portReception.Location = new global::System.Drawing.Point(32, 60);
			this.tb_portReception.Name = "tb_portReception";
			this.tb_portReception.ReadOnly = true;
			this.tb_portReception.Size = new global::System.Drawing.Size(20, 20);
			this.tb_portReception.TabIndex = 23;
			this.tb_portReception.TabStop = false;
			this.tb_portReception.Text = "24";
			this.label1.Location = new global::System.Drawing.Point(4, 60);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(28, 20);
			this.label1.TabIndex = 24;
			this.label1.Text = "Port";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.Location = new global::System.Drawing.Point(64, 60);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(20, 20);
			this.label2.TabIndex = 26;
			this.label2.Text = "De";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_emetteur.Location = new global::System.Drawing.Point(84, 60);
			this.tb_emetteur.Name = "tb_emetteur";
			this.tb_emetteur.ReadOnly = true;
			this.tb_emetteur.Size = new global::System.Drawing.Size(48, 20);
			this.tb_emetteur.TabIndex = 25;
			this.tb_emetteur.TabStop = false;
			this.tb_emetteur.Text = "mac222";
			this.label3.Location = new global::System.Drawing.Point(140, 60);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(28, 20);
			this.label3.TabIndex = 28;
			this.label3.Text = "Vers";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_destinataire.Location = new global::System.Drawing.Point(172, 60);
			this.tb_destinataire.Name = "tb_destinataire";
			this.tb_destinataire.ReadOnly = true;
			this.tb_destinataire.Size = new global::System.Drawing.Size(48, 20);
			this.tb_destinataire.TabIndex = 27;
			this.tb_destinataire.TabStop = false;
			this.tb_destinataire.Text = "";
			this.macPortEdit1.Location = new global::System.Drawing.Point(0, 88);
			this.macPortEdit1.Name = "macPortEdit1";
			this.macPortEdit1.Size = new global::System.Drawing.Size(240, 80);
			this.macPortEdit1.TabIndex = 29;
			this.lb_ports.CheckOnClick = true;
			this.lb_ports.Location = new global::System.Drawing.Point(4, 88);
			this.lb_ports.Name = "lb_ports";
			this.lb_ports.Size = new global::System.Drawing.Size(215, 94);
			this.lb_ports.TabIndex = 36;
			this.portVlanEdit1.Location = new global::System.Drawing.Point(0, 88);
			this.portVlanEdit1.Name = "portVlanEdit1";
			this.portVlanEdit1.Size = new global::System.Drawing.Size(240, 80);
			this.portVlanEdit1.TabIndex = 37;
			this.macVlanEdit1.Location = new global::System.Drawing.Point(0, 88);
			this.macVlanEdit1.Name = "macVlanEdit1";
			this.macVlanEdit1.Size = new global::System.Drawing.Size(184, 80);
			this.macVlanEdit1.TabIndex = 38;
			this.tb_vlanMarque.Location = new global::System.Drawing.Point(4, 84);
			this.tb_vlanMarque.Name = "tb_vlanMarque";
			this.tb_vlanMarque.ReadOnly = true;
			this.tb_vlanMarque.Size = new global::System.Drawing.Size(216, 20);
			this.tb_vlanMarque.TabIndex = 39;
			this.tb_vlanMarque.TabStop = false;
			this.tb_vlanMarque.Text = "mac222";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(314, 207);
			base.Controls.Add(this.tb_vlanMarque);
			base.Controls.Add(this.macVlanEdit1);
			base.Controls.Add(this.portVlanEdit1);
			base.Controls.Add(this.lb_ports);
			base.Controls.Add(this.macPortEdit1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.tb_destinataire);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.tb_emetteur);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.tb_portReception);
			base.Name = "DemoSwitch";
			base.Closed += new global::System.EventHandler(this.DemoSwitch_Closed);
			base.Activated += new global::System.EventHandler(this.DemoSwitch_Activated);
			base.Controls.SetChildIndex(this.tb_portReception, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.tb_emetteur, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.tb_destinataire, 0);
			base.Controls.SetChildIndex(this.label3, 0);
			base.Controls.SetChildIndex(this.macPortEdit1, 0);
			base.Controls.SetChildIndex(this.lb_ports, 0);
			base.Controls.SetChildIndex(this.portVlanEdit1, 0);
			base.Controls.SetChildIndex(this.macVlanEdit1, 0);
			base.Controls.SetChildIndex(this.tb_phase, 0);
			base.Controls.SetChildIndex(this.lecteur, 0);
			base.Controls.SetChildIndex(this.tb_resultat, 0);
			base.Controls.SetChildIndex(this.cb_action, 0);
			base.Controls.SetChildIndex(this.bt_stop, 0);
			base.Controls.SetChildIndex(this.bt_continuer, 0);
			base.Controls.SetChildIndex(this.tb_vlanMarque, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x04000252 RID: 594
		protected global::System.Windows.Forms.TextBox tb_portReception;

		// Token: 0x04000253 RID: 595
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000254 RID: 596
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000255 RID: 597
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000256 RID: 598
		protected global::System.Windows.Forms.TextBox tb_emetteur;

		// Token: 0x04000257 RID: 599
		protected global::System.Windows.Forms.TextBox tb_destinataire;

		// Token: 0x04000258 RID: 600
		private global::Simulateur.MacPortEdit macPortEdit1;

		// Token: 0x04000259 RID: 601
		private global::System.Windows.Forms.CheckedListBox lb_ports;

		// Token: 0x0400025A RID: 602
		private global::Simulateur.PortVlanEdit portVlanEdit1;

		// Token: 0x0400025B RID: 603
		private global::Simulateur.MacVlanEdit macVlanEdit1;

		// Token: 0x0400025C RID: 604
		protected global::System.Windows.Forms.TextBox tb_vlanMarque;

		// Token: 0x0400025D RID: 605
		private global::System.ComponentModel.IContainer components = null;
	}
}
