namespace Simulateur
{
	// Token: 0x02000033 RID: 51
	public partial class DialoguePortVlan : global::Simulateur.DialogueHashTable
	{
		// Token: 0x0600030C RID: 780 RVA: 0x000266CC File Offset: 0x000256CC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600030D RID: 781 RVA: 0x000266F8 File Offset: 0x000256F8
		private void InitializeComponent()
		{
			this.bt_ok = new global::System.Windows.Forms.Button();
			this.hte_portVlan = new global::Simulateur.PortVlanEdit();
			base.SuspendLayout();
			this.bt_ok.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.bt_ok.Location = new global::System.Drawing.Point(83, 84);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.TabIndex = 2;
			this.bt_ok.Text = "OK";
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			this.hte_portVlan.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.hte_portVlan.Location = new global::System.Drawing.Point(0, 0);
			this.hte_portVlan.Name = "hte_portVlan";
			this.hte_portVlan.Size = new global::System.Drawing.Size(240, 80);
			this.hte_portVlan.TabIndex = 2;
			base.AcceptButton = this.bt_ok;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(240, 113);
			base.ControlBox = false;
			base.Controls.Add(this.hte_portVlan);
			base.Controls.Add(this.bt_ok);
			base.MaximizeBox = false;
			base.Name = "DialoguePortVlan";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "DialoguePortVlan";
			base.TopMost = true;
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.DialoguePortVlan_Closing);
			base.ResumeLayout(false);
		}

		// Token: 0x0400028E RID: 654
		private global::System.Windows.Forms.Button bt_ok;

		// Token: 0x0400028F RID: 655
		private global::Simulateur.PortVlanEdit hte_portVlan;

		// Token: 0x04000290 RID: 656
		private global::System.ComponentModel.Container components = null;
	}
}
