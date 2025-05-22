using System;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000090 RID: 144
	public class TraceCable
	{
		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000933 RID: 2355 RVA: 0x000573D8 File Offset: 0x000563D8
		public TraceCable.CasDroite Cas
		{
			get
			{
				return this.cas;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000934 RID: 2356 RVA: 0x000573EC File Offset: 0x000563EC
		public int SensX
		{
			get
			{
				return this.sensX;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000935 RID: 2357 RVA: 0x00057400 File Offset: 0x00056400
		public int SensY
		{
			get
			{
				return this.sensY;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000936 RID: 2358 RVA: 0x00057414 File Offset: 0x00056414
		public PointF Arrivee
		{
			get
			{
				return this.arrivee;
			}
		}

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x06000937 RID: 2359 RVA: 0x00057428 File Offset: 0x00056428
		// (remove) Token: 0x06000938 RID: 2360 RVA: 0x0005744C File Offset: 0x0005644C
		public event EventHandler TraceTermine;

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000939 RID: 2361 RVA: 0x00057470 File Offset: 0x00056470
		// (remove) Token: 0x0600093A RID: 2362 RVA: 0x00057494 File Offset: 0x00056494
		public event EventHandler DebutTrame1Arrive;

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x0600093B RID: 2363 RVA: 0x000574B8 File Offset: 0x000564B8
		// (remove) Token: 0x0600093C RID: 2364 RVA: 0x000574DC File Offset: 0x000564DC
		public event EventHandler FinTrame1Arrive;

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x0600093D RID: 2365 RVA: 0x00057500 File Offset: 0x00056500
		// (remove) Token: 0x0600093E RID: 2366 RVA: 0x00057524 File Offset: 0x00056524
		public event EventHandler DebutTrame2Arrive;

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x0600093F RID: 2367 RVA: 0x00057548 File Offset: 0x00056548
		// (remove) Token: 0x06000940 RID: 2368 RVA: 0x0005756C File Offset: 0x0005656C
		public event EventHandler FinTrame2Arrive;

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x06000941 RID: 2369 RVA: 0x00057590 File Offset: 0x00056590
		// (remove) Token: 0x06000942 RID: 2370 RVA: 0x000575B4 File Offset: 0x000565B4
		public event EventHandler Collision1;

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x06000943 RID: 2371 RVA: 0x000575D8 File Offset: 0x000565D8
		// (remove) Token: 0x06000944 RID: 2372 RVA: 0x000575FC File Offset: 0x000565FC
		public event EventHandler Collision2;

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000945 RID: 2373 RVA: 0x00057620 File Offset: 0x00056620
		public Pen StyloLigne
		{
			get
			{
				return this.styloLigne;
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000946 RID: 2374 RVA: 0x00057634 File Offset: 0x00056634
		public Pen StyloCollision
		{
			get
			{
				return this.styloCollision;
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000947 RID: 2375 RVA: 0x00057648 File Offset: 0x00056648
		public Pen Stylo8021q
		{
			get
			{
				return this.stylo8021q;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000948 RID: 2376 RVA: 0x0005765C File Offset: 0x0005665C
		public Pen StyloGomme
		{
			get
			{
				return this.styloGomme;
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000949 RID: 2377 RVA: 0x00057670 File Offset: 0x00056670
		public Graphics GraphicsCable
		{
			get
			{
				return this.graphicsCable;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x0600094A RID: 2378 RVA: 0x00057684 File Offset: 0x00056684
		public bool EnCours
		{
			get
			{
				return this.enCours;
			}
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x00057698 File Offset: 0x00056698
		public TraceCable(bool p_marque8021q, TraceCable.TypeDeTrace p_typeTrace, Pen p_styloTrame1, Pen p_styloTrame2, Pen p_styloCollision, Pen p_styloLigne, Color p_couleurGomme, ElementReseau p_cable, Point p_depart, Point p_arrivee)
		{
			this.collisionPermise = (p_typeTrace == TraceCable.TypeDeTrace.ethernetAvecCollision);
			this.styloGomme = new Pen(p_couleurGomme, 3f);
			this.typeTrace = p_typeTrace;
			this.cable = p_cable;
			this.graphicsCable = this.cable.Reseau.Schema.CreateGraphics();
			this.nbMetresParTick = this.cable.Reseau.Pref.NbMetresParTick;
			this.styloLigne = p_styloLigne;
			this.styloTrame1 = p_styloTrame1;
			this.styloTrame2 = p_styloTrame2;
			this.couleurGomme = p_couleurGomme;
			this.styloCollision = this.cable.Reseau.Pref.StyloCollision;
			this.stylo8021q = this.cable.Reseau.Pref.Stylo8021q;
			this.pointDepart = p_depart;
			this.pointArrivee = p_arrivee;
			float num = (float)this.pointDepart.X;
			float num2 = (float)this.pointDepart.Y;
			float num3 = (float)this.pointArrivee.X;
			float num4 = (float)this.pointArrivee.Y;
			this.longueur = (float)this.cable.Longueur;
			this.depart = new PointF(num, num2);
			this.arrivee = new PointF(num3, num4);
			float num5 = (float)Math.Sqrt((double)((num3 - num) * (num3 - num) + (num4 - num2) * (num4 - num2)));
			if (num3 != num)
			{
				this.a = (num4 - num2) / (num3 - num);
			}
			else
			{
				this.a = 0f;
			}
			this.b = num2 - this.a * num;
			if (num3 == num)
			{
				this.cas = TraceCable.CasDroite.dteVerticale;
				if (num2 < num4)
				{
					this.sensX = 1;
					this.sensY = 1;
				}
				else
				{
					this.sensX = -1;
					this.sensY = -1;
				}
			}
			else if (num4 == num2)
			{
				this.cas = TraceCable.CasDroite.dteHorizontale;
				this.sensY = 0;
				if (num < num3)
				{
					this.sensX = 1;
					this.sensY = 1;
				}
				else
				{
					this.sensX = -1;
					this.sensY = -1;
				}
			}
			else
			{
				this.cas = TraceCable.CasDroite.general;
				if (num < num3)
				{
					this.sensX = 1;
				}
				else
				{
					this.sensX = -1;
				}
				if (num2 < num4)
				{
					this.sensY = 1;
				}
				else
				{
					this.sensY = -1;
				}
			}
			this.vitesse = this.nbMetresParTick * (num5 / this.longueur) * this.cable.Reseau.CoefVitesseDemo;
			this.t = this.cable.Reseau.TimerTraceTrame;
			this.styloEllipse = new Pen(this.styloCollision.Brush, 1f);
			switch (this.typeTrace)
			{
			case TraceCable.TypeDeTrace.ethernetAvecCollision:
				this.etatFinal = 44;
				this.t1Deb = new TraceLigne(null, p_marque8021q, this.t, this, this.depart, this.arrivee, this.a, this.b, this.cas, this.sensX, this.sensY, this.vitesse);
				this.t1Fin = new TraceLigne(null, p_marque8021q, this.t, this, this.depart, this.arrivee, this.a, this.b, this.cas, this.sensX, this.sensY, this.vitesse);
				this.t2Deb = new TraceLigne(null, p_marque8021q, this.t, this, this.arrivee, this.depart, this.a, this.b, this.cas, -this.sensX, -this.sensY, this.vitesse);
				this.t2Fin = new TraceLigne(null, p_marque8021q, this.t, this, this.arrivee, this.depart, this.a, this.b, this.cas, -this.sensX, -this.sensY, this.vitesse);
				this.t1debEtat = new TLEtat[this.etatFinal];
				this.t1finEtat = new TLEtat[this.etatFinal];
				this.t2debEtat = new TLEtat[this.etatFinal];
				this.t2finEtat = new TLEtat[this.etatFinal];
				for (int i = 0; i < this.etatFinal; i++)
				{
					this.t1debEtat[i] = new TLEtat();
					this.t1finEtat[i] = new TLEtat();
					this.t2debEtat[i] = new TLEtat();
					this.t2finEtat[i] = new TLEtat();
				}
				this.t1debEtat[4] = new TLEtat(TypeActivite.actArrivee, this.styloTrame1, false, null, 7);
				this.t1debEtat[5] = new TLEtat(TypeActivite.actArrivee, this.styloTrame1, false, null, 6);
				this.t1debEtat[8] = new TLEtat(TypeActivite.actRencontre, this.styloTrame1, false, this.t2Deb, 0);
				this.t1debEtat[9] = new TLEtat(TypeActivite.actRencontre, this.styloTrame1, false, this.t2Deb, 1);
				this.t1debEtat[10] = new TLEtat(TypeActivite.actRencontre, this.styloTrame1, false, this.t2Deb, 2);
				this.t1debEtat[11] = new TLEtat(TypeActivite.actRencontre, this.styloTrame1, false, this.t2Deb, 3);
				this.t1debEtat[12] = new TLEtat(TypeActivite.actArrivee, this.styloCollision, false, null, 20);
				this.t1debEtat[13] = new TLEtat(TypeActivite.actArrivee, this.styloCollision, false, null, 21);
				this.t1debEtat[14] = new TLEtat(TypeActivite.actRencontre, this.styloCollision, false, this.t2Fin, 16);
				this.t1debEtat[15] = new TLEtat(TypeActivite.actRencontre, this.styloCollision, false, this.t2Fin, 17);
				this.t1debEtat[16] = new TLEtat(TypeActivite.actArrivee, this.styloCollision, false, null, 20);
				this.t1debEtat[17] = new TLEtat(TypeActivite.actArrivee, this.styloCollision, false, null, 21);
				this.t1debEtat[18] = new TLEtat(TypeActivite.actArrivee, this.styloCollision, false, null, 25);
				this.t1debEtat[19] = new TLEtat(TypeActivite.actRencontre, this.styloCollision, false, this.t2Fin, 26);
				this.t1debEtat[22] = new TLEtat(TypeActivite.actArrivee, this.styloCollision, false, null, this.etatFinal);
				this.t1debEtat[23] = new TLEtat(TypeActivite.actRencontre, this.styloCollision, false, this.t2Fin, 24);
				this.t1debEtat[24] = new TLEtat(TypeActivite.actArrivee, this.styloCollision, false, null, this.etatFinal);
				this.t1debEtat[26] = new TLEtat(TypeActivite.actArrivee, this.styloCollision, false, null, 25);
				this.t1debEtat[27] = new TLEtat(TypeActivite.actArrivee, this.styloTrame1, false, null, 30);
				this.t1debEtat[28] = new TLEtat(TypeActivite.actArrivee, this.styloTrame1, false, null, 29);
				this.t1debEtat[32] = new TLEtat(TypeActivite.actArrivee, this.styloTrame1, false, null, 35);
				this.t1debEtat[33] = new TLEtat(TypeActivite.actArrivee, this.styloTrame1, false, null, 34);
				this.t1debEtat[36] = new TLEtat(TypeActivite.actArrivee, this.styloTrame1, false, null, 39);
				this.t1debEtat[37] = new TLEtat(TypeActivite.actArrivee, this.styloTrame1, false, null, 38);
				this.t1finEtat[5] = new TLEtat(TypeActivite.actNo, this.styloLigne, true, null, this.etatFinal);
				this.t1finEtat[6] = new TLEtat(TypeActivite.actArrivee, this.styloLigne, true, null, this.etatFinal);
				this.t1finEtat[9] = new TLEtat(TypeActivite.actNo, this.styloLigne, true, null, this.etatFinal);
				this.t1finEtat[11] = new TLEtat(TypeActivite.actNo, this.styloLigne, true, null, this.etatFinal);
				this.t1finEtat[13] = new TLEtat(TypeActivite.actRencontre, this.styloLigne, true, this.t2Deb, 18);
				this.t1finEtat[15] = new TLEtat(TypeActivite.actRencontre, this.styloLigne, true, this.t2Deb, 19);
				this.t1finEtat[17] = new TLEtat(TypeActivite.actRencontre, this.styloLigne, true, this.t2Deb, 26);
				this.t1finEtat[21] = new TLEtat(TypeActivite.actRencontre, this.styloLigne, true, this.t2Deb, 25);
				this.t1finEtat[28] = new TLEtat(TypeActivite.actNo, this.styloLigne, true, null, this.etatFinal);
				this.t1finEtat[29] = new TLEtat(TypeActivite.actArrivee, this.styloLigne, true, null, 31);
				this.t1finEtat[33] = new TLEtat(TypeActivite.actNo, this.styloLigne, true, null, this.etatFinal);
				this.t1finEtat[34] = new TLEtat(TypeActivite.actArrivee, this.styloLigne, true, null, 42);
				this.t1finEtat[37] = new TLEtat(TypeActivite.actNo, this.styloLigne, true, null, this.etatFinal);
				this.t1finEtat[38] = new TLEtat(TypeActivite.actArrivee, this.styloLigne, true, null, 40);
				this.t2debEtat[8] = new TLEtat(TypeActivite.actConcurrent, this.styloTrame2, false, null, this.etatFinal);
				this.t2debEtat[9] = new TLEtat(TypeActivite.actConcurrent, this.styloTrame2, false, null, this.etatFinal);
				this.t2debEtat[10] = new TLEtat(TypeActivite.actConcurrent, this.styloTrame2, false, null, this.etatFinal);
				this.t2debEtat[11] = new TLEtat(TypeActivite.actConcurrent, this.styloTrame2, false, null, this.etatFinal);
				this.t2debEtat[12] = new TLEtat(TypeActivite.actArrivee, this.styloCollision, false, null, 22);
				this.t2debEtat[13] = new TLEtat(TypeActivite.actConcurrent, this.styloCollision, false, null, this.etatFinal);
				this.t2debEtat[14] = new TLEtat(TypeActivite.actArrivee, this.styloCollision, false, null, 23);
				this.t2debEtat[15] = new TLEtat(TypeActivite.actConcurrent, this.styloCollision, false, null, this.etatFinal);
				this.t2debEtat[16] = new TLEtat(TypeActivite.actArrivee, this.styloCollision, false, null, 24);
				this.t2debEtat[17] = new TLEtat(TypeActivite.actConcurrent, this.styloCollision, false, null, this.etatFinal);
				this.t2debEtat[18] = new TLEtat(TypeActivite.actArrivee, this.styloCollision, false, null, 22);
				this.t2debEtat[19] = new TLEtat(TypeActivite.actArrivee, this.styloCollision, false, null, 23);
				this.t2debEtat[20] = new TLEtat(TypeActivite.actArrivee, this.styloCollision, false, null, this.etatFinal);
				this.t2debEtat[21] = new TLEtat(TypeActivite.actConcurrent, this.styloCollision, false, null, this.etatFinal);
				this.t2debEtat[25] = new TLEtat(TypeActivite.actArrivee, this.styloCollision, false, null, this.etatFinal);
				this.t2debEtat[26] = new TLEtat(TypeActivite.actArrivee, this.styloCollision, false, null, 24);
				this.t2debEtat[27] = new TLEtat(TypeActivite.actNo, this.styloCollision, false, null, this.etatFinal);
				this.t2debEtat[28] = new TLEtat(TypeActivite.actNo, this.styloCollision, false, null, this.etatFinal);
				this.t2debEtat[29] = new TLEtat(TypeActivite.actNo, this.styloCollision, false, null, this.etatFinal);
				this.t2debEtat[30] = new TLEtat(TypeActivite.actArrivee, this.styloCollision, false, null, this.etatFinal);
				this.t2debEtat[31] = new TLEtat(TypeActivite.actArrivee, this.styloCollision, false, null, this.etatFinal);
				this.t2debEtat[32] = new TLEtat(TypeActivite.actNo, this.styloTrame2, false, null, this.etatFinal);
				this.t2debEtat[33] = new TLEtat(TypeActivite.actNo, this.styloTrame2, false, null, this.etatFinal);
				this.t2debEtat[34] = new TLEtat(TypeActivite.actNo, this.styloTrame2, false, null, this.etatFinal);
				this.t2debEtat[35] = new TLEtat(TypeActivite.actArrivee, this.styloTrame2, false, null, 43);
				this.t2debEtat[36] = new TLEtat(TypeActivite.actNo, this.styloTrame2, false, null, this.etatFinal);
				this.t2debEtat[37] = new TLEtat(TypeActivite.actNo, this.styloTrame2, false, null, this.etatFinal);
				this.t2debEtat[38] = new TLEtat(TypeActivite.actNo, this.styloTrame2, false, null, this.etatFinal);
				this.t2debEtat[39] = new TLEtat(TypeActivite.actArrivee, this.styloTrame2, false, null, 41);
				this.t2debEtat[40] = new TLEtat(TypeActivite.actArrivee, this.styloTrame2, false, null, 41);
				this.t2debEtat[42] = new TLEtat(TypeActivite.actArrivee, this.styloTrame2, false, null, 43);
				this.t2finEtat[10] = new TLEtat(TypeActivite.actNo, this.styloLigne, true, null, this.etatFinal);
				this.t2finEtat[11] = new TLEtat(TypeActivite.actNo, this.styloLigne, true, null, this.etatFinal);
				this.t2finEtat[14] = new TLEtat(TypeActivite.actConcurrent, this.styloLigne, true, null, this.etatFinal);
				this.t2finEtat[15] = new TLEtat(TypeActivite.actConcurrent, this.styloLigne, true, null, this.etatFinal);
				this.t2finEtat[19] = new TLEtat(TypeActivite.actConcurrent, this.styloLigne, true, null, this.etatFinal);
				this.t2finEtat[23] = new TLEtat(TypeActivite.actConcurrent, this.styloLigne, true, null, this.etatFinal);
				this.t2finEtat[36] = new TLEtat(TypeActivite.actNo, this.styloLigne, true, null, this.etatFinal);
				this.t2finEtat[37] = new TLEtat(TypeActivite.actNo, this.styloLigne, true, null, this.etatFinal);
				this.t2finEtat[38] = new TLEtat(TypeActivite.actNo, this.styloLigne, true, null, this.etatFinal);
				this.t2finEtat[39] = new TLEtat(TypeActivite.actNo, this.styloLigne, true, null, this.etatFinal);
				this.t2finEtat[40] = new TLEtat(TypeActivite.actNo, this.styloLigne, true, null, this.etatFinal);
				this.t2finEtat[41] = new TLEtat(TypeActivite.actArrivee, this.styloLigne, true, null, this.etatFinal);
				this.transitionsCollision = new int[4];
				this.transitionsCollision[0] = 12;
				this.transitionsCollision[1] = 13;
				this.transitionsCollision[2] = 14;
				this.transitionsCollision[3] = 15;
				this.transitionsAjoutCollision = new int[this.etatFinal];
				this.transitionsAjoutSuiveur = new int[this.etatFinal];
				this.transitionsFinTrame1 = new int[this.etatFinal];
				this.transitionsDebutTrame2 = new int[this.etatFinal];
				this.transitionsFinTrame2 = new int[this.etatFinal];
				this.transitionsFinTrame1[0] = 1;
				this.transitionsFinTrame1[2] = 3;
				this.transitionsFinTrame1[4] = 5;
				this.transitionsFinTrame1[7] = 6;
				this.transitionsFinTrame1[8] = 9;
				this.transitionsFinTrame1[10] = 11;
				this.transitionsFinTrame1[12] = 13;
				this.transitionsFinTrame1[14] = 15;
				this.transitionsFinTrame1[16] = 17;
				this.transitionsFinTrame1[20] = 21;
				this.transitionsDebutTrame2[4] = 8;
				this.transitionsDebutTrame2[5] = 9;
				this.transitionsFinTrame2[0] = 2;
				this.transitionsFinTrame2[1] = 3;
				this.transitionsFinTrame2[8] = 10;
				this.transitionsFinTrame2[9] = 11;
				this.transitionsFinTrame2[12] = 14;
				this.transitionsFinTrame2[13] = 15;
				this.transitionsFinTrame2[18] = 19;
				this.transitionsFinTrame2[22] = 23;
				this.transitionsFinTrame2[32] = 36;
				this.transitionsFinTrame2[33] = 37;
				this.transitionsFinTrame2[34] = 38;
				this.transitionsFinTrame2[35] = 39;
				this.transitionsFinTrame2[42] = 40;
				this.transitionsFinTrame2[43] = 41;
				this.transitionsAjoutCollision[4] = 27;
				this.transitionsAjoutCollision[5] = 28;
				this.transitionsAjoutCollision[6] = 29;
				this.transitionsAjoutCollision[7] = 30;
				this.transitionsAjoutCollision[42] = 27;
				this.transitionsAjoutCollision[40] = 28;
				this.transitionsAjoutCollision[41] = 29;
				this.transitionsAjoutCollision[43] = 30;
				this.transitionsAjoutSuiveur[4] = 32;
				this.transitionsAjoutSuiveur[5] = 33;
				this.transitionsAjoutSuiveur[6] = 34;
				this.transitionsAjoutSuiveur[7] = 35;
				this.etatCourant = -1;
				this.installerGestionnaires();
				this.changerEtat(this, new EtatTransitionEventArgs(4));
				return;
			case TraceCable.TypeDeTrace.ethernetAvecCroisement:
				break;
			case TraceCable.TypeDeTrace.ethernetNoCollision:
				this.etatFinal = 5;
				this.t1Deb = new TraceLigne(null, p_marque8021q, this.t, this, this.depart, this.arrivee, this.a, this.b, this.cas, this.sensX, this.sensY, this.vitesse);
				this.t1Fin = new TraceLigne(null, p_marque8021q, this.t, this, this.depart, this.arrivee, this.a, this.b, this.cas, this.sensX, this.sensY, this.vitesse);
				this.t2Deb = new TraceLigne(null, p_marque8021q, this.t, this, this.arrivee, this.depart, this.a, this.b, this.cas, -this.sensX, -this.sensY, this.vitesse);
				this.t2Fin = new TraceLigne(null, p_marque8021q, this.t, this, this.arrivee, this.depart, this.a, this.b, this.cas, -this.sensX, -this.sensY, this.vitesse);
				this.t1debEtat = new TLEtat[this.etatFinal];
				this.t1finEtat = new TLEtat[this.etatFinal];
				this.t2debEtat = new TLEtat[this.etatFinal];
				this.t2finEtat = new TLEtat[this.etatFinal];
				for (int j = 0; j < this.etatFinal; j++)
				{
					this.t1debEtat[j] = new TLEtat();
					this.t1finEtat[j] = new TLEtat();
					this.t2debEtat[j] = new TLEtat();
					this.t2finEtat[j] = new TLEtat();
				}
				this.t1debEtat[4] = new TLEtat(TypeActivite.actArrivee, this.styloTrame1, false, null, this.etatFinal);
				this.transitionsCollision = new int[4];
				this.transitionsFinTrame1 = new int[this.etatFinal];
				this.transitionsDebutTrame2 = new int[this.etatFinal];
				this.transitionsFinTrame2 = new int[this.etatFinal];
				this.etatCourant = -1;
				this.installerGestionnaires();
				this.changerEtat(this, new EtatTransitionEventArgs(4));
				return;
			case TraceCable.TypeDeTrace.paquetIP:
				this.etatFinal = 5;
				this.t1Deb = new TraceLigne(null, p_marque8021q, this.t, this, this.depart, this.arrivee, this.a, this.b, this.cas, this.sensX, this.sensY, this.vitesse);
				this.t1Fin = new TraceLigne(null, p_marque8021q, this.t, this, this.depart, this.arrivee, this.a, this.b, this.cas, this.sensX, this.sensY, this.vitesse);
				this.t2Deb = new TraceLigne(null, p_marque8021q, this.t, this, this.arrivee, this.depart, this.a, this.b, this.cas, -this.sensX, -this.sensY, this.vitesse);
				this.t2Fin = new TraceLigne(null, p_marque8021q, this.t, this, this.arrivee, this.depart, this.a, this.b, this.cas, -this.sensX, -this.sensY, this.vitesse);
				this.t1debEtat = new TLEtat[this.etatFinal];
				this.t1finEtat = new TLEtat[this.etatFinal];
				this.t2debEtat = new TLEtat[this.etatFinal];
				this.t2finEtat = new TLEtat[this.etatFinal];
				for (int k = 0; k < this.etatFinal; k++)
				{
					this.t1debEtat[k] = new TLEtat();
					this.t1finEtat[k] = new TLEtat();
					this.t2debEtat[k] = new TLEtat();
					this.t2finEtat[k] = new TLEtat();
				}
				this.t1debEtat[4] = new TLEtat(TypeActivite.actArrivee, this.styloTrame1, false, null, this.etatFinal);
				this.transitionsCollision = new int[4];
				this.transitionsFinTrame1 = new int[this.etatFinal];
				this.transitionsDebutTrame2 = new int[this.etatFinal];
				this.transitionsFinTrame2 = new int[this.etatFinal];
				this.etatCourant = -1;
				this.installerGestionnaires();
				this.changerEtat(this, new EtatTransitionEventArgs(4));
				return;
			case TraceCable.TypeDeTrace.etapeCheminIp:
				this.etatFinal = 5;
				this.t1Deb = new TraceLigne(null, p_marque8021q, this.t, this, this.depart, this.arrivee, this.a, this.b, this.cas, this.sensX, this.sensY, this.vitesse);
				this.t1Fin = new TraceLigne(null, p_marque8021q, this.t, this, this.depart, this.arrivee, this.a, this.b, this.cas, this.sensX, this.sensY, this.vitesse);
				this.t2Deb = new TraceLigne(null, p_marque8021q, this.t, this, this.arrivee, this.depart, this.a, this.b, this.cas, -this.sensX, -this.sensY, this.vitesse);
				this.t2Fin = new TraceLigne(null, p_marque8021q, this.t, this, this.arrivee, this.depart, this.a, this.b, this.cas, -this.sensX, -this.sensY, this.vitesse);
				this.t1debEtat = new TLEtat[this.etatFinal];
				this.t1finEtat = new TLEtat[this.etatFinal];
				this.t2debEtat = new TLEtat[this.etatFinal];
				this.t2finEtat = new TLEtat[this.etatFinal];
				for (int l = 0; l < this.etatFinal; l++)
				{
					this.t1debEtat[l] = new TLEtat();
					this.t1finEtat[l] = new TLEtat();
					this.t2debEtat[l] = new TLEtat();
					this.t2finEtat[l] = new TLEtat();
				}
				this.t1debEtat[4] = new TLEtat(TypeActivite.actArrivee, this.styloTrame1, false, null, this.etatFinal);
				this.transitionsCollision = new int[4];
				this.transitionsFinTrame1 = new int[this.etatFinal];
				this.transitionsDebutTrame2 = new int[this.etatFinal];
				this.transitionsFinTrame2 = new int[this.etatFinal];
				this.etatCourant = -1;
				this.installerGestionnaires();
				this.changerEtat(this, new EtatTransitionEventArgs(4));
				return;
			case TraceCable.TypeDeTrace.messageAppl:
				this.etatFinal = 5;
				this.t1Deb = new TraceLigne(this.cable.Reseau.Schema.Controls[0], p_marque8021q, this.t, this, this.depart, this.arrivee, this.a, this.b, this.cas, this.sensX, this.sensY, this.vitesse);
				this.t1Fin = new TraceLigne(this.cable.Reseau.Schema.Controls[0], p_marque8021q, this.t, this, this.depart, this.arrivee, this.a, this.b, this.cas, this.sensX, this.sensY, this.vitesse);
				this.t2Deb = new TraceLigne(this.cable.Reseau.Schema.Controls[0], p_marque8021q, this.t, this, this.arrivee, this.depart, this.a, this.b, this.cas, -this.sensX, -this.sensY, this.vitesse);
				this.t2Fin = new TraceLigne(this.cable.Reseau.Schema.Controls[0], p_marque8021q, this.t, this, this.arrivee, this.depart, this.a, this.b, this.cas, -this.sensX, -this.sensY, this.vitesse);
				this.t1debEtat = new TLEtat[this.etatFinal];
				this.t1finEtat = new TLEtat[this.etatFinal];
				this.t2debEtat = new TLEtat[this.etatFinal];
				this.t2finEtat = new TLEtat[this.etatFinal];
				for (int m = 0; m < this.etatFinal; m++)
				{
					this.t1debEtat[m] = new TLEtat();
					this.t1finEtat[m] = new TLEtat();
					this.t2debEtat[m] = new TLEtat();
					this.t2finEtat[m] = new TLEtat();
				}
				this.t1debEtat[4] = new TLEtat(TypeActivite.actArrivee, this.styloTrame1, false, null, this.etatFinal);
				this.transitionsCollision = new int[4];
				this.transitionsFinTrame1 = new int[this.etatFinal];
				this.transitionsDebutTrame2 = new int[this.etatFinal];
				this.transitionsFinTrame2 = new int[this.etatFinal];
				this.etatCourant = -1;
				this.installerGestionnaires();
				this.changerEtat(this, new EtatTransitionEventArgs(4));
				break;
			default:
				return;
			}
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x00058EE8 File Offset: 0x00057EE8
		private void installerGestionnaires()
		{
			this.t1Deb.Rencontre += this.changerEtat;
			this.t1Deb.Arrivee += this.gererArrivee;
			this.t1Fin.Rencontre += this.changerEtat;
			this.t1Fin.Arrivee += this.gererArrivee;
			this.t2Deb.Rencontre += this.changerEtat;
			this.t2Deb.Arrivee += this.gererArrivee;
			this.t2Fin.Rencontre += this.changerEtat;
			this.t2Fin.Arrivee += this.gererArrivee;
			this.t1Deb.DebutTrameArrive += this.genererArriveeDebutTrame1;
			this.t2Deb.DebutTrameArrive += this.genererArriveeDebutTrame2;
			this.t1Fin.FinTrameArrivee += this.genererArriveeFinTrame1;
			this.t2Fin.FinTrameArrivee += this.genererArriveeFinTrame2;
			this.t1Deb.Collision += this.genererCollision;
			this.t2Deb.Collision += this.genererCollision;
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x00059038 File Offset: 0x00058038
		private void desinstallerGestionnaires()
		{
			this.t1Deb.Rencontre -= this.changerEtat;
			this.t1Deb.Arrivee -= this.gererArrivee;
			this.t1Fin.Rencontre -= this.changerEtat;
			this.t1Fin.Arrivee -= this.gererArrivee;
			this.t2Deb.Rencontre -= this.changerEtat;
			this.t2Deb.Arrivee -= this.gererArrivee;
			this.t2Fin.Rencontre -= this.changerEtat;
			this.t2Fin.Arrivee -= this.gererArrivee;
			this.t1Deb.DebutTrameArrive -= this.genererArriveeDebutTrame1;
			this.t2Deb.DebutTrameArrive -= this.genererArriveeDebutTrame2;
			this.t1Fin.FinTrameArrivee -= this.genererArriveeFinTrame1;
			this.t1Fin.FinTrameArrivee -= this.genererArriveeFinTrame2;
			this.t1Deb.Collision -= this.genererCollision;
			this.t2Deb.Collision -= this.genererCollision;
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x00059188 File Offset: 0x00058188
		public void genererArriveeDebutTrame1(object sender, EventArgs e)
		{
			if (this.DebutTrame1Arrive != null)
			{
				this.DebutTrame1Arrive(this, e);
			}
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x000591AC File Offset: 0x000581AC
		public void genererArriveeDebutTrame2(object sender, EventArgs e)
		{
			if (this.DebutTrame2Arrive != null)
			{
				this.DebutTrame2Arrive(this, e);
			}
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x000591D0 File Offset: 0x000581D0
		public void genererArriveeFinTrame1(object sender, EventArgs e)
		{
			if (this.FinTrame1Arrive != null)
			{
				this.FinTrame1Arrive(this, e);
			}
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x000591F4 File Offset: 0x000581F4
		public void genererArriveeFinTrame2(object sender, EventArgs e)
		{
			if (this.FinTrame2Arrive != null)
			{
				this.FinTrame2Arrive(this, e);
			}
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x00059218 File Offset: 0x00058218
		public void genererCollision(object sender, EventArgs e)
		{
			if (sender == this.t1Deb)
			{
				if (this.Collision1 != null)
				{
					this.Collision1(this, e);
					return;
				}
			}
			else if (this.Collision2 != null)
			{
				this.Collision2(this, e);
			}
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x0005925C File Offset: 0x0005825C
		private void changerEtat(object sender, EtatTransitionEventArgs e)
		{
			int evt = e.Evt;
			this.etatPrecedent = this.etatCourant;
			this.etatCourant = evt;
			if (evt < 4)
			{
				if (this.etatPrecedent >= 4)
				{
					if (this.collisionPermise)
					{
						this.t1Deb.Stop();
						this.t2Deb.Stop();
						this.t1Fin.Stop();
						this.t2Fin.Stop();
						this.pointCollision = this.t1Deb.Pos;
						this.collisionEnCours = true;
						this.nbCercles = (int)((double)this.cable.Reseau.Pref.DistanceCercleCollision * 0.65);
						this.graphicsCable.FillEllipse(this.styloEllipse.Brush, this.pointCollision.X - (float)(this.nbCercles / 2 + 1), this.pointCollision.Y - (float)(this.nbCercles / 2 + 1), (float)(this.nbCercles + 2), (float)(this.nbCercles + 2));
						this.t.Tick += this.dessinerCollision;
						return;
					}
					this.t1debEtat[evt].SetTraceLigne(this.t1Deb);
					this.t1finEtat[evt].SetTraceLigne(this.t1Fin);
					this.t2debEtat[evt].SetTraceLigne(this.t2Deb);
					this.t2finEtat[evt].SetTraceLigne(this.t2Fin);
					return;
				}
			}
			else
			{
				this.t1Deb.Stop();
				this.t2Deb.Stop();
				this.t1Fin.Stop();
				this.t2Fin.Stop();
				this.t1debEtat[evt].SetTraceLigne(this.t1Deb);
				this.t1finEtat[evt].SetTraceLigne(this.t1Fin);
				this.t2debEtat[evt].SetTraceLigne(this.t2Deb);
				this.t2finEtat[evt].SetTraceLigne(this.t2Fin);
			}
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x00059440 File Offset: 0x00058440
		private void gererArrivee(object sender, EtatTransitionEventArgs e)
		{
			int evt = e.Evt;
			if (evt != this.etatFinal)
			{
				this.changerEtat(sender, e);
				return;
			}
			if (this.etatCourant == 30)
			{
				this.genererArriveeFinTrame1(this, new EventArgs());
			}
			this.desinstallerGestionnaires();
			this.enCours = false;
			if (this.TraceTermine != null)
			{
				this.TraceTermine(this, new EventArgs());
			}
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x000594A4 File Offset: 0x000584A4
		public void Stopper()
		{
			this.t.Tick -= this.dessinerCollision;
			this.t1Deb.Stop();
			this.t1Fin.Stop();
			this.t2Deb.Stop();
			this.t2Fin.Stop();
			this.desinstallerGestionnaires();
			if (this.graphicsCable != null)
			{
				this.graphicsCable.Dispose();
				this.cable.Reseau.Schema.Invalidate(new Rectangle((int)(this.pointCollision.X - (float)(this.nbCercles / 2 + 2)), (int)(this.pointCollision.Y - (float)(this.nbCercles / 2 + 2)), this.nbCercles + 5, this.nbCercles + 5), false);
			}
			if (this.TraceTermine != null)
			{
				this.TraceTermine(this, new EventArgs());
			}
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x00059584 File Offset: 0x00058584
		public void AjouterConcurrent()
		{
			this.changerEtat(this, new EtatTransitionEventArgs(this.transitionsDebutTrame2[this.etatCourant]));
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000957 RID: 2391 RVA: 0x000595AC File Offset: 0x000585AC
		public bool ExisteSuiveur
		{
			get
			{
				return this.existeSuiveur;
			}
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x000595C0 File Offset: 0x000585C0
		public void AjouterCollision()
		{
			if (!this.existeSuiveur)
			{
				this.t2Deb.Inverser();
				this.t2Fin.Inverser();
				this.changerEtat(this, new EtatTransitionEventArgs(this.transitionsAjoutCollision[this.etatCourant]));
				return;
			}
			this.t2finEtat[36] = new TLEtat(TypeActivite.actNo, this.styloCollision, false, null, this.etatFinal);
			this.t2finEtat[37] = new TLEtat(TypeActivite.actNo, this.styloCollision, false, null, this.etatFinal);
			this.t2finEtat[38] = new TLEtat(TypeActivite.actNo, this.styloCollision, false, null, this.etatFinal);
			this.t2finEtat[39] = new TLEtat(TypeActivite.actNo, this.styloCollision, false, null, this.etatFinal);
			this.t2finEtat[40] = new TLEtat(TypeActivite.actNo, this.styloCollision, false, null, this.etatFinal);
			this.t2finEtat[41] = new TLEtat(TypeActivite.actArrivee, this.styloCollision, false, null, this.etatFinal);
			this.t2Fin.Stylo = this.styloCollision;
			this.t2Fin.Gomme = false;
			this.fin2Collision = true;
			this.FinirTrame(2);
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x000596E0 File Offset: 0x000586E0
		public void AjouterSuiveur()
		{
			this.t2Deb.Inverser();
			this.t2Fin.Inverser();
			this.existeSuiveur = true;
			this.changerEtat(this, new EtatTransitionEventArgs(this.transitionsAjoutSuiveur[this.etatCourant]));
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x00059724 File Offset: 0x00058724
		public bool ReceptifFinTrameCollisee()
		{
			return this.etatCourant != 6 && this.etatCourant != 5;
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x00059748 File Offset: 0x00058748
		public bool ReceptifFinTrame()
		{
			return this.etatCourant != 27 && this.etatCourant != 30;
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x00059770 File Offset: 0x00058770
		public void FinirTrame(int numTrame)
		{
			if (numTrame == 1)
			{
				this.changerEtat(this, new EtatTransitionEventArgs(this.transitionsFinTrame1[this.etatCourant]));
				return;
			}
			this.changerEtat(this, new EtatTransitionEventArgs(this.transitionsFinTrame2[this.etatCourant]));
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x000597B4 File Offset: 0x000587B4
		public void TracerCable(object sender, PaintEventArgs e)
		{
			switch (this.typeTrace)
			{
			case TraceCable.TypeDeTrace.ethernetAvecCollision:
				if (this.etatCourant < 27)
				{
					if (this.etatCourant < 12)
					{
						this.graphicsCable.DrawLine(this.styloLigne, this.depart, this.t1Fin.Pos);
						this.graphicsCable.DrawLine(this.styloTrame1, this.t1Fin.Pos, this.t1Deb.Pos);
						this.graphicsCable.DrawLine(this.styloLigne, this.t1Deb.Pos, this.t2Deb.Pos);
						this.graphicsCable.DrawLine(this.styloTrame2, this.t2Deb.Pos, this.t2Fin.Pos);
						this.graphicsCable.DrawLine(this.styloLigne, this.t2Fin.Pos, this.arrivee);
					}
					else
					{
						this.graphicsCable.DrawLine(this.styloLigne, this.depart, this.t1Fin.Pos);
						this.graphicsCable.DrawLine(this.styloTrame1, this.t1Fin.Pos, this.t2Deb.Pos);
						this.graphicsCable.DrawLine(this.styloCollision, this.t2Deb.Pos, this.t1Deb.Pos);
						if (this.t1Deb < this.t2Fin)
						{
							this.graphicsCable.DrawLine(this.styloTrame2, this.t1Deb.Pos, this.t2Fin.Pos);
							this.graphicsCable.DrawLine(this.styloLigne, this.t2Fin.Pos, this.arrivee);
						}
					}
					if (this.collisionEnCours)
					{
						int i = (int)((double)this.cable.Reseau.Pref.DistanceCercleCollision * 0.65);
						this.graphicsCable.FillEllipse(this.styloEllipse.Brush, this.pointCollision.X - (float)(i / 2 + 1), this.pointCollision.Y - (float)(i / 2 + 1), (float)(i + 2), (float)(i + 2));
						for (i += this.cable.Reseau.Pref.DistanceCercleCollision; i <= this.nbCercles; i += this.cable.Reseau.Pref.DistanceCercleCollision)
						{
							this.graphicsCable.DrawEllipse(this.styloEllipse, this.pointCollision.X - (float)(i / 2 + 1), this.pointCollision.Y - (float)(i / 2 + 1), (float)(i + 2), (float)(i + 2));
						}
						return;
					}
				}
				else
				{
					if (this.etatCourant < 32)
					{
						this.graphicsCable.DrawLine(this.styloLigne, this.depart, this.arrivee);
						this.graphicsCable.DrawLine(this.styloTrame1, this.t1Deb.Pos, this.t1Fin.Pos);
						this.graphicsCable.DrawLine(this.styloCollision, this.depart, this.t2Deb.Pos);
						return;
					}
					this.graphicsCable.DrawLine(this.styloLigne, this.depart, this.arrivee);
					this.graphicsCable.DrawLine(this.styloTrame1, this.t1Deb.Pos, this.t1Fin.Pos);
					this.graphicsCable.DrawLine(this.styloTrame2, this.t2Deb.Pos, this.t2Fin.Pos);
					if (this.fin2Collision)
					{
						this.graphicsCable.DrawLine(this.styloCollision, this.depart, this.t2Fin.Pos);
						return;
					}
				}
				break;
			case TraceCable.TypeDeTrace.ethernetAvecCroisement:
			case TraceCable.TypeDeTrace.messageAppl:
				break;
			case TraceCable.TypeDeTrace.ethernetNoCollision:
				this.graphicsCable.DrawLine(this.styloTrame1, this.depart, this.t1Deb.Pos);
				this.graphicsCable.DrawLine(this.styloLigne, this.t1Deb.Pos, this.arrivee);
				return;
			case TraceCable.TypeDeTrace.paquetIP:
				this.graphicsCable.DrawLine(this.styloTrame1, this.depart, this.t1Deb.Pos);
				return;
			case TraceCable.TypeDeTrace.etapeCheminIp:
				this.graphicsCable.DrawLine(this.styloLigne, this.depart, this.arrivee);
				this.graphicsCable.DrawLine(this.styloTrame1, this.depart, this.t1Deb.Pos);
				break;
			default:
				return;
			}
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x00059C24 File Offset: 0x00058C24
		public void dessinerCollision(object sender, EventArgs e)
		{
			this.nbTicksAttente++;
			if (this.nbTicksAttente > this.cable.Reseau.Pref.NbTicksAttenteCercleCollision)
			{
				this.nbCercles += this.cable.Reseau.Pref.DistanceCercleCollision;
				if (this.nbCercles > this.cable.Reseau.Pref.LimiteCercleCollision)
				{
					this.collisionEnCours = false;
					this.cable.Reseau.Schema.Invalidate(new Rectangle((int)(this.pointCollision.X - (float)(this.nbCercles / 2 + 2)), (int)(this.pointCollision.Y - (float)(this.nbCercles / 2 + 2)), this.nbCercles + 5, this.nbCercles + 5), false);
					this.t.Tick -= this.dessinerCollision;
					this.changerEtat(this, new EtatTransitionEventArgs(this.transitionsCollision[this.etatCourant]));
				}
				else
				{
					this.graphicsCable.DrawEllipse(this.styloEllipse, this.pointCollision.X - (float)(this.nbCercles / 2 + 1), this.pointCollision.Y - (float)(this.nbCercles / 2 + 1), (float)(this.nbCercles + 2), (float)(this.nbCercles + 2));
				}
				this.nbTicksAttente = 0;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x0600095F RID: 2399 RVA: 0x00059D90 File Offset: 0x00058D90
		// (set) Token: 0x06000960 RID: 2400 RVA: 0x00059DA4 File Offset: 0x00058DA4
		public bool EnCollisionDeuxPaires
		{
			get
			{
				return this.enCollisionDeuxPaires;
			}
			set
			{
				this.enCollisionDeuxPaires = value;
			}
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x00059DB8 File Offset: 0x00058DB8
		public void ReinitEthernet()
		{
			try
			{
				this.t1Deb.DebutTrameArrive -= this.genererArriveeDebutTrame1;
				this.t1Deb.Collision -= this.genererCollision;
				this.t1Deb.ReinitEthernet();
				this.t1Deb = null;
			}
			catch
			{
			}
			try
			{
				this.t1Fin.FinTrameArrivee -= this.genererArriveeFinTrame1;
				this.t1Fin.FinTrameArrivee -= this.genererArriveeFinTrame2;
				this.t1Fin.ReinitEthernet();
				this.t1Fin = null;
			}
			catch
			{
			}
			try
			{
				this.t2Deb.Rencontre -= this.changerEtat;
				this.t2Deb.Arrivee -= this.gererArrivee;
				this.t2Deb.DebutTrameArrive -= this.genererArriveeDebutTrame2;
				this.t2Deb.Collision -= this.genererCollision;
				this.t2Deb.ReinitEthernet();
				this.t2Deb = null;
			}
			catch
			{
			}
			try
			{
				this.t2Fin.Rencontre -= this.changerEtat;
				this.t2Fin.Arrivee -= this.gererArrivee;
				this.t2Fin.ReinitEthernet();
				this.t2Fin = null;
			}
			catch
			{
			}
			this.t.Tick -= this.dessinerCollision;
			this.t.Tick -= this.dessinerCollision;
			this.t.Tick -= this.dessinerCollision;
			this.t = null;
		}

		// Token: 0x040005C1 RID: 1473
		private TraceCable.CasDroite cas;

		// Token: 0x040005C2 RID: 1474
		private int sensX;

		// Token: 0x040005C3 RID: 1475
		private int sensY;

		// Token: 0x040005C4 RID: 1476
		private float nbMetresParTick;

		// Token: 0x040005C5 RID: 1477
		private ElementReseau cable;

		// Token: 0x040005C6 RID: 1478
		private Point pointDepart;

		// Token: 0x040005C7 RID: 1479
		private Point pointArrivee;

		// Token: 0x040005C8 RID: 1480
		private PointF depart;

		// Token: 0x040005C9 RID: 1481
		private PointF arrivee;

		// Token: 0x040005CA RID: 1482
		private float vitesse;

		// Token: 0x040005CB RID: 1483
		private float a;

		// Token: 0x040005CC RID: 1484
		private float b;

		// Token: 0x040005CD RID: 1485
		private float longueur;

		// Token: 0x040005CE RID: 1486
		private TraceLigne t1Deb;

		// Token: 0x040005CF RID: 1487
		private TraceLigne t1Fin;

		// Token: 0x040005D0 RID: 1488
		private TraceLigne t2Deb;

		// Token: 0x040005D1 RID: 1489
		private TraceLigne t2Fin;

		// Token: 0x040005D2 RID: 1490
		private Timer t;

		// Token: 0x040005DA RID: 1498
		private Pen styloTrame1;

		// Token: 0x040005DB RID: 1499
		private Pen styloTrame2;

		// Token: 0x040005DC RID: 1500
		private Pen styloLigne;

		// Token: 0x040005DD RID: 1501
		private Color couleurGomme;

		// Token: 0x040005DE RID: 1502
		private Pen styloCollision;

		// Token: 0x040005DF RID: 1503
		private Pen stylo8021q;

		// Token: 0x040005E0 RID: 1504
		private TraceCable.TypeDeTrace typeTrace;

		// Token: 0x040005E1 RID: 1505
		private Pen styloGomme;

		// Token: 0x040005E2 RID: 1506
		private PointF pointCollision;

		// Token: 0x040005E3 RID: 1507
		private Graphics graphicsCable;

		// Token: 0x040005E4 RID: 1508
		private int nbCercles = 0;

		// Token: 0x040005E5 RID: 1509
		private bool collisionEnCours = false;

		// Token: 0x040005E6 RID: 1510
		private int nbTicksAttente = 0;

		// Token: 0x040005E7 RID: 1511
		private Pen styloEllipse;

		// Token: 0x040005E8 RID: 1512
		private int etatCourant;

		// Token: 0x040005E9 RID: 1513
		private int etatPrecedent;

		// Token: 0x040005EA RID: 1514
		private int etatFinal;

		// Token: 0x040005EB RID: 1515
		private bool collisionPermise;

		// Token: 0x040005EC RID: 1516
		private bool enCours = true;

		// Token: 0x040005ED RID: 1517
		private TLEtat[] t1debEtat;

		// Token: 0x040005EE RID: 1518
		private TLEtat[] t1finEtat;

		// Token: 0x040005EF RID: 1519
		private TLEtat[] t2debEtat;

		// Token: 0x040005F0 RID: 1520
		private TLEtat[] t2finEtat;

		// Token: 0x040005F1 RID: 1521
		private int[] transitionsCollision;

		// Token: 0x040005F2 RID: 1522
		private int[] transitionsFinTrame1;

		// Token: 0x040005F3 RID: 1523
		private int[] transitionsDebutTrame2;

		// Token: 0x040005F4 RID: 1524
		private int[] transitionsFinTrame2;

		// Token: 0x040005F5 RID: 1525
		private int[] transitionsAjoutCollision;

		// Token: 0x040005F6 RID: 1526
		private int[] transitionsAjoutSuiveur;

		// Token: 0x040005F7 RID: 1527
		private bool existeSuiveur = false;

		// Token: 0x040005F8 RID: 1528
		private bool fin2Collision = false;

		// Token: 0x040005F9 RID: 1529
		private bool enCollisionDeuxPaires = false;

		// Token: 0x02000091 RID: 145
		public enum CasDroite
		{
			// Token: 0x040005FB RID: 1531
			dteVerticale,
			// Token: 0x040005FC RID: 1532
			dteHorizontale,
			// Token: 0x040005FD RID: 1533
			general
		}

		// Token: 0x02000092 RID: 146
		public enum TypeDeTrace
		{
			// Token: 0x040005FF RID: 1535
			ethernetAvecCollision,
			// Token: 0x04000600 RID: 1536
			ethernetAvecCroisement,
			// Token: 0x04000601 RID: 1537
			ethernetNoCollision,
			// Token: 0x04000602 RID: 1538
			paquetIP,
			// Token: 0x04000603 RID: 1539
			etapeCheminIp,
			// Token: 0x04000604 RID: 1540
			messageAppl
		}
	}
}
