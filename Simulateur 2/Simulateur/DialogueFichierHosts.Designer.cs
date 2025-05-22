namespace Simulateur
{
	// Token: 0x0200002E RID: 46
	public partial class DialogueFichierHosts : global::Simulateur.DialogueHashTable
	{
		// Token: 0x060002DB RID: 731 RVA: 0x0002570C File Offset: 0x0002470C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00025738 File Offset: 0x00024738
		private void InitializeComponent()
		{
			this.hte_fichierHosts = new global::Simulateur.FichierHostsEdit();
			this.bt_ok = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.hte_fichierHosts.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.hte_fichierHosts.Location = new global::System.Drawing.Point(0, 0);
			this.hte_fichierHosts.Name = "hte_fichierHosts";
			this.hte_fichierHosts.Size = new global::System.Drawing.Size(316, 87);
			this.hte_fichierHosts.TabIndex = 0;
			this.bt_ok.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.bt_ok.Location = new global::System.Drawing.Point(121, 91);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.TabIndex = 3;
			this.bt_ok.Text = "OK";
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			base.AcceptButton = this.bt_ok;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(316, 120);
			base.ControlBox = false;
			base.Controls.Add(this.bt_ok);
			base.Controls.Add(this.hte_fichierHosts);
			base.Name = "DialogueFichierHosts";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.DialogueFichierHosts_Closing);
			base.ResumeLayout(false);
		}

		// Token: 0x0400027A RID: 634
		private global::System.Windows.Forms.Button bt_ok;

		// Token: 0x0400027B RID: 635
		private global::Simulateur.FichierHostsEdit hte_fichierHosts;

		// Token: 0x0400027C RID: 636
		private global::System.ComponentModel.IContainer components = null;
	}
}
