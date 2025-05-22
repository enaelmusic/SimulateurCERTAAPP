namespace Simulateur
{
	// Token: 0x02000080 RID: 128
	public partial class Simulation : global::System.Windows.Forms.Form, global::IAppliParam.IAppliParam
	{
		// Token: 0x060007C0 RID: 1984 RVA: 0x0004A294 File Offset: 0x00049294
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x0004A2C0 File Offset: 0x000492C0
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager(typeof(global::Simulateur.Simulation));
			this.outils = new global::System.Windows.Forms.Panel();
			this.panelApplication = new global::System.Windows.Forms.Panel();
			this.bt_pauseRepriseAp = new global::System.Windows.Forms.Button();
			this.il_pauseReprise = new global::System.Windows.Forms.ImageList(this.components);
			this.panelReglagesAp = new global::System.Windows.Forms.Panel();
			this.cb_ralentiAp = new global::System.Windows.Forms.CheckBox();
			this.cb_typeSimulAp = new global::System.Windows.Forms.ComboBox();
			this.bt_tracerAp = new global::System.Windows.Forms.Button();
			this.label3 = new global::System.Windows.Forms.Label();
			this.bt_stopBisAp = new global::System.Windows.Forms.Button();
			this.panelTrameAp = new global::System.Windows.Forms.Panel();
			this.panelPaquetAp = new global::System.Windows.Forms.Panel();
			this.panelMessageAp = new global::System.Windows.Forms.Panel();
			this.lbl_donneesAp = new global::System.Windows.Forms.Label();
			this.lbl_ipSourceAp = new global::System.Windows.Forms.Label();
			this.lbl_ipDestAp = new global::System.Windows.Forms.Label();
			this.lbl_typeAp = new global::System.Windows.Forms.Label();
			this.panelEthernet = new global::System.Windows.Forms.Panel();
			this.panelReglagesEthernet = new global::System.Windows.Forms.Panel();
			this.cb_fullDuplex = new global::System.Windows.Forms.CheckBox();
			this.cb_ralenti = new global::System.Windows.Forms.CheckBox();
			this.cb_messageReception = new global::System.Windows.Forms.CheckBox();
			this.cb_demoEmission = new global::System.Windows.Forms.CheckBox();
			this.cb_typeDemo = new global::System.Windows.Forms.ComboBox();
			this.bt_noeudsDemo = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.bt_pauseReprise = new global::System.Windows.Forms.Button();
			this.panelTrameEthernet = new global::System.Windows.Forms.Panel();
			this.lbl_donnees = new global::System.Windows.Forms.Label();
			this.lbl_crc = new global::System.Windows.Forms.Label();
			this.lbl_type = new global::System.Windows.Forms.Label();
			this.lbl_emetteur = new global::System.Windows.Forms.Label();
			this.lbl_destinataire = new global::System.Windows.Forms.Label();
			this.lbl_preambule = new global::System.Windows.Forms.Label();
			this.bt_debugBis = new global::System.Windows.Forms.Button();
			this.bt_stopBis = new global::System.Windows.Forms.Button();
			this.panelIp = new global::System.Windows.Forms.Panel();
			this.panelReglagesIp = new global::System.Windows.Forms.Panel();
			this.cb_statiques = new global::System.Windows.Forms.CheckBox();
			this.cb_demoRoutageSeul = new global::System.Windows.Forms.CheckBox();
			this.cb_trajetPaquet = new global::System.Windows.Forms.ComboBox();
			this.lbl_trajetPaquet = new global::System.Windows.Forms.Label();
			this.cb_demoArp = new global::System.Windows.Forms.CheckBox();
			this.cb_ralentiIp = new global::System.Windows.Forms.CheckBox();
			this.cb_typeSimulIp = new global::System.Windows.Forms.ComboBox();
			this.lbl_SimulIp = new global::System.Windows.Forms.Label();
			this.panelTrameIp = new global::System.Windows.Forms.Panel();
			this.lbl_typePaquet = new global::System.Windows.Forms.Label();
			this.panelPaquetIp = new global::System.Windows.Forms.Panel();
			this.lbl_ttlPaquet = new global::System.Windows.Forms.Label();
			this.lbl_IpSource = new global::System.Windows.Forms.Label();
			this.lbl_IpDest = new global::System.Windows.Forms.Label();
			this.lbl_donneesIp = new global::System.Windows.Forms.Label();
			this.lbl_macSource = new global::System.Windows.Forms.Label();
			this.lbl_macDest = new global::System.Windows.Forms.Label();
			this.bt_stopBisIp = new global::System.Windows.Forms.Button();
			this.bt_pauseRepriseIp = new global::System.Windows.Forms.Button();
			this.boutonsConception = new global::System.Windows.Forms.GroupBox();
			this.rb_internet = new global::System.Windows.Forms.RadioButton();
			this.il_composants = new global::System.Windows.Forms.ImageList(this.components);
			this.rb_switch = new global::System.Windows.Forms.RadioButton();
			this.rb_cable = new global::System.Windows.Forms.RadioButton();
			this.rb_hub = new global::System.Windows.Forms.RadioButton();
			this.rb_station = new global::System.Windows.Forms.RadioButton();
			this.rb_fleche = new global::System.Windows.Forms.RadioButton();
			this.schema = new global::System.Windows.Forms.Panel();
			this.iconeMessage = new global::Simulateur.Ap_Message();
			this.gereDoc = new global::Simulateur.GestionDocument();
			this.mi_mode = new global::System.Windows.Forms.MenuItem();
			this.mi_conceptionReseau = new global::System.Windows.Forms.MenuItem();
			this.mi_ethernet = new global::System.Windows.Forms.MenuItem();
			this.mi_ip = new global::System.Windows.Forms.MenuItem();
			this.mi_transport = new global::System.Windows.Forms.MenuItem();
			this.mi_application = new global::System.Windows.Forms.MenuItem();
			this.mi_options = new global::System.Windows.Forms.MenuItem();
			this.mi_configOptions = new global::System.Windows.Forms.MenuItem();
			this.mi_sauverOptions = new global::System.Windows.Forms.MenuItem();
			this.mi_chargerOptions = new global::System.Windows.Forms.MenuItem();
			this.mi_tablesIp = new global::System.Windows.Forms.MenuItem();
			this.mi_viderCachesArp = new global::System.Windows.Forms.MenuItem();
			this.mi_remplirCachesArp = new global::System.Windows.Forms.MenuItem();
			this.mi_supprimerEchangesEnCours = new global::System.Windows.Forms.MenuItem();
			this.mi_interrogation = new global::System.Windows.Forms.MenuItem();
			this.mi_aPropos = new global::System.Windows.Forms.MenuItem();
			this.mi_aide = new global::System.Windows.Forms.MenuItem();
			this.infoBulle = new global::System.Windows.Forms.ToolTip(this.components);
			this.outils.SuspendLayout();
			this.panelApplication.SuspendLayout();
			this.panelReglagesAp.SuspendLayout();
			this.panelTrameAp.SuspendLayout();
			this.panelPaquetAp.SuspendLayout();
			this.panelMessageAp.SuspendLayout();
			this.panelEthernet.SuspendLayout();
			this.panelReglagesEthernet.SuspendLayout();
			this.panelTrameEthernet.SuspendLayout();
			this.panelIp.SuspendLayout();
			this.panelReglagesIp.SuspendLayout();
			this.panelTrameIp.SuspendLayout();
			this.panelPaquetIp.SuspendLayout();
			this.boutonsConception.SuspendLayout();
			this.schema.SuspendLayout();
			base.SuspendLayout();
			this.outils.BackColor = global::System.Drawing.SystemColors.Control;
			this.outils.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.outils.Controls.Add(this.panelApplication);
			this.outils.Controls.Add(this.panelEthernet);
			this.outils.Controls.Add(this.panelIp);
			this.outils.Controls.Add(this.boutonsConception);
			this.outils.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.outils.Location = new global::System.Drawing.Point(0, 0);
			this.outils.Name = "outils";
			this.outils.Size = new global::System.Drawing.Size(692, 40);
			this.outils.TabIndex = 0;
			this.panelApplication.BackColor = global::System.Drawing.SystemColors.Control;
			this.panelApplication.Controls.Add(this.bt_pauseRepriseAp);
			this.panelApplication.Controls.Add(this.panelReglagesAp);
			this.panelApplication.Controls.Add(this.bt_stopBisAp);
			this.panelApplication.Controls.Add(this.panelTrameAp);
			this.panelApplication.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panelApplication.Location = new global::System.Drawing.Point(0, 40);
			this.panelApplication.Name = "panelApplication";
			this.panelApplication.Size = new global::System.Drawing.Size(688, 0);
			this.panelApplication.TabIndex = 5;
			this.bt_pauseRepriseAp.Enabled = false;
			this.bt_pauseRepriseAp.ImageIndex = 0;
			this.bt_pauseRepriseAp.ImageList = this.il_pauseReprise;
			this.bt_pauseRepriseAp.Location = new global::System.Drawing.Point(623, 8);
			this.bt_pauseRepriseAp.Name = "bt_pauseRepriseAp";
			this.bt_pauseRepriseAp.Size = new global::System.Drawing.Size(22, 23);
			this.bt_pauseRepriseAp.TabIndex = 13;
			this.bt_pauseRepriseAp.TabStop = false;
			this.bt_pauseRepriseAp.Tag = "pause";
			this.il_pauseReprise.ImageSize = new global::System.Drawing.Size(16, 16);
			this.il_pauseReprise.ImageStream = (global::System.Windows.Forms.ImageListStreamer)resourceManager.GetObject("il_pauseReprise.ImageStream");
			this.il_pauseReprise.TransparentColor = global::System.Drawing.Color.White;
			this.panelReglagesAp.BackColor = global::System.Drawing.SystemColors.Control;
			this.panelReglagesAp.Controls.Add(this.cb_ralentiAp);
			this.panelReglagesAp.Controls.Add(this.cb_typeSimulAp);
			this.panelReglagesAp.Controls.Add(this.bt_tracerAp);
			this.panelReglagesAp.Controls.Add(this.label3);
			this.panelReglagesAp.Location = new global::System.Drawing.Point(0, 0);
			this.panelReglagesAp.Name = "panelReglagesAp";
			this.panelReglagesAp.Size = new global::System.Drawing.Size(622, 0);
			this.panelReglagesAp.TabIndex = 11;
			this.cb_ralentiAp.Location = new global::System.Drawing.Point(269, 12);
			this.cb_ralentiAp.Name = "cb_ralentiAp";
			this.cb_ralentiAp.Size = new global::System.Drawing.Size(84, 16);
			this.cb_ralentiAp.TabIndex = 13;
			this.cb_ralentiAp.Text = "Ralenti";
			this.cb_typeSimulAp.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_typeSimulAp.Enabled = false;
			this.cb_typeSimulAp.Items.AddRange(new object[]
			{
				"pas à pas",
				"automatique",
				"manuelle"
			});
			this.cb_typeSimulAp.Location = new global::System.Drawing.Point(109, 9);
			this.cb_typeSimulAp.Name = "cb_typeSimulAp";
			this.cb_typeSimulAp.Size = new global::System.Drawing.Size(130, 21);
			this.cb_typeSimulAp.TabIndex = 9;
			this.bt_tracerAp.Enabled = false;
			this.bt_tracerAp.Location = new global::System.Drawing.Point(496, 8);
			this.bt_tracerAp.Name = "bt_tracerAp";
			this.bt_tracerAp.Size = new global::System.Drawing.Size(110, 23);
			this.bt_tracerAp.TabIndex = 8;
			this.bt_tracerAp.Text = "aucun noeud tracé";
			this.label3.Location = new global::System.Drawing.Point(5, 12);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(115, 19);
			this.label3.TabIndex = 7;
			this.label3.Text = "Type de simulation";
			this.bt_stopBisAp.Enabled = false;
			this.bt_stopBisAp.Location = new global::System.Drawing.Point(649, 8);
			this.bt_stopBisAp.Name = "bt_stopBisAp";
			this.bt_stopBisAp.Size = new global::System.Drawing.Size(35, 23);
			this.bt_stopBisAp.TabIndex = 10;
			this.bt_stopBisAp.Text = "bis";
			this.panelTrameAp.BackColor = global::System.Drawing.SystemColors.Control;
			this.panelTrameAp.Controls.Add(this.panelPaquetAp);
			this.panelTrameAp.Controls.Add(this.lbl_typeAp);
			this.panelTrameAp.Location = new global::System.Drawing.Point(2, 3);
			this.panelTrameAp.Name = "panelTrameAp";
			this.panelTrameAp.Size = new global::System.Drawing.Size(617, 30);
			this.panelTrameAp.TabIndex = 8;
			this.panelPaquetAp.BackColor = global::System.Drawing.SystemColors.Control;
			this.panelPaquetAp.Controls.Add(this.panelMessageAp);
			this.panelPaquetAp.Controls.Add(this.lbl_ipSourceAp);
			this.panelPaquetAp.Controls.Add(this.lbl_ipDestAp);
			this.panelPaquetAp.Location = new global::System.Drawing.Point(36, 2);
			this.panelPaquetAp.Name = "panelPaquetAp";
			this.panelPaquetAp.Size = new global::System.Drawing.Size(579, 26);
			this.panelPaquetAp.TabIndex = 4;
			this.panelMessageAp.BackColor = global::System.Drawing.SystemColors.Control;
			this.panelMessageAp.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelMessageAp.Controls.Add(this.lbl_donneesAp);
			this.panelMessageAp.Location = new global::System.Drawing.Point(184, 2);
			this.panelMessageAp.Name = "panelMessageAp";
			this.panelMessageAp.Size = new global::System.Drawing.Size(393, 22);
			this.panelMessageAp.TabIndex = 14;
			this.lbl_donneesAp.BackColor = global::System.Drawing.SystemColors.Control;
			this.lbl_donneesAp.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbl_donneesAp.Location = new global::System.Drawing.Point(1, 1);
			this.lbl_donneesAp.Name = "lbl_donneesAp";
			this.lbl_donneesAp.Size = new global::System.Drawing.Size(389, 18);
			this.lbl_donneesAp.TabIndex = 12;
			this.lbl_donneesAp.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.lbl_ipSourceAp.BackColor = global::System.Drawing.SystemColors.Control;
			this.lbl_ipSourceAp.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbl_ipSourceAp.Location = new global::System.Drawing.Point(93, 2);
			this.lbl_ipSourceAp.Name = "lbl_ipSourceAp";
			this.lbl_ipSourceAp.Size = new global::System.Drawing.Size(92, 22);
			this.lbl_ipSourceAp.TabIndex = 13;
			this.lbl_ipSourceAp.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.lbl_ipDestAp.BackColor = global::System.Drawing.SystemColors.Control;
			this.lbl_ipDestAp.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbl_ipDestAp.Location = new global::System.Drawing.Point(2, 2);
			this.lbl_ipDestAp.Name = "lbl_ipDestAp";
			this.lbl_ipDestAp.Size = new global::System.Drawing.Size(92, 22);
			this.lbl_ipDestAp.TabIndex = 12;
			this.lbl_ipDestAp.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.lbl_typeAp.BackColor = global::System.Drawing.SystemColors.Control;
			this.lbl_typeAp.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbl_typeAp.Location = new global::System.Drawing.Point(1, 1);
			this.lbl_typeAp.Name = "lbl_typeAp";
			this.lbl_typeAp.Size = new global::System.Drawing.Size(35, 28);
			this.lbl_typeAp.TabIndex = 1;
			this.lbl_typeAp.Text = "IP";
			this.lbl_typeAp.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panelEthernet.BackColor = global::System.Drawing.SystemColors.Control;
			this.panelEthernet.Controls.Add(this.panelReglagesEthernet);
			this.panelEthernet.Controls.Add(this.bt_pauseReprise);
			this.panelEthernet.Controls.Add(this.panelTrameEthernet);
			this.panelEthernet.Controls.Add(this.bt_debugBis);
			this.panelEthernet.Controls.Add(this.bt_stopBis);
			this.panelEthernet.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panelEthernet.Location = new global::System.Drawing.Point(0, 40);
			this.panelEthernet.Name = "panelEthernet";
			this.panelEthernet.Size = new global::System.Drawing.Size(688, 0);
			this.panelEthernet.TabIndex = 1;
			this.panelReglagesEthernet.BackColor = global::System.Drawing.SystemColors.Control;
			this.panelReglagesEthernet.Controls.Add(this.cb_fullDuplex);
			this.panelReglagesEthernet.Controls.Add(this.cb_ralenti);
			this.panelReglagesEthernet.Controls.Add(this.cb_messageReception);
			this.panelReglagesEthernet.Controls.Add(this.cb_demoEmission);
			this.panelReglagesEthernet.Controls.Add(this.cb_typeDemo);
			this.panelReglagesEthernet.Controls.Add(this.bt_noeudsDemo);
			this.panelReglagesEthernet.Controls.Add(this.label1);
			this.panelReglagesEthernet.Location = new global::System.Drawing.Point(0, 0);
			this.panelReglagesEthernet.Name = "panelReglagesEthernet";
			this.panelReglagesEthernet.Size = new global::System.Drawing.Size(622, 36);
			this.panelReglagesEthernet.TabIndex = 5;
			this.cb_fullDuplex.Checked = true;
			this.cb_fullDuplex.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.cb_fullDuplex.Location = new global::System.Drawing.Point(220, 2);
			this.cb_fullDuplex.Name = "cb_fullDuplex";
			this.cb_fullDuplex.Size = new global::System.Drawing.Size(81, 16);
			this.cb_fullDuplex.TabIndex = 14;
			this.cb_fullDuplex.Text = "Full duplex";
			this.cb_fullDuplex.CheckedChanged += new global::System.EventHandler(this.cb_optionSimulation_CheckedChanged);
			this.cb_ralenti.Location = new global::System.Drawing.Point(220, 18);
			this.cb_ralenti.Name = "cb_ralenti";
			this.cb_ralenti.Size = new global::System.Drawing.Size(84, 16);
			this.cb_ralenti.TabIndex = 13;
			this.cb_ralenti.Text = "Ralenti";
			this.cb_ralenti.CheckedChanged += new global::System.EventHandler(this.cb_optionSimulation_CheckedChanged);
			this.cb_messageReception.Location = new global::System.Drawing.Point(341, 2);
			this.cb_messageReception.Name = "cb_messageReception";
			this.cb_messageReception.Size = new global::System.Drawing.Size(120, 16);
			this.cb_messageReception.TabIndex = 12;
			this.cb_messageReception.Text = "Message réception";
			this.cb_messageReception.CheckedChanged += new global::System.EventHandler(this.cb_optionSimulation_CheckedChanged);
			this.cb_demoEmission.Location = new global::System.Drawing.Point(341, 18);
			this.cb_demoEmission.Name = "cb_demoEmission";
			this.cb_demoEmission.Size = new global::System.Drawing.Size(120, 16);
			this.cb_demoEmission.TabIndex = 11;
			this.cb_demoEmission.Text = "Démo émission";
			this.cb_demoEmission.CheckedChanged += new global::System.EventHandler(this.cb_optionSimulation_CheckedChanged);
			this.cb_typeDemo.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_typeDemo.Items.AddRange(new object[]
			{
				"pas à pas",
				"automatique",
				"manuelle",
				"trame réelle"
			});
			this.cb_typeDemo.Location = new global::System.Drawing.Point(68, 9);
			this.cb_typeDemo.Name = "cb_typeDemo";
			this.cb_typeDemo.Size = new global::System.Drawing.Size(130, 21);
			this.cb_typeDemo.TabIndex = 9;
			this.cb_typeDemo.SelectedIndexChanged += new global::System.EventHandler(this.typeDemoChanged);
			this.bt_noeudsDemo.Location = new global::System.Drawing.Point(496, 8);
			this.bt_noeudsDemo.Name = "bt_noeudsDemo";
			this.bt_noeudsDemo.Size = new global::System.Drawing.Size(110, 23);
			this.bt_noeudsDemo.TabIndex = 8;
			this.bt_noeudsDemo.Text = "aucun noeud tracé";
			this.bt_noeudsDemo.Click += new global::System.EventHandler(this.bt_noeudsDemo_Click);
			this.label1.Location = new global::System.Drawing.Point(5, 4);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(60, 29);
			this.label1.TabIndex = 7;
			this.label1.Text = "Simulation Ethernet";
			this.bt_pauseReprise.Enabled = false;
			this.bt_pauseReprise.ImageIndex = 0;
			this.bt_pauseReprise.ImageList = this.il_pauseReprise;
			this.bt_pauseReprise.Location = new global::System.Drawing.Point(623, 8);
			this.bt_pauseReprise.Name = "bt_pauseReprise";
			this.bt_pauseReprise.Size = new global::System.Drawing.Size(22, 23);
			this.bt_pauseReprise.TabIndex = 12;
			this.bt_pauseReprise.TabStop = false;
			this.bt_pauseReprise.Tag = "pause";
			this.bt_pauseReprise.Click += new global::System.EventHandler(this.bt_pauseReprise_Click);
			this.panelTrameEthernet.BackColor = global::System.Drawing.SystemColors.Control;
			this.panelTrameEthernet.Controls.Add(this.lbl_donnees);
			this.panelTrameEthernet.Controls.Add(this.lbl_crc);
			this.panelTrameEthernet.Controls.Add(this.lbl_type);
			this.panelTrameEthernet.Controls.Add(this.lbl_emetteur);
			this.panelTrameEthernet.Controls.Add(this.lbl_destinataire);
			this.panelTrameEthernet.Controls.Add(this.lbl_preambule);
			this.panelTrameEthernet.Location = new global::System.Drawing.Point(2, 3);
			this.panelTrameEthernet.Name = "panelTrameEthernet";
			this.panelTrameEthernet.Size = new global::System.Drawing.Size(617, 30);
			this.panelTrameEthernet.TabIndex = 7;
			this.lbl_donnees.BackColor = global::System.Drawing.SystemColors.Control;
			this.lbl_donnees.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbl_donnees.Location = new global::System.Drawing.Point(209, 1);
			this.lbl_donnees.Name = "lbl_donnees";
			this.lbl_donnees.Size = new global::System.Drawing.Size(376, 28);
			this.lbl_donnees.TabIndex = 6;
			this.lbl_donnees.Text = "Données transportées par la trame";
			this.lbl_donnees.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lbl_crc.BackColor = global::System.Drawing.SystemColors.Control;
			this.lbl_crc.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbl_crc.Location = new global::System.Drawing.Point(584, 1);
			this.lbl_crc.Name = "lbl_crc";
			this.lbl_crc.Size = new global::System.Drawing.Size(32, 28);
			this.lbl_crc.TabIndex = 4;
			this.lbl_crc.Text = "CRC";
			this.lbl_crc.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lbl_type.BackColor = global::System.Drawing.SystemColors.Control;
			this.lbl_type.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbl_type.Location = new global::System.Drawing.Point(158, 1);
			this.lbl_type.Name = "lbl_type";
			this.lbl_type.Size = new global::System.Drawing.Size(52, 28);
			this.lbl_type.TabIndex = 3;
			this.lbl_type.Text = "Type";
			this.lbl_type.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lbl_emetteur.BackColor = global::System.Drawing.SystemColors.Control;
			this.lbl_emetteur.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbl_emetteur.Location = new global::System.Drawing.Point(111, 1);
			this.lbl_emetteur.Name = "lbl_emetteur";
			this.lbl_emetteur.Size = new global::System.Drawing.Size(48, 28);
			this.lbl_emetteur.TabIndex = 2;
			this.lbl_emetteur.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lbl_destinataire.BackColor = global::System.Drawing.SystemColors.Control;
			this.lbl_destinataire.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbl_destinataire.Location = new global::System.Drawing.Point(64, 1);
			this.lbl_destinataire.Name = "lbl_destinataire";
			this.lbl_destinataire.Size = new global::System.Drawing.Size(48, 28);
			this.lbl_destinataire.TabIndex = 1;
			this.lbl_destinataire.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lbl_preambule.BackColor = global::System.Drawing.SystemColors.Control;
			this.lbl_preambule.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbl_preambule.Location = new global::System.Drawing.Point(1, 1);
			this.lbl_preambule.Name = "lbl_preambule";
			this.lbl_preambule.Size = new global::System.Drawing.Size(64, 28);
			this.lbl_preambule.TabIndex = 0;
			this.lbl_preambule.Text = "Préambule";
			this.lbl_preambule.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.bt_debugBis.Location = new global::System.Drawing.Point(681, 8);
			this.bt_debugBis.Name = "bt_debugBis";
			this.bt_debugBis.Size = new global::System.Drawing.Size(7, 23);
			this.bt_debugBis.TabIndex = 6;
			this.bt_debugBis.Click += new global::System.EventHandler(this.bt_debugBis_Click);
			this.bt_stopBis.Enabled = false;
			this.bt_stopBis.Location = new global::System.Drawing.Point(649, 8);
			this.bt_stopBis.Name = "bt_stopBis";
			this.bt_stopBis.Size = new global::System.Drawing.Size(35, 23);
			this.bt_stopBis.TabIndex = 4;
			this.bt_stopBis.Text = "bis";
			this.bt_stopBis.Click += new global::System.EventHandler(this.bt_stopBis_Click);
			this.panelIp.BackColor = global::System.Drawing.SystemColors.Control;
			this.panelIp.Controls.Add(this.panelReglagesIp);
			this.panelIp.Controls.Add(this.panelTrameIp);
			this.panelIp.Controls.Add(this.bt_stopBisIp);
			this.panelIp.Controls.Add(this.bt_pauseRepriseIp);
			this.panelIp.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panelIp.Location = new global::System.Drawing.Point(0, 0);
			this.panelIp.Name = "panelIp";
			this.panelIp.Size = new global::System.Drawing.Size(688, 40);
			this.panelIp.TabIndex = 4;
			this.panelReglagesIp.BackColor = global::System.Drawing.SystemColors.Control;
			this.panelReglagesIp.Controls.Add(this.cb_statiques);
			this.panelReglagesIp.Controls.Add(this.cb_demoRoutageSeul);
			this.panelReglagesIp.Controls.Add(this.cb_trajetPaquet);
			this.panelReglagesIp.Controls.Add(this.lbl_trajetPaquet);
			this.panelReglagesIp.Controls.Add(this.cb_demoArp);
			this.panelReglagesIp.Controls.Add(this.cb_ralentiIp);
			this.panelReglagesIp.Controls.Add(this.cb_typeSimulIp);
			this.panelReglagesIp.Controls.Add(this.lbl_SimulIp);
			this.panelReglagesIp.Location = new global::System.Drawing.Point(0, 0);
			this.panelReglagesIp.Name = "panelReglagesIp";
			this.panelReglagesIp.Size = new global::System.Drawing.Size(622, 36);
			this.panelReglagesIp.TabIndex = 9;
			this.cb_statiques.Location = new global::System.Drawing.Point(308, 12);
			this.cb_statiques.Name = "cb_statiques";
			this.cb_statiques.Size = new global::System.Drawing.Size(140, 16);
			this.cb_statiques.TabIndex = 23;
			this.cb_statiques.Text = "Entrées ARP statiques";
			this.cb_demoRoutageSeul.Checked = true;
			this.cb_demoRoutageSeul.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.cb_demoRoutageSeul.Location = new global::System.Drawing.Point(308, 12);
			this.cb_demoRoutageSeul.Name = "cb_demoRoutageSeul";
			this.cb_demoRoutageSeul.Size = new global::System.Drawing.Size(136, 16);
			this.cb_demoRoutageSeul.TabIndex = 26;
			this.cb_demoRoutageSeul.Text = "Démo si routage seul";
			this.cb_trajetPaquet.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_trajetPaquet.Items.AddRange(new object[]
			{
				"chemin ethernet",
				"route IP"
			});
			this.cb_trajetPaquet.Location = new global::System.Drawing.Point(500, 9);
			this.cb_trajetPaquet.Name = "cb_trajetPaquet";
			this.cb_trajetPaquet.Size = new global::System.Drawing.Size(104, 21);
			this.cb_trajetPaquet.TabIndex = 24;
			this.lbl_trajetPaquet.Location = new global::System.Drawing.Point(452, 4);
			this.lbl_trajetPaquet.Name = "lbl_trajetPaquet";
			this.lbl_trajetPaquet.Size = new global::System.Drawing.Size(44, 28);
			this.lbl_trajetPaquet.TabIndex = 25;
			this.lbl_trajetPaquet.Text = "Trajet paquets";
			this.cb_demoArp.Checked = true;
			this.cb_demoArp.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.cb_demoArp.Location = new global::System.Drawing.Point(220, 2);
			this.cb_demoArp.Name = "cb_demoArp";
			this.cb_demoArp.Size = new global::System.Drawing.Size(83, 16);
			this.cb_demoArp.TabIndex = 15;
			this.cb_demoArp.Text = "Démo ARP";
			this.cb_demoArp.CheckedChanged += new global::System.EventHandler(this.cb_demoArp_CheckedChanged);
			this.cb_ralentiIp.Location = new global::System.Drawing.Point(220, 18);
			this.cb_ralentiIp.Name = "cb_ralentiIp";
			this.cb_ralentiIp.Size = new global::System.Drawing.Size(60, 16);
			this.cb_ralentiIp.TabIndex = 13;
			this.cb_ralentiIp.Text = "Ralenti";
			this.cb_ralentiIp.CheckedChanged += new global::System.EventHandler(this.cb_ralentiIp_CheckedChanged);
			this.cb_typeSimulIp.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_typeSimulIp.Items.AddRange(new object[]
			{
				"pas à pas",
				"automatique",
				"pas de démonstration",
				"manuelle"
			});
			this.cb_typeSimulIp.Location = new global::System.Drawing.Point(68, 9);
			this.cb_typeSimulIp.Name = "cb_typeSimulIp";
			this.cb_typeSimulIp.Size = new global::System.Drawing.Size(130, 21);
			this.cb_typeSimulIp.TabIndex = 9;
			this.cb_typeSimulIp.SelectedIndexChanged += new global::System.EventHandler(this.typeDemoIpChanged);
			this.lbl_SimulIp.Location = new global::System.Drawing.Point(5, 4);
			this.lbl_SimulIp.Name = "lbl_SimulIp";
			this.lbl_SimulIp.Size = new global::System.Drawing.Size(60, 29);
			this.lbl_SimulIp.TabIndex = 7;
			this.lbl_SimulIp.Text = "Simulation";
			this.panelTrameIp.BackColor = global::System.Drawing.SystemColors.Control;
			this.panelTrameIp.Controls.Add(this.lbl_typePaquet);
			this.panelTrameIp.Controls.Add(this.panelPaquetIp);
			this.panelTrameIp.Controls.Add(this.lbl_macSource);
			this.panelTrameIp.Controls.Add(this.lbl_macDest);
			this.panelTrameIp.Location = new global::System.Drawing.Point(2, 3);
			this.panelTrameIp.Name = "panelTrameIp";
			this.panelTrameIp.Size = new global::System.Drawing.Size(617, 40);
			this.panelTrameIp.TabIndex = 8;
			this.lbl_typePaquet.BackColor = global::System.Drawing.SystemColors.Control;
			this.lbl_typePaquet.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbl_typePaquet.Location = new global::System.Drawing.Point(83, 1);
			this.lbl_typePaquet.Name = "lbl_typePaquet";
			this.lbl_typePaquet.Size = new global::System.Drawing.Size(35, 28);
			this.lbl_typePaquet.TabIndex = 3;
			this.lbl_typePaquet.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panelPaquetIp.BackColor = global::System.Drawing.SystemColors.Control;
			this.panelPaquetIp.Controls.Add(this.lbl_ttlPaquet);
			this.panelPaquetIp.Controls.Add(this.lbl_IpSource);
			this.panelPaquetIp.Controls.Add(this.lbl_IpDest);
			this.panelPaquetIp.Controls.Add(this.lbl_donneesIp);
			this.panelPaquetIp.Location = new global::System.Drawing.Point(118, 2);
			this.panelPaquetIp.Name = "panelPaquetIp";
			this.panelPaquetIp.Size = new global::System.Drawing.Size(497, 26);
			this.panelPaquetIp.TabIndex = 4;
			this.lbl_ttlPaquet.BackColor = global::System.Drawing.SystemColors.Control;
			this.lbl_ttlPaquet.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbl_ttlPaquet.Location = new global::System.Drawing.Point(2, 2);
			this.lbl_ttlPaquet.Name = "lbl_ttlPaquet";
			this.lbl_ttlPaquet.Size = new global::System.Drawing.Size(20, 22);
			this.lbl_ttlPaquet.TabIndex = 14;
			this.lbl_ttlPaquet.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lbl_IpSource.BackColor = global::System.Drawing.SystemColors.Control;
			this.lbl_IpSource.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbl_IpSource.Location = new global::System.Drawing.Point(21, 2);
			this.lbl_IpSource.Name = "lbl_IpSource";
			this.lbl_IpSource.Size = new global::System.Drawing.Size(92, 22);
			this.lbl_IpSource.TabIndex = 13;
			this.lbl_IpSource.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.lbl_IpDest.BackColor = global::System.Drawing.SystemColors.Control;
			this.lbl_IpDest.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbl_IpDest.Location = new global::System.Drawing.Point(112, 2);
			this.lbl_IpDest.Name = "lbl_IpDest";
			this.lbl_IpDest.Size = new global::System.Drawing.Size(92, 22);
			this.lbl_IpDest.TabIndex = 12;
			this.lbl_IpDest.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.lbl_donneesIp.BackColor = global::System.Drawing.SystemColors.Control;
			this.lbl_donneesIp.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbl_donneesIp.Location = new global::System.Drawing.Point(203, 2);
			this.lbl_donneesIp.Name = "lbl_donneesIp";
			this.lbl_donneesIp.Size = new global::System.Drawing.Size(292, 22);
			this.lbl_donneesIp.TabIndex = 10;
			this.lbl_donneesIp.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.lbl_macSource.BackColor = global::System.Drawing.SystemColors.Control;
			this.lbl_macSource.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbl_macSource.Location = new global::System.Drawing.Point(42, 1);
			this.lbl_macSource.Name = "lbl_macSource";
			this.lbl_macSource.Size = new global::System.Drawing.Size(42, 28);
			this.lbl_macSource.TabIndex = 2;
			this.lbl_macSource.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lbl_macDest.BackColor = global::System.Drawing.SystemColors.Control;
			this.lbl_macDest.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbl_macDest.Location = new global::System.Drawing.Point(1, 1);
			this.lbl_macDest.Name = "lbl_macDest";
			this.lbl_macDest.Size = new global::System.Drawing.Size(42, 28);
			this.lbl_macDest.TabIndex = 1;
			this.lbl_macDest.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.bt_stopBisIp.Enabled = false;
			this.bt_stopBisIp.Location = new global::System.Drawing.Point(649, 8);
			this.bt_stopBisIp.Name = "bt_stopBisIp";
			this.bt_stopBisIp.Size = new global::System.Drawing.Size(35, 23);
			this.bt_stopBisIp.TabIndex = 10;
			this.bt_stopBisIp.TabStop = false;
			this.bt_stopBisIp.Text = "bis";
			this.bt_stopBisIp.Click += new global::System.EventHandler(this.bt_stopBisIp_Click);
			this.bt_pauseRepriseIp.Enabled = false;
			this.bt_pauseRepriseIp.ImageIndex = 0;
			this.bt_pauseRepriseIp.ImageList = this.il_pauseReprise;
			this.bt_pauseRepriseIp.Location = new global::System.Drawing.Point(623, 8);
			this.bt_pauseRepriseIp.Name = "bt_pauseRepriseIp";
			this.bt_pauseRepriseIp.Size = new global::System.Drawing.Size(22, 23);
			this.bt_pauseRepriseIp.TabIndex = 11;
			this.bt_pauseRepriseIp.TabStop = false;
			this.bt_pauseRepriseIp.Tag = "pause";
			this.bt_pauseRepriseIp.Click += new global::System.EventHandler(this.bt_pauseRepriseIp_Click);
			this.boutonsConception.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.boutonsConception.Controls.Add(this.rb_internet);
			this.boutonsConception.Controls.Add(this.rb_switch);
			this.boutonsConception.Controls.Add(this.rb_cable);
			this.boutonsConception.Controls.Add(this.rb_hub);
			this.boutonsConception.Controls.Add(this.rb_station);
			this.boutonsConception.Controls.Add(this.rb_fleche);
			this.boutonsConception.Location = new global::System.Drawing.Point(2, -4);
			this.boutonsConception.Name = "boutonsConception";
			this.boutonsConception.Size = new global::System.Drawing.Size(270, 40);
			this.boutonsConception.TabIndex = 0;
			this.boutonsConception.TabStop = false;
			this.rb_internet.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.rb_internet.ImageIndex = 5;
			this.rb_internet.ImageList = this.il_composants;
			this.rb_internet.Location = new global::System.Drawing.Point(224, 9);
			this.rb_internet.Name = "rb_internet";
			this.rb_internet.Size = new global::System.Drawing.Size(41, 27);
			this.rb_internet.TabIndex = 5;
			this.rb_internet.Click += new global::System.EventHandler(this.rb_internet_Click);
			this.il_composants.ImageSize = new global::System.Drawing.Size(27, 16);
			this.il_composants.ImageStream = (global::System.Windows.Forms.ImageListStreamer)resourceManager.GetObject("il_composants.ImageStream");
			this.il_composants.TransparentColor = global::System.Drawing.Color.White;
			this.rb_switch.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.rb_switch.ImageIndex = 4;
			this.rb_switch.ImageList = this.il_composants;
			this.rb_switch.Location = new global::System.Drawing.Point(180, 9);
			this.rb_switch.Name = "rb_switch";
			this.rb_switch.Size = new global::System.Drawing.Size(41, 27);
			this.rb_switch.TabIndex = 4;
			this.rb_switch.Click += new global::System.EventHandler(this.rb_switch_Click);
			this.rb_cable.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.rb_cable.ImageIndex = 1;
			this.rb_cable.ImageList = this.il_composants;
			this.rb_cable.Location = new global::System.Drawing.Point(48, 9);
			this.rb_cable.Name = "rb_cable";
			this.rb_cable.Size = new global::System.Drawing.Size(41, 27);
			this.rb_cable.TabIndex = 3;
			this.rb_cable.Click += new global::System.EventHandler(this.rb_cable_Click);
			this.rb_hub.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.rb_hub.ImageIndex = 3;
			this.rb_hub.ImageList = this.il_composants;
			this.rb_hub.Location = new global::System.Drawing.Point(136, 9);
			this.rb_hub.Name = "rb_hub";
			this.rb_hub.Size = new global::System.Drawing.Size(41, 27);
			this.rb_hub.TabIndex = 2;
			this.rb_hub.Click += new global::System.EventHandler(this.rb_hub_Click);
			this.rb_station.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.rb_station.ImageIndex = 2;
			this.rb_station.ImageList = this.il_composants;
			this.rb_station.Location = new global::System.Drawing.Point(92, 9);
			this.rb_station.Name = "rb_station";
			this.rb_station.Size = new global::System.Drawing.Size(41, 27);
			this.rb_station.TabIndex = 1;
			this.rb_station.Click += new global::System.EventHandler(this.rb_station_Click);
			this.rb_fleche.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.rb_fleche.Checked = true;
			this.rb_fleche.ImageIndex = 0;
			this.rb_fleche.ImageList = this.il_composants;
			this.rb_fleche.Location = new global::System.Drawing.Point(4, 9);
			this.rb_fleche.Name = "rb_fleche";
			this.rb_fleche.Size = new global::System.Drawing.Size(41, 27);
			this.rb_fleche.TabIndex = 0;
			this.rb_fleche.TabStop = true;
			this.rb_fleche.Click += new global::System.EventHandler(this.rb_fleche_Click);
			this.schema.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.schema.BackColor = global::System.Drawing.SystemColors.Control;
			this.schema.Controls.Add(this.iconeMessage);
			this.schema.Location = new global::System.Drawing.Point(0, 40);
			this.schema.Name = "schema";
			this.schema.Size = new global::System.Drawing.Size(692, 413);
			this.schema.TabIndex = 1;
			this.schema.Paint += new global::System.Windows.Forms.PaintEventHandler(this.schema_Paint);
			this.schema.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.schema_MouseMove);
			this.schema.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.schema_MouseDown);
			this.iconeMessage.Demo = null;
			this.iconeMessage.Location = new global::System.Drawing.Point(322, 152);
			this.iconeMessage.Longueur = 0;
			this.iconeMessage.Name = "iconeMessage";
			this.iconeMessage.Size = new global::System.Drawing.Size(22, 18);
			this.iconeMessage.StyloRelief = null;
			this.iconeMessage.TabIndex = 0;
			this.iconeMessage.Visible = false;
			this.gereDoc.Extension = "xml";
			this.gereDoc.Filtre = "fichiers xml|*.xml";
			this.gereDoc.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
			{
				this.mi_mode,
				this.mi_options,
				this.mi_tablesIp,
				this.mi_interrogation
			});
			this.mi_mode.Index = 0;
			this.mi_mode.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
			{
				this.mi_conceptionReseau,
				this.mi_ethernet,
				this.mi_ip,
				this.mi_transport,
				this.mi_application
			});
			this.mi_mode.Text = "Mode";
			this.mi_conceptionReseau.Checked = true;
			this.mi_conceptionReseau.Index = 0;
			this.mi_conceptionReseau.Shortcut = global::System.Windows.Forms.Shortcut.F2;
			this.mi_conceptionReseau.Text = "Conception réseau";
			this.mi_conceptionReseau.Click += new global::System.EventHandler(this.mi_conceptionReseau_Click);
			this.mi_ethernet.Index = 1;
			this.mi_ethernet.Shortcut = global::System.Windows.Forms.Shortcut.F3;
			this.mi_ethernet.Text = "Ethernet";
			this.mi_ethernet.Click += new global::System.EventHandler(this.mi_ethernet_Click);
			this.mi_ip.Index = 2;
			this.mi_ip.Shortcut = global::System.Windows.Forms.Shortcut.F4;
			this.mi_ip.Text = "IP";
			this.mi_ip.Click += new global::System.EventHandler(this.mi_ip_Click);
			this.mi_transport.Index = 3;
			this.mi_transport.Shortcut = global::System.Windows.Forms.Shortcut.F5;
			this.mi_transport.Text = "Transport";
			this.mi_transport.Click += new global::System.EventHandler(this.mi_transport_Click);
			this.mi_application.Enabled = false;
			this.mi_application.Index = 4;
			this.mi_application.Shortcut = global::System.Windows.Forms.Shortcut.F6;
			this.mi_application.Text = "Application";
			this.mi_application.Visible = false;
			this.mi_application.Click += new global::System.EventHandler(this.mi_application_Click);
			this.mi_options.Index = 1;
			this.mi_options.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
			{
				this.mi_configOptions,
				this.mi_sauverOptions,
				this.mi_chargerOptions
			});
			this.mi_options.Text = "Options";
			this.mi_configOptions.Index = 0;
			this.mi_configOptions.Text = "Configurer";
			this.mi_configOptions.Click += new global::System.EventHandler(this.mi_options_Click);
			this.mi_sauverOptions.Index = 1;
			this.mi_sauverOptions.Text = "Sauvegarder";
			this.mi_sauverOptions.Click += new global::System.EventHandler(this.mi_sauverOptions_Click);
			this.mi_chargerOptions.Index = 2;
			this.mi_chargerOptions.Text = "Charger";
			this.mi_chargerOptions.Click += new global::System.EventHandler(this.mi_chargerOptions_Click);
			this.mi_tablesIp.Index = 2;
			this.mi_tablesIp.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
			{
				this.mi_viderCachesArp,
				this.mi_remplirCachesArp,
				this.mi_supprimerEchangesEnCours
			});
			this.mi_tablesIp.Text = "Tables";
			this.mi_tablesIp.Visible = false;
			this.mi_viderCachesArp.Index = 0;
			this.mi_viderCachesArp.Text = "Vider les caches ARP";
			this.mi_viderCachesArp.Click += new global::System.EventHandler(this.mi_viderCachesArp_Click);
			this.mi_remplirCachesArp.Index = 1;
			this.mi_remplirCachesArp.Text = "Remplir les caches ARP";
			this.mi_remplirCachesArp.Click += new global::System.EventHandler(this.mi_remplirCachesArp_Click);
			this.mi_supprimerEchangesEnCours.Index = 2;
			this.mi_supprimerEchangesEnCours.Text = "Supprimer les échanges en cours";
			this.mi_supprimerEchangesEnCours.Click += new global::System.EventHandler(this.mi_supprimerEchangesEnCours_Click);
			this.mi_interrogation.Index = 3;
			this.mi_interrogation.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
			{
				this.mi_aPropos,
				this.mi_aide
			});
			this.mi_interrogation.Text = "?";
			this.mi_aPropos.Index = 0;
			this.mi_aPropos.Text = "A propos";
			this.mi_aPropos.Click += new global::System.EventHandler(this.mi_aPropos_Click);
			this.mi_aide.Index = 1;
			this.mi_aide.Shortcut = global::System.Windows.Forms.Shortcut.F1;
			this.mi_aide.Text = "Aide";
			this.mi_aide.Click += new global::System.EventHandler(this.mi_aide_Click);
			this.infoBulle.AutomaticDelay = 1;
			this.infoBulle.AutoPopDelay = 2500;
			this.infoBulle.InitialDelay = 1;
			this.infoBulle.ReshowDelay = 0;
			this.infoBulle.ShowAlways = true;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(692, 453);
			base.Controls.Add(this.schema);
			base.Controls.Add(this.outils);
			base.Menu = this.gereDoc;
			base.Name = "Simulation";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Simulateur Réseau 2.0 (réseau non enregistré)";
			this.outils.ResumeLayout(false);
			this.panelApplication.ResumeLayout(false);
			this.panelReglagesAp.ResumeLayout(false);
			this.panelTrameAp.ResumeLayout(false);
			this.panelPaquetAp.ResumeLayout(false);
			this.panelMessageAp.ResumeLayout(false);
			this.panelEthernet.ResumeLayout(false);
			this.panelReglagesEthernet.ResumeLayout(false);
			this.panelTrameEthernet.ResumeLayout(false);
			this.panelIp.ResumeLayout(false);
			this.panelReglagesIp.ResumeLayout(false);
			this.panelTrameIp.ResumeLayout(false);
			this.panelPaquetIp.ResumeLayout(false);
			this.boutonsConception.ResumeLayout(false);
			this.schema.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040004D0 RID: 1232
		private global::System.Windows.Forms.ImageList il_composants;

		// Token: 0x040004D1 RID: 1233
		private global::System.Windows.Forms.Panel schema;

		// Token: 0x040004D2 RID: 1234
		private global::System.Windows.Forms.RadioButton rb_hub;

		// Token: 0x040004D3 RID: 1235
		private global::System.Windows.Forms.RadioButton rb_station;

		// Token: 0x040004D4 RID: 1236
		private global::System.Windows.Forms.RadioButton rb_fleche;

		// Token: 0x040004D5 RID: 1237
		private global::System.Windows.Forms.RadioButton rb_cable;

		// Token: 0x040004D6 RID: 1238
		private global::System.Windows.Forms.Panel outils;

		// Token: 0x040004D7 RID: 1239
		private global::System.Windows.Forms.GroupBox boutonsConception;

		// Token: 0x040004D8 RID: 1240
		private global::System.Windows.Forms.Panel panelEthernet;

		// Token: 0x040004D9 RID: 1241
		private global::System.Windows.Forms.Panel panelReglagesEthernet;

		// Token: 0x040004DA RID: 1242
		private global::System.Windows.Forms.ComboBox cb_typeDemo;

		// Token: 0x040004DB RID: 1243
		private global::System.Windows.Forms.Button bt_noeudsDemo;

		// Token: 0x040004DC RID: 1244
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040004DD RID: 1245
		private global::System.Windows.Forms.RadioButton rb_switch;

		// Token: 0x040004DE RID: 1246
		private global::System.Windows.Forms.CheckBox cb_demoEmission;

		// Token: 0x040004DF RID: 1247
		private global::System.Windows.Forms.CheckBox cb_messageReception;

		// Token: 0x040004E0 RID: 1248
		private global::Simulateur.GestionDocument gereDoc;

		// Token: 0x040004E1 RID: 1249
		private global::System.Windows.Forms.MenuItem mi_mode;

		// Token: 0x040004E2 RID: 1250
		private global::System.Windows.Forms.MenuItem mi_conceptionReseau;

		// Token: 0x040004E3 RID: 1251
		private global::System.Windows.Forms.MenuItem mi_ethernet;

		// Token: 0x040004E4 RID: 1252
		private global::System.Windows.Forms.MenuItem mi_options;

		// Token: 0x040004E5 RID: 1253
		private global::System.Windows.Forms.MenuItem mi_configOptions;

		// Token: 0x040004E6 RID: 1254
		private global::System.Windows.Forms.MenuItem mi_sauverOptions;

		// Token: 0x040004E7 RID: 1255
		private global::System.Windows.Forms.MenuItem mi_chargerOptions;

		// Token: 0x040004E8 RID: 1256
		private global::System.Windows.Forms.MenuItem mi_aPropos;

		// Token: 0x040004E9 RID: 1257
		private global::System.Windows.Forms.CheckBox cb_fullDuplex;

		// Token: 0x040004EA RID: 1258
		private global::System.Windows.Forms.CheckBox cb_ralenti;

		// Token: 0x040004EB RID: 1259
		private global::System.Windows.Forms.Button bt_stopBis;

		// Token: 0x040004EC RID: 1260
		private global::System.Windows.Forms.Button bt_debugBis;

		// Token: 0x040004ED RID: 1261
		private global::System.Windows.Forms.MenuItem mi_aide;

		// Token: 0x040004EE RID: 1262
		private global::System.Windows.Forms.Panel panelTrameEthernet;

		// Token: 0x040004EF RID: 1263
		private global::System.Windows.Forms.Label lbl_preambule;

		// Token: 0x040004F0 RID: 1264
		private global::System.Windows.Forms.Label lbl_crc;

		// Token: 0x040004F1 RID: 1265
		private global::System.Windows.Forms.Label lbl_emetteur;

		// Token: 0x040004F2 RID: 1266
		private global::System.Windows.Forms.Label lbl_destinataire;

		// Token: 0x040004F3 RID: 1267
		private global::System.Windows.Forms.Label lbl_donnees;

		// Token: 0x040004F4 RID: 1268
		private global::System.Windows.Forms.Panel panelIp;

		// Token: 0x040004F5 RID: 1269
		private global::System.Windows.Forms.MenuItem mi_ip;

		// Token: 0x040004F6 RID: 1270
		private global::System.Windows.Forms.MenuItem mi_interrogation;

		// Token: 0x040004F7 RID: 1271
		private global::System.Windows.Forms.Label lbl_type;

		// Token: 0x040004F8 RID: 1272
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040004F9 RID: 1273
		private global::System.Windows.Forms.Panel panelTrameIp;

		// Token: 0x040004FA RID: 1274
		private global::System.Windows.Forms.Label lbl_typePaquet;

		// Token: 0x040004FB RID: 1275
		private global::System.Windows.Forms.Label lbl_macSource;

		// Token: 0x040004FC RID: 1276
		private global::System.Windows.Forms.Label lbl_macDest;

		// Token: 0x040004FD RID: 1277
		private global::System.Windows.Forms.Panel panelPaquetIp;

		// Token: 0x040004FE RID: 1278
		private global::System.Windows.Forms.Label lbl_donneesIp;

		// Token: 0x040004FF RID: 1279
		private global::System.Windows.Forms.Panel panelReglagesIp;

		// Token: 0x04000500 RID: 1280
		private global::System.Windows.Forms.CheckBox cb_ralentiIp;

		// Token: 0x04000501 RID: 1281
		private global::System.Windows.Forms.ComboBox cb_typeSimulIp;

		// Token: 0x04000502 RID: 1282
		private global::System.Windows.Forms.Button bt_stopBisIp;

		// Token: 0x04000503 RID: 1283
		private global::System.Windows.Forms.Label lbl_IpDest;

		// Token: 0x04000504 RID: 1284
		private global::System.Windows.Forms.Label lbl_IpSource;

		// Token: 0x04000505 RID: 1285
		private global::System.Windows.Forms.MenuItem mi_application;

		// Token: 0x04000506 RID: 1286
		private global::System.Windows.Forms.Panel panelApplication;

		// Token: 0x04000507 RID: 1287
		private global::System.Windows.Forms.Button bt_stopBisAp;

		// Token: 0x04000508 RID: 1288
		private global::System.Windows.Forms.Panel panelTrameAp;

		// Token: 0x04000509 RID: 1289
		private global::System.Windows.Forms.Panel panelPaquetAp;

		// Token: 0x0400050A RID: 1290
		private global::System.Windows.Forms.Label lbl_ipSourceAp;

		// Token: 0x0400050B RID: 1291
		private global::System.Windows.Forms.Label lbl_ipDestAp;

		// Token: 0x0400050C RID: 1292
		private global::System.Windows.Forms.Label lbl_typeAp;

		// Token: 0x0400050D RID: 1293
		private global::System.Windows.Forms.Panel panelMessageAp;

		// Token: 0x0400050E RID: 1294
		private global::System.Windows.Forms.Label lbl_donneesAp;

		// Token: 0x0400050F RID: 1295
		private global::System.Windows.Forms.Panel panelReglagesAp;

		// Token: 0x04000510 RID: 1296
		private global::System.Windows.Forms.CheckBox cb_ralentiAp;

		// Token: 0x04000511 RID: 1297
		private global::System.Windows.Forms.ComboBox cb_typeSimulAp;

		// Token: 0x04000512 RID: 1298
		private global::System.Windows.Forms.Button bt_tracerAp;

		// Token: 0x04000513 RID: 1299
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000514 RID: 1300
		private global::Simulateur.Ap_Message iconeMessage;

		// Token: 0x04000515 RID: 1301
		private global::System.Windows.Forms.CheckBox cb_demoArp;

		// Token: 0x04000516 RID: 1302
		private global::System.Windows.Forms.Label lbl_ttlPaquet;

		// Token: 0x04000517 RID: 1303
		private global::System.Windows.Forms.ToolTip infoBulle;

		// Token: 0x04000518 RID: 1304
		private global::System.Windows.Forms.RadioButton rb_internet;

		// Token: 0x04000519 RID: 1305
		private global::System.Windows.Forms.MenuItem mi_tablesIp;

		// Token: 0x0400051A RID: 1306
		private global::System.Windows.Forms.MenuItem mi_viderCachesArp;

		// Token: 0x0400051B RID: 1307
		private global::System.Windows.Forms.MenuItem mi_remplirCachesArp;

		// Token: 0x0400051C RID: 1308
		private global::System.Windows.Forms.MenuItem mi_supprimerEchangesEnCours;

		// Token: 0x0400051D RID: 1309
		private global::System.Windows.Forms.CheckBox cb_statiques;

		// Token: 0x0400051E RID: 1310
		private global::System.Windows.Forms.ImageList il_pauseReprise;

		// Token: 0x0400051F RID: 1311
		private global::System.Windows.Forms.Button bt_pauseRepriseIp;

		// Token: 0x04000520 RID: 1312
		private global::System.Windows.Forms.Button bt_pauseReprise;

		// Token: 0x04000521 RID: 1313
		private global::System.Windows.Forms.Button bt_pauseRepriseAp;

		// Token: 0x04000522 RID: 1314
		private global::System.Windows.Forms.MenuItem mi_transport;

		// Token: 0x04000523 RID: 1315
		private global::System.Windows.Forms.Label lbl_SimulIp;

		// Token: 0x04000524 RID: 1316
		private global::System.Windows.Forms.ComboBox cb_trajetPaquet;

		// Token: 0x04000525 RID: 1317
		private global::System.Windows.Forms.Label lbl_trajetPaquet;

		// Token: 0x04000526 RID: 1318
		private global::System.Windows.Forms.CheckBox cb_demoRoutageSeul;
	}
}
