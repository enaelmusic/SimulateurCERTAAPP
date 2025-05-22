using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000014 RID: 20
	public partial class ConfigCable : Dialogue
	{
		// Token: 0x06000172 RID: 370 RVA: 0x0000BEC4 File Offset: 0x0000AEC4
		public ConfigCable()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000176 RID: 374 RVA: 0x0000C3C0 File Offset: 0x0000B3C0
		// (set) Token: 0x06000175 RID: 373 RVA: 0x0000C364 File Offset: 0x0000B364
		public Cable.TypeCable Type
		{
			get
			{
				if (this.rb_droit.Checked)
				{
					return Cable.TypeCable.droit;
				}
				if (this.rb_croise.Checked)
				{
					return Cable.TypeCable.croise;
				}
				if (this.rb_coaxial.Checked)
				{
					return Cable.TypeCable.coaxial;
				}
				if (this.rb_telecom.Checked)
				{
					return Cable.TypeCable.telecom;
				}
				return Cable.TypeCable.droit;
			}
			set
			{
				switch (value)
				{
				case Cable.TypeCable.croise:
					this.rb_croise.Checked = true;
					return;
				case Cable.TypeCable.droit:
					this.rb_droit.Checked = true;
					return;
				case Cable.TypeCable.coaxial:
					this.rb_coaxial.Checked = true;
					return;
				case Cable.TypeCable.telecom:
					this.rb_telecom.Checked = true;
					return;
				default:
					return;
				}
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000177 RID: 375 RVA: 0x0000C40C File Offset: 0x0000B40C
		// (set) Token: 0x06000178 RID: 376 RVA: 0x0000C42C File Offset: 0x0000B42C
		public int Longueur
		{
			get
			{
				return (int)this.ud_longueur.Value;
			}
			set
			{
				this.ud_longueur.Value = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (set) Token: 0x06000179 RID: 377 RVA: 0x0000C44C File Offset: 0x0000B44C
		public decimal longueurMax
		{
			set
			{
				this.ud_longueur.Maximum = value;
			}
		}
	}
}
