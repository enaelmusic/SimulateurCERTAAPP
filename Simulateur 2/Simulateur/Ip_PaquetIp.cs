using System;
using System.Collections;

namespace Simulateur
{
	// Token: 0x0200005E RID: 94
	public class Ip_PaquetIp
	{
		// Token: 0x0600051A RID: 1306 RVA: 0x00035238 File Offset: 0x00034238
		public Ip_PaquetIp(Station sSource, Ip_adresse p_adrDest, TypeDePaquetIp pType, string pDonnees)
		{
			this.nbSauts = sSource.Reseau.Pref.NbSautsMax;
			this.adrDest = p_adrDest;
			this.donnees = pDonnees;
			this.stationSource = sSource;
			this.type = pType;
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x000352B8 File Offset: 0x000342B8
		public Ip_PaquetIp(CarteReseau cSource, CarteReseau cDest, Ip_adresse p_adrDest, TypeDePaquetIp pType, string pDonnees)
		{
			this.nbSauts = cSource.Reseau.Pref.NbSautsMax;
			this.adrDest = p_adrDest;
			this.adrSource = cSource.Ip.Adresse;
			this.carteDest = cDest;
			this.carteSource = cSource;
			this.donnees = pDonnees;
			if (cDest == null)
			{
				this.macDest = cSource.Reseau.Pref.AdrMacBroadcast;
			}
			else
			{
				this.macDest = cDest.AdresseMac;
			}
			this.macSource = cSource.AdresseMac;
			if (cDest == null)
			{
				this.stationDest = null;
			}
			else
			{
				this.stationDest = (Station)cDest.NoeudAttache;
			}
			this.stationSource = (Station)cSource.NoeudAttache;
			this.type = pType;
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600051C RID: 1308 RVA: 0x000353B4 File Offset: 0x000343B4
		// (set) Token: 0x0600051D RID: 1309 RVA: 0x000353C8 File Offset: 0x000343C8
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

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600051E RID: 1310 RVA: 0x000353DC File Offset: 0x000343DC
		// (set) Token: 0x0600051F RID: 1311 RVA: 0x000353F0 File Offset: 0x000343F0
		public ArrayList Route
		{
			get
			{
				return this.route;
			}
			set
			{
				this.route = value;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000520 RID: 1312 RVA: 0x00035404 File Offset: 0x00034404
		// (set) Token: 0x06000521 RID: 1313 RVA: 0x00035418 File Offset: 0x00034418
		public ArrayList CablesTraverses
		{
			get
			{
				return this.cablesTraverses;
			}
			set
			{
				this.cablesTraverses = value;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000522 RID: 1314 RVA: 0x0003542C File Offset: 0x0003442C
		// (set) Token: 0x06000523 RID: 1315 RVA: 0x00035440 File Offset: 0x00034440
		public bool RouteOk
		{
			get
			{
				return this.routeOk;
			}
			set
			{
				this.routeOk = value;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000524 RID: 1316 RVA: 0x00035454 File Offset: 0x00034454
		// (set) Token: 0x06000525 RID: 1317 RVA: 0x00035468 File Offset: 0x00034468
		public int Vlan
		{
			get
			{
				return this.vlan;
			}
			set
			{
				this.vlan = value;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000526 RID: 1318 RVA: 0x0003547C File Offset: 0x0003447C
		// (set) Token: 0x06000527 RID: 1319 RVA: 0x00035490 File Offset: 0x00034490
		public bool Marque8021q
		{
			get
			{
				return this.marque8021q;
			}
			set
			{
				this.marque8021q = value;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000528 RID: 1320 RVA: 0x000354A4 File Offset: 0x000344A4
		// (set) Token: 0x06000529 RID: 1321 RVA: 0x000354B8 File Offset: 0x000344B8
		public bool CarteDestLocale
		{
			get
			{
				return this.carteDestLocale;
			}
			set
			{
				this.carteDestLocale = value;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600052A RID: 1322 RVA: 0x000354CC File Offset: 0x000344CC
		// (set) Token: 0x0600052B RID: 1323 RVA: 0x000354E0 File Offset: 0x000344E0
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

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600052C RID: 1324 RVA: 0x000354F4 File Offset: 0x000344F4
		// (set) Token: 0x0600052D RID: 1325 RVA: 0x00035508 File Offset: 0x00034508
		public CarteReseau CarteSource
		{
			get
			{
				return this.carteSource;
			}
			set
			{
				this.carteSource = value;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600052E RID: 1326 RVA: 0x0003551C File Offset: 0x0003451C
		// (set) Token: 0x0600052F RID: 1327 RVA: 0x00035530 File Offset: 0x00034530
		public Station StationDest
		{
			get
			{
				return this.stationDest;
			}
			set
			{
				this.stationDest = value;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000530 RID: 1328 RVA: 0x00035544 File Offset: 0x00034544
		// (set) Token: 0x06000531 RID: 1329 RVA: 0x00035558 File Offset: 0x00034558
		public CarteReseau CarteDest
		{
			get
			{
				return this.carteDest;
			}
			set
			{
				this.carteDest = value;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000532 RID: 1330 RVA: 0x0003556C File Offset: 0x0003456C
		// (set) Token: 0x06000533 RID: 1331 RVA: 0x00035580 File Offset: 0x00034580
		public string MacSource
		{
			get
			{
				return this.macSource;
			}
			set
			{
				this.macSource = value;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000534 RID: 1332 RVA: 0x00035594 File Offset: 0x00034594
		// (set) Token: 0x06000535 RID: 1333 RVA: 0x000355A8 File Offset: 0x000345A8
		public string MacDest
		{
			get
			{
				return this.macDest;
			}
			set
			{
				this.macDest = value;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000536 RID: 1334 RVA: 0x000355BC File Offset: 0x000345BC
		// (set) Token: 0x06000537 RID: 1335 RVA: 0x000355D0 File Offset: 0x000345D0
		public Ip_adresse AdrDest
		{
			get
			{
				return this.adrDest;
			}
			set
			{
				this.adrDest = value;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000538 RID: 1336 RVA: 0x000355E4 File Offset: 0x000345E4
		// (set) Token: 0x06000539 RID: 1337 RVA: 0x000355F8 File Offset: 0x000345F8
		public Ip_adresse AdrSource
		{
			get
			{
				return this.adrSource;
			}
			set
			{
				this.adrSource = value;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x0003560C File Offset: 0x0003460C
		// (set) Token: 0x0600053B RID: 1339 RVA: 0x00035620 File Offset: 0x00034620
		public TypeDePaquetIp Type
		{
			get
			{
				return this.type;
			}
			set
			{
				this.type = value;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x0600053C RID: 1340 RVA: 0x00035634 File Offset: 0x00034634
		// (set) Token: 0x0600053D RID: 1341 RVA: 0x00035648 File Offset: 0x00034648
		public string Donnees
		{
			get
			{
				return this.donnees;
			}
			set
			{
				this.donnees = value;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x0600053E RID: 1342 RVA: 0x0003565C File Offset: 0x0003465C
		// (set) Token: 0x0600053F RID: 1343 RVA: 0x00035670 File Offset: 0x00034670
		public Ip_adresse AdrPasserelle
		{
			get
			{
				return this.adrPasserelle;
			}
			set
			{
				this.adrPasserelle = value;
			}
		}

		// Token: 0x0400038B RID: 907
		private int nbSauts = 0;

		// Token: 0x0400038C RID: 908
		private ArrayList route = new ArrayList();

		// Token: 0x0400038D RID: 909
		private ArrayList cablesTraverses = new ArrayList();

		// Token: 0x0400038E RID: 910
		private bool routeOk = false;

		// Token: 0x0400038F RID: 911
		private int vlan = 0;

		// Token: 0x04000390 RID: 912
		private bool marque8021q = false;

		// Token: 0x04000391 RID: 913
		private bool carteDestLocale = false;

		// Token: 0x04000392 RID: 914
		private Station stationSource;

		// Token: 0x04000393 RID: 915
		private CarteReseau carteSource;

		// Token: 0x04000394 RID: 916
		private Station stationDest;

		// Token: 0x04000395 RID: 917
		private CarteReseau carteDest;

		// Token: 0x04000396 RID: 918
		private string macSource;

		// Token: 0x04000397 RID: 919
		private string macDest;

		// Token: 0x04000398 RID: 920
		private Ip_adresse adrDest;

		// Token: 0x04000399 RID: 921
		private Ip_adresse adrSource;

		// Token: 0x0400039A RID: 922
		private TypeDePaquetIp type;

		// Token: 0x0400039B RID: 923
		private string donnees;

		// Token: 0x0400039C RID: 924
		private Ip_adresse adrPasserelle;
	}
}
