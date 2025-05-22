namespace Simulateur
{
	// Token: 0x02000026 RID: 38
	public partial class DemoPaquetIp : global::Simulateur.DemoDialogue
	{
		// Token: 0x06000258 RID: 600 RVA: 0x00016FF0 File Offset: 0x00015FF0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0001701C File Offset: 0x0001601C
		private void InitializeComponent()
		{
			this.routeEdit1 = new global::Simulateur.RouteEdit();
			this.cacheArpEdit1 = new global::Simulateur.CacheArpEdit();
			this.tb_destination = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.tb_ipCarte = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.tb_routage = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.pn_configIp = new global::System.Windows.Forms.Panel();
			this.cb_activerRoutage = new global::System.Windows.Forms.CheckBox();
			this.tb_nomHote = new global::System.Windows.Forms.TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.lb_interface = new global::System.Windows.Forms.ListBox();
			this.tb_passerelle = new global::System.Windows.Forms.TextBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.pn_paquetIp = new global::System.Windows.Forms.Panel();
			this.cb_ppp = new global::System.Windows.Forms.CheckBox();
			this.cb_viaArp = new global::System.Windows.Forms.CheckBox();
			this.cb_adrMacSource = new global::System.Windows.Forms.ComboBox();
			this.cb_bcast = new global::System.Windows.Forms.CheckBox();
			this.tb_adrIpDest = new global::System.Windows.Forms.TextBox();
			this.tb_adrIpSource = new global::System.Windows.Forms.TextBox();
			this.tb_adrMacDest = new global::System.Windows.Forms.TextBox();
			this.cb_ttl = new global::System.Windows.Forms.ComboBox();
			this.lbl_ttl = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.label11 = new global::System.Windows.Forms.Label();
			this.cb_typePaquet = new global::System.Windows.Forms.ComboBox();
			this.pn_nouveauPaquetIp = new global::System.Windows.Forms.Panel();
			this.cb_adrMacSourceNouveau = new global::System.Windows.Forms.ComboBox();
			this.cb_bcastNouveau = new global::System.Windows.Forms.CheckBox();
			this.tb_adrIpDestNouveau = new global::System.Windows.Forms.TextBox();
			this.tb_adrIpSourceNouveau = new global::System.Windows.Forms.TextBox();
			this.tb_adrMacDestNouveau = new global::System.Windows.Forms.TextBox();
			this.cb_ttlNouveau = new global::System.Windows.Forms.ComboBox();
			this.lbl_ttlNouveau = new global::System.Windows.Forms.Label();
			this.label13 = new global::System.Windows.Forms.Label();
			this.label14 = new global::System.Windows.Forms.Label();
			this.label15 = new global::System.Windows.Forms.Label();
			this.label16 = new global::System.Windows.Forms.Label();
			this.label17 = new global::System.Windows.Forms.Label();
			this.cb_typePaquetNouveau = new global::System.Windows.Forms.ComboBox();
			this.tb_numCarte = new global::System.Windows.Forms.TextBox();
			this.label18 = new global::System.Windows.Forms.Label();
			this.cb_pppNouveau = new global::System.Windows.Forms.CheckBox();
			this.pn_configIp.SuspendLayout();
			this.pn_paquetIp.SuspendLayout();
			this.pn_nouveauPaquetIp.SuspendLayout();
			base.SuspendLayout();
			this.bt_continuer.Location = new global::System.Drawing.Point(145, 4);
			this.bt_continuer.Name = "bt_continuer";
			this.bt_stop.Name = "bt_stop";
			this.cb_action.Name = "cb_action";
			this.tb_phase.Name = "tb_phase";
			this.lecteur.Name = "lecteur";
			this.tb_resultat.Name = "tb_resultat";
			this.routeEdit1.Location = new global::System.Drawing.Point(4, 84);
			this.routeEdit1.Name = "routeEdit1";
			this.routeEdit1.Size = new global::System.Drawing.Size(488, 80);
			this.routeEdit1.TabIndex = 38;
			this.cacheArpEdit1.Location = new global::System.Drawing.Point(4, 84);
			this.cacheArpEdit1.Name = "cacheArpEdit1";
			this.cacheArpEdit1.Size = new global::System.Drawing.Size(336, 80);
			this.cacheArpEdit1.TabIndex = 39;
			this.tb_destination.Location = new global::System.Drawing.Point(52, 60);
			this.tb_destination.Name = "tb_destination";
			this.tb_destination.ReadOnly = true;
			this.tb_destination.Size = new global::System.Drawing.Size(92, 20);
			this.tb_destination.TabIndex = 40;
			this.tb_destination.TabStop = false;
			this.tb_destination.Text = "255.255.255.255";
			this.label2.Location = new global::System.Drawing.Point(4, 60);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(44, 20);
			this.label2.TabIndex = 41;
			this.label2.Text = "IP dest.";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_ipCarte.Location = new global::System.Drawing.Point(36, 84);
			this.tb_ipCarte.Name = "tb_ipCarte";
			this.tb_ipCarte.ReadOnly = true;
			this.tb_ipCarte.Size = new global::System.Drawing.Size(184, 20);
			this.tb_ipCarte.TabIndex = 42;
			this.tb_ipCarte.TabStop = false;
			this.tb_ipCarte.Text = "255.255.255.255 (255.255.255.255)";
			this.label1.Location = new global::System.Drawing.Point(4, 84);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(32, 20);
			this.label1.TabIndex = 43;
			this.label1.Text = "Carte";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tb_routage.Location = new global::System.Drawing.Point(56, 108);
			this.tb_routage.Name = "tb_routage";
			this.tb_routage.ReadOnly = true;
			this.tb_routage.Size = new global::System.Drawing.Size(164, 20);
			this.tb_routage.TabIndex = 44;
			this.tb_routage.TabStop = false;
			this.tb_routage.Text = "";
			this.label3.Location = new global::System.Drawing.Point(4, 108);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(52, 20);
			this.label3.TabIndex = 45;
			this.label3.Text = "Routage";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.pn_configIp.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pn_configIp.Controls.Add(this.cb_activerRoutage);
			this.pn_configIp.Controls.Add(this.tb_nomHote);
			this.pn_configIp.Controls.Add(this.label4);
			this.pn_configIp.Controls.Add(this.lb_interface);
			this.pn_configIp.Controls.Add(this.tb_passerelle);
			this.pn_configIp.Controls.Add(this.label6);
			this.pn_configIp.Location = new global::System.Drawing.Point(4, 84);
			this.pn_configIp.Name = "pn_configIp";
			this.pn_configIp.Size = new global::System.Drawing.Size(464, 76);
			this.pn_configIp.TabIndex = 46;
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
			this.label4.Location = new global::System.Drawing.Point(0, 4);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(79, 23);
			this.label4.TabIndex = 33;
			this.label4.Text = "Nom d'hôte :";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
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
			this.label6.Location = new global::System.Drawing.Point(0, 28);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(63, 23);
			this.label6.TabIndex = 28;
			this.label6.Text = "Passerelle :";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.pn_paquetIp.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pn_paquetIp.Controls.Add(this.cb_ppp);
			this.pn_paquetIp.Controls.Add(this.cb_viaArp);
			this.pn_paquetIp.Controls.Add(this.cb_adrMacSource);
			this.pn_paquetIp.Controls.Add(this.cb_bcast);
			this.pn_paquetIp.Controls.Add(this.tb_adrIpDest);
			this.pn_paquetIp.Controls.Add(this.tb_adrIpSource);
			this.pn_paquetIp.Controls.Add(this.tb_adrMacDest);
			this.pn_paquetIp.Controls.Add(this.cb_ttl);
			this.pn_paquetIp.Controls.Add(this.lbl_ttl);
			this.pn_paquetIp.Controls.Add(this.label9);
			this.pn_paquetIp.Controls.Add(this.label10);
			this.pn_paquetIp.Controls.Add(this.label7);
			this.pn_paquetIp.Controls.Add(this.label8);
			this.pn_paquetIp.Controls.Add(this.label11);
			this.pn_paquetIp.Controls.Add(this.cb_typePaquet);
			this.pn_paquetIp.Location = new global::System.Drawing.Point(4, 84);
			this.pn_paquetIp.Name = "pn_paquetIp";
			this.pn_paquetIp.Size = new global::System.Drawing.Size(440, 80);
			this.pn_paquetIp.TabIndex = 47;
			this.cb_ppp.Location = new global::System.Drawing.Point(144, 52);
			this.cb_ppp.Name = "cb_ppp";
			this.cb_ppp.Size = new global::System.Drawing.Size(44, 20);
			this.cb_ppp.TabIndex = 52;
			this.cb_ppp.Text = "ppp";
			this.cb_ppp.CheckedChanged += new global::System.EventHandler(this.cb_ppp_CheckedChanged);
			this.cb_viaArp.Location = new global::System.Drawing.Point(80, 52);
			this.cb_viaArp.Name = "cb_viaArp";
			this.cb_viaArp.Size = new global::System.Drawing.Size(60, 20);
			this.cb_viaArp.TabIndex = 18;
			this.cb_viaArp.Text = "via arp";
			this.cb_viaArp.CheckedChanged += new global::System.EventHandler(this.cb_viaArp_CheckedChanged);
			this.cb_adrMacSource.Location = new global::System.Drawing.Point(100, 28);
			this.cb_adrMacSource.Name = "cb_adrMacSource";
			this.cb_adrMacSource.Size = new global::System.Drawing.Size(121, 21);
			this.cb_adrMacSource.TabIndex = 13;
			this.cb_bcast.Location = new global::System.Drawing.Point(196, 52);
			this.cb_bcast.Name = "cb_bcast";
			this.cb_bcast.Size = new global::System.Drawing.Size(51, 20);
			this.cb_bcast.TabIndex = 12;
			this.cb_bcast.Text = "bcast";
			this.cb_bcast.CheckedChanged += new global::System.EventHandler(this.cb_bcast_CheckedChanged);
			this.tb_adrIpDest.Location = new global::System.Drawing.Point(312, 28);
			this.tb_adrIpDest.Name = "tb_adrIpDest";
			this.tb_adrIpDest.Size = new global::System.Drawing.Size(120, 20);
			this.tb_adrIpDest.TabIndex = 11;
			this.tb_adrIpDest.Text = "";
			this.tb_adrIpSource.Location = new global::System.Drawing.Point(312, 4);
			this.tb_adrIpSource.Name = "tb_adrIpSource";
			this.tb_adrIpSource.Size = new global::System.Drawing.Size(120, 20);
			this.tb_adrIpSource.TabIndex = 10;
			this.tb_adrIpSource.Text = "";
			this.tb_adrMacDest.Location = new global::System.Drawing.Point(248, 52);
			this.tb_adrMacDest.Name = "tb_adrMacDest";
			this.tb_adrMacDest.ReadOnly = true;
			this.tb_adrMacDest.TabIndex = 9;
			this.tb_adrMacDest.Text = "Clic sur la carte";
			this.tb_adrMacDest.Leave += new global::System.EventHandler(this.tb_adrMacDest_Leave);
			this.tb_adrMacDest.Enter += new global::System.EventHandler(this.tb_adrMacDest_Enter);
			this.cb_ttl.Location = new global::System.Drawing.Point(384, 52);
			this.cb_ttl.Name = "cb_ttl";
			this.cb_ttl.Size = new global::System.Drawing.Size(48, 21);
			this.cb_ttl.TabIndex = 7;
			this.lbl_ttl.Location = new global::System.Drawing.Point(352, 56);
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
			this.label8.Location = new global::System.Drawing.Point(4, 28);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(92, 20);
			this.label8.TabIndex = 2;
			this.label8.Text = "Adr mac source :";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label11.Location = new global::System.Drawing.Point(4, 6);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(92, 16);
			this.label11.TabIndex = 1;
			this.label11.Text = "Type de paquet :";
			this.label11.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.cb_typePaquet.Items.AddRange(new object[]
			{
				"IcmpEchoRequest",
				"IcmpEchoResponse",
				"ArpRequest",
				"ArpReply"
			});
			this.cb_typePaquet.Location = new global::System.Drawing.Point(100, 4);
			this.cb_typePaquet.Name = "cb_typePaquet";
			this.cb_typePaquet.Size = new global::System.Drawing.Size(121, 21);
			this.cb_typePaquet.TabIndex = 0;
			this.cb_typePaquet.SelectedIndexChanged += new global::System.EventHandler(this.cb_typePaquet_SelectedIndexChanged);
			this.pn_nouveauPaquetIp.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pn_nouveauPaquetIp.Controls.Add(this.cb_pppNouveau);
			this.pn_nouveauPaquetIp.Controls.Add(this.cb_adrMacSourceNouveau);
			this.pn_nouveauPaquetIp.Controls.Add(this.cb_bcastNouveau);
			this.pn_nouveauPaquetIp.Controls.Add(this.tb_adrIpDestNouveau);
			this.pn_nouveauPaquetIp.Controls.Add(this.tb_adrIpSourceNouveau);
			this.pn_nouveauPaquetIp.Controls.Add(this.tb_adrMacDestNouveau);
			this.pn_nouveauPaquetIp.Controls.Add(this.cb_ttlNouveau);
			this.pn_nouveauPaquetIp.Controls.Add(this.lbl_ttlNouveau);
			this.pn_nouveauPaquetIp.Controls.Add(this.label13);
			this.pn_nouveauPaquetIp.Controls.Add(this.label14);
			this.pn_nouveauPaquetIp.Controls.Add(this.label15);
			this.pn_nouveauPaquetIp.Controls.Add(this.label16);
			this.pn_nouveauPaquetIp.Controls.Add(this.label17);
			this.pn_nouveauPaquetIp.Controls.Add(this.cb_typePaquetNouveau);
			this.pn_nouveauPaquetIp.Location = new global::System.Drawing.Point(4, 84);
			this.pn_nouveauPaquetIp.Name = "pn_nouveauPaquetIp";
			this.pn_nouveauPaquetIp.Size = new global::System.Drawing.Size(440, 80);
			this.pn_nouveauPaquetIp.TabIndex = 48;
			this.cb_adrMacSourceNouveau.Location = new global::System.Drawing.Point(100, 28);
			this.cb_adrMacSourceNouveau.Name = "cb_adrMacSourceNouveau";
			this.cb_adrMacSourceNouveau.Size = new global::System.Drawing.Size(121, 21);
			this.cb_adrMacSourceNouveau.TabIndex = 13;
			this.cb_bcastNouveau.Location = new global::System.Drawing.Point(156, 52);
			this.cb_bcastNouveau.Name = "cb_bcastNouveau";
			this.cb_bcastNouveau.Size = new global::System.Drawing.Size(64, 20);
			this.cb_bcastNouveau.TabIndex = 12;
			this.cb_bcastNouveau.Text = "BCAST";
			this.cb_bcastNouveau.CheckedChanged += new global::System.EventHandler(this.cb_bcastNouveau_CheckedChanged);
			this.tb_adrIpDestNouveau.Location = new global::System.Drawing.Point(312, 28);
			this.tb_adrIpDestNouveau.Name = "tb_adrIpDestNouveau";
			this.tb_adrIpDestNouveau.Size = new global::System.Drawing.Size(120, 20);
			this.tb_adrIpDestNouveau.TabIndex = 11;
			this.tb_adrIpDestNouveau.Text = "";
			this.tb_adrIpSourceNouveau.Location = new global::System.Drawing.Point(312, 4);
			this.tb_adrIpSourceNouveau.Name = "tb_adrIpSourceNouveau";
			this.tb_adrIpSourceNouveau.Size = new global::System.Drawing.Size(120, 20);
			this.tb_adrIpSourceNouveau.TabIndex = 10;
			this.tb_adrIpSourceNouveau.Text = "";
			this.tb_adrMacDestNouveau.Location = new global::System.Drawing.Point(220, 52);
			this.tb_adrMacDestNouveau.Name = "tb_adrMacDestNouveau";
			this.tb_adrMacDestNouveau.ReadOnly = true;
			this.tb_adrMacDestNouveau.Size = new global::System.Drawing.Size(108, 20);
			this.tb_adrMacDestNouveau.TabIndex = 9;
			this.tb_adrMacDestNouveau.Text = "Clic sur la carte";
			this.tb_adrMacDestNouveau.Leave += new global::System.EventHandler(this.tb_adrMacDestNouveau_Leave);
			this.tb_adrMacDestNouveau.Enter += new global::System.EventHandler(this.tb_adrMacDestNouveau_Enter);
			this.cb_ttlNouveau.Location = new global::System.Drawing.Point(368, 52);
			this.cb_ttlNouveau.Name = "cb_ttlNouveau";
			this.cb_ttlNouveau.Size = new global::System.Drawing.Size(60, 21);
			this.cb_ttlNouveau.TabIndex = 7;
			this.lbl_ttlNouveau.Location = new global::System.Drawing.Point(332, 56);
			this.lbl_ttlNouveau.Name = "lbl_ttlNouveau";
			this.lbl_ttlNouveau.Size = new global::System.Drawing.Size(32, 16);
			this.lbl_ttlNouveau.TabIndex = 6;
			this.lbl_ttlNouveau.Text = "TTL :";
			this.lbl_ttlNouveau.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label13.Location = new global::System.Drawing.Point(224, 28);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(84, 20);
			this.label13.TabIndex = 5;
			this.label13.Text = "Adr IP dest :";
			this.label13.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label14.Location = new global::System.Drawing.Point(224, 4);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(84, 20);
			this.label14.TabIndex = 4;
			this.label14.Text = "Adr IP source :";
			this.label14.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label15.Location = new global::System.Drawing.Point(4, 52);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(92, 20);
			this.label15.TabIndex = 3;
			this.label15.Text = "Adr mac dest :";
			this.label15.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label16.Location = new global::System.Drawing.Point(4, 28);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(92, 20);
			this.label16.TabIndex = 2;
			this.label16.Text = "Adr mac source :";
			this.label16.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label17.Location = new global::System.Drawing.Point(4, 6);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(92, 16);
			this.label17.TabIndex = 1;
			this.label17.Text = "Type de paquet :";
			this.label17.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.cb_typePaquetNouveau.Items.AddRange(new object[]
			{
				"IcmpEchoRequest",
				"IcmpEchoResponse",
				"ArpRequest",
				"ArpReply"
			});
			this.cb_typePaquetNouveau.Location = new global::System.Drawing.Point(100, 4);
			this.cb_typePaquetNouveau.Name = "cb_typePaquetNouveau";
			this.cb_typePaquetNouveau.Size = new global::System.Drawing.Size(121, 21);
			this.cb_typePaquetNouveau.TabIndex = 0;
			this.cb_typePaquetNouveau.SelectedIndexChanged += new global::System.EventHandler(this.cb_typePaquetNouveau_SelectedIndexChanged);
			this.tb_numCarte.Location = new global::System.Drawing.Point(200, 60);
			this.tb_numCarte.Name = "tb_numCarte";
			this.tb_numCarte.ReadOnly = true;
			this.tb_numCarte.Size = new global::System.Drawing.Size(20, 20);
			this.tb_numCarte.TabIndex = 49;
			this.tb_numCarte.TabStop = false;
			this.tb_numCarte.Text = "";
			this.label18.Location = new global::System.Drawing.Point(148, 60);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(48, 20);
			this.label18.TabIndex = 50;
			this.label18.Text = "Interface";
			this.label18.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.cb_pppNouveau.Location = new global::System.Drawing.Point(100, 52);
			this.cb_pppNouveau.Name = "cb_pppNouveau";
			this.cb_pppNouveau.Size = new global::System.Drawing.Size(48, 20);
			this.cb_pppNouveau.TabIndex = 14;
			this.cb_pppNouveau.Text = "ppp";
			this.cb_pppNouveau.CheckedChanged += new global::System.EventHandler(this.cb_pppNouveau_CheckedChanged);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(602, 183);
			base.Controls.Add(this.pn_paquetIp);
			base.Controls.Add(this.pn_nouveauPaquetIp);
			base.Controls.Add(this.tb_numCarte);
			base.Controls.Add(this.label18);
			base.Controls.Add(this.pn_configIp);
			base.Controls.Add(this.cacheArpEdit1);
			base.Controls.Add(this.routeEdit1);
			base.Controls.Add(this.tb_routage);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.tb_ipCarte);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.tb_destination);
			base.Controls.Add(this.label2);
			base.Name = "DemoPaquetIp";
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.tb_destination, 0);
			base.Controls.SetChildIndex(this.tb_phase, 0);
			base.Controls.SetChildIndex(this.lecteur, 0);
			base.Controls.SetChildIndex(this.tb_resultat, 0);
			base.Controls.SetChildIndex(this.cb_action, 0);
			base.Controls.SetChildIndex(this.bt_stop, 0);
			base.Controls.SetChildIndex(this.bt_continuer, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.tb_ipCarte, 0);
			base.Controls.SetChildIndex(this.label3, 0);
			base.Controls.SetChildIndex(this.tb_routage, 0);
			base.Controls.SetChildIndex(this.routeEdit1, 0);
			base.Controls.SetChildIndex(this.cacheArpEdit1, 0);
			base.Controls.SetChildIndex(this.pn_configIp, 0);
			base.Controls.SetChildIndex(this.label18, 0);
			base.Controls.SetChildIndex(this.tb_numCarte, 0);
			base.Controls.SetChildIndex(this.pn_nouveauPaquetIp, 0);
			base.Controls.SetChildIndex(this.pn_paquetIp, 0);
			this.pn_configIp.ResumeLayout(false);
			this.pn_paquetIp.ResumeLayout(false);
			this.pn_nouveauPaquetIp.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000185 RID: 389
		private global::Simulateur.RouteEdit routeEdit1;

		// Token: 0x04000186 RID: 390
		private global::Simulateur.CacheArpEdit cacheArpEdit1;

		// Token: 0x04000187 RID: 391
		protected global::System.Windows.Forms.TextBox tb_destination;

		// Token: 0x04000188 RID: 392
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000189 RID: 393
		protected global::System.Windows.Forms.TextBox tb_ipCarte;

		// Token: 0x0400018A RID: 394
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400018B RID: 395
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400018C RID: 396
		protected global::System.Windows.Forms.TextBox tb_routage;

		// Token: 0x0400018D RID: 397
		private global::System.Windows.Forms.Panel pn_configIp;

		// Token: 0x0400018E RID: 398
		private global::System.Windows.Forms.CheckBox cb_activerRoutage;

		// Token: 0x0400018F RID: 399
		private global::System.Windows.Forms.TextBox tb_nomHote;

		// Token: 0x04000190 RID: 400
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000191 RID: 401
		private global::System.Windows.Forms.ListBox lb_interface;

		// Token: 0x04000192 RID: 402
		private global::System.Windows.Forms.TextBox tb_passerelle;

		// Token: 0x04000193 RID: 403
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000194 RID: 404
		private global::System.Windows.Forms.Panel pn_paquetIp;

		// Token: 0x04000195 RID: 405
		private global::System.Windows.Forms.ComboBox cb_adrMacSource;

		// Token: 0x04000196 RID: 406
		private global::System.Windows.Forms.CheckBox cb_bcast;

		// Token: 0x04000197 RID: 407
		private global::System.Windows.Forms.TextBox tb_adrIpDest;

		// Token: 0x04000198 RID: 408
		private global::System.Windows.Forms.TextBox tb_adrIpSource;

		// Token: 0x04000199 RID: 409
		private global::System.Windows.Forms.TextBox tb_adrMacDest;

		// Token: 0x0400019A RID: 410
		private global::System.Windows.Forms.ComboBox cb_ttl;

		// Token: 0x0400019B RID: 411
		private global::System.Windows.Forms.Label lbl_ttl;

		// Token: 0x0400019C RID: 412
		private global::System.Windows.Forms.Label label9;

		// Token: 0x0400019D RID: 413
		private global::System.Windows.Forms.Label label10;

		// Token: 0x0400019E RID: 414
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400019F RID: 415
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040001A0 RID: 416
		private global::System.Windows.Forms.Label label11;

		// Token: 0x040001A1 RID: 417
		private global::System.Windows.Forms.ComboBox cb_typePaquet;

		// Token: 0x040001A2 RID: 418
		private global::System.Windows.Forms.Panel pn_nouveauPaquetIp;

		// Token: 0x040001A3 RID: 419
		private global::System.Windows.Forms.ComboBox cb_adrMacSourceNouveau;

		// Token: 0x040001A4 RID: 420
		private global::System.Windows.Forms.CheckBox cb_bcastNouveau;

		// Token: 0x040001A5 RID: 421
		private global::System.Windows.Forms.TextBox tb_adrIpDestNouveau;

		// Token: 0x040001A6 RID: 422
		private global::System.Windows.Forms.TextBox tb_adrIpSourceNouveau;

		// Token: 0x040001A7 RID: 423
		private global::System.Windows.Forms.TextBox tb_adrMacDestNouveau;

		// Token: 0x040001A8 RID: 424
		private global::System.Windows.Forms.ComboBox cb_ttlNouveau;

		// Token: 0x040001A9 RID: 425
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040001AA RID: 426
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040001AB RID: 427
		private global::System.Windows.Forms.Label label15;

		// Token: 0x040001AC RID: 428
		private global::System.Windows.Forms.Label label16;

		// Token: 0x040001AD RID: 429
		private global::System.Windows.Forms.Label label17;

		// Token: 0x040001AE RID: 430
		private global::System.Windows.Forms.ComboBox cb_typePaquetNouveau;

		// Token: 0x040001AF RID: 431
		protected global::System.Windows.Forms.TextBox tb_numCarte;

		// Token: 0x040001B0 RID: 432
		private global::System.Windows.Forms.Label label18;

		// Token: 0x040001B1 RID: 433
		private global::System.Windows.Forms.Label lbl_ttlNouveau;

		// Token: 0x040001B2 RID: 434
		private global::System.Windows.Forms.CheckBox cb_viaArp;

		// Token: 0x040001B3 RID: 435
		private global::System.Windows.Forms.CheckBox cb_ppp;

		// Token: 0x040001B4 RID: 436
		private global::System.Windows.Forms.CheckBox cb_pppNouveau;

		// Token: 0x040001B5 RID: 437
		private global::System.ComponentModel.IContainer components = null;
	}
}
