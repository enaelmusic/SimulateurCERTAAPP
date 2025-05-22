using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000099 RID: 153
	public partial class Trs_DialogueSaisie : Dialogue
	{
		// Token: 0x060009CA RID: 2506 RVA: 0x0005C6D8 File Offset: 0x0005B6D8
		public Trs_DialogueSaisie()
		{
			this.InitializeComponent();
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x0005CBA0 File Offset: 0x0005BBA0
		public Trs_DialogueSaisie(Trs_station p_trs, SuiteOk p_siOk, SuiteAnnuler p_siAnnuler, Noeud p_n)
		{
			this.InitializeComponent();
			this.n = p_n;
			this.trs = p_trs;
			this.siOk = p_siOk;
			this.siAnnuler = p_siAnnuler;
			this.cb_protocole.SelectedIndex = 0;
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x0005CBEC File Offset: 0x0005BBEC
		public void bt_ok_Click(object sender, EventArgs e)
		{
			if (!this.trs.St.Reseau.IsAdrInternet(this.tb_adrIp.Text.Trim()))
			{
				string value = this.cb_protocole.SelectedItem.ToString();
				string text = this.tb_adrIp.Text.Trim();
				if (text == "")
				{
					text = "0.0.0.0";
				}
				string text2 = this.tb_numPort.Text.Trim();
				if (text2 == "")
				{
					text2 = "0";
				}
				ArrayList arrayList = new ArrayList();
				arrayList.Add(value);
				arrayList.Add(text);
				arrayList.Add(text2);
				if (this.n.Reseau.Pref.MemoriserPosDemo)
				{
					this.n.FixerPosition(base.Location.X, base.Location.Y);
				}
				base.Close();
				this.siOk(arrayList);
				return;
			}
			MessageBox.Show("Impossible d'adresser le composant Internet en mode transport");
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x0005CCF8 File Offset: 0x0005BCF8
		private void bt_annuler_Click(object sender, EventArgs e)
		{
			this.siAnnuler();
			base.Close();
		}

		// Token: 0x170001AB RID: 427
		// (set) Token: 0x060009D0 RID: 2512 RVA: 0x0005CD18 File Offset: 0x0005BD18
		public string AdrIpSaisie
		{
			set
			{
				this.tb_adrIp.Text = value;
			}
		}

		// Token: 0x170001AC RID: 428
		// (set) Token: 0x060009D1 RID: 2513 RVA: 0x0005CD34 File Offset: 0x0005BD34
		public string Protocole
		{
			set
			{
				this.cb_protocole.SelectedItem = value;
			}
		}

		// Token: 0x170001AD RID: 429
		// (set) Token: 0x060009D2 RID: 2514 RVA: 0x0005CD50 File Offset: 0x0005BD50
		public string NumPort
		{
			set
			{
				this.tb_numPort.Text = value;
			}
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x0005CD6C File Offset: 0x0005BD6C
		public void BloquerSaisie()
		{
			this.cb_protocole.Enabled = false;
			this.tb_adrIp.Enabled = false;
			this.tb_numPort.Enabled = false;
			this.bt_annuler.Enabled = false;
			this.bt_ok.Enabled = false;
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x0005CDB8 File Offset: 0x0005BDB8
		private void cb_protocole_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cb_protocole.SelectedItem.ToString() == "ICMP")
			{
				this.lbl_numPort.Text = "Id ICMP :";
				this.tb_numPort.Text = this.trs.GenPort(ProtocoleTrs.ICMP).ToString();
				this.tb_numPort.Enabled = false;
				return;
			}
			this.lbl_numPort.Text = "N° de port :";
			this.tb_numPort.Text = "";
			this.tb_numPort.Enabled = true;
		}

		// Token: 0x04000658 RID: 1624
		private Noeud n;

		// Token: 0x04000659 RID: 1625
		private SuiteOk siOk;

		// Token: 0x0400065A RID: 1626
		private SuiteAnnuler siAnnuler;

		// Token: 0x0400065B RID: 1627
		private Trs_station trs;
	}
}
