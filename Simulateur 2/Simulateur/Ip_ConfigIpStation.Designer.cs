namespace Simulateur
{
	// Token: 0x0200005C RID: 92
	public partial class Ip_ConfigIpStation : global::Simulateur.FormConfig
	{
		// Token: 0x060004FB RID: 1275 RVA: 0x00034404 File Offset: 0x00033404
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00034430 File Offset: 0x00033430
		private void InitializeComponent()
		{
			this.tb_serveurDns = new global::System.Windows.Forms.TextBox();
			this.tb_passerelle = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.lb_interface = new global::System.Windows.Forms.ListBox();
			this.lbl_interfaces = new global::System.Windows.Forms.Label();
			this.tb_nomHote = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.cb_activerRoutage = new global::System.Windows.Forms.CheckBox();
			this.bt_annuler = new global::System.Windows.Forms.Button();
			this.bt_ok = new global::System.Windows.Forms.Button();
			this.cb_natPat = new global::System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.tb_serveurDns.Location = new global::System.Drawing.Point(92, 220);
			this.tb_serveurDns.Name = "tb_serveurDns";
			this.tb_serveurDns.Size = new global::System.Drawing.Size(136, 20);
			this.tb_serveurDns.TabIndex = 21;
			this.tb_serveurDns.Text = "";
			this.tb_serveurDns.Visible = false;
			this.tb_passerelle.Location = new global::System.Drawing.Point(88, 32);
			this.tb_passerelle.Name = "tb_passerelle";
			this.tb_passerelle.Size = new global::System.Drawing.Size(136, 20);
			this.tb_passerelle.TabIndex = 0;
			this.tb_passerelle.Text = "";
			this.label3.Location = new global::System.Drawing.Point(12, 220);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(79, 23);
			this.label3.TabIndex = 22;
			this.label3.Text = "Serveur DNS :";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label3.Visible = false;
			this.label4.Location = new global::System.Drawing.Point(8, 32);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(63, 23);
			this.label4.TabIndex = 19;
			this.label4.Text = "Passerelle :";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.lb_interface.Location = new global::System.Drawing.Point(4, 132);
			this.lb_interface.Name = "lb_interface";
			this.lb_interface.Size = new global::System.Drawing.Size(240, 56);
			this.lb_interface.TabIndex = 23;
			this.lbl_interfaces.Location = new global::System.Drawing.Point(8, 108);
			this.lbl_interfaces.Name = "lbl_interfaces";
			this.lbl_interfaces.Size = new global::System.Drawing.Size(79, 23);
			this.lbl_interfaces.TabIndex = 24;
			this.lbl_interfaces.Text = "Interfaces :";
			this.lbl_interfaces.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_nomHote.Location = new global::System.Drawing.Point(88, 8);
			this.tb_nomHote.Name = "tb_nomHote";
			this.tb_nomHote.Size = new global::System.Drawing.Size(136, 20);
			this.tb_nomHote.TabIndex = 25;
			this.tb_nomHote.Text = "";
			this.label2.Location = new global::System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(79, 23);
			this.label2.TabIndex = 26;
			this.label2.Text = "Nom d'hôte :";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.cb_activerRoutage.Location = new global::System.Drawing.Point(48, 60);
			this.cb_activerRoutage.Name = "cb_activerRoutage";
			this.cb_activerRoutage.Size = new global::System.Drawing.Size(120, 24);
			this.cb_activerRoutage.TabIndex = 27;
			this.cb_activerRoutage.Text = "Activer le routage";
			this.cb_activerRoutage.CheckedChanged += new global::System.EventHandler(this.cb_activerRoutage_CheckedChanged);
			this.bt_annuler.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.bt_annuler.Location = new global::System.Drawing.Point(47, 196);
			this.bt_annuler.Name = "bt_annuler";
			this.bt_annuler.Size = new global::System.Drawing.Size(64, 23);
			this.bt_annuler.TabIndex = 29;
			this.bt_annuler.Text = "annuler";
			this.bt_annuler.Click += new global::System.EventHandler(this.bt_annuler_Click);
			this.bt_ok.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.bt_ok.Location = new global::System.Drawing.Point(135, 196);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.Size = new global::System.Drawing.Size(64, 23);
			this.bt_ok.TabIndex = 28;
			this.bt_ok.Text = "OK";
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			this.cb_natPat.Location = new global::System.Drawing.Point(48, 80);
			this.cb_natPat.Name = "cb_natPat";
			this.cb_natPat.Size = new global::System.Drawing.Size(192, 24);
			this.cb_natPat.TabIndex = 30;
			this.cb_natPat.Text = "Nat / Pat (sélectionnez l'interface)";
			base.AcceptButton = this.bt_ok;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.bt_annuler;
			base.ClientSize = new global::System.Drawing.Size(246, 227);
			base.ControlBox = false;
			base.Controls.Add(this.cb_natPat);
			base.Controls.Add(this.bt_annuler);
			base.Controls.Add(this.bt_ok);
			base.Controls.Add(this.cb_activerRoutage);
			base.Controls.Add(this.tb_nomHote);
			base.Controls.Add(this.tb_serveurDns);
			base.Controls.Add(this.tb_passerelle);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.lbl_interfaces);
			base.Controls.Add(this.lb_interface);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label4);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "Ip_ConfigIpStation";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Configuration IP de la station";
			base.TopMost = true;
			base.ResumeLayout(false);
		}

		// Token: 0x04000376 RID: 886
		private global::System.Windows.Forms.TextBox tb_serveurDns;

		// Token: 0x04000377 RID: 887
		private global::System.Windows.Forms.TextBox tb_passerelle;

		// Token: 0x04000378 RID: 888
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000379 RID: 889
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400037A RID: 890
		private global::System.Windows.Forms.ListBox lb_interface;

		// Token: 0x0400037B RID: 891
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400037C RID: 892
		private global::System.Windows.Forms.TextBox tb_nomHote;

		// Token: 0x0400037D RID: 893
		private global::System.Windows.Forms.CheckBox cb_activerRoutage;

		// Token: 0x0400037E RID: 894
		protected global::System.Windows.Forms.Button bt_annuler;

		// Token: 0x0400037F RID: 895
		protected global::System.Windows.Forms.Button bt_ok;

		// Token: 0x04000380 RID: 896
		private global::System.Windows.Forms.CheckBox cb_natPat;

		// Token: 0x04000381 RID: 897
		private global::System.Windows.Forms.Label lbl_interfaces;

		// Token: 0x04000382 RID: 898
		private global::System.ComponentModel.IContainer components = null;
	}
}
