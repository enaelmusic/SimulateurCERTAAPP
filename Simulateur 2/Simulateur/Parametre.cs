using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using System.Xml;

namespace Simulateur
{
	// Token: 0x0200006B RID: 107
	public class Parametre : UserControl
	{
		// Token: 0x06000692 RID: 1682 RVA: 0x00041918 File Offset: 0x00040918
		public Parametre()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x00041934 File Offset: 0x00040934
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x00041960 File Offset: 0x00040960
		private void InitializeComponent()
		{
			this.components = new Container();
			ResourceManager resourceManager = new ResourceManager(typeof(Parametre));
			this.il_images = new ImageList(this.components);
			this.bt_defaut = new Button();
			base.SuspendLayout();
			this.il_images.ColorDepth = ColorDepth.Depth8Bit;
			this.il_images.ImageSize = new Size(16, 16);
			this.il_images.ImageStream = (ImageListStreamer)resourceManager.GetObject("il_images.ImageStream");
			this.il_images.TransparentColor = Color.White;
			this.bt_defaut.Image = (Bitmap)resourceManager.GetObject("bt_defaut.Image");
			this.bt_defaut.ImageIndex = 1;
			this.bt_defaut.ImageList = this.il_images;
			this.bt_defaut.Name = "bt_defaut";
			this.bt_defaut.Size = new Size(24, 24);
			this.bt_defaut.TabIndex = 57;
			this.bt_defaut.Click += this.bt_defaut_Click;
			base.Controls.AddRange(new Control[]
			{
				this.bt_defaut
			});
			base.Name = "Parametre";
			base.Size = new Size(112, 24);
			base.ResumeLayout(false);
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x00041AB4 File Offset: 0x00040AB4
		public virtual void restaurerDefaut()
		{
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x00041AC4 File Offset: 0x00040AC4
		private void bt_defaut_Click(object sender, EventArgs e)
		{
			this.restaurerDefaut();
		}

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x06000697 RID: 1687 RVA: 0x00041AD8 File Offset: 0x00040AD8
		// (remove) Token: 0x06000698 RID: 1688 RVA: 0x00041AFC File Offset: 0x00040AFC
		public event EventHandler ValueChanged;

		// Token: 0x06000699 RID: 1689 RVA: 0x00041B20 File Offset: 0x00040B20
		protected void signalerModif()
		{
			if (this.ValueChanged != null)
			{
				this.ValueChanged(this, null);
			}
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x00041B44 File Offset: 0x00040B44
		protected virtual string xmlValeur()
		{
			return "";
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x00041B58 File Offset: 0x00040B58
		protected virtual void setValeur(string xmlValeur)
		{
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x00041B68 File Offset: 0x00040B68
		public bool SetXmlRead(XmlTextReader reader)
		{
			if (reader.LocalName == base.Name)
			{
				reader.Read();
				this.setValeur(reader.Value);
				return true;
			}
			return false;
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x00041BA0 File Offset: 0x00040BA0
		public void XmlWrite(XmlTextWriter writer)
		{
			writer.WriteStartElement(base.Name);
			writer.WriteString(this.xmlValeur());
			writer.WriteEndElement();
		}

		// Token: 0x04000457 RID: 1111
		private ImageList il_images;

		// Token: 0x04000458 RID: 1112
		private Button bt_defaut;

		// Token: 0x04000459 RID: 1113
		private IContainer components;
	}
}
