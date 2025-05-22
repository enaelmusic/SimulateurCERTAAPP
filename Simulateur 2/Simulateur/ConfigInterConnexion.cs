using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000016 RID: 22
	public partial class ConfigInterConnexion : Dialogue
	{
		// Token: 0x0600017E RID: 382 RVA: 0x0000C6BC File Offset: 0x0000B6BC
		public ConfigInterConnexion()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000182 RID: 386 RVA: 0x0000CD04 File Offset: 0x0000BD04
		// (set) Token: 0x06000181 RID: 385 RVA: 0x0000CCE8 File Offset: 0x0000BCE8
		public string Nom
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

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000184 RID: 388 RVA: 0x0000CD3C File Offset: 0x0000BD3C
		// (set) Token: 0x06000183 RID: 387 RVA: 0x0000CD1C File Offset: 0x0000BD1C
		public int NbPorts
		{
			get
			{
				return (int)this.ud_nbPorts.Value;
			}
			set
			{
				this.ud_nbPorts.Value = value;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000186 RID: 390 RVA: 0x0000CD7C File Offset: 0x0000BD7C
		// (set) Token: 0x06000185 RID: 389 RVA: 0x0000CD5C File Offset: 0x0000BD5C
		public int NbPortsMini
		{
			get
			{
				return (int)this.ud_nbPorts.Minimum;
			}
			set
			{
				this.ud_nbPorts.Minimum = value;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000188 RID: 392 RVA: 0x0000CDBC File Offset: 0x0000BDBC
		// (set) Token: 0x06000187 RID: 391 RVA: 0x0000CD9C File Offset: 0x0000BD9C
		public int NbPortsCascade
		{
			get
			{
				return (int)this.ud_nbPortsCascade.Value;
			}
			set
			{
				this.ud_nbPortsCascade.Value = value;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600018A RID: 394 RVA: 0x0000CDFC File Offset: 0x0000BDFC
		// (set) Token: 0x06000189 RID: 393 RVA: 0x0000CDDC File Offset: 0x0000BDDC
		public int NbPortsCascadeMini
		{
			get
			{
				return (int)this.ud_nbPortsCascade.Minimum;
			}
			set
			{
				this.ud_nbPortsCascade.Minimum = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600018C RID: 396 RVA: 0x0000CE3C File Offset: 0x0000BE3C
		// (set) Token: 0x0600018B RID: 395 RVA: 0x0000CE1C File Offset: 0x0000BE1C
		public int NbPorts8021q
		{
			get
			{
				return (int)this.ud_nbPorts8021q.Value;
			}
			set
			{
				this.ud_nbPorts8021q.Value = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600018E RID: 398 RVA: 0x0000CE7C File Offset: 0x0000BE7C
		// (set) Token: 0x0600018D RID: 397 RVA: 0x0000CE5C File Offset: 0x0000BE5C
		public int NbPorts8021qMini
		{
			get
			{
				return (int)this.ud_nbPorts8021q.Minimum;
			}
			set
			{
				this.ud_nbPorts8021q.Minimum = value;
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000CE9C File Offset: 0x0000BE9C
		public void Cacher8021q()
		{
			this.lbl_8021q.Visible = false;
			this.ud_nbPorts8021q.Visible = false;
		}
	}
}
