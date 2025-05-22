namespace Simulateur
{
	// Token: 0x02000034 RID: 52
	public partial class DialogueReglesFiltrage : global::Simulateur.DialogueHashTable
	{
		// Token: 0x06000315 RID: 789 RVA: 0x00026968 File Offset: 0x00025968
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00026994 File Offset: 0x00025994
		private void InitializeComponent()
		{
			this.bt_ok = new global::System.Windows.Forms.Button();
			this.hte_reglesFiltrage = new global::Simulateur.ReglesFiltrageEdit();
			base.SuspendLayout();
			this.bt_ok.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.bt_ok.Location = new global::System.Drawing.Point(253, 84);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.TabIndex = 2;
			this.bt_ok.Text = "OK";
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			this.hte_reglesFiltrage.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.hte_reglesFiltrage.Location = new global::System.Drawing.Point(0, 0);
			this.hte_reglesFiltrage.Name = "hte_reglesFiltrage";
			this.hte_reglesFiltrage.Size = new global::System.Drawing.Size(580, 80);
			this.hte_reglesFiltrage.TabIndex = 3;
			base.AcceptButton = this.bt_ok;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(580, 113);
			base.Controls.Add(this.hte_reglesFiltrage);
			base.Controls.Add(this.bt_ok);
			base.Name = "DialogueReglesFiltrage";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			base.ResumeLayout(false);
		}

		// Token: 0x04000292 RID: 658
		private global::System.Windows.Forms.Button bt_ok;

		// Token: 0x04000293 RID: 659
		private global::Simulateur.ReglesFiltrageEdit hte_reglesFiltrage;

		// Token: 0x04000294 RID: 660
		private global::System.ComponentModel.IContainer components = null;
	}
}
