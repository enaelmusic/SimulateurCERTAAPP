namespace Simulateur
{
	// Token: 0x02000031 RID: 49
	public partial class DialogueNatPat : global::Simulateur.DialogueHashTable
	{
		// Token: 0x060002F9 RID: 761 RVA: 0x00025FFC File Offset: 0x00024FFC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00026028 File Offset: 0x00025028
		private void InitializeComponent()
		{
			this.hte_natPat = new global::Simulateur.NatPatEdit();
			this.bt_ok = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.hte_natPat.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.hte_natPat.Location = new global::System.Drawing.Point(0, 0);
			this.hte_natPat.Name = "hte_natPat";
			this.hte_natPat.Size = new global::System.Drawing.Size(468, 80);
			this.hte_natPat.TabIndex = 0;
			this.bt_ok.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.bt_ok.Location = new global::System.Drawing.Point(197, 91);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.TabIndex = 4;
			this.bt_ok.Text = "OK";
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			base.AcceptButton = this.bt_ok;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(468, 120);
			base.ControlBox = false;
			base.Controls.Add(this.bt_ok);
			base.Controls.Add(this.hte_natPat);
			base.Name = "DialogueNatPat";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.DialogueNatPat_Closing);
			base.ResumeLayout(false);
		}

		// Token: 0x04000286 RID: 646
		private global::System.Windows.Forms.Button bt_ok;

		// Token: 0x04000287 RID: 647
		private global::Simulateur.NatPatEdit hte_natPat;

		// Token: 0x04000288 RID: 648
		private global::System.ComponentModel.IContainer components = null;
	}
}
