using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000067 RID: 103
	public partial class MessageSt : Form
	{
		// Token: 0x060005DA RID: 1498 RVA: 0x0003ADBC File Offset: 0x00039DBC
		public MessageSt(Station p_st)
		{
			this.InitializeComponent();
			this.st = p_st;
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x0003ADE4 File Offset: 0x00039DE4
		public void ShowDialog(string message, string couche)
		{
			if (this.st.Demo != null)
			{
				this.st.Demo.Close();
			}
			base.Location = this.st.posDialogueDemo();
			if (couche != null)
			{
				string text = string.IsInterned(couche);
				if (text == "ip")
				{
					this.Text = this.st.NomNoeud + " : " + this.st.Ip.GetEtat();
					goto IL_CB;
				}
				if (text == "trs")
				{
					this.Text = this.st.NomNoeud + " : envoi " + this.st.Trs.SegmentEnCours.Protocole.ToString();
					goto IL_CB;
				}
			}
			this.Text = couche;
			IL_CB:
			this.lbl_message.Text = message;
			Dialogue.InScreen(this);
			base.ShowDialog();
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x0003B078 File Offset: 0x0003A078
		private void bt_ok_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x040003ED RID: 1005
		private Station st;
	}
}
