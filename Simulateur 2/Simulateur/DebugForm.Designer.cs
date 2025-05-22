namespace Simulateur
{
	// Token: 0x0200001F RID: 31
	public partial class DebugForm : global::System.Windows.Forms.Form
	{
		// Token: 0x060001E1 RID: 481 RVA: 0x0001027C File Offset: 0x0000F27C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x000102A8 File Offset: 0x0000F2A8
		private void InitializeComponent()
		{
			this.tb_temoin = new global::System.Windows.Forms.TextBox();
			this.bt_fermer = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.tb_temoin.Location = new global::System.Drawing.Point(8, 8);
			this.tb_temoin.Multiline = true;
			this.tb_temoin.Name = "tb_temoin";
			this.tb_temoin.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.tb_temoin.Size = new global::System.Drawing.Size(232, 472);
			this.tb_temoin.TabIndex = 0;
			this.tb_temoin.Text = "";
			this.bt_fermer.Location = new global::System.Drawing.Point(56, 488);
			this.bt_fermer.Name = "bt_fermer";
			this.bt_fermer.Size = new global::System.Drawing.Size(88, 24);
			this.bt_fermer.TabIndex = 1;
			this.bt_fermer.Text = "fermer";
			this.bt_fermer.Click += new global::System.EventHandler(this.bt_fermer_Click);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(248, 517);
			base.ControlBox = false;
			base.Controls.AddRange(new global::System.Windows.Forms.Control[]
			{
				this.bt_fermer,
				this.tb_temoin
			});
			base.Name = "DebugForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "DebugForm";
			base.ResumeLayout(false);
		}

		// Token: 0x04000101 RID: 257
		public global::System.Windows.Forms.TextBox tb_temoin;

		// Token: 0x04000102 RID: 258
		private global::System.Windows.Forms.Button bt_fermer;

		// Token: 0x04000103 RID: 259
		private global::System.ComponentModel.Container components = null;
	}
}
