using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000023 RID: 35
	public partial class DemoEchecPing : DemoDialogue
	{
		// Token: 0x06000233 RID: 563 RVA: 0x000134E8 File Offset: 0x000124E8
		public DemoEchecPing()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00013508 File Offset: 0x00012508
		public DemoEchecPing(Form f) : base(f)
		{
			this.InitializeComponent();
			base.Owner = f;
			this.actions = new ArrayList();
			this.actions.Add("Afficher message échec");
			this.actions.Add("Fin de la démonstration");
		}

		// Token: 0x06000237 RID: 567 RVA: 0x000138A8 File Offset: 0x000128A8
		protected override void setInScreen()
		{
			Dialogue.InScreen(this);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x000138BC File Offset: 0x000128BC
		protected override void executerPhase()
		{
			switch (this.numPhaseSuivante)
			{
			case 0:
				base.LibellePhase = "Affichage message utilisateur";
				this.tb_resultat.Text = "Afficher 'Délai d'attente dépassé'";
				this.numPhaseSuivante = 1;
				return;
			case 1:
				this.numPhaseSuivante = 2;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0001390C File Offset: 0x0001290C
		protected override void initManuel()
		{
			this.Text = "Station : " + ((Station)this.elt).NomNoeud;
			this.nbPhasesManuelles = 2;
			base.initManuel();
			this.cb_action.Items.Clear();
			this.cb_action.Items.Add("Préparer un message utilisateur...");
			this.cb_action.Items.Add("Afficher le message préparé -->");
			this.phasesAValider.Add(1);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00013994 File Offset: 0x00012994
		protected override void executerPhaseManuelle(int numPhaseManuelle)
		{
			this.gb_messageUtilisateur.Visible = false;
			base.Size = new Size(228, 84);
			this.messageManuelErreur = "Regardez bien le destinataire !";
			switch (numPhaseManuelle)
			{
			case 0:
				this.gb_messageUtilisateur.Visible = true;
				base.Size = new Size(228, 147);
				this.messageManuelOk = "Choisissez le message...";
				this.okManuel = true;
				return;
			case 1:
				this.messageManuelErreur = "Message utilisateur incorrect !";
				this.okManuel = this.rb_delaiDepasse.Checked;
				return;
			default:
				return;
			}
		}
	}
}
