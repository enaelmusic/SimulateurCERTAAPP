using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Simulateur
{
	// Token: 0x0200004F RID: 79
	public class Interconnexion : Noeud
	{
		// Token: 0x06000416 RID: 1046 RVA: 0x0002D660 File Offset: 0x0002C660
		public Interconnexion()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x0002D6A0 File Offset: 0x0002C6A0
		public Interconnexion(Simulation s, string nom) : base(s)
		{
			this.InitializeComponent();
			this.initialiser(nom);
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x0002D6E8 File Offset: 0x0002C6E8
		private void initialiser(string nom)
		{
			Graphics graphics = base.CreateGraphics();
			base.Height = (int)graphics.MeasureString("I", this.police).Height + 16;
			this.nomNoeud = nom;
			graphics.Dispose();
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x0002D72C File Offset: 0x0002C72C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x0002D758 File Offset: 0x0002C758
		private void InitializeComponent()
		{
			base.Name = "Interconnexion";
			base.Size = new Size(24, 62);
			base.Paint += this.Interconnexion_Paint;
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x0002D794 File Offset: 0x0002C794
		protected void CalculerLargeur()
		{
			Graphics graphics = this.reseau.Schema.CreateGraphics();
			base.Width = Math.Max((int)graphics.MeasureString(this.etiquette + this.nomNoeud, this.police).Width, 12 * this.nbPointsConnexion + 3);
			graphics.Dispose();
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x0002D7F4 File Offset: 0x0002C7F4
		public override void Dessiner(Graphics g)
		{
			g.FillRectangle(Brushes.White, base.Location.X, base.Location.Y, base.Width, base.Height);
			g.DrawRectangle(this.stylo, base.Location.X, base.Location.Y, base.Width - 1, base.Height - 1);
			g.DrawString(this.etiquette + this.nomNoeud, this.police, this.stylo.Brush, (float)(base.Location.X + 1), (float)(base.Location.Y + 2));
			foreach (object obj in base.Controls)
			{
				PointConnexion pointConnexion = (PointConnexion)obj;
				pointConnexion.Dessiner(g);
			}
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x0002D910 File Offset: 0x0002C910
		protected virtual void Interconnexion_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.DrawRectangle(this.stylo, 0, 0, base.Width - 1, base.Height - 1);
			graphics.DrawString(this.etiquette + this.nomNoeud, this.police, this.stylo.Brush, 1f, 2f);
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x0002D974 File Offset: 0x0002C974
		public virtual Port nouveauPort()
		{
			return new Port(this.reseau);
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0002D98C File Offset: 0x0002C98C
		public virtual Port nouveauPortDeCascade()
		{
			return new Port(this.reseau);
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x0002D9A4 File Offset: 0x0002C9A4
		public virtual Port nouveauPort8021q()
		{
			return new Port(this.reseau);
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0002D9BC File Offset: 0x0002C9BC
		public virtual Port nouveauPortFai()
		{
			return new Port(this.reseau);
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x0002D9D4 File Offset: 0x0002C9D4
		public void InitialiserPorts(int nbPortsNormaux, int nbCascade, int nb8021q)
		{
			this.nbPortsCascade = nbCascade;
			this.nbPorts = nbPortsNormaux;
			this.nbPorts8021q = nb8021q;
			for (int i = 0; i < this.nbPorts; i++)
			{
				base.AjouterPointConnexion(this.nouveauPort());
			}
			for (int j = 0; j < this.nbPortsCascade; j++)
			{
				base.AjouterPointConnexion(this.nouveauPortDeCascade());
			}
			for (int k = 0; k < this.nbPorts8021q; k++)
			{
				base.AjouterPointConnexion(this.nouveauPort8021q());
			}
			this.CalculerLargeur();
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x0002DA54 File Offset: 0x0002CA54
		public int NbPorts8021q
		{
			get
			{
				return this.nbPorts8021q;
			}
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x0002DA68 File Offset: 0x0002CA68
		protected int dernierPortConnecte()
		{
			int num = this.nbPointsConnexion - this.nbPortsCascade - this.nbPorts8021q;
			while (num > 0 && ((PointConnexion)base.Controls[num - 1]).Lien == null)
			{
				num--;
			}
			return num;
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x0002DAB0 File Offset: 0x0002CAB0
		protected int dernierPortCascadeConnecte()
		{
			int num = this.nbPointsConnexion - this.nbPorts8021q;
			while (num > this.nbPointsConnexion - this.nbPortsCascade - this.nbPorts8021q && ((PointConnexion)base.Controls[num - 1]).Lien == null)
			{
				num--;
			}
			return num;
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0002DB04 File Offset: 0x0002CB04
		protected int dernierPort8021qConnecte()
		{
			int num = this.nbPointsConnexion;
			while (num > this.nbPointsConnexion - this.nbPorts8021q && ((PointConnexion)base.Controls[num - 1]).Lien == null)
			{
				num--;
			}
			return num;
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x0002DB4C File Offset: 0x0002CB4C
		protected bool ConfigurerGraphique(ConfigInterConnexion dialogue)
		{
			int num = this.dernierPortConnecte();
			int num2 = this.dernierPortCascadeConnecte();
			int num3 = this.dernierPort8021qConnecte();
			dialogue.Nom = this.nomNoeud;
			dialogue.NbPorts = this.nbPointsConnexion - this.nbPortsCascade - this.nbPorts8021q;
			dialogue.NbPortsMini = Math.Max(2, num);
			dialogue.NbPortsCascade = this.nbPortsCascade;
			dialogue.NbPortsCascadeMini = num2 - this.nbPorts;
			dialogue.NbPorts8021q = this.nbPorts8021q;
			dialogue.NbPorts8021qMini = num3 - this.nbPorts - this.nbPortsCascade;
			if (dialogue.ShowDialog() == DialogResult.OK)
			{
				Rectangle rectangle = base.rectangleTrace();
				if (!base.modifierNom(dialogue.Nom))
				{
					MessageBox.Show("Changement de nom impossible, nom incorrect ou déjà existant !", "Modification non effectuée");
				}
				if (dialogue.NbPorts != this.nbPorts || dialogue.NbPortsCascade != this.nbPortsCascade || dialogue.NbPorts8021q != this.nbPorts8021q)
				{
					ArrayList arrayList = new ArrayList();
					foreach (object obj in base.Controls)
					{
						PointConnexion value = (PointConnexion)obj;
						arrayList.Add(value);
					}
					this.nbPointsConnexion = 0;
					int num4 = this.nbPorts + this.nbPortsCascade;
					base.Controls.Clear();
					int i;
					for (i = 0; i < num; i++)
					{
						base.AjouterPointConnexion((Port)arrayList[i]);
					}
					while (i < dialogue.NbPorts)
					{
						base.AjouterPointConnexion(this.nouveauPort());
						i++;
					}
					this.nbPortsCascade = 0;
					for (i = this.nbPorts; i < num2; i++)
					{
						base.AjouterPointConnexion((Port)arrayList[i]);
						this.nbPortsCascade++;
					}
					while (this.nbPortsCascade < dialogue.NbPortsCascade)
					{
						base.AjouterPointConnexion(this.nouveauPortDeCascade());
						this.nbPortsCascade++;
					}
					this.nbPorts8021q = 0;
					for (i = num4; i < num3; i++)
					{
						base.AjouterPointConnexion((Port)arrayList[i]);
						this.nbPorts8021q++;
					}
					while (this.nbPorts8021q < dialogue.NbPorts8021q)
					{
						base.AjouterPointConnexion(this.nouveauPort8021q());
						this.nbPorts8021q++;
					}
					this.nbPorts = dialogue.NbPorts;
				}
				this.CalculerLargeur();
				base.Location = this.reseau.positionOk(base.Size, base.Location);
				base.Invalidate();
				rectangle = Rectangle.Union(rectangle, base.rectangleTrace());
				this.reseau.Schema.Invalidate(rectangle, false);
				this.reseau.GereDoc.FaireAction(ActionDocument.modifier);
				return true;
			}
			return false;
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0002DE3C File Offset: 0x0002CE3C
		public override void InstallerGestionEvenements()
		{
			foreach (object obj in base.Controls)
			{
				Port port = (Port)obj;
				if (port.Lien != null)
				{
					port.InstallerGestionEvenements();
					port.TrameTransmise += this.InterConn_TrameTransmise;
					port.FinTrameTransmis += this.InterConn_FinTrameTransmis;
					port.DebutTrameTransmis += this.InterConn_DebutTrameTransmis;
				}
			}
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0002DEE4 File Offset: 0x0002CEE4
		public override void DesinstallerGestionEvenements()
		{
			foreach (object obj in base.Controls)
			{
				Port port = (Port)obj;
				if (port.Lien != null)
				{
					port.DesinstallerGestionEvenements();
					port.TrameTransmise -= this.InterConn_TrameTransmise;
					port.FinTrameTransmis -= this.InterConn_FinTrameTransmis;
					port.DebutTrameTransmis -= this.InterConn_DebutTrameTransmis;
				}
			}
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0002DF8C File Offset: 0x0002CF8C
		protected virtual void InterConn_TrameTransmise(ElementReseau sender, TrameEventArgs e)
		{
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x0002DF9C File Offset: 0x0002CF9C
		protected virtual void InterConn_FinTrameTransmis(ElementReseau sender, TrameEventArgs e)
		{
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x0002DFAC File Offset: 0x0002CFAC
		protected virtual void InterConn_DebutTrameTransmis(ElementReseau sender, TrameEventArgs e)
		{
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x0002DFBC File Offset: 0x0002CFBC
		public override bool EstConnecte(PointConnexion source, PointConnexion cible, ref ArrayList portsVisites, bool okSwitch)
		{
			bool flag = false;
			if (okSwitch || !this.reseau.SommetsSwitch.Contains(this))
			{
				int num = 0;
				while (num < base.Controls.Count && !flag)
				{
					PointConnexion pointConnexion = (PointConnexion)base.Controls[num];
					if (pointConnexion != source && pointConnexion.EtatConnexion == PointConnexion.EtatsConnexion.actif && !portsVisites.Contains(pointConnexion))
					{
						flag = pointConnexion.EstConnecte(cible, ref portsVisites, okSwitch);
					}
					num++;
				}
			}
			return flag;
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0002E030 File Offset: 0x0002D030
		public override bool EstRelie(PointConnexion source, PointConnexion cible, ref ArrayList visites)
		{
			bool flag = false;
			int num = 0;
			while (num < base.Controls.Count && !flag)
			{
				PointConnexion pointConnexion = (PointConnexion)base.Controls[num];
				if (pointConnexion != source && pointConnexion.EtatConnexion == PointConnexion.EtatsConnexion.actif && !visites.Contains(pointConnexion))
				{
					flag = pointConnexion.EstRelie(cible, ref visites);
				}
				num++;
			}
			return flag;
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0002E08C File Offset: 0x0002D08C
		public override void ModeDeuxPaires(PointConnexion source, ref ArrayList cablesVus)
		{
			foreach (object obj in base.Controls)
			{
				PointConnexion pointConnexion = (PointConnexion)obj;
				if (pointConnexion != source && pointConnexion.EtatConnexion == PointConnexion.EtatsConnexion.actif && !cablesVus.Contains(pointConnexion.Lien))
				{
					pointConnexion.Lien.ModeDeuxPaires();
					cablesVus.Add(pointConnexion.Lien);
					pointConnexion.Lien.Oppose(pointConnexion).NoeudAttache.ModeDeuxPaires(pointConnexion, ref cablesVus);
				}
			}
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x0002E138 File Offset: 0x0002D138
		public override void ModeCableSimple(PointConnexion source, ref ArrayList cablesVus)
		{
			foreach (object obj in base.Controls)
			{
				PointConnexion pointConnexion = (PointConnexion)obj;
				if (pointConnexion != source && pointConnexion.EtatConnexion == PointConnexion.EtatsConnexion.actif && !cablesVus.Contains(pointConnexion.Lien))
				{
					pointConnexion.Lien.ModeCableSimple();
					cablesVus.Add(pointConnexion.Lien);
					pointConnexion.Lien.Oppose(pointConnexion).NoeudAttache.ModeCableSimple(pointConnexion, ref cablesVus);
				}
			}
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x0002E1E4 File Offset: 0x0002D1E4
		protected override void mi_eteindre_Click(object sender, EventArgs e)
		{
			this.Eteindre();
			base.EnFonction = false;
			this.reseau.SpanningTree();
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x0002E20C File Offset: 0x0002D20C
		public override void Eteindre()
		{
			base.Eteindre();
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x0002E220 File Offset: 0x0002D220
		protected override void mi_allumer_Click(object sender, EventArgs e)
		{
			this.Allumer();
			base.EnFonction = true;
			this.reseau.SpanningTree();
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x0002E248 File Offset: 0x0002D248
		public override void Allumer()
		{
			base.Allumer();
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x0002E25C File Offset: 0x0002D25C
		public override void StockerXml(XmlTextWriter writer)
		{
			int num = this.nbPorts;
			int num2 = this.nbPortsCascade;
			writer.WriteAttributeString("nomNoeud", this.nomNoeud.ToString());
			base.StockerXml(writer);
			writer.WriteElementString("nbPortsNormaux", num.ToString());
			writer.WriteElementString("nbPortsCascade", num2.ToString());
		}

		// Token: 0x0400031A RID: 794
		private IContainer components = null;

		// Token: 0x0400031B RID: 795
		protected string etiquette = "";

		// Token: 0x0400031C RID: 796
		protected int nbPorts8021q = 0;

		// Token: 0x0400031D RID: 797
		protected int nbPortsCascade = 0;

		// Token: 0x0400031E RID: 798
		protected int nbPorts = 0;
	}
}
