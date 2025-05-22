using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200002E RID: 46
	public partial class DialogueFichierHosts : DialogueHashTable
	{
		// Token: 0x060002D9 RID: 729 RVA: 0x0002565C File Offset: 0x0002465C
		public DialogueFichierHosts()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0002567C File Offset: 0x0002467C
		public DialogueFichierHosts(string titre, Ip_station p_ipSt)
		{
			base.Owner = Form.ActiveForm;
			this.InitializeComponent();
			this.ipSt = p_ipSt;
			base.Location = this.ipSt.St.posDialogueDemo();
			this.Text = titre;
			this.hte_fichierHosts.init(this.ipSt, false);
			this.hte_fichierHosts.DebutEdition += this.cacherOk;
			this.hte_fichierHosts.FinEdition += this.montrerOk;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00025898 File Offset: 0x00024898
		private void bt_ok_Click(object sender, EventArgs e)
		{
			this.ipSt.FichierHosts = this.hte_fichierHosts.GetTable();
			if (!this.hte_fichierHosts.Nochange())
			{
				this.ipSt.St.Reseau.BloquerBisIp();
				this.ipSt.St.Reseau.GereDoc.FaireAction(ActionDocument.modifier);
			}
			base.Close();
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00025900 File Offset: 0x00024900
		private void cacherOk(object sender, EventArgs e)
		{
			this.bt_ok.Visible = false;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0002591C File Offset: 0x0002491C
		private void montrerOk(object sender, EventArgs e)
		{
			this.bt_ok.Visible = true;
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x00025938 File Offset: 0x00024938
		public static int Largeur
		{
			get
			{
				return 324;
			}
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0002594C File Offset: 0x0002494C
		private void DialogueFichierHosts_Closing(object sender, CancelEventArgs e)
		{
			this.ipSt.HauteurFichierHosts = base.Size.Height;
		}

		// Token: 0x0400027D RID: 637
		private Ip_station ipSt;
	}
}
