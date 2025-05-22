using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200001A RID: 26
	public partial class ConfigSwitch : ConfigInterConnexion
	{
		// Token: 0x060001B3 RID: 435 RVA: 0x0000DFFC File Offset: 0x0000CFFC
		public ConfigSwitch()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0000E01C File Offset: 0x0000D01C
		public ConfigSwitch(Switch p_sw, bool lectureSeule)
		{
			this.InitializeComponent();
			this.sw = p_sw;
			if (this.sw.TypeSwitch == Switch.TypeDeSwitch.onTheFly)
			{
				this.rb_onTheFly.Checked = true;
			}
			else
			{
				this.rb_storeAndForward.Checked = true;
			}
			this.cb_spanningTree.Checked = this.sw.SpanningTree;
			this.ud_niveauVlan.Value = this.sw.NiveauVlan;
			if (lectureSeule)
			{
				this.tb_nom.Enabled = false;
				this.ud_nbPorts.Enabled = false;
				this.ud_nbPortsCascade.Enabled = false;
				this.ud_nbPorts8021q.Enabled = false;
				this.ud_niveauVlan.Enabled = false;
				this.cb_spanningTree.Enabled = false;
			}
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0000E788 File Offset: 0x0000D788
		private void bt_ok_Click(object sender, EventArgs e)
		{
			if (this.ud_niveauVlan.Value == 0m)
			{
				if (this.sw.NbPorts8021qConnectes() != 0)
				{
					MessageBox.Show("Changement de niveau vlan impossible, il y a des ports 802.1q connectés !");
					this.ud_niveauVlan.Value = this.sw.NiveauVlan;
					return;
				}
				if (this.ud_nbPorts8021q.Value != 0m)
				{
					MessageBox.Show("VLANs non gérés, les ports 802.1q ont été supprimés !");
					this.ud_nbPorts8021q.Value = 0m;
				}
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x0000E818 File Offset: 0x0000D818
		public Switch.TypeDeSwitch TypeSwitch
		{
			get
			{
				if (this.rb_onTheFly.Checked)
				{
					return Switch.TypeDeSwitch.onTheFly;
				}
				return Switch.TypeDeSwitch.storeAndForward;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x0000E838 File Offset: 0x0000D838
		public bool SpanningTree
		{
			get
			{
				return this.cb_spanningTree.Checked;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060001BA RID: 442 RVA: 0x0000E850 File Offset: 0x0000D850
		public int NiveauVlan
		{
			get
			{
				return (int)this.ud_niveauVlan.Value;
			}
		}

		// Token: 0x040000E2 RID: 226
		private Switch sw;
	}
}
