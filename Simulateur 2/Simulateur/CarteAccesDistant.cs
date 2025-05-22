using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Simulateur
{
	// Token: 0x02000012 RID: 18
	public class CarteAccesDistant : CarteReseau
	{
		// Token: 0x06000162 RID: 354 RVA: 0x0000B9E4 File Offset: 0x0000A9E4
		public CarteAccesDistant()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000BA04 File Offset: 0x0000AA04
		public CarteAccesDistant(Simulation s) : base(s)
		{
			this.InitializeComponent();
			base.Size = new Size(11, 11);
			this.stylo = s.Pref.EpaisStylo;
			base.Protocole = "ppp";
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000BA50 File Offset: 0x0000AA50
		protected override void initOkCables()
		{
			this.typePointConnexion = PointConnexion.TypesPointConnexion.carteAccesDistant;
			this.okCableTelecom.Add(PointConnexion.TypesPointConnexion.portFai);
			this.okCableTelecom.Add(PointConnexion.TypesPointConnexion.carteAccesDistant);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000BA88 File Offset: 0x0000AA88
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000BAB4 File Offset: 0x0000AAB4
		private void InitializeComponent()
		{
			base.Name = "CarteAccesDistant";
			base.Size = new Size(11, 11);
			base.Paint += this.CarteAccesDistant_Paint;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000BAF0 File Offset: 0x0000AAF0
		public override void Dessiner(Graphics g)
		{
			base.dessinerFond(g);
			g.DrawRectangle(this.stylo, base.NoeudAttache.Location.X + base.Location.X + 1, base.NoeudAttache.Location.Y + base.Location.Y + 1, base.Width - 2, base.Height - 2);
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000BB68 File Offset: 0x0000AB68
		private void CarteAccesDistant_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.DrawRectangle(this.stylo, 1, 1, base.Width - 2, base.Height - 2);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000BB9C File Offset: 0x0000AB9C
		protected override ContextMenu menuIp()
		{
			if (this.lien == null)
			{
				return base.menuIp();
			}
			if (this.lien.Oppose(this).GetType() == typeof(CarteAccesDistant))
			{
				return base.menuIp();
			}
			return null;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0000BBE0 File Offset: 0x0000ABE0
		protected override ContextMenu menuEthernet()
		{
			return null;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0000BBF0 File Offset: 0x0000ABF0
		public override void StockerXml(XmlTextWriter writer)
		{
			writer.WriteStartElement("carteAccesDistant");
			writer.WriteAttributeString("adresseMac", base.AdresseMac);
			base.Ip.StockerXml(writer);
			writer.WriteEndElement();
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0000BC2C File Offset: 0x0000AC2C
		public override bool EstSurStation()
		{
			return true;
		}

		// Token: 0x040000AC RID: 172
		private IContainer components = null;
	}
}
