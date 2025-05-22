using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000020 RID: 32
	public partial class DemoDialogue : Form
	{
		// Token: 0x060001E6 RID: 486 RVA: 0x0001049C File Offset: 0x0000F49C
		public DemoDialogue()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x000104F0 File Offset: 0x0000F4F0
		public DemoDialogue(Form f)
		{
			this.InitializeComponent();
			base.Owner = f;
			this.simul = f;
			this.attente.Interval = (int)((float)((Simulation)this.simul).Pref.TempsAttenteDemoDefaut / ((Simulation)this.simul).CoefVitesseDemo);
			this.attente.Start();
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00010590 File Offset: 0x0000F590
		protected virtual void setInScreen()
		{
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x000105A0 File Offset: 0x0000F5A0
		// (set) Token: 0x060001EA RID: 490 RVA: 0x000105B4 File Offset: 0x0000F5B4
		public string TitreDialogue
		{
			get
			{
				return this.titreDialogue;
			}
			set
			{
				this.titreDialogue = value;
			}
		}

		// Token: 0x1700003B RID: 59
		// (set) Token: 0x060001EB RID: 491 RVA: 0x000105C8 File Offset: 0x0000F5C8
		public string LibellePhase
		{
			set
			{
				if (value == "")
				{
					this.Text = this.titreDialogue;
					return;
				}
				this.Text = this.titreDialogue + " : " + value;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060001EE RID: 494 RVA: 0x00010ABC File Offset: 0x0000FABC
		public Timer Attente
		{
			get
			{
				return this.attente;
			}
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00010AD0 File Offset: 0x0000FAD0
		protected virtual void executerPhase()
		{
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00010AE0 File Offset: 0x0000FAE0
		protected void executerPhaseSuivante(object sender, EventArgs e)
		{
			this.numPhasePrecedente = this.numPhaseSuivante;
			this.tb_resultat.Text = "";
			if (this.numPhaseSuivante < this.actions.Count)
			{
				this.tb_phase.Text = (string)this.actions[this.numPhaseSuivante];
			}
			switch (this.typeDemo)
			{
			case Simulation.TypeDeDemo.automatique:
				this.executerPhase();
				if (this.numPhaseSuivante == this.actions.Count)
				{
					this.lecteur.Bt_pauseEnabled = false;
					this.attente.Tick -= this.executerPhaseSuivante;
					this.attente.Tick += this.FinDemo;
					return;
				}
				this.lecteur.Bt_pauseEnabled = true;
				return;
			case Simulation.TypeDeDemo.pasAPas:
				if (this.numPhaseSuivante == this.actions.Count)
				{
					this.FinDemo(null, null);
					return;
				}
				this.executerPhase();
				if (!this.marcheArriere)
				{
					if (this.numPhaseSuivante != this.numPhasePrecedente)
					{
						this.phasesPrecedentes[this.numPhaseSuivante] = this.numPhasePrecedente;
					}
					if (this.tablesParcours[this.numPhaseSuivante] == null)
					{
						if (this.tablesModifiees)
						{
							this.tablesParcours[this.numPhaseSuivante] = this.getTables();
							this.tablesModifiees = false;
							return;
						}
						this.tablesParcours[this.numPhaseSuivante] = this.tablesParcours[this.numPhasePrecedente];
					}
				}
				return;
			default:
				return;
			}
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00010C50 File Offset: 0x0000FC50
		public void Lecture()
		{
			if (this.typeDemo == Simulation.TypeDeDemo.automatique)
			{
				this.lecteur.Bt_lectureEnabled = false;
				this.lecteur.Bt_pauseEnabled = true;
				this.attente.Tick += this.executerPhaseSuivante;
				this.attente.Start();
				return;
			}
			this.marcheArriere = false;
			this.executerPhaseSuivante(null, null);
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00010CB0 File Offset: 0x0000FCB0
		public void Pause()
		{
			this.lecteur.Bt_pauseEnabled = false;
			this.lecteur.Bt_lectureEnabled = true;
			this.attente.Tick -= this.executerPhaseSuivante;
			this.attente.Stop();
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00010CF8 File Offset: 0x0000FCF8
		public void Precedent()
		{
			this.marcheArriere = true;
			this.numPhaseSuivante = this.phasesPrecedentes[this.numPhasePrecedente];
			this.setTables(this.tablesParcours[this.numPhaseSuivante]);
			this.executerPhaseSuivante(null, null);
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00010D3C File Offset: 0x0000FD3C
		public void Rewind()
		{
			if (this.typeDemo == Simulation.TypeDeDemo.automatique)
			{
				this.attente.Tick -= this.FinDemo;
				this.attente.Tick -= this.executerPhaseSuivante;
				this.attente.Tick += this.executerPhaseSuivante;
				this.attente.Stop();
				this.attente.Start();
			}
			this.numPhaseSuivante = 0;
			this.setTables(this.tablesParcours[0]);
			this.init();
			this.executerPhaseSuivante(null, null);
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00010DD0 File Offset: 0x0000FDD0
		protected virtual void init()
		{
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00010DE0 File Offset: 0x0000FDE0
		public void FixerPosition()
		{
			Noeud noeud;
			if (this.elt.GetType() == typeof(CarteReseau))
			{
				noeud = ((CarteReseau)this.elt).NoeudAttache;
			}
			else
			{
				noeud = (Noeud)this.elt;
			}
			noeud.FixerPosition(base.Location.X, base.Location.Y);
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00010E48 File Offset: 0x0000FE48
		public void FinDemo(object sender, EventArgs e)
		{
			this.attente.Stop();
			if (this.DemoTerminee != null)
			{
				this.DemoTerminee(this.elt, null);
			}
			if (this.elt.Reseau.Pref.MemoriserPosDemo)
			{
				this.FixerPosition();
			}
			base.Close();
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00010EA0 File Offset: 0x0000FEA0
		protected virtual Point positionDemo()
		{
			return this.elt.posDialogueDemo();
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00010EB8 File Offset: 0x0000FEB8
		protected virtual void executerPhaseManuelle(int numPhaseManuelle)
		{
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00010EC8 File Offset: 0x0000FEC8
		public void DemarrerDemo(ElementReseau p_sender, ElementReseau p_elt, TrameEthernet p_trame, Simulation.TypeDeDemo p_typeDemo)
		{
			this.sender = p_sender;
			this.elt = p_elt;
			this.trame = p_trame;
			base.Location = this.elt.posDialogueDemo();
			this.demarrer(p_typeDemo);
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00010F04 File Offset: 0x0000FF04
		public void DemarrerDemo(ElementReseau p_elt, string p_adrIpToPing, Simulation.TypeDeDemo p_typeDemo)
		{
			this.adrIpToPing = p_adrIpToPing;
			this.elt = p_elt;
			base.Location = this.elt.posDialogueDemo();
			this.demarrer(p_typeDemo);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00010F38 File Offset: 0x0000FF38
		public void DemarrerDemo(ElementReseau p_elt, Ip_PaquetIp p_paquet, Simulation.TypeDeDemo p_typeDemo)
		{
			this.paquet = p_paquet;
			this.elt = p_elt;
			base.Location = this.elt.posDialogueDemo();
			this.demarrer(p_typeDemo);
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00010F6C File Offset: 0x0000FF6C
		public void DemarrerDemo(ElementReseau p_elt, string p_adrIpSource, string p_adrIpToPing, ProtocoleTrs p_protocole, int p_numPortDest, int p_numPortClient, Simulation.TypeDeDemo p_typeDemo)
		{
			this.adrIpToPing = p_adrIpToPing;
			this.adrIpSource = p_adrIpSource;
			this.protocoleTransport = p_protocole;
			this.numPortDest = p_numPortDest;
			this.numPortClient = p_numPortClient;
			this.elt = p_elt;
			base.Location = this.elt.posDialogueDemo();
			this.demarrer(p_typeDemo);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00010FC0 File Offset: 0x0000FFC0
		public void DemarrerDemo(ElementReseau p_elt, Trs_SegmentTrs p_segment, Ip_PaquetIp p_paquet, Simulation.TypeDeDemo p_typeDemo)
		{
			this.elt = p_elt;
			this.paquet = p_paquet;
			this.segment = new Trs_SegmentTrs(p_segment.StationSource, p_segment.Protocole, p_segment.AdrIpSource, p_segment.NumPortSource, p_segment.AdrIpDest, p_segment.NumPortDest);
			this.segment.MacArrivee = p_segment.MacArrivee;
			this.segment.StationSource = p_segment.StationSource;
			this.segment.NbSauts = p_segment.NbSauts;
			base.Location = this.elt.posDialogueDemo();
			this.demarrer(p_typeDemo);
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00011058 File Offset: 0x00010058
		private void demarrer(Simulation.TypeDeDemo p_typeDemo)
		{
			this.setInScreen();
			this.typeDemo = p_typeDemo;
			this.bt_continuer.Visible = false;
			switch (this.typeDemo)
			{
			case Simulation.TypeDeDemo.automatique:
				this.lecteur.Bt_pauseEnabled = true;
				this.lecteur.Bt_lectureEnabled = false;
				this.lecteur.Visible = true;
				this.tb_phase.Visible = true;
				this.cb_action.Visible = false;
				this.bt_stop.Visible = false;
				this.init();
				this.initTables(this.getTables());
				this.executerPhaseSuivante(null, null);
				this.attente.Tick += this.executerPhaseSuivante;
				break;
			case Simulation.TypeDeDemo.pasAPas:
				this.lecteur.ActionPause = BoutonPauseAction.precedent;
				this.lecteur.Bt_pauseEnabled = true;
				this.lecteur.Bt_lectureEnabled = true;
				this.lecteur.Visible = true;
				this.tb_phase.Visible = true;
				this.cb_action.Visible = false;
				this.bt_stop.Visible = false;
				this.init();
				this.initTables(this.getTables());
				this.executerPhaseSuivante(null, null);
				break;
			case Simulation.TypeDeDemo.manuel:
				this.cb_action.Visible = true;
				this.bt_stop.Visible = true;
				this.lecteur.Visible = false;
				this.tb_phase.Visible = false;
				this.initManuel();
				break;
			}
			base.Show();
		}

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x06000200 RID: 512 RVA: 0x000111C8 File Offset: 0x000101C8
		// (remove) Token: 0x06000201 RID: 513 RVA: 0x000111EC File Offset: 0x000101EC
		public event EventHandler DemoTerminee;

		// Token: 0x06000202 RID: 514 RVA: 0x00011210 File Offset: 0x00010210
		private void bt_stop_Click(object sender, EventArgs e)
		{
			this.FinDemo(null, null);
		}

		// Token: 0x06000203 RID: 515 RVA: 0x00011228 File Offset: 0x00010228
		private bool phasesAValiderValidees()
		{
			bool result = true;
			foreach (object obj in this.phasesAValider)
			{
				int num = (int)obj;
				if (!this.phasesOk[num])
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00011298 File Offset: 0x00010298
		protected virtual void initManuel()
		{
			this.phasesOk = new bool[this.nbPhasesManuelles];
			for (int i = 0; i < this.nbPhasesManuelles; i++)
			{
				this.phasesOk[i] = false;
			}
		}

		// Token: 0x06000205 RID: 517 RVA: 0x000112D0 File Offset: 0x000102D0
		protected void desactiverActionIndexChanged()
		{
			this.cb_action.SelectedIndexChanged -= this.cb_action_SelectedIndexChanged;
		}

		// Token: 0x06000206 RID: 518 RVA: 0x000112F4 File Offset: 0x000102F4
		protected void activerActionIndexChanged()
		{
			this.cb_action.SelectedIndexChanged += this.cb_action_SelectedIndexChanged;
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00011318 File Offset: 0x00010318
		private void cb_action_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.messageManuelFinOk = "Bravo !";
			this.messageManuelOk = "Bien ! Mais ce n'est pas terminé...";
			this.messageManuelErreur = "Erreur !";
			this.okManuel = false;
			this.executerPhaseManuelle(this.cb_action.SelectedIndex);
			if (!this.okManuel)
			{
				this.tb_resultat.ForeColor = Color.Red;
				this.tb_resultat.Text = this.messageManuelErreur;
				return;
			}
			this.tb_resultat.ForeColor = Color.Black;
			this.tb_resultat.Text = this.messageManuelOk;
			if (!this.phasesOk[this.cb_action.SelectedIndex])
			{
				this.phasesOk[this.cb_action.SelectedIndex] = true;
				if (this.phasesAValiderValidees())
				{
					this.tb_resultat.Text = this.messageManuelFinOk;
					this.cb_action.Visible = false;
					this.bt_stop.Visible = false;
					this.bt_continuer.Visible = true;
				}
			}
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00011410 File Offset: 0x00010410
		private void bt_continuer_Click(object sender, EventArgs e)
		{
			this.FinDemo(null, null);
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00011428 File Offset: 0x00010428
		private void DemoDialogue_Closed(object sender, EventArgs e)
		{
			this.simul.Activate();
			foreach (Form form in this.simul.OwnedForms)
			{
				if (form.GetType().BaseType.Equals(typeof(DemoDialogue)))
				{
					form.Activate();
				}
			}
		}

		// Token: 0x1700003D RID: 61
		// (set) Token: 0x0600020A RID: 522 RVA: 0x00011480 File Offset: 0x00010480
		public bool TablesModifiees
		{
			set
			{
				this.tablesModifiees = value;
			}
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00011494 File Offset: 0x00010494
		protected void initTables(ArrayList p_tables)
		{
			this.tablesParcours = new ArrayList[this.actions.Count + 1];
			this.phasesPrecedentes = new int[this.actions.Count + 1];
			if (p_tables != null)
			{
				this.nbTables = p_tables.Count;
				this.tablesParcours[0] = new ArrayList(this.nbTables);
				for (int i = 0; i < this.nbTables; i++)
				{
					this.tablesParcours[0].Add(((SortedList)p_tables[i]).Clone());
				}
			}
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00011524 File Offset: 0x00010524
		protected virtual ArrayList getTables()
		{
			return null;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00011534 File Offset: 0x00010534
		protected virtual void setTables(ArrayList p_tables)
		{
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600020E RID: 526 RVA: 0x00011544 File Offset: 0x00010544
		protected bool MarcheArriere
		{
			get
			{
				return this.marcheArriere;
			}
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00011558 File Offset: 0x00010558
		public void InScreen()
		{
			Dialogue.InScreen(this);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0001156C File Offset: 0x0001056C
		public void Abandonner()
		{
			this.bt_stop_Click(this, new EventArgs());
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00011588 File Offset: 0x00010588
		private void control_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\u001b')
			{
				this.Abandonner();
			}
		}

		// Token: 0x04000106 RID: 262
		private Form simul;

		// Token: 0x04000107 RID: 263
		private string titreDialogue;

		// Token: 0x04000108 RID: 264
		protected ArrayList actions;

		// Token: 0x0400010F RID: 271
		protected Timer attente = new Timer();

		// Token: 0x04000110 RID: 272
		protected int numPhaseSuivante = 0;

		// Token: 0x04000111 RID: 273
		protected int numPhasePrecedente = 0;

		// Token: 0x04000112 RID: 274
		protected Simulation.TypeDeDemo typeDemo;

		// Token: 0x04000113 RID: 275
		protected ElementReseau sender;

		// Token: 0x04000114 RID: 276
		protected string adrIpToPing;

		// Token: 0x04000115 RID: 277
		protected string adrIpSource;

		// Token: 0x04000116 RID: 278
		protected Ip_PaquetIp paquet;

		// Token: 0x04000117 RID: 279
		protected ProtocoleTrs protocoleTransport;

		// Token: 0x04000118 RID: 280
		protected int numPortDest;

		// Token: 0x04000119 RID: 281
		protected int numPortClient;

		// Token: 0x0400011A RID: 282
		protected Trs_SegmentTrs segment;

		// Token: 0x0400011C RID: 284
		protected ElementReseau elt;

		// Token: 0x0400011D RID: 285
		protected TrameEthernet trame;

		// Token: 0x0400011E RID: 286
		protected bool okManuel;

		// Token: 0x0400011F RID: 287
		protected ArrayList phasesAValider = new ArrayList();

		// Token: 0x04000120 RID: 288
		private bool[] phasesOk;

		// Token: 0x04000121 RID: 289
		protected string messageManuelOk;

		// Token: 0x04000122 RID: 290
		protected string messageManuelFinOk;

		// Token: 0x04000123 RID: 291
		protected string messageManuelErreur;

		// Token: 0x04000124 RID: 292
		protected int nbPhasesManuelles;

		// Token: 0x04000125 RID: 293
		private ArrayList[] tablesParcours;

		// Token: 0x04000126 RID: 294
		private int[] phasesPrecedentes;

		// Token: 0x04000127 RID: 295
		private int nbTables = 0;

		// Token: 0x04000128 RID: 296
		private bool tablesModifiees = false;

		// Token: 0x04000129 RID: 297
		private bool marcheArriere = false;
	}
}
