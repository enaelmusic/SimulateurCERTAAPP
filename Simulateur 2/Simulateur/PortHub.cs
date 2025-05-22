using System;
using System.ComponentModel;
using System.Drawing;

namespace Simulateur
{
	// Token: 0x02000074 RID: 116
	public class PortHub : Port
	{
		// Token: 0x06000730 RID: 1840 RVA: 0x00043F50 File Offset: 0x00042F50
		public PortHub()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x00043F78 File Offset: 0x00042F78
		public PortHub(Simulation s) : base(s)
		{
			this.InitializeComponent();
			base.Size = new Size(11, 11);
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x00043FB0 File Offset: 0x00042FB0
		protected override void initOkCables()
		{
			this.typePointConnexion = PointConnexion.TypesPointConnexion.portHub;
			base.initOkCablesMDI();
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x00043FCC File Offset: 0x00042FCC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x00043FF8 File Offset: 0x00042FF8
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x00044010 File Offset: 0x00043010
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

		// Token: 0x06000736 RID: 1846 RVA: 0x00044088 File Offset: 0x00043088
		protected override void Port_DebutTrameTransmis(ElementReseau sender, TrameEventArgs e)
		{
			if (e.Cible != this)
			{
				if (e.Cible == this.lien)
				{
					e.Trame.IncrementerNbTransmissions();
					base.transmettreDebutTrame(e.Trame, e.Cible);
				}
				return;
			}
			if (!((Hub)base.NoeudAttache).Occupe() && !((Hub)base.NoeudAttache).CollisionRecue)
			{
				e.Trame.IncrementerNbTransmissions();
				base.transmettreDebutTrame(e.Trame, base.NoeudAttache);
				return;
			}
			if (!e.Trame.Collisee)
			{
				e.Trame.Annuler();
				((Hub)base.NoeudAttache).TrameEnCours.Trame.Annuler();
				e.Trame.Collisee = true;
				e.Trame.TrameAnnulee += this.receptionTrameAnnulee;
				((Hub)base.NoeudAttache).ColliserTrameEnCours();
				((Hub)base.NoeudAttache).TrameEnCours.Trame.TrameAnnulee += this.receptionTrameAnnulee;
				this.detecterCollision(true);
				return;
			}
			this.detecterCollision(false);
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x000441AC File Offset: 0x000431AC
		private void receptionTrameAnnulee(object sender, EventArgs e)
		{
			((TrameEthernet)sender).TrameAnnulee -= this.receptionTrameAnnulee;
			this.domCollision.NbTramesAnnulees++;
			this.arreterCollision();
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x000441EC File Offset: 0x000431EC
		protected override void Port_FinTrameTransmis(ElementReseau sender, TrameEventArgs e)
		{
			if (e.Cible == this)
			{
				if (!((Hub)base.NoeudAttache).EnCollision && !e.Trame.Collisee)
				{
					base.transmettreFinTrame(e.Trame, base.NoeudAttache);
					base.receptionnerFinTrame(e.Trame, "porthub");
					return;
				}
				((Hub)base.NoeudAttache).EnvoyerFinTrameCollisee(this);
				if (((Hub)base.NoeudAttache).EnCollision)
				{
					base.annulerTrame(e.Trame);
					return;
				}
			}
			else if (e.Cible == this.lien)
			{
				base.transmettreFinTrame(e.Trame, e.Cible);
			}
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x00044298 File Offset: 0x00043298
		private void detecterCollision(bool portHubGestionnaire)
		{
			if (portHubGestionnaire)
			{
				this.reseau.NbCollisionsDeuxPaires++;
				((Hub)base.NoeudAttache).EnCollision = true;
				this.domCollision = new DomaineCollision(this);
				this.domCollision.NbTramesAnnulees = 0;
				foreach (object obj in this.domCollision.Cables)
				{
					Cable cable = (Cable)obj;
					Cable cable2 = cable;
					cable2.CollisionRepandueParCable = (EventHandler)Delegate.Combine(cable2.CollisionRepandueParCable, new EventHandler(this.collisionCableOk));
					cable.EcouterCollisionRepandue(this);
				}
				((Hub)base.NoeudAttache).envoyerCollisionDeuxPaires(this);
				this.envoyerCollisionDeuxPaires();
			}
			else
			{
				((Hub)base.NoeudAttache).envoyerCollisionDeuxPaires(this);
			}
			((Hub)base.NoeudAttache).DessinerCollision();
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x000443A0 File Offset: 0x000433A0
		public void envoyerCollisionDeuxPaires()
		{
			if (this.CollisionDeuxPaires != null)
			{
				this.CollisionDeuxPaires(this, new EventArgs());
			}
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x000443C8 File Offset: 0x000433C8
		private void collisionCableOk(object sender, EventArgs e)
		{
			this.domCollision.NbCollisionCableOk++;
			this.arreterCollision();
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x000443F0 File Offset: 0x000433F0
		private void arreterCollision()
		{
			if (this.domCollision.NbCollisionCableOk == this.domCollision.Cables.Count && this.domCollision.NbTramesAnnulees == 2)
			{
				CarteReseau carteRepresentante = this.domCollision.CarteRepresentante;
				if (this.CollisionRepandue != null)
				{
					this.CollisionRepandue(this, new EventArgs());
				}
				this.domCollision.NbCollisionCableOk = 0;
				foreach (object obj in this.domCollision.Cables)
				{
					Cable cable = (Cable)obj;
					Cable cable2 = cable;
					cable2.CollisionRepandueParCable = (EventHandler)Delegate.Remove(cable2.CollisionRepandueParCable, new EventHandler(this.collisionCableOk));
					cable.NePasEcouterCollisionRepandue(this);
					if (cable.Origine.NoeudAttache.GetType() == typeof(Hub))
					{
						((Hub)cable.Origine.NoeudAttache).Liberer();
					}
					else if (cable.Extremite.NoeudAttache.GetType() == typeof(Hub))
					{
						((Hub)cable.Extremite.NoeudAttache).Liberer();
					}
				}
				this.domCollision = null;
				((Hub)base.NoeudAttache).AnnulerTrameEnCours();
				((Hub)base.NoeudAttache).EnCollision = false;
				this.reseau.decrementerCollisionsDeuxPaires(carteRepresentante);
				if (this.reseau.NbTrameEnCours == 0 && this.reseau.NbCollisionsDeuxPaires == 0 && this.reseau.OwnedForms.GetLength(0) == 0)
				{
					this.reseau.ArreterSimulation(carteRepresentante);
				}
			}
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x000445B8 File Offset: 0x000435B8
		protected override void Port_CollisionDeuxPairesRecue(object sender, EventArgs e)
		{
			if ((Port)sender == this.lien.Oppose(this))
			{
				((Hub)base.NoeudAttache).envoyerCollisionDeuxPaires(this);
			}
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x000445EC File Offset: 0x000435EC
		public override void ReinitEthernet()
		{
			base.ReinitEthernet();
			if (this.domCollision != null)
			{
				foreach (object obj in this.domCollision.Cables)
				{
					Cable cable = (Cable)obj;
					Cable cable2 = cable;
					cable2.CollisionRepandueParCable = (EventHandler)Delegate.Remove(cable2.CollisionRepandueParCable, new EventHandler(this.collisionCableOk));
				}
				this.domCollision = null;
			}
		}

		// Token: 0x04000481 RID: 1153
		private IContainer components = null;

		// Token: 0x04000482 RID: 1154
		public EventHandler CollisionRepandue;

		// Token: 0x04000483 RID: 1155
		private DomaineCollision domCollision = null;
	}
}
