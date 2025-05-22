using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000033 RID: 51
	public partial class DialoguePortVlan : DialogueHashTable
	{
		// Token: 0x0600030A RID: 778 RVA: 0x00026614 File Offset: 0x00025614
		public DialoguePortVlan()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00026634 File Offset: 0x00025634
		public DialoguePortVlan(string titre, Switch s)
		{
			base.Owner = Form.ActiveForm;
			this.InitializeComponent();
			base.Location = s.posDialogueDemo();
			this.Text = titre;
			if (s.NiveauVlan == 1)
			{
				this.hte_portVlan.init(s, false);
			}
			else
			{
				this.hte_portVlan.init(s, true);
			}
			this.sw = s;
			this.hte_portVlan.DebutEdition += this.cacherOk;
			this.hte_portVlan.FinEdition += this.montrerOk;
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00026870 File Offset: 0x00025870
		protected override HashTableEdit getHashTableEdit()
		{
			return this.hte_portVlan;
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00026884 File Offset: 0x00025884
		private void bt_ok_Click(object sender, EventArgs e)
		{
			this.sw.PortVlanNiv1 = this.hte_portVlan.GetTable();
			if (!this.hte_portVlan.Nochange())
			{
				this.sw.Reseau.GereDoc.FaireAction(ActionDocument.modifier);
			}
			base.Close();
		}

		// Token: 0x06000310 RID: 784 RVA: 0x000268D4 File Offset: 0x000258D4
		private void cacherOk(object sender, EventArgs e)
		{
			this.bt_ok.Visible = false;
		}

		// Token: 0x06000311 RID: 785 RVA: 0x000268F0 File Offset: 0x000258F0
		private void montrerOk(object sender, EventArgs e)
		{
			this.bt_ok.Visible = true;
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000312 RID: 786 RVA: 0x0002690C File Offset: 0x0002590C
		public static int Largeur
		{
			get
			{
				return 248;
			}
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00026920 File Offset: 0x00025920
		private void DialoguePortVlan_Closing(object sender, CancelEventArgs e)
		{
			this.sw.HauteurTablePortVlan = base.Size.Height;
		}

		// Token: 0x04000291 RID: 657
		private Switch sw;
	}
}
