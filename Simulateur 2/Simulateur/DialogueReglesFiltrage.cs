using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000034 RID: 52
	public partial class DialogueReglesFiltrage : DialogueHashTable
	{
		// Token: 0x06000314 RID: 788 RVA: 0x00026948 File Offset: 0x00025948
		public DialogueReglesFiltrage()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00026ADC File Offset: 0x00025ADC
		public DialogueReglesFiltrage(string titre, Trs_station p_trs)
		{
			this.trs = p_trs;
			base.Owner = Form.ActiveForm;
			this.InitializeComponent();
			base.Location = this.trs.St.posDialogueDemo();
			this.Text = titre;
			this.hte_reglesFiltrage.init(this.trs, false);
			this.hte_reglesFiltrage.DebutEdition += this.cacherOk;
			this.hte_reglesFiltrage.FinEdition += this.montrerOk;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00026B6C File Offset: 0x00025B6C
		private void bt_ok_Click(object sender, EventArgs e)
		{
			if (!this.hte_reglesFiltrage.Nochange())
			{
				this.trs.St.Reseau.BloquerBisIp();
				this.trs.St.Reseau.GereDoc.FaireAction(ActionDocument.modifier);
				this.trs.ReglesFiltrage = this.hte_reglesFiltrage.GetTable();
				this.trs.St.SetContenuInfoBulle();
			}
			else
			{
				this.trs.ReglesFiltrage = this.hte_reglesFiltrage.GetTable();
			}
			base.Close();
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00026BFC File Offset: 0x00025BFC
		private void cacherOk(object sender, EventArgs e)
		{
			this.bt_ok.Visible = false;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00026C18 File Offset: 0x00025C18
		private void montrerOk(object sender, EventArgs e)
		{
			this.bt_ok.Visible = true;
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600031B RID: 795 RVA: 0x00026C34 File Offset: 0x00025C34
		public static int Largeur
		{
			get
			{
				return 588;
			}
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00026C48 File Offset: 0x00025C48
		private void DialogueNatPat_Closing(object sender, CancelEventArgs e)
		{
			this.trs.HauteurReglesFiltrage = base.Size.Height;
		}

		// Token: 0x04000295 RID: 661
		private Trs_station trs;
	}
}
