namespace Simulateur
{
	// Token: 0x02000024 RID: 36
	public partial class DemoEnvoyerSegment : global::Simulateur.DemoDialogue
	{
		// Token: 0x0600023C RID: 572 RVA: 0x00013ACC File Offset: 0x00012ACC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00013AF8 File Offset: 0x00012AF8
		private void InitializeComponent()
		{
			this.tb_ipSource = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.routeEdit1 = new global::Simulateur.RouteEdit();
			this.reqTrsEditEnvoyees = new global::Simulateur.ReqTrsEdit();
			this.reglesFiltrageEdit1 = new global::Simulateur.ReglesFiltrageEdit();
			this.portsEcoutesEdit1 = new global::Simulateur.PortsEcoutesEdit();
			this.tb_ipDestination = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.tb_portSource = new global::System.Windows.Forms.TextBox();
			this.lbl_portSource = new global::System.Windows.Forms.Label();
			this.tb_portDest = new global::System.Windows.Forms.TextBox();
			this.lbl_portDest = new global::System.Windows.Forms.Label();
			this.tb_protocole = new global::System.Windows.Forms.TextBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.reqTrsEditRecues = new global::Simulateur.ReqTrsEdit();
			this.lbl_requetes = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.tb_carteDepart = new global::System.Windows.Forms.TextBox();
			this.gb_messageUtilisateur = new global::System.Windows.Forms.GroupBox();
			this.rb_accepte = new global::System.Windows.Forms.RadioButton();
			this.rb_refuse = new global::System.Windows.Forms.RadioButton();
			this.rb_adrIpIncorrecte = new global::System.Windows.Forms.RadioButton();
			this.rb_nonJoignable = new global::System.Windows.Forms.RadioButton();
			this.rb_filtre = new global::System.Windows.Forms.RadioButton();
			this.gb_messageUtilisateur.SuspendLayout();
			base.SuspendLayout();
			this.bt_continuer.Location = new global::System.Drawing.Point(236, 4);
			this.bt_continuer.Name = "bt_continuer";
			this.bt_stop.Name = "bt_stop";
			this.cb_action.Name = "cb_action";
			this.tb_phase.Name = "tb_phase";
			this.lecteur.Name = "lecteur";
			this.tb_resultat.Name = "tb_resultat";
			this.tb_resultat.Size = new global::System.Drawing.Size(308, 20);
			this.tb_ipSource.Location = new global::System.Drawing.Point(4, 76);
			this.tb_ipSource.Name = "tb_ipSource";
			this.tb_ipSource.ReadOnly = true;
			this.tb_ipSource.Size = new global::System.Drawing.Size(152, 20);
			this.tb_ipSource.TabIndex = 35;
			this.tb_ipSource.TabStop = false;
			this.tb_ipSource.Text = "";
			this.label2.Location = new global::System.Drawing.Point(4, 55);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(64, 20);
			this.label2.TabIndex = 36;
			this.label2.Text = "Ip source";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.routeEdit1.Location = new global::System.Drawing.Point(4, 148);
			this.routeEdit1.Name = "routeEdit1";
			this.routeEdit1.Size = new global::System.Drawing.Size(488, 80);
			this.routeEdit1.TabIndex = 38;
			this.reqTrsEditEnvoyees.Location = new global::System.Drawing.Point(4, 148);
			this.reqTrsEditEnvoyees.Name = "reqTrsEditEnvoyees";
			this.reqTrsEditEnvoyees.Size = new global::System.Drawing.Size(404, 80);
			this.reqTrsEditEnvoyees.TabIndex = 39;
			this.reglesFiltrageEdit1.Location = new global::System.Drawing.Point(4, 148);
			this.reglesFiltrageEdit1.Name = "reglesFiltrageEdit1";
			this.reglesFiltrageEdit1.Size = new global::System.Drawing.Size(580, 80);
			this.reglesFiltrageEdit1.TabIndex = 40;
			this.portsEcoutesEdit1.Location = new global::System.Drawing.Point(4, 148);
			this.portsEcoutesEdit1.Name = "portsEcoutesEdit1";
			this.portsEcoutesEdit1.Size = new global::System.Drawing.Size(220, 80);
			this.portsEcoutesEdit1.TabIndex = 41;
			this.tb_ipDestination.Location = new global::System.Drawing.Point(160, 76);
			this.tb_ipDestination.Name = "tb_ipDestination";
			this.tb_ipDestination.ReadOnly = true;
			this.tb_ipDestination.Size = new global::System.Drawing.Size(152, 20);
			this.tb_ipDestination.TabIndex = 42;
			this.tb_ipDestination.TabStop = false;
			this.tb_ipDestination.Text = "";
			this.label1.Location = new global::System.Drawing.Point(160, 56);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(104, 20);
			this.label1.TabIndex = 43;
			this.label1.Text = "Ip destination";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_portSource.Location = new global::System.Drawing.Point(72, 120);
			this.tb_portSource.Name = "tb_portSource";
			this.tb_portSource.ReadOnly = true;
			this.tb_portSource.Size = new global::System.Drawing.Size(64, 20);
			this.tb_portSource.TabIndex = 44;
			this.tb_portSource.TabStop = false;
			this.tb_portSource.Text = "";
			this.lbl_portSource.Location = new global::System.Drawing.Point(72, 100);
			this.lbl_portSource.Name = "lbl_portSource";
			this.lbl_portSource.Size = new global::System.Drawing.Size(64, 20);
			this.lbl_portSource.TabIndex = 45;
			this.lbl_portSource.Text = "Port source";
			this.lbl_portSource.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_portDest.Location = new global::System.Drawing.Point(140, 120);
			this.tb_portDest.Name = "tb_portDest";
			this.tb_portDest.ReadOnly = true;
			this.tb_portDest.Size = new global::System.Drawing.Size(64, 20);
			this.tb_portDest.TabIndex = 46;
			this.tb_portDest.TabStop = false;
			this.tb_portDest.Text = "";
			this.lbl_portDest.Location = new global::System.Drawing.Point(140, 100);
			this.lbl_portDest.Name = "lbl_portDest";
			this.lbl_portDest.Size = new global::System.Drawing.Size(64, 20);
			this.lbl_portDest.TabIndex = 47;
			this.lbl_portDest.Text = "Port dest.";
			this.lbl_portDest.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_protocole.Location = new global::System.Drawing.Point(4, 120);
			this.tb_protocole.Name = "tb_protocole";
			this.tb_protocole.ReadOnly = true;
			this.tb_protocole.Size = new global::System.Drawing.Size(64, 20);
			this.tb_protocole.TabIndex = 48;
			this.tb_protocole.TabStop = false;
			this.tb_protocole.Text = "";
			this.label5.Location = new global::System.Drawing.Point(4, 100);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(64, 20);
			this.label5.TabIndex = 49;
			this.label5.Text = "Protocole";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.reqTrsEditRecues.Location = new global::System.Drawing.Point(4, 148);
			this.reqTrsEditRecues.Name = "reqTrsEditRecues";
			this.reqTrsEditRecues.Size = new global::System.Drawing.Size(404, 80);
			this.reqTrsEditRecues.TabIndex = 50;
			this.lbl_requetes.Location = new global::System.Drawing.Point(284, 124);
			this.lbl_requetes.Name = "lbl_requetes";
			this.lbl_requetes.Size = new global::System.Drawing.Size(104, 16);
			this.lbl_requetes.TabIndex = 51;
			this.lbl_requetes.Text = "Requêtes envoyées";
			this.lbl_requetes.Visible = false;
			this.label7.Location = new global::System.Drawing.Point(212, 100);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(56, 20);
			this.label7.TabIndex = 55;
			this.label7.Text = "Int. départ";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_carteDepart.Location = new global::System.Drawing.Point(208, 120);
			this.tb_carteDepart.Name = "tb_carteDepart";
			this.tb_carteDepart.ReadOnly = true;
			this.tb_carteDepart.Size = new global::System.Drawing.Size(58, 20);
			this.tb_carteDepart.TabIndex = 54;
			this.tb_carteDepart.TabStop = false;
			this.tb_carteDepart.Text = "";
			this.gb_messageUtilisateur.Controls.Add(this.rb_accepte);
			this.gb_messageUtilisateur.Controls.Add(this.rb_refuse);
			this.gb_messageUtilisateur.Controls.Add(this.rb_adrIpIncorrecte);
			this.gb_messageUtilisateur.Controls.Add(this.rb_nonJoignable);
			this.gb_messageUtilisateur.Controls.Add(this.rb_filtre);
			this.gb_messageUtilisateur.Location = new global::System.Drawing.Point(4, 148);
			this.gb_messageUtilisateur.Name = "gb_messageUtilisateur";
			this.gb_messageUtilisateur.Size = new global::System.Drawing.Size(288, 76);
			this.gb_messageUtilisateur.TabIndex = 56;
			this.gb_messageUtilisateur.TabStop = false;
			this.rb_accepte.Location = new global::System.Drawing.Point(152, 36);
			this.rb_accepte.Name = "rb_accepte";
			this.rb_accepte.Size = new global::System.Drawing.Size(130, 20);
			this.rb_accepte.TabIndex = 4;
			this.rb_accepte.Text = "l'envoi a été accepté";
			this.rb_refuse.Location = new global::System.Drawing.Point(152, 16);
			this.rb_refuse.Name = "rb_refuse";
			this.rb_refuse.Size = new global::System.Drawing.Size(130, 20);
			this.rb_refuse.TabIndex = 3;
			this.rb_refuse.Text = "l'envoi a été refusé";
			this.rb_adrIpIncorrecte.Location = new global::System.Drawing.Point(18, 32);
			this.rb_adrIpIncorrecte.Name = "rb_adrIpIncorrecte";
			this.rb_adrIpIncorrecte.Size = new global::System.Drawing.Size(130, 20);
			this.rb_adrIpIncorrecte.TabIndex = 2;
			this.rb_adrIpIncorrecte.Text = "adresse IP incorrecte";
			this.rb_nonJoignable.Location = new global::System.Drawing.Point(18, 12);
			this.rb_nonJoignable.Name = "rb_nonJoignable";
			this.rb_nonJoignable.Size = new global::System.Drawing.Size(130, 20);
			this.rb_nonJoignable.TabIndex = 1;
			this.rb_nonJoignable.Text = "hôte non joignable";
			this.rb_filtre.Location = new global::System.Drawing.Point(18, 52);
			this.rb_filtre.Name = "rb_filtre";
			this.rb_filtre.Size = new global::System.Drawing.Size(130, 20);
			this.rb_filtre.TabIndex = 0;
			this.rb_filtre.Text = "l'envoi a été filtré";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(318, 231);
			base.Controls.Add(this.gb_messageUtilisateur);
			base.Controls.Add(this.reqTrsEditRecues);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.tb_carteDepart);
			base.Controls.Add(this.lbl_requetes);
			base.Controls.Add(this.tb_protocole);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.tb_portDest);
			base.Controls.Add(this.lbl_portDest);
			base.Controls.Add(this.tb_portSource);
			base.Controls.Add(this.lbl_portSource);
			base.Controls.Add(this.tb_ipDestination);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.tb_ipSource);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.reqTrsEditEnvoyees);
			base.Controls.Add(this.routeEdit1);
			base.Controls.Add(this.portsEcoutesEdit1);
			base.Controls.Add(this.reglesFiltrageEdit1);
			base.Name = "DemoEnvoyerSegment";
			base.Controls.SetChildIndex(this.reglesFiltrageEdit1, 0);
			base.Controls.SetChildIndex(this.portsEcoutesEdit1, 0);
			base.Controls.SetChildIndex(this.routeEdit1, 0);
			base.Controls.SetChildIndex(this.reqTrsEditEnvoyees, 0);
			base.Controls.SetChildIndex(this.tb_phase, 0);
			base.Controls.SetChildIndex(this.lecteur, 0);
			base.Controls.SetChildIndex(this.tb_resultat, 0);
			base.Controls.SetChildIndex(this.cb_action, 0);
			base.Controls.SetChildIndex(this.bt_stop, 0);
			base.Controls.SetChildIndex(this.bt_continuer, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.tb_ipSource, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.tb_ipDestination, 0);
			base.Controls.SetChildIndex(this.lbl_portSource, 0);
			base.Controls.SetChildIndex(this.tb_portSource, 0);
			base.Controls.SetChildIndex(this.lbl_portDest, 0);
			base.Controls.SetChildIndex(this.tb_portDest, 0);
			base.Controls.SetChildIndex(this.label5, 0);
			base.Controls.SetChildIndex(this.tb_protocole, 0);
			base.Controls.SetChildIndex(this.lbl_requetes, 0);
			base.Controls.SetChildIndex(this.tb_carteDepart, 0);
			base.Controls.SetChildIndex(this.label7, 0);
			base.Controls.SetChildIndex(this.reqTrsEditRecues, 0);
			base.Controls.SetChildIndex(this.gb_messageUtilisateur, 0);
			this.gb_messageUtilisateur.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400014B RID: 331
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400014C RID: 332
		private global::Simulateur.RouteEdit routeEdit1;

		// Token: 0x0400014D RID: 333
		private global::Simulateur.ReglesFiltrageEdit reglesFiltrageEdit1;

		// Token: 0x0400014E RID: 334
		private global::Simulateur.PortsEcoutesEdit portsEcoutesEdit1;

		// Token: 0x0400014F RID: 335
		protected global::System.Windows.Forms.TextBox tb_ipSource;

		// Token: 0x04000150 RID: 336
		protected global::System.Windows.Forms.TextBox tb_ipDestination;

		// Token: 0x04000151 RID: 337
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000152 RID: 338
		protected global::System.Windows.Forms.TextBox tb_portSource;

		// Token: 0x04000153 RID: 339
		protected global::System.Windows.Forms.TextBox tb_portDest;

		// Token: 0x04000154 RID: 340
		protected global::System.Windows.Forms.TextBox tb_protocole;

		// Token: 0x04000155 RID: 341
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000156 RID: 342
		private global::Simulateur.ReqTrsEdit reqTrsEditEnvoyees;

		// Token: 0x04000157 RID: 343
		private global::Simulateur.ReqTrsEdit reqTrsEditRecues;

		// Token: 0x04000158 RID: 344
		private global::System.Windows.Forms.Label lbl_requetes;

		// Token: 0x04000159 RID: 345
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400015A RID: 346
		protected global::System.Windows.Forms.TextBox tb_carteDepart;

		// Token: 0x0400015B RID: 347
		private global::System.Windows.Forms.GroupBox gb_messageUtilisateur;

		// Token: 0x0400015C RID: 348
		private global::System.Windows.Forms.RadioButton rb_adrIpIncorrecte;

		// Token: 0x0400015D RID: 349
		private global::System.Windows.Forms.RadioButton rb_nonJoignable;

		// Token: 0x0400015E RID: 350
		private global::System.Windows.Forms.RadioButton rb_filtre;

		// Token: 0x0400015F RID: 351
		private global::System.Windows.Forms.RadioButton rb_refuse;

		// Token: 0x04000160 RID: 352
		private global::System.Windows.Forms.RadioButton rb_accepte;

		// Token: 0x04000161 RID: 353
		private global::System.Windows.Forms.Label lbl_portSource;

		// Token: 0x04000162 RID: 354
		private global::System.Windows.Forms.Label lbl_portDest;

		// Token: 0x04000163 RID: 355
		private global::System.ComponentModel.IContainer components = null;
	}
}
