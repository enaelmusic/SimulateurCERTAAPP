using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200001C RID: 28
	public partial class DDialogPlus : Form
	{
		// Token: 0x060001C4 RID: 452 RVA: 0x0000F3A8 File Offset: 0x0000E3A8
		public DDialogPlus()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0000F3D4 File Offset: 0x0000E3D4
		public DDialogPlus(Form f)
		{
			this.InitializeComponent();
			base.Owner = f;
			this.simul = f;
			this.actions = new ArrayList();
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x0000F608 File Offset: 0x0000E608
		public TimerEtatTransition Attente
		{
			get
			{
				return this.attente;
			}
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0000F61C File Offset: 0x0000E61C
		public virtual void Arreter()
		{
			this.attente.Interval = 1;
			this.attente.TempsAttenteEvenement[0] = 0;
			for (int i = 1; i < this.attente.TempsAttenteEvenement.Count; i++)
			{
				this.attente.TempsAttenteEvenement[i] = 1;
			}
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060001CA RID: 458 RVA: 0x0000F680 File Offset: 0x0000E680
		// (remove) Token: 0x060001CB RID: 459 RVA: 0x0000F6A4 File Offset: 0x0000E6A4
		public event EventHandler DemoTerminee;

		// Token: 0x060001CC RID: 460 RVA: 0x0000F6C8 File Offset: 0x0000E6C8
		public virtual void FinDemo()
		{
			TimerEtatTransition timerEtatTransition = this.attente;
			timerEtatTransition.EvtEtatTransition = (EtatTransitionEventHandler)Delegate.Remove(timerEtatTransition.EvtEtatTransition, new EtatTransitionEventHandler(this.executerTransition));
			this.fin();
			this.attente.Stop();
			if (this.DemoTerminee != null)
			{
				this.DemoTerminee(null, null);
			}
			base.Close();
			try
			{
				base.Dispose();
			}
			catch
			{
			}
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000F750 File Offset: 0x0000E750
		protected Point positionDemo()
		{
			return this.eltRes.posDialogueDemo();
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000F768 File Offset: 0x0000E768
		protected virtual void init(bool p_afficher, bool p_attenteFin)
		{
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0000F778 File Offset: 0x0000E778
		protected virtual void fin()
		{
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0000F788 File Offset: 0x0000E788
		public void DemarrerDemo(ElementReseau p_eltRes, Point position, bool p_afficher, bool p_attenteFin)
		{
			this.eltRes = p_eltRes;
			base.Location = position;
			Dialogue.InScreen(this);
			this.tb_phase.Visible = true;
			this.init(p_afficher, p_attenteFin);
			if (p_afficher)
			{
				base.Show();
			}
			this.etat = -1;
			TimerEtatTransition timerEtatTransition = this.attente;
			timerEtatTransition.EvtEtatTransition = (EtatTransitionEventHandler)Delegate.Combine(timerEtatTransition.EvtEtatTransition, new EtatTransitionEventHandler(this.executerTransition));
			this.executerTransition(null, new EtatTransitionEventArgs(0));
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0000F804 File Offset: 0x0000E804
		protected virtual void executerTransition(object sender, EtatTransitionEventArgs e)
		{
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000F814 File Offset: 0x0000E814
		private void DDialogPlus_Closed(object sender, EventArgs e)
		{
			this.simul.Activate();
		}

		// Token: 0x040000E7 RID: 231
		private Form simul;

		// Token: 0x040000E8 RID: 232
		protected TimerEtatTransition attente = new TimerEtatTransition();

		// Token: 0x040000E9 RID: 233
		protected ArrayList actions;

		// Token: 0x040000EB RID: 235
		protected ElementReseau eltRes;

		// Token: 0x040000EC RID: 236
		protected int etat;
	}
}
