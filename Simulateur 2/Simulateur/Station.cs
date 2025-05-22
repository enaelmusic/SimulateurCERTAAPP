using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Simulateur
{
	// Token: 0x02000053 RID: 83
	public class Station : Noeud
	{
		// Token: 0x06000462 RID: 1122 RVA: 0x0002F5A0 File Offset: 0x0002E5A0
		public Station()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0002F5C0 File Offset: 0x0002E5C0
		public Station(Simulation s) : base(s)
		{
			this.InitializeComponent();
			base.Paint += this.Station_Paint;
			this.initialiser();
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x0002F5FC File Offset: 0x0002E5FC
		private void initialiser()
		{
			base.Size = new Size(39, 50);
			base.AjouterPointConnexion(new CarteReseau(this.reseau));
			this.ip = new Ip_station(this);
			this.ap = new Ap_station(this);
			this.trs = new Trs_station(this);
			this.message = new MessageSt(this);
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x0002F65C File Offset: 0x0002E65C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0002F688 File Offset: 0x0002E688
		private void InitializeComponent()
		{
			this.menuItem1 = new MenuItem();
			this.mi_configIp = new MenuItem();
			this.mi_ping = new MenuItem();
			this.menuItem2 = new MenuItem();
			this.mi_envoyerMessage = new MenuItem();
			this.mi_envoyerRequete = new MenuItem();
			this.mi_repondreClient = new MenuItem();
			this.mi_tablesTrs = new MenuItem();
			this.mi_tableRoutageTrs = new MenuItem();
			this.mi_fichierHostsTrs = new MenuItem();
			this.mi_cacheArp = new MenuItem();
			this.mi_separIp = new MenuItem();
			this.mi_reglesFiltrage = new MenuItem();
			this.mi_tableNatPat = new MenuItem();
			this.mi_viderCacheArp = new MenuItem();
			this.mi_echangesEnCours = new MenuItem();
			this.menuItem3 = new MenuItem();
			this.menuItem4 = new MenuItem();
			this.mi_tablesIp = new MenuItem();
			this.mi_portsEcoutes = new MenuItem();
			this.mi_tableRoutageIp = new MenuItem();
			this.mi_fichierHostsIp = new MenuItem();
			this.cm_ip.MenuItems.AddRange(new MenuItem[]
			{
				this.menuItem1,
				this.mi_configIp,
				this.mi_tablesIp,
				this.mi_tablesTrs,
				this.menuItem3,
				this.mi_viderCacheArp,
				this.mi_echangesEnCours,
				this.menuItem4,
				this.mi_ping,
				this.mi_envoyerRequete,
				this.mi_repondreClient
			});
			this.cm_appl.MenuItems.AddRange(new MenuItem[]
			{
				this.menuItem2,
				this.mi_envoyerMessage
			});
			this.menuItem1.Index = 2;
			this.menuItem1.Text = "-";
			this.mi_configIp.Index = 3;
			this.mi_configIp.Text = "Configuration IP";
			this.mi_configIp.Click += this.mi_configIp_Click;
			this.mi_ping.Index = 10;
			this.mi_ping.Text = "Envoyer un ping";
			this.mi_ping.Click += this.mi_ping_Click;
			this.menuItem2.Index = 2;
			this.menuItem2.Text = "-";
			this.mi_envoyerMessage.Index = 3;
			this.mi_envoyerMessage.Text = "Envoyer un message";
			this.mi_envoyerMessage.Click += this.mi_envoyerMessage_Click;
			this.mi_envoyerRequete.Index = 11;
			this.mi_envoyerRequete.Text = "Envoyer une requête";
			this.mi_envoyerRequete.Click += this.mi_envoyerRequete_Click;
			this.mi_repondreClient.Index = 12;
			this.mi_repondreClient.Text = "Répondre à une requête";
			this.mi_repondreClient.Click += this.mi_repondreRequete_Click;
			this.mi_tablesTrs.Index = 5;
			this.mi_tablesTrs.MenuItems.AddRange(new MenuItem[]
			{
				this.mi_tableRoutageTrs,
				this.mi_fichierHostsTrs,
				this.mi_separIp,
				this.mi_portsEcoutes,
				this.mi_reglesFiltrage,
				this.mi_tableNatPat
			});
			this.mi_tablesTrs.Text = "Tables";
			this.mi_tableRoutageTrs.Index = 0;
			this.mi_tableRoutageTrs.Text = "Table de routage";
			this.mi_tableRoutageTrs.Click += this.mi_tableRoutage_Click;
			this.mi_fichierHostsTrs.Index = 1;
			this.mi_fichierHostsTrs.Text = "Fichier hosts";
			this.mi_fichierHostsTrs.Click += this.mi_fichierHosts_Click;
			this.mi_cacheArp.Index = 2;
			this.mi_cacheArp.Text = "Cache ARP";
			this.mi_cacheArp.Click += this.mi_cacheArp_Click;
			this.mi_separIp.Index = 2;
			this.mi_separIp.Text = "-";
			this.mi_reglesFiltrage.Index = 4;
			this.mi_reglesFiltrage.Text = "Règles de filtrage";
			this.mi_reglesFiltrage.Click += this.mi_reglesFiltrage_Click;
			this.mi_tableNatPat.Index = 5;
			this.mi_tableNatPat.Text = "Table Nat/Pat";
			this.mi_tableNatPat.Click += this.mi_tableNatPat_Click;
			this.mi_viderCacheArp.Index = 7;
			this.mi_viderCacheArp.Text = "Vider cache ARP";
			this.mi_viderCacheArp.Click += this.mi_viderCacheArp_Click;
			this.mi_echangesEnCours.Index = 8;
			this.mi_echangesEnCours.Text = "Echanges en cours";
			this.mi_echangesEnCours.Click += this.mi_echangesEnCours_Click;
			this.menuItem3.Index = 6;
			this.menuItem3.Text = "-";
			this.menuItem4.Index = 9;
			this.menuItem4.Text = "-";
			this.mi_tablesIp.Index = 4;
			this.mi_tablesIp.MenuItems.AddRange(new MenuItem[]
			{
				this.mi_tableRoutageIp,
				this.mi_fichierHostsIp,
				this.mi_cacheArp
			});
			this.mi_tablesIp.Text = "Tables";
			this.mi_portsEcoutes.Index = 3;
			this.mi_portsEcoutes.Text = "Ports écoutés";
			this.mi_portsEcoutes.Click += this.mi_portsEcoutes_Click;
			this.mi_tableRoutageIp.Index = 0;
			this.mi_tableRoutageIp.Text = "Table de routage";
			this.mi_tableRoutageIp.Click += this.mi_tableRoutage_Click;
			this.mi_fichierHostsIp.Index = 1;
			this.mi_fichierHostsIp.Text = "Fichier hosts";
			this.mi_fichierHostsIp.Click += this.mi_fichierHosts_Click;
			base.Name = "Station";
			base.Size = new Size(24, 328);
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x0002FC94 File Offset: 0x0002EC94
		public override void Dessiner(Graphics g)
		{
			g.FillRectangle(Brushes.White, base.Location.X, base.Location.Y, base.Width, base.Height);
			g.DrawRectangle(this.stylo, base.Location.X, base.Location.Y, 38, 33);
			g.DrawRectangle(this.stylo, base.Location.X + 4, base.Location.Y + 4, 30, 25);
			g.DrawString(this.nomNoeud, this.police, this.stylo.Brush, new RectangleF((float)(base.Location.X + 5), (float)(base.Location.Y + 4), 32f, 25f));
			g.DrawRectangle(this.stylo, base.Location.X, base.Location.Y + 35, 38, 14);
			if (this.reseau.Pref.Icones)
			{
				if (this.ip.RoutageActif)
				{
					g.DrawLine(this.stylo, base.Location.X + 7, base.Location.Y + 18, base.Location.X + 10, base.Location.Y + 21);
					g.DrawLine(this.stylo, base.Location.X + 7, base.Location.Y + 26, base.Location.X + 10, base.Location.Y + 23);
					g.DrawLine(this.stylo, base.Location.X + 12, base.Location.Y + 21, base.Location.X + 15, base.Location.Y + 18);
					g.DrawLine(this.stylo, base.Location.X + 12, base.Location.Y + 23, base.Location.X + 15, base.Location.Y + 26);
					g.DrawLine(this.stylo, base.Location.X + 13, base.Location.Y + 18, base.Location.X + 14, base.Location.Y + 18);
					g.DrawLine(this.stylo, base.Location.X + 15, base.Location.Y + 19, base.Location.X + 15, base.Location.Y + 20);
					g.DrawLine(this.stylo, base.Location.X + 12, base.Location.Y + 24, base.Location.X + 12, base.Location.Y + 25);
					g.DrawLine(this.stylo, base.Location.X + 13, base.Location.Y + 23, base.Location.X + 14, base.Location.Y + 23);
					g.DrawLine(this.stylo, base.Location.X + 10, base.Location.Y + 19, base.Location.X + 10, base.Location.Y + 20);
					g.DrawLine(this.stylo, base.Location.X + 8, base.Location.Y + 21, base.Location.X + 9, base.Location.Y + 21);
					g.DrawLine(this.stylo, base.Location.X + 7, base.Location.Y + 24, base.Location.X + 7, base.Location.Y + 25);
					g.DrawLine(this.stylo, base.Location.X + 8, base.Location.Y + 26, base.Location.X + 9, base.Location.Y + 26);
					if (this.trs.NatPatActif)
					{
						g.DrawLine(this.stylo, base.Location.X + 22, base.Location.Y + 24, base.Location.X + 31, base.Location.Y + 24);
						g.DrawLine(this.stylo, base.Location.X + 23, base.Location.Y + 23, base.Location.X + 23, base.Location.Y + 25);
						g.DrawLine(this.stylo, base.Location.X + 24, base.Location.Y + 22, base.Location.X + 24, base.Location.Y + 26);
						g.DrawLine(this.stylo, base.Location.X + 29, base.Location.Y + 22, base.Location.X + 29, base.Location.Y + 26);
						g.DrawLine(this.stylo, base.Location.X + 30, base.Location.Y + 23, base.Location.X + 30, base.Location.Y + 25);
					}
				}
				if (this.trs.ReglesFiltrage.Count > 0)
				{
					g.DrawLine(this.stylo, base.Location.X + 19, base.Location.Y + 18, base.Location.X + 19, base.Location.Y + 26);
					g.DrawLine(this.stylo, base.Location.X + 18, base.Location.Y + 18, base.Location.X + 19, base.Location.Y + 18);
					g.DrawLine(this.stylo, base.Location.X + 18, base.Location.Y + 20, base.Location.X + 19, base.Location.Y + 20);
					g.DrawLine(this.stylo, base.Location.X + 18, base.Location.Y + 22, base.Location.X + 19, base.Location.Y + 22);
					g.DrawLine(this.stylo, base.Location.X + 18, base.Location.Y + 24, base.Location.X + 19, base.Location.Y + 24);
					g.DrawLine(this.stylo, base.Location.X + 18, base.Location.Y + 26, base.Location.X + 19, base.Location.Y + 26);
				}
			}
			foreach (object obj in base.Controls)
			{
				PointConnexion pointConnexion = (PointConnexion)obj;
				pointConnexion.Dessiner(g);
			}
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x0003057C File Offset: 0x0002F57C
		public override void Tracer(Graphics g)
		{
			g.DrawRectangle(this.stylo, 0, 0, 38, 33);
			g.DrawRectangle(this.styloRelief, 2, 2, 34, 29);
			g.DrawRectangle(this.stylo, 4, 4, 30, 25);
			g.DrawString(this.nomNoeud, this.police, this.stylo.Brush, new RectangleF(5f, 4f, 32f, 25f));
			g.DrawRectangle(this.stylo, 0, 35, 38, 14);
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x00030608 File Offset: 0x0002F608
		public override void Effacer(Graphics g)
		{
			g.DrawRectangle(this.reseau.StyloEfface, 0, 0, 38, 33);
			g.DrawRectangle(this.reseau.StyloEfface, 2, 2, 34, 29);
			g.DrawRectangle(this.reseau.StyloEfface, 4, 4, 30, 25);
			g.DrawString(this.nomNoeud, this.police, this.reseau.StyloEfface.Brush, new RectangleF(5f, 4f, 32f, 25f));
			g.DrawRectangle(this.reseau.StyloEfface, 0, 35, 38, 14);
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x000306B0 File Offset: 0x0002F6B0
		protected void Station_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.DrawRectangle(this.stylo, 0, 0, 38, 33);
			graphics.DrawRectangle(this.styloRelief, 2, 2, 34, 29);
			graphics.DrawRectangle(this.stylo, 4, 4, 30, 25);
			graphics.DrawString(this.nomNoeud, this.police, this.stylo.Brush, new RectangleF(5f, 4f, 32f, 25f));
			if (this.reseau.ModeActif == Simulation.Mode.ip && this.reseau.Pref.Icones)
			{
				if (this.ip.RoutageActif)
				{
					graphics.DrawLine(this.stylo, 7, 18, 10, 21);
					graphics.DrawLine(this.stylo, 7, 26, 10, 23);
					graphics.DrawLine(this.stylo, 12, 21, 15, 18);
					graphics.DrawLine(this.stylo, 12, 23, 15, 26);
					graphics.DrawLine(this.stylo, 13, 18, 14, 18);
					graphics.DrawLine(this.stylo, 15, 19, 15, 20);
					graphics.DrawLine(this.stylo, 12, 24, 12, 25);
					graphics.DrawLine(this.stylo, 13, 23, 14, 23);
					graphics.DrawLine(this.stylo, 10, 19, 10, 20);
					graphics.DrawLine(this.stylo, 8, 21, 9, 21);
					graphics.DrawLine(this.stylo, 7, 24, 7, 25);
					graphics.DrawLine(this.stylo, 8, 26, 9, 26);
				}
				if (this.reseau.PseudoModeTransport)
				{
					if (this.trs.ReglesFiltrage.Count > 0)
					{
						graphics.DrawLine(this.stylo, 19, 18, 19, 26);
						graphics.DrawLine(this.stylo, 18, 18, 19, 18);
						graphics.DrawLine(this.stylo, 18, 20, 19, 20);
						graphics.DrawLine(this.stylo, 18, 22, 19, 22);
						graphics.DrawLine(this.stylo, 18, 24, 19, 24);
						graphics.DrawLine(this.stylo, 18, 26, 19, 26);
					}
					if (this.trs.NatPatActif)
					{
						graphics.DrawLine(this.stylo, 22, 24, 31, 24);
						graphics.DrawLine(this.stylo, 23, 23, 23, 25);
						graphics.DrawLine(this.stylo, 24, 22, 24, 26);
						graphics.DrawLine(this.stylo, 29, 22, 29, 26);
						graphics.DrawLine(this.stylo, 30, 23, 30, 25);
					}
				}
			}
			graphics.DrawRectangle(this.stylo, 0, 35, 38, 14);
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600046B RID: 1131 RVA: 0x00030970 File Offset: 0x0002F970
		public CarteAccesDistant AccesDistant
		{
			get
			{
				if (base.Controls[this.nbPointsConnexion - 1].GetType() == typeof(CarteAccesDistant))
				{
					return (CarteAccesDistant)base.Controls[this.nbPointsConnexion - 1];
				}
				return null;
			}
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x000309BC File Offset: 0x0002F9BC
		private int derniereCarteConnectee(int dernierPointConnexion)
		{
			int num = dernierPointConnexion;
			while (num > 0 && ((PointConnexion)base.Controls[num - 1]).Lien == null)
			{
				num--;
			}
			return num;
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x000309F0 File Offset: 0x0002F9F0
		public override void Configurer()
		{
			ConfigStation configStation = new ConfigStation();
			configStation.NomStation = this.nomNoeud;
			int num = 0;
			CarteAccesDistant accesDistant = this.AccesDistant;
			int num2;
			int i;
			if (accesDistant != null)
			{
				num2 = this.nbPointsConnexion - 1;
				i = 1;
				configStation.AccesDistant = true;
				if (accesDistant.Lien != null)
				{
					configStation.BloquerAccesDistant();
					num = accesDistant.NumeroOrdre;
				}
			}
			else
			{
				num2 = this.nbPointsConnexion;
				i = 0;
				configStation.AccesDistant = false;
			}
			configStation.NbCartes = num2;
			int num3 = this.derniereCarteConnectee(num2);
			configStation.NbCartesMini = Math.Max(1, num3);
			if (configStation.ShowDialog() == DialogResult.OK)
			{
				Rectangle rectangle = base.rectangleTrace();
				if (!base.modifierNom(configStation.NomStation))
				{
					MessageBox.Show("Changement de nom impossible, nom incorrect ou déjà existant !", "Modification non effectuée");
				}
				int nbCartes = configStation.NbCartes;
				int num4;
				if (configStation.AccesDistant)
				{
					num4 = 1;
				}
				else
				{
					num4 = 0;
				}
				SortedList reglesFiltrage = HashTableEdit.CopieProfonde(this.trs.ReglesFiltrage);
				if (num4 < i)
				{
					CarteReseau carteReseau = (CarteReseau)base.Controls[this.nbPointsConnexion - 1];
					if (!carteReseau.Ip.Adresse.Isnul())
					{
						this.ip.MajRoutesCarteSupprimee(carteReseau);
					}
					ReglesFiltrageEdit.MajCarteSupprimee(ref reglesFiltrage, carteReseau);
				}
				if (nbCartes < num2)
				{
					for (int j = num2 - 1; j >= nbCartes; j--)
					{
						CarteReseau carteReseau = (CarteReseau)base.Controls[j];
						if (!carteReseau.Ip.Adresse.Isnul())
						{
							this.ip.MajRoutesCarteSupprimee(carteReseau);
						}
						ReglesFiltrageEdit.MajCarteSupprimee(ref reglesFiltrage, carteReseau);
					}
				}
				this.trs.ReglesFiltrage = reglesFiltrage;
				if (nbCartes != num2 || num4 != i)
				{
					ArrayList arrayList = new ArrayList();
					foreach (object obj in base.Controls)
					{
						PointConnexion value = (PointConnexion)obj;
						arrayList.Add(value);
					}
					this.nbPointsConnexion = 0;
					base.Controls.Clear();
					int k;
					for (k = 0; k < num3; k++)
					{
						base.AjouterPointConnexion((PointConnexion)arrayList[k]);
					}
					while (k < nbCartes)
					{
						if (k < arrayList.Count && arrayList[k].GetType() != typeof(CarteAccesDistant))
						{
							base.AjouterPointConnexion((PointConnexion)arrayList[k]);
						}
						else
						{
							base.AjouterPointConnexion(new CarteReseau(this.reseau));
						}
						k++;
					}
					i = 0;
					for (k = num2; k < num; k++)
					{
						base.AjouterPointConnexion((PointConnexion)arrayList[k]);
						i++;
					}
					while (i < num4)
					{
						if (k < arrayList.Count)
						{
							base.AjouterPointConnexion((PointConnexion)arrayList[k]);
						}
						else
						{
							base.AjouterPointConnexion(new CarteAccesDistant(this.reseau));
						}
						i++;
						k++;
					}
				}
				if (this.trs.NatPatActif)
				{
					bool flag = false;
					foreach (object obj2 in base.Controls)
					{
						CarteReseau carteReseau2 = (CarteReseau)obj2;
						if (carteReseau2 == this.trs.CarteQuiNat)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						this.trs.NatPatActif = false;
						this.trs.CarteQuiNat = null;
					}
				}
				if (this.nbPointsConnexion < 2)
				{
					this.ip.RoutageActif = false;
					this.trs.NatPatActif = false;
				}
				base.Invalidate();
				rectangle = Rectangle.Union(rectangle, base.rectangleTrace());
				this.reseau.Schema.Invalidate(rectangle, false);
				this.reseau.GereDoc.FaireAction(ActionDocument.modifier);
			}
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00030DE4 File Offset: 0x0002FDE4
		public override void StockerXml(XmlTextWriter writer)
		{
			writer.WriteStartElement("station");
			writer.WriteAttributeString("nomNoeud", this.nomNoeud.ToString());
			base.StockerXml(writer);
			this.ip.StockerXml(writer);
			writer.WriteElementString("AccesDistant", (this.AccesDistant != null).ToString());
			foreach (object obj in base.Controls)
			{
				CarteReseau carteReseau = (CarteReseau)obj;
				carteReseau.StockerXml(writer);
			}
			writer.WriteEndElement();
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00030EA4 File Offset: 0x0002FEA4
		protected override void eteindreIp()
		{
			this.ip.eteindre();
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00030EBC File Offset: 0x0002FEBC
		public override void ChangerMode(Simulation.Mode nouveauMode)
		{
			if (this.reseau.ModeActif == Simulation.Mode.ip)
			{
				this.trs.ViderInfosTrs();
			}
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
			foreach (object obj in base.Controls)
			{
				CarteReseau carteReseau = (CarteReseau)obj;
				carteReseau.ChangerMode(nouveauMode);
			}
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00030F90 File Offset: 0x0002FF90
		public override void SetContenuInfoBulle()
		{
			string caption = "Passerelle : " + this.ip.Passerelle.ToString();
			this.infoBulle.SetToolTip(this, caption);
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00030FC8 File Offset: 0x0002FFC8
		protected override void mi_allumer_Click(object sender, EventArgs e)
		{
			this.Allumer();
			base.EnFonction = true;
			if (this.reseau.Pref.AnnonceStations)
			{
				foreach (object obj in this.reseau.Schema.Controls)
				{
					ElementReseau elementReseau = (ElementReseau)obj;
					if (elementReseau.GetType() == typeof(Switch))
					{
						((Switch)elementReseau).DecouvrirReseau(this);
					}
				}
			}
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x00031070 File Offset: 0x00030070
		private void mi_configIp_Click(object sender, EventArgs e)
		{
			Ip_ConfigIpStation ip_ConfigIpStation = new Ip_ConfigIpStation(this, new SuiteOk(this.ControleIpStation));
			ip_ConfigIpStation.NomHote = this.nomNoeud;
			ip_ConfigIpStation.Passerelle = this.ip.Passerelle.ToString();
			ip_ConfigIpStation.ActiverRoutage = this.ip.RoutageActif;
			ip_ConfigIpStation.ActiverNatPat = this.trs.NatPatActif;
			ip_ConfigIpStation.ServeurDns = this.ip.ServeurDns.ToString();
			int num = 1;
			int num2 = 0;
			foreach (object obj in base.Controls)
			{
				CarteReseau carteReseau = (CarteReseau)obj;
				if (carteReseau == this.trs.CarteQuiNat)
				{
					num2 = num;
				}
				ip_ConfigIpStation.Interfaces.Items.Add(string.Concat(new string[]
				{
					num.ToString(),
					"  ",
					carteReseau.AdresseMac,
					"  ",
					carteReseau.Ip.Adresse.ToString(),
					" (",
					carteReseau.Ip.Masque.ToString(),
					") ",
					carteReseau.Protocole
				}));
				num++;
			}
			if (this.reseau.PseudoModeTransport)
			{
				ip_ConfigIpStation.ConfigPseudoMode(false);
				ip_ConfigIpStation.SetCarteQuiNat(num2 - 1);
			}
			else
			{
				ip_ConfigIpStation.ConfigPseudoMode(true);
			}
			if (base.Controls.Count < 2)
			{
				ip_ConfigIpStation.ActiverRoutage = false;
				ip_ConfigIpStation.ActiverRoutageEnabled = false;
				ip_ConfigIpStation.ActiverNatPat = false;
				ip_ConfigIpStation.ActiverNatPatEnabled = false;
			}
			else
			{
				ip_ConfigIpStation.ActiverRoutageEnabled = true;
				ip_ConfigIpStation.ActiverNatPatEnabled = this.ip.RoutageActif;
			}
			ip_ConfigIpStation.Show();
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x0003125C File Offset: 0x0003025C
		public void ControleIpStation(object p_dialogue)
		{
			this.reseau.BloquerBisIp();
			bool flag = true;
			Ip_ConfigIpStation ip_ConfigIpStation = (Ip_ConfigIpStation)p_dialogue;
			if (ip_ConfigIpStation.Passerelle == "")
			{
				ip_ConfigIpStation.Passerelle = "0.0.0.0";
			}
			if (ip_ConfigIpStation.ServeurDns == "")
			{
				ip_ConfigIpStation.ServeurDns = "0.0.0.0";
			}
			bool flag2 = true;
			if (ip_ConfigIpStation.Passerelle != "0.0.0.0" && Ip_adresse.Ok(ip_ConfigIpStation.Passerelle))
			{
				CarteReseau carteReseau = this.ip.TrouverCarteMemeReseau(new Ip_adresse(ip_ConfigIpStation.Passerelle));
				flag2 = (carteReseau != null);
			}
			if (!flag2 || !Ip_adresse.Ok(ip_ConfigIpStation.Passerelle) || !Ip_adresse.Ok(ip_ConfigIpStation.ServeurDns))
			{
				flag = false;
				MessageBox.Show("Erreur de configuration !");
			}
			else if (ip_ConfigIpStation.NomHote != this.nomNoeud && !base.modifierNom(ip_ConfigIpStation.NomHote))
			{
				MessageBox.Show("Nom incorrect ou déjà existant !");
				flag = false;
			}
			if (flag)
			{
				this.ip.Passerelle = new Ip_adresse(ip_ConfigIpStation.Passerelle);
				if (this.ip.Passerelle.Isnul())
				{
					this.ip.supprimerRoute("0.0.0.0");
				}
				this.ip.MajRoutes(this.ip.Passerelle);
				this.ip.RoutageActif = ip_ConfigIpStation.ActiverRoutage;
				this.trs.NatPatActif = ip_ConfigIpStation.ActiverNatPat;
				int num = 1;
				if (this.trs.NatPatActif)
				{
					using (IEnumerator enumerator = base.Controls.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							CarteReseau carteQuiNat = (CarteReseau)obj;
							if (num - 1 == ip_ConfigIpStation.Interfaces.SelectedIndex)
							{
								this.trs.CarteQuiNat = carteQuiNat;
							}
							num++;
						}
						goto IL_1EB;
					}
				}
				NatPatEdit.SupprimerNatPats(this.trs.NatPat);
				this.trs.CarteQuiNat = null;
				IL_1EB:
				this.ip.ServeurDns = new Ip_adresse(ip_ConfigIpStation.ServeurDns);
				this.reseau.GereDoc.FaireAction(ActionDocument.modifier);
				this.SetContenuInfoBulle();
				base.Invalidate();
				ip_ConfigIpStation.Close();
			}
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x000314AC File Offset: 0x000304AC
		public void SetOptionsModeIp(bool ipMode)
		{
			if (ipMode)
			{
				this.mi_tablesIp.Visible = true;
				this.mi_tablesTrs.Visible = false;
				this.mi_viderCacheArp.Visible = true;
				this.mi_echangesEnCours.Visible = false;
				this.mi_ping.Visible = true;
				this.mi_envoyerRequete.Visible = false;
				this.mi_repondreClient.Visible = false;
			}
			else
			{
				this.mi_tablesIp.Visible = false;
				this.mi_tablesTrs.Visible = true;
				this.mi_viderCacheArp.Visible = false;
				this.mi_echangesEnCours.Visible = true;
				this.mi_ping.Visible = false;
				this.mi_envoyerRequete.Visible = true;
				this.mi_repondreClient.Visible = true;
			}
			base.Invalidate();
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0003156C File Offset: 0x0003056C
		protected override ContextMenu menuIp()
		{
			Simulation.EtatIp etatIpActif = this.reseau.EtatIpActif;
			ContextMenu result;
			if (etatIpActif == Simulation.EtatIp.attente)
			{
				if (this.mi_eteindre.Enabled)
				{
					this.mi_tableNatPat.Enabled = this.trs.NatPatActif;
					result = this.cm_ip;
				}
				else
				{
					result = this.cm_ethernetEteint;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x000315C4 File Offset: 0x000305C4
		protected override ContextMenu menuAppl()
		{
			Simulation.EtatAppl etatApplActif = this.reseau.EtatApplActif;
			ContextMenu result;
			if (etatApplActif == Simulation.EtatAppl.attente)
			{
				if (this.mi_eteindre.Enabled)
				{
					result = this.cm_appl;
				}
				else
				{
					result = this.cm_ethernetEteint;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00031604 File Offset: 0x00030604
		private void mi_tableRoutage_Click(object sender, EventArgs e)
		{
			DialogueRoute dialogueRoute = new DialogueRoute("Table de routage " + this.nomNoeud, this.ip);
			dialogueRoute.Size = new Size(DialogueRoute.Largeur, this.ip.HauteurTableRoutage);
			dialogueRoute.InScreen();
			dialogueRoute.Show();
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x00031654 File Offset: 0x00030654
		private void mi_cacheArp_Click(object sender, EventArgs e)
		{
			DialogueCacheArp dialogueCacheArp = new DialogueCacheArp("Cache ARP " + this.nomNoeud, this.ip);
			dialogueCacheArp.Size = new Size(DialogueCacheArp.Largeur, this.ip.HauteurCacheArp);
			dialogueCacheArp.InScreen();
			dialogueCacheArp.Show();
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x000316A4 File Offset: 0x000306A4
		private void mi_ping_Click(object sender, EventArgs e)
		{
			this.reseau.BisIpEnCours = false;
			this.ip.EnvoyerPing();
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x000316C8 File Offset: 0x000306C8
		private void mi_viderCacheArp_Click(object sender, EventArgs e)
		{
			this.ip.CacheArp = new SortedList();
			this.ip.St.Reseau.BloquerBisIp();
			this.ip.St.Reseau.GereDoc.FaireAction(ActionDocument.modifier);
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600047C RID: 1148 RVA: 0x00031718 File Offset: 0x00030718
		public Ip_station Ip
		{
			get
			{
				return this.ip;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600047D RID: 1149 RVA: 0x0003172C File Offset: 0x0003072C
		public Ap_station Ap
		{
			get
			{
				return this.ap;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600047E RID: 1150 RVA: 0x00031740 File Offset: 0x00030740
		public Trs_station Trs
		{
			get
			{
				return this.trs;
			}
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00031754 File Offset: 0x00030754
		public override void TransmissionRapideEthernet(bool demo, PointConnexion demandeur, Ip_PaquetIp paquet, bool suivreLiensPortsEteints, ReactionStation rs, ReactionSwitch rsw)
		{
			if (rs != null)
			{
				rs(this, (CarteReseau)demandeur, paquet);
			}
			if (((CarteReseau)demandeur).Ip.Adresse.ToString() == paquet.AdrDest.ToString())
			{
				paquet.RouteOk = true;
			}
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x000317A4 File Offset: 0x000307A4
		public static void ReactionMajCacheArp(Station st, CarteReseau c, Ip_PaquetIp paquet)
		{
			if (!c.Ip.Adresse.Isnul())
			{
				st.ip.AjoutCacheArp(paquet.AdrSource, paquet.MacSource, c, paquet.Donnees);
			}
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x000317E4 File Offset: 0x000307E4
		public static void ReactionRenseignerAdrArp(Station st, CarteReseau c, Ip_PaquetIp paquet)
		{
			if (c.Ip.Adresse.ToString() == paquet.AdrDest.ToString())
			{
				paquet.StationSource.ip.AdrMacReponseArp = c.AdresseMac;
			}
			c.Ip.Args = new ArrayList();
			c.Ip.Args.Add(st);
			c.Ip.Args.Add(paquet);
			if (st.Reseau.TypeDemoIp != Simulation.TypeDeDemo.noDemo && st.Reseau.DemoArp && Ip_station.NbStationsConcernes > 0)
			{
				c.Ip.ReagirArpRequest(paquet);
				c.Demo.DemoTerminee += Station.Demo_DemoArpTerminee;
				return;
			}
			Station.Demo_DemoArpTerminee(c, new EventArgs());
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x000318B0 File Offset: 0x000308B0
		private static void Demo_DemoArpTerminee(object sender, EventArgs e)
		{
			CarteReseau carteReseau = (CarteReseau)sender;
			Station station = (Station)carteReseau.Ip.Args[0];
			Ip_PaquetIp ip_PaquetIp = (Ip_PaquetIp)carteReseau.Ip.Args[1];
			if (carteReseau.Demo != null)
			{
				carteReseau.Demo.DemoTerminee -= Station.Demo_DemoArpTerminee;
			}
			station.ip.AjoutCacheArp(ip_PaquetIp.AdrSource, ip_PaquetIp.MacSource, carteReseau, "Dyn.");
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x00031930 File Offset: 0x00030930
		public static void ReactionCompterStations(Station st, CarteReseau c, Ip_PaquetIp paquet)
		{
			Ip_station.NbStationsConcernes++;
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x0003194C File Offset: 0x0003094C
		public static void ReactionValiderRoute(Station st, CarteReseau c, Ip_PaquetIp paquet)
		{
			if (c.NoeudAttache == paquet.CarteDest.NoeudAttache && paquet.CarteDest.EtatConnexion == PointConnexion.EtatsConnexion.actif)
			{
				paquet.StationSource.ip.OkRouteIp = true;
				return;
			}
			if (st.ip.RoutageActif && paquet.NbSauts > 0)
			{
				CarteReseau carteReseau = null;
				string text = null;
				st.ip.TrouverRoute(paquet.AdrDest, ref carteReseau, ref text);
				if (carteReseau != null)
				{
					CarteReseau carteReseau2 = carteReseau;
					if (text != null)
					{
						CarteReseau carteReseau3 = Ip_station.TrouverCarteIpDansReseau(st.Reseau.Schema, text);
						((Station)carteReseau2.NoeudAttache).Ip.OkRouteIp = false;
						if (carteReseau3 != null && carteReseau3.EtatConnexion == PointConnexion.EtatsConnexion.actif)
						{
							Ip_PaquetIp paquet2 = new Ip_PaquetIp(carteReseau2, carteReseau3, carteReseau3.Ip.Adresse, TypeDePaquetIp.Aucun, "");
							carteReseau2.Lien.TransmissionRapideEthernet(false, carteReseau2, paquet2, false, new ReactionStation(Station.ReactionValiderRoute), null);
						}
					}
					if ((text == null || ((Station)carteReseau2.NoeudAttache).Ip.OkRouteIp) && carteReseau != c && carteReseau.EtatConnexion == PointConnexion.EtatsConnexion.actif)
					{
						paquet.NbSauts--;
						if (carteReseau == paquet.CarteDest)
						{
							paquet.StationSource.ip.OkRouteIp = true;
							paquet.RouteOk = true;
							return;
						}
						carteReseau.Lien.TransmissionRapideEthernet(false, carteReseau, paquet, false, new ReactionStation(Station.ReactionValiderRoute), null);
						if (paquet.RouteOk)
						{
							paquet.Route.Add(st);
						}
					}
				}
			}
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x00031AC0 File Offset: 0x00030AC0
		private void mi_envoyerMessage_Click(object sender, EventArgs e)
		{
			this.ap.EnvoyerMessage();
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x00031AD8 File Offset: 0x00030AD8
		private void mi_fichierHosts_Click(object sender, EventArgs e)
		{
			DialogueFichierHosts dialogueFichierHosts = new DialogueFichierHosts("Fichier hosts " + this.nomNoeud, this.ip);
			dialogueFichierHosts.Size = new Size(DialogueFichierHosts.Largeur, this.ip.HauteurFichierHosts);
			dialogueFichierHosts.InScreen();
			dialogueFichierHosts.Show();
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00031B28 File Offset: 0x00030B28
		private void mi_portsEcoutes_Click(object sender, EventArgs e)
		{
			DialoguePortsEcoutes dialoguePortsEcoutes = new DialoguePortsEcoutes("Ports écoutés " + this.nomNoeud, this.trs);
			dialoguePortsEcoutes.Size = new Size(DialoguePortsEcoutes.Largeur, this.trs.HauteurPortsEcoutes);
			dialoguePortsEcoutes.InScreen();
			dialoguePortsEcoutes.Show();
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00031B78 File Offset: 0x00030B78
		private void mi_tableNatPat_Click(object sender, EventArgs e)
		{
			DialogueNatPat dialogueNatPat = new DialogueNatPat("Table Nat/Pat " + this.nomNoeud, this.trs);
			dialogueNatPat.Size = new Size(DialogueNatPat.Largeur, this.trs.HauteurNatPat);
			dialogueNatPat.InScreen();
			dialogueNatPat.Show();
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x00031BC8 File Offset: 0x00030BC8
		private void mi_envoyerRequete_Click(object sender, EventArgs e)
		{
			this.reseau.BisIpEnCours = false;
			this.trs.EnvoyerTrs(false);
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x00031BF0 File Offset: 0x00030BF0
		private void mi_echangesEnCours_Click(object sender, EventArgs e)
		{
			DialogueReqTrs dialogueReqTrs = new DialogueReqTrs("Echanges en cours " + this.nomNoeud, this.trs);
			dialogueReqTrs.InScreen();
			dialogueReqTrs.Show();
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x00031C28 File Offset: 0x00030C28
		private void mi_repondreRequete_Click(object sender, EventArgs e)
		{
			this.reseau.BisIpEnCours = false;
			this.trs.EnvoyerTrs(true);
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x00031C50 File Offset: 0x00030C50
		private void mi_reglesFiltrage_Click(object sender, EventArgs e)
		{
			DialogueReglesFiltrage dialogueReglesFiltrage = new DialogueReglesFiltrage("Règles de filtrage " + this.nomNoeud, this.trs);
			dialogueReglesFiltrage.Size = new Size(DialogueReglesFiltrage.Largeur, this.trs.HauteurReglesFiltrage);
			dialogueReglesFiltrage.InScreen();
			dialogueReglesFiltrage.Show();
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600048D RID: 1165 RVA: 0x00031CA0 File Offset: 0x00030CA0
		public MessageSt Message
		{
			get
			{
				return this.message;
			}
		}

		// Token: 0x04000334 RID: 820
		private IContainer components = null;

		// Token: 0x04000335 RID: 821
		private MenuItem menuItem1;

		// Token: 0x04000336 RID: 822
		private MenuItem mi_configIp;

		// Token: 0x04000337 RID: 823
		private MenuItem mi_ping;

		// Token: 0x04000338 RID: 824
		private MenuItem menuItem2;

		// Token: 0x04000339 RID: 825
		private MenuItem mi_envoyerMessage;

		// Token: 0x0400033A RID: 826
		protected Ip_station ip;

		// Token: 0x0400033B RID: 827
		private Ap_station ap;

		// Token: 0x0400033C RID: 828
		private MenuItem mi_repondreClient;

		// Token: 0x0400033D RID: 829
		private MenuItem mi_envoyerRequete;

		// Token: 0x0400033E RID: 830
		private MenuItem mi_cacheArp;

		// Token: 0x0400033F RID: 831
		private MenuItem mi_viderCacheArp;

		// Token: 0x04000340 RID: 832
		private MenuItem mi_reglesFiltrage;

		// Token: 0x04000341 RID: 833
		private MenuItem mi_tableNatPat;

		// Token: 0x04000342 RID: 834
		private MenuItem mi_echangesEnCours;

		// Token: 0x04000343 RID: 835
		private MenuItem menuItem3;

		// Token: 0x04000344 RID: 836
		private MenuItem menuItem4;

		// Token: 0x04000345 RID: 837
		private MenuItem mi_separIp;

		// Token: 0x04000346 RID: 838
		private MenuItem mi_tablesIp;

		// Token: 0x04000347 RID: 839
		private MenuItem mi_portsEcoutes;

		// Token: 0x04000348 RID: 840
		private MenuItem mi_tablesTrs;

		// Token: 0x04000349 RID: 841
		private MenuItem mi_tableRoutageTrs;

		// Token: 0x0400034A RID: 842
		private MenuItem mi_fichierHostsTrs;

		// Token: 0x0400034B RID: 843
		private MenuItem mi_tableRoutageIp;

		// Token: 0x0400034C RID: 844
		private MenuItem mi_fichierHostsIp;

		// Token: 0x0400034D RID: 845
		private Trs_station trs;

		// Token: 0x0400034E RID: 846
		private MessageSt message;
	}
}
