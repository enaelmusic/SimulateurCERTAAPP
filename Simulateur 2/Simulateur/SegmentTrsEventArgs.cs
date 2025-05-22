using System;

namespace Simulateur
{
	// Token: 0x02000040 RID: 64
	public class SegmentTrsEventArgs : EventArgs
	{
		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000390 RID: 912 RVA: 0x0002A358 File Offset: 0x00029358
		public Trs_SegmentTrs Segment
		{
			get
			{
				return this.segment;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000391 RID: 913 RVA: 0x0002A36C File Offset: 0x0002936C
		public Ip_PaquetIp Paquet
		{
			get
			{
				return this.paquet;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000392 RID: 914 RVA: 0x0002A380 File Offset: 0x00029380
		public Trs_station Cible
		{
			get
			{
				return this.cible;
			}
		}

		// Token: 0x06000393 RID: 915 RVA: 0x0002A394 File Offset: 0x00029394
		public SegmentTrsEventArgs(Trs_SegmentTrs s, Ip_PaquetIp p, Trs_station c)
		{
			this.segment = s;
			this.paquet = p;
			this.cible = c;
		}

		// Token: 0x040002DB RID: 731
		private Trs_SegmentTrs segment;

		// Token: 0x040002DC RID: 732
		private Ip_PaquetIp paquet;

		// Token: 0x040002DD RID: 733
		private Trs_station cible;
	}
}
