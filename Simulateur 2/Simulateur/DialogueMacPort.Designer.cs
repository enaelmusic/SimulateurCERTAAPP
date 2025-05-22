namespace Simulateur
{
	// Token: 0x0200002F RID: 47
	public partial class DialogueMacPort : global::Simulateur.DialogueHashTable
	{
		// Token: 0x060002E4 RID: 740 RVA: 0x00025A14 File Offset: 0x00024A14
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00025A40 File Offset: 0x00024A40
		private void InitializeComponent()
		{
			this.bt_ok = new global::System.Windows.Forms.Button();
			this.hte_macPort = new global::Simulateur.MacPortEdit();
			base.SuspendLayout();
			this.bt_ok.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.bt_ok.Location = new global::System.Drawing.Point(83, 91);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.TabIndex = 1;
			this.bt_ok.Text = "OK";
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			this.hte_macPort.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.hte_macPort.Location = new global::System.Drawing.Point(0, 0);
			this.hte_macPort.Name = "hte_macPort";
			this.hte_macPort.Size = new global::System.Drawing.Size(240, 87);
			this.hte_macPort.TabIndex = 2;
			base.AcceptButton = this.bt_ok;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(240, 120);
			base.ControlBox = false;
			base.Controls.Add(this.hte_macPort);
			base.Controls.Add(this.bt_ok);
			base.MaximizeBox = false;
			base.Name = "DialogueMacPort";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "DialogueMacPort";
			base.TopMost = true;
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.DialogueMacPort_Closing);
			base.Closed += new global::System.EventHandler(this.DialogueMacPort_Closed);
			base.Activated += new global::System.EventHandler(this.DialogueMacPort_Activated);
			base.ResumeLayout(false);
		}

		// Token: 0x0400027E RID: 638
		private global::System.Windows.Forms.Button bt_ok;

		// Token: 0x0400027F RID: 639
		private global::Simulateur.MacPortEdit hte_macPort;

		// Token: 0x04000280 RID: 640
		private global::System.ComponentModel.Container components = null;
	}
}
