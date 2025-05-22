using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000035 RID: 53
	public partial class DialogueReqTrs : DialogueHashTable
	{
		// Token: 0x0600031D RID: 797 RVA: 0x00026C70 File Offset: 0x00025C70
		public DialogueReqTrs()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00026F7C File Offset: 0x00025F7C
		public DialogueReqTrs(string titre, Trs_station p_trs)
		{
			this.trs = p_trs;
			base.Owner = Form.ActiveForm;
			this.InitializeComponent();
			base.Location = this.trs.St.posDialogueDemo();
			this.Text = titre;
			this.hte_reqTrsEnvoyees.init(this.trs, this.trs.ReqTrsEnvoyees, true);
			this.hte_reqTrsRecues.init(this.trs, this.trs.ReqTrsRecues, true);
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00027008 File Offset: 0x00026008
		private void bt_ok_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0400029C RID: 668
		private Trs_station trs;
	}
}
