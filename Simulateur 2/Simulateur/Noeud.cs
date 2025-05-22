using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Simulateur
{
	// Token: 0x0200004E RID: 78
	public class Noeud : ElementReseau
	{
		// Token: 0x060003DE RID: 990 RVA: 0x0002BEC4 File Offset: 0x0002AEC4
		public Noeud()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0002BF14 File Offset: 0x0002AF14
		public Noeud(Simulation s) : base(s)
		{
			this.InitializeComponent();
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x0002BF64 File Offset: 0x0002AF64
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0002BF90 File Offset: 0x0002AF90
		private void InitializeComponent()
		{
			this.mi_allumer = new MenuItem();
			this.mi_eteindre = new MenuItem();
			this.cm_ethernetEteint = new ContextMenu();
			this.mi_allumerEteint = new MenuItem();
			this.mi_inutile = new MenuItem();
			this.mi_allumerIp = new MenuItem();
			this.mi_EteindreIp = new MenuItem();
			this.mi_allumerAppl = new MenuItem();
			this.mi_eteindreAppl = new MenuItem();
			this.cm_ip.MenuItems.AddRange(new MenuItem[]
			{
				this.mi_allumerIp,
				this.mi_EteindreIp
			});
			this.cm_appl.MenuItems.AddRange(new MenuItem[]
			{
				this.mi_allumerAppl,
				this.mi_eteindreAppl
			});
			this.cm_ethernet.MenuItems.AddRange(new MenuItem[]
			{
				this.mi_allumer,
				this.mi_eteindre
			});
			this.mi_allumer.Index = 0;
			this.mi_allumer.Text = "Allumer";
			this.mi_allumer.Click += this.mi_allumer_Click;
			this.mi_eteindre.Index = 1;
			this.mi_eteindre.Text = "Eteindre";
			this.mi_eteindre.Click += this.mi_eteindre_Click;
			this.cm_ethernetEteint.MenuItems.AddRange(new MenuItem[]
			{
				this.mi_allumerEteint,
				this.mi_inutile
			});
			this.mi_allumerEteint.Index = 0;
			this.mi_allumerEteint.Text = "Allumer";
			this.mi_allumerEteint.Click += this.mi_allumer_Click;
			this.mi_inutile.Enabled = false;
			this.mi_inutile.Index = 1;
			this.mi_inutile.Text = "Eteindre";
			this.mi_allumerIp.Index = 0;
			this.mi_allumerIp.Text = "Allumer";
			this.mi_allumerIp.Click += this.mi_allumer_Click;
			this.mi_EteindreIp.Index = 1;
			this.mi_EteindreIp.Text = "Eteindre";
			this.mi_EteindreIp.Click += this.mi_eteindre_Click;
			this.mi_allumerAppl.Index = 0;
			this.mi_allumerAppl.Text = "Allumer";
			this.mi_allumerAppl.Click += this.mi_allumer_Click;
			this.mi_eteindreAppl.Index = 1;
			this.mi_eteindreAppl.Text = "Eteindre";
			this.mi_eteindreAppl.Click += this.mi_eteindre_Click;
			base.Name = "Noeud";
			base.Size = new Size(24, 214);
			base.KeyDown += this.Noeud_KeyDown;
			base.MouseMove += this.Noeud_MouseMove;
			base.MouseDown += this.Noeud_MouseDown;
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x0002C290 File Offset: 0x0002B290
		// (set) Token: 0x060003E3 RID: 995 RVA: 0x0002C2A4 File Offset: 0x0002B2A4
		public int NbPointsConnexion
		{
			get
			{
				return this.nbPointsConnexion;
			}
			set
			{
				this.nbPointsConnexion = value;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x0002C2B8 File Offset: 0x0002B2B8
		// (set) Token: 0x060003E5 RID: 997 RVA: 0x0002C2CC File Offset: 0x0002B2CC
		public string NomNoeud
		{
			get
			{
				return this.nomNoeud;
			}
			set
			{
				this.nomNoeud = value;
			}
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x0002C2E0 File Offset: 0x0002B2E0
		private int getPosDebutDeplX()
		{
			return this.posDebutDepl.X;
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x0002C2F8 File Offset: 0x0002B2F8
		private int getPosDebutDeplY()
		{
			return this.posDebutDepl.Y;
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0002C310 File Offset: 0x0002B310
		private void gererSelectionNoeud()
		{
			if ((Control.ModifierKeys & Keys.Control) != Keys.Control && (Control.ModifierKeys & Keys.Shift) != Keys.Shift)
			{
				if (!this.selectionne)
				{
					this.reseau.ToutDeSelectionner();
					this.selectionner();
				}
				return;
			}
			if (this.selectionne)
			{
				this.deSelectionner();
				return;
			}
			this.selectionner();
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0002C370 File Offset: 0x0002B370
		private void Noeud_MouseDown(object sender, MouseEventArgs e)
		{
			if (this.reseau.EtatConceptionActif == Simulation.EtatConception.creationCableEnCours)
			{
				this.reseau.AbandonCableEnCours();
				this.reseau.EtatConceptionActif = Simulation.EtatConception.creationCable;
			}
			if (e.Button != MouseButtons.Left)
			{
				ContextMenu contextMenu = base.GetContextMenu();
				if (contextMenu != null)
				{
					contextMenu.Show(this, new Point(e.X, e.Y));
				}
				return;
			}
			switch (this.reseau.ModeActif)
			{
			case Simulation.Mode.conceptionReseau:
				if (this.reseau.EtatConceptionActif == Simulation.EtatConception.consultationSchema)
				{
					this.gererSelectionNoeud();
				}
				this.sourisDebutDepl = new Point(Control.MousePosition.X, Control.MousePosition.Y);
				if (this.reseau.NoeudsSelectionnes.Count > 1)
				{
					using (IEnumerator enumerator = this.reseau.NoeudsSelectionnes.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							Noeud noeud = (Noeud)obj;
							noeud.posDebutDepl = new Point(noeud.Location.X, noeud.Location.Y);
						}
						goto IL_133;
					}
				}
				this.posDebutDepl = new Point(base.Location.X, base.Location.Y);
				IL_133:
				base.MouseMove += this.deplacerNoeud;
				base.MouseUp += this.placerNoeud;
				return;
			case Simulation.Mode.ethernet:
			{
				Simulation.EtatEthernet etatEthernetActif = this.reseau.EtatEthernetActif;
				if (etatEthernetActif != Simulation.EtatEthernet.attente)
				{
					return;
				}
				this.sourisDebutDepl = new Point(Control.MousePosition.X, Control.MousePosition.Y);
				this.posDebutDepl = new Point(base.Location.X, base.Location.Y);
				base.MouseMove += this.deplacerNoeud;
				base.MouseUp += this.placerNoeud;
				return;
			}
			case Simulation.Mode.ip:
			{
				Simulation.EtatIp etatIpActif = this.reseau.EtatIpActif;
				if (etatIpActif != Simulation.EtatIp.attente)
				{
					return;
				}
				this.sourisDebutDepl = new Point(Control.MousePosition.X, Control.MousePosition.Y);
				this.posDebutDepl = new Point(base.Location.X, base.Location.Y);
				base.MouseMove += this.deplacerNoeud;
				base.MouseUp += this.placerNoeud;
				return;
			}
			case Simulation.Mode.appl:
			{
				Simulation.EtatAppl etatApplActif = this.reseau.EtatApplActif;
				if (etatApplActif != Simulation.EtatAppl.attente)
				{
					return;
				}
				this.sourisDebutDepl = new Point(Control.MousePosition.X, Control.MousePosition.Y);
				this.posDebutDepl = new Point(base.Location.X, base.Location.Y);
				base.MouseMove += this.deplacerNoeud;
				base.MouseUp += this.placerNoeud;
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x0002C6A0 File Offset: 0x0002B6A0
		private void effacerCables(Graphics g)
		{
			foreach (object obj in base.Controls)
			{
				PointConnexion pointConnexion = (PointConnexion)obj;
				if (pointConnexion.Lien != null)
				{
					pointConnexion.Lien.Effacer(g);
				}
			}
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0002C714 File Offset: 0x0002B714
		public virtual void Dessiner(Graphics g)
		{
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x0002C724 File Offset: 0x0002B724
		public void tracerCables(Graphics g)
		{
			foreach (object obj in base.Controls)
			{
				PointConnexion pointConnexion = (PointConnexion)obj;
				if (pointConnexion.Lien != null)
				{
					pointConnexion.Lien.Tracer(g);
				}
			}
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x0002C798 File Offset: 0x0002B798
		private int nbPointsConnectionsConnectes()
		{
			int num = 0;
			foreach (object obj in base.Controls)
			{
				PointConnexion pointConnexion = (PointConnexion)obj;
				if (pointConnexion.Lien != null)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0002C808 File Offset: 0x0002B808
		private void deplacerNoeud(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this.reseau.NoeudsSelectionnes.Count > 1)
				{
					using (IEnumerator enumerator = this.reseau.NoeudsSelectionnes.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							Noeud noeud = (Noeud)obj;
							Rectangle rc = noeud.rectangleTrace();
							int x = noeud.getPosDebutDeplX() + (Control.MousePosition.X - this.sourisDebutDepl.X);
							int y = noeud.getPosDebutDeplY() + (Control.MousePosition.Y - this.sourisDebutDepl.Y);
							Point pos = new Point(x, y);
							noeud.Location = this.reseau.positionOk(noeud.Size, pos);
							this.reseau.Schema.Invalidate(rc, false);
						}
						return;
					}
				}
				Rectangle rc2 = this.rectangleTrace();
				int x2 = this.posDebutDepl.X + (Control.MousePosition.X - this.sourisDebutDepl.X);
				int y2 = this.posDebutDepl.Y + (Control.MousePosition.Y - this.sourisDebutDepl.Y);
				Point pos2 = new Point(x2, y2);
				base.Location = this.reseau.positionOk(base.Size, pos2);
				this.reseau.Schema.Invalidate(rc2, false);
			}
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x0002C9B0 File Offset: 0x0002B9B0
		private void placerNoeud(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				base.MouseMove -= this.deplacerNoeud;
				base.MouseUp -= this.placerNoeud;
			}
			this.reseau.GereDoc.FaireAction(ActionDocument.modifier);
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0002CA00 File Offset: 0x0002BA00
		public void AjouterPointConnexion(PointConnexion p)
		{
			p.NoeudAttache = this;
			base.Controls.Add(p);
			p.Location = new Point(2 + 12 * this.nbPointsConnexion, base.Height - 13);
			this.nbPointsConnexion++;
			p.NumeroOrdre = this.nbPointsConnexion;
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x0002CA5C File Offset: 0x0002BA5C
		public void AjouterPointConnexion(PointConnexion p, Point pos)
		{
			p.NoeudAttache = this;
			base.Controls.Add(p);
			p.Location = pos;
			this.nbPointsConnexion++;
			p.NumeroOrdre = this.nbPointsConnexion;
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x0002CAA0 File Offset: 0x0002BAA0
		protected int dernierPointConnexionConnecte()
		{
			int num = this.nbPointsConnexion;
			while (num > 0 && ((PointConnexion)base.Controls[num - 1]).Lien == null)
			{
				num--;
			}
			return num;
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x0002CADC File Offset: 0x0002BADC
		public bool Selectionne
		{
			get
			{
				return this.selectionne;
			}
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0002CAF0 File Offset: 0x0002BAF0
		public void selectionner()
		{
			this.stylo = this.reseau.Pref.SelectionStylo;
			base.Invalidate(base.ClientRectangle, false);
			this.selectionne = true;
			this.reseau.NoeudsSelectionnes.Add(this);
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0002CB3C File Offset: 0x0002BB3C
		public void deSelectionner()
		{
			this.stylo = this.reseau.Pref.NormalStylo;
			base.Invalidate(base.ClientRectangle, false);
			this.selectionne = false;
			this.reseau.NoeudsSelectionnes.Remove(this);
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0002CB84 File Offset: 0x0002BB84
		public void supprimerNoeud()
		{
			Rectangle rc = this.rectangleTrace();
			foreach (object obj in base.Controls)
			{
				PointConnexion pointConnexion = (PointConnexion)obj;
				if (pointConnexion.Lien != null)
				{
					this.reseau.Schema.Controls.Remove(pointConnexion.Lien);
					this.reseau.DeconfigurerClientInternet(pointConnexion.Lien);
					pointConnexion.Lien.Deconnecter();
				}
			}
			this.reseau.Schema.Controls.Remove(this);
			this.reseau.Noeuds.Remove(this.nomNoeud);
			this.reseau.NoeudsNonDemo.Remove(this.nomNoeud);
			this.reseau.Schema.Invalidate(rc, false);
			if (this == this.reseau.ReseauInternet)
			{
				this.reseau.SupprimerInternet();
			}
			this.reseau.GereDoc.FaireAction(ActionDocument.modifier);
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0002CCA8 File Offset: 0x0002BCA8
		public virtual void Noeud_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.reseau.EtatConceptionActif == Simulation.EtatConception.consultationSchema && this.selectionne && e.KeyCode == Keys.Delete)
			{
				this.reseau.SupprimerNoeudsSelectionnes();
			}
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0002CCE0 File Offset: 0x0002BCE0
		protected Rectangle rectangleTrace()
		{
			Rectangle rectangle = new Rectangle(base.Location, base.Size);
			foreach (object obj in base.Controls)
			{
				PointConnexion pointConnexion = (PointConnexion)obj;
				if (pointConnexion.Lien != null)
				{
					rectangle = Rectangle.Union(rectangle, pointConnexion.Lien.RectangleTrace());
				}
			}
			return rectangle;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0002CD6C File Offset: 0x0002BD6C
		private void Noeud_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.reseau.EtatConceptionActif == Simulation.EtatConception.creationCableEnCours)
			{
				Graphics graphics = this.reseau.Schema.CreateGraphics();
				Rectangle rectInvalide = this.reseau.TraceNouveauCable.RectangleTrace();
				this.reseau.TraceNouveauCable.Effacer(graphics);
				this.reseau.TraceNouveauCable.B = new Point(base.Location.X + e.X, base.Location.Y + e.Y);
				this.reseau.TracerCablesManuel(graphics, rectInvalide);
				graphics.Dispose();
			}
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0002CE10 File Offset: 0x0002BE10
		public override void Allumer()
		{
			foreach (object obj in base.Controls)
			{
				PointConnexion pointConnexion = (PointConnexion)obj;
				pointConnexion.Allumer();
			}
			this.mi_allumer.Enabled = false;
			this.mi_eteindre.Enabled = true;
			this.mi_allumerIp.Enabled = false;
			this.mi_allumerAppl.Enabled = false;
			this.mi_EteindreIp.Enabled = true;
			this.mi_eteindreAppl.Enabled = true;
			this.reseau.OkBis = false;
			this.reseau.PreparerBis();
			this.reseau.BloquerBisIp();
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0002CEE0 File Offset: 0x0002BEE0
		public override void ModifierCouleurConnexions()
		{
			switch (this.reseau.ModeActif)
			{
			case Simulation.Mode.conceptionReseau:
				using (IEnumerator enumerator = base.Controls.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						PointConnexion pointConnexion = (PointConnexion)obj;
						if (pointConnexion.Lien == null)
						{
							pointConnexion.BackColor = this.reseau.Schema.BackColor;
						}
						else
						{
							pointConnexion.BackColor = this.reseau.Pref.CouleurConnexionConception;
						}
					}
					return;
				}
				break;
			case Simulation.Mode.ethernet:
				break;
			default:
				return;
			}
			foreach (object obj2 in base.Controls)
			{
				PointConnexion pointConnexion2 = (PointConnexion)obj2;
				pointConnexion2.changerEtat(pointConnexion2.EtatConnexion);
			}
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0002CFF0 File Offset: 0x0002BFF0
		protected virtual void eteindreIp()
		{
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x0002D000 File Offset: 0x0002C000
		public override void Eteindre()
		{
			foreach (object obj in base.Controls)
			{
				PointConnexion pointConnexion = (PointConnexion)obj;
				pointConnexion.Eteindre();
			}
			this.eteindreIp();
			this.mi_allumer.Enabled = true;
			this.mi_eteindre.Enabled = false;
			this.mi_allumerIp.Enabled = true;
			this.mi_allumerAppl.Enabled = true;
			this.mi_EteindreIp.Enabled = false;
			this.mi_eteindreAppl.Enabled = false;
			this.reseau.OkBis = false;
			this.reseau.PreparerBis();
			this.reseau.BloquerBisIp();
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x0002D0D4 File Offset: 0x0002C0D4
		protected virtual void mi_allumer_Click(object sender, EventArgs e)
		{
			this.Allumer();
			this.enFonction = true;
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x0002D0F0 File Offset: 0x0002C0F0
		protected virtual void mi_eteindre_Click(object sender, EventArgs e)
		{
			this.Eteindre();
			this.enFonction = false;
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x0002D10C File Offset: 0x0002C10C
		protected override ContextMenu menuConception()
		{
			return this.cm_conception;
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x0002D120 File Offset: 0x0002C120
		public override void InstallerGestionEvenements()
		{
			foreach (object obj in base.Controls)
			{
				PointConnexion pointConnexion = (PointConnexion)obj;
				pointConnexion.InstallerGestionEvenements();
			}
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x0002D184 File Offset: 0x0002C184
		public override void DesinstallerGestionEvenements()
		{
			foreach (object obj in base.Controls)
			{
				PointConnexion pointConnexion = (PointConnexion)obj;
				pointConnexion.DesinstallerGestionEvenements();
			}
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x0002D1E8 File Offset: 0x0002C1E8
		protected bool modifierNom(string nouveauNom)
		{
			this.reseau.Noeuds.Remove(this.nomNoeud);
			bool result;
			if (nouveauNom == "" || nouveauNom == "Internet" || this.reseau.Noeuds.Contains(nouveauNom))
			{
				result = false;
			}
			else
			{
				result = true;
				if (this.reseau.NoeudsNonDemo.Contains(this.nomNoeud))
				{
					this.reseau.NoeudsNonDemo.Remove(this.nomNoeud);
					this.nomNoeud = nouveauNom;
					this.reseau.NoeudsNonDemo.Add(this.nomNoeud, this);
				}
				else
				{
					this.nomNoeud = nouveauNom;
				}
			}
			this.reseau.Noeuds.Add(this.nomNoeud, this);
			return result;
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x0002D2AC File Offset: 0x0002C2AC
		public bool trace()
		{
			return !this.reseau.NoeudsNonDemo.ContainsKey(this.nomNoeud);
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x0002D2D4 File Offset: 0x0002C2D4
		protected override ContextMenu menuEthernet()
		{
			if (this.reseau.EtatEthernetActif == Simulation.EtatEthernet.attente)
			{
				return this.cm_ethernet;
			}
			return null;
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000406 RID: 1030 RVA: 0x0002D2F8 File Offset: 0x0002C2F8
		// (set) Token: 0x06000407 RID: 1031 RVA: 0x0002D30C File Offset: 0x0002C30C
		public bool EnFonction
		{
			get
			{
				return this.enFonction;
			}
			set
			{
				this.enFonction = value;
			}
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0002D320 File Offset: 0x0002C320
		public int nbPointsConnexionActifs()
		{
			int num = 0;
			foreach (object obj in base.Controls)
			{
				PointConnexion pointConnexion = (PointConnexion)obj;
				if (pointConnexion.EtatConnexion == PointConnexion.EtatsConnexion.actif)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000409 RID: 1033 RVA: 0x0002D390 File Offset: 0x0002C390
		// (set) Token: 0x0600040A RID: 1034 RVA: 0x0002D3A4 File Offset: 0x0002C3A4
		public Point PosDemo
		{
			get
			{
				return this.posDemo;
			}
			set
			{
				this.posDemo = value;
			}
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0002D3B8 File Offset: 0x0002C3B8
		public void FixerPosition(int X, int Y)
		{
			if (this.PosDemo != new Point(X, Y))
			{
				this.PosDemo = new Point(X, Y);
				base.Reseau.GereDoc.FaireAction(ActionDocument.modifier);
			}
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0002D3F8 File Offset: 0x0002C3F8
		public override Point posDialogueDemo()
		{
			if (this.posDemo == new Point(0, 0))
			{
				int x = this.reseau.Location.X + this.reseau.Schema.Location.X + base.Location.X + 5;
				int y = this.reseau.Location.Y + this.reseau.Schema.Location.Y + base.Location.Y + this.reseau.Pref.HauteurOutils + 3;
				return new Point(x, y);
			}
			return this.posDemo;
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x0002D4B8 File Offset: 0x0002C4B8
		public virtual bool EstConnecte(PointConnexion source, PointConnexion cible, ref ArrayList portsVisites, bool okSwitch)
		{
			return false;
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x0002D4C8 File Offset: 0x0002C4C8
		public virtual bool EstRelie(PointConnexion source, PointConnexion cible, ref ArrayList visites)
		{
			return false;
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x0002D4D8 File Offset: 0x0002C4D8
		public virtual void ModeDeuxPaires(PointConnexion source, ref ArrayList cablesVus)
		{
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0002D4E8 File Offset: 0x0002C4E8
		public virtual void ModeCableSimple(PointConnexion source, ref ArrayList cablesVus)
		{
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000411 RID: 1041 RVA: 0x0002D4F8 File Offset: 0x0002C4F8
		// (set) Token: 0x06000412 RID: 1042 RVA: 0x0002D50C File Offset: 0x0002C50C
		public int IdNoeud
		{
			get
			{
				return this.idNoeud;
			}
			set
			{
				this.idNoeud = value;
			}
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x0002D520 File Offset: 0x0002C520
		public override void StockerXml(XmlTextWriter writer)
		{
			writer.WriteElementString("idNoeud", this.idNoeud.ToString());
			writer.WriteElementString("nbPointsConnexion", this.nbPointsConnexion.ToString());
			writer.WriteElementString("Location.X", base.Location.X.ToString());
			writer.WriteElementString("Location.Y", base.Location.Y.ToString());
			writer.WriteElementString("PosDemo.X", this.posDemo.X.ToString());
			writer.WriteElementString("PosDemo.Y", this.posDemo.Y.ToString());
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x0002D5D8 File Offset: 0x0002C5D8
		public override void ReinitEthernet()
		{
			this.trameEnCours = null;
			this.senderEnCours = null;
			this.DesinstallerGestionEvenements();
			foreach (object obj in base.Controls)
			{
				PointConnexion pointConnexion = (PointConnexion)obj;
				pointConnexion.ReinitEthernet();
			}
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x0002D650 File Offset: 0x0002C650
		public virtual void TransmissionRapideEthernet(bool demo, PointConnexion demandeur, Ip_PaquetIp paquet, bool suivreLiensPortsEteints, ReactionStation rs, ReactionSwitch rsw)
		{
		}

		// Token: 0x04000308 RID: 776
		private Container components = null;

		// Token: 0x04000309 RID: 777
		protected MenuItem mi_allumer;

		// Token: 0x0400030A RID: 778
		protected MenuItem mi_eteindre;

		// Token: 0x0400030B RID: 779
		protected int nbPointsConnexion = 0;

		// Token: 0x0400030C RID: 780
		protected string nomNoeud = "";

		// Token: 0x0400030D RID: 781
		private Point sourisDebutDepl;

		// Token: 0x0400030E RID: 782
		private Point posDebutDepl;

		// Token: 0x0400030F RID: 783
		protected ContextMenu cm_ethernetEteint;

		// Token: 0x04000310 RID: 784
		protected MenuItem mi_allumerIp;

		// Token: 0x04000311 RID: 785
		protected MenuItem mi_EteindreIp;

		// Token: 0x04000312 RID: 786
		private MenuItem mi_inutile;

		// Token: 0x04000313 RID: 787
		private MenuItem mi_allumerAppl;

		// Token: 0x04000314 RID: 788
		private MenuItem mi_eteindreAppl;

		// Token: 0x04000315 RID: 789
		private MenuItem mi_allumerEteint;

		// Token: 0x04000316 RID: 790
		private bool selectionne = false;

		// Token: 0x04000317 RID: 791
		private bool enFonction = true;

		// Token: 0x04000318 RID: 792
		protected Point posDemo = new Point(0, 0);

		// Token: 0x04000319 RID: 793
		private int idNoeud;
	}
}
