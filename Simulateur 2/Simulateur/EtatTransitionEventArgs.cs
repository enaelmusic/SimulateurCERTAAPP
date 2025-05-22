using System;

namespace Simulateur
{
	// Token: 0x02000043 RID: 67
	public class EtatTransitionEventArgs : EventArgs
	{
		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600039C RID: 924 RVA: 0x0002A3BC File Offset: 0x000293BC
		public int Evt
		{
			get
			{
				return this.evt;
			}
		}

		// Token: 0x0600039D RID: 925 RVA: 0x0002A3D0 File Offset: 0x000293D0
		public EtatTransitionEventArgs(int evenement)
		{
			this.evt = evenement;
		}

		// Token: 0x040002DE RID: 734
		private int evt;
	}
}
