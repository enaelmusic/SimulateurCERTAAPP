using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200001F RID: 31
	public partial class DebugForm : Form
	{
		// Token: 0x060001E0 RID: 480 RVA: 0x0001024C File Offset: 0x0000F24C
		public DebugForm()
		{
			this.InitializeComponent();
			this.tb_temoin.Text = "";
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00010424 File Offset: 0x0000F424
		public void Afficher(string s)
		{
			if (!base.Visible)
			{
				base.Show();
			}
			this.tb_temoin.AppendText(s + Environment.NewLine);
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00010458 File Offset: 0x0000F458
		public void Clear()
		{
			this.tb_temoin.Text = "";
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00010478 File Offset: 0x0000F478
		private void bt_fermer_Click(object sender, EventArgs e)
		{
			this.tb_temoin.Text = "";
			base.Hide();
		}
	}
}
