using System;

namespace Simulateur
{
	// Token: 0x0200003D RID: 61
	public class TrameEventArgs : EventArgs
	{
		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000386 RID: 902 RVA: 0x0002A2C0 File Offset: 0x000292C0
		public TrameEthernet Trame
		{
			get
			{
				return this.trame;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000387 RID: 903 RVA: 0x0002A2D4 File Offset: 0x000292D4
		public ElementReseau Cible
		{
			get
			{
				return this.cible;
			}
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0002A2E8 File Offset: 0x000292E8
		public TrameEventArgs(TrameEthernet t, ElementReseau c)
		{
			this.trame = t;
			this.cible = c;
		}

		// Token: 0x040002D7 RID: 727
		private TrameEthernet trame;

		// Token: 0x040002D8 RID: 728
		private ElementReseau cible;
	}
}
