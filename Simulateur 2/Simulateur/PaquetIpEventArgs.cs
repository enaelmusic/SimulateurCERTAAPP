using System;

namespace Simulateur
{
	// Token: 0x0200003F RID: 63
	public class PaquetIpEventArgs : EventArgs
	{
		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600038D RID: 909 RVA: 0x0002A30C File Offset: 0x0002930C
		public Ip_PaquetIp Paquet
		{
			get
			{
				return this.paquet;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600038E RID: 910 RVA: 0x0002A320 File Offset: 0x00029320
		public Ip_station Cible
		{
			get
			{
				return this.cible;
			}
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0002A334 File Offset: 0x00029334
		public PaquetIpEventArgs(Ip_PaquetIp p, Ip_station c)
		{
			this.paquet = p;
			this.cible = c;
		}

		// Token: 0x040002D9 RID: 729
		private Ip_PaquetIp paquet;

		// Token: 0x040002DA RID: 730
		private Ip_station cible;
	}
}
