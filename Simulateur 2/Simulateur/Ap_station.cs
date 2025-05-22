using System;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000004 RID: 4
	public class Ap_station
	{
		// Token: 0x0600003D RID: 61 RVA: 0x000029AC File Offset: 0x000019AC
		public Ap_station(Station s)
		{
			this.st = s;
			this.tempo.Interval = 1000;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000029E4 File Offset: 0x000019E4
		private void demarrerSimulationAp()
		{
			this.st.Reseau.SetEnabledMenus(false);
			this.st.Reseau.BloquerReglages();
			this.st.Reseau.EtatApplActif = Simulation.EtatAppl.simulationEnCours;
			this.st.Reseau.TimerTraceTrame.Start();
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002A38 File Offset: 0x00001A38
		private void arreterSimulationAp()
		{
			this.st.Reseau.TimerTraceTrame.Stop();
			this.st.Reseau.EtatApplActif = Simulation.EtatAppl.attente;
			this.st.Reseau.CacherMessage();
			this.st.Reseau.SetEnabledMenus(true);
			this.st.Reseau.LibererReglages();
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002A9C File Offset: 0x00001A9C
		public void EnvoyerMessage()
		{
			if (this.st.Reseau.NoBouclesHubGeneral())
			{
				this.demarrerSimulationAp();
				new Ip_DialogueSaisieIP(new SuiteOk(this.SuiteEnvoyerMessage), new SuiteAnnuler(this.AnnulerEnvoyerMessage), this.st)
				{
					Text = "Hôte de destination",
					Location = this.st.posDialogueDemo()
				}.Show();
				return;
			}
			MessageBox.Show("Impossible, le réseau comporte des boucles !");
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002B14 File Offset: 0x00001B14
		public void AnnulerEnvoyerMessage()
		{
			this.arreterSimulationAp();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002B28 File Offset: 0x00001B28
		public void SuiteEnvoyerMessage(object p_strAdrIp)
		{
			string text = (string)p_strAdrIp;
			if (!Ip_adresse.Ok(text))
			{
				text = FichierHostsEdit.GetAdrIp(this.st.Ip.FichierHosts, text);
			}
			if (!Ip_adresse.Ok(text))
			{
				MessageBox.Show("Adresse IP incorrecte !");
				this.arreterSimulationAp();
				return;
			}
			this.paquetEnCours = new Ip_PaquetIp(this.st, new Ip_adresse(text), TypeDePaquetIp.messageAppl, text);
			this.paquetEnCours.Donnees = "Exemple de message d'application";
			if (this.st.Ip.CalculerRoute(this.paquetEnCours))
			{
				if (this.st.Reseau.Pref.TrameModeAp)
				{
					Pen stylo = new Pen(this.st.Reseau.Pref.CableActifStylo1.Brush, 1f);
					foreach (object obj in this.paquetEnCours.CablesTraverses)
					{
						Cable cable = (Cable)obj;
						cable.Stylo = stylo;
					}
					this.st.Reseau.Schema.Invalidate(false);
				}
				this.depart = ((Station)this.paquetEnCours.Route[this.paquetEnCours.Route.Count - 1]).GetCentre();
				this.arrivee = ((Station)this.paquetEnCours.Route[0]).GetCentre();
				this.st.Reseau.Schema.Controls[0].Visible = true;
				this.st.Reseau.Schema.Controls[0].Location = this.depart;
				this.st.Reseau.AfficherMessage(this.paquetEnCours);
				if (this.st.Reseau.Pref.RouteModeAp)
				{
					this.traceIp = new Ip_CableVirtuel(this.paquetEnCours.Route, this.st.Reseau, true);
					this.st.Reseau.Schema.Controls.Add(this.traceIp);
				}
				else
				{
					this.traceIp = new Ip_CableVirtuel(this.paquetEnCours.Route, this.st.Reseau, false);
				}
				this.tempo.Tick += this.FinEnvoyerMessage;
				this.tempo.Start();
				return;
			}
			MessageBox.Show("Impossible de joindre l'hôte de destination !");
			this.arreterSimulationAp();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002DD0 File Offset: 0x00001DD0
		public void FinTraceIcone(object sender, EventArgs e)
		{
			if (this.trace != null)
			{
				this.trace.TraceTermine -= this.FinTraceIcone;
				this.st.Reseau.Schema.Controls[0].Paint -= this.trace.TracerCable;
			}
			this.trace = null;
			this.tempo.Tick += this.FinSimulationAp;
			this.tempo.Start();
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002E58 File Offset: 0x00001E58
		private void FinEnvoyerMessage(object sender, EventArgs e)
		{
			this.tempo.Stop();
			this.tempo.Tick -= this.FinEnvoyerMessage;
			Pen pen = new Pen(this.st.Reseau.Schema.BackColor, 1f);
			this.trace = new TraceCable(false, TraceCable.TypeDeTrace.messageAppl, pen, pen, pen, pen, this.st.Reseau.Schema.BackColor, this.traceIp, this.depart, this.arrivee);
			this.st.Reseau.Schema.Controls[0].Paint += this.trace.TracerCable;
			this.trace.TraceTermine += this.FinTraceIcone;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002F28 File Offset: 0x00001F28
		private void FinSimulationAp(object sender, EventArgs e)
		{
			this.tempo.Stop();
			this.tempo.Tick -= this.FinSimulationAp;
			this.st.Reseau.Schema.Controls[0].Visible = false;
			if (this.st.Reseau.Pref.RouteModeAp)
			{
				this.st.Reseau.Schema.Controls.Remove(this.traceIp);
			}
			this.traceIp = null;
			if (this.st.Reseau.Pref.TrameModeAp)
			{
				foreach (object obj in this.paquetEnCours.CablesTraverses)
				{
					Cable cable = (Cable)obj;
					cable.Stylo = this.st.Reseau.Pref.NormalStylo;
				}
			}
			this.st.Reseau.Schema.Invalidate();
			this.arreterSimulationAp();
		}

		// Token: 0x04000015 RID: 21
		private Station st;

		// Token: 0x04000016 RID: 22
		private Ip_PaquetIp paquetEnCours;

		// Token: 0x04000017 RID: 23
		private TraceCable trace;

		// Token: 0x04000018 RID: 24
		private Ip_CableVirtuel traceIp;

		// Token: 0x04000019 RID: 25
		private Point depart;

		// Token: 0x0400001A RID: 26
		private Point arrivee;

		// Token: 0x0400001B RID: 27
		private Timer tempo = new Timer();
	}
}
