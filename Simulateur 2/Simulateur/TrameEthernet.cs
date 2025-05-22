using System;
using System.Collections;

namespace Simulateur
{
	// Token: 0x02000097 RID: 151
	public class TrameEthernet
	{
		// Token: 0x06000999 RID: 2457 RVA: 0x0005AFA4 File Offset: 0x00059FA4
		public TrameEthernet(int p_numeroTrame, int p_vlan, CarteReseau p_carteEmetteur, string p_macEmetteur, string p_macDestinataire, string p_info, Simulation p_reseau)
		{
			this.numeroTrame = p_numeroTrame;
			this.vlan = p_vlan;
			this.carteEmetteur = p_carteEmetteur;
			this.reseau = p_reseau;
			this.macEmetteur = p_macEmetteur;
			this.macDestinataire = p_macDestinataire;
			this.info = p_info;
			ElementReseau.TransmissionTrameAchevee += this.Trame_TransmissionTrameAchevee;
			ElementReseau.TransmissionFinTrameAchevee += this.Trame_TransmissionFinTrameAchevee;
			this.reseau.AjouterTrameCreee(this);
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x0600099A RID: 2458 RVA: 0x0005B058 File Offset: 0x0005A058
		// (set) Token: 0x0600099B RID: 2459 RVA: 0x0005B06C File Offset: 0x0005A06C
		public int Vlan
		{
			get
			{
				return this.vlan;
			}
			set
			{
				this.vlan = value;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x0600099C RID: 2460 RVA: 0x0005B080 File Offset: 0x0005A080
		// (set) Token: 0x0600099D RID: 2461 RVA: 0x0005B094 File Offset: 0x0005A094
		public bool Marque8021q
		{
			get
			{
				return this.marque8021q;
			}
			set
			{
				this.marque8021q = value;
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x0600099E RID: 2462 RVA: 0x0005B0A8 File Offset: 0x0005A0A8
		// (set) Token: 0x0600099F RID: 2463 RVA: 0x0005B0BC File Offset: 0x0005A0BC
		public bool Collisee
		{
			get
			{
				return this.collisee;
			}
			set
			{
				this.collisee = value;
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x060009A0 RID: 2464 RVA: 0x0005B0D0 File Offset: 0x0005A0D0
		// (set) Token: 0x060009A1 RID: 2465 RVA: 0x0005B0E4 File Offset: 0x0005A0E4
		public bool Annulee
		{
			get
			{
				return this.annulee;
			}
			set
			{
				this.annulee = value;
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x060009A2 RID: 2466 RVA: 0x0005B0F8 File Offset: 0x0005A0F8
		// (set) Token: 0x060009A3 RID: 2467 RVA: 0x0005B10C File Offset: 0x0005A10C
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

		// Token: 0x060009A4 RID: 2468 RVA: 0x0005B120 File Offset: 0x0005A120
		public int TempsEmission()
		{
			double num = 0.0;
			switch (this.tailleTrame)
			{
			case 0:
				num = this.reseau.Pref.CoefEmissionTrameCourte;
				break;
			case 1:
				num = 1.0;
				break;
			case 2:
				num = this.reseau.Pref.CoefEmissionTrameLongue;
				break;
			}
			return (int)((double)this.reseau.Pref.TempsEmissionTrame * num / (double)this.reseau.CoefVitesseDemo);
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x060009A5 RID: 2469 RVA: 0x0005B1A4 File Offset: 0x0005A1A4
		public int NumeroTrame
		{
			get
			{
				return this.numeroTrame;
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x060009A6 RID: 2470 RVA: 0x0005B1B8 File Offset: 0x0005A1B8
		// (set) Token: 0x060009A7 RID: 2471 RVA: 0x0005B1CC File Offset: 0x0005A1CC
		public bool BienRecue
		{
			get
			{
				return this.bienRecue;
			}
			set
			{
				this.bienRecue = value;
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x060009A8 RID: 2472 RVA: 0x0005B1E0 File Offset: 0x0005A1E0
		// (set) Token: 0x060009A9 RID: 2473 RVA: 0x0005B1F4 File Offset: 0x0005A1F4
		public int NbTransmissionsEnCours
		{
			get
			{
				return this.nbTransmissionsEnCours;
			}
			set
			{
				this.nbTransmissionsEnCours = value;
			}
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x0005B208 File Offset: 0x0005A208
		public void IncrementerNbTransmissions()
		{
			if (!this.annulee)
			{
				this.nbTransmissionsEnCours++;
				this.reseau.NbTransmissionsTotales++;
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x060009AB RID: 2475 RVA: 0x0005B240 File Offset: 0x0005A240
		public string MacEmetteur
		{
			get
			{
				return this.macEmetteur;
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x060009AC RID: 2476 RVA: 0x0005B254 File Offset: 0x0005A254
		public string MacDestinataire
		{
			get
			{
				return this.macDestinataire;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x060009AD RID: 2477 RVA: 0x0005B268 File Offset: 0x0005A268
		// (set) Token: 0x060009AE RID: 2478 RVA: 0x0005B27C File Offset: 0x0005A27C
		public string Info
		{
			get
			{
				return this.info;
			}
			set
			{
				this.info = value;
			}
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x0005B290 File Offset: 0x0005A290
		public void AddCableTraverse(Cable c)
		{
			this.cablesTraverses.Add(c);
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x0005B2AC File Offset: 0x0005A2AC
		public void Trame_TransmissionTrameAchevee(ElementReseau sender, TrameEventArgs e)
		{
			if (e.Trame == this)
			{
				ElementReseau.TransmissionTrameAchevee -= this.Trame_TransmissionTrameAchevee;
				this.RedessinerCables();
				if (e.Trame.BienRecue)
				{
					this.reseau.TrameBienRecue = true;
					if (this.TransmissionTrameAchevee != null)
					{
						this.TransmissionTrameAchevee(null, e);
					}
				}
				else
				{
					this.carteEmetteur.BackColor = this.reseau.Pref.CouleurActifEthernet;
				}
				if (this.reseau.NbTransmissionsTotales == 0)
				{
					this.reseau.ArreterSimulation(this.carteEmetteur);
				}
			}
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x0005B348 File Offset: 0x0005A348
		public void Trame_TransmissionFinTrameAchevee(ElementReseau sender, TrameEventArgs e)
		{
			if (e.Trame == this)
			{
				if (e.Trame.BienRecue)
				{
					this.reseau.TrameBienRecue = true;
					if (this.TransmissionFinTrameAchevee != null)
					{
						this.TransmissionFinTrameAchevee(null, e);
					}
				}
				this.reseau.DecrementerNbTramesEnCours("FT " + this.info);
				if (this.reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.trameReelle)
				{
					if (this.reseau.NbTrameEnCours == 0 && this.reseau.NbCollisionsDeuxPaires == 0 && this.reseau.OwnedForms.GetLength(0) == 0)
					{
						this.reseau.ArreterSimulation(this.carteEmetteur);
						return;
					}
				}
				else if (this.reseau.NbTransmissionsTotales == 0 && this.reseau.NbCollisionsDeuxPaires == 0 && this.reseau.OwnedForms.GetLength(0) == 0)
				{
					this.reseau.ArreterSimulation(this.carteEmetteur);
				}
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x060009B2 RID: 2482 RVA: 0x0005B438 File Offset: 0x0005A438
		// (set) Token: 0x060009B3 RID: 2483 RVA: 0x0005B44C File Offset: 0x0005A44C
		public CarteReseau CarteEmetteur
		{
			get
			{
				return this.carteEmetteur;
			}
			set
			{
				this.carteEmetteur = value;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x060009B4 RID: 2484 RVA: 0x0005B460 File Offset: 0x0005A460
		public bool SegmentEmetteur
		{
			get
			{
				return this.segmentEmetteur;
			}
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x0005B474 File Offset: 0x0005A474
		public void RedessinerCables()
		{
			this.segmentEmetteur = false;
			if (this.cablesTraverses.Count > 0)
			{
				foreach (object obj in this.cablesTraverses)
				{
					Cable cable = (Cable)obj;
					cable.redessiner(Cable.sensRedessiner.milieu);
					cable.Stylo = this.reseau.Pref.NormalStylo;
					if (cable == this.carteEmetteur.Lien)
					{
						this.segmentEmetteur = true;
					}
				}
			}
			this.cablesTraverses = new ArrayList();
		}

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x060009B6 RID: 2486 RVA: 0x0005B524 File Offset: 0x0005A524
		// (remove) Token: 0x060009B7 RID: 2487 RVA: 0x0005B548 File Offset: 0x0005A548
		public event TrameEventHandler TransmissionTrameAchevee;

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x060009B8 RID: 2488 RVA: 0x0005B56C File Offset: 0x0005A56C
		// (remove) Token: 0x060009B9 RID: 2489 RVA: 0x0005B590 File Offset: 0x0005A590
		public event TrameEventHandler TransmissionFinTrameAchevee;

		// Token: 0x060009BA RID: 2490 RVA: 0x0005B5B4 File Offset: 0x0005A5B4
		public bool ToutesCartesPrevenues()
		{
			return this.TransmissionTrameAchevee == null;
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x0005B5CC File Offset: 0x0005A5CC
		public void Annuler()
		{
			this.annulee = true;
			this.reseau.NbTransmissionsTotales -= this.nbTransmissionsEnCours;
			this.reseau.DecrementerNbTramesEnCours("tr annulée");
		}

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x060009BC RID: 2492 RVA: 0x0005B608 File Offset: 0x0005A608
		// (remove) Token: 0x060009BD RID: 2493 RVA: 0x0005B62C File Offset: 0x0005A62C
		public event EventHandler TrameAnnulee;

		// Token: 0x060009BE RID: 2494 RVA: 0x0005B650 File Offset: 0x0005A650
		public void GenererAnnulation()
		{
			if (this.TrameAnnulee != null)
			{
				this.TrameAnnulee(this, new EventArgs());
			}
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x0005B678 File Offset: 0x0005A678
		public void ReinitEthernet()
		{
			ElementReseau.TransmissionTrameAchevee -= this.Trame_TransmissionTrameAchevee;
			ElementReseau.TransmissionFinTrameAchevee -= this.Trame_TransmissionFinTrameAchevee;
		}

		// Token: 0x04000628 RID: 1576
		private int vlan = 0;

		// Token: 0x04000629 RID: 1577
		private bool marque8021q = false;

		// Token: 0x0400062A RID: 1578
		private bool collisee = false;

		// Token: 0x0400062B RID: 1579
		private bool annulee = false;

		// Token: 0x0400062C RID: 1580
		private int tailleTrame = 0;

		// Token: 0x0400062D RID: 1581
		private int numeroTrame;

		// Token: 0x0400062E RID: 1582
		private Simulation reseau;

		// Token: 0x0400062F RID: 1583
		private int nbTransmissionsEnCours = 0;

		// Token: 0x04000630 RID: 1584
		private bool bienRecue = false;

		// Token: 0x04000631 RID: 1585
		private string macEmetteur;

		// Token: 0x04000632 RID: 1586
		private string macDestinataire;

		// Token: 0x04000633 RID: 1587
		private string info;

		// Token: 0x04000634 RID: 1588
		private ArrayList cablesTraverses = new ArrayList();

		// Token: 0x04000635 RID: 1589
		private CarteReseau carteEmetteur;

		// Token: 0x04000636 RID: 1590
		private bool segmentEmetteur;
	}
}
