using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200001D RID: 29
	public partial class DDialogPlusEmissionTrame : DDialogPlus
	{
		// Token: 0x060001D3 RID: 467 RVA: 0x0000F82C File Offset: 0x0000E82C
		public DDialogPlusEmissionTrame()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0000F854 File Offset: 0x0000E854
		public DDialogPlusEmissionTrame(PointConnexion elt, Form f, int p_tempsEmission, bool p_collisionDeuxPaires, bool p_genererFinTrame) : base(f)
		{
			this.avirer = elt;
			this.InitializeComponent();
			this.rnd = Simulation.Rnd;
			this.tempsEmission = p_tempsEmission;
			this.collisionDeuxPaires = p_collisionDeuxPaires;
			this.genererFinTrame = p_genererFinTrame;
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x0000F958 File Offset: 0x0000E958
		private int attenteReemission()
		{
			int num = 0;
			double delaiReemissionW = this.eltRes.Reseau.Pref.DelaiReemissionW;
			int delaiReemissionX = this.eltRes.Reseau.Pref.DelaiReemissionX;
			int delaiReemissionY = this.eltRes.Reseau.Pref.DelaiReemissionY;
			int delaiReemissionZ = this.eltRes.Reseau.Pref.DelaiReemissionZ;
			if (!this.eltRes.Reseau.BisEnCours)
			{
				if (delaiReemissionW == 0.0)
				{
					num = (int)((float)(++this.nbEssaisEmission * delaiReemissionX * Simulation.Rnd.Next(delaiReemissionY) + delaiReemissionZ) / this.eltRes.Reseau.CoefVitesseDemo);
				}
				else
				{
					num = (int)(((double)this.trame.NumeroTrame * delaiReemissionW * (double)(++this.nbEssaisEmission) * (double)delaiReemissionX * (double)Simulation.Rnd.Next(delaiReemissionY) + (double)delaiReemissionZ) / (double)this.eltRes.Reseau.CoefVitesseDemo);
				}
				this.eltRes.Reseau.DerniereSimulation.AjouterDelaiReemission(num);
			}
			else if (!this.eltRes.Reseau.DerniereSimulation.GetDelaiReemission(ref num))
			{
				if (delaiReemissionW == 0.0)
				{
					num = (int)((float)(++this.nbEssaisEmission * delaiReemissionX * Simulation.Rnd.Next(delaiReemissionY) + delaiReemissionZ) / this.eltRes.Reseau.CoefVitesseDemo);
				}
				else
				{
					num = (int)(((double)this.trame.NumeroTrame * delaiReemissionW * (double)(++this.nbEssaisEmission) * (double)delaiReemissionX * (double)Simulation.Rnd.Next(delaiReemissionY) + (double)delaiReemissionZ) / (double)this.eltRes.Reseau.CoefVitesseDemo);
				}
				this.eltRes.Reseau.DerniereSimulation.AjouterDelaiReemission(num);
			}
			return num;
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x0000FB48 File Offset: 0x0000EB48
		public bool EnEmission
		{
			get
			{
				return this.etat == 1;
			}
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x0000FB60 File Offset: 0x0000EB60
		public void DemarrerDemo(TrameEthernet t, ElementReseau p_eltRes, Point position, bool p_afficher, bool p_attenteFin, bool p_fullDuplex)
		{
			this.fullDuplex = p_fullDuplex;
			this.trame = t;
			base.DemarrerDemo(p_eltRes, position, p_afficher, p_attenteFin);
		}

		// Token: 0x060001DA RID: 474 RVA: 0x0000FB88 File Offset: 0x0000EB88
		protected override void init(bool p_afficher, bool p_attenteFin)
		{
			this.actions.Add("Ecoute du câble");
			if (this.fullDuplex)
			{
				this.actions.Add("Emission de la trame");
			}
			else
			{
				this.actions.Add("Emission de la trame et écoute du câble");
			}
			this.actions.Add("Fin d'émission de la trame");
			this.actions.Add("Attente câble libre");
			this.actions.Add("Collision détectée");
			this.actions.Add("Attente avant réémission");
			this.attente.TempsAttenteEvenement.Add(0);
			if (p_attenteFin)
			{
				this.attente.TempsAttenteEvenement.Add((int)((float)this.eltRes.Reseau.Pref.TempsInterTrames / this.eltRes.Reseau.CoefVitesseDemo));
			}
			else
			{
				this.attente.TempsAttenteEvenement.Add(1);
			}
			this.attente.TempsAttenteEvenement.Add(this.eltRes.Reseau.Pref.TempsAttenteEcoute);
			this.attente.TempsAttenteEvenement.Add(this.attenteReemission());
			if (this.genererFinTrame)
			{
				this.attente.TempsAttenteEvenement.Add(this.tempsEmission);
			}
		}

		// Token: 0x060001DB RID: 475 RVA: 0x0000FCF4 File Offset: 0x0000ECF4
		protected override void fin()
		{
			this.eltRes.BackColor = this.eltRes.Reseau.Pref.CouleurActifEthernet;
		}

		// Token: 0x060001DC RID: 476 RVA: 0x0000FD24 File Offset: 0x0000ED24
		public void FixerPosition()
		{
			if (((PointConnexion)this.eltRes).PosDemoEmission != new Point(base.Location.X, base.Location.Y))
			{
				((PointConnexion)this.eltRes).PosDemoEmission = new Point(base.Location.X, base.Location.Y);
				((PointConnexion)this.eltRes).Reseau.GereDoc.FaireAction(ActionDocument.modifier);
			}
		}

		// Token: 0x060001DD RID: 477 RVA: 0x0000FDB8 File Offset: 0x0000EDB8
		public override void FinDemo()
		{
			((PointConnexion)this.eltRes).EvtEtatTransition -= this.executerTransition;
			this.FixerPosition();
			base.FinDemo();
		}

		// Token: 0x060001DE RID: 478 RVA: 0x0000FDF0 File Offset: 0x0000EDF0
		protected override void executerTransition(object sender, EtatTransitionEventArgs e)
		{
			DDialogPlusEmissionTrame.TypEvtTransition evt = (DDialogPlusEmissionTrame.TypEvtTransition)e.Evt;
			switch (this.etat)
			{
			case -1:
			{
				DDialogPlusEmissionTrame.TypEvtTransition typEvtTransition = evt;
				if (typEvtTransition == DDialogPlusEmissionTrame.TypEvtTransition.debut)
				{
					((PointConnexion)this.eltRes).EvtEtatTransition += this.executerTransition;
					if (this.fullDuplex)
					{
						this.etat = 1;
						this.tb_resultat.Text = "Emission en cours";
						if (this.genererFinTrame)
						{
							this.attente.Demarrer(4);
						}
						((PointConnexion)this.eltRes).DebutTrameSurCable();
					}
					else if (!this.eltRes.Occupe())
					{
						this.etat = 0;
						this.tb_resultat.Text = "Câble libre";
						this.attente.Demarrer(2);
					}
					else
					{
						this.etat = 3;
						this.tb_resultat.Text = "Câble occupé, attente";
					}
				}
				break;
			}
			case 0:
			{
				DDialogPlusEmissionTrame.TypEvtTransition typEvtTransition = evt;
				if (typEvtTransition != DDialogPlusEmissionTrame.TypEvtTransition.finEcouteCable)
				{
					if (typEvtTransition == DDialogPlusEmissionTrame.TypEvtTransition.carteTrameRecue)
					{
						this.attente.Arreter();
						this.etat = 3;
						this.tb_resultat.Text = "Câble occupé, attente";
					}
				}
				else
				{
					this.etat = 1;
					this.tb_resultat.Text = "Pas de collision";
					if (this.genererFinTrame)
					{
						this.attente.Demarrer(4);
					}
					((PointConnexion)this.eltRes).DebutTrameSurCable();
				}
				break;
			}
			case 1:
				switch (evt)
				{
				case DDialogPlusEmissionTrame.TypEvtTransition.finEmissionTrame:
					this.etat = 2;
					this.tb_resultat.Text = "Emission terminée correctement";
					this.attente.Demarrer(1);
					((PointConnexion)this.eltRes).FinTrameSurCable(false);
					break;
				case DDialogPlusEmissionTrame.TypEvtTransition.carteCollisionRecue:
					if (this.collisionDeuxPaires)
					{
						((PointConnexion)this.eltRes).FinTrameSurCable(true);
						this.okPourReemission = false;
						this.attente.Arreter();
						this.tb_resultat.Text = "Collision détectée";
						this.etat = 5;
					}
					else
					{
						this.okPourReemission = false;
						this.attente.Arreter();
						this.etat = 4;
						int num = this.attenteReemission();
						this.attente.TempsAttenteEvenement[3] = num;
						this.tb_resultat.Text = "Délai avant réémission : " + num.ToString();
						this.attente.Demarrer(3);
					}
					break;
				}
				break;
			case 3:
			{
				DDialogPlusEmissionTrame.TypEvtTransition typEvtTransition = evt;
				if (typEvtTransition == DDialogPlusEmissionTrame.TypEvtTransition.carteCableLibre)
				{
					this.etat = 1;
					this.tb_resultat.Text = "Pas de collision";
					this.attente.Demarrer(4);
					((PointConnexion)this.eltRes).DebutTrameSurCable();
				}
				break;
			}
			case 4:
			{
				DDialogPlusEmissionTrame.TypEvtTransition typEvtTransition = evt;
				switch (typEvtTransition)
				{
				case DDialogPlusEmissionTrame.TypEvtTransition.finAttenteReemission:
					if (this.okPourReemission)
					{
						this.attente.Arreter();
						this.etat = 1;
						this.tb_resultat.Text = "Pas de collision";
						this.attente.Demarrer(4);
						((PointConnexion)this.eltRes).DebutTrameSurCable();
					}
					else
					{
						this.etat = 3;
						this.tb_resultat.Text = "Câble occupé, attente";
					}
					break;
				case DDialogPlusEmissionTrame.TypEvtTransition.finEmissionTrame:
					break;
				case DDialogPlusEmissionTrame.TypEvtTransition.carteTrameRecue:
					this.okPourReemission = false;
					break;
				default:
					if (typEvtTransition == DDialogPlusEmissionTrame.TypEvtTransition.carteCableLibre)
					{
						this.okPourReemission = true;
					}
					break;
				}
				break;
			}
			case 5:
			{
				DDialogPlusEmissionTrame.TypEvtTransition typEvtTransition = evt;
				if (typEvtTransition == DDialogPlusEmissionTrame.TypEvtTransition.carteCableLibre)
				{
					this.okPourReemission = true;
					this.attente.Arreter();
					this.etat = 4;
					int num2 = this.attenteReemission();
					this.attente.TempsAttenteEvenement[3] = num2;
					this.tb_resultat.Text = "Délai avant réémission : " + num2.ToString();
					this.attente.Demarrer(3);
				}
				break;
			}
			}
			if (this.etat == 2 && evt == DDialogPlusEmissionTrame.TypEvtTransition.finAttenteDemo)
			{
				this.FinDemo();
				return;
			}
			this.tb_phase.Text = (string)this.actions[this.etat];
		}

		// Token: 0x060001DF RID: 479 RVA: 0x000101EC File Offset: 0x0000F1EC
		public void ReinitEthernet()
		{
			((PointConnexion)this.eltRes).EvtEtatTransition -= this.executerTransition;
			TimerEtatTransition attente = this.attente;
			attente.EvtEtatTransition = (EtatTransitionEventHandler)Delegate.Remove(attente.EvtEtatTransition, new EtatTransitionEventHandler(this.executerTransition));
			base.Close();
			base.Dispose();
		}

		// Token: 0x040000EE RID: 238
		private PointConnexion avirer;

		// Token: 0x040000EF RID: 239
		private bool genererFinTrame;

		// Token: 0x040000F0 RID: 240
		private bool collisionDeuxPaires;

		// Token: 0x040000F1 RID: 241
		private Random rnd;

		// Token: 0x040000F2 RID: 242
		private int tempsEmission;

		// Token: 0x040000F3 RID: 243
		private int nbEssaisEmission = 0;

		// Token: 0x040000F4 RID: 244
		private bool okPourReemission;

		// Token: 0x040000F5 RID: 245
		private TrameEthernet trame;

		// Token: 0x040000F6 RID: 246
		private bool fullDuplex;

		// Token: 0x0200001E RID: 30
		public enum TypEvtTransition
		{
			// Token: 0x040000F8 RID: 248
			debut,
			// Token: 0x040000F9 RID: 249
			finAttenteDemo,
			// Token: 0x040000FA RID: 250
			finEcouteCable,
			// Token: 0x040000FB RID: 251
			finAttenteReemission,
			// Token: 0x040000FC RID: 252
			finEmissionTrame,
			// Token: 0x040000FD RID: 253
			carteTrameRecue,
			// Token: 0x040000FE RID: 254
			carteCollisionRecue,
			// Token: 0x040000FF RID: 255
			carteCollisionTransmise,
			// Token: 0x04000100 RID: 256
			carteCableLibre
		}
	}
}
