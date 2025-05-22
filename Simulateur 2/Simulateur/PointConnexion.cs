using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200000E RID: 14
	public class PointConnexion : ElementReseau
	{
		// Token: 0x060000F3 RID: 243 RVA: 0x00008CEC File Offset: 0x00007CEC
		public PointConnexion()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00008D68 File Offset: 0x00007D68
		public PointConnexion(Simulation s) : base(s)
		{
			this.InitializeComponent();
			this.initialiser();
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00008DEC File Offset: 0x00007DEC
		private void initialiser()
		{
			base.Size = new Size(11, 11);
			this.BackColor = this.reseau.Schema.BackColor;
			this.initOkCables();
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x00008E24 File Offset: 0x00007E24
		// (set) Token: 0x060000F7 RID: 247 RVA: 0x00008E38 File Offset: 0x00007E38
		public Point PosDemoEmission
		{
			get
			{
				return this.posDemoEmission;
			}
			set
			{
				this.posDemoEmission = value;
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00008E4C File Offset: 0x00007E4C
		protected virtual void initOkCables()
		{
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x00008E5C File Offset: 0x00007E5C
		public PointConnexion.TypesPointConnexion TypePointConnexion
		{
			get
			{
				return this.typePointConnexion;
			}
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00008E70 File Offset: 0x00007E70
		public bool OkCableDroit(PointConnexion.TypesPointConnexion t)
		{
			return this.okCableDroit.Contains(t);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00008E90 File Offset: 0x00007E90
		public bool OkCableCroise(PointConnexion.TypesPointConnexion t)
		{
			return this.okCableCroise.Contains(t);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00008EB0 File Offset: 0x00007EB0
		public bool OkCableCoaxial(PointConnexion.TypesPointConnexion t)
		{
			return this.okCableCoaxial.Contains(t);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00008ED0 File Offset: 0x00007ED0
		public bool OkCableTelecom(PointConnexion.TypesPointConnexion t)
		{
			return this.okCableTelecom.Contains(t);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00008EF0 File Offset: 0x00007EF0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00008F1C File Offset: 0x00007F1C
		private void InitializeComponent()
		{
			this.mi_supprimerCable = new MenuItem();
			this.mi_configurerCable = new MenuItem();
			this.cm_conception.MenuItems.AddRange(new MenuItem[]
			{
				this.mi_configurerCable,
				this.mi_supprimerCable
			});
			this.mi_supprimerCable.Index = 2;
			this.mi_supprimerCable.Text = "Supprimer le câble";
			this.mi_supprimerCable.Click += this.mi_supprimerCable_Click;
			this.mi_configurerCable.Index = 1;
			this.mi_configurerCable.Text = "Configurer le câble";
			this.mi_configurerCable.Click += this.mi_configurerCable_Click;
			base.Name = "PointConnexion";
			base.Size = new Size(11, 30);
			base.MouseLeave += this.PointConnexion_MouseLeave;
			base.Paint += this.PointConnexion_Paint;
			base.MouseEnter += this.PointConnexion_MouseEnter;
			base.KeyDown += this.PointConnexion_KeyDown;
			base.MouseMove += this.PointConnexion_MouseMove;
			base.MouseDown += this.PointConnexion_MouseDown;
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00009058 File Offset: 0x00008058
		// (set) Token: 0x06000101 RID: 257 RVA: 0x0000906C File Offset: 0x0000806C
		public Noeud NoeudAttache
		{
			get
			{
				return this.noeudAttache;
			}
			set
			{
				this.noeudAttache = value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000103 RID: 259 RVA: 0x00009094 File Offset: 0x00008094
		// (set) Token: 0x06000102 RID: 258 RVA: 0x00009080 File Offset: 0x00008080
		public int NumeroOrdre
		{
			get
			{
				return this.numeroOrdre;
			}
			set
			{
				this.numeroOrdre = value;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000104 RID: 260 RVA: 0x000090A8 File Offset: 0x000080A8
		// (set) Token: 0x06000105 RID: 261 RVA: 0x000090BC File Offset: 0x000080BC
		public Cable Lien
		{
			get
			{
				return this.lien;
			}
			set
			{
				this.lien = value;
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x000090D0 File Offset: 0x000080D0
		private void PointConnexion_KeyDown(object sender, KeyEventArgs e)
		{
			this.noeudAttache.Noeud_KeyDown(sender, e);
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000107 RID: 263 RVA: 0x000090EC File Offset: 0x000080EC
		public Point Centre
		{
			get
			{
				Point result;
				try
				{
					result = new Point(base.Parent.Location.X + base.Location.X + 5, base.Parent.Location.Y + base.Location.Y + 5);
				}
				catch
				{
					result = new Point(0, 0);
				}
				return result;
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00009174 File Offset: 0x00008174
		private void PointConnexion_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.DrawRectangle(this.stylo, 0, 0, base.Width - 1, base.Height - 1);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x000091A8 File Offset: 0x000081A8
		protected void dessinerFond(Graphics g)
		{
			if (this.lien != null)
			{
				g.FillRectangle(new SolidBrush(this.BackColor), this.noeudAttache.Location.X + base.Location.X, this.noeudAttache.Location.Y + base.Location.Y, base.Width - 1, base.Height - 1);
				return;
			}
			if (this.reseau.ModeActif == Simulation.Mode.conceptionReseau)
			{
				g.FillRectangle(Brushes.White, this.noeudAttache.Location.X + base.Location.X, this.noeudAttache.Location.Y + base.Location.Y, base.Width - 1, base.Height - 1);
				return;
			}
			g.FillRectangle(new SolidBrush(this.BackColor), this.noeudAttache.Location.X + base.Location.X, this.noeudAttache.Location.Y + base.Location.Y, base.Width - 1, base.Height - 1);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000092F8 File Offset: 0x000082F8
		public virtual void Dessiner(Graphics g)
		{
			this.dessinerFond(g);
			g.DrawRectangle(this.stylo, this.noeudAttache.Location.X + base.Location.X, this.noeudAttache.Location.Y + base.Location.Y, base.Width - 1, base.Height - 1);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0000936C File Offset: 0x0000836C
		public void Deconnecter()
		{
			this.lien = null;
			this.BackColor = this.reseau.Schema.BackColor;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00009398 File Offset: 0x00008398
		private void PointConnexion_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.reseau.EtatConceptionActif == Simulation.EtatConception.creationCableEnCours)
			{
				Graphics graphics = this.reseau.Schema.CreateGraphics();
				Rectangle rectInvalide = this.reseau.TraceNouveauCable.RectangleTrace();
				this.reseau.TraceNouveauCable.Effacer(graphics);
				this.reseau.TraceNouveauCable.B = new Point(base.Parent.Location.X + base.Location.X + e.X, base.Parent.Location.Y + base.Location.Y + e.Y);
				this.reseau.TracerCablesManuel(graphics, rectInvalide);
				graphics.Dispose();
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00009464 File Offset: 0x00008464
		private void mi_supprimerCable_Click(object sender, EventArgs e)
		{
			this.reseau.SupprimerCable(this.lien);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00009484 File Offset: 0x00008484
		private void PointConnexion_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				switch (this.reseau.ModeActif)
				{
				case Simulation.Mode.conceptionReseau:
					switch (this.reseau.EtatConceptionActif)
					{
					case Simulation.EtatConception.creationCable:
						if (this.lien == null)
						{
							this.surbrillance = false;
							this.reseau.CreerCable(this);
							this.reseau.EtatConceptionActif = Simulation.EtatConception.creationCableEnCours;
							return;
						}
						this.reseau.DeplacerCable(this);
						this.reseau.EtatConceptionActif = Simulation.EtatConception.creationCableEnCours;
						return;
					case Simulation.EtatConception.creationCableEnCours:
						if (this.lien == null && this.reseau.NouveauCable.Origine.noeudAttache != this.noeudAttache)
						{
							if (this.reseau.NouveauCable.OkTypeCable(this, this.reseau.NouveauCable.Origine))
							{
								this.surbrillance = false;
								this.reseau.TerminerCable(this);
							}
							else
							{
								this.reseau.AbandonCableEnCours();
							}
						}
						else
						{
							this.reseau.AbandonCableEnCours();
						}
						this.reseau.EtatConceptionActif = Simulation.EtatConception.creationCable;
						return;
					default:
						if (this.noeudAttache.Selectionne)
						{
							this.noeudAttache.deSelectionner();
						}
						this.reseau.Rb_cableChecked = true;
						this.reseau.rb_cable_Click(null, null);
						this.PointConnexion_MouseDown(sender, e);
						return;
					}
					break;
				case Simulation.Mode.ethernet:
					break;
				default:
					return;
				}
			}
			else
			{
				if (this.reseau.EtatConceptionActif == Simulation.EtatConception.creationCableEnCours)
				{
					this.reseau.AbandonCableEnCours();
					this.reseau.EtatConceptionActif = Simulation.EtatConception.creationCable;
				}
				ContextMenu contextMenu = base.GetContextMenu();
				if (contextMenu != null)
				{
					contextMenu.Show(this, new Point(e.X, e.Y));
				}
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00009624 File Offset: 0x00008624
		public PointConnexion.EtatsConnexion EtatConnexion
		{
			get
			{
				return this.etatConnexion;
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00009638 File Offset: 0x00008638
		public override void Allumer()
		{
			if (this.etatConnexion == PointConnexion.EtatsConnexion.éteint)
			{
				this.changerEtat(PointConnexion.EtatsConnexion.allumé);
				if (this.lien != null)
				{
					PointConnexion.EtatsConnexion etatsConnexion = this.lien.Oppose(this).etatConnexion;
					if (etatsConnexion != PointConnexion.EtatsConnexion.allumé)
					{
						return;
					}
					if (this.lien.Activable())
					{
						this.changerEtat(PointConnexion.EtatsConnexion.actif);
						this.lien.Oppose(this).changerEtat(PointConnexion.EtatsConnexion.actif);
						return;
					}
					this.changerEtat(PointConnexion.EtatsConnexion.erreur);
					this.lien.Oppose(this).changerEtat(PointConnexion.EtatsConnexion.erreur);
				}
			}
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000096B4 File Offset: 0x000086B4
		public bool EstConnecte(PointConnexion cible, ref ArrayList portsVisites, bool okSwitch)
		{
			if (this.lien.Oppose(this) == cible)
			{
				return true;
			}
			portsVisites.Add(this);
			return this.lien.Oppose(this).noeudAttache.EstConnecte(this.lien.Oppose(this), cible, ref portsVisites, okSwitch);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00009700 File Offset: 0x00008700
		public bool EstRelie(PointConnexion cible, ref ArrayList visites)
		{
			if (this.lien.Oppose(this) == cible)
			{
				return true;
			}
			visites.Add(this);
			return this.lien.Oppose(this).noeudAttache.EstRelie(this.lien.Oppose(this), cible, ref visites);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000974C File Offset: 0x0000874C
		public void changerEtat(PointConnexion.EtatsConnexion nouvelEtat)
		{
			this.etatConnexion = nouvelEtat;
			switch (nouvelEtat)
			{
			case PointConnexion.EtatsConnexion.éteint:
				if (this.lien == null)
				{
					this.BackColor = this.reseau.Schema.BackColor;
					return;
				}
				this.BackColor = this.reseau.Pref.CouleurConnexionConception;
				return;
			case PointConnexion.EtatsConnexion.allumé:
				this.BackColor = this.reseau.Pref.CouleurAllumeEthernet;
				return;
			case PointConnexion.EtatsConnexion.actif:
				this.BackColor = this.reseau.Pref.CouleurActifEthernet;
				return;
			case PointConnexion.EtatsConnexion.erreur:
				this.BackColor = this.reseau.Pref.CouleurErreurEthernet;
				return;
			case PointConnexion.EtatsConnexion.bloqué:
				this.BackColor = this.reseau.Pref.CouleurBloqueEthernet;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00009810 File Offset: 0x00008810
		public override void Eteindre()
		{
			if (this.etatConnexion != PointConnexion.EtatsConnexion.éteint)
			{
				this.changerEtat(PointConnexion.EtatsConnexion.éteint);
				if (this.lien != null)
				{
					switch (this.lien.Oppose(this).etatConnexion)
					{
					case PointConnexion.EtatsConnexion.actif:
						this.lien.Oppose(this).changerEtat(PointConnexion.EtatsConnexion.allumé);
						return;
					case PointConnexion.EtatsConnexion.erreur:
						this.lien.Oppose(this).changerEtat(PointConnexion.EtatsConnexion.allumé);
						break;
					default:
						return;
					}
				}
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0000987C File Offset: 0x0000887C
		public Rectangle RectangleAttache()
		{
			return new Rectangle(this.noeudAttache.Location.X + base.Location.X + 3, this.noeudAttache.Location.Y + base.Location.Y + 2, 7, 7);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x000098D8 File Offset: 0x000088D8
		private void mi_configurerCable_Click(object sender, EventArgs e)
		{
			ConfigCable configCable = new ConfigCable();
			configCable.Type = this.lien.Type;
			configCable.Longueur = this.lien.Longueur;
			configCable.longueurMax = this.reseau.Pref.LongueurCableMax;
			if (configCable.ShowDialog() == DialogResult.OK)
			{
				this.lien.Type = configCable.Type;
				this.lien.Longueur = configCable.Longueur;
				this.reseau.GereDoc.FaireAction(ActionDocument.modifier);
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00009968 File Offset: 0x00008968
		public virtual void SuiteEmissionTrame(int taille)
		{
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00009978 File Offset: 0x00008978
		public virtual void AbandonEmissionTrame()
		{
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00009988 File Offset: 0x00008988
		public virtual string LibelleEmissionTrame()
		{
			return "";
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000999C File Offset: 0x0000899C
		public override string ToString()
		{
			return this.numeroOrdre.ToString();
		}

		// Token: 0x0600011B RID: 283 RVA: 0x000099B4 File Offset: 0x000089B4
		private void PointConnexion_MouseEnter(object sender, EventArgs e)
		{
			if (this.reseau.EtatConceptionActif == Simulation.EtatConception.creationCableEnCours)
			{
				if (this.lien == null && this.reseau.NouveauCable.Origine.noeudAttache != this.noeudAttache)
				{
					this.surbrillance = true;
					this.BackColor = this.reseau.Pref.SurbrillancePointConnexion;
					return;
				}
			}
			else if (this.reseau.ModeActif == Simulation.Mode.conceptionReseau && this.lien == null)
			{
				this.surbrillance = true;
				this.BackColor = this.reseau.Pref.SurbrillancePointConnexion;
			}
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00009A44 File Offset: 0x00008A44
		private void PointConnexion_MouseLeave(object sender, EventArgs e)
		{
			if (this.surbrillance)
			{
				this.surbrillance = false;
				this.BackColor = this.reseau.Schema.BackColor;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00009A78 File Offset: 0x00008A78
		public ConnecteurPaire Emetteur
		{
			get
			{
				return this.emetteur;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600011E RID: 286 RVA: 0x00009A8C File Offset: 0x00008A8C
		public ConnecteurPaire Recepteur
		{
			get
			{
				return this.recepteur;
			}
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00009AA0 File Offset: 0x00008AA0
		public void CreerConnecteurs()
		{
			Point p_pos = new Point(0, 0);
			Point p_pos2 = new Point(0, 0);
			this.calculerPosConnecteurs(ref p_pos, ref p_pos2);
			this.emetteur = new ConnecteurPaire(this, this.lien.Oppose(this).recepteur, p_pos);
			this.recepteur = new ConnecteurPaire(this, this.lien.Oppose(this).emetteur, p_pos2);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00009B08 File Offset: 0x00008B08
		public virtual void LibererEmission()
		{
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00009B18 File Offset: 0x00008B18
		public virtual void LibererReception()
		{
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00009B28 File Offset: 0x00008B28
		private void calculerPosConnecteurs(ref Point p_posEmetteur, ref Point p_posRecepteur)
		{
			float num = (float)this.Centre.X;
			float num2 = (float)this.Centre.Y;
			float num3 = (float)this.lien.Oppose(this).Centre.X;
			float num4 = (float)this.lien.Oppose(this).Centre.Y;
			float num5 = (float)this.reseau.Pref.DistanceConnecteursPaire;
			if (num2 == num4)
			{
				if (num < num3)
				{
					p_posEmetteur = new Point((int)num, (int)(num2 - num5));
					p_posRecepteur = new Point((int)num, (int)(num2 + num5));
					return;
				}
				p_posEmetteur = new Point((int)num, (int)(num2 + num5));
				p_posRecepteur = new Point((int)num, (int)(num2 - num5));
				return;
			}
			else
			{
				if (num != num3)
				{
					float num6 = -1f / ((num4 - num2) / (num3 - num));
					float num7 = num2 - num6 * num;
					int num8;
					if (num2 < num4)
					{
						num8 = 1;
					}
					else
					{
						num8 = -1;
					}
					float num9 = num + num5 * (float)num8 / (float)Math.Sqrt((double)(1f + num6 * num6));
					float num10 = num6 * num9 + num7;
					float num11 = num + -num5 * (float)num8 / (float)Math.Sqrt((double)(1f + num6 * num6));
					float num12 = num6 * num11 + num7;
					p_posEmetteur = new Point((int)num9, (int)num10);
					p_posRecepteur = new Point((int)num11, (int)num12);
					return;
				}
				if (num2 > num4)
				{
					p_posEmetteur = new Point((int)(num - num5), (int)num2);
					p_posRecepteur = new Point((int)(num + num5), (int)num2);
					return;
				}
				p_posEmetteur = new Point((int)(num + num5), (int)num2);
				p_posRecepteur = new Point((int)(num - num5), (int)num2);
				return;
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000123 RID: 291 RVA: 0x00009CA8 File Offset: 0x00008CA8
		// (remove) Token: 0x06000124 RID: 292 RVA: 0x00009CCC File Offset: 0x00008CCC
		public virtual event EtatTransitionEventHandler EvtEtatTransition;

		// Token: 0x06000125 RID: 293 RVA: 0x00009CF0 File Offset: 0x00008CF0
		public virtual void DebutTrameSurCable()
		{
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00009D00 File Offset: 0x00008D00
		public virtual void FinTrameSurCable(bool p_collisee)
		{
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00009D10 File Offset: 0x00008D10
		public bool EnReception
		{
			get
			{
				return this.enReception;
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00009D24 File Offset: 0x00008D24
		public void AllumerReception(int numTrame)
		{
			this.enReception = true;
			if (numTrame == 1)
			{
				this.BackColor = this.reseau.Pref.CableActifStylo1.Color;
				return;
			}
			this.BackColor = this.reseau.Pref.CableActifStylo2.Color;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00009D74 File Offset: 0x00008D74
		public void EteindreReception()
		{
			this.enReception = false;
			this.BackColor = this.reseau.Pref.CouleurActifEthernet;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00009DA0 File Offset: 0x00008DA0
		public override void ReinitEthernet()
		{
			this.trameEnCours = null;
			this.senderEnCours = null;
			this.demo = null;
			if (this.etatConnexion == PointConnexion.EtatsConnexion.actif)
			{
				this.EteindreReception();
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00009DD4 File Offset: 0x00008DD4
		public override Point GetCentre()
		{
			return new Point(base.Parent.Location.X + base.Location.X + base.Size.Width / 2, base.Parent.Location.Y + base.Location.Y + base.Size.Height / 2);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00009E4C File Offset: 0x00008E4C
		public virtual bool EstSurStation()
		{
			return false;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00009E5C File Offset: 0x00008E5C
		public bool CalculerCheminIp(PointConnexion dest, ref ArrayList chemin, ref ArrayList visites)
		{
			if (visites.Contains(this))
			{
				return false;
			}
			if (this.etatConnexion != PointConnexion.EtatsConnexion.actif)
			{
				return false;
			}
			visites.Add(this);
			if (this == dest)
			{
				return true;
			}
			bool result = false;
			if (!this.EstSurStation())
			{
				foreach (object obj in this.NoeudAttache.Controls)
				{
					PointConnexion pointConnexion = (PointConnexion)obj;
					if (pointConnexion != this && pointConnexion.etatConnexion == PointConnexion.EtatsConnexion.actif && pointConnexion.lien.Oppose(pointConnexion).CalculerCheminIp(dest, ref chemin, ref visites))
					{
						chemin.Add(pointConnexion.lien.Oppose(pointConnexion));
						chemin.Add(pointConnexion);
						result = true;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x0400007E RID: 126
		private Container components = null;

		// Token: 0x0400007F RID: 127
		private Point posDemoEmission = new Point(0, 0);

		// Token: 0x04000080 RID: 128
		protected PointConnexion.TypesPointConnexion typePointConnexion;

		// Token: 0x04000081 RID: 129
		protected ArrayList okCableDroit = new ArrayList();

		// Token: 0x04000082 RID: 130
		protected ArrayList okCableCroise = new ArrayList();

		// Token: 0x04000083 RID: 131
		protected ArrayList okCableCoaxial = new ArrayList();

		// Token: 0x04000084 RID: 132
		protected ArrayList okCableTelecom = new ArrayList();

		// Token: 0x04000085 RID: 133
		private Noeud noeudAttache = null;

		// Token: 0x04000086 RID: 134
		protected MenuItem mi_supprimerCable;

		// Token: 0x04000087 RID: 135
		protected MenuItem mi_configurerCable;

		// Token: 0x04000088 RID: 136
		protected int numeroOrdre;

		// Token: 0x04000089 RID: 137
		protected Cable lien = null;

		// Token: 0x0400008A RID: 138
		protected PointConnexion.EtatsConnexion etatConnexion = PointConnexion.EtatsConnexion.éteint;

		// Token: 0x0400008B RID: 139
		private bool surbrillance = false;

		// Token: 0x0400008C RID: 140
		public EventHandler CollisionDeuxPaires;

		// Token: 0x0400008D RID: 141
		private ConnecteurPaire emetteur;

		// Token: 0x0400008E RID: 142
		private ConnecteurPaire recepteur;

		// Token: 0x04000090 RID: 144
		private bool enReception = false;

		// Token: 0x0200000F RID: 15
		public enum TypesPointConnexion
		{
			// Token: 0x04000092 RID: 146
			carteReseau,
			// Token: 0x04000093 RID: 147
			carteAccesDistant,
			// Token: 0x04000094 RID: 148
			portHub,
			// Token: 0x04000095 RID: 149
			portCascadeHub,
			// Token: 0x04000096 RID: 150
			portSwitch,
			// Token: 0x04000097 RID: 151
			portCascadeSwitch,
			// Token: 0x04000098 RID: 152
			port8021qSwitch,
			// Token: 0x04000099 RID: 153
			portFai
		}

		// Token: 0x02000010 RID: 16
		public enum EtatsConnexion
		{
			// Token: 0x0400009B RID: 155
			éteint,
			// Token: 0x0400009C RID: 156
			allumé,
			// Token: 0x0400009D RID: 157
			actif,
			// Token: 0x0400009E RID: 158
			erreur,
			// Token: 0x0400009F RID: 159
			bloqué
		}
	}
}
