using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Simulateur
{
	// Token: 0x02000072 RID: 114
	public class PortSwitch : Port
	{
		// Token: 0x060006FC RID: 1788 RVA: 0x00042FA0 File Offset: 0x00041FA0
		public PortSwitch()
		{
			this.InitializeComponent();
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x00042FD0 File Offset: 0x00041FD0
		public PortSwitch(Simulation s) : base(s)
		{
			this.InitializeComponent();
			base.Size = new Size(11, 11);
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x00043010 File Offset: 0x00042010
		protected override void initOkCables()
		{
			this.typePointConnexion = PointConnexion.TypesPointConnexion.portSwitch;
			base.initOkCablesMDI();
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x0004302C File Offset: 0x0004202C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x00043058 File Offset: 0x00042058
		private void InitializeComponent()
		{
			this.mi_bloquer = new MenuItem();
			this.cm_ethernet.MenuItems.AddRange(new MenuItem[]
			{
				this.mi_bloquer
			});
			this.mi_bloquer.Index = 0;
			this.mi_bloquer.Text = "Bloquer";
			this.mi_bloquer.Click += this.mi_bloquer_Click;
			base.Name = "PortSwitch";
			base.Size = new Size(11, 30);
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x000430E0 File Offset: 0x000420E0
		public int Vlan(SortedList portVlan)
		{
			if (base.GetType() == typeof(Port8021qSwitch))
			{
				return -1;
			}
			return int.Parse(((ArrayList)portVlan[PortVlanEdit.numPortFormat(this.numeroOrdre)])[1].ToString());
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00043128 File Offset: 0x00042128
		protected override void Port_TrameTransmise(ElementReseau sender, TrameEventArgs e)
		{
			if (e.Cible == this)
			{
				e.Trame.IncrementerNbTransmissions();
				base.transmettreTrame(e.Trame, base.NoeudAttache);
				base.receptionnerTrame(e.Trame);
				return;
			}
			if (e.Cible == this.lien)
			{
				e.Trame.IncrementerNbTransmissions();
				base.transmettreTrame(e.Trame, e.Cible);
				base.receptionnerTrame(e.Trame);
			}
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x000431A0 File Offset: 0x000421A0
		protected override void Port_DebutTrameTransmis(ElementReseau sender, TrameEventArgs e)
		{
			if (this.reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.trameReelle)
			{
				if (e.Cible == this)
				{
					if (this.demoEmission != null)
					{
						this.envoyerEvenementTransition(DDialogPlusEmissionTrame.TypEvtTransition.carteTrameRecue);
					}
					this.trameEnCours = e;
					base.transmettreDebutTrame(e.Trame, base.NoeudAttache);
					return;
				}
				if (e.Cible == this.lien)
				{
					this.SuiteEmissionTrame(e.Trame);
					return;
				}
			}
			else
			{
				if (e.Cible == this)
				{
					e.Trame.IncrementerNbTransmissions();
					base.transmettreDebutTrame(e.Trame, base.NoeudAttache);
					return;
				}
				if (e.Cible == this.lien)
				{
					e.Trame.IncrementerNbTransmissions();
					base.transmettreDebutTrame(e.Trame, e.Cible);
				}
			}
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x0004325C File Offset: 0x0004225C
		protected override void Port_FinTrameTransmis(ElementReseau sender, TrameEventArgs e)
		{
			if (e.Cible != this)
			{
				if (e.Cible == this.lien)
				{
					if (this.reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.trameReelle)
					{
						if (e.Trame.Collisee)
						{
							base.annulerTrame(e.Trame);
							if (this.demoEmission.EnEmission && e.Trame == this.trame)
							{
								this.lien.EnvoyerFinTrameCollisee(this);
								this.demoEmission.FinDemo();
								return;
							}
						}
					}
					else
					{
						base.transmettreFinTrame(e.Trame, e.Cible);
						base.receptionnerFinTrame(e.Trame, "ps " + this.numeroOrdre);
					}
				}
				return;
			}
			base.transmettreFinTrame(e.Trame, base.NoeudAttache);
			if (this.reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.trameReelle)
			{
				this.trameEnCours = null;
				return;
			}
			base.receptionnerFinTrame(e.Trame, "ps " + this.numeroOrdre);
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000705 RID: 1797 RVA: 0x0004335C File Offset: 0x0004235C
		public TrameEthernet Trame
		{
			get
			{
				return this.trame;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000706 RID: 1798 RVA: 0x00043370 File Offset: 0x00042370
		// (set) Token: 0x06000707 RID: 1799 RVA: 0x00043384 File Offset: 0x00042384
		public DDialogPlusEmissionTrame DemoEmission
		{
			get
			{
				return this.demoEmission;
			}
			set
			{
				this.demoEmission = value;
			}
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x00043398 File Offset: 0x00042398
		public override bool Occupe()
		{
			return this.trameEnCours != null;
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000709 RID: 1801 RVA: 0x000433B4 File Offset: 0x000423B4
		public TrameEthernet TrameDemoEmission
		{
			get
			{
				return this.trameDemoEmission;
			}
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x000433C8 File Offset: 0x000423C8
		public override Point posDialogueDemo()
		{
			int x = this.reseau.Location.X + this.reseau.Schema.Location.X + base.NoeudAttache.Location.X + base.Location.X + 5;
			int y = this.reseau.Location.Y + this.reseau.Schema.Location.Y + base.NoeudAttache.Location.Y + base.Location.Y + this.reseau.Pref.HauteurOutils + 3;
			return new Point(x, y);
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00043494 File Offset: 0x00042494
		public void SuiteEmissionTrame(TrameEthernet tr)
		{
			this.trame = tr;
			if (base.PosDemoEmission == new Point(0, 0))
			{
				base.PosDemoEmission = this.posDialogueDemo();
			}
			this.demoEmission = new DDialogPlusEmissionTrame(this, this.reseau, this.trame.TempsEmission(), true, true);
			this.trameDemoEmission = tr;
			this.demoEmission.Text = base.NoeudAttache.NomNoeud + " : port " + this.numeroOrdre;
			this.demoEmission.DemoTerminee += this.PortSwitch_DemoEmissionTerminee;
			bool flag = this.reseau.FullDuplex;
			if (flag && (this.lien.Type == Cable.TypeCable.coaxial || this.lien.Oppose(this).GetType() == typeof(PortHub) || this.lien.Oppose(this).GetType() == typeof(PortDeCascadeHub)))
			{
				flag = false;
			}
			this.demoEmission.DemarrerDemo(this.trame, this, base.PosDemoEmission, this.reseau.DemoEmission && base.NoeudAttache.trace(), true, flag);
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x000435C0 File Offset: 0x000425C0
		public void PortSwitch_DemoEmissionTerminee(object sender, EventArgs e)
		{
			if (this.demoEmission != null)
			{
				this.demoEmission.DemoTerminee -= this.PortSwitch_DemoEmissionTerminee;
			}
			this.ReemissionTerminee(this, new EventArgs());
			this.trame = null;
			this.trameDemoEmission = null;
			this.demoEmission = null;
			if (this.PortLibre != null)
			{
				this.PortLibre(this, new EventArgs());
			}
		}

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x0600070D RID: 1805 RVA: 0x0004362C File Offset: 0x0004262C
		// (remove) Token: 0x0600070E RID: 1806 RVA: 0x00043650 File Offset: 0x00042650
		public event EventHandler ReemissionTerminee;

		// Token: 0x0600070F RID: 1807 RVA: 0x00043674 File Offset: 0x00042674
		public CarteReseau ChercherCarte()
		{
			return this.trouverCarte(base.NoeudAttache, this, new ArrayList());
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x00043694 File Offset: 0x00042694
		private CarteReseau trouverCarte(Noeud n, PointConnexion p, ArrayList vus)
		{
			CarteReseau carteReseau = null;
			if (!vus.Contains(p))
			{
				vus.Add(p);
				if (n.GetType() == typeof(Station))
				{
					return (CarteReseau)p;
				}
				int index = 0;
				while (carteReseau == null)
				{
					PointConnexion pointConnexion = (PointConnexion)n.Controls[index];
					if (pointConnexion != p && pointConnexion.EtatConnexion == PointConnexion.EtatsConnexion.actif)
					{
						carteReseau = this.trouverCarte(pointConnexion.Lien.Oppose(pointConnexion).NoeudAttache, pointConnexion.Lien.Oppose(pointConnexion), vus);
					}
				}
			}
			return carteReseau;
		}

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x06000711 RID: 1809 RVA: 0x0004371C File Offset: 0x0004271C
		// (remove) Token: 0x06000712 RID: 1810 RVA: 0x00043740 File Offset: 0x00042740
		public override event EtatTransitionEventHandler EvtEtatTransition;

		// Token: 0x06000713 RID: 1811 RVA: 0x00043764 File Offset: 0x00042764
		public override void DebutTrameSurCable()
		{
			base.AllumerReception(this.trame.NumeroTrame);
			this.reseau.IncrementerNbTramesEnCours(base.NoeudAttache.NomNoeud);
			this.trame.Collisee = false;
			this.trame.Annulee = false;
			if (this.reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.trameReelle)
			{
				this.trame.NbTransmissionsEnCours = 0;
				this.trame.IncrementerNbTransmissions();
			}
			else
			{
				this.trame.NbTransmissionsEnCours++;
			}
			base.transmettreDebutTrame(this.trame, this.lien);
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x000437FC File Offset: 0x000427FC
		public override void FinTrameSurCable(bool p_collisee)
		{
			if (this.trame != null)
			{
				if (!this.trame.Collisee)
				{
					this.trame.Collisee = p_collisee;
				}
				base.transmettreFinTrame(this.trame, this.lien);
				int numeroOrdre = this.numeroOrdre;
				if (this.reseau.SimulationEthernet != Simulation.TypeDeSimulationEthernet.trameReelle)
				{
					base.receptionnerFinTrame(this.trame, "ps " + this.numeroOrdre);
				}
				if (!this.trame.Collisee)
				{
					base.EteindreReception();
				}
			}
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x00043888 File Offset: 0x00042888
		private void envoyerEvenementTransition(DDialogPlusEmissionTrame.TypEvtTransition evt)
		{
			if (this.EvtEtatTransition != null)
			{
				this.EvtEtatTransition(this, new EtatTransitionEventArgs((int)evt));
			}
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x000438B0 File Offset: 0x000428B0
		private void PortSwitch_CollisionRepandue(object sender, EventArgs e)
		{
			this.Liberer();
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x000438C4 File Offset: 0x000428C4
		public void AnnulerDemoEmission()
		{
			this.demoEmission.FinDemo();
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x000438DC File Offset: 0x000428DC
		public override void Liberer()
		{
			this.envoyerEvenementTransition(DDialogPlusEmissionTrame.TypEvtTransition.carteCableLibre);
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x000438F0 File Offset: 0x000428F0
		public override void LibererEmission()
		{
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x00043900 File Offset: 0x00042900
		public override void LibererReception()
		{
			this.envoyerEvenementTransition(DDialogPlusEmissionTrame.TypEvtTransition.carteCableLibre);
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x00043914 File Offset: 0x00042914
		public override void InstallerGestionEvenements()
		{
			if (this.lien != null)
			{
				base.InstallerGestionEvenements();
				Cable lien = this.lien;
				lien.CollisionRepandue = (EventHandler)Delegate.Combine(lien.CollisionRepandue, new EventHandler(this.PortSwitch_CollisionRepandue));
			}
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x00043958 File Offset: 0x00042958
		public override void DesinstallerGestionEvenements()
		{
			if (this.lien != null)
			{
				base.DesinstallerGestionEvenements();
				Cable lien = this.lien;
				lien.CollisionRepandue = (EventHandler)Delegate.Remove(lien.CollisionRepandue, new EventHandler(this.PortSwitch_CollisionRepandue));
			}
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x0004399C File Offset: 0x0004299C
		protected override void Port_CollisionDeuxPairesRecue(object sender, EventArgs e)
		{
			this.envoyerEvenementTransition(DDialogPlusEmissionTrame.TypEvtTransition.carteCollisionRecue);
		}

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x0600071E RID: 1822 RVA: 0x000439B0 File Offset: 0x000429B0
		// (remove) Token: 0x0600071F RID: 1823 RVA: 0x000439D4 File Offset: 0x000429D4
		public event EventHandler PortLibre;

		// Token: 0x06000720 RID: 1824 RVA: 0x000439F8 File Offset: 0x000429F8
		public void DemanderEmission()
		{
			if (this.trame == null)
			{
				this.PortLibre(this, new EventArgs());
			}
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x00043A20 File Offset: 0x00042A20
		public void Bloquer()
		{
			base.changerEtat(PointConnexion.EtatsConnexion.bloqué);
			if (this.lien != null)
			{
				switch (this.lien.Oppose(this).EtatConnexion)
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

		// Token: 0x06000722 RID: 1826 RVA: 0x00043A84 File Offset: 0x00042A84
		public void Debloquer()
		{
			if (this.lien == null)
			{
				base.changerEtat(PointConnexion.EtatsConnexion.allumé);
				return;
			}
			if (this.lien.Oppose(this).EtatConnexion == PointConnexion.EtatsConnexion.allumé)
			{
				if (this.lien.Activable())
				{
					base.changerEtat(PointConnexion.EtatsConnexion.actif);
					this.lien.Oppose(this).changerEtat(PointConnexion.EtatsConnexion.actif);
					return;
				}
				base.changerEtat(PointConnexion.EtatsConnexion.erreur);
				this.lien.Oppose(this).changerEtat(PointConnexion.EtatsConnexion.erreur);
				return;
			}
			else
			{
				if (this.lien.Oppose(this).EtatConnexion == PointConnexion.EtatsConnexion.erreur)
				{
					base.changerEtat(PointConnexion.EtatsConnexion.erreur);
					return;
				}
				base.changerEtat(PointConnexion.EtatsConnexion.allumé);
				return;
			}
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x00043B1C File Offset: 0x00042B1C
		private void mi_bloquer_Click(object sender, EventArgs e)
		{
			if (this.bloqueManuel)
			{
				this.Debloquer();
				this.bloqueManuel = false;
			}
			else
			{
				this.Bloquer();
				this.bloqueManuel = true;
			}
			this.reseau.SpanningTree();
			this.reseau.OkBis = false;
			this.reseau.PreparerBis();
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000724 RID: 1828 RVA: 0x00043B70 File Offset: 0x00042B70
		public bool BloqueManuel
		{
			get
			{
				return this.bloqueManuel;
			}
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x00043B84 File Offset: 0x00042B84
		protected override ContextMenu menuEthernet()
		{
			ContextMenu result;
			if (this.reseau.EtatEthernetActif == Simulation.EtatEthernet.attente)
			{
				if (((Switch)base.NoeudAttache).SpanningTree)
				{
					result = null;
				}
				else if (base.NoeudAttache.EnFonction)
				{
					if (!this.bloqueManuel)
					{
						this.mi_bloquer.Text = "Bloquer";
						result = this.cm_ethernet;
					}
					else
					{
						this.mi_bloquer.Text = "Débloquer";
						result = this.cm_ethernet;
					}
				}
				else
				{
					result = null;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x00043C04 File Offset: 0x00042C04
		public override void ReinitEthernet()
		{
			if (this.demoEmission != null)
			{
				this.demoEmission.DemoTerminee -= this.PortSwitch_DemoEmissionTerminee;
				this.demoEmission.ReinitEthernet();
				this.demoEmission = null;
			}
			this.trameEnCours = null;
			this.senderEnCours = null;
			this.DesinstallerGestionEvenements();
			this.trameDemoEmission = null;
			this.trame = null;
			if (this.etatConnexion == PointConnexion.EtatsConnexion.actif)
			{
				base.EteindreReception();
			}
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x00043C74 File Offset: 0x00042C74
		public override void StockerXml(XmlTextWriter writer)
		{
			int numeroOrdre = this.numeroOrdre;
			writer.WriteStartElement("PortSwitch");
			writer.WriteAttributeString("numero", numeroOrdre.ToString());
			writer.WriteElementString("PosDemoEmission.X", base.PosDemoEmission.X.ToString());
			writer.WriteElementString("PosDemoEmission.Y", base.PosDemoEmission.Y.ToString());
			writer.WriteEndElement();
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x00043CF0 File Offset: 0x00042CF0
		public bool OkToCarte(CarteReseau c)
		{
			if (this.etatConnexion == PointConnexion.EtatsConnexion.actif)
			{
				ArrayList arrayList = new ArrayList();
				arrayList.Add(this);
				return base.EstConnecte(c, ref arrayList, true);
			}
			return false;
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x00043D20 File Offset: 0x00042D20
		public override void SetContenuInfoBulle()
		{
			switch (this.reseau.ModeActif)
			{
			case Simulation.Mode.ethernet:
				this.infoBulle.SetToolTip(this, this.numeroOrdre.ToString());
				return;
			case Simulation.Mode.ip:
				if (((Switch)base.NoeudAttache).NiveauVlan != 0)
				{
					if (base.GetType() == typeof(Port8021qSwitch))
					{
						this.infoBulle.SetToolTip(this, "802.1q");
						return;
					}
					"vlan " + PortVlanEdit.GetNumVlan(((Switch)base.NoeudAttache).PortVlanNiv1, this.numeroOrdre).ToString();
					this.infoBulle.SetToolTip(this, "vlan " + PortVlanEdit.GetNumVlan(((Switch)base.NoeudAttache).PortVlanNiv1, this.numeroOrdre).ToString());
				}
				return;
			default:
				return;
			}
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x00043E04 File Offset: 0x00042E04
		public override void ChangerMode(Simulation.Mode nouveauMode)
		{
			this.SetContenuInfoBulle();
			switch (nouveauMode)
			{
			case Simulation.Mode.conceptionReseau:
				this.infoBulle.Active = false;
				return;
			case Simulation.Mode.ethernet:
				this.infoBulle.Active = true;
				return;
			case Simulation.Mode.ip:
				if (((Switch)base.NoeudAttache).NiveauVlan != 0)
				{
					this.infoBulle.Active = true;
					return;
				}
				this.infoBulle.Active = false;
				return;
			case Simulation.Mode.appl:
				this.infoBulle.Active = false;
				return;
			default:
				return;
			}
		}

		// Token: 0x04000477 RID: 1143
		private MenuItem mi_bloquer;

		// Token: 0x04000478 RID: 1144
		private IContainer components = null;

		// Token: 0x04000479 RID: 1145
		private TrameEthernet trame;

		// Token: 0x0400047A RID: 1146
		private DDialogPlusEmissionTrame demoEmission;

		// Token: 0x0400047B RID: 1147
		private TrameEthernet trameDemoEmission = null;

		// Token: 0x0400047F RID: 1151
		private bool bloqueManuel = false;
	}
}
