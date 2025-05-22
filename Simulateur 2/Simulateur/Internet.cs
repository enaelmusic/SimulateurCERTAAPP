using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using System.Xml;

namespace Simulateur
{
	// Token: 0x02000054 RID: 84
	public class Internet : Station
	{
		// Token: 0x0600048E RID: 1166 RVA: 0x00031CB4 File Offset: 0x00030CB4
		public Internet()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x00031CEC File Offset: 0x00030CEC
		public Internet(Simulation s) : base(s)
		{
			this.InitializeComponent();
			base.Paint -= base.Station_Paint;
			this.nbPointsConnexion = 0;
			this.nomNoeud = "Internet";
			base.Controls.Clear();
			for (int i = 0; i < this.BackgroundImage.Width; i++)
			{
				for (int j = 0; j < this.BackgroundImage.Height; j++)
				{
					if (((Bitmap)this.BackgroundImage).GetPixel(i, j).ToArgb() == -1)
					{
						((Bitmap)this.BackgroundImage).SetPixel(i, j, s.Schema.BackColor);
					}
				}
			}
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x00031DB8 File Offset: 0x00030DB8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x00031DE4 File Offset: 0x00030DE4
		private void InitializeComponent()
		{
			this.components = new Container();
			ResourceManager resourceManager = new ResourceManager(typeof(Internet));
			this.il_internet = new ImageList(this.components);
			this.il_internet.ImageSize = new Size(73, 40);
			this.il_internet.ImageStream = (ImageListStreamer)resourceManager.GetObject("il_internet.ImageStream");
			this.il_internet.TransparentColor = Color.White;
			this.BackColor = SystemColors.Control;
			this.BackgroundImage = (Image)resourceManager.GetObject("$this.BackgroundImage");
			base.Name = "Internet";
			base.Size = new Size(73, 40);
			base.Tag = "internet_blanc.bmp";
			base.Paint += this.Internet_Paint;
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x00031EB4 File Offset: 0x00030EB4
		public void Initialiser(Simulation s)
		{
			Point pos = new Point(2, 27);
			base.AjouterPointConnexion(new PortFai(this.reseau), pos);
			pos = new Point(14, 27);
			base.AjouterPointConnexion(new PortFai(this.reseau), pos);
			pos = new Point(48, 27);
			base.AjouterPointConnexion(new PortFai(this.reseau), pos);
			pos = new Point(60, 27);
			base.AjouterPointConnexion(new PortFai(this.reseau), pos);
			this.portsFai = new PortFai[4];
			for (int i = 0; i < 4; i++)
			{
				this.portsFai[i] = (PortFai)base.Controls[i];
			}
			this.fai1.Ports[0] = this.portsFai[0];
			this.fai1.Ports[1] = this.portsFai[1];
			this.fai2.Ports[0] = this.portsFai[2];
			this.fai2.Ports[1] = this.portsFai[3];
			this.ip.RoutageActif = true;
			this.fai1.AdrReseau = s.AdrReseauInternet1;
			this.fai1.MasqueReseau = Ip_masque.GetMasqueDefaut(s.AdrReseauInternet1);
			this.fai2.AdrReseau = s.AdrReseauInternet2;
			this.fai2.MasqueReseau = Ip_masque.GetMasqueDefaut(s.AdrReseauInternet2);
			this.configurerPortsFai();
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0003201C File Offset: 0x0003101C
		private void Internet_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.DrawEllipse(this.styloRelief, 15, 8, 46, 16);
			graphics.DrawString("Internet", this.police, this.stylo.Brush, new RectangleF(19f, 9f, 40f, 25f));
			graphics.DrawRectangle(this.stylo, 0, 25, 26, 14);
			graphics.DrawRectangle(this.stylo, 46, 25, 26, 14);
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x000320A0 File Offset: 0x000310A0
		public override void Dessiner(Graphics g)
		{
			Bitmap image = new Bitmap(base.GetType(), "internet_blanc.bmp");
			g.DrawImage(image, base.Location.X, base.Location.Y, base.Width, base.Height);
			g.DrawString("Internet", this.police, this.stylo.Brush, new RectangleF((float)(base.Location.X + 19), (float)(base.Location.Y + 9), 40f, 25f));
			g.DrawRectangle(this.stylo, base.Location.X, base.Location.Y + 25, 26, 14);
			g.DrawRectangle(this.stylo, base.Location.X + 46, base.Location.Y + 25, 26, 14);
			foreach (object obj in base.Controls)
			{
				PointConnexion pointConnexion = (PointConnexion)obj;
				pointConnexion.Dessiner(g);
			}
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x000321F8 File Offset: 0x000311F8
		protected override ContextMenu menuConception()
		{
			return null;
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x00032208 File Offset: 0x00031208
		protected override ContextMenu menuEthernet()
		{
			return null;
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x00032218 File Offset: 0x00031218
		protected override ContextMenu menuIp()
		{
			return null;
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x00032228 File Offset: 0x00031228
		protected override ContextMenu menuAppl()
		{
			return null;
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x00032238 File Offset: 0x00031238
		public static void SetAdressesInternetDispo(Simulation s)
		{
			int num = 172;
			int num2 = 15;
			int i = 5;
			while (i > 0)
			{
				Ip_adresse adr = new Ip_adresse(string.Concat(new object[]
				{
					num,
					".",
					num2,
					".0.0"
				}));
				while (!Internet.adrReseauDispo(s, adr))
				{
					if (num2 > 0)
					{
						num2--;
					}
					else
					{
						if (num <= 128)
						{
							return;
						}
						num--;
						num2 = 255;
					}
					adr = new Ip_adresse(string.Concat(new object[]
					{
						num,
						".",
						num2,
						".0.0"
					}));
				}
				s.SetAdrReseauInternet(i, adr);
				i--;
				if (num2 > 0)
				{
					num2--;
				}
				else
				{
					if (num <= 128)
					{
						return;
					}
					num--;
					num2 = 255;
				}
			}
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x00032328 File Offset: 0x00031328
		private static bool adrReseauDispo(Simulation s, Ip_adresse adr)
		{
			foreach (object obj in s.Noeuds.Values)
			{
				Noeud noeud = (Noeud)obj;
				if (noeud.GetType() == typeof(Station))
				{
					foreach (object obj2 in ((Station)noeud).Controls)
					{
						CarteReseau carteReseau = (CarteReseau)obj2;
						if (Ip_quartet.MemeReseau(carteReseau.Ip.Adresse, adr, new Ip_quartet("255.255.0.0")))
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00032424 File Offset: 0x00031424
		public static bool IsAdrReseauInternet(Simulation s, string adr)
		{
			for (int i = 1; i <= 5; i++)
			{
				if (Ip_quartet.MemeReseau(s.GetAdrReseauInternet(i).ToString(), adr, "255.255.0.0"))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x0003245C File Offset: 0x0003145C
		private bool estConnecteeInternet(CarteReseau c)
		{
			return (this.fai1.Ports[0].Lien != null && this.fai1.Ports[0].Lien.Oppose(this.fai1.Ports[0]) == c) || (this.fai1.Ports[1].Lien != null && this.fai1.Ports[1].Lien.Oppose(this.fai1.Ports[1]) == c) || (this.fai2.Ports[0].Lien != null && this.fai2.Ports[0].Lien.Oppose(this.fai2.Ports[0]) == c) || (this.fai2.Ports[1].Lien != null && this.fai2.Ports[1].Lien.Oppose(this.fai2.Ports[1]) == c);
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x00032560 File Offset: 0x00031560
		private void configurerPortsFai()
		{
			this.fai1.ConfigurerPorts();
			this.fai2.ConfigurerPorts();
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00032584 File Offset: 0x00031584
		public bool IsAdrInternet(string strAdrIp)
		{
			return this.fai1.IsAdressePort(strAdrIp) || this.fai2.IsAdressePort(strAdrIp);
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x000325B4 File Offset: 0x000315B4
		public override void StockerXml(XmlTextWriter writer)
		{
			writer.WriteStartElement("internet");
			writer.WriteElementString("idNoeud", base.IdNoeud.ToString());
			writer.WriteElementString("nbPointsConnexion", this.nbPointsConnexion.ToString());
			writer.WriteElementString("Location.X", base.Location.X.ToString());
			writer.WriteElementString("Location.Y", base.Location.Y.ToString());
			writer.WriteElementString("PosDemo.X", this.posDemo.X.ToString());
			writer.WriteElementString("PosDemo.Y", this.posDemo.Y.ToString());
			writer.WriteElementString("macPort1", this.portsFai[0].AdresseMac);
			writer.WriteElementString("macPort2", this.portsFai[1].AdresseMac);
			writer.WriteElementString("macPort3", this.portsFai[2].AdresseMac);
			writer.WriteElementString("macPort4", this.portsFai[3].AdresseMac);
			writer.WriteEndElement();
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x000326E0 File Offset: 0x000316E0
		public override void ChangerMode(Simulation.Mode nouveauMode)
		{
			switch (nouveauMode)
			{
			case Simulation.Mode.conceptionReseau:
				this.infoBulle.Active = false;
				break;
			case Simulation.Mode.ethernet:
				this.infoBulle.Active = false;
				break;
			case Simulation.Mode.ip:
				this.infoBulle.Active = true;
				this.SetContenuInfoBulle();
				break;
			case Simulation.Mode.appl:
				this.infoBulle.Active = false;
				break;
			}
			foreach (PortFai portFai in this.portsFai)
			{
				portFai.ChangerMode(nouveauMode);
			}
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x00032764 File Offset: 0x00031764
		public override void SetContenuInfoBulle()
		{
			string text = string.Concat(new object[]
			{
				"FAI 1 : ",
				this.fai1.AdrReseau,
				" (",
				this.fai1.MasqueReseau,
				")"
			});
			text += Environment.NewLine;
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"FAI 2 : ",
				this.fai2.AdrReseau,
				" (",
				this.fai2.MasqueReseau,
				")"
			});
			this.infoBulle.SetToolTip(this, text);
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x00032814 File Offset: 0x00031814
		public void ConfigurerClients()
		{
			this.ip.Routes = new SortedList();
			this.fai1.ConfigurerClients(this.ip.Routes);
			this.fai2.ConfigurerClients(this.ip.Routes);
		}

		// Token: 0x0400034F RID: 847
		private IContainer components = null;

		// Token: 0x04000350 RID: 848
		private PortFai[] portsFai;

		// Token: 0x04000351 RID: 849
		private Fai fai1 = new Fai();

		// Token: 0x04000352 RID: 850
		private ImageList il_internet;

		// Token: 0x04000353 RID: 851
		private Fai fai2 = new Fai();
	}
}
