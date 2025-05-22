using System;
using System.Collections;

namespace Simulateur
{
	// Token: 0x02000037 RID: 55
	public class DomaineCollision
	{
		// Token: 0x0600032B RID: 811 RVA: 0x00027340 File Offset: 0x00026340
		public DomaineCollision(PortHub detecteurCollision)
		{
			this.gestionnaire = detecteurCollision;
			this.construireDomaine(this.gestionnaire, new ArrayList());
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600032C RID: 812 RVA: 0x00027384 File Offset: 0x00026384
		public ArrayList Cables
		{
			get
			{
				return this.cables;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600032D RID: 813 RVA: 0x00027398 File Offset: 0x00026398
		public CarteReseau CarteRepresentante
		{
			get
			{
				return this.carteRepresentante;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600032E RID: 814 RVA: 0x000273AC File Offset: 0x000263AC
		// (set) Token: 0x0600032F RID: 815 RVA: 0x000273C0 File Offset: 0x000263C0
		public int NbCollisionCableOk
		{
			get
			{
				return this.nbCollisionCableOk;
			}
			set
			{
				this.nbCollisionCableOk = value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000330 RID: 816 RVA: 0x000273D4 File Offset: 0x000263D4
		// (set) Token: 0x06000331 RID: 817 RVA: 0x000273E8 File Offset: 0x000263E8
		public int NbTramesAnnulees
		{
			get
			{
				return this.nbTramesAnnulees;
			}
			set
			{
				this.nbTramesAnnulees = value;
			}
		}

		// Token: 0x06000332 RID: 818 RVA: 0x000273FC File Offset: 0x000263FC
		private void construireDomaine(PortHub p, ArrayList vus)
		{
			if (!vus.Contains(p))
			{
				vus.Add(p);
				if (!this.cables.Contains(p.Lien))
				{
					this.cables.Add(p.Lien);
				}
				if (this.carteRepresentante == null && p.Lien.Oppose(p).GetType() == typeof(CarteReseau))
				{
					this.carteRepresentante = (CarteReseau)p.Lien.Oppose(p);
				}
				if (p.Lien.Oppose(p).NoeudAttache.GetType() == typeof(Hub))
				{
					this.construireDomaine((PortHub)p.Lien.Oppose(p), vus);
				}
				foreach (object obj in p.NoeudAttache.Controls)
				{
					PortHub portHub = (PortHub)obj;
					if (portHub.EtatConnexion == PointConnexion.EtatsConnexion.actif)
					{
						this.construireDomaine(portHub, vus);
					}
				}
			}
		}

		// Token: 0x040002A1 RID: 673
		private ArrayList cables = new ArrayList();

		// Token: 0x040002A2 RID: 674
		private PortHub gestionnaire;

		// Token: 0x040002A3 RID: 675
		private CarteReseau carteRepresentante = null;

		// Token: 0x040002A4 RID: 676
		private int nbCollisionCableOk;

		// Token: 0x040002A5 RID: 677
		private int nbTramesAnnulees = 0;
	}
}
