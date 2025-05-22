namespace Simulateur
{
	// Token: 0x02000027 RID: 39
	public partial class DemoPing : global::Simulateur.DemoDialogue
	{
		// Token: 0x06000275 RID: 629 RVA: 0x0001A7F0 File Offset: 0x000197F0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0001A81C File Offset: 0x0001981C
		private void InitializeComponent()
		{
			this.tb_destination = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.fichierHostsEdit1 = new global::Simulateur.FichierHostsEdit();
			this.cacheArpEdit1 = new global::Simulateur.CacheArpEdit();
			this.routeEdit1 = new global::Simulateur.RouteEdit();
			this.pn_configIp = new global::System.Windows.Forms.Panel();
			this.cb_activerRoutage = new global::System.Windows.Forms.CheckBox();
			this.tb_nomHote = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.lb_interface = new global::System.Windows.Forms.ListBox();
			this.tb_passerelle = new global::System.Windows.Forms.TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.gb_messageUtilisateur = new global::System.Windows.Forms.GroupBox();
			this.rb_adrIpIncorrecte = new global::System.Windows.Forms.RadioButton();
			this.rb_nonJoignable = new global::System.Windows.Forms.RadioButton();
			this.rb_ok = new global::System.Windows.Forms.RadioButton();
			this.pn_paquetIp = new global::System.Windows.Forms.Panel();
			this.cb_pppIp = new global::System.Windows.Forms.CheckBox();
			this.cb_bcastIp = new global::System.Windows.Forms.CheckBox();
			this.cb_viaArpIp = new global::System.Windows.Forms.CheckBox();
			this.cb_adrMacSourceIp = new global::System.Windows.Forms.ComboBox();
			this.tb_adrIpDestIp = new global::System.Windows.Forms.TextBox();
			this.tb_adrIpSourceIp = new global::System.Windows.Forms.TextBox();
			this.tb_adrMacDestIp = new global::System.Windows.Forms.TextBox();
			this.cb_ttlIp = new global::System.Windows.Forms.ComboBox();
			this.lbl_ttl = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.cb_typePaquetIp = new global::System.Windows.Forms.ComboBox();
			this.pn_paquetArp = new global::System.Windows.Forms.Panel();
			this.cb_adrMacSourceArp = new global::System.Windows.Forms.ComboBox();
			this.cb_bcastArp = new global::System.Windows.Forms.CheckBox();
			this.tb_adrIpDestArp = new global::System.Windows.Forms.TextBox();
			this.tb_adrIpSourceArp = new global::System.Windows.Forms.TextBox();
			this.tb_adrMacDestArp = new global::System.Windows.Forms.TextBox();
			this.label11 = new global::System.Windows.Forms.Label();
			this.label12 = new global::System.Windows.Forms.Label();
			this.label13 = new global::System.Windows.Forms.Label();
			this.label14 = new global::System.Windows.Forms.Label();
			this.label15 = new global::System.Windows.Forms.Label();
			this.cb_typePaquetArp = new global::System.Windows.Forms.ComboBox();
			this.pn_configIp.SuspendLayout();
			this.gb_messageUtilisateur.SuspendLayout();
			this.pn_paquetIp.SuspendLayout();
			this.pn_paquetArp.SuspendLayout();
			base.SuspendLayout();
			this.bt_continuer.Name = "bt_continuer";
			this.bt_stop.Name = "bt_stop";
			this.cb_action.Name = "cb_action";
			this.tb_phase.Name = "tb_phase";
			this.lecteur.Name = "lecteur";
			this.tb_resultat.Name = "tb_resultat";
			this.tb_destination.Location = new global::System.Drawing.Point(68, 60);
			this.tb_destination.Name = "tb_destination";
			this.tb_destination.ReadOnly = true;
			this.tb_destination.Size = new global::System.Drawing.Size(152, 20);
			this.tb_destination.TabIndex = 33;
			this.tb_destination.TabStop = false;
			this.tb_destination.Text = "";
			this.label2.Location = new global::System.Drawing.Point(4, 60);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(64, 20);
			this.label2.TabIndex = 34;
			this.label2.Text = "Destination";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.fichierHostsEdit1.Location = new global::System.Drawing.Point(4, 84);
			this.fichierHostsEdit1.Name = "fichierHostsEdit1";
			this.fichierHostsEdit1.Size = new global::System.Drawing.Size(316, 80);
			this.fichierHostsEdit1.TabIndex = 35;
			this.cacheArpEdit1.Location = new global::System.Drawing.Point(4, 84);
			this.cacheArpEdit1.Name = "cacheArpEdit1";
			this.cacheArpEdit1.Size = new global::System.Drawing.Size(336, 80);
			this.cacheArpEdit1.TabIndex = 36;
			this.routeEdit1.Location = new global::System.Drawing.Point(4, 84);
			this.routeEdit1.Name = "routeEdit1";
			this.routeEdit1.Size = new global::System.Drawing.Size(488, 80);
			this.routeEdit1.TabIndex = 37;
			this.pn_configIp.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pn_configIp.Controls.Add(this.cb_activerRoutage);
			this.pn_configIp.Controls.Add(this.tb_nomHote);
			this.pn_configIp.Controls.Add(this.label1);
			this.pn_configIp.Controls.Add(this.lb_interface);
			this.pn_configIp.Controls.Add(this.tb_passerelle);
			this.pn_configIp.Controls.Add(this.label4);
			this.pn_configIp.Location = new global::System.Drawing.Point(4, 84);
			this.pn_configIp.Name = "pn_configIp";
			this.pn_configIp.Size = new global::System.Drawing.Size(464, 76);
			this.pn_configIp.TabIndex = 38;
			this.cb_activerRoutage.Enabled = false;
			this.cb_activerRoutage.Location = new global::System.Drawing.Point(80, 52);
			this.cb_activerRoutage.Name = "cb_activerRoutage";
			this.cb_activerRoutage.Size = new global::System.Drawing.Size(136, 16);
			this.cb_activerRoutage.TabIndex = 34;
			this.cb_activerRoutage.Text = "Activer le routage";
			this.tb_nomHote.Enabled = false;
			this.tb_nomHote.Location = new global::System.Drawing.Point(80, 4);
			this.tb_nomHote.Name = "tb_nomHote";
			this.tb_nomHote.Size = new global::System.Drawing.Size(136, 20);
			this.tb_nomHote.TabIndex = 32;
			this.tb_nomHote.Text = "";
			this.label1.Location = new global::System.Drawing.Point(0, 4);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(79, 23);
			this.label1.TabIndex = 33;
			this.label1.Text = "Nom d'hôte :";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
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
			this.label4.Location = new global::System.Drawing.Point(0, 28);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(63, 23);
			this.label4.TabIndex = 28;
			this.label4.Text = "Passerelle :";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label3.Location = new global::System.Drawing.Point(228, 64);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(79, 16);
			this.label3.TabIndex = 31;
			this.label3.Text = "Interfaces :";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label3.Visible = false;
			this.gb_messageUtilisateur.Controls.Add(this.rb_adrIpIncorrecte);
			this.gb_messageUtilisateur.Controls.Add(this.rb_nonJoignable);
			this.gb_messageUtilisateur.Controls.Add(this.rb_ok);
			this.gb_messageUtilisateur.Location = new global::System.Drawing.Point(4, 80);
			this.gb_messageUtilisateur.Name = "gb_messageUtilisateur";
			this.gb_messageUtilisateur.Size = new global::System.Drawing.Size(216, 76);
			this.gb_messageUtilisateur.TabIndex = 40;
			this.gb_messageUtilisateur.TabStop = false;
			this.rb_adrIpIncorrecte.Location = new global::System.Drawing.Point(20, 52);
			this.rb_adrIpIncorrecte.Name = "rb_adrIpIncorrecte";
			this.rb_adrIpIncorrecte.Size = new global::System.Drawing.Size(180, 20);
			this.rb_adrIpIncorrecte.TabIndex = 2;
			this.rb_adrIpIncorrecte.Text = "adresse IP incorrecte";
			this.rb_nonJoignable.Location = new global::System.Drawing.Point(20, 32);
			this.rb_nonJoignable.Name = "rb_nonJoignable";
			this.rb_nonJoignable.Size = new global::System.Drawing.Size(180, 20);
			this.rb_nonJoignable.TabIndex = 1;
			this.rb_nonJoignable.Text = "hôte non joignable";
			this.rb_ok.Location = new global::System.Drawing.Point(20, 12);
			this.rb_ok.Name = "rb_ok";
			this.rb_ok.Size = new global::System.Drawing.Size(180, 20);
			this.rb_ok.TabIndex = 0;
			this.rb_ok.Text = "l'hôte a bien renvoyé le paquet";
			this.pn_paquetIp.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pn_paquetIp.Controls.Add(this.cb_pppIp);
			this.pn_paquetIp.Controls.Add(this.cb_bcastIp);
			this.pn_paquetIp.Controls.Add(this.cb_viaArpIp);
			this.pn_paquetIp.Controls.Add(this.cb_adrMacSourceIp);
			this.pn_paquetIp.Controls.Add(this.tb_adrIpDestIp);
			this.pn_paquetIp.Controls.Add(this.tb_adrIpSourceIp);
			this.pn_paquetIp.Controls.Add(this.tb_adrMacDestIp);
			this.pn_paquetIp.Controls.Add(this.cb_ttlIp);
			this.pn_paquetIp.Controls.Add(this.lbl_ttl);
			this.pn_paquetIp.Controls.Add(this.label9);
			this.pn_paquetIp.Controls.Add(this.label10);
			this.pn_paquetIp.Controls.Add(this.label7);
			this.pn_paquetIp.Controls.Add(this.label6);
			this.pn_paquetIp.Controls.Add(this.label5);
			this.pn_paquetIp.Controls.Add(this.cb_typePaquetIp);
			this.pn_paquetIp.Location = new global::System.Drawing.Point(4, 84);
			this.pn_paquetIp.Name = "pn_paquetIp";
			this.pn_paquetIp.Size = new global::System.Drawing.Size(440, 80);
			this.pn_paquetIp.TabIndex = 41;
			this.cb_pppIp.Location = new global::System.Drawing.Point(144, 52);
			this.cb_pppIp.Name = "cb_pppIp";
			this.cb_pppIp.Size = new global::System.Drawing.Size(44, 20);
			this.cb_pppIp.TabIndex = 46;
			this.cb_pppIp.Text = "ppp";
			this.cb_pppIp.CheckedChanged += new global::System.EventHandler(this.cb_pppIp_CheckedChanged);
			this.cb_bcastIp.Location = new global::System.Drawing.Point(192, 52);
			this.cb_bcastIp.Name = "cb_bcastIp";
			this.cb_bcastIp.Size = new global::System.Drawing.Size(51, 20);
			this.cb_bcastIp.TabIndex = 18;
			this.cb_bcastIp.Text = "bcast";
			this.cb_bcastIp.CheckedChanged += new global::System.EventHandler(this.cb_bcastIp_CheckedChanged);
			this.cb_viaArpIp.Location = new global::System.Drawing.Point(84, 52);
			this.cb_viaArpIp.Name = "cb_viaArpIp";
			this.cb_viaArpIp.Size = new global::System.Drawing.Size(60, 20);
			this.cb_viaArpIp.TabIndex = 17;
			this.cb_viaArpIp.Text = "via arp";
			this.cb_viaArpIp.CheckedChanged += new global::System.EventHandler(this.cb_viaArpIp_CheckedChanged);
			this.cb_adrMacSourceIp.Location = new global::System.Drawing.Point(100, 28);
			this.cb_adrMacSourceIp.Name = "cb_adrMacSourceIp";
			this.cb_adrMacSourceIp.Size = new global::System.Drawing.Size(121, 21);
			this.cb_adrMacSourceIp.TabIndex = 13;
			this.tb_adrIpDestIp.Location = new global::System.Drawing.Point(312, 28);
			this.tb_adrIpDestIp.Name = "tb_adrIpDestIp";
			this.tb_adrIpDestIp.Size = new global::System.Drawing.Size(120, 20);
			this.tb_adrIpDestIp.TabIndex = 11;
			this.tb_adrIpDestIp.Text = "";
			this.tb_adrIpSourceIp.Location = new global::System.Drawing.Point(312, 4);
			this.tb_adrIpSourceIp.Name = "tb_adrIpSourceIp";
			this.tb_adrIpSourceIp.Size = new global::System.Drawing.Size(120, 20);
			this.tb_adrIpSourceIp.TabIndex = 10;
			this.tb_adrIpSourceIp.Text = "";
			this.tb_adrMacDestIp.Location = new global::System.Drawing.Point(244, 52);
			this.tb_adrMacDestIp.Name = "tb_adrMacDestIp";
			this.tb_adrMacDestIp.ReadOnly = true;
			this.tb_adrMacDestIp.TabIndex = 9;
			this.tb_adrMacDestIp.Text = "Clic sur la carte";
			this.tb_adrMacDestIp.Leave += new global::System.EventHandler(this.tb_adrMacDestIp_Leave);
			this.tb_adrMacDestIp.Enter += new global::System.EventHandler(this.tb_adrMacDestIp_Enter);
			this.cb_ttlIp.Location = new global::System.Drawing.Point(384, 52);
			this.cb_ttlIp.Name = "cb_ttlIp";
			this.cb_ttlIp.Size = new global::System.Drawing.Size(48, 21);
			this.cb_ttlIp.TabIndex = 7;
			this.lbl_ttl.Location = new global::System.Drawing.Point(348, 56);
			this.lbl_ttl.Name = "lbl_ttl";
			this.lbl_ttl.Size = new global::System.Drawing.Size(32, 16);
			this.lbl_ttl.TabIndex = 6;
			this.lbl_ttl.Text = "TTL :";
			this.lbl_ttl.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label9.Location = new global::System.Drawing.Point(224, 28);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(84, 20);
			this.label9.TabIndex = 5;
			this.label9.Text = "Adr IP dest :";
			this.label9.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label10.Location = new global::System.Drawing.Point(224, 4);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(84, 20);
			this.label10.TabIndex = 4;
			this.label10.Text = "Adr IP source :";
			this.label10.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label7.Location = new global::System.Drawing.Point(4, 52);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(80, 20);
			this.label7.TabIndex = 3;
			this.label7.Text = "Adr mac dest :";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label6.Location = new global::System.Drawing.Point(4, 28);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(92, 20);
			this.label6.TabIndex = 2;
			this.label6.Text = "Adr mac source :";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label5.Location = new global::System.Drawing.Point(4, 6);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(92, 16);
			this.label5.TabIndex = 1;
			this.label5.Text = "Type de paquet :";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.cb_typePaquetIp.Items.AddRange(new object[]
			{
				"IcmpEchoRequest",
				"IcmpEchoResponse"
			});
			this.cb_typePaquetIp.Location = new global::System.Drawing.Point(100, 4);
			this.cb_typePaquetIp.Name = "cb_typePaquetIp";
			this.cb_typePaquetIp.Size = new global::System.Drawing.Size(121, 21);
			this.cb_typePaquetIp.TabIndex = 0;
			this.pn_paquetArp.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pn_paquetArp.Controls.Add(this.cb_adrMacSourceArp);
			this.pn_paquetArp.Controls.Add(this.cb_bcastArp);
			this.pn_paquetArp.Controls.Add(this.tb_adrIpDestArp);
			this.pn_paquetArp.Controls.Add(this.tb_adrIpSourceArp);
			this.pn_paquetArp.Controls.Add(this.tb_adrMacDestArp);
			this.pn_paquetArp.Controls.Add(this.label11);
			this.pn_paquetArp.Controls.Add(this.label12);
			this.pn_paquetArp.Controls.Add(this.label13);
			this.pn_paquetArp.Controls.Add(this.label14);
			this.pn_paquetArp.Controls.Add(this.label15);
			this.pn_paquetArp.Controls.Add(this.cb_typePaquetArp);
			this.pn_paquetArp.Location = new global::System.Drawing.Point(4, 84);
			this.pn_paquetArp.Name = "pn_paquetArp";
			this.pn_paquetArp.Size = new global::System.Drawing.Size(440, 80);
			this.pn_paquetArp.TabIndex = 42;
			this.cb_adrMacSourceArp.Location = new global::System.Drawing.Point(100, 28);
			this.cb_adrMacSourceArp.Name = "cb_adrMacSourceArp";
			this.cb_adrMacSourceArp.Size = new global::System.Drawing.Size(121, 21);
			this.cb_adrMacSourceArp.TabIndex = 13;
			this.cb_bcastArp.Location = new global::System.Drawing.Point(100, 52);
			this.cb_bcastArp.Name = "cb_bcastArp";
			this.cb_bcastArp.Size = new global::System.Drawing.Size(64, 20);
			this.cb_bcastArp.TabIndex = 12;
			this.cb_bcastArp.Text = "BCAST";
			this.cb_bcastArp.CheckedChanged += new global::System.EventHandler(this.cb_bcastArp_CheckedChanged);
			this.tb_adrIpDestArp.Location = new global::System.Drawing.Point(312, 28);
			this.tb_adrIpDestArp.Name = "tb_adrIpDestArp";
			this.tb_adrIpDestArp.Size = new global::System.Drawing.Size(120, 20);
			this.tb_adrIpDestArp.TabIndex = 11;
			this.tb_adrIpDestArp.Text = "";
			this.tb_adrIpSourceArp.Location = new global::System.Drawing.Point(312, 4);
			this.tb_adrIpSourceArp.Name = "tb_adrIpSourceArp";
			this.tb_adrIpSourceArp.Size = new global::System.Drawing.Size(120, 20);
			this.tb_adrIpSourceArp.TabIndex = 10;
			this.tb_adrIpSourceArp.Text = "";
			this.tb_adrMacDestArp.Location = new global::System.Drawing.Point(164, 52);
			this.tb_adrMacDestArp.Name = "tb_adrMacDestArp";
			this.tb_adrMacDestArp.ReadOnly = true;
			this.tb_adrMacDestArp.Size = new global::System.Drawing.Size(108, 20);
			this.tb_adrMacDestArp.TabIndex = 9;
			this.tb_adrMacDestArp.Text = "Clic sur la carte";
			this.tb_adrMacDestArp.Leave += new global::System.EventHandler(this.tb_adrMacDestArp_Leave);
			this.tb_adrMacDestArp.Enter += new global::System.EventHandler(this.tb_adrMacDestArp_Enter);
			this.label11.Location = new global::System.Drawing.Point(224, 28);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(84, 20);
			this.label11.TabIndex = 5;
			this.label11.Text = "Adr IP dest :";
			this.label11.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label12.Location = new global::System.Drawing.Point(224, 4);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(84, 20);
			this.label12.TabIndex = 4;
			this.label12.Text = "Adr IP source :";
			this.label12.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label13.Location = new global::System.Drawing.Point(4, 52);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(92, 20);
			this.label13.TabIndex = 3;
			this.label13.Text = "Adr mac dest :";
			this.label13.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label14.Location = new global::System.Drawing.Point(4, 28);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(92, 20);
			this.label14.TabIndex = 2;
			this.label14.Text = "Adr mac source :";
			this.label14.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label15.Location = new global::System.Drawing.Point(4, 6);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(92, 16);
			this.label15.TabIndex = 1;
			this.label15.Text = "Type de paquet :";
			this.label15.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.cb_typePaquetArp.Items.AddRange(new object[]
			{
				"ArpRequest",
				"ArpReply"
			});
			this.cb_typePaquetArp.Location = new global::System.Drawing.Point(100, 4);
			this.cb_typePaquetArp.Name = "cb_typePaquetArp";
			this.cb_typePaquetArp.Size = new global::System.Drawing.Size(121, 21);
			this.cb_typePaquetArp.TabIndex = 0;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(498, 167);
			base.Controls.Add(this.pn_configIp);
			base.Controls.Add(this.pn_paquetIp);
			base.Controls.Add(this.gb_messageUtilisateur);
			base.Controls.Add(this.pn_paquetArp);
			base.Controls.Add(this.routeEdit1);
			base.Controls.Add(this.cacheArpEdit1);
			base.Controls.Add(this.fichierHostsEdit1);
			base.Controls.Add(this.tb_destination);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label3);
			base.Name = "DemoPing";
			base.Controls.SetChildIndex(this.label3, 0);
			base.Controls.SetChildIndex(this.tb_phase, 0);
			base.Controls.SetChildIndex(this.lecteur, 0);
			base.Controls.SetChildIndex(this.tb_resultat, 0);
			base.Controls.SetChildIndex(this.cb_action, 0);
			base.Controls.SetChildIndex(this.bt_stop, 0);
			base.Controls.SetChildIndex(this.bt_continuer, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.tb_destination, 0);
			base.Controls.SetChildIndex(this.fichierHostsEdit1, 0);
			base.Controls.SetChildIndex(this.cacheArpEdit1, 0);
			base.Controls.SetChildIndex(this.routeEdit1, 0);
			base.Controls.SetChildIndex(this.pn_paquetArp, 0);
			base.Controls.SetChildIndex(this.gb_messageUtilisateur, 0);
			base.Controls.SetChildIndex(this.pn_paquetIp, 0);
			base.Controls.SetChildIndex(this.pn_configIp, 0);
			this.pn_configIp.ResumeLayout(false);
			this.gb_messageUtilisateur.ResumeLayout(false);
			this.pn_paquetIp.ResumeLayout(false);
			this.pn_paquetArp.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040001C7 RID: 455
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040001C8 RID: 456
		protected global::System.Windows.Forms.TextBox tb_destination;

		// Token: 0x040001C9 RID: 457
		private global::Simulateur.FichierHostsEdit fichierHostsEdit1;

		// Token: 0x040001CA RID: 458
		private global::Simulateur.CacheArpEdit cacheArpEdit1;

		// Token: 0x040001CB RID: 459
		private global::Simulateur.RouteEdit routeEdit1;

		// Token: 0x040001CC RID: 460
		private global::System.Windows.Forms.Panel pn_configIp;

		// Token: 0x040001CD RID: 461
		private global::System.Windows.Forms.CheckBox cb_activerRoutage;

		// Token: 0x040001CE RID: 462
		private global::System.Windows.Forms.TextBox tb_nomHote;

		// Token: 0x040001CF RID: 463
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040001D0 RID: 464
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040001D1 RID: 465
		private global::System.Windows.Forms.ListBox lb_interface;

		// Token: 0x040001D2 RID: 466
		private global::System.Windows.Forms.TextBox tb_passerelle;

		// Token: 0x040001D3 RID: 467
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040001D4 RID: 468
		private global::System.Windows.Forms.GroupBox gb_messageUtilisateur;

		// Token: 0x040001D5 RID: 469
		private global::System.Windows.Forms.RadioButton rb_ok;

		// Token: 0x040001D6 RID: 470
		private global::System.Windows.Forms.RadioButton rb_nonJoignable;

		// Token: 0x040001D7 RID: 471
		private global::System.Windows.Forms.RadioButton rb_adrIpIncorrecte;

		// Token: 0x040001D8 RID: 472
		private global::System.Windows.Forms.Panel pn_paquetIp;

		// Token: 0x040001D9 RID: 473
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040001DA RID: 474
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040001DB RID: 475
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040001DC RID: 476
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040001DD RID: 477
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040001DE RID: 478
		private global::System.Windows.Forms.Label lbl_ttl;

		// Token: 0x040001DF RID: 479
		private global::System.Windows.Forms.Label label11;

		// Token: 0x040001E0 RID: 480
		private global::System.Windows.Forms.Label label12;

		// Token: 0x040001E1 RID: 481
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040001E2 RID: 482
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040001E3 RID: 483
		private global::System.Windows.Forms.Label label15;

		// Token: 0x040001E4 RID: 484
		private global::System.Windows.Forms.ComboBox cb_adrMacSourceIp;

		// Token: 0x040001E5 RID: 485
		private global::System.Windows.Forms.TextBox tb_adrIpDestIp;

		// Token: 0x040001E6 RID: 486
		private global::System.Windows.Forms.TextBox tb_adrIpSourceIp;

		// Token: 0x040001E7 RID: 487
		private global::System.Windows.Forms.TextBox tb_adrMacDestIp;

		// Token: 0x040001E8 RID: 488
		private global::System.Windows.Forms.ComboBox cb_ttlIp;

		// Token: 0x040001E9 RID: 489
		private global::System.Windows.Forms.ComboBox cb_typePaquetIp;

		// Token: 0x040001EA RID: 490
		private global::System.Windows.Forms.Panel pn_paquetArp;

		// Token: 0x040001EB RID: 491
		private global::System.Windows.Forms.ComboBox cb_adrMacSourceArp;

		// Token: 0x040001EC RID: 492
		private global::System.Windows.Forms.CheckBox cb_bcastArp;

		// Token: 0x040001ED RID: 493
		private global::System.Windows.Forms.TextBox tb_adrIpDestArp;

		// Token: 0x040001EE RID: 494
		private global::System.Windows.Forms.TextBox tb_adrIpSourceArp;

		// Token: 0x040001EF RID: 495
		private global::System.Windows.Forms.TextBox tb_adrMacDestArp;

		// Token: 0x040001F0 RID: 496
		private global::System.Windows.Forms.ComboBox cb_typePaquetArp;

		// Token: 0x040001F1 RID: 497
		private global::System.Windows.Forms.CheckBox cb_viaArpIp;

		// Token: 0x040001F2 RID: 498
		private global::System.Windows.Forms.CheckBox cb_bcastIp;

		// Token: 0x040001F3 RID: 499
		private global::System.Windows.Forms.CheckBox cb_pppIp;

		// Token: 0x040001F4 RID: 500
		private global::System.ComponentModel.IContainer components = null;
	}
}
