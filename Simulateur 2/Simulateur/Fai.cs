using System;
using System.Collections;

namespace Simulateur
{
	// Token: 0x02000045 RID: 69
	public class Fai
	{
		// Token: 0x060003A2 RID: 930 RVA: 0x0002A3EC File Offset: 0x000293EC
		public Fai()
		{
			this.adrReseau = new Ip_adresse("0.0.0.0");
			this.masqueReseau = new Ip_masque("0.0.0.0");
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x0002A42C File Offset: 0x0002942C
		// (set) Token: 0x060003A4 RID: 932 RVA: 0x0002A440 File Offset: 0x00029440
		public Ip_adresse AdrReseau
		{
			get
			{
				return this.adrReseau;
			}
			set
			{
				this.adrReseau = value;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x0002A454 File Offset: 0x00029454
		// (set) Token: 0x060003A6 RID: 934 RVA: 0x0002A468 File Offset: 0x00029468
		public Ip_masque MasqueReseau
		{
			get
			{
				return this.masqueReseau;
			}
			set
			{
				this.masqueReseau = value;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060003A7 RID: 935 RVA: 0x0002A47C File Offset: 0x0002947C
		public PortFai[] Ports
		{
			get
			{
				return this.ports;
			}
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x0002A490 File Offset: 0x00029490
		public void ConfigurerPorts()
		{
			if (!this.adrReseau.Isnul())
			{
				this.ports[0].Ip.Adresse = this.getAdressePort(1U);
				this.ports[0].Ip.Masque = this.masqueReseau;
				this.ports[1].Ip.Adresse = this.getAdressePort(2U);
				this.ports[1].Ip.Masque = this.masqueReseau;
			}
			this.ports[0].SetContenuInfoBulle();
			this.ports[1].SetContenuInfoBulle();
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x0002A528 File Offset: 0x00029528
		private Ip_adresse getAdressePort(uint numPort)
		{
			return new Ip_adresse(new Ip_quartet(Ip_quartet.ValReseau(this.adrReseau, this.masqueReseau) + numPort));
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0002A554 File Offset: 0x00029554
		public bool IsAdressePort(string strAdrIp)
		{
			return this.ports[0].Ip.Adresse.ToString() == strAdrIp.Trim() || this.ports[1].Ip.Adresse.ToString() == strAdrIp.Trim();
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0002A5B0 File Offset: 0x000295B0
		public void ConfigurerClients(SortedList routes)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add(HashTableEdit.DeuxChiffres(routes.Count + 1));
			arrayList.Add(this.ports[0].Ip.Adresse.ToString());
			arrayList.Add("255.255.255.255");
			arrayList.Add(this.ports[0].Ip.Adresse.ToString());
			arrayList.Add(this.ports[0].Ip.Adresse.ToString());
			arrayList.Add("1");
			routes.Add(arrayList[0], arrayList.Clone());
			arrayList = new ArrayList();
			arrayList.Add(HashTableEdit.DeuxChiffres(routes.Count + 1));
			arrayList.Add(this.ports[1].Ip.Adresse.ToString());
			arrayList.Add("255.255.255.255");
			arrayList.Add(this.ports[1].Ip.Adresse.ToString());
			arrayList.Add(this.ports[1].Ip.Adresse.ToString());
			arrayList.Add("1");
			routes.Add(arrayList[0], arrayList.Clone());
			if (this.ports[0].EtatConnexion == PointConnexion.EtatsConnexion.actif)
			{
				CarteAccesDistant carteAccesDistant = (CarteAccesDistant)this.ports[0].Lien.Oppose(this.ports[0]);
				Ip_adresse adresse = carteAccesDistant.Ip.Adresse;
				Ip_masque masque = carteAccesDistant.Ip.Masque;
				carteAccesDistant.Ip.Adresse = this.getAdressePort(3U);
				carteAccesDistant.Ip.Masque = this.masqueReseau;
				((Station)carteAccesDistant.NoeudAttache).Ip.MajRoutes(adresse, masque, carteAccesDistant.Ip.Adresse, carteAccesDistant.Ip.Masque);
				arrayList = new ArrayList();
				arrayList.Add(HashTableEdit.DeuxChiffres(routes.Count + 1));
				arrayList.Add(carteAccesDistant.Ip.Adresse.ToString());
				arrayList.Add("255.255.255.255");
				arrayList.Add(this.ports[0].Ip.Adresse.ToString());
				arrayList.Add(this.ports[0].Ip.Adresse.ToString());
				arrayList.Add("50");
				routes.Add(arrayList[0], arrayList.Clone());
				carteAccesDistant.SetContenuInfoBulle();
			}
			if (this.ports[1].EtatConnexion == PointConnexion.EtatsConnexion.actif)
			{
				CarteAccesDistant carteAccesDistant = (CarteAccesDistant)this.ports[1].Lien.Oppose(this.ports[1]);
				Ip_adresse adresse2 = carteAccesDistant.Ip.Adresse;
				Ip_masque masque2 = carteAccesDistant.Ip.Masque;
				carteAccesDistant.Ip.Adresse = this.getAdressePort(4U);
				carteAccesDistant.Ip.Masque = this.masqueReseau;
				((Station)carteAccesDistant.NoeudAttache).Ip.MajRoutes(adresse2, masque2, carteAccesDistant.Ip.Adresse, carteAccesDistant.Ip.Masque);
				arrayList = new ArrayList();
				arrayList.Add(HashTableEdit.DeuxChiffres(routes.Count + 1));
				arrayList.Add(carteAccesDistant.Ip.Adresse.ToString());
				arrayList.Add("255.255.255.255");
				arrayList.Add(this.ports[1].Ip.Adresse.ToString());
				arrayList.Add(this.ports[1].Ip.Adresse.ToString());
				arrayList.Add("50");
				routes.Add(arrayList[0], arrayList.Clone());
				carteAccesDistant.SetContenuInfoBulle();
			}
		}

		// Token: 0x040002DF RID: 735
		private Ip_adresse adrReseau;

		// Token: 0x040002E0 RID: 736
		private Ip_masque masqueReseau;

		// Token: 0x040002E1 RID: 737
		private PortFai[] ports = new PortFai[2];
	}
}
