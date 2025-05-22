using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000015 RID: 21
	public partial class ConfigCarte : Dialogue
	{
		// Token: 0x0600017A RID: 378 RVA: 0x0000C468 File Offset: 0x0000B468
		public ConfigCarte()
		{
			this.InitializeComponent();
			this.bt_annuler.Visible = false;
		}

		// Token: 0x17000024 RID: 36
		// (set) Token: 0x0600017D RID: 381 RVA: 0x0000C6A0 File Offset: 0x0000B6A0
		public string AdresseMac
		{
			set
			{
				this.tb_adresseMac.Text = value;
			}
		}
	}
}
