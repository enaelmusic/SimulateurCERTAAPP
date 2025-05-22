using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200006F RID: 111
	public class ParamNumericUpDown : Parametre
	{
		// Token: 0x060006D0 RID: 1744 RVA: 0x0004273C File Offset: 0x0004173C
		public ParamNumericUpDown()
		{
			this.InitializeComponent();
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x0004275C File Offset: 0x0004175C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x00042788 File Offset: 0x00041788
		private void InitializeComponent()
		{
			this.upDown = new NumericUpDown();
			this.label = new Label();
			((ISupportInitialize)this.upDown).BeginInit();
			base.SuspendLayout();
			this.upDown.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.upDown.Location = new Point(120, 2);
			this.upDown.Name = "upDown";
			this.upDown.Size = new Size(56, 20);
			this.upDown.TabIndex = 59;
			this.upDown.ValueChanged += this.upDown_ValueChanged;
			this.label.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.label.Location = new Point(24, 0);
			this.label.Name = "label";
			this.label.Size = new Size(96, 23);
			this.label.TabIndex = 60;
			this.label.Text = "label";
			this.label.TextAlign = ContentAlignment.MiddleLeft;
			base.Controls.AddRange(new Control[]
			{
				this.label,
				this.upDown
			});
			base.Name = "ParamNumericUpDown";
			base.Size = new Size(176, 24);
			((ISupportInitialize)this.upDown).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x000428E8 File Offset: 0x000418E8
		protected override string xmlValeur()
		{
			return this.Valeur.ToString();
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x00042904 File Offset: 0x00041904
		protected override void setValeur(string xmlValeur)
		{
			this.Valeur = decimal.Parse(xmlValeur);
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060006D5 RID: 1749 RVA: 0x00042920 File Offset: 0x00041920
		// (set) Token: 0x060006D6 RID: 1750 RVA: 0x00042938 File Offset: 0x00041938
		public int NbDecimales
		{
			get
			{
				return this.upDown.DecimalPlaces;
			}
			set
			{
				this.upDown.DecimalPlaces = value;
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060006D7 RID: 1751 RVA: 0x00042954 File Offset: 0x00041954
		// (set) Token: 0x060006D8 RID: 1752 RVA: 0x0004296C File Offset: 0x0004196C
		public string Label
		{
			get
			{
				return this.label.Text;
			}
			set
			{
				this.label.Text = value;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060006D9 RID: 1753 RVA: 0x00042988 File Offset: 0x00041988
		// (set) Token: 0x060006DA RID: 1754 RVA: 0x0004299C File Offset: 0x0004199C
		public decimal ValeurDefaut
		{
			get
			{
				return this.valeurDefaut;
			}
			set
			{
				this.valeurDefaut = value;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060006DB RID: 1755 RVA: 0x000429B0 File Offset: 0x000419B0
		// (set) Token: 0x060006DC RID: 1756 RVA: 0x000429C8 File Offset: 0x000419C8
		public decimal Valeur
		{
			get
			{
				return this.upDown.Value;
			}
			set
			{
				this.upDown.Value = value;
				this.temp = this.upDown.Value;
				this.upDown.Value = value;
				base.signalerModif();
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060006DD RID: 1757 RVA: 0x00042A04 File Offset: 0x00041A04
		// (set) Token: 0x060006DE RID: 1758 RVA: 0x00042A1C File Offset: 0x00041A1C
		public decimal Increment
		{
			get
			{
				return this.upDown.Increment;
			}
			set
			{
				this.upDown.Increment = value;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x00042A38 File Offset: 0x00041A38
		// (set) Token: 0x060006E0 RID: 1760 RVA: 0x00042A50 File Offset: 0x00041A50
		public decimal Minimum
		{
			get
			{
				return this.upDown.Minimum;
			}
			set
			{
				this.upDown.Minimum = value;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060006E1 RID: 1761 RVA: 0x00042A6C File Offset: 0x00041A6C
		// (set) Token: 0x060006E2 RID: 1762 RVA: 0x00042A84 File Offset: 0x00041A84
		public decimal Maximum
		{
			get
			{
				return this.upDown.Maximum;
			}
			set
			{
				this.upDown.Maximum = value;
			}
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x00042AA0 File Offset: 0x00041AA0
		public override void restaurerDefaut()
		{
			this.Valeur = this.valeurDefaut;
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x00042ABC File Offset: 0x00041ABC
		private void upDown_ValueChanged(object sender, EventArgs e)
		{
			base.signalerModif();
		}

		// Token: 0x0400046C RID: 1132
		private NumericUpDown upDown;

		// Token: 0x0400046D RID: 1133
		private Label label;

		// Token: 0x0400046E RID: 1134
		private IContainer components = null;

		// Token: 0x0400046F RID: 1135
		private decimal valeurDefaut;

		// Token: 0x04000470 RID: 1136
		private decimal temp;
	}
}
