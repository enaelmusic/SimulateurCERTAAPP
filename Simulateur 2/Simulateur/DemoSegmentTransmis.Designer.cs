namespace Simulateur
{
	// Token: 0x02000028 RID: 40
	public partial class DemoSegmentTransmis : global::Simulateur.DemoDialogue
	{
		// Token: 0x06000290 RID: 656 RVA: 0x0001DCA4 File Offset: 0x0001CCA4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0001DCD0 File Offset: 0x0001CCD0
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
			this.natPatEdit1 = new global::Simulateur.NatPatEdit();
			this.tb_carteArrivee = new global::System.Windows.Forms.TextBox();
			this.tb_carteDepart = new global::System.Windows.Forms.TextBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.reqTrsEditRecues = new global::Simulateur.ReqTrsEdit();
			this.lbl_requetes = new global::System.Windows.Forms.Label();
			this.gb_messageUtilisateur = new global::System.Windows.Forms.GroupBox();
			this.rb_ttlEpuise = new global::System.Windows.Forms.RadioButton();
			this.rb_accepte = new global::System.Windows.Forms.RadioButton();
			this.rb_refuse = new global::System.Windows.Forms.RadioButton();
			this.rb_routageInactif = new global::System.Windows.Forms.RadioButton();
			this.rb_nonJoignable = new global::System.Windows.Forms.RadioButton();
			this.rb_filtre = new global::System.Windows.Forms.RadioButton();
			this.pn_configIp = new global::System.Windows.Forms.Panel();
			this.cb_activerNatPat = new global::System.Windows.Forms.CheckBox();
			this.cb_activerRoutage = new global::System.Windows.Forms.CheckBox();
			this.tb_nomHote = new global::System.Windows.Forms.TextBox();
			this.label13 = new global::System.Windows.Forms.Label();
			this.lb_interface = new global::System.Windows.Forms.ListBox();
			this.tb_passerelle = new global::System.Windows.Forms.TextBox();
			this.label14 = new global::System.Windows.Forms.Label();
			this.pn_nouveauSegment = new global::System.Windows.Forms.Panel();
			this.tb_newPortDest = new global::System.Windows.Forms.TextBox();
			this.tb_newIpDest = new global::System.Windows.Forms.TextBox();
			this.lbl_newDest = new global::System.Windows.Forms.Label();
			this.tb_newPortSource = new global::System.Windows.Forms.TextBox();
			this.tb_newIpSource = new global::System.Windows.Forms.TextBox();
			this.lbl_newSource = new global::System.Windows.Forms.Label();
			this.gb_messageUtilisateur.SuspendLayout();
			this.pn_configIp.SuspendLayout();
			this.pn_nouveauSegment.SuspendLayout();
			base.SuspendLayout();
			this.bt_continuer.Location = new global::System.Drawing.Point(236, 4);
			this.bt_continuer.Name = "bt_continuer";
			this.bt_stop.Name = "bt_stop";
			this.cb_action.MaxDropDownItems = 12;
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
			this.tb_portSource.Location = new global::System.Drawing.Point(64, 120);
			this.tb_portSource.Name = "tb_portSource";
			this.tb_portSource.ReadOnly = true;
			this.tb_portSource.Size = new global::System.Drawing.Size(58, 20);
			this.tb_portSource.TabIndex = 44;
			this.tb_portSource.TabStop = false;
			this.tb_portSource.Text = "";
			this.lbl_portSource.Location = new global::System.Drawing.Point(64, 100);
			this.lbl_portSource.Name = "lbl_portSource";
			this.lbl_portSource.Size = new global::System.Drawing.Size(64, 20);
			this.lbl_portSource.TabIndex = 45;
			this.lbl_portSource.Text = "Port source";
			this.lbl_portSource.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_portDest.Location = new global::System.Drawing.Point(124, 120);
			this.tb_portDest.Name = "tb_portDest";
			this.tb_portDest.ReadOnly = true;
			this.tb_portDest.Size = new global::System.Drawing.Size(58, 20);
			this.tb_portDest.TabIndex = 46;
			this.tb_portDest.TabStop = false;
			this.tb_portDest.Text = "";
			this.lbl_portDest.Location = new global::System.Drawing.Point(128, 100);
			this.lbl_portDest.Name = "lbl_portDest";
			this.lbl_portDest.Size = new global::System.Drawing.Size(56, 20);
			this.lbl_portDest.TabIndex = 47;
			this.lbl_portDest.Text = "Port dest.";
			this.lbl_portDest.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_protocole.Location = new global::System.Drawing.Point(4, 120);
			this.tb_protocole.Name = "tb_protocole";
			this.tb_protocole.ReadOnly = true;
			this.tb_protocole.Size = new global::System.Drawing.Size(58, 20);
			this.tb_protocole.TabIndex = 48;
			this.tb_protocole.TabStop = false;
			this.tb_protocole.Text = "";
			this.label5.Location = new global::System.Drawing.Point(4, 100);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(52, 20);
			this.label5.TabIndex = 49;
			this.label5.Text = "Protocole";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.natPatEdit1.Location = new global::System.Drawing.Point(4, 148);
			this.natPatEdit1.Name = "natPatEdit1";
			this.natPatEdit1.Size = new global::System.Drawing.Size(468, 80);
			this.natPatEdit1.TabIndex = 50;
			this.tb_carteArrivee.Location = new global::System.Drawing.Point(188, 120);
			this.tb_carteArrivee.Name = "tb_carteArrivee";
			this.tb_carteArrivee.ReadOnly = true;
			this.tb_carteArrivee.Size = new global::System.Drawing.Size(58, 20);
			this.tb_carteArrivee.TabIndex = 51;
			this.tb_carteArrivee.TabStop = false;
			this.tb_carteArrivee.Text = "";
			this.tb_carteDepart.Location = new global::System.Drawing.Point(252, 120);
			this.tb_carteDepart.Name = "tb_carteDepart";
			this.tb_carteDepart.ReadOnly = true;
			this.tb_carteDepart.Size = new global::System.Drawing.Size(58, 20);
			this.tb_carteDepart.TabIndex = 52;
			this.tb_carteDepart.TabStop = false;
			this.tb_carteDepart.Text = "";
			this.label7.Location = new global::System.Drawing.Point(256, 100);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(56, 20);
			this.label7.TabIndex = 53;
			this.label7.Text = "Int. départ";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label6.Location = new global::System.Drawing.Point(188, 100);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(60, 20);
			this.label6.TabIndex = 54;
			this.label6.Text = "Int. arrivée";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.reqTrsEditRecues.Location = new global::System.Drawing.Point(4, 148);
			this.reqTrsEditRecues.Name = "reqTrsEditRecues";
			this.reqTrsEditRecues.Size = new global::System.Drawing.Size(404, 80);
			this.reqTrsEditRecues.TabIndex = 55;
			this.lbl_requetes.Location = new global::System.Drawing.Point(316, 124);
			this.lbl_requetes.Name = "lbl_requetes";
			this.lbl_requetes.Size = new global::System.Drawing.Size(172, 16);
			this.lbl_requetes.TabIndex = 56;
			this.lbl_requetes.Text = "Req. Envoyées";
			this.lbl_requetes.Visible = false;
			this.gb_messageUtilisateur.Controls.Add(this.rb_ttlEpuise);
			this.gb_messageUtilisateur.Controls.Add(this.rb_accepte);
			this.gb_messageUtilisateur.Controls.Add(this.rb_refuse);
			this.gb_messageUtilisateur.Controls.Add(this.rb_routageInactif);
			this.gb_messageUtilisateur.Controls.Add(this.rb_nonJoignable);
			this.gb_messageUtilisateur.Controls.Add(this.rb_filtre);
			this.gb_messageUtilisateur.Location = new global::System.Drawing.Point(4, 148);
			this.gb_messageUtilisateur.Name = "gb_messageUtilisateur";
			this.gb_messageUtilisateur.Size = new global::System.Drawing.Size(308, 76);
			this.gb_messageUtilisateur.TabIndex = 58;
			this.gb_messageUtilisateur.TabStop = false;
			this.gb_messageUtilisateur.Visible = false;
			this.rb_ttlEpuise.Location = new global::System.Drawing.Point(156, 32);
			this.rb_ttlEpuise.Name = "rb_ttlEpuise";
			this.rb_ttlEpuise.Size = new global::System.Drawing.Size(136, 20);
			this.rb_ttlEpuise.TabIndex = 5;
			this.rb_ttlEpuise.Tag = "";
			this.rb_ttlEpuise.Text = "TTL du paquet épuisé";
			this.rb_accepte.Location = new global::System.Drawing.Point(156, 52);
			this.rb_accepte.Name = "rb_accepte";
			this.rb_accepte.Size = new global::System.Drawing.Size(136, 20);
			this.rb_accepte.TabIndex = 6;
			this.rb_accepte.Text = "l'envoi a été accepté";
			this.rb_refuse.Location = new global::System.Drawing.Point(16, 52);
			this.rb_refuse.Name = "rb_refuse";
			this.rb_refuse.Size = new global::System.Drawing.Size(130, 20);
			this.rb_refuse.TabIndex = 3;
			this.rb_refuse.Tag = "";
			this.rb_refuse.Text = "l'envoi a été refusé";
			this.rb_routageInactif.Location = new global::System.Drawing.Point(156, 12);
			this.rb_routageInactif.Name = "rb_routageInactif";
			this.rb_routageInactif.Size = new global::System.Drawing.Size(136, 20);
			this.rb_routageInactif.TabIndex = 4;
			this.rb_routageInactif.Tag = "";
			this.rb_routageInactif.Text = "routage inactif";
			this.rb_nonJoignable.Location = new global::System.Drawing.Point(16, 12);
			this.rb_nonJoignable.Name = "rb_nonJoignable";
			this.rb_nonJoignable.Size = new global::System.Drawing.Size(130, 20);
			this.rb_nonJoignable.TabIndex = 1;
			this.rb_nonJoignable.Tag = "";
			this.rb_nonJoignable.Text = "hôte non joignable";
			this.rb_filtre.Location = new global::System.Drawing.Point(16, 32);
			this.rb_filtre.Name = "rb_filtre";
			this.rb_filtre.Size = new global::System.Drawing.Size(130, 20);
			this.rb_filtre.TabIndex = 2;
			this.rb_filtre.Tag = "";
			this.rb_filtre.Text = "l'envoi a été filtré";
			this.pn_configIp.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pn_configIp.Controls.Add(this.cb_activerNatPat);
			this.pn_configIp.Controls.Add(this.cb_activerRoutage);
			this.pn_configIp.Controls.Add(this.tb_nomHote);
			this.pn_configIp.Controls.Add(this.label13);
			this.pn_configIp.Controls.Add(this.lb_interface);
			this.pn_configIp.Controls.Add(this.tb_passerelle);
			this.pn_configIp.Controls.Add(this.label14);
			this.pn_configIp.Location = new global::System.Drawing.Point(4, 148);
			this.pn_configIp.Name = "pn_configIp";
			this.pn_configIp.Size = new global::System.Drawing.Size(464, 76);
			this.pn_configIp.TabIndex = 59;
			this.cb_activerNatPat.Enabled = false;
			this.cb_activerNatPat.Location = new global::System.Drawing.Point(104, 52);
			this.cb_activerNatPat.Name = "cb_activerNatPat";
			this.cb_activerNatPat.Size = new global::System.Drawing.Size(92, 16);
			this.cb_activerNatPat.TabIndex = 35;
			this.cb_activerNatPat.Text = "natPat actif";
			this.cb_activerRoutage.Enabled = false;
			this.cb_activerRoutage.Location = new global::System.Drawing.Point(12, 52);
			this.cb_activerRoutage.Name = "cb_activerRoutage";
			this.cb_activerRoutage.Size = new global::System.Drawing.Size(88, 16);
			this.cb_activerRoutage.TabIndex = 34;
			this.cb_activerRoutage.Text = "routage actif";
			this.tb_nomHote.Enabled = false;
			this.tb_nomHote.Location = new global::System.Drawing.Point(80, 4);
			this.tb_nomHote.Name = "tb_nomHote";
			this.tb_nomHote.Size = new global::System.Drawing.Size(136, 20);
			this.tb_nomHote.TabIndex = 32;
			this.tb_nomHote.Text = "";
			this.label13.Location = new global::System.Drawing.Point(0, 4);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(79, 23);
			this.label13.TabIndex = 33;
			this.label13.Text = "Nom d'hôte :";
			this.label13.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.lb_interface.Enabled = false;
			this.lb_interface.Location = new global::System.Drawing.Point(220, 4);
			this.lb_interface.Name = "lb_interface";
			this.lb_interface.Size = new global::System.Drawing.Size(240, 69);
			this.lb_interface.TabIndex = 30;
			this.tb_passerelle.Enabled = false;
			this.tb_passerelle.Location = new global::System.Drawing.Point(80, 28);
			this.tb_passerelle.Name = "tb_passerelle";
			this.tb_passerelle.Size = new global::System.Drawing.Size(136, 20);
			this.tb_passerelle.TabIndex = 29;
			this.tb_passerelle.Text = "";
			this.label14.Location = new global::System.Drawing.Point(0, 28);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(63, 23);
			this.label14.TabIndex = 28;
			this.label14.Text = "Passerelle :";
			this.label14.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.pn_nouveauSegment.Controls.Add(this.tb_newPortDest);
			this.pn_nouveauSegment.Controls.Add(this.tb_newIpDest);
			this.pn_nouveauSegment.Controls.Add(this.lbl_newDest);
			this.pn_nouveauSegment.Controls.Add(this.tb_newPortSource);
			this.pn_nouveauSegment.Controls.Add(this.tb_newIpSource);
			this.pn_nouveauSegment.Controls.Add(this.lbl_newSource);
			this.pn_nouveauSegment.Location = new global::System.Drawing.Point(4, 148);
			this.pn_nouveauSegment.Name = "pn_nouveauSegment";
			this.pn_nouveauSegment.Size = new global::System.Drawing.Size(310, 62);
			this.pn_nouveauSegment.TabIndex = 60;
			this.tb_newPortDest.Location = new global::System.Drawing.Point(248, 36);
			this.tb_newPortDest.Name = "tb_newPortDest";
			this.tb_newPortDest.Size = new global::System.Drawing.Size(58, 20);
			this.tb_newPortDest.TabIndex = 50;
			this.tb_newPortDest.Text = "";
			this.tb_newIpDest.Location = new global::System.Drawing.Point(120, 36);
			this.tb_newIpDest.Name = "tb_newIpDest";
			this.tb_newIpDest.Size = new global::System.Drawing.Size(120, 20);
			this.tb_newIpDest.TabIndex = 49;
			this.tb_newIpDest.Text = "";
			this.lbl_newDest.Location = new global::System.Drawing.Point(8, 36);
			this.lbl_newDest.Name = "lbl_newDest";
			this.lbl_newDest.Size = new global::System.Drawing.Size(112, 20);
			this.lbl_newDest.TabIndex = 53;
			this.lbl_newDest.Text = "Destination (IP / Port)";
			this.lbl_newDest.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_newPortSource.Location = new global::System.Drawing.Point(248, 8);
			this.tb_newPortSource.Name = "tb_newPortSource";
			this.tb_newPortSource.Size = new global::System.Drawing.Size(58, 20);
			this.tb_newPortSource.TabIndex = 48;
			this.tb_newPortSource.Text = "";
			this.tb_newIpSource.Location = new global::System.Drawing.Point(120, 8);
			this.tb_newIpSource.Name = "tb_newIpSource";
			this.tb_newIpSource.Size = new global::System.Drawing.Size(120, 20);
			this.tb_newIpSource.TabIndex = 47;
			this.tb_newIpSource.Text = "";
			this.lbl_newSource.Location = new global::System.Drawing.Point(8, 8);
			this.lbl_newSource.Name = "lbl_newSource";
			this.lbl_newSource.Size = new global::System.Drawing.Size(108, 20);
			this.lbl_newSource.TabIndex = 48;
			this.lbl_newSource.Text = "Source (IP / Port)";
			this.lbl_newSource.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(502, 275);
			base.Controls.Add(this.pn_nouveauSegment);
			base.Controls.Add(this.pn_configIp);
			base.Controls.Add(this.gb_messageUtilisateur);
			base.Controls.Add(this.lbl_requetes);
			base.Controls.Add(this.reqTrsEditRecues);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.tb_carteDepart);
			base.Controls.Add(this.tb_carteArrivee);
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
			base.Controls.Add(this.natPatEdit1);
			base.Controls.Add(this.routeEdit1);
			base.Controls.Add(this.reglesFiltrageEdit1);
			base.Controls.Add(this.portsEcoutesEdit1);
			base.Name = "DemoSegmentTransmis";
			base.Controls.SetChildIndex(this.portsEcoutesEdit1, 0);
			base.Controls.SetChildIndex(this.reglesFiltrageEdit1, 0);
			base.Controls.SetChildIndex(this.routeEdit1, 0);
			base.Controls.SetChildIndex(this.natPatEdit1, 0);
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
			base.Controls.SetChildIndex(this.tb_carteArrivee, 0);
			base.Controls.SetChildIndex(this.tb_carteDepart, 0);
			base.Controls.SetChildIndex(this.label7, 0);
			base.Controls.SetChildIndex(this.label6, 0);
			base.Controls.SetChildIndex(this.reqTrsEditRecues, 0);
			base.Controls.SetChildIndex(this.lbl_requetes, 0);
			base.Controls.SetChildIndex(this.gb_messageUtilisateur, 0);
			base.Controls.SetChildIndex(this.pn_configIp, 0);
			base.Controls.SetChildIndex(this.pn_nouveauSegment, 0);
			this.gb_messageUtilisateur.ResumeLayout(false);
			this.pn_configIp.ResumeLayout(false);
			this.pn_nouveauSegment.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000206 RID: 518
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000207 RID: 519
		private global::Simulateur.RouteEdit routeEdit1;

		// Token: 0x04000208 RID: 520
		private global::Simulateur.ReglesFiltrageEdit reglesFiltrageEdit1;

		// Token: 0x04000209 RID: 521
		private global::Simulateur.PortsEcoutesEdit portsEcoutesEdit1;

		// Token: 0x0400020A RID: 522
		protected global::System.Windows.Forms.TextBox tb_ipSource;

		// Token: 0x0400020B RID: 523
		protected global::System.Windows.Forms.TextBox tb_ipDestination;

		// Token: 0x0400020C RID: 524
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400020D RID: 525
		protected global::System.Windows.Forms.TextBox tb_portSource;

		// Token: 0x0400020E RID: 526
		protected global::System.Windows.Forms.TextBox tb_portDest;

		// Token: 0x0400020F RID: 527
		protected global::System.Windows.Forms.TextBox tb_protocole;

		// Token: 0x04000210 RID: 528
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000211 RID: 529
		private global::Simulateur.NatPatEdit natPatEdit1;

		// Token: 0x04000212 RID: 530
		protected global::System.Windows.Forms.TextBox tb_carteArrivee;

		// Token: 0x04000213 RID: 531
		protected global::System.Windows.Forms.TextBox tb_carteDepart;

		// Token: 0x04000214 RID: 532
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000215 RID: 533
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000216 RID: 534
		private global::Simulateur.ReqTrsEdit reqTrsEditEnvoyees;

		// Token: 0x04000217 RID: 535
		private global::Simulateur.ReqTrsEdit reqTrsEditRecues;

		// Token: 0x04000218 RID: 536
		private global::System.Windows.Forms.Label lbl_requetes;

		// Token: 0x04000219 RID: 537
		private global::System.Windows.Forms.GroupBox gb_messageUtilisateur;

		// Token: 0x0400021A RID: 538
		private global::System.Windows.Forms.RadioButton rb_accepte;

		// Token: 0x0400021B RID: 539
		private global::System.Windows.Forms.RadioButton rb_refuse;

		// Token: 0x0400021C RID: 540
		private global::System.Windows.Forms.RadioButton rb_nonJoignable;

		// Token: 0x0400021D RID: 541
		private global::System.Windows.Forms.RadioButton rb_filtre;

		// Token: 0x0400021E RID: 542
		private global::System.Windows.Forms.RadioButton rb_routageInactif;

		// Token: 0x0400021F RID: 543
		private global::System.Windows.Forms.RadioButton rb_ttlEpuise;

		// Token: 0x04000220 RID: 544
		private global::System.Windows.Forms.Panel pn_configIp;

		// Token: 0x04000221 RID: 545
		private global::System.Windows.Forms.CheckBox cb_activerRoutage;

		// Token: 0x04000222 RID: 546
		private global::System.Windows.Forms.TextBox tb_nomHote;

		// Token: 0x04000223 RID: 547
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000224 RID: 548
		private global::System.Windows.Forms.ListBox lb_interface;

		// Token: 0x04000225 RID: 549
		private global::System.Windows.Forms.TextBox tb_passerelle;

		// Token: 0x04000226 RID: 550
		private global::System.Windows.Forms.Label label14;

		// Token: 0x04000227 RID: 551
		private global::System.Windows.Forms.Panel pn_nouveauSegment;

		// Token: 0x04000228 RID: 552
		protected global::System.Windows.Forms.TextBox tb_newPortSource;

		// Token: 0x04000229 RID: 553
		protected global::System.Windows.Forms.TextBox tb_newIpDest;

		// Token: 0x0400022A RID: 554
		protected global::System.Windows.Forms.TextBox tb_newPortDest;

		// Token: 0x0400022B RID: 555
		protected global::System.Windows.Forms.TextBox tb_newIpSource;

		// Token: 0x0400022C RID: 556
		private global::System.Windows.Forms.CheckBox cb_activerNatPat;

		// Token: 0x0400022D RID: 557
		private global::System.Windows.Forms.Label lbl_portSource;

		// Token: 0x0400022E RID: 558
		private global::System.Windows.Forms.Label lbl_portDest;

		// Token: 0x0400022F RID: 559
		private global::System.Windows.Forms.Label lbl_newDest;

		// Token: 0x04000230 RID: 560
		private global::System.Windows.Forms.Label lbl_newSource;

		// Token: 0x04000231 RID: 561
		private global::System.ComponentModel.IContainer components = null;
	}
}
