using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000019 RID: 25
	public partial class ConfigStation : Dialogue
	{
		// Token: 0x060001A5 RID: 421 RVA: 0x0000DA1C File Offset: 0x0000CA1C
		public ConfigStation()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x0000DE60 File Offset: 0x0000CE60
		// (set) Token: 0x060001A8 RID: 424 RVA: 0x0000DE44 File Offset: 0x0000CE44
		public string NomStation
		{
			get
			{
				return this.tb_nom.Text;
			}
			set
			{
				this.tb_nom.Text = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060001AB RID: 427 RVA: 0x0000DE98 File Offset: 0x0000CE98
		// (set) Token: 0x060001AA RID: 426 RVA: 0x0000DE78 File Offset: 0x0000CE78
		public int NbCartes
		{
			get
			{
				return (int)this.ud_nbCartes.Value;
			}
			set
			{
				this.ud_nbCartes.Value = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060001AD RID: 429 RVA: 0x0000DEFC File Offset: 0x0000CEFC
		// (set) Token: 0x060001AC RID: 428 RVA: 0x0000DEB8 File Offset: 0x0000CEB8
		public int NbCartesMini
		{
			get
			{
				return (int)this.ud_nbCartes.Value;
			}
			set
			{
				this.ud_nbCartes.Minimum = value;
				if (this.ud_nbCartes.Minimum == 3m)
				{
					this.cb_accesDistant.Enabled = false;
				}
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060001AE RID: 430 RVA: 0x0000DF1C File Offset: 0x0000CF1C
		// (set) Token: 0x060001AF RID: 431 RVA: 0x0000DF34 File Offset: 0x0000CF34
		public bool AccesDistant
		{
			get
			{
				return this.cb_accesDistant.Checked;
			}
			set
			{
				this.cb_accesDistant.Checked = value;
			}
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0000DF50 File Offset: 0x0000CF50
		public void BloquerAccesDistant()
		{
			this.cb_accesDistant.Enabled = false;
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0000DF6C File Offset: 0x0000CF6C
		private void cb_accesDistant_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cb_accesDistant.Checked)
			{
				this.ud_nbCartes.Value = Math.Min(this.ud_nbCartes.Value, 2m);
				this.ud_nbCartes.Maximum = 2m;
				return;
			}
			this.ud_nbCartes.Maximum = 3m;
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x0000DFCC File Offset: 0x0000CFCC
		public int NbPointsConnexion
		{
			get
			{
				int num = (int)this.ud_nbCartes.Value;
				if (this.cb_accesDistant.Checked)
				{
					num++;
				}
				return num;
			}
		}
	}
}
