using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200002D RID: 45
	public partial class DialogueCacheArp : DialogueHashTable
	{
		// Token: 0x060002CD RID: 717 RVA: 0x000252F4 File Offset: 0x000242F4
		public DialogueCacheArp()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00025314 File Offset: 0x00024314
		public DialogueCacheArp(string titre, Ip_station ips)
		{
			base.Owner = Form.ActiveForm;
			this.InitializeComponent();
			base.Location = ips.St.posDialogueDemo();
			this.Text = titre;
			this.hte_cacheArp.init(ips, false);
			this.ip = ips;
			this.hte_cacheArp.DebutEdition += this.cacherOk;
			this.hte_cacheArp.FinEdition += this.montrerOk;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0002553C File Offset: 0x0002453C
		protected override HashTableEdit getHashTableEdit()
		{
			return this.hte_cacheArp;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00025550 File Offset: 0x00024550
		private void bt_ok_Click(object sender, EventArgs e)
		{
			if (!this.hte_cacheArp.Nochange())
			{
				this.ip.St.Reseau.GereDoc.FaireAction(ActionDocument.modifier);
				this.ip.St.Reseau.BloquerBisIp();
			}
			this.ip.CacheArp = this.hte_cacheArp.GetTable();
			base.Close();
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x000255B8 File Offset: 0x000245B8
		private void cacherOk(object sender, EventArgs e)
		{
			this.bt_ok.Visible = false;
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x000255D4 File Offset: 0x000245D4
		private void montrerOk(object sender, EventArgs e)
		{
			this.bt_ok.Visible = true;
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x000255F0 File Offset: 0x000245F0
		private void DialogueCacheArp_Activated(object sender, EventArgs e)
		{
			this.hte_cacheArp.MacAttenteOn();
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00025608 File Offset: 0x00024608
		private void DialogueCacheArp_Closed(object sender, EventArgs e)
		{
			this.hte_cacheArp.MacAttenteOff();
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060002D7 RID: 727 RVA: 0x00025620 File Offset: 0x00024620
		public static int Largeur
		{
			get
			{
				return 344;
			}
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00025634 File Offset: 0x00024634
		private void DialogueCacheArp_Closing(object sender, CancelEventArgs e)
		{
			this.ip.HauteurCacheArp = base.Size.Height;
		}

		// Token: 0x04000279 RID: 633
		private Ip_station ip;
	}
}
