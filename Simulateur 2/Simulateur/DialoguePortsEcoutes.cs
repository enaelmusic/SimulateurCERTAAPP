using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000032 RID: 50
	public partial class DialoguePortsEcoutes : DialogueHashTable
	{
		// Token: 0x06000301 RID: 769 RVA: 0x000262F4 File Offset: 0x000252F4
		public DialoguePortsEcoutes()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000304 RID: 772 RVA: 0x000264A8 File Offset: 0x000254A8
		public DialoguePortsEcoutes(string titre, Trs_station p_trs)
		{
			this.trs = p_trs;
			base.Owner = Form.ActiveForm;
			this.InitializeComponent();
			base.Location = this.trs.St.posDialogueDemo();
			this.Text = titre;
			this.hte_portsEcoutes.init(this.trs, false);
			this.hte_portsEcoutes.DebutEdition += this.cacherOk;
			this.hte_portsEcoutes.FinEdition += this.montrerOk;
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00026538 File Offset: 0x00025538
		private void bt_ok_Click(object sender, EventArgs e)
		{
			if (!this.hte_portsEcoutes.Nochange())
			{
				this.trs.St.Reseau.BloquerBisIp();
				this.trs.St.Reseau.GereDoc.FaireAction(ActionDocument.modifier);
			}
			this.trs.PortsEcoutes = this.hte_portsEcoutes.GetTable();
			base.Close();
		}

		// Token: 0x06000306 RID: 774 RVA: 0x000265A0 File Offset: 0x000255A0
		private void cacherOk(object sender, EventArgs e)
		{
			this.bt_ok.Visible = false;
		}

		// Token: 0x06000307 RID: 775 RVA: 0x000265BC File Offset: 0x000255BC
		private void montrerOk(object sender, EventArgs e)
		{
			this.bt_ok.Visible = true;
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000308 RID: 776 RVA: 0x000265D8 File Offset: 0x000255D8
		public static int Largeur
		{
			get
			{
				return 228;
			}
		}

		// Token: 0x06000309 RID: 777 RVA: 0x000265EC File Offset: 0x000255EC
		private void DialoguePortsEcoutes_Closing(object sender, CancelEventArgs e)
		{
			this.trs.HauteurPortsEcoutes = base.Size.Height;
		}

		// Token: 0x0400028D RID: 653
		private Trs_station trs;
	}
}
