using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200006C RID: 108
	public class ParamBool : Parametre
	{
		// Token: 0x0600069E RID: 1694 RVA: 0x00041BCC File Offset: 0x00040BCC
		public ParamBool()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x00041BEC File Offset: 0x00040BEC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x00041C18 File Offset: 0x00040C18
		private void InitializeComponent()
		{
			this.cb_valeur = new CheckBox();
			this.label = new Label();
			base.SuspendLayout();
			this.cb_valeur.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.cb_valeur.Location = new Point(152, 8);
			this.cb_valeur.Name = "cb_valeur";
			this.cb_valeur.Size = new Size(12, 12);
			this.cb_valeur.TabIndex = 58;
			this.cb_valeur.CheckedChanged += this.cb_valeur_CheckedChanged;
			this.label.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.label.Location = new Point(24, 0);
			this.label.Name = "label";
			this.label.Size = new Size(120, 23);
			this.label.TabIndex = 59;
			this.label.Text = "label";
			this.label.TextAlign = ContentAlignment.MiddleLeft;
			base.Controls.AddRange(new Control[]
			{
				this.label,
				this.cb_valeur
			});
			base.Name = "ParamBool";
			base.Size = new Size(168, 24);
			base.ResumeLayout(false);
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x00041D64 File Offset: 0x00040D64
		protected override string xmlValeur()
		{
			return this.Valeur.ToString();
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x00041D80 File Offset: 0x00040D80
		protected override void setValeur(string xmlValeur)
		{
			this.Valeur = bool.Parse(xmlValeur);
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060006A3 RID: 1699 RVA: 0x00041D9C File Offset: 0x00040D9C
		// (set) Token: 0x060006A4 RID: 1700 RVA: 0x00041DB4 File Offset: 0x00040DB4
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

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060006A5 RID: 1701 RVA: 0x00041DD0 File Offset: 0x00040DD0
		// (set) Token: 0x060006A6 RID: 1702 RVA: 0x00041DE4 File Offset: 0x00040DE4
		public bool ValeurDefaut
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

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060006A7 RID: 1703 RVA: 0x00041DF8 File Offset: 0x00040DF8
		// (set) Token: 0x060006A8 RID: 1704 RVA: 0x00041E10 File Offset: 0x00040E10
		public bool Valeur
		{
			get
			{
				return this.cb_valeur.Checked;
			}
			set
			{
				this.cb_valeur.Checked = value;
				base.signalerModif();
			}
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x00041E30 File Offset: 0x00040E30
		public override void restaurerDefaut()
		{
			this.Valeur = this.valeurDefaut;
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x00041E4C File Offset: 0x00040E4C
		private void cb_valeur_CheckedChanged(object sender, EventArgs e)
		{
			base.signalerModif();
		}

		// Token: 0x0400045B RID: 1115
		private CheckBox cb_valeur;

		// Token: 0x0400045C RID: 1116
		private Label label;

		// Token: 0x0400045D RID: 1117
		private IContainer components = null;

		// Token: 0x0400045E RID: 1118
		private bool valeurDefaut;
	}
}
