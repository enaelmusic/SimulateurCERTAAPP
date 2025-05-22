using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000098 RID: 152
	public partial class Trs_DialogueReponse : Dialogue
	{
		// Token: 0x060009C0 RID: 2496 RVA: 0x0005B6A8 File Offset: 0x0005A6A8
		public Trs_DialogueReponse()
		{
			this.InitializeComponent();
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x0005C1B0 File Offset: 0x0005B1B0
		public Trs_DialogueReponse(SuiteOk p_siOk, SuiteAnnuler p_siAnnuler, SortedList p_reqTrsRecues, Noeud p_n)
		{
			this.InitializeComponent();
			this.n = p_n;
			this.siOk = p_siOk;
			this.siAnnuler = p_siAnnuler;
			this.reqTrsRecues = p_reqTrsRecues;
			this.remplirListeRequetes();
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x0005C200 File Offset: 0x0005B200
		public void bt_ok_Click(object sender, EventArgs e)
		{
			string text = this.tb_protocole.Text;
			string text2 = this.tb_adrIp.Text.Trim();
			if (text2 == "")
			{
				text2 = "0.0.0.0";
			}
			string text3 = this.tb_numPort.Text.Trim();
			if (text3 == "")
			{
				text3 = "0";
			}
			string text4 = this.tb_ipServeur.Text.Trim();
			if (text4 == "")
			{
				text4 = "0.0.0.0";
			}
			string text5 = this.tb_numPortServeur.Text.Trim();
			if (text5 == "")
			{
				text5 = "0";
			}
			ArrayList arrayList = new ArrayList();
			arrayList.Add(text);
			arrayList.Add(text2);
			arrayList.Add(text3);
			arrayList.Add(text5);
			arrayList.Add(this.clef);
			arrayList.Add(this.lb_requetes.SelectedIndex);
			arrayList.Add(text4);
			if (this.n.Reseau.Pref.MemoriserPosDemo)
			{
				this.n.FixerPosition(base.Location.X, base.Location.Y);
			}
			base.Close();
			this.siOk(arrayList);
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x0005C35C File Offset: 0x0005B35C
		private void bt_annuler_Click(object sender, EventArgs e)
		{
			this.siAnnuler();
			base.Close();
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x0005C37C File Offset: 0x0005B37C
		public void BloquerSaisie()
		{
			this.lb_requetes.Enabled = false;
			this.bt_annuler.Enabled = false;
			this.bt_ok.Enabled = false;
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x0005C3B0 File Offset: 0x0005B3B0
		private void remplirListeRequetes()
		{
			this.lb_requetes.Items.Clear();
			foreach (object obj in this.reqTrsRecues.Values)
			{
				ArrayList arrayList = (ArrayList)obj;
				string text = (string)arrayList[0] + "       ";
				text = text + (string)arrayList[1] + "\t";
				string a = (string)arrayList[1];
				text = text + Ip_quartet.FormatFixe((string)arrayList[2]) + "\t";
				if (a == "ICMP")
				{
					text = text + "Id " + (string)arrayList[3] + "\t ";
				}
				else
				{
					text = text + (string)arrayList[3] + "\t ";
				}
				text = text + Ip_quartet.FormatFixe((string)arrayList[4]) + "\t   ";
				if (a == "ICMP")
				{
					text += "---";
				}
				else
				{
					text += (string)arrayList[5];
				}
				this.lb_requetes.Items.Add(text);
			}
			if (this.lb_requetes.Items.Count > 0)
			{
				this.lb_requetes.SelectedIndex = 0;
				this.bt_ok.Enabled = true;
				return;
			}
			this.bt_ok.Enabled = false;
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x0005C560 File Offset: 0x0005B560
		private void lb_requetes_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.lb_requetes.SelectedIndex == -1)
			{
				this.tb_adrIp.Text = "";
				this.tb_numPort.Text = "";
				this.tb_protocole.Text = "";
				this.lbl_numPort.Visible = false;
				this.tb_numPort.Visible = false;
				return;
			}
			this.clef = this.lb_requetes.SelectedItem.ToString().Substring(0, 2);
			ArrayList arrayList = (ArrayList)this.reqTrsRecues[this.clef];
			this.tb_protocole.Text = arrayList[1].ToString();
			this.tb_adrIp.Text = arrayList[2].ToString();
			this.tb_numPort.Text = arrayList[3].ToString();
			this.tb_ipServeur.Text = arrayList[4].ToString();
			this.tb_numPortServeur.Text = arrayList[5].ToString();
			if (this.tb_protocole.Text == "ICMP")
			{
				this.lbl_numPort.Text = "Id Icmp :";
			}
			else
			{
				this.lbl_numPort.Text = "N° de port :";
			}
			this.lbl_numPort.Visible = true;
			this.tb_numPort.Visible = true;
		}

		// Token: 0x170001AA RID: 426
		// (set) Token: 0x060009C9 RID: 2505 RVA: 0x0005C6BC File Offset: 0x0005B6BC
		public int IndexRequete
		{
			set
			{
				this.lb_requetes.SelectedIndex = value;
			}
		}

		// Token: 0x0400064C RID: 1612
		private Noeud n;

		// Token: 0x0400064D RID: 1613
		private SuiteOk siOk;

		// Token: 0x0400064E RID: 1614
		private SuiteAnnuler siAnnuler;

		// Token: 0x0400064F RID: 1615
		private SortedList reqTrsRecues;

		// Token: 0x04000650 RID: 1616
		private string clef = "";
	}
}
