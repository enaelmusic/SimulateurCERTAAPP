namespace Simulateur
{
	// Token: 0x02000032 RID: 50
	public partial class DialoguePortsEcoutes : global::Simulateur.DialogueHashTable
	{
		// Token: 0x06000302 RID: 770 RVA: 0x00026314 File Offset: 0x00025314
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00026340 File Offset: 0x00025340
		private void InitializeComponent()
		{
			this.bt_ok = new global::System.Windows.Forms.Button();
			this.hte_portsEcoutes = new global::Simulateur.PortsEcoutesEdit();
			base.SuspendLayout();
			this.bt_ok.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.bt_ok.Location = new global::System.Drawing.Point(73, 84);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.TabIndex = 3;
			this.bt_ok.Text = "OK";
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			this.hte_portsEcoutes.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.hte_portsEcoutes.Location = new global::System.Drawing.Point(0, 0);
			this.hte_portsEcoutes.Name = "hte_portsEcoutes";
			this.hte_portsEcoutes.Size = new global::System.Drawing.Size(220, 80);
			this.hte_portsEcoutes.TabIndex = 4;
			base.AcceptButton = this.bt_ok;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(220, 113);
			base.ControlBox = false;
			base.Controls.Add(this.hte_portsEcoutes);
			base.Controls.Add(this.bt_ok);
			base.Name = "DialoguePortsEcoutes";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Ports écoutés";
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.DialoguePortsEcoutes_Closing);
			base.ResumeLayout(false);
		}

		// Token: 0x0400028A RID: 650
		private global::System.Windows.Forms.Button bt_ok;

		// Token: 0x0400028B RID: 651
		private global::Simulateur.PortsEcoutesEdit hte_portsEcoutes;

		// Token: 0x0400028C RID: 652
		private global::System.ComponentModel.IContainer components = null;
	}
}
