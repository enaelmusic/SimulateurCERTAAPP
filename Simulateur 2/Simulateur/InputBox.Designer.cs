namespace Simulateur
{
	// Token: 0x02000052 RID: 82
	public partial class InputBox : global::System.Windows.Forms.Form
	{
		// Token: 0x0600045F RID: 1119 RVA: 0x0002F2F8 File Offset: 0x0002E2F8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x0002F324 File Offset: 0x0002E324
		private void InitializeComponent()
		{
			this.lb_question = new global::System.Windows.Forms.Label();
			this.tb_reponse = new global::System.Windows.Forms.TextBox();
			this.bt_annuler = new global::System.Windows.Forms.Button();
			this.bt_ok = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.lb_question.Location = new global::System.Drawing.Point(16, 16);
			this.lb_question.Name = "lb_question";
			this.lb_question.Size = new global::System.Drawing.Size(200, 16);
			this.lb_question.TabIndex = 0;
			this.lb_question.Text = "lb_question";
			this.tb_reponse.Location = new global::System.Drawing.Point(16, 40);
			this.tb_reponse.Name = "tb_reponse";
			this.tb_reponse.Size = new global::System.Drawing.Size(208, 20);
			this.tb_reponse.TabIndex = 1;
			this.tb_reponse.Text = "";
			this.bt_annuler.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.bt_annuler.Location = new global::System.Drawing.Point(32, 80);
			this.bt_annuler.Name = "bt_annuler";
			this.bt_annuler.TabIndex = 2;
			this.bt_annuler.Text = "annuler";
			this.bt_ok.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.bt_ok.Location = new global::System.Drawing.Point(120, 80);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.TabIndex = 3;
			this.bt_ok.Text = "OK";
			base.AcceptButton = this.bt_ok;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.bt_annuler;
			base.ClientSize = new global::System.Drawing.Size(240, 117);
			base.ControlBox = false;
			base.Controls.AddRange(new global::System.Windows.Forms.Control[]
			{
				this.bt_ok,
				this.bt_annuler,
				this.tb_reponse,
				this.lb_question
			});
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.Name = "InputBox";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "InputBox";
			base.ResumeLayout(false);
		}

		// Token: 0x0400032F RID: 815
		private global::System.Windows.Forms.Label lb_question;

		// Token: 0x04000330 RID: 816
		private global::System.Windows.Forms.TextBox tb_reponse;

		// Token: 0x04000331 RID: 817
		private global::System.Windows.Forms.Button bt_annuler;

		// Token: 0x04000332 RID: 818
		private global::System.Windows.Forms.Button bt_ok;

		// Token: 0x04000333 RID: 819
		private global::System.ComponentModel.Container components = null;
	}
}
