using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200002F RID: 47
	public partial class DialogueMacPort : DialogueHashTable
	{
		// Token: 0x060002E2 RID: 738 RVA: 0x00025974 File Offset: 0x00024974
		public DialogueMacPort()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00025994 File Offset: 0x00024994
		public DialogueMacPort(string titre, Switch s)
		{
			base.Owner = Form.ActiveForm;
			this.InitializeComponent();
			base.Location = s.posDialogueDemo();
			this.Text = titre;
			this.hte_macPort.init(s, false);
			this.sw = s;
			this.hte_macPort.DebutEdition += this.cacherOk;
			this.hte_macPort.FinEdition += this.montrerOk;
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x00025BDC File Offset: 0x00024BDC
		protected override HashTableEdit getHashTableEdit()
		{
			return this.hte_macPort;
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00025BF0 File Offset: 0x00024BF0
		private void bt_ok_Click(object sender, EventArgs e)
		{
			this.sw.PortAdresseMac = this.hte_macPort.GetTable();
			base.Close();
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00025C1C File Offset: 0x00024C1C
		private void cacherOk(object sender, EventArgs e)
		{
			this.bt_ok.Visible = false;
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00025C38 File Offset: 0x00024C38
		private void montrerOk(object sender, EventArgs e)
		{
			this.bt_ok.Visible = true;
		}

		// Token: 0x060002EA RID: 746 RVA: 0x00025C54 File Offset: 0x00024C54
		private void DialogueMacPort_Activated(object sender, EventArgs e)
		{
			this.hte_macPort.MacAttenteOn();
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00025C6C File Offset: 0x00024C6C
		private void DialogueMacPort_Closed(object sender, EventArgs e)
		{
			this.hte_macPort.MacAttenteOff();
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060002EC RID: 748 RVA: 0x00025C84 File Offset: 0x00024C84
		public static int Largeur
		{
			get
			{
				return 248;
			}
		}

		// Token: 0x060002ED RID: 749 RVA: 0x00025C98 File Offset: 0x00024C98
		private void DialogueMacPort_Closing(object sender, CancelEventArgs e)
		{
			this.sw.HauteurTableMacPort = base.Size.Height;
		}

		// Token: 0x04000281 RID: 641
		private Switch sw;
	}
}
