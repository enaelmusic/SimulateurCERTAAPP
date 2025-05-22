using System;

namespace Simulateur
{
	// Token: 0x0200005F RID: 95
	public class Ip_PaquetIpDemoManuel
	{
		// Token: 0x06000540 RID: 1344 RVA: 0x00035684 File Offset: 0x00034684
		public Ip_PaquetIpDemoManuel(string p_macDest, string p_macSource, int p_ttl, string p_ipSource, string p_ipDest, TypeDePaquetIp p_type)
		{
			this.macDest = p_macDest;
			this.macSource = p_macSource;
			this.ttl = p_ttl;
			this.ipSource = p_ipSource;
			this.ipDest = p_ipDest;
			this.type = p_type;
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x00035700 File Offset: 0x00034700
		public bool Idem(Ip_PaquetIpDemoManuel autre)
		{
			return !(this.macDest != autre.macDest) && !(this.macSource != autre.macSource) && !(this.ipSource.Trim() != autre.ipSource.Trim()) && !(this.ipDest.Trim() != autre.ipDest.Trim()) && this.type == autre.type && (this.ttl == autre.ttl || (this.type != TypeDePaquetIp.IcmpEchoRequest && this.type != TypeDePaquetIp.IcmpEchoResponse));
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000542 RID: 1346 RVA: 0x000357A8 File Offset: 0x000347A8
		public TypeDePaquetIp Type
		{
			get
			{
				return this.type;
			}
		}

		// Token: 0x0400039D RID: 925
		private string macDest = "";

		// Token: 0x0400039E RID: 926
		private string macSource = "";

		// Token: 0x0400039F RID: 927
		private int ttl = -1;

		// Token: 0x040003A0 RID: 928
		private string ipSource = "";

		// Token: 0x040003A1 RID: 929
		private string ipDest = "";

		// Token: 0x040003A2 RID: 930
		private TypeDePaquetIp type = TypeDePaquetIp.Aucun;
	}
}
