using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000071 RID: 113
	public class Port : PointConnexion
	{
		// Token: 0x060006EB RID: 1771 RVA: 0x00042B78 File Offset: 0x00041B78
		public Port()
		{
			this.InitializeComponent();
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x00042B98 File Offset: 0x00041B98
		public Port(Simulation s) : base(s)
		{
			this.InitializeComponent();
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x00042BBC File Offset: 0x00041BBC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x00042BE8 File Offset: 0x00041BE8
		private void InitializeComponent()
		{
			base.Name = "Port";
			base.Size = new Size(11, 11);
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x00042C10 File Offset: 0x00041C10
		protected void initOkCablesMDI()
		{
			this.okCableCroise.Add(PointConnexion.TypesPointConnexion.portHub);
			this.okCableCroise.Add(PointConnexion.TypesPointConnexion.portSwitch);
			this.okCableDroit.Add(PointConnexion.TypesPointConnexion.carteReseau);
			this.okCableDroit.Add(PointConnexion.TypesPointConnexion.portCascadeHub);
			this.okCableDroit.Add(PointConnexion.TypesPointConnexion.portCascadeSwitch);
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x00042C78 File Offset: 0x00041C78
		protected void initOkCablesMDIX()
		{
			this.okCableCroise.Add(PointConnexion.TypesPointConnexion.portCascadeHub);
			this.okCableCroise.Add(PointConnexion.TypesPointConnexion.portCascadeSwitch);
			this.okCableDroit.Add(PointConnexion.TypesPointConnexion.portHub);
			this.okCableDroit.Add(PointConnexion.TypesPointConnexion.portSwitch);
			this.okCableCroise.Add(PointConnexion.TypesPointConnexion.carteReseau);
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x00042CE0 File Offset: 0x00041CE0
		protected void initOkCables8021q()
		{
			this.okCableCroise.Add(PointConnexion.TypesPointConnexion.port8021qSwitch);
			this.okCableDroit.Add(PointConnexion.TypesPointConnexion.port8021qSwitch);
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x00042D14 File Offset: 0x00041D14
		protected override ContextMenu menuConception()
		{
			if (this.lien != null)
			{
				return new ContextMenu(new MenuItem[]
				{
					this.mi_configurerCable,
					this.mi_supprimerCable
				});
			}
			return null;
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x00042D4C File Offset: 0x00041D4C
		protected void initialiserCascade(Simulation s)
		{
			this.stylo = s.Pref.EpaisStylo;
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00042D6C File Offset: 0x00041D6C
		protected void initialiser8021q(Simulation s)
		{
			this.stylo = s.Pref.TresEpaisStylo;
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00042D8C File Offset: 0x00041D8C
		protected void PortDeCascade_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.DrawRectangle(this.stylo, 1, 1, base.Width - 2, base.Height - 2);
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00042DC0 File Offset: 0x00041DC0
		public override void InstallerGestionEvenements()
		{
			if (this.lien != null)
			{
				this.lien.TrameTransmise += this.Port_TrameTransmise;
				base.NoeudAttache.TrameTransmise += this.Port_TrameTransmise;
				this.lien.DebutTrameTransmis += this.Port_DebutTrameTransmis;
				base.NoeudAttache.DebutTrameTransmis += this.Port_DebutTrameTransmis;
				this.lien.FinTrameTransmis += this.Port_FinTrameTransmis;
				base.NoeudAttache.FinTrameTransmis += this.Port_FinTrameTransmis;
				Cable lien = this.lien;
				lien.CollisionDeuxPaires = (EventHandler)Delegate.Combine(lien.CollisionDeuxPaires, new EventHandler(this.Port_CollisionDeuxPairesRecue));
			}
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x00042E90 File Offset: 0x00041E90
		public override void DesinstallerGestionEvenements()
		{
			if (this.lien != null)
			{
				this.lien.TrameTransmise -= this.Port_TrameTransmise;
				base.NoeudAttache.TrameTransmise -= this.Port_TrameTransmise;
				this.lien.DebutTrameTransmis -= this.Port_DebutTrameTransmis;
				base.NoeudAttache.DebutTrameTransmis -= this.Port_DebutTrameTransmis;
				this.lien.FinTrameTransmis -= this.Port_FinTrameTransmis;
				base.NoeudAttache.FinTrameTransmis -= this.Port_FinTrameTransmis;
				Cable lien = this.lien;
				lien.CollisionDeuxPaires = (EventHandler)Delegate.Remove(lien.CollisionDeuxPaires, new EventHandler(this.Port_CollisionDeuxPairesRecue));
			}
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00042F60 File Offset: 0x00041F60
		protected virtual void Port_CollisionDeuxPairesRecue(object sender, EventArgs e)
		{
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x00042F70 File Offset: 0x00041F70
		protected virtual void Port_TrameTransmise(ElementReseau sender, TrameEventArgs e)
		{
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00042F80 File Offset: 0x00041F80
		protected virtual void Port_FinTrameTransmis(ElementReseau sender, TrameEventArgs e)
		{
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x00042F90 File Offset: 0x00041F90
		protected virtual void Port_DebutTrameTransmis(ElementReseau sender, TrameEventArgs e)
		{
		}

		// Token: 0x04000476 RID: 1142
		private Container components = null;
	}
}
