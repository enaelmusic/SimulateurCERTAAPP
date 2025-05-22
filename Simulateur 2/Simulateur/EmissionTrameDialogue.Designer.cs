namespace Simulateur
{
	// Token: 0x0200003C RID: 60
	public partial class EmissionTrameDialogue : global::System.Windows.Forms.Form
	{
		// Token: 0x06000377 RID: 887 RVA: 0x000299BC File Offset: 0x000289BC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000378 RID: 888 RVA: 0x000299E8 File Offset: 0x000289E8
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.tb_adrMacDestinataire = new global::System.Windows.Forms.TextBox();
			this.gb_destination = new global::System.Windows.Forms.GroupBox();
			this.rb_broadcast = new global::System.Windows.Forms.RadioButton();
			this.rb_unicast = new global::System.Windows.Forms.RadioButton();
			this.bt_annuler = new global::System.Windows.Forms.Button();
			this.bt_ok = new global::System.Windows.Forms.Button();
			this.cb_tailleTrame = new global::System.Windows.Forms.ComboBox();
			this.gb_destination.SuspendLayout();
			base.SuspendLayout();
			this.label1.Location = new global::System.Drawing.Point(8, 56);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(160, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "Adresse MAC du destinataire :";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.tb_adrMacDestinataire.Location = new global::System.Drawing.Point(8, 72);
			this.tb_adrMacDestinataire.Name = "tb_adrMacDestinataire";
			this.tb_adrMacDestinataire.ReadOnly = true;
			this.tb_adrMacDestinataire.Size = new global::System.Drawing.Size(168, 20);
			this.tb_adrMacDestinataire.TabIndex = 0;
			this.tb_adrMacDestinataire.Text = "";
			this.tb_adrMacDestinataire.TextChanged += new global::System.EventHandler(this.tb_adrMacDestinataire_TextChanged);
			this.gb_destination.Controls.Add(this.rb_broadcast);
			this.gb_destination.Controls.Add(this.rb_unicast);
			this.gb_destination.Location = new global::System.Drawing.Point(8, 0);
			this.gb_destination.Name = "gb_destination";
			this.gb_destination.Size = new global::System.Drawing.Size(168, 48);
			this.gb_destination.TabIndex = 12;
			this.gb_destination.TabStop = false;
			this.gb_destination.Text = "Destination";
			this.rb_broadcast.Checked = true;
			this.rb_broadcast.Location = new global::System.Drawing.Point(88, 16);
			this.rb_broadcast.Name = "rb_broadcast";
			this.rb_broadcast.Size = new global::System.Drawing.Size(72, 24);
			this.rb_broadcast.TabIndex = 1;
			this.rb_broadcast.TabStop = true;
			this.rb_broadcast.Text = "broadcast";
			this.rb_broadcast.CheckedChanged += new global::System.EventHandler(this.destination_Changed);
			this.rb_unicast.Location = new global::System.Drawing.Point(8, 16);
			this.rb_unicast.Name = "rb_unicast";
			this.rb_unicast.Size = new global::System.Drawing.Size(64, 24);
			this.rb_unicast.TabIndex = 0;
			this.rb_unicast.Text = "unicast";
			this.rb_unicast.CheckedChanged += new global::System.EventHandler(this.destination_Changed);
			this.bt_annuler.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.bt_annuler.Location = new global::System.Drawing.Point(16, 124);
			this.bt_annuler.Name = "bt_annuler";
			this.bt_annuler.Size = new global::System.Drawing.Size(64, 23);
			this.bt_annuler.TabIndex = 14;
			this.bt_annuler.Text = "annuler";
			this.bt_annuler.Click += new global::System.EventHandler(this.bt_annuler_Click);
			this.bt_ok.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.bt_ok.Location = new global::System.Drawing.Point(104, 124);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.Size = new global::System.Drawing.Size(64, 23);
			this.bt_ok.TabIndex = 13;
			this.bt_ok.Text = "OK";
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			this.cb_tailleTrame.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_tailleTrame.Items.AddRange(new object[]
			{
				"trame courte",
				"trame moyenne",
				"trame longue"
			});
			this.cb_tailleTrame.Location = new global::System.Drawing.Point(8, 96);
			this.cb_tailleTrame.Name = "cb_tailleTrame";
			this.cb_tailleTrame.Size = new global::System.Drawing.Size(170, 21);
			this.cb_tailleTrame.TabIndex = 15;
			base.AcceptButton = this.bt_ok;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.bt_annuler;
			base.ClientSize = new global::System.Drawing.Size(184, 155);
			base.ControlBox = false;
			base.Controls.Add(this.cb_tailleTrame);
			base.Controls.Add(this.bt_annuler);
			base.Controls.Add(this.bt_ok);
			base.Controls.Add(this.gb_destination);
			base.Controls.Add(this.tb_adrMacDestinataire);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.Name = "EmissionTrameDialogue";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Emission trame";
			base.TopMost = true;
			base.Activated += new global::System.EventHandler(this.EmissionTrameDialogue_Activated);
			this.gb_destination.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040002C9 RID: 713
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002CA RID: 714
		private global::System.Windows.Forms.TextBox tb_adrMacDestinataire;

		// Token: 0x040002CB RID: 715
		private global::System.Windows.Forms.RadioButton rb_unicast;

		// Token: 0x040002CC RID: 716
		private global::System.Windows.Forms.RadioButton rb_broadcast;

		// Token: 0x040002CD RID: 717
		protected global::System.Windows.Forms.Button bt_annuler;

		// Token: 0x040002CE RID: 718
		protected global::System.Windows.Forms.Button bt_ok;

		// Token: 0x040002CF RID: 719
		private global::System.Windows.Forms.GroupBox gb_destination;

		// Token: 0x040002D0 RID: 720
		private global::System.Windows.Forms.ComboBox cb_tailleTrame;

		// Token: 0x040002D1 RID: 721
		private global::System.ComponentModel.IContainer components = null;
	}
}
