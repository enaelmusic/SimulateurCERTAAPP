namespace Simulateur
{
	// Token: 0x02000036 RID: 54
	public partial class DialogueRoute : global::Simulateur.DialogueHashTable
	{
		// Token: 0x06000323 RID: 803 RVA: 0x0002703C File Offset: 0x0002603C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00027068 File Offset: 0x00026068
		private void InitializeComponent()
		{
			this.bt_ok = new global::System.Windows.Forms.Button();
			this.hte_route = new global::Simulateur.RouteEdit();
			base.SuspendLayout();
			this.bt_ok.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.bt_ok.Location = new global::System.Drawing.Point(207, 84);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.TabIndex = 2;
			this.bt_ok.Text = "OK";
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			this.hte_route.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.hte_route.Location = new global::System.Drawing.Point(0, 0);
			this.hte_route.Name = "hte_route";
			this.hte_route.Size = new global::System.Drawing.Size(488, 80);
			this.hte_route.TabIndex = 3;
			base.AcceptButton = this.bt_ok;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(488, 113);
			base.ControlBox = false;
			base.Controls.Add(this.hte_route);
			base.Controls.Add(this.bt_ok);
			base.Name = "DialogueRoute";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Table de routage";
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.DialogueRoute_Closing);
			base.ResumeLayout(false);
		}

		// Token: 0x0400029D RID: 669
		private global::System.Windows.Forms.Button bt_ok;

		// Token: 0x0400029E RID: 670
		private global::Simulateur.RouteEdit hte_route;

		// Token: 0x0400029F RID: 671
		private global::System.ComponentModel.IContainer components = null;
	}
}
