using System;
using System.Collections;
using System.Xml;

namespace Simulateur
{
	// Token: 0x0200005A RID: 90
	public class Ip_carte
	{
		// Token: 0x060004D9 RID: 1241 RVA: 0x00033924 File Offset: 0x00032924
		public Ip_carte(CarteReseau p_c)
		{
			this.dhcp = false;
			this.adresse = new Ip_adresse("0.0.0.0");
			this.masque = new Ip_masque("0.0.0.0");
			this.carte = p_c;
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060004DA RID: 1242 RVA: 0x0003396C File Offset: 0x0003296C
		public CarteReseau Carte
		{
			get
			{
				return this.carte;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060004DB RID: 1243 RVA: 0x00033980 File Offset: 0x00032980
		// (set) Token: 0x060004DC RID: 1244 RVA: 0x00033994 File Offset: 0x00032994
		public Ip_adresse Adresse
		{
			get
			{
				return this.adresse;
			}
			set
			{
				this.adresse = value;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060004DD RID: 1245 RVA: 0x000339A8 File Offset: 0x000329A8
		// (set) Token: 0x060004DE RID: 1246 RVA: 0x000339BC File Offset: 0x000329BC
		public Ip_masque Masque
		{
			get
			{
				return this.masque;
			}
			set
			{
				this.masque = value;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060004DF RID: 1247 RVA: 0x000339D0 File Offset: 0x000329D0
		// (set) Token: 0x060004E0 RID: 1248 RVA: 0x000339E4 File Offset: 0x000329E4
		public bool Dhcp
		{
			get
			{
				return this.dhcp;
			}
			set
			{
				this.dhcp = value;
			}
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x000339F8 File Offset: 0x000329F8
		public void StockerXml(XmlTextWriter writer)
		{
			writer.WriteStartElement("ConfigIpCarte");
			writer.WriteElementString("clientDhcp", this.dhcp.ToString());
			writer.WriteElementString("adresse", this.adresse.ToString());
			writer.WriteElementString("masque", this.masque.ToString());
			writer.WriteEndElement();
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x00033A58 File Offset: 0x00032A58
		public void ChargerXml(XmlTextReader reader)
		{
			Simulation.elementXmlSuivant(reader, true);
			Simulation.elementXmlSuivant(reader, true);
			this.dhcp = bool.Parse(reader.Value);
			Simulation.elementXmlSuivant(reader, true);
			this.adresse = new Ip_adresse(reader.Value);
			Simulation.elementXmlSuivant(reader, true);
			this.masque = new Ip_masque(reader.Value);
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00033AB4 File Offset: 0x00032AB4
		public void ReagirArpRequest(Ip_PaquetIp paquet)
		{
			this.carte.Demo = new DemoArp(this.carte.Reseau);
			this.carte.Demo.TitreDialogue = string.Concat(new object[]
			{
				this.carte.NoeudAttache.NomNoeud,
				" (",
				this.adresse,
				")"
			});
			this.carte.Demo.DemoTerminee += this.reagirArpRequest_DemoTerminee;
			this.carte.Demo.DemarrerDemo(this.carte, paquet, this.carte.Reseau.TypeDemoIp);
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00033B68 File Offset: 0x00032B68
		private void reagirArpRequest_DemoTerminee(object sender, EventArgs e)
		{
			if (Ip_carte.UneDemoArpTerminee != null)
			{
				Ip_carte.UneDemoArpTerminee(this, new EventArgs());
			}
		}

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060004E5 RID: 1253 RVA: 0x00033B8C File Offset: 0x00032B8C
		// (remove) Token: 0x060004E6 RID: 1254 RVA: 0x00033BB0 File Offset: 0x00032BB0
		public static event EventHandler UneDemoArpTerminee;

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060004E7 RID: 1255 RVA: 0x00033BD4 File Offset: 0x00032BD4
		// (set) Token: 0x060004E8 RID: 1256 RVA: 0x00033BE8 File Offset: 0x00032BE8
		public ArrayList Args
		{
			get
			{
				return this.args;
			}
			set
			{
				this.args = value;
			}
		}

		// Token: 0x04000363 RID: 867
		private CarteReseau carte;

		// Token: 0x04000364 RID: 868
		private Ip_adresse adresse;

		// Token: 0x04000365 RID: 869
		private Ip_masque masque;

		// Token: 0x04000366 RID: 870
		private bool dhcp = false;

		// Token: 0x04000368 RID: 872
		private ArrayList args;
	}
}
