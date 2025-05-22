namespace Simulateur
{
	// Token: 0x0200001C RID: 28
	public partial class DDialogPlus : global::System.Windows.Forms.Form
	{
		// Token: 0x060001C6 RID: 454 RVA: 0x0000F418 File Offset: 0x0000E418
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0000F444 File Offset: 0x0000E444
		private void InitializeComponent()
		{
			this.tb_resultat = new global::System.Windows.Forms.TextBox();
			this.tb_phase = new global::System.Windows.Forms.TextBox();
			base.SuspendLayout();
			this.tb_resultat.BackColor = global::System.Drawing.SystemColors.Window;
			this.tb_resultat.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tb_resultat.ForeColor = global::System.Drawing.Color.Black;
			this.tb_resultat.Location = new global::System.Drawing.Point(0, 20);
			this.tb_resultat.Name = "tb_resultat";
			this.tb_resultat.ReadOnly = true;
			this.tb_resultat.Size = new global::System.Drawing.Size(214, 20);
			this.tb_resultat.TabIndex = 24;
			this.tb_resultat.TabStop = false;
			this.tb_resultat.Text = "";
			this.tb_phase.Name = "tb_phase";
			this.tb_phase.ReadOnly = true;
			this.tb_phase.Size = new global::System.Drawing.Size(214, 20);
			this.tb_phase.TabIndex = 23;
			this.tb_phase.TabStop = false;
			this.tb_phase.Text = "";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(214, 39);
			base.ControlBox = false;
			base.Controls.AddRange(new global::System.Windows.Forms.Control[]
			{
				this.tb_resultat,
				this.tb_phase
			});
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.Name = "DDialogPlus";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "DDialogPlus";
			base.Closed += new global::System.EventHandler(this.DDialogPlus_Closed);
			base.ResumeLayout(false);
		}

		// Token: 0x040000E4 RID: 228
		protected global::System.Windows.Forms.TextBox tb_resultat;

		// Token: 0x040000E5 RID: 229
		protected global::System.Windows.Forms.TextBox tb_phase;

		// Token: 0x040000E6 RID: 230
		private global::System.ComponentModel.Container components = null;
	}
}
