namespace Simulateur
{
	// Token: 0x02000015 RID: 21
	public partial class ConfigCarte : global::Simulateur.Dialogue
	{
		// Token: 0x0600017B RID: 379 RVA: 0x0000C494 File Offset: 0x0000B494
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000C4C0 File Offset: 0x0000B4C0
		private void InitializeComponent()
		{
			this.tb_adresseMac = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.bt_annuler.Location = new global::System.Drawing.Point(32, 104);
			this.bt_annuler.Name = "bt_annuler";
			this.bt_ok.Location = new global::System.Drawing.Point(120, 104);
			this.bt_ok.Name = "bt_ok";
			this.tb_adresseMac.Enabled = false;
			this.tb_adresseMac.Location = new global::System.Drawing.Point(32, 56);
			this.tb_adresseMac.Name = "tb_adresseMac";
			this.tb_adresseMac.ReadOnly = true;
			this.tb_adresseMac.Size = new global::System.Drawing.Size(136, 20);
			this.tb_adresseMac.TabIndex = 10;
			this.tb_adresseMac.Text = "";
			this.label1.Location = new global::System.Drawing.Point(32, 32);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(112, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "Adresse MAC :";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(242, 159);
			base.Controls.Add(this.tb_adresseMac);
			base.Controls.Add(this.label1);
			base.Name = "ConfigCarte";
			this.Text = "Configuration d'une carte réseau";
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.tb_adresseMac, 0);
			base.Controls.SetChildIndex(this.bt_ok, 0);
			base.Controls.SetChildIndex(this.bt_annuler, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x040000B8 RID: 184
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000B9 RID: 185
		private global::System.Windows.Forms.TextBox tb_adresseMac;

		// Token: 0x040000BA RID: 186
		private global::System.ComponentModel.IContainer components = null;
	}
}
