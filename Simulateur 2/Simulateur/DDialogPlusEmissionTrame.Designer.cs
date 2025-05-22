namespace Simulateur
{
	// Token: 0x0200001D RID: 29
	public partial class DDialogPlusEmissionTrame : global::Simulateur.DDialogPlus
	{
		// Token: 0x060001D5 RID: 469 RVA: 0x0000F8A8 File Offset: 0x0000E8A8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0000F8D4 File Offset: 0x0000E8D4
		private void InitializeComponent()
		{
			base.SuspendLayout();
			this.tb_resultat.Visible = true;
			this.tb_phase.Visible = true;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(214, 39);
			base.Controls.AddRange(new global::System.Windows.Forms.Control[]
			{
				this.tb_resultat,
				this.tb_phase
			});
			base.Name = "DDialogPlusEmissionTrame";
			base.ResumeLayout(false);
		}

		// Token: 0x040000ED RID: 237
		private global::System.ComponentModel.IContainer components = null;
	}
}
