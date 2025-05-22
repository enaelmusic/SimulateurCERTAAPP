namespace Simulateur
{
	// Token: 0x0200002D RID: 45
	public partial class DialogueCacheArp : global::Simulateur.DialogueHashTable
	{
		// Token: 0x060002CF RID: 719 RVA: 0x0002539C File Offset: 0x0002439C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x000253C8 File Offset: 0x000243C8
		private void InitializeComponent()
		{
			this.bt_ok = new global::System.Windows.Forms.Button();
			this.hte_cacheArp = new global::Simulateur.CacheArpEdit();
			base.SuspendLayout();
			this.bt_ok.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.bt_ok.Location = new global::System.Drawing.Point(134, 84);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.TabIndex = 1;
			this.bt_ok.Text = "OK";
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			this.hte_cacheArp.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.hte_cacheArp.Location = new global::System.Drawing.Point(0, 0);
			this.hte_cacheArp.Name = "hte_cacheArp";
			this.hte_cacheArp.Size = new global::System.Drawing.Size(336, 80);
			this.hte_cacheArp.TabIndex = 2;
			base.AcceptButton = this.bt_ok;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			base.ClientSize = new global::System.Drawing.Size(336, 120);
			base.ControlBox = false;
			base.Controls.Add(this.hte_cacheArp);
			base.Controls.Add(this.bt_ok);
			base.Name = "DialogueCacheArp";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "DialogueCacheArp";
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.DialogueCacheArp_Closing);
			base.ResumeLayout(false);
		}

		// Token: 0x04000276 RID: 630
		private global::System.Windows.Forms.Button bt_ok;

		// Token: 0x04000277 RID: 631
		private global::Simulateur.CacheArpEdit hte_cacheArp;

		// Token: 0x04000278 RID: 632
		private global::System.ComponentModel.Container components = null;
	}
}
