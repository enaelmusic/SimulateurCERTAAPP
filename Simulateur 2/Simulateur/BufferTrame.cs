using System;
using System.Collections;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200007B RID: 123
	public class BufferTrame
	{
		// Token: 0x06000772 RID: 1906 RVA: 0x00045E80 File Offset: 0x00044E80
		public BufferTrame()
		{
			this.tramesRetransmises = new Hashtable();
			this.numeroTrame = 0;
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x00045EC8 File Offset: 0x00044EC8
		public void init(PortSwitch pEmetteur, TrameEventArgs trameEvt, Switch p_switch)
		{
			this.portEmetteur = pEmetteur;
			this.trameEnCours = trameEvt;
			this.numeroTrame = trameEvt.Trame.NumeroTrame;
			this.tramesRetransmises = new Hashtable();
			this.monSwitch = p_switch;
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000774 RID: 1908 RVA: 0x00045F08 File Offset: 0x00044F08
		public PortSwitch PortEmetteur
		{
			get
			{
				return this.portEmetteur;
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000775 RID: 1909 RVA: 0x00045F1C File Offset: 0x00044F1C
		public TrameEthernet Trame
		{
			get
			{
				return this.trameEnCours.Trame;
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000776 RID: 1910 RVA: 0x00045F34 File Offset: 0x00044F34
		public Hashtable TramesRetransmises
		{
			get
			{
				return this.tramesRetransmises;
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000777 RID: 1911 RVA: 0x00045F48 File Offset: 0x00044F48
		// (set) Token: 0x06000778 RID: 1912 RVA: 0x00045F5C File Offset: 0x00044F5C
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

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000779 RID: 1913 RVA: 0x00045F70 File Offset: 0x00044F70
		// (set) Token: 0x0600077A RID: 1914 RVA: 0x00045F84 File Offset: 0x00044F84
		public int NbTramesATransmettre
		{
			get
			{
				return this.nbTramesATransmettre;
			}
			set
			{
				this.nbTramesATransmettre = value;
			}
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x00045F98 File Offset: 0x00044F98
		public void ReemettreDebutTrame()
		{
			this.nbTramesTransmises = 0;
			if (this.monSwitch.TypeSwitch == Switch.TypeDeSwitch.onTheFly)
			{
				foreach (object obj in this.tramesRetransmises.Keys)
				{
					PortSwitch portSwitch = (PortSwitch)obj;
					portSwitch.PortLibre += this.portLibreTransmis;
					portSwitch.DemanderEmission();
				}
			}
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x00046028 File Offset: 0x00045028
		private void portLibreTransmis(object sender, EventArgs e)
		{
			((PortSwitch)sender).PortLibre -= this.portLibreTransmis;
			this.monSwitch.retransmettreDebutTrameDeuxTrames((TrameEthernet)this.tramesRetransmises[sender], ((PortSwitch)sender).Lien);
			((PortSwitch)sender).ReemissionTerminee += this.reemissionTermineTransmis;
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x0004608C File Offset: 0x0004508C
		private void reemissionTermineTransmis(object sender, EventArgs e)
		{
			((PortSwitch)sender).ReemissionTerminee -= this.reemissionTermineTransmis;
			this.nbTramesTransmises++;
			if (this.nbTramesTransmises == this.tramesRetransmises.Count)
			{
				this.SuiteReemissionTermineTransmis();
			}
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x000460D8 File Offset: 0x000450D8
		public void SuiteReemissionTermineTransmis()
		{
			this.monSwitch.ViderTampon(this.trameEnCours.Trame.NumeroTrame);
			if (this.monSwitch.Reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.trameReelle)
			{
				this.monSwitch.ReceptionnerTrameDeuxTrames(this.trameEnCours.Trame);
			}
			this.numeroTrame = 0;
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x00046130 File Offset: 0x00045130
		public void ReemettreFinTrame()
		{
			if (this.monSwitch.TypeSwitch == Switch.TypeDeSwitch.onTheFly)
			{
				if (this.trameEnCours.Trame.Collisee)
				{
					this.monSwitch.ViderTampon(this.trameEnCours.Trame.NumeroTrame);
					foreach (object obj in this.tramesRetransmises.Keys)
					{
						PortSwitch portSwitch = (PortSwitch)obj;
						if (portSwitch.TrameDemoEmission == (TrameEthernet)this.tramesRetransmises[portSwitch])
						{
							((TrameEthernet)this.tramesRetransmises[portSwitch]).Collisee = true;
							if (portSwitch.DemoEmission.EnEmission)
							{
								this.monSwitch.Reseau.DecrementerNbTramesEnCours("ramsw");
								if (this.monSwitch.Reseau.NbTrameEnCours == 0 && this.monSwitch.Reseau.NbCollisionsDeuxPaires == 0 && this.monSwitch.Reseau.OwnedForms.GetLength(0) == 0)
								{
									this.monSwitch.Reseau.ArreterSimulation(((TrameEthernet)this.tramesRetransmises[portSwitch]).CarteEmetteur);
								}
								this.monSwitch.retransmettreFinTrameDeuxTrames((TrameEthernet)this.tramesRetransmises[portSwitch], portSwitch.Lien);
							}
							else
							{
								portSwitch.AnnulerDemoEmission();
							}
						}
						else
						{
							portSwitch.PortLibre -= this.portLibreTransmis;
						}
					}
					this.numeroTrame = 0;
					return;
				}
			}
			else
			{
				if (this.trameEnCours.Trame.Collisee)
				{
					this.monSwitch.ViderTampon(this.trameEnCours.Trame.NumeroTrame);
					this.numeroTrame = 0;
					return;
				}
				if (this.tramesRetransmises.Count > 0)
				{
					this.monSwitch.ArreterTampon(this.trameEnCours.Trame.NumeroTrame);
				}
				else
				{
					this.monSwitch.ViderTampon(this.trameEnCours.Trame.NumeroTrame);
				}
				foreach (object obj2 in this.tramesRetransmises.Keys)
				{
					PortSwitch portSwitch2 = (PortSwitch)obj2;
					portSwitch2.PortLibre += this.portLibreTransmis;
					portSwitch2.DemanderEmission();
				}
				if (this.tramesRetransmises.Count == 0)
				{
					this.delaiReemissionTrameComplete.Interval = 1;
				}
				else
				{
					this.delaiReemissionTrameComplete.Interval = this.trameEnCours.Trame.TempsEmission();
				}
				this.delaiReemissionTrameComplete.Tick += this.finDelaiReemissionTrameCompleteDeuxTrames;
				this.delaiReemissionTrameComplete.Start();
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000780 RID: 1920 RVA: 0x00046418 File Offset: 0x00045418
		public Timer DelaiReemissionTrameComplete
		{
			get
			{
				return this.delaiReemissionTrameComplete;
			}
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x0004642C File Offset: 0x0004542C
		private void finDelaiReemissionTrameCompleteDeuxTrames(object sender, EventArgs e)
		{
			this.delaiReemissionTrameComplete.Stop();
			this.delaiReemissionTrameComplete.Tick -= this.finDelaiReemissionTrameCompleteDeuxTrames;
			foreach (object obj in this.tramesRetransmises.Keys)
			{
				PortSwitch portSwitch = (PortSwitch)obj;
				this.monSwitch.retransmettreFinTrameDeuxTrames((TrameEthernet)this.tramesRetransmises[portSwitch], portSwitch.Lien);
			}
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x000464D4 File Offset: 0x000454D4
		public void ReinitEthernet()
		{
			this.portEmetteur = null;
			this.trameEnCours = null;
			this.numeroTrame = 0;
			if (this.tramesRetransmises != null)
			{
				foreach (object obj in this.tramesRetransmises.Values)
				{
					TrameEthernet trameEthernet = (TrameEthernet)obj;
					trameEthernet.ReinitEthernet();
				}
			}
			this.tramesRetransmises = new Hashtable();
			this.delaiReemissionTrameComplete.Tick -= this.finDelaiReemissionTrameCompleteDeuxTrames;
			if (this.monSwitch != null)
			{
				foreach (object obj2 in this.monSwitch.Controls)
				{
					PortSwitch portSwitch = (PortSwitch)obj2;
					portSwitch.ReemissionTerminee -= this.reemissionTermineTransmis;
					portSwitch.PortLibre -= this.portLibreTransmis;
				}
			}
		}

		// Token: 0x04000495 RID: 1173
		private Switch monSwitch;

		// Token: 0x04000496 RID: 1174
		private PortSwitch portEmetteur;

		// Token: 0x04000497 RID: 1175
		private TrameEventArgs trameEnCours;

		// Token: 0x04000498 RID: 1176
		private Hashtable tramesRetransmises;

		// Token: 0x04000499 RID: 1177
		private int numeroTrame = 0;

		// Token: 0x0400049A RID: 1178
		private int nbTramesTransmises = 0;

		// Token: 0x0400049B RID: 1179
		private int nbTramesATransmettre = 0;

		// Token: 0x0400049C RID: 1180
		private Timer delaiReemissionTrameComplete = new TimerEtatTransition();
	}
}
