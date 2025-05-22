using System;

namespace Simulateur
{
	// Token: 0x0200009A RID: 154
	public class Trs_SegmentTrs
	{
		// Token: 0x060009D5 RID: 2517 RVA: 0x0005CE4C File Offset: 0x0005BE4C
		private Trs_SegmentTrs()
		{
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x0005CE60 File Offset: 0x0005BE60
		public Trs_SegmentTrs(Station sSource, ProtocoleTrs p_protocole, Ip_adresse p_adrSource, int p_portSource, Ip_adresse p_adrDest, int p_portDest)
		{
			this.stationSource = sSource;
			this.protocole = p_protocole;
			this.adrIpDest = p_adrDest;
			this.adrIpSource = p_adrSource;
			this.numPortSource = p_portSource;
			this.numPortDest = p_portDest;
			this.macArrivee = null;
			this.macDepart = null;
			this.nbSauts = sSource.Reseau.Pref.NbSautsMax;
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x0005CEC4 File Offset: 0x0005BEC4
		public Trs_SegmentTrs Clone()
		{
			return new Trs_SegmentTrs
			{
				stationSource = this.stationSource,
				protocole = this.protocole,
				adrIpDest = this.adrIpDest,
				adrIpSource = this.adrIpSource,
				numPortSource = this.numPortSource,
				numPortDest = this.numPortDest,
				macArrivee = this.macArrivee,
				macDepart = this.macDepart,
				nbSauts = this.nbSauts
			};
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x060009D8 RID: 2520 RVA: 0x0005CF44 File Offset: 0x0005BF44
		// (set) Token: 0x060009D9 RID: 2521 RVA: 0x0005CF58 File Offset: 0x0005BF58
		public Station StationSource
		{
			get
			{
				return this.stationSource;
			}
			set
			{
				this.stationSource = value;
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x060009DA RID: 2522 RVA: 0x0005CF6C File Offset: 0x0005BF6C
		// (set) Token: 0x060009DB RID: 2523 RVA: 0x0005CF80 File Offset: 0x0005BF80
		public ProtocoleTrs Protocole
		{
			get
			{
				return this.protocole;
			}
			set
			{
				this.protocole = value;
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x060009DC RID: 2524 RVA: 0x0005CF94 File Offset: 0x0005BF94
		// (set) Token: 0x060009DD RID: 2525 RVA: 0x0005CFA8 File Offset: 0x0005BFA8
		public Ip_adresse AdrIpDest
		{
			get
			{
				return this.adrIpDest;
			}
			set
			{
				this.adrIpDest = value;
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x060009DE RID: 2526 RVA: 0x0005CFBC File Offset: 0x0005BFBC
		// (set) Token: 0x060009DF RID: 2527 RVA: 0x0005CFD0 File Offset: 0x0005BFD0
		public Ip_adresse AdrIpSource
		{
			get
			{
				return this.adrIpSource;
			}
			set
			{
				this.adrIpSource = value;
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x060009E0 RID: 2528 RVA: 0x0005CFE4 File Offset: 0x0005BFE4
		// (set) Token: 0x060009E1 RID: 2529 RVA: 0x0005CFF8 File Offset: 0x0005BFF8
		public int NumPortSource
		{
			get
			{
				return this.numPortSource;
			}
			set
			{
				this.numPortSource = value;
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x060009E2 RID: 2530 RVA: 0x0005D00C File Offset: 0x0005C00C
		// (set) Token: 0x060009E3 RID: 2531 RVA: 0x0005D020 File Offset: 0x0005C020
		public int NumPortDest
		{
			get
			{
				return this.numPortDest;
			}
			set
			{
				this.numPortDest = value;
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x060009E4 RID: 2532 RVA: 0x0005D034 File Offset: 0x0005C034
		// (set) Token: 0x060009E5 RID: 2533 RVA: 0x0005D048 File Offset: 0x0005C048
		public string MacArrivee
		{
			get
			{
				return this.macArrivee;
			}
			set
			{
				this.macArrivee = value;
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x060009E6 RID: 2534 RVA: 0x0005D05C File Offset: 0x0005C05C
		// (set) Token: 0x060009E7 RID: 2535 RVA: 0x0005D070 File Offset: 0x0005C070
		public string MacDepart
		{
			get
			{
				return this.macDepart;
			}
			set
			{
				this.macDepart = value;
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x060009E8 RID: 2536 RVA: 0x0005D084 File Offset: 0x0005C084
		// (set) Token: 0x060009E9 RID: 2537 RVA: 0x0005D098 File Offset: 0x0005C098
		public int NbSauts
		{
			get
			{
				return this.nbSauts;
			}
			set
			{
				this.nbSauts = value;
			}
		}

		// Token: 0x0400065C RID: 1628
		private Station stationSource;

		// Token: 0x0400065D RID: 1629
		private ProtocoleTrs protocole;

		// Token: 0x0400065E RID: 1630
		private Ip_adresse adrIpDest;

		// Token: 0x0400065F RID: 1631
		private Ip_adresse adrIpSource;

		// Token: 0x04000660 RID: 1632
		private int numPortSource;

		// Token: 0x04000661 RID: 1633
		private int numPortDest;

		// Token: 0x04000662 RID: 1634
		private string macArrivee;

		// Token: 0x04000663 RID: 1635
		private string macDepart;

		// Token: 0x04000664 RID: 1636
		private int nbSauts;
	}
}
