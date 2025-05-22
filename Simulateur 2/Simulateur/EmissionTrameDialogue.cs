using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200003C RID: 60
	public partial class EmissionTrameDialogue : Form
	{
		// Token: 0x0600036F RID: 879 RVA: 0x0002963C File Offset: 0x0002863C
		public EmissionTrameDialogue()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000370 RID: 880 RVA: 0x00029664 File Offset: 0x00028664
		public EmissionTrameDialogue(CarteReseau p_emetteur, int numOrdre)
		{
			this.InitializeComponent();
			this.numOrdreTrame = numOrdre;
			this.emetteur = p_emetteur;
			this.reseau = this.emetteur.Reseau;
			if (this.reseau.BisEnCours)
			{
				this.initialiserBis(numOrdre);
				return;
			}
			this.initialiser();
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000371 RID: 881 RVA: 0x000296C8 File Offset: 0x000286C8
		// (set) Token: 0x06000372 RID: 882 RVA: 0x000296DC File Offset: 0x000286DC
		public bool CollisionDeuxPaires
		{
			get
			{
				return this.collisionDeuxPaires;
			}
			set
			{
				this.collisionDeuxPaires = value;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000373 RID: 883 RVA: 0x000296F0 File Offset: 0x000286F0
		public int TailleTrame
		{
			get
			{
				return this.cb_tailleTrame.SelectedIndex;
			}
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00029708 File Offset: 0x00028708
		private void initialiser()
		{
			if (this.reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.trameReelle)
			{
				base.Height = 180;
				this.bt_annuler.Top = 124;
				this.bt_ok.Top = 124;
				this.cb_tailleTrame.Visible = true;
				this.cb_tailleTrame.SelectedIndex = 1;
			}
			else
			{
				base.Height = 156;
				this.bt_annuler.Top = 100;
				this.bt_ok.Top = 100;
				this.cb_tailleTrame.Visible = false;
			}
			this.Text = "Emetteur " + this.emetteur.NoeudAttache.NomNoeud + " : " + this.emetteur.LibelleEmissionTrame();
			this.rb_broadcast.Checked = true;
			this.tb_adrMacDestinataire.Text = this.reseau.Pref.AdrMacBroadcast;
			this.tb_adrMacDestinataire.Enabled = false;
		}

		// Token: 0x06000375 RID: 885 RVA: 0x000297F8 File Offset: 0x000287F8
		private void initialiserBis(int p_numOrdre)
		{
			if (this.reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.trameReelle)
			{
				base.Height = 180;
				this.bt_annuler.Top = 124;
				this.bt_ok.Top = 124;
				this.cb_tailleTrame.Visible = true;
			}
			else
			{
				base.Height = 156;
				this.bt_annuler.Top = 100;
				this.bt_ok.Top = 100;
				this.cb_tailleTrame.Visible = false;
			}
			this.Text = "Emetteur " + this.emetteur.NoeudAttache.NomNoeud + " : " + this.emetteur.LibelleEmissionTrame();
			if (this.reseau.DerniereSimulation.Trames[this.numOrdreTrame - 1].Envoyee)
			{
				if (this.reseau.DerniereSimulation.Trames[this.numOrdreTrame - 1].AdrDestinataire == this.reseau.Pref.AdrMacBroadcast)
				{
					this.rb_broadcast.Checked = true;
				}
				else
				{
					this.rb_unicast.Checked = true;
				}
				this.tb_adrMacDestinataire.Text = this.reseau.DerniereSimulation.Trames[this.numOrdreTrame - 1].AdrDestinataire;
				this.cb_tailleTrame.SelectedIndex = this.reseau.DerniereSimulation.Trames[this.numOrdreTrame - 1].TailleTrame;
			}
			else
			{
				this.rb_broadcast.Checked = false;
				this.rb_unicast.Checked = false;
				this.tb_adrMacDestinataire.Text = "Trame non envoyée";
				this.cb_tailleTrame.SelectedIndex = -1;
			}
			this.Desactiver(true);
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000376 RID: 886 RVA: 0x000299A8 File Offset: 0x000289A8
		public int NumOrdreTrame
		{
			get
			{
				return this.numOrdreTrame;
			}
		}

		// Token: 0x06000379 RID: 889 RVA: 0x00029F28 File Offset: 0x00028F28
		private void destination_Changed(object sender, EventArgs e)
		{
			if (this.rb_unicast.Checked)
			{
				this.tb_adrMacDestinataire.Text = EmissionTrameDialogue.messageAdresse;
				this.tb_adrMacDestinataire.Enabled = true;
				this.reseau.AdrMacAttente = this.tb_adrMacDestinataire;
				return;
			}
			if (this.rb_broadcast.Checked)
			{
				if (this.reseau.AdrMacAttente == this.tb_adrMacDestinataire)
				{
					this.reseau.AdrMacAttente = null;
				}
				this.tb_adrMacDestinataire.Text = this.reseau.Pref.AdrMacBroadcast;
				this.tb_adrMacDestinataire.Enabled = false;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600037A RID: 890 RVA: 0x00029FC4 File Offset: 0x00028FC4
		public CarteReseau Emetteur
		{
			get
			{
				return this.emetteur;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600037C RID: 892 RVA: 0x00029FF4 File Offset: 0x00028FF4
		// (set) Token: 0x0600037B RID: 891 RVA: 0x00029FD8 File Offset: 0x00028FD8
		public string Destinataire
		{
			get
			{
				return this.tb_adrMacDestinataire.Text;
			}
			set
			{
				this.tb_adrMacDestinataire.Text = value;
			}
		}

		// Token: 0x0600037D RID: 893 RVA: 0x0002A00C File Offset: 0x0002900C
		private EmissionTrameDialogue autre()
		{
			if (this.numOrdreTrame == 1)
			{
				return this.reseau.DialogueEmissionTrame2;
			}
			return this.reseau.DialogueEmissionTrame1;
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0002A03C File Offset: 0x0002903C
		public void bt_ok_Click(object sender, EventArgs e)
		{
			if (this.tb_adrMacDestinataire.Text == EmissionTrameDialogue.messageAdresse)
			{
				this.tb_adrMacDestinataire.Text = this.reseau.Pref.AdrMacBroadcast;
			}
			if (this.emetteur.Reseau.Pref.MemoriserPosDemo)
			{
				this.emetteur.NoeudAttache.FixerPosition(base.Location.X, base.Location.Y);
			}
			Simulation.TimerEmissionTrame.Tick += this.TimerEmissionTrame_Tick;
		}

		// Token: 0x0600037F RID: 895 RVA: 0x0002A0D4 File Offset: 0x000290D4
		private void TimerEmissionTrame_Tick(object sender, EventArgs e)
		{
			Simulation.TimerEmissionTrame.Tick -= this.TimerEmissionTrame_Tick;
			this.emetteur.SuiteEmissionTrame(this.cb_tailleTrame.SelectedIndex);
		}

		// Token: 0x06000380 RID: 896 RVA: 0x0002A110 File Offset: 0x00029110
		private void bt_annuler_Click(object sender, EventArgs e)
		{
			this.emetteur.AbandonEmissionTrame();
			this.reseau.PreparerBis();
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0002A134 File Offset: 0x00029134
		private void EmissionTrameDialogue_Activated(object sender, EventArgs e)
		{
			if (this.rb_unicast.Checked)
			{
				this.reseau.AdrMacAttente = this.tb_adrMacDestinataire;
				return;
			}
			this.reseau.AdrMacAttente = null;
		}

		// Token: 0x06000382 RID: 898 RVA: 0x0002A16C File Offset: 0x0002916C
		private void tb_adrMacDestinataire_TextChanged(object sender, EventArgs e)
		{
			if (!this.reseau.BisEnCours)
			{
				if (this.tb_adrMacDestinataire.Text == this.reseau.Pref.AdrMacBroadcast)
				{
					this.rb_broadcast.Checked = true;
				}
				else if (this.tb_adrMacDestinataire.Text == this.emetteur.AdresseMac)
				{
					this.tb_adrMacDestinataire.Text = this.reseau.Pref.AdrMacBroadcast;
				}
				else
				{
					string text = this.tb_adrMacDestinataire.Text;
					this.rb_unicast.Checked = true;
					this.tb_adrMacDestinataire.Text = text;
				}
				this.bt_ok.Enabled = (this.tb_adrMacDestinataire.Text != EmissionTrameDialogue.messageAdresse);
			}
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0002A238 File Offset: 0x00029238
		public void Desactiver(bool tout)
		{
			this.rb_broadcast.Enabled = (this.rb_unicast.Enabled = false);
			this.tb_adrMacDestinataire.Enabled = false;
			this.cb_tailleTrame.Enabled = false;
			if (tout)
			{
				this.bt_annuler.Enabled = (this.bt_ok.Enabled = false);
			}
		}

		// Token: 0x06000384 RID: 900 RVA: 0x0002A294 File Offset: 0x00029294
		public void InScreen()
		{
			Dialogue.InScreen(this);
		}

		// Token: 0x040002D2 RID: 722
		private bool collisionDeuxPaires = false;

		// Token: 0x040002D3 RID: 723
		private Simulation reseau;

		// Token: 0x040002D4 RID: 724
		private int numOrdreTrame;

		// Token: 0x040002D5 RID: 725
		private static string messageAdresse = "Cliquer sur la carte réseau";

		// Token: 0x040002D6 RID: 726
		private CarteReseau emetteur;
	}
}
