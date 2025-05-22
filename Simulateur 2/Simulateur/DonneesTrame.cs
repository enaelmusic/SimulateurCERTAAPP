using System;

namespace Simulateur
{
	// Token: 0x02000038 RID: 56
	public class DonneesTrame
	{
		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000333 RID: 819 RVA: 0x00027520 File Offset: 0x00026520
		// (set) Token: 0x06000334 RID: 820 RVA: 0x00027534 File Offset: 0x00026534
		public int NumeroTrame
		{
			get
			{
				return this.numeroTrame;
			}
			set
			{
				this.numeroTrame = value;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000335 RID: 821 RVA: 0x00027548 File Offset: 0x00026548
		// (set) Token: 0x06000336 RID: 822 RVA: 0x0002755C File Offset: 0x0002655C
		public int TailleTrame
		{
			get
			{
				return this.tailleTrame;
			}
			set
			{
				this.tailleTrame = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000337 RID: 823 RVA: 0x00027570 File Offset: 0x00026570
		// (set) Token: 0x06000338 RID: 824 RVA: 0x00027584 File Offset: 0x00026584
		public DateTime MomentEmission
		{
			get
			{
				return this.momentEmission;
			}
			set
			{
				this.momentEmission = value;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000339 RID: 825 RVA: 0x00027598 File Offset: 0x00026598
		// (set) Token: 0x0600033A RID: 826 RVA: 0x000275AC File Offset: 0x000265AC
		public CarteReseau Emetteur
		{
			get
			{
				return this.emetteur;
			}
			set
			{
				this.emetteur = value;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600033B RID: 827 RVA: 0x000275C0 File Offset: 0x000265C0
		// (set) Token: 0x0600033C RID: 828 RVA: 0x000275D4 File Offset: 0x000265D4
		public string AdrDestinataire
		{
			get
			{
				return this.adrDestinataire;
			}
			set
			{
				this.adrDestinataire = value;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600033D RID: 829 RVA: 0x000275E8 File Offset: 0x000265E8
		// (set) Token: 0x0600033E RID: 830 RVA: 0x000275FC File Offset: 0x000265FC
		public EmissionTrameDialogue DialogueEmission
		{
			get
			{
				return this.dialogueEmission;
			}
			set
			{
				this.dialogueEmission = value;
			}
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00027610 File Offset: 0x00026610
		public DonneesTrame(int p_numTrame, DateTime p_moment, CarteReseau p_emetteur, string p_adrDest, int p_tailleTrame)
		{
			this.numeroTrame = p_numTrame;
			this.momentEmission = p_moment;
			this.emetteur = p_emetteur;
			this.adrDestinataire = p_adrDest;
			this.tailleTrame = p_tailleTrame;
			this.envoyee = true;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00027650 File Offset: 0x00026650
		public DonneesTrame()
		{
			this.envoyee = false;
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000341 RID: 833 RVA: 0x0002766C File Offset: 0x0002666C
		// (set) Token: 0x06000342 RID: 834 RVA: 0x00027680 File Offset: 0x00026680
		public bool Envoyee
		{
			get
			{
				return this.envoyee;
			}
			set
			{
				this.envoyee = value;
			}
		}

		// Token: 0x040002A6 RID: 678
		private int numeroTrame;

		// Token: 0x040002A7 RID: 679
		private int tailleTrame;

		// Token: 0x040002A8 RID: 680
		private DateTime momentEmission;

		// Token: 0x040002A9 RID: 681
		private CarteReseau emetteur;

		// Token: 0x040002AA RID: 682
		private string adrDestinataire;

		// Token: 0x040002AB RID: 683
		private EmissionTrameDialogue dialogueEmission;

		// Token: 0x040002AC RID: 684
		private bool envoyee;
	}
}
