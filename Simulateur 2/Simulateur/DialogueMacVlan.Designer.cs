namespace Simulateur
{
	// Token: 0x02000030 RID: 48
	public partial class DialogueMacVlan : global::Simulateur.DialogueHashTable
	{
		// Token: 0x060002F0 RID: 752 RVA: 0x00025D60 File Offset: 0x00024D60
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00025D8C File Offset: 0x00024D8C
		private void InitializeComponent()
		{
			this.hte_macVlan = new global::Simulateur.MacVlanEdit();
			this.bt_ok = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.hte_macVlan.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.hte_macVlan.Location = new global::System.Drawing.Point(0, 0);
			this.hte_macVlan.Name = "hte_macVlan";
			this.hte_macVlan.Size = new global::System.Drawing.Size(228, 80);
			this.hte_macVlan.TabIndex = 0;
			this.bt_ok.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.bt_ok.Location = new global::System.Drawing.Point(77, 84);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.TabIndex = 3;
			this.bt_ok.Text = "OK";
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			base.AcceptButton = this.bt_ok;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(228, 113);
			base.ControlBox = false;
			base.Controls.Add(this.bt_ok);
			base.Controls.Add(this.hte_macVlan);
			base.MaximizeBox = false;
			base.Name = "DialogueMacVlan";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "DialogueMacVlan";
			base.TopMost = true;
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.DialogueMacVlan_Closing);
			base.ResumeLayout(false);
		}

		// Token: 0x04000282 RID: 642
		private global::Simulateur.MacVlanEdit hte_macVlan;

		// Token: 0x04000283 RID: 643
		private global::System.Windows.Forms.Button bt_ok;

		// Token: 0x04000284 RID: 644
		private global::System.ComponentModel.Container components = null;
	}
}
