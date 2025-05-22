using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000022 RID: 34
	public partial class DemoCarteReseau : DemoDialogue
	{
		// Token: 0x0600022B RID: 555 RVA: 0x00012F30 File Offset: 0x00011F30
		public DemoCarteReseau()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00012F50 File Offset: 0x00011F50
		public DemoCarteReseau(Form f) : base(f)
		{
			this.InitializeComponent();
			base.Owner = f;
			this.actions = new ArrayList();
			this.actions.Add("Examiner le destinataire");
			this.actions.Add("Traiter la trame");
			this.actions.Add("Ignorer la trame");
			this.actions.Add("Fin de la démonstration");
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00013224 File Offset: 0x00012224
		protected override void init()
		{
			this.tb_destinataire.Text = this.trame.MacDestinataire;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00013248 File Offset: 0x00012248
		protected override void executerPhase()
		{
			switch (this.numPhaseSuivante)
			{
			case 0:
				base.LibellePhase = "Réception d'une trame";
				this.tb_resultat.Text = "Destinataire:" + this.trame.MacDestinataire;
				if (this.trame.MacDestinataire == ((CarteReseau)this.elt).AdresseMac || this.trame.MacDestinataire == ((Simulation)base.Owner).Pref.AdrMacBroadcast)
				{
					this.numPhaseSuivante = 1;
					return;
				}
				this.numPhaseSuivante = 2;
				return;
			case 1:
				this.tb_resultat.Text = "Transmettre à la couche concernée";
				this.numPhaseSuivante = 3;
				return;
			case 2:
				this.tb_resultat.Text = "Cette trame n'est pas pour moi !";
				this.numPhaseSuivante = 3;
				return;
			case 3:
				this.numPhaseSuivante = 4;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00013330 File Offset: 0x00012330
		protected override void initManuel()
		{
			this.init();
			this.Text = "Carte : " + ((CarteReseau)this.elt).AdresseMac;
			this.nbPhasesManuelles = 2;
			base.initManuel();
			this.cb_action.Items.Clear();
			this.cb_action.Items.Add("Traiter la trame -->");
			this.cb_action.Items.Add("Ignorer la trame -->");
			if (this.trame.MacDestinataire == ((CarteReseau)this.elt).AdresseMac || this.trame.MacDestinataire == ((Simulation)base.Owner).Pref.AdrMacBroadcast)
			{
				this.phasesAValider.Add(0);
				return;
			}
			this.phasesAValider.Add(1);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0001341C File Offset: 0x0001241C
		protected override void executerPhaseManuelle(int numPhaseManuelle)
		{
			this.messageManuelErreur = "Regardez bien le destinataire !";
			switch (numPhaseManuelle)
			{
			case 0:
				this.okManuel = (this.trame.MacDestinataire == ((CarteReseau)this.elt).AdresseMac || this.trame.MacDestinataire == ((Simulation)base.Owner).Pref.AdrMacBroadcast);
				return;
			case 1:
				this.okManuel = (this.trame.MacDestinataire != ((CarteReseau)this.elt).AdresseMac && this.trame.MacDestinataire != ((Simulation)base.Owner).Pref.AdrMacBroadcast);
				return;
			default:
				return;
			}
		}
	}
}
