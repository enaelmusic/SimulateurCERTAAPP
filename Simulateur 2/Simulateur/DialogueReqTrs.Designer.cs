namespace Simulateur
{
	// Token: 0x02000035 RID: 53
	public partial class DialogueReqTrs : global::Simulateur.DialogueHashTable
	{
		// Token: 0x0600031E RID: 798 RVA: 0x00026C90 File Offset: 0x00025C90
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00026CBC File Offset: 0x00025CBC
		private void InitializeComponent()
		{
			this.bt_ok = new global::System.Windows.Forms.Button();
			this.hte_reqTrsEnvoyees = new global::Simulateur.ReqTrsEdit();
			this.hte_reqTrsRecues = new global::Simulateur.ReqTrsEdit();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.bt_ok.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.bt_ok.Location = new global::System.Drawing.Point(163, 212);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.TabIndex = 2;
			this.bt_ok.Text = "OK";
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			this.hte_reqTrsEnvoyees.Location = new global::System.Drawing.Point(8, 24);
			this.hte_reqTrsEnvoyees.Name = "hte_reqTrsEnvoyees";
			this.hte_reqTrsEnvoyees.Size = new global::System.Drawing.Size(404, 80);
			this.hte_reqTrsEnvoyees.TabIndex = 3;
			this.hte_reqTrsRecues.Location = new global::System.Drawing.Point(8, 128);
			this.hte_reqTrsRecues.Name = "hte_reqTrsRecues";
			this.hte_reqTrsRecues.Size = new global::System.Drawing.Size(404, 80);
			this.hte_reqTrsRecues.TabIndex = 4;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(8, 4);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(112, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Requêtes envoyées";
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(8, 108);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(112, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Requêtes reçues";
			base.AcceptButton = this.bt_ok;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(400, 241);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.hte_reqTrsRecues);
			base.Controls.Add(this.hte_reqTrsEnvoyees);
			base.Controls.Add(this.bt_ok);
			base.Name = "DialogueReqTrs";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			base.ResumeLayout(false);
		}

		// Token: 0x04000296 RID: 662
		private global::System.Windows.Forms.Button bt_ok;

		// Token: 0x04000297 RID: 663
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000298 RID: 664
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000299 RID: 665
		private global::Simulateur.ReqTrsEdit hte_reqTrsEnvoyees;

		// Token: 0x0400029A RID: 666
		private global::Simulateur.ReqTrsEdit hte_reqTrsRecues;

		// Token: 0x0400029B RID: 667
		private global::System.ComponentModel.IContainer components = null;
	}
}
