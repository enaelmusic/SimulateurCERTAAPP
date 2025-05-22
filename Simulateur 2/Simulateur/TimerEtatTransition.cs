using System;
using System.Collections;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200008F RID: 143
	public class TimerEtatTransition : Timer
	{
		// Token: 0x1700018B RID: 395
		// (get) Token: 0x0600092D RID: 2349 RVA: 0x000572D8 File Offset: 0x000562D8
		public ArrayList TempsAttenteEvenement
		{
			get
			{
				return this.tempsAttenteEvenement;
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x0600092F RID: 2351 RVA: 0x0005730C File Offset: 0x0005630C
		public int Evenement
		{
			get
			{
				return this.evenement;
			}
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x00057320 File Offset: 0x00056320
		public void Demarrer(int p_evenement)
		{
			this.evenement = p_evenement;
			base.Interval = (int)this.tempsAttenteEvenement[this.evenement];
			base.Tick += this.genererEvt;
			base.Start();
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x0005736C File Offset: 0x0005636C
		public void Arreter()
		{
			base.Stop();
			base.Tick -= this.genererEvt;
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x00057394 File Offset: 0x00056394
		private void genererEvt(object sender, EventArgs e)
		{
			base.Stop();
			base.Tick -= this.genererEvt;
			if (this.EvtEtatTransition != null)
			{
				this.EvtEtatTransition(null, new EtatTransitionEventArgs(this.evenement));
			}
		}

		// Token: 0x040005BE RID: 1470
		private ArrayList tempsAttenteEvenement = new ArrayList();

		// Token: 0x040005BF RID: 1471
		private int evenement;

		// Token: 0x040005C0 RID: 1472
		public EtatTransitionEventHandler EvtEtatTransition;
	}
}
