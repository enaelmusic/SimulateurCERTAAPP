using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000036 RID: 54
	public partial class DialogueRoute : DialogueHashTable
	{
		// Token: 0x06000322 RID: 802 RVA: 0x0002701C File Offset: 0x0002601C
		public DialogueRoute()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000325 RID: 805 RVA: 0x000271D4 File Offset: 0x000261D4
		public DialogueRoute(string titre, Ip_station p_ip)
		{
			this.ip = p_ip;
			base.Owner = Form.ActiveForm;
			this.InitializeComponent();
			base.Location = this.ip.St.posDialogueDemo();
			this.Text = titre;
			this.hte_route.init(this.ip, false, true);
			this.hte_route.DebutEdition += this.cacherOk;
			this.hte_route.FinEdition += this.montrerOk;
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00027264 File Offset: 0x00026264
		private void bt_ok_Click(object sender, EventArgs e)
		{
			if (!this.hte_route.Nochange())
			{
				this.ip.St.Reseau.BloquerBisIp();
				this.ip.St.Reseau.GereDoc.FaireAction(ActionDocument.modifier);
			}
			this.ip.Routes = this.hte_route.GetTable();
			base.Close();
		}

		// Token: 0x06000327 RID: 807 RVA: 0x000272CC File Offset: 0x000262CC
		private void cacherOk(object sender, EventArgs e)
		{
			this.bt_ok.Visible = false;
		}

		// Token: 0x06000328 RID: 808 RVA: 0x000272E8 File Offset: 0x000262E8
		private void montrerOk(object sender, EventArgs e)
		{
			this.bt_ok.Visible = true;
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000329 RID: 809 RVA: 0x00027304 File Offset: 0x00026304
		public static int Largeur
		{
			get
			{
				return 496;
			}
		}

		// Token: 0x0600032A RID: 810 RVA: 0x00027318 File Offset: 0x00026318
		private void DialogueRoute_Closing(object sender, CancelEventArgs e)
		{
			this.ip.HauteurTableRoutage = base.Size.Height;
		}

		// Token: 0x040002A0 RID: 672
		private Ip_station ip;
	}
}
