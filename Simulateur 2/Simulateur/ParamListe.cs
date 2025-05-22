using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200006E RID: 110
	public class ParamListe : Parametre
	{
		// Token: 0x060006BF RID: 1727 RVA: 0x00042348 File Offset: 0x00041348
		public ParamListe()
		{
			this.InitializeComponent();
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x00042378 File Offset: 0x00041378
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x000423A4 File Offset: 0x000413A4
		private void InitializeComponent()
		{
			this.label = new Label();
			this.cb_valeurs = new ComboBox();
			base.SuspendLayout();
			this.label.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.label.Location = new Point(24, 0);
			this.label.Name = "label";
			this.label.Size = new Size(272, 23);
			this.label.TabIndex = 59;
			this.label.Text = "label";
			this.label.TextAlign = ContentAlignment.MiddleLeft;
			this.cb_valeurs.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.cb_valeurs.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cb_valeurs.Location = new Point(192, 2);
			this.cb_valeurs.Name = "cb_valeurs";
			this.cb_valeurs.Size = new Size(150, 21);
			this.cb_valeurs.TabIndex = 60;
			this.cb_valeurs.SelectedIndexChanged += this.cb_valeurs_SelectedIndexChanged;
			base.Controls.Add(this.cb_valeurs);
			base.Controls.Add(this.label);
			base.Name = "ParamListe";
			base.Size = new Size(344, 24);
			base.Controls.SetChildIndex(this.label, 0);
			base.Controls.SetChildIndex(this.cb_valeurs, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x00042524 File Offset: 0x00041524
		protected override string xmlValeur()
		{
			return this.cb_valeurs.SelectedItem.ToString();
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x00042544 File Offset: 0x00041544
		protected override void setValeur(string xmlValeur)
		{
			this.Valeur = xmlValeur;
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060006C4 RID: 1732 RVA: 0x00042558 File Offset: 0x00041558
		// (set) Token: 0x060006C5 RID: 1733 RVA: 0x00042570 File Offset: 0x00041570
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

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060006C6 RID: 1734 RVA: 0x0004258C File Offset: 0x0004158C
		// (set) Token: 0x060006C7 RID: 1735 RVA: 0x000425A0 File Offset: 0x000415A0
		public string ValeurDefaut
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

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060006C8 RID: 1736 RVA: 0x000425B4 File Offset: 0x000415B4
		// (set) Token: 0x060006C9 RID: 1737 RVA: 0x000425D4 File Offset: 0x000415D4
		public string Valeur
		{
			get
			{
				return this.cb_valeurs.SelectedItem.ToString();
			}
			set
			{
				try
				{
					this.cb_valeurs.SelectedItem = value;
					base.signalerModif();
				}
				catch
				{
				}
			}
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x00042614 File Offset: 0x00041614
		public override void restaurerDefaut()
		{
			this.Valeur = this.valeurDefaut;
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x00042630 File Offset: 0x00041630
		private void cb_valeurs_SelectedIndexChanged(object sender, EventArgs e)
		{
			base.signalerModif();
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060006CC RID: 1740 RVA: 0x00042644 File Offset: 0x00041644
		// (set) Token: 0x060006CD RID: 1741 RVA: 0x00042658 File Offset: 0x00041658
		public string[] Items
		{
			get
			{
				return this.items;
			}
			set
			{
				this.items = value;
				foreach (string item in this.items)
				{
					this.cb_valeurs.Items.Add(item);
				}
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060006CE RID: 1742 RVA: 0x00042698 File Offset: 0x00041698
		// (set) Token: 0x060006CF RID: 1743 RVA: 0x000426B0 File Offset: 0x000416B0
		public int TailleListe
		{
			get
			{
				return this.cb_valeurs.Width;
			}
			set
			{
				int num = value - this.cb_valeurs.Width;
				this.cb_valeurs.Size = new Size(this.cb_valeurs.Size.Width + num, this.cb_valeurs.Size.Height);
				this.cb_valeurs.Location = new Point(this.cb_valeurs.Location.X - num, this.cb_valeurs.Location.Y);
			}
		}

		// Token: 0x04000467 RID: 1127
		private Label label;

		// Token: 0x04000468 RID: 1128
		private ComboBox cb_valeurs;

		// Token: 0x04000469 RID: 1129
		private IContainer components = null;

		// Token: 0x0400046A RID: 1130
		private string valeurDefaut;

		// Token: 0x0400046B RID: 1131
		private string[] items = new string[20];
	}
}
