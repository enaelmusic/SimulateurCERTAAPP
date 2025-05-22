namespace Simulateur
{
	// Token: 0x02000013 RID: 19
	public partial class Dialogue : global::System.Windows.Forms.Form
	{
		// Token: 0x0600016E RID: 366 RVA: 0x0000BC5C File Offset: 0x0000AC5C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000BC88 File Offset: 0x0000AC88
		private void InitializeComponent()
		{
			this.bt_annuler = new global::System.Windows.Forms.Button();
			this.bt_ok = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.bt_annuler.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.bt_annuler.Location = new global::System.Drawing.Point(64, 208);
			this.bt_annuler.Name = "bt_annuler";
			this.bt_annuler.Size = new global::System.Drawing.Size(64, 23);
			this.bt_annuler.TabIndex = 8;
			this.bt_annuler.Text = "annuler";
			this.bt_ok.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.bt_ok.Location = new global::System.Drawing.Point(152, 208);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.Size = new global::System.Drawing.Size(64, 23);
			this.bt_ok.TabIndex = 7;
			this.bt_ok.Text = "OK";
			base.AcceptButton = this.bt_ok;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.bt_annuler;
			base.ClientSize = new global::System.Drawing.Size(292, 255);
			base.ControlBox = false;
			base.Controls.AddRange(new global::System.Windows.Forms.Control[]
			{
				this.bt_annuler,
				this.bt_ok
			});
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.Name = "Dialogue";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Dialogue";
			base.ResumeLayout(false);
		}

		// Token: 0x040000AD RID: 173
		protected global::System.Windows.Forms.Button bt_annuler;

		// Token: 0x040000AE RID: 174
		protected global::System.Windows.Forms.Button bt_ok;

		// Token: 0x040000AF RID: 175
		private global::System.ComponentModel.Container components = null;
	}
}
