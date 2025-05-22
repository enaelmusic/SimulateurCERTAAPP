using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000031 RID: 49
	public partial class DialogueNatPat : DialogueHashTable
	{
		// Token: 0x060002F8 RID: 760 RVA: 0x00025FDC File Offset: 0x00024FDC
		public DialogueNatPat()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002FB RID: 763 RVA: 0x00026188 File Offset: 0x00025188
		public DialogueNatPat(string titre, Trs_station p_trs)
		{
			this.trs = p_trs;
			base.Owner = Form.ActiveForm;
			this.InitializeComponent();
			base.Location = this.trs.St.posDialogueDemo();
			this.Text = titre;
			this.hte_natPat.init(this.trs, false);
			this.hte_natPat.DebutEdition += this.cacherOk;
			this.hte_natPat.FinEdition += this.montrerOk;
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00026218 File Offset: 0x00025218
		private void bt_ok_Click(object sender, EventArgs e)
		{
			if (!this.hte_natPat.Nochange())
			{
				this.trs.St.Reseau.BloquerBisIp();
				this.trs.St.Reseau.GereDoc.FaireAction(ActionDocument.modifier);
			}
			this.trs.NatPat = this.hte_natPat.GetTable();
			base.Close();
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00026280 File Offset: 0x00025280
		private void cacherOk(object sender, EventArgs e)
		{
			this.bt_ok.Visible = false;
		}

		// Token: 0x060002FE RID: 766 RVA: 0x0002629C File Offset: 0x0002529C
		private void montrerOk(object sender, EventArgs e)
		{
			this.bt_ok.Visible = true;
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060002FF RID: 767 RVA: 0x000262B8 File Offset: 0x000252B8
		public static int Largeur
		{
			get
			{
				return 476;
			}
		}

		// Token: 0x06000300 RID: 768 RVA: 0x000262CC File Offset: 0x000252CC
		private void DialogueNatPat_Closing(object sender, CancelEventArgs e)
		{
			this.trs.HauteurNatPat = base.Size.Height;
		}

		// Token: 0x04000289 RID: 649
		private Trs_station trs;
	}
}
