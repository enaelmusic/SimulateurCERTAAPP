using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000030 RID: 48
	public partial class DialogueMacVlan : DialogueHashTable
	{
		// Token: 0x060002EE RID: 750 RVA: 0x00025CC0 File Offset: 0x00024CC0
		public DialogueMacVlan()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00025CE0 File Offset: 0x00024CE0
		public DialogueMacVlan(string titre, Switch s)
		{
			base.Owner = Form.ActiveForm;
			this.InitializeComponent();
			base.Location = s.posDialogueDemo();
			this.Text = titre;
			this.hte_macVlan.init(s, false);
			this.sw = s;
			this.hte_macVlan.DebutEdition += this.cacherOk;
			this.hte_macVlan.FinEdition += this.montrerOk;
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00025F04 File Offset: 0x00024F04
		protected override HashTableEdit getHashTableEdit()
		{
			return this.hte_macVlan;
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x00025F18 File Offset: 0x00024F18
		private void bt_ok_Click(object sender, EventArgs e)
		{
			this.sw.MacVlanNiv2 = this.hte_macVlan.GetTable();
			if (!this.hte_macVlan.Nochange())
			{
				this.sw.Reseau.GereDoc.FaireAction(ActionDocument.modifier);
			}
			base.Close();
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x00025F68 File Offset: 0x00024F68
		private void cacherOk(object sender, EventArgs e)
		{
			this.bt_ok.Visible = false;
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00025F84 File Offset: 0x00024F84
		private void montrerOk(object sender, EventArgs e)
		{
			this.bt_ok.Visible = true;
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x00025FA0 File Offset: 0x00024FA0
		public static int Largeur
		{
			get
			{
				return 236;
			}
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00025FB4 File Offset: 0x00024FB4
		private void DialogueMacVlan_Closing(object sender, CancelEventArgs e)
		{
			this.sw.HauteurTableMacVlan = base.Size.Height;
		}

		// Token: 0x04000285 RID: 645
		private Switch sw;
	}
}
