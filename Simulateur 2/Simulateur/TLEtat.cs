using System;
using System.Drawing;

namespace Simulateur
{
	// Token: 0x02000095 RID: 149
	public class TLEtat
	{
		// Token: 0x06000966 RID: 2406 RVA: 0x00059FB8 File Offset: 0x00058FB8
		public TLEtat()
		{
			this.activite = TypeActivite.absent;
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x00059FD4 File Offset: 0x00058FD4
		public TLEtat(TypeActivite p_activite, Pen p_stylo, bool p_gomme, TraceLigne p_concurrent, int p_etatSuivant)
		{
			this.activite = p_activite;
			this.stylo = p_stylo;
			this.gomme = p_gomme;
			this.concurrent = p_concurrent;
			this.etatSuivant = p_etatSuivant;
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x0005A00C File Offset: 0x0005900C
		public void SetTraceLigne(TraceLigne t)
		{
			switch (this.activite)
			{
			case TypeActivite.actNo:
				t.SetNoEvent(this.stylo, this.gomme);
				return;
			case TypeActivite.actRencontre:
				t.SetRencontreEvent(this.stylo, this.gomme, this.concurrent, this.etatSuivant);
				return;
			case TypeActivite.actConcurrent:
				t.Init(this.stylo, this.gomme);
				return;
			case TypeActivite.actArrivee:
				t.SetArriveeEvent(this.stylo, this.gomme, this.etatSuivant);
				return;
			default:
				return;
			}
		}

		// Token: 0x0400060B RID: 1547
		private TypeActivite activite;

		// Token: 0x0400060C RID: 1548
		private Pen stylo;

		// Token: 0x0400060D RID: 1549
		private bool gomme;

		// Token: 0x0400060E RID: 1550
		private TraceLigne concurrent;

		// Token: 0x0400060F RID: 1551
		private int etatSuivant;
	}
}
