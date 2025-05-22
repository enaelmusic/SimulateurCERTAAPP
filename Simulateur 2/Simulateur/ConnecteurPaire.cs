using System;
using System.Drawing;

namespace Simulateur
{
	// Token: 0x02000070 RID: 112
	public class ConnecteurPaire
	{
		// Token: 0x17000124 RID: 292
		// (get) Token: 0x060006E5 RID: 1765 RVA: 0x00042AD0 File Offset: 0x00041AD0
		// (set) Token: 0x060006E6 RID: 1766 RVA: 0x00042AE4 File Offset: 0x00041AE4
		public TrameEventArgs TrameEnCours
		{
			get
			{
				return this.trameEnCours;
			}
			set
			{
				this.trameEnCours = value;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060006E7 RID: 1767 RVA: 0x00042AF8 File Offset: 0x00041AF8
		// (set) Token: 0x060006E8 RID: 1768 RVA: 0x00042B0C File Offset: 0x00041B0C
		public TraceCable Trace
		{
			get
			{
				return this.trace;
			}
			set
			{
				this.trace = value;
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060006E9 RID: 1769 RVA: 0x00042B20 File Offset: 0x00041B20
		public Point Pos
		{
			get
			{
				return this.pos;
			}
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x00042B34 File Offset: 0x00041B34
		public ConnecteurPaire(PointConnexion p_ptConnexion, ConnecteurPaire p_oppose, Point p_pos)
		{
			this.ptConnexion = p_ptConnexion;
			this.oppose = p_oppose;
			this.pos = p_pos;
		}

		// Token: 0x04000471 RID: 1137
		private TraceCable trace = null;

		// Token: 0x04000472 RID: 1138
		private TrameEventArgs trameEnCours = null;

		// Token: 0x04000473 RID: 1139
		private Point pos = new Point(0, 0);

		// Token: 0x04000474 RID: 1140
		private ConnecteurPaire oppose;

		// Token: 0x04000475 RID: 1141
		private PointConnexion ptConnexion;
	}
}
