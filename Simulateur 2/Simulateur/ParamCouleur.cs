using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200006D RID: 109
	public class ParamCouleur : Parametre
	{
		// Token: 0x060006AB RID: 1707 RVA: 0x00041E60 File Offset: 0x00040E60
		public ParamCouleur()
		{
			this.InitializeComponent();
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x00041E98 File Offset: 0x00040E98
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x00041EC4 File Offset: 0x00040EC4
		private void InitializeComponent()
		{
			this.components = new Container();
			ResourceManager resourceManager = new ResourceManager(typeof(ParamCouleur));
			this.bt_choixCouleur = new Button();
			this.il_images = new ImageList(this.components);
			this.cd_couleur = new ColorDialog();
			this.temoin_couleur = new Label();
			this.label = new Label();
			base.SuspendLayout();
			this.bt_choixCouleur.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.bt_choixCouleur.ImageIndex = 0;
			this.bt_choixCouleur.ImageList = this.il_images;
			this.bt_choixCouleur.Location = new Point(144, 0);
			this.bt_choixCouleur.Name = "bt_choixCouleur";
			this.bt_choixCouleur.Size = new Size(24, 24);
			this.bt_choixCouleur.TabIndex = 60;
			this.bt_choixCouleur.Click += this.bt_choixCouleur_Click;
			this.il_images.ImageSize = new Size(16, 16);
			this.il_images.ImageStream = (ImageListStreamer)resourceManager.GetObject("il_images.ImageStream");
			this.il_images.TransparentColor = Color.White;
			this.cd_couleur.AnyColor = true;
			this.temoin_couleur.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.temoin_couleur.BackColor = Color.Magenta;
			this.temoin_couleur.BorderStyle = BorderStyle.FixedSingle;
			this.temoin_couleur.Location = new Point(120, 0);
			this.temoin_couleur.Name = "temoin_couleur";
			this.temoin_couleur.Size = new Size(24, 24);
			this.temoin_couleur.TabIndex = 61;
			this.label.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.label.Location = new Point(24, 0);
			this.label.Name = "label";
			this.label.Size = new Size(96, 23);
			this.label.TabIndex = 62;
			this.label.Text = "label";
			this.label.TextAlign = ContentAlignment.MiddleLeft;
			base.Controls.Add(this.label);
			base.Controls.Add(this.temoin_couleur);
			base.Controls.Add(this.bt_choixCouleur);
			base.Name = "ParamCouleur";
			base.Size = new Size(168, 24);
			base.Controls.SetChildIndex(this.bt_choixCouleur, 0);
			base.Controls.SetChildIndex(this.temoin_couleur, 0);
			base.Controls.SetChildIndex(this.label, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x0004216C File Offset: 0x0004116C
		public override void restaurerDefaut()
		{
			this.Valeur = this.valeurDefaut;
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x00042188 File Offset: 0x00041188
		protected override string xmlValeur()
		{
			return this.Valeur.ToArgb().ToString();
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x000421AC File Offset: 0x000411AC
		protected override void setValeur(string xmlValeur)
		{
			this.Valeur = Color.FromArgb(int.Parse(xmlValeur));
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060006B1 RID: 1713 RVA: 0x000421CC File Offset: 0x000411CC
		// (set) Token: 0x060006B2 RID: 1714 RVA: 0x000421E4 File Offset: 0x000411E4
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

		// Token: 0x060006B3 RID: 1715 RVA: 0x00042200 File Offset: 0x00041200
		private void bt_choixCouleur_Click(object sender, EventArgs e)
		{
			if (this.cd_couleur.ShowDialog() == DialogResult.OK)
			{
				this.Valeur = this.cd_couleur.Color;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060006B4 RID: 1716 RVA: 0x0004222C File Offset: 0x0004122C
		// (set) Token: 0x060006B5 RID: 1717 RVA: 0x00042244 File Offset: 0x00041244
		public float EpaisseurStylo
		{
			get
			{
				return this.stylo.Width;
			}
			set
			{
				this.stylo.Width = value;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060006B6 RID: 1718 RVA: 0x00042260 File Offset: 0x00041260
		public Pen Stylo
		{
			get
			{
				return this.stylo;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060006B7 RID: 1719 RVA: 0x00042274 File Offset: 0x00041274
		// (set) Token: 0x060006B8 RID: 1720 RVA: 0x00042288 File Offset: 0x00041288
		public Color ValeurDefaut
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

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060006B9 RID: 1721 RVA: 0x0004229C File Offset: 0x0004129C
		// (set) Token: 0x060006BA RID: 1722 RVA: 0x000422B4 File Offset: 0x000412B4
		public Color Valeur
		{
			get
			{
				return this.temoin_couleur.BackColor;
			}
			set
			{
				this.temoin_couleur.BackColor = value;
				this.stylo.Color = value;
				base.signalerModif();
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060006BB RID: 1723 RVA: 0x000422E0 File Offset: 0x000412E0
		// (set) Token: 0x060006BC RID: 1724 RVA: 0x000422F8 File Offset: 0x000412F8
		public bool AllowFullOpen
		{
			get
			{
				return this.cd_couleur.AllowFullOpen;
			}
			set
			{
				this.cd_couleur.AllowFullOpen = value;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060006BD RID: 1725 RVA: 0x00042314 File Offset: 0x00041314
		// (set) Token: 0x060006BE RID: 1726 RVA: 0x0004232C File Offset: 0x0004132C
		public bool SolidColorOnly
		{
			get
			{
				return this.cd_couleur.SolidColorOnly;
			}
			set
			{
				this.cd_couleur.SolidColorOnly = value;
			}
		}

		// Token: 0x0400045F RID: 1119
		private ImageList il_images;

		// Token: 0x04000460 RID: 1120
		private ColorDialog cd_couleur;

		// Token: 0x04000461 RID: 1121
		private Button bt_choixCouleur;

		// Token: 0x04000462 RID: 1122
		private Label temoin_couleur;

		// Token: 0x04000463 RID: 1123
		private Label label;

		// Token: 0x04000464 RID: 1124
		private IContainer components = null;

		// Token: 0x04000465 RID: 1125
		private Color valeurDefaut;

		// Token: 0x04000466 RID: 1126
		private Pen stylo = new Pen(Color.Black, 1f);
	}
}
