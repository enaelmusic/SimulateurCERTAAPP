using System;
using System.Collections;

namespace Simulateur
{
	// Token: 0x0200003A RID: 58
	public class DonneesSimulationIp
	{
		// Token: 0x0600035A RID: 858 RVA: 0x00028C98 File Offset: 0x00027C98
		public void InitCachesArpStation()
		{
			this.cachesArpStation = new Hashtable();
			foreach (object obj in this.reseau.Schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Station))
				{
					this.cachesArpStation.Add(((Station)elementReseau).NomNoeud, new SortedList());
					foreach (object obj2 in ((Station)elementReseau).Ip.CacheArp.Values)
					{
						ArrayList arrayList = (ArrayList)obj2;
						((SortedList)this.cachesArpStation[((Station)elementReseau).NomNoeud]).Add(arrayList[0], arrayList.Clone());
					}
				}
			}
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00028DD0 File Offset: 0x00027DD0
		public void RelireCachesArpStation()
		{
			foreach (object obj in this.reseau.Schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Station))
				{
					((Station)elementReseau).Ip.CacheArp = new SortedList();
					foreach (object obj2 in ((SortedList)this.cachesArpStation[((Station)elementReseau).NomNoeud]).Values)
					{
						ArrayList arrayList = (ArrayList)obj2;
						((Station)elementReseau).Ip.CacheArp.Add(arrayList[0], arrayList.Clone());
					}
				}
			}
		}

		// Token: 0x0600035C RID: 860 RVA: 0x00028EF8 File Offset: 0x00027EF8
		public DonneesSimulationIp(Simulation p_reseau)
		{
			this.reseau = p_reseau;
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x0600035D RID: 861 RVA: 0x00028F4C File Offset: 0x00027F4C
		// (set) Token: 0x0600035E RID: 862 RVA: 0x00028F60 File Offset: 0x00027F60
		public string AdrIp
		{
			get
			{
				return this.adrIp;
			}
			set
			{
				this.adrIp = value;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600035F RID: 863 RVA: 0x00028F74 File Offset: 0x00027F74
		// (set) Token: 0x06000360 RID: 864 RVA: 0x00028F88 File Offset: 0x00027F88
		public Station StationPing
		{
			get
			{
				return this.stationPing;
			}
			set
			{
				this.stationPing = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000361 RID: 865 RVA: 0x00028F9C File Offset: 0x00027F9C
		// (set) Token: 0x06000362 RID: 866 RVA: 0x00028FB0 File Offset: 0x00027FB0
		public string TrsProtocole
		{
			get
			{
				return this.trsProtocole;
			}
			set
			{
				this.trsProtocole = value;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000363 RID: 867 RVA: 0x00028FC4 File Offset: 0x00027FC4
		// (set) Token: 0x06000364 RID: 868 RVA: 0x00028FD8 File Offset: 0x00027FD8
		public string TrsNumport
		{
			get
			{
				return this.trsNumport;
			}
			set
			{
				this.trsNumport = value;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000365 RID: 869 RVA: 0x00028FEC File Offset: 0x00027FEC
		// (set) Token: 0x06000366 RID: 870 RVA: 0x00029000 File Offset: 0x00028000
		public int TrsIndexRequete
		{
			get
			{
				return this.trsIndexRequete;
			}
			set
			{
				this.trsIndexRequete = value;
			}
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00029014 File Offset: 0x00028014
		public int portGenereSuivant()
		{
			if (this.posDernierPort < this.portsGeneres.Count)
			{
				return (int)this.portsGeneres[this.posDernierPort++];
			}
			int num = Trs_station.RndPort.Next(2000, 10000);
			while (this.portsGeneres.Contains(num))
			{
				num = Trs_station.RndPort.Next(2000, 10000);
			}
			this.AjouterPortGenere(num);
			return num;
		}

		// Token: 0x06000368 RID: 872 RVA: 0x000290A0 File Offset: 0x000280A0
		public void InitPortsGeneres()
		{
			this.portsGeneres = new ArrayList();
		}

		// Token: 0x06000369 RID: 873 RVA: 0x000290B8 File Offset: 0x000280B8
		public void InitPosDernierPort()
		{
			this.posDernierPort = 0;
		}

		// Token: 0x0600036A RID: 874 RVA: 0x000290CC File Offset: 0x000280CC
		public void AjouterPortGenere(int port)
		{
			this.portsGeneres.Add(port);
		}

		// Token: 0x0600036B RID: 875 RVA: 0x000290EC File Offset: 0x000280EC
		public void InitNatPatEtRequetesTrs()
		{
			this.tablesNatPat = new Hashtable();
			this.tablesRequetesEnvoyees = new Hashtable();
			this.tablesRequetesRecues = new Hashtable();
			foreach (object obj in this.reseau.Schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Station))
				{
					this.tablesNatPat.Add(((Station)elementReseau).NomNoeud, new SortedList());
					foreach (object obj2 in ((Station)elementReseau).Trs.NatPat.Values)
					{
						ArrayList arrayList = (ArrayList)obj2;
						((SortedList)this.tablesNatPat[((Station)elementReseau).NomNoeud]).Add(arrayList[0], arrayList.Clone());
					}
					this.tablesRequetesEnvoyees.Add(((Station)elementReseau).NomNoeud, new SortedList());
					foreach (object obj3 in ((Station)elementReseau).Trs.ReqTrsEnvoyees.Values)
					{
						ArrayList arrayList2 = (ArrayList)obj3;
						((SortedList)this.tablesRequetesEnvoyees[((Station)elementReseau).NomNoeud]).Add(arrayList2[0], arrayList2.Clone());
					}
					this.tablesRequetesRecues.Add(((Station)elementReseau).NomNoeud, new SortedList());
					foreach (object obj4 in ((Station)elementReseau).Trs.ReqTrsRecues.Values)
					{
						ArrayList arrayList3 = (ArrayList)obj4;
						((SortedList)this.tablesRequetesRecues[((Station)elementReseau).NomNoeud]).Add(arrayList3[0], arrayList3.Clone());
					}
				}
			}
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00029398 File Offset: 0x00028398
		public void RelireNatPatEtRequetesTrs()
		{
			foreach (object obj in this.reseau.Schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Station))
				{
					((Station)elementReseau).Trs.NatPat = new SortedList();
					foreach (object obj2 in ((SortedList)this.tablesNatPat[((Station)elementReseau).NomNoeud]).Values)
					{
						ArrayList arrayList = (ArrayList)obj2;
						((Station)elementReseau).Trs.NatPat.Add(arrayList[0], arrayList.Clone());
					}
					((Station)elementReseau).Trs.ReqTrsEnvoyees = new SortedList();
					foreach (object obj3 in ((SortedList)this.tablesRequetesEnvoyees[((Station)elementReseau).NomNoeud]).Values)
					{
						ArrayList arrayList2 = (ArrayList)obj3;
						((Station)elementReseau).Trs.ReqTrsEnvoyees.Add(arrayList2[0], arrayList2.Clone());
					}
					((Station)elementReseau).Trs.ReqTrsRecues = new SortedList();
					foreach (object obj4 in ((SortedList)this.tablesRequetesRecues[((Station)elementReseau).NomNoeud]).Values)
					{
						ArrayList arrayList3 = (ArrayList)obj4;
						((Station)elementReseau).Trs.ReqTrsRecues.Add(arrayList3[0], arrayList3.Clone());
					}
				}
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600036D RID: 877 RVA: 0x00029614 File Offset: 0x00028614
		// (set) Token: 0x0600036E RID: 878 RVA: 0x00029628 File Offset: 0x00028628
		public TypeSimulationIp DemoIp
		{
			get
			{
				return this.demoIp;
			}
			set
			{
				this.demoIp = value;
			}
		}

		// Token: 0x040002B8 RID: 696
		private Hashtable cachesArpStation;

		// Token: 0x040002B9 RID: 697
		private Simulation reseau;

		// Token: 0x040002BA RID: 698
		private string adrIp = "";

		// Token: 0x040002BB RID: 699
		private Station stationPing;

		// Token: 0x040002BC RID: 700
		private string trsProtocole = "TCP";

		// Token: 0x040002BD RID: 701
		private string trsNumport = "";

		// Token: 0x040002BE RID: 702
		private int trsIndexRequete;

		// Token: 0x040002BF RID: 703
		private ArrayList portsGeneres = new ArrayList();

		// Token: 0x040002C0 RID: 704
		private int posDernierPort = 0;

		// Token: 0x040002C1 RID: 705
		private Hashtable tablesNatPat;

		// Token: 0x040002C2 RID: 706
		private Hashtable tablesRequetesEnvoyees;

		// Token: 0x040002C3 RID: 707
		private Hashtable tablesRequetesRecues;

		// Token: 0x040002C4 RID: 708
		private TypeSimulationIp demoIp = TypeSimulationIp.ping;
	}
}
