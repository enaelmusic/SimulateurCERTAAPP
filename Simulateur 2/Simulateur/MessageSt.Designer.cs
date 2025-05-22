namespace Simulateur
{
	// Token: 0x02000067 RID: 103
	public partial class MessageSt : global::System.Windows.Forms.Form
	{
		// Token: 0x060005DC RID: 1500 RVA: 0x0003AED8 File Offset: 0x00039ED8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x0003AF04 File Offset: 0x00039F04
		private void InitializeComponent()
		{
			this.lbl_message = new global::System.Windows.Forms.Label();
			this.bt_ok = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.lbl_message.Location = new global::System.Drawing.Point(4, 0);
			this.lbl_message.Name = "lbl_message";
			this.lbl_message.Size = new global::System.Drawing.Size(180, 36);
			this.lbl_message.TabIndex = 9;
			this.lbl_message.Text = "Message";
			this.lbl_message.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.bt_ok.Location = new global::System.Drawing.Point(56, 40);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.TabIndex = 1;
			this.bt_ok.Text = "OK";
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			base.AcceptButton = this.bt_ok;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(186, 66);
			base.Controls.Add(this.bt_ok);
			base.Controls.Add(this.lbl_message);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "MessageSt";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Message";
			base.TopMost = true;
			base.ResumeLayout(false);
		}

		// Token: 0x040003EA RID: 1002
		private global::System.Windows.Forms.Label lbl_message;

		// Token: 0x040003EB RID: 1003
		private global::System.Windows.Forms.Button bt_ok;

		// Token: 0x040003EC RID: 1004
		private global::System.ComponentModel.IContainer components = null;
	}
}
