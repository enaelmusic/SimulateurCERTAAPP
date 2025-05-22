using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000025 RID: 37
	public partial class DemoHub : DemoDialogue
	{
		// Token: 0x0600024E RID: 590 RVA: 0x000166FC File Offset: 0x000156FC
		public DemoHub()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0001671C File Offset: 0x0001571C
		public DemoHub(Form f) : base(f)
		{
			this.InitializeComponent();
			base.Owner = f;
			this.actions = new ArrayList();
			this.actions.Add("Examiner le port d'origine");
			this.actions.Add("Répéter sur les autres ports");
			this.actions.Add("Fin de la démonstration");
			base.initTables(null);
		}

		// Token: 0x06000252 RID: 594 RVA: 0x00016C48 File Offset: 0x00015C48
		protected override void setInScreen()
		{
			Dialogue.InScreen(this);
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00016C5C File Offset: 0x00015C5C
		protected override void init()
		{
			this.tb_resultat.Text = "";
			this.tb_portReception.Text = ((PointConnexion)this.sender).NumeroOrdre.ToString();
			this.tb_emetteur.Text = this.trame.MacEmetteur;
			this.tb_destinataire.Text = this.trame.MacDestinataire;
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00016CC8 File Offset: 0x00015CC8
		protected override void executerPhase()
		{
			switch (this.numPhaseSuivante)
			{
			case 0:
				base.LibellePhase = "Sélection ports de réémission";
				this.tb_resultat.Text = "Port d'origine:" + this.tb_portReception.Text;
				this.numPhaseSuivante = 1;
				return;
			case 1:
				this.numPhaseSuivante = 2;
				this.tb_resultat.Text = "Ports actifs uniquement";
				return;
			case 2:
				this.numPhaseSuivante = 3;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00016D44 File Offset: 0x00015D44
		protected override void initManuel()
		{
			this.init();
			this.Text = "Hub : " + ((Hub)this.elt).NomNoeud;
			this.nbPhasesManuelles = 2;
			base.initManuel();
			this.cb_action.Items.Clear();
			this.cb_action.Items.Add("Sélectionner ports de réémission...");
			this.cb_action.Items.Add("Réémettre sur ports sélectionnés -->");
			this.phasesAValider.Add(1);
			foreach (object obj in ((Hub)this.elt).Controls)
			{
				PortHub portHub = (PortHub)obj;
				string item = string.Concat(new object[]
				{
					"Port n°",
					portHub.ToString(),
					" (",
					portHub.EtatConnexion,
					")"
				});
				this.lb_ports.Items.Add(item, false);
			}
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00016E80 File Offset: 0x00015E80
		protected override void executerPhaseManuelle(int numPhaseManuelle)
		{
			switch (numPhaseManuelle)
			{
			case 0:
				base.Size = new Size(230, 210);
				this.messageManuelOk = "Sélectionnez les ports...";
				this.okManuel = true;
				return;
			case 1:
				base.Size = new Size(230, 110);
				this.okManuel = true;
				this.messageManuelErreur = "Ports sélectionnés incorrects !";
				foreach (object obj in this.elt.Controls)
				{
					PortHub portHub = (PortHub)obj;
					if (portHub.EtatConnexion == PointConnexion.EtatsConnexion.actif && portHub.ToString() != this.tb_portReception.Text)
					{
						this.okManuel = (this.okManuel && this.lb_ports.GetItemChecked(portHub.NumeroOrdre - 1));
					}
					else
					{
						this.okManuel = (this.okManuel && !this.lb_ports.GetItemChecked(portHub.NumeroOrdre - 1));
					}
				}
				return;
			default:
				return;
			}
		}
	}
}
