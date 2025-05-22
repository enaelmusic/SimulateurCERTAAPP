using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000005 RID: 5
	public partial class APropos : Form
	{
		// Token: 0x06000046 RID: 70 RVA: 0x0000305C File Offset: 0x0000205C
		public APropos()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003AB0 File Offset: 0x00002AB0
		private void bt_fermer_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}
