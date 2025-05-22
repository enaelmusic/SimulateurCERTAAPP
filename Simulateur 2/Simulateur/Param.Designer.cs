namespace Simulateur
{
	// Token: 0x0200006A RID: 106
	public partial class Param : global::System.Windows.Forms.Form
	{
		// Token: 0x06000604 RID: 1540 RVA: 0x0003D3AC File Offset: 0x0003C3AC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x0003D3D8 File Offset: 0x0003C3D8
		private void InitializeComponent()
		{
			this.tc_onglets = new global::Simulateur.TabParam();
			this.tp_conception = new global::System.Windows.Forms.TabPage();
			this.p_traitsEpais = new global::Simulateur.ParamBool();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.p_niveauVlanSwitch = new global::Simulateur.ParamNumericUpDown();
			this.p_nbPorts8021qSwitch = new global::Simulateur.ParamNumericUpDown();
			this.p_spanningTree = new global::Simulateur.ParamBool();
			this.p_storeAndForward = new global::Simulateur.ParamBool();
			this.p_surbrillancePointConnexion = new global::Simulateur.ParamCouleur();
			this.p_couleurConnexionConception = new global::Simulateur.ParamCouleur();
			this.p_longueurCableMax = new global::Simulateur.ParamNumericUpDown();
			this.p_selectionStylo = new global::Simulateur.ParamCouleur();
			this.p_longueurCableDefaut = new global::Simulateur.ParamNumericUpDown();
			this.p_nbPortsCascadeSwitch = new global::Simulateur.ParamNumericUpDown();
			this.p_nbPortsSwitch = new global::Simulateur.ParamNumericUpDown();
			this.p_nbPortsCascadeHub = new global::Simulateur.ParamNumericUpDown();
			this.p_normalStylo = new global::Simulateur.ParamCouleur();
			this.p_nbPortsHub = new global::Simulateur.ParamNumericUpDown();
			this.tp_ethernet = new global::System.Windows.Forms.TabPage();
			this.p_annonceStations = new global::Simulateur.ParamBool();
			this.p_stylo8021q = new global::Simulateur.ParamCouleur();
			this.p_delaiReemissionW = new global::Simulateur.ParamNumericUpDown();
			this.p_delaiReemissionZ = new global::Simulateur.ParamNumericUpDown();
			this.p_delaiReemissionY = new global::Simulateur.ParamNumericUpDown();
			this.p_delaiReemissionX = new global::Simulateur.ParamNumericUpDown();
			this.lbl_delaiReemission = new global::System.Windows.Forms.Label();
			this.p_tauxRalenti = new global::Simulateur.ParamNumericUpDown();
			this.p_tempsInterTrames = new global::Simulateur.ParamNumericUpDown();
			this.p_couleurBloqueEthernet = new global::Simulateur.ParamCouleur();
			this.p_nbMetresParTick = new global::Simulateur.ParamNumericUpDown();
			this.p_tempsDelaiTransmissionSwitch = new global::Simulateur.ParamNumericUpDown();
			this.p_coefEmissionTrameLongue = new global::Simulateur.ParamNumericUpDown();
			this.p_tempsDelaiTransmissionHub = new global::Simulateur.ParamNumericUpDown();
			this.p_coefEmissionTrameCourte = new global::Simulateur.ParamNumericUpDown();
			this.p_tempsEmissionTrame = new global::Simulateur.ParamNumericUpDown();
			this.p_tempsAttenteEcoute = new global::Simulateur.ParamNumericUpDown();
			this.p_tempsAttenteDemoDefaut = new global::Simulateur.ParamNumericUpDown();
			this.p_traceParDefaut = new global::Simulateur.ParamBool();
			this.p_couleurErreurEthernet = new global::Simulateur.ParamCouleur();
			this.p_couleurActifEthernet = new global::Simulateur.ParamCouleur();
			this.p_couleurAllumeEthernet = new global::Simulateur.ParamCouleur();
			this.p_cableActifStylo2 = new global::Simulateur.ParamCouleur();
			this.p_cableActifStylo1 = new global::Simulateur.ParamCouleur();
			this.p_styloCollision = new global::Simulateur.ParamCouleur();
			this.tp_tcpIp = new global::System.Windows.Forms.TabPage();
			this.p_icones = new global::Simulateur.ParamBool();
			this.p_cachesArpAutoIp = new global::Simulateur.ParamBool();
			this.p_demoInternet = new global::Simulateur.ParamBool();
			this.p_cheminPaquet = new global::Simulateur.ParamListe();
			this.p_nbSautsMax = new global::Simulateur.ParamNumericUpDown();
			this.p_attentePing = new global::Simulateur.ParamNumericUpDown();
			this.p_ttlCacheArp = new global::Simulateur.ParamNumericUpDown();
			this.p_trameModeIp = new global::Simulateur.ParamBool();
			this.p_longueurRoute = new global::Simulateur.ParamNumericUpDown();
			this.p_styloPaquet = new global::Simulateur.ParamCouleur();
			this.bt_restaurerDefaut = new global::System.Windows.Forms.Button();
			this.bc_sauvegarder = new global::System.Windows.Forms.Button();
			this.bt_charger = new global::System.Windows.Forms.Button();
			this.bt_fermer = new global::System.Windows.Forms.Button();
			this.sd_enregistrer = new global::System.Windows.Forms.SaveFileDialog();
			this.od_ouvrir = new global::System.Windows.Forms.OpenFileDialog();
			this.p_memoriserPosition = new global::Simulateur.ParamBool();
			this.tc_onglets.SuspendLayout();
			this.tp_conception.SuspendLayout();
			this.tp_ethernet.SuspendLayout();
			this.tp_tcpIp.SuspendLayout();
			base.SuspendLayout();
			this.tc_onglets.Controls.Add(this.tp_conception);
			this.tc_onglets.Controls.Add(this.tp_ethernet);
			this.tc_onglets.Controls.Add(this.tp_tcpIp);
			this.tc_onglets.Location = new global::System.Drawing.Point(8, 8);
			this.tc_onglets.Name = "tc_onglets";
			this.tc_onglets.SelectedIndex = 0;
			this.tc_onglets.Size = new global::System.Drawing.Size(488, 376);
			this.tc_onglets.TabIndex = 67;
			this.tc_onglets.TitreXml = "paramSimulateur1.0";
			this.tp_conception.Controls.Add(this.p_memoriserPosition);
			this.tp_conception.Controls.Add(this.p_traitsEpais);
			this.tp_conception.Controls.Add(this.label2);
			this.tp_conception.Controls.Add(this.label1);
			this.tp_conception.Controls.Add(this.p_niveauVlanSwitch);
			this.tp_conception.Controls.Add(this.p_nbPorts8021qSwitch);
			this.tp_conception.Controls.Add(this.p_spanningTree);
			this.tp_conception.Controls.Add(this.p_storeAndForward);
			this.tp_conception.Controls.Add(this.p_surbrillancePointConnexion);
			this.tp_conception.Controls.Add(this.p_couleurConnexionConception);
			this.tp_conception.Controls.Add(this.p_longueurCableMax);
			this.tp_conception.Controls.Add(this.p_selectionStylo);
			this.tp_conception.Controls.Add(this.p_longueurCableDefaut);
			this.tp_conception.Controls.Add(this.p_nbPortsCascadeSwitch);
			this.tp_conception.Controls.Add(this.p_nbPortsSwitch);
			this.tp_conception.Controls.Add(this.p_nbPortsCascadeHub);
			this.tp_conception.Controls.Add(this.p_normalStylo);
			this.tp_conception.Controls.Add(this.p_nbPortsHub);
			this.tp_conception.Location = new global::System.Drawing.Point(4, 22);
			this.tp_conception.Name = "tp_conception";
			this.tp_conception.Size = new global::System.Drawing.Size(480, 350);
			this.tp_conception.TabIndex = 0;
			this.tp_conception.Text = "Conception/Divers";
			this.p_traitsEpais.Label = "Utiliser des Traits épais";
			this.p_traitsEpais.Location = new global::System.Drawing.Point(16, 296);
			this.p_traitsEpais.Name = "p_traitsEpais";
			this.p_traitsEpais.Size = new global::System.Drawing.Size(208, 24);
			this.p_traitsEpais.TabIndex = 97;
			this.p_traitsEpais.Valeur = false;
			this.p_traitsEpais.ValeurDefaut = false;
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(16, 272);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(48, 16);
			this.label2.TabIndex = 96;
			this.label2.Text = "Divers";
			this.label1.Location = new global::System.Drawing.Point(240, 236);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(100, 16);
			this.label1.TabIndex = 95;
			this.label1.Text = "(0 : non géré)";
			global::Simulateur.ParamNumericUpDown paramNumericUpDown = this.p_niveauVlanSwitch;
			int[] array = new int[4];
			array[0] = 1;
			paramNumericUpDown.Increment = new decimal(array);
			this.p_niveauVlanSwitch.Label = "Niveau Vlan d'un switch";
			this.p_niveauVlanSwitch.Location = new global::System.Drawing.Point(16, 232);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown2 = this.p_niveauVlanSwitch;
			array = new int[4];
			array[0] = 2;
			paramNumericUpDown2.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown3 = this.p_niveauVlanSwitch;
			array = new int[4];
			paramNumericUpDown3.Minimum = new decimal(array);
			this.p_niveauVlanSwitch.Name = "p_niveauVlanSwitch";
			this.p_niveauVlanSwitch.NbDecimales = 0;
			this.p_niveauVlanSwitch.Size = new global::System.Drawing.Size(216, 24);
			this.p_niveauVlanSwitch.TabIndex = 94;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown4 = this.p_niveauVlanSwitch;
			array = new int[4];
			paramNumericUpDown4.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown5 = this.p_niveauVlanSwitch;
			array = new int[4];
			paramNumericUpDown5.ValeurDefaut = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown6 = this.p_nbPorts8021qSwitch;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown6.Increment = new decimal(array);
			this.p_nbPorts8021qSwitch.Label = "Ports 802.1q d'un switch";
			this.p_nbPorts8021qSwitch.Location = new global::System.Drawing.Point(16, 112);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown7 = this.p_nbPorts8021qSwitch;
			array = new int[4];
			array[0] = 24;
			paramNumericUpDown7.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown8 = this.p_nbPorts8021qSwitch;
			array = new int[4];
			paramNumericUpDown8.Minimum = new decimal(array);
			this.p_nbPorts8021qSwitch.Name = "p_nbPorts8021qSwitch";
			this.p_nbPorts8021qSwitch.NbDecimales = 0;
			this.p_nbPorts8021qSwitch.Size = new global::System.Drawing.Size(216, 24);
			this.p_nbPorts8021qSwitch.TabIndex = 93;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown9 = this.p_nbPorts8021qSwitch;
			array = new int[4];
			paramNumericUpDown9.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown10 = this.p_nbPorts8021qSwitch;
			array = new int[4];
			paramNumericUpDown10.ValeurDefaut = new decimal(array);
			this.p_spanningTree.Label = "Spanning tree par défaut";
			this.p_spanningTree.Location = new global::System.Drawing.Point(16, 208);
			this.p_spanningTree.Name = "p_spanningTree";
			this.p_spanningTree.Size = new global::System.Drawing.Size(208, 24);
			this.p_spanningTree.TabIndex = 92;
			this.p_spanningTree.Valeur = true;
			this.p_spanningTree.ValeurDefaut = true;
			this.p_storeAndForward.Label = "Switchs store and forward";
			this.p_storeAndForward.Location = new global::System.Drawing.Point(16, 184);
			this.p_storeAndForward.Name = "p_storeAndForward";
			this.p_storeAndForward.Size = new global::System.Drawing.Size(208, 24);
			this.p_storeAndForward.TabIndex = 91;
			this.p_storeAndForward.Valeur = true;
			this.p_storeAndForward.ValeurDefaut = true;
			this.p_surbrillancePointConnexion.AllowFullOpen = false;
			this.p_surbrillancePointConnexion.EpaisseurStylo = 1f;
			this.p_surbrillancePointConnexion.Label = "Surbrillance connexion";
			this.p_surbrillancePointConnexion.Location = new global::System.Drawing.Point(248, 88);
			this.p_surbrillancePointConnexion.Name = "p_surbrillancePointConnexion";
			this.p_surbrillancePointConnexion.Size = new global::System.Drawing.Size(216, 24);
			this.p_surbrillancePointConnexion.SolidColorOnly = true;
			this.p_surbrillancePointConnexion.TabIndex = 90;
			this.p_surbrillancePointConnexion.Valeur = global::System.Drawing.Color.Black;
			this.p_surbrillancePointConnexion.ValeurDefaut = global::System.Drawing.Color.Black;
			this.p_couleurConnexionConception.AllowFullOpen = false;
			this.p_couleurConnexionConception.EpaisseurStylo = 1f;
			this.p_couleurConnexionConception.Label = "Connexion connectée";
			this.p_couleurConnexionConception.Location = new global::System.Drawing.Point(248, 64);
			this.p_couleurConnexionConception.Name = "p_couleurConnexionConception";
			this.p_couleurConnexionConception.Size = new global::System.Drawing.Size(216, 24);
			this.p_couleurConnexionConception.SolidColorOnly = true;
			this.p_couleurConnexionConception.TabIndex = 88;
			this.p_couleurConnexionConception.Valeur = global::System.Drawing.Color.Gray;
			this.p_couleurConnexionConception.ValeurDefaut = global::System.Drawing.Color.Gray;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown11 = this.p_longueurCableMax;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown11.Increment = new decimal(array);
			this.p_longueurCableMax.Label = "Longueur maximale câble";
			this.p_longueurCableMax.Location = new global::System.Drawing.Point(16, 160);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown12 = this.p_longueurCableMax;
			array = new int[4];
			array[0] = 50000;
			paramNumericUpDown12.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown13 = this.p_longueurCableMax;
			array = new int[4];
			array[0] = 2;
			paramNumericUpDown13.Minimum = new decimal(array);
			this.p_longueurCableMax.Name = "p_longueurCableMax";
			this.p_longueurCableMax.NbDecimales = 0;
			this.p_longueurCableMax.Size = new global::System.Drawing.Size(216, 24);
			this.p_longueurCableMax.TabIndex = 87;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown14 = this.p_longueurCableMax;
			array = new int[4];
			array[0] = 500;
			paramNumericUpDown14.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown15 = this.p_longueurCableMax;
			array = new int[4];
			array[0] = 500;
			paramNumericUpDown15.ValeurDefaut = new decimal(array);
			this.p_longueurCableMax.ValueChanged += new global::System.EventHandler(this.longueurCableMaxChanged);
			this.p_selectionStylo.AllowFullOpen = false;
			this.p_selectionStylo.EpaisseurStylo = 1f;
			this.p_selectionStylo.Label = "Objet sélectionné";
			this.p_selectionStylo.Location = new global::System.Drawing.Point(248, 40);
			this.p_selectionStylo.Name = "p_selectionStylo";
			this.p_selectionStylo.Size = new global::System.Drawing.Size(216, 24);
			this.p_selectionStylo.SolidColorOnly = true;
			this.p_selectionStylo.TabIndex = 86;
			this.p_selectionStylo.Valeur = global::System.Drawing.Color.Gray;
			this.p_selectionStylo.ValeurDefaut = global::System.Drawing.Color.Gray;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown16 = this.p_longueurCableDefaut;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown16.Increment = new decimal(array);
			this.p_longueurCableDefaut.Label = "Longueur câble par défaut";
			this.p_longueurCableDefaut.Location = new global::System.Drawing.Point(16, 136);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown17 = this.p_longueurCableDefaut;
			array = new int[4];
			array[0] = 500;
			paramNumericUpDown17.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown18 = this.p_longueurCableDefaut;
			array = new int[4];
			array[0] = 2;
			paramNumericUpDown18.Minimum = new decimal(array);
			this.p_longueurCableDefaut.Name = "p_longueurCableDefaut";
			this.p_longueurCableDefaut.NbDecimales = 0;
			this.p_longueurCableDefaut.Size = new global::System.Drawing.Size(216, 24);
			this.p_longueurCableDefaut.TabIndex = 85;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown19 = this.p_longueurCableDefaut;
			array = new int[4];
			array[0] = 30;
			paramNumericUpDown19.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown20 = this.p_longueurCableDefaut;
			array = new int[4];
			array[0] = 30;
			paramNumericUpDown20.ValeurDefaut = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown21 = this.p_nbPortsCascadeSwitch;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown21.Increment = new decimal(array);
			this.p_nbPortsCascadeSwitch.Label = "Ports cascade d'un switch";
			this.p_nbPortsCascadeSwitch.Location = new global::System.Drawing.Point(16, 88);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown22 = this.p_nbPortsCascadeSwitch;
			array = new int[4];
			array[0] = 24;
			paramNumericUpDown22.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown23 = this.p_nbPortsCascadeSwitch;
			array = new int[4];
			paramNumericUpDown23.Minimum = new decimal(array);
			this.p_nbPortsCascadeSwitch.Name = "p_nbPortsCascadeSwitch";
			this.p_nbPortsCascadeSwitch.NbDecimales = 0;
			this.p_nbPortsCascadeSwitch.Size = new global::System.Drawing.Size(216, 24);
			this.p_nbPortsCascadeSwitch.TabIndex = 84;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown24 = this.p_nbPortsCascadeSwitch;
			array = new int[4];
			array[0] = 3;
			paramNumericUpDown24.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown25 = this.p_nbPortsCascadeSwitch;
			array = new int[4];
			array[0] = 3;
			paramNumericUpDown25.ValeurDefaut = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown26 = this.p_nbPortsSwitch;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown26.Increment = new decimal(array);
			this.p_nbPortsSwitch.Label = "Nb de ports d'un switch";
			this.p_nbPortsSwitch.Location = new global::System.Drawing.Point(16, 64);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown27 = this.p_nbPortsSwitch;
			array = new int[4];
			array[0] = 24;
			paramNumericUpDown27.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown28 = this.p_nbPortsSwitch;
			array = new int[4];
			array[0] = 2;
			paramNumericUpDown28.Minimum = new decimal(array);
			this.p_nbPortsSwitch.Name = "p_nbPortsSwitch";
			this.p_nbPortsSwitch.NbDecimales = 0;
			this.p_nbPortsSwitch.Size = new global::System.Drawing.Size(216, 24);
			this.p_nbPortsSwitch.TabIndex = 83;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown29 = this.p_nbPortsSwitch;
			array = new int[4];
			array[0] = 4;
			paramNumericUpDown29.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown30 = this.p_nbPortsSwitch;
			array = new int[4];
			array[0] = 4;
			paramNumericUpDown30.ValeurDefaut = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown31 = this.p_nbPortsCascadeHub;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown31.Increment = new decimal(array);
			this.p_nbPortsCascadeHub.Label = "Ports cascade d'un hub";
			this.p_nbPortsCascadeHub.Location = new global::System.Drawing.Point(16, 40);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown32 = this.p_nbPortsCascadeHub;
			array = new int[4];
			array[0] = 24;
			paramNumericUpDown32.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown33 = this.p_nbPortsCascadeHub;
			array = new int[4];
			paramNumericUpDown33.Minimum = new decimal(array);
			this.p_nbPortsCascadeHub.Name = "p_nbPortsCascadeHub";
			this.p_nbPortsCascadeHub.NbDecimales = 0;
			this.p_nbPortsCascadeHub.Size = new global::System.Drawing.Size(216, 24);
			this.p_nbPortsCascadeHub.TabIndex = 82;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown34 = this.p_nbPortsCascadeHub;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown34.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown35 = this.p_nbPortsCascadeHub;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown35.ValeurDefaut = new decimal(array);
			this.p_normalStylo.AllowFullOpen = false;
			this.p_normalStylo.EpaisseurStylo = 1f;
			this.p_normalStylo.Label = "Trait normal";
			this.p_normalStylo.Location = new global::System.Drawing.Point(248, 16);
			this.p_normalStylo.Name = "p_normalStylo";
			this.p_normalStylo.Size = new global::System.Drawing.Size(216, 24);
			this.p_normalStylo.SolidColorOnly = true;
			this.p_normalStylo.TabIndex = 81;
			this.p_normalStylo.Valeur = global::System.Drawing.Color.Black;
			this.p_normalStylo.ValeurDefaut = global::System.Drawing.Color.Black;
			this.p_normalStylo.ValueChanged += new global::System.EventHandler(this.normalStyloChanged);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown36 = this.p_nbPortsHub;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown36.Increment = new decimal(array);
			this.p_nbPortsHub.Label = "Nb de ports d'un hub";
			this.p_nbPortsHub.Location = new global::System.Drawing.Point(16, 16);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown37 = this.p_nbPortsHub;
			array = new int[4];
			array[0] = 24;
			paramNumericUpDown37.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown38 = this.p_nbPortsHub;
			array = new int[4];
			array[0] = 2;
			paramNumericUpDown38.Minimum = new decimal(array);
			this.p_nbPortsHub.Name = "p_nbPortsHub";
			this.p_nbPortsHub.NbDecimales = 0;
			this.p_nbPortsHub.Size = new global::System.Drawing.Size(216, 24);
			this.p_nbPortsHub.TabIndex = 80;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown39 = this.p_nbPortsHub;
			array = new int[4];
			array[0] = 6;
			paramNumericUpDown39.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown40 = this.p_nbPortsHub;
			array = new int[4];
			array[0] = 6;
			paramNumericUpDown40.ValeurDefaut = new decimal(array);
			this.tp_ethernet.Controls.Add(this.p_annonceStations);
			this.tp_ethernet.Controls.Add(this.p_stylo8021q);
			this.tp_ethernet.Controls.Add(this.p_delaiReemissionW);
			this.tp_ethernet.Controls.Add(this.p_delaiReemissionZ);
			this.tp_ethernet.Controls.Add(this.p_delaiReemissionY);
			this.tp_ethernet.Controls.Add(this.p_delaiReemissionX);
			this.tp_ethernet.Controls.Add(this.lbl_delaiReemission);
			this.tp_ethernet.Controls.Add(this.p_tauxRalenti);
			this.tp_ethernet.Controls.Add(this.p_tempsInterTrames);
			this.tp_ethernet.Controls.Add(this.p_couleurBloqueEthernet);
			this.tp_ethernet.Controls.Add(this.p_nbMetresParTick);
			this.tp_ethernet.Controls.Add(this.p_tempsDelaiTransmissionSwitch);
			this.tp_ethernet.Controls.Add(this.p_coefEmissionTrameLongue);
			this.tp_ethernet.Controls.Add(this.p_tempsDelaiTransmissionHub);
			this.tp_ethernet.Controls.Add(this.p_coefEmissionTrameCourte);
			this.tp_ethernet.Controls.Add(this.p_tempsEmissionTrame);
			this.tp_ethernet.Controls.Add(this.p_tempsAttenteEcoute);
			this.tp_ethernet.Controls.Add(this.p_tempsAttenteDemoDefaut);
			this.tp_ethernet.Controls.Add(this.p_traceParDefaut);
			this.tp_ethernet.Controls.Add(this.p_couleurErreurEthernet);
			this.tp_ethernet.Controls.Add(this.p_couleurActifEthernet);
			this.tp_ethernet.Controls.Add(this.p_couleurAllumeEthernet);
			this.tp_ethernet.Controls.Add(this.p_cableActifStylo2);
			this.tp_ethernet.Controls.Add(this.p_cableActifStylo1);
			this.tp_ethernet.Controls.Add(this.p_styloCollision);
			this.tp_ethernet.Location = new global::System.Drawing.Point(4, 22);
			this.tp_ethernet.Name = "tp_ethernet";
			this.tp_ethernet.Size = new global::System.Drawing.Size(480, 350);
			this.tp_ethernet.TabIndex = 1;
			this.tp_ethernet.Text = "Ethernet";
			this.tp_ethernet.Visible = false;
			this.p_annonceStations.Label = "Les stations s'annoncent";
			this.p_annonceStations.Location = new global::System.Drawing.Point(16, 232);
			this.p_annonceStations.Name = "p_annonceStations";
			this.p_annonceStations.Size = new global::System.Drawing.Size(208, 24);
			this.p_annonceStations.TabIndex = 121;
			this.p_annonceStations.Valeur = true;
			this.p_annonceStations.ValeurDefaut = true;
			this.p_stylo8021q.AllowFullOpen = false;
			this.p_stylo8021q.EpaisseurStylo = 2f;
			this.p_stylo8021q.Label = "Couleur marque 802.1q";
			this.p_stylo8021q.Location = new global::System.Drawing.Point(248, 184);
			this.p_stylo8021q.Name = "p_stylo8021q";
			this.p_stylo8021q.Size = new global::System.Drawing.Size(216, 24);
			this.p_stylo8021q.SolidColorOnly = true;
			this.p_stylo8021q.TabIndex = 120;
			this.p_stylo8021q.Valeur = global::System.Drawing.Color.Red;
			this.p_stylo8021q.ValeurDefaut = global::System.Drawing.Color.Red;
			this.p_delaiReemissionW.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.p_delaiReemissionW.Label = "W";
			this.p_delaiReemissionW.Location = new global::System.Drawing.Point(16, 312);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown41 = this.p_delaiReemissionW;
			array = new int[4];
			array[0] = 3;
			paramNumericUpDown41.Maximum = new decimal(array);
			this.p_delaiReemissionW.Minimum = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.p_delaiReemissionW.Name = "p_delaiReemissionW";
			this.p_delaiReemissionW.NbDecimales = 2;
			this.p_delaiReemissionW.Size = new global::System.Drawing.Size(96, 24);
			this.p_delaiReemissionW.TabIndex = 118;
			this.p_delaiReemissionW.Valeur = new decimal(new int[]
			{
				75,
				0,
				0,
				131072
			});
			this.p_delaiReemissionW.ValeurDefaut = new decimal(new int[]
			{
				75,
				0,
				0,
				131072
			});
			this.p_delaiReemissionW.Leave += new global::System.EventHandler(this.p_delaiReemissionW_Leave);
			this.p_delaiReemissionW.ValueChanged += new global::System.EventHandler(this.p_delaiReemissionW_ValueChanged);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown42 = this.p_delaiReemissionZ;
			array = new int[4];
			array[0] = 10;
			paramNumericUpDown42.Increment = new decimal(array);
			this.p_delaiReemissionZ.Label = "Z";
			this.p_delaiReemissionZ.Location = new global::System.Drawing.Point(352, 312);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown43 = this.p_delaiReemissionZ;
			array = new int[4];
			array[0] = 300000;
			paramNumericUpDown43.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown44 = this.p_delaiReemissionZ;
			array = new int[4];
			array[0] = 10;
			paramNumericUpDown44.Minimum = new decimal(array);
			this.p_delaiReemissionZ.Name = "p_delaiReemissionZ";
			this.p_delaiReemissionZ.NbDecimales = 0;
			this.p_delaiReemissionZ.Size = new global::System.Drawing.Size(96, 24);
			this.p_delaiReemissionZ.TabIndex = 117;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown45 = this.p_delaiReemissionZ;
			array = new int[4];
			array[0] = 100;
			paramNumericUpDown45.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown46 = this.p_delaiReemissionZ;
			array = new int[4];
			array[0] = 100;
			paramNumericUpDown46.ValeurDefaut = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown47 = this.p_delaiReemissionY;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown47.Increment = new decimal(array);
			this.p_delaiReemissionY.Label = "Y";
			this.p_delaiReemissionY.Location = new global::System.Drawing.Point(240, 312);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown48 = this.p_delaiReemissionY;
			array = new int[4];
			array[0] = 30000;
			paramNumericUpDown48.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown49 = this.p_delaiReemissionY;
			array = new int[4];
			array[0] = 2;
			paramNumericUpDown49.Minimum = new decimal(array);
			this.p_delaiReemissionY.Name = "p_delaiReemissionY";
			this.p_delaiReemissionY.NbDecimales = 0;
			this.p_delaiReemissionY.Size = new global::System.Drawing.Size(96, 24);
			this.p_delaiReemissionY.TabIndex = 116;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown50 = this.p_delaiReemissionY;
			array = new int[4];
			array[0] = 5;
			paramNumericUpDown50.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown51 = this.p_delaiReemissionY;
			array = new int[4];
			array[0] = 5;
			paramNumericUpDown51.ValeurDefaut = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown52 = this.p_delaiReemissionX;
			array = new int[4];
			array[0] = 10;
			paramNumericUpDown52.Increment = new decimal(array);
			this.p_delaiReemissionX.Label = "X";
			this.p_delaiReemissionX.Location = new global::System.Drawing.Point(128, 312);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown53 = this.p_delaiReemissionX;
			array = new int[4];
			array[0] = 30000;
			paramNumericUpDown53.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown54 = this.p_delaiReemissionX;
			array = new int[4];
			array[0] = 10;
			paramNumericUpDown54.Minimum = new decimal(array);
			this.p_delaiReemissionX.Name = "p_delaiReemissionX";
			this.p_delaiReemissionX.NbDecimales = 0;
			this.p_delaiReemissionX.Size = new global::System.Drawing.Size(96, 24);
			this.p_delaiReemissionX.TabIndex = 115;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown55 = this.p_delaiReemissionX;
			array = new int[4];
			array[0] = 800;
			paramNumericUpDown55.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown56 = this.p_delaiReemissionX;
			array = new int[4];
			array[0] = 800;
			paramNumericUpDown56.ValeurDefaut = new decimal(array);
			this.lbl_delaiReemission.Location = new global::System.Drawing.Point(16, 288);
			this.lbl_delaiReemission.Name = "lbl_delaiReemission";
			this.lbl_delaiReemission.Size = new global::System.Drawing.Size(448, 23);
			this.lbl_delaiReemission.TabIndex = 113;
			this.lbl_delaiReemission.Text = "Délai réémission : n° trame * w * nb d'essais * X * nb aléatoire(entre 1 et Y ) + Z";
			global::Simulateur.ParamNumericUpDown paramNumericUpDown57 = this.p_tauxRalenti;
			array = new int[4];
			array[0] = 10;
			paramNumericUpDown57.Increment = new decimal(array);
			this.p_tauxRalenti.Label = "Vitesse ralenti en %";
			this.p_tauxRalenti.Location = new global::System.Drawing.Point(248, 232);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown58 = this.p_tauxRalenti;
			array = new int[4];
			array[0] = 90;
			paramNumericUpDown58.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown59 = this.p_tauxRalenti;
			array = new int[4];
			array[0] = 10;
			paramNumericUpDown59.Minimum = new decimal(array);
			this.p_tauxRalenti.Name = "p_tauxRalenti";
			this.p_tauxRalenti.NbDecimales = 0;
			this.p_tauxRalenti.Size = new global::System.Drawing.Size(216, 24);
			this.p_tauxRalenti.TabIndex = 111;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown60 = this.p_tauxRalenti;
			array = new int[4];
			array[0] = 50;
			paramNumericUpDown60.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown61 = this.p_tauxRalenti;
			array = new int[4];
			array[0] = 50;
			paramNumericUpDown61.ValeurDefaut = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown62 = this.p_tempsInterTrames;
			array = new int[4];
			array[0] = 10;
			paramNumericUpDown62.Increment = new decimal(array);
			this.p_tempsInterTrames.Label = "Temps inter-trames";
			this.p_tempsInterTrames.Location = new global::System.Drawing.Point(16, 184);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown63 = this.p_tempsInterTrames;
			array = new int[4];
			array[0] = 300000;
			paramNumericUpDown63.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown64 = this.p_tempsInterTrames;
			array = new int[4];
			array[0] = 100;
			paramNumericUpDown64.Minimum = new decimal(array);
			this.p_tempsInterTrames.Name = "p_tempsInterTrames";
			this.p_tempsInterTrames.NbDecimales = 0;
			this.p_tempsInterTrames.Size = new global::System.Drawing.Size(216, 24);
			this.p_tempsInterTrames.TabIndex = 110;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown65 = this.p_tempsInterTrames;
			array = new int[4];
			array[0] = 300;
			paramNumericUpDown65.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown66 = this.p_tempsInterTrames;
			array = new int[4];
			array[0] = 300;
			paramNumericUpDown66.ValeurDefaut = new decimal(array);
			this.p_couleurBloqueEthernet.AllowFullOpen = false;
			this.p_couleurBloqueEthernet.EpaisseurStylo = 1f;
			this.p_couleurBloqueEthernet.Label = "Connexion bloquée";
			this.p_couleurBloqueEthernet.Location = new global::System.Drawing.Point(248, 160);
			this.p_couleurBloqueEthernet.Name = "p_couleurBloqueEthernet";
			this.p_couleurBloqueEthernet.Size = new global::System.Drawing.Size(216, 24);
			this.p_couleurBloqueEthernet.SolidColorOnly = true;
			this.p_couleurBloqueEthernet.TabIndex = 109;
			this.p_couleurBloqueEthernet.Valeur = global::System.Drawing.Color.Magenta;
			this.p_couleurBloqueEthernet.ValeurDefaut = global::System.Drawing.Color.Magenta;
			this.p_nbMetresParTick.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.p_nbMetresParTick.Label = "Vitesse des trames";
			this.p_nbMetresParTick.Location = new global::System.Drawing.Point(16, 160);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown67 = this.p_nbMetresParTick;
			array = new int[4];
			array[0] = 100;
			paramNumericUpDown67.Maximum = new decimal(array);
			this.p_nbMetresParTick.Minimum = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.p_nbMetresParTick.Name = "p_nbMetresParTick";
			this.p_nbMetresParTick.NbDecimales = 2;
			this.p_nbMetresParTick.Size = new global::System.Drawing.Size(216, 24);
			this.p_nbMetresParTick.TabIndex = 108;
			this.p_nbMetresParTick.Valeur = new decimal(new int[]
			{
				6,
				0,
				0,
				65536
			});
			this.p_nbMetresParTick.ValeurDefaut = new decimal(new int[]
			{
				6,
				0,
				0,
				65536
			});
			global::Simulateur.ParamNumericUpDown paramNumericUpDown68 = this.p_tempsDelaiTransmissionSwitch;
			array = new int[4];
			array[0] = 10;
			paramNumericUpDown68.Increment = new decimal(array);
			this.p_tempsDelaiTransmissionSwitch.Label = "Tps retournement switch";
			this.p_tempsDelaiTransmissionSwitch.Location = new global::System.Drawing.Point(16, 136);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown69 = this.p_tempsDelaiTransmissionSwitch;
			array = new int[4];
			array[0] = 30000;
			paramNumericUpDown69.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown70 = this.p_tempsDelaiTransmissionSwitch;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown70.Minimum = new decimal(array);
			this.p_tempsDelaiTransmissionSwitch.Name = "p_tempsDelaiTransmissionSwitch";
			this.p_tempsDelaiTransmissionSwitch.NbDecimales = 0;
			this.p_tempsDelaiTransmissionSwitch.Size = new global::System.Drawing.Size(216, 24);
			this.p_tempsDelaiTransmissionSwitch.TabIndex = 107;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown71 = this.p_tempsDelaiTransmissionSwitch;
			array = new int[4];
			array[0] = 800;
			paramNumericUpDown71.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown72 = this.p_tempsDelaiTransmissionSwitch;
			array = new int[4];
			array[0] = 800;
			paramNumericUpDown72.ValeurDefaut = new decimal(array);
			this.p_tempsDelaiTransmissionSwitch.ValueChanged += new global::System.EventHandler(this.p_tempsDelaiTransmissionHubSwitch_ValueChanged);
			this.p_coefEmissionTrameLongue.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.p_coefEmissionTrameLongue.Label = "Coefficient trame longue";
			this.p_coefEmissionTrameLongue.Location = new global::System.Drawing.Point(16, 88);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown73 = this.p_coefEmissionTrameLongue;
			array = new int[4];
			array[0] = 10;
			paramNumericUpDown73.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown74 = this.p_coefEmissionTrameLongue;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown74.Minimum = new decimal(array);
			this.p_coefEmissionTrameLongue.Name = "p_coefEmissionTrameLongue";
			this.p_coefEmissionTrameLongue.NbDecimales = 2;
			this.p_coefEmissionTrameLongue.Size = new global::System.Drawing.Size(216, 24);
			this.p_coefEmissionTrameLongue.TabIndex = 106;
			this.p_coefEmissionTrameLongue.Valeur = new decimal(new int[]
			{
				15,
				0,
				0,
				65536
			});
			this.p_coefEmissionTrameLongue.ValeurDefaut = new decimal(new int[]
			{
				15,
				0,
				0,
				65536
			});
			global::Simulateur.ParamNumericUpDown paramNumericUpDown75 = this.p_tempsDelaiTransmissionHub;
			array = new int[4];
			array[0] = 10;
			paramNumericUpDown75.Increment = new decimal(array);
			this.p_tempsDelaiTransmissionHub.Label = "Temps retournement hub";
			this.p_tempsDelaiTransmissionHub.Location = new global::System.Drawing.Point(16, 112);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown76 = this.p_tempsDelaiTransmissionHub;
			array = new int[4];
			array[0] = 30000;
			paramNumericUpDown76.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown77 = this.p_tempsDelaiTransmissionHub;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown77.Minimum = new decimal(array);
			this.p_tempsDelaiTransmissionHub.Name = "p_tempsDelaiTransmissionHub";
			this.p_tempsDelaiTransmissionHub.NbDecimales = 0;
			this.p_tempsDelaiTransmissionHub.Size = new global::System.Drawing.Size(216, 24);
			this.p_tempsDelaiTransmissionHub.TabIndex = 105;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown78 = this.p_tempsDelaiTransmissionHub;
			array = new int[4];
			array[0] = 800;
			paramNumericUpDown78.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown79 = this.p_tempsDelaiTransmissionHub;
			array = new int[4];
			array[0] = 800;
			paramNumericUpDown79.ValeurDefaut = new decimal(array);
			this.p_tempsDelaiTransmissionHub.ValueChanged += new global::System.EventHandler(this.p_tempsDelaiTransmissionHubSwitch_ValueChanged);
			this.p_coefEmissionTrameCourte.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.p_coefEmissionTrameCourte.Label = "Coefficient trame courte";
			this.p_coefEmissionTrameCourte.Location = new global::System.Drawing.Point(16, 64);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown80 = this.p_coefEmissionTrameCourte;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown80.Maximum = new decimal(array);
			this.p_coefEmissionTrameCourte.Minimum = new decimal(new int[]
			{
				2,
				0,
				0,
				65536
			});
			this.p_coefEmissionTrameCourte.Name = "p_coefEmissionTrameCourte";
			this.p_coefEmissionTrameCourte.NbDecimales = 2;
			this.p_coefEmissionTrameCourte.Size = new global::System.Drawing.Size(216, 24);
			this.p_coefEmissionTrameCourte.TabIndex = 104;
			this.p_coefEmissionTrameCourte.Valeur = new decimal(new int[]
			{
				25,
				0,
				0,
				131072
			});
			this.p_coefEmissionTrameCourte.ValeurDefaut = new decimal(new int[]
			{
				25,
				0,
				0,
				131072
			});
			global::Simulateur.ParamNumericUpDown paramNumericUpDown81 = this.p_tempsEmissionTrame;
			array = new int[4];
			array[0] = 10;
			paramNumericUpDown81.Increment = new decimal(array);
			this.p_tempsEmissionTrame.Label = "Temps émission trame";
			this.p_tempsEmissionTrame.Location = new global::System.Drawing.Point(16, 40);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown82 = this.p_tempsEmissionTrame;
			array = new int[4];
			array[0] = 300000;
			paramNumericUpDown82.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown83 = this.p_tempsEmissionTrame;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown83.Minimum = new decimal(array);
			this.p_tempsEmissionTrame.Name = "p_tempsEmissionTrame";
			this.p_tempsEmissionTrame.NbDecimales = 0;
			this.p_tempsEmissionTrame.Size = new global::System.Drawing.Size(216, 24);
			this.p_tempsEmissionTrame.TabIndex = 103;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown84 = this.p_tempsEmissionTrame;
			array = new int[4];
			array[0] = 9000;
			paramNumericUpDown84.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown85 = this.p_tempsEmissionTrame;
			array = new int[4];
			array[0] = 9000;
			paramNumericUpDown85.ValeurDefaut = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown86 = this.p_tempsAttenteEcoute;
			array = new int[4];
			array[0] = 10;
			paramNumericUpDown86.Increment = new decimal(array);
			this.p_tempsAttenteEcoute.Label = "Ecoute avant émission";
			this.p_tempsAttenteEcoute.Location = new global::System.Drawing.Point(16, 16);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown87 = this.p_tempsAttenteEcoute;
			array = new int[4];
			array[0] = 30000;
			paramNumericUpDown87.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown88 = this.p_tempsAttenteEcoute;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown88.Minimum = new decimal(array);
			this.p_tempsAttenteEcoute.Name = "p_tempsAttenteEcoute";
			this.p_tempsAttenteEcoute.NbDecimales = 0;
			this.p_tempsAttenteEcoute.Size = new global::System.Drawing.Size(216, 24);
			this.p_tempsAttenteEcoute.TabIndex = 102;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown89 = this.p_tempsAttenteEcoute;
			array = new int[4];
			array[0] = 1000;
			paramNumericUpDown89.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown90 = this.p_tempsAttenteEcoute;
			array = new int[4];
			array[0] = 1000;
			paramNumericUpDown90.ValeurDefaut = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown91 = this.p_tempsAttenteDemoDefaut;
			array = new int[4];
			array[0] = 10;
			paramNumericUpDown91.Increment = new decimal(array);
			this.p_tempsAttenteDemoDefaut.Label = "Attente lors des démos";
			this.p_tempsAttenteDemoDefaut.Location = new global::System.Drawing.Point(16, 208);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown92 = this.p_tempsAttenteDemoDefaut;
			array = new int[4];
			array[0] = 300000;
			paramNumericUpDown92.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown93 = this.p_tempsAttenteDemoDefaut;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown93.Minimum = new decimal(array);
			this.p_tempsAttenteDemoDefaut.Name = "p_tempsAttenteDemoDefaut";
			this.p_tempsAttenteDemoDefaut.NbDecimales = 0;
			this.p_tempsAttenteDemoDefaut.Size = new global::System.Drawing.Size(216, 24);
			this.p_tempsAttenteDemoDefaut.TabIndex = 101;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown94 = this.p_tempsAttenteDemoDefaut;
			array = new int[4];
			array[0] = 3000;
			paramNumericUpDown94.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown95 = this.p_tempsAttenteDemoDefaut;
			array = new int[4];
			array[0] = 3000;
			paramNumericUpDown95.ValeurDefaut = new decimal(array);
			this.p_traceParDefaut.Label = "Noeuds tracés par défaut";
			this.p_traceParDefaut.Location = new global::System.Drawing.Point(248, 208);
			this.p_traceParDefaut.Name = "p_traceParDefaut";
			this.p_traceParDefaut.Size = new global::System.Drawing.Size(216, 24);
			this.p_traceParDefaut.TabIndex = 100;
			this.p_traceParDefaut.Valeur = false;
			this.p_traceParDefaut.ValeurDefaut = false;
			this.p_couleurErreurEthernet.AllowFullOpen = false;
			this.p_couleurErreurEthernet.EpaisseurStylo = 1f;
			this.p_couleurErreurEthernet.Label = "Connexion en erreur";
			this.p_couleurErreurEthernet.Location = new global::System.Drawing.Point(248, 136);
			this.p_couleurErreurEthernet.Name = "p_couleurErreurEthernet";
			this.p_couleurErreurEthernet.Size = new global::System.Drawing.Size(216, 24);
			this.p_couleurErreurEthernet.SolidColorOnly = true;
			this.p_couleurErreurEthernet.TabIndex = 99;
			this.p_couleurErreurEthernet.Valeur = global::System.Drawing.Color.Red;
			this.p_couleurErreurEthernet.ValeurDefaut = global::System.Drawing.Color.Red;
			this.p_couleurActifEthernet.AllowFullOpen = false;
			this.p_couleurActifEthernet.EpaisseurStylo = 1f;
			this.p_couleurActifEthernet.Label = "Connexion active";
			this.p_couleurActifEthernet.Location = new global::System.Drawing.Point(248, 112);
			this.p_couleurActifEthernet.Name = "p_couleurActifEthernet";
			this.p_couleurActifEthernet.Size = new global::System.Drawing.Size(216, 24);
			this.p_couleurActifEthernet.SolidColorOnly = true;
			this.p_couleurActifEthernet.TabIndex = 98;
			this.p_couleurActifEthernet.Valeur = global::System.Drawing.Color.Green;
			this.p_couleurActifEthernet.ValeurDefaut = global::System.Drawing.Color.Green;
			this.p_couleurAllumeEthernet.AllowFullOpen = false;
			this.p_couleurAllumeEthernet.EpaisseurStylo = 1f;
			this.p_couleurAllumeEthernet.Label = "Connexion allumée";
			this.p_couleurAllumeEthernet.Location = new global::System.Drawing.Point(248, 88);
			this.p_couleurAllumeEthernet.Name = "p_couleurAllumeEthernet";
			this.p_couleurAllumeEthernet.Size = new global::System.Drawing.Size(216, 24);
			this.p_couleurAllumeEthernet.SolidColorOnly = true;
			this.p_couleurAllumeEthernet.TabIndex = 97;
			this.p_couleurAllumeEthernet.Valeur = global::System.Drawing.Color.Orange;
			this.p_couleurAllumeEthernet.ValeurDefaut = global::System.Drawing.Color.Orange;
			this.p_cableActifStylo2.AllowFullOpen = false;
			this.p_cableActifStylo2.EpaisseurStylo = 2f;
			this.p_cableActifStylo2.Label = "Couleur seconde trame";
			this.p_cableActifStylo2.Location = new global::System.Drawing.Point(248, 40);
			this.p_cableActifStylo2.Name = "p_cableActifStylo2";
			this.p_cableActifStylo2.Size = new global::System.Drawing.Size(216, 24);
			this.p_cableActifStylo2.SolidColorOnly = true;
			this.p_cableActifStylo2.TabIndex = 96;
			this.p_cableActifStylo2.Valeur = global::System.Drawing.Color.Cyan;
			this.p_cableActifStylo2.ValeurDefaut = global::System.Drawing.Color.Cyan;
			this.p_cableActifStylo1.AllowFullOpen = false;
			this.p_cableActifStylo1.EpaisseurStylo = 2f;
			this.p_cableActifStylo1.Label = "Couleur première trame";
			this.p_cableActifStylo1.Location = new global::System.Drawing.Point(248, 16);
			this.p_cableActifStylo1.Name = "p_cableActifStylo1";
			this.p_cableActifStylo1.Size = new global::System.Drawing.Size(216, 24);
			this.p_cableActifStylo1.SolidColorOnly = true;
			this.p_cableActifStylo1.TabIndex = 95;
			this.p_cableActifStylo1.Valeur = global::System.Drawing.Color.Blue;
			this.p_cableActifStylo1.ValeurDefaut = global::System.Drawing.Color.Blue;
			this.p_styloCollision.AllowFullOpen = false;
			this.p_styloCollision.EpaisseurStylo = 2f;
			this.p_styloCollision.Label = "Couleur collision";
			this.p_styloCollision.Location = new global::System.Drawing.Point(248, 64);
			this.p_styloCollision.Name = "p_styloCollision";
			this.p_styloCollision.Size = new global::System.Drawing.Size(216, 24);
			this.p_styloCollision.SolidColorOnly = true;
			this.p_styloCollision.TabIndex = 94;
			this.p_styloCollision.Valeur = global::System.Drawing.Color.Red;
			this.p_styloCollision.ValeurDefaut = global::System.Drawing.Color.Red;
			this.tp_tcpIp.Controls.Add(this.p_icones);
			this.tp_tcpIp.Controls.Add(this.p_cachesArpAutoIp);
			this.tp_tcpIp.Controls.Add(this.p_demoInternet);
			this.tp_tcpIp.Controls.Add(this.p_cheminPaquet);
			this.tp_tcpIp.Controls.Add(this.p_nbSautsMax);
			this.tp_tcpIp.Controls.Add(this.p_attentePing);
			this.tp_tcpIp.Controls.Add(this.p_ttlCacheArp);
			this.tp_tcpIp.Controls.Add(this.p_trameModeIp);
			this.tp_tcpIp.Controls.Add(this.p_longueurRoute);
			this.tp_tcpIp.Controls.Add(this.p_styloPaquet);
			this.tp_tcpIp.Location = new global::System.Drawing.Point(4, 22);
			this.tp_tcpIp.Name = "tp_tcpIp";
			this.tp_tcpIp.Size = new global::System.Drawing.Size(480, 350);
			this.tp_tcpIp.TabIndex = 2;
			this.tp_tcpIp.Text = "IP/Transport";
			this.p_icones.Label = "Afficher les icônes sur les stations";
			this.p_icones.Location = new global::System.Drawing.Point(8, 224);
			this.p_icones.Name = "p_icones";
			this.p_icones.Size = new global::System.Drawing.Size(280, 24);
			this.p_icones.TabIndex = 102;
			this.p_icones.Valeur = true;
			this.p_icones.ValeurDefaut = true;
			this.p_cachesArpAutoIp.Label = "Caches ARP automatiques en mode IP";
			this.p_cachesArpAutoIp.Location = new global::System.Drawing.Point(8, 200);
			this.p_cachesArpAutoIp.Name = "p_cachesArpAutoIp";
			this.p_cachesArpAutoIp.Size = new global::System.Drawing.Size(280, 24);
			this.p_cachesArpAutoIp.TabIndex = 101;
			this.p_cachesArpAutoIp.Valeur = false;
			this.p_cachesArpAutoIp.ValeurDefaut = false;
			this.p_demoInternet.Label = "Démos du composant Internet";
			this.p_demoInternet.Location = new global::System.Drawing.Point(8, 176);
			this.p_demoInternet.Name = "p_demoInternet";
			this.p_demoInternet.Size = new global::System.Drawing.Size(280, 24);
			this.p_demoInternet.TabIndex = 100;
			this.p_demoInternet.Valeur = true;
			this.p_demoInternet.ValeurDefaut = true;
			this.p_cheminPaquet.Items = new string[]
			{
				"Ethernet",
				"IP"
			};
			this.p_cheminPaquet.Label = "Trajet par défaut des paquets";
			this.p_cheminPaquet.Location = new global::System.Drawing.Point(8, 80);
			this.p_cheminPaquet.Name = "p_cheminPaquet";
			this.p_cheminPaquet.Size = new global::System.Drawing.Size(280, 24);
			this.p_cheminPaquet.TabIndex = 99;
			this.p_cheminPaquet.TailleListe = 100;
			this.p_cheminPaquet.ValeurDefaut = "Ethernet";
			global::Simulateur.ParamNumericUpDown paramNumericUpDown96 = this.p_nbSautsMax;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown96.Increment = new decimal(array);
			this.p_nbSautsMax.Label = "TTL paquet IP";
			this.p_nbSautsMax.Location = new global::System.Drawing.Point(8, 152);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown97 = this.p_nbSautsMax;
			array = new int[4];
			array[0] = 99;
			paramNumericUpDown97.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown98 = this.p_nbSautsMax;
			array = new int[4];
			array[0] = 2;
			paramNumericUpDown98.Minimum = new decimal(array);
			this.p_nbSautsMax.Name = "p_nbSautsMax";
			this.p_nbSautsMax.NbDecimales = 0;
			this.p_nbSautsMax.Size = new global::System.Drawing.Size(280, 24);
			this.p_nbSautsMax.TabIndex = 97;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown99 = this.p_nbSautsMax;
			array = new int[4];
			array[0] = 5;
			paramNumericUpDown99.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown100 = this.p_nbSautsMax;
			array = new int[4];
			array[0] = 5;
			paramNumericUpDown100.ValeurDefaut = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown101 = this.p_attentePing;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown101.Increment = new decimal(array);
			this.p_attentePing.Label = "Attente Ping si échec";
			this.p_attentePing.Location = new global::System.Drawing.Point(8, 128);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown102 = this.p_attentePing;
			array = new int[4];
			array[0] = 5000;
			paramNumericUpDown102.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown103 = this.p_attentePing;
			array = new int[4];
			array[0] = 100;
			paramNumericUpDown103.Minimum = new decimal(array);
			this.p_attentePing.Name = "p_attentePing";
			this.p_attentePing.NbDecimales = 0;
			this.p_attentePing.Size = new global::System.Drawing.Size(280, 24);
			this.p_attentePing.TabIndex = 96;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown104 = this.p_attentePing;
			array = new int[4];
			array[0] = 1500;
			paramNumericUpDown104.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown105 = this.p_attentePing;
			array = new int[4];
			array[0] = 1500;
			paramNumericUpDown105.ValeurDefaut = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown106 = this.p_ttlCacheArp;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown106.Increment = new decimal(array);
			this.p_ttlCacheArp.Label = "TTL cache ARP";
			this.p_ttlCacheArp.Location = new global::System.Drawing.Point(8, 104);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown107 = this.p_ttlCacheArp;
			array = new int[4];
			array[0] = 50;
			paramNumericUpDown107.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown108 = this.p_ttlCacheArp;
			array = new int[4];
			array[0] = 2;
			paramNumericUpDown108.Minimum = new decimal(array);
			this.p_ttlCacheArp.Name = "p_ttlCacheArp";
			this.p_ttlCacheArp.NbDecimales = 0;
			this.p_ttlCacheArp.Size = new global::System.Drawing.Size(280, 24);
			this.p_ttlCacheArp.TabIndex = 94;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown109 = this.p_ttlCacheArp;
			array = new int[4];
			array[0] = 20;
			paramNumericUpDown109.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown110 = this.p_ttlCacheArp;
			array = new int[4];
			array[0] = 20;
			paramNumericUpDown110.ValeurDefaut = new decimal(array);
			this.p_trameModeIp.Label = "Montrer la trame";
			this.p_trameModeIp.Location = new global::System.Drawing.Point(8, 56);
			this.p_trameModeIp.Name = "p_trameModeIp";
			this.p_trameModeIp.Size = new global::System.Drawing.Size(280, 24);
			this.p_trameModeIp.TabIndex = 92;
			this.p_trameModeIp.Valeur = true;
			this.p_trameModeIp.ValeurDefaut = true;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown111 = this.p_longueurRoute;
			array = new int[4];
			array[0] = 1;
			paramNumericUpDown111.Increment = new decimal(array);
			this.p_longueurRoute.Label = "Longueur d'une \"route\" IP";
			this.p_longueurRoute.Location = new global::System.Drawing.Point(8, 32);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown112 = this.p_longueurRoute;
			array = new int[4];
			array[0] = 200;
			paramNumericUpDown112.Maximum = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown113 = this.p_longueurRoute;
			array = new int[4];
			array[0] = 10;
			paramNumericUpDown113.Minimum = new decimal(array);
			this.p_longueurRoute.Name = "p_longueurRoute";
			this.p_longueurRoute.NbDecimales = 0;
			this.p_longueurRoute.Size = new global::System.Drawing.Size(280, 24);
			this.p_longueurRoute.TabIndex = 86;
			global::Simulateur.ParamNumericUpDown paramNumericUpDown114 = this.p_longueurRoute;
			array = new int[4];
			array[0] = 50;
			paramNumericUpDown114.Valeur = new decimal(array);
			global::Simulateur.ParamNumericUpDown paramNumericUpDown115 = this.p_longueurRoute;
			array = new int[4];
			array[0] = 50;
			paramNumericUpDown115.ValeurDefaut = new decimal(array);
			this.p_styloPaquet.AllowFullOpen = false;
			this.p_styloPaquet.EpaisseurStylo = 2f;
			this.p_styloPaquet.Label = "Couleur des paquets IP";
			this.p_styloPaquet.Location = new global::System.Drawing.Point(8, 8);
			this.p_styloPaquet.Name = "p_styloPaquet";
			this.p_styloPaquet.Size = new global::System.Drawing.Size(280, 24);
			this.p_styloPaquet.SolidColorOnly = true;
			this.p_styloPaquet.TabIndex = 0;
			this.p_styloPaquet.Valeur = global::System.Drawing.Color.Yellow;
			this.p_styloPaquet.ValeurDefaut = global::System.Drawing.Color.Yellow;
			this.bt_restaurerDefaut.Location = new global::System.Drawing.Point(208, 392);
			this.bt_restaurerDefaut.Name = "bt_restaurerDefaut";
			this.bt_restaurerDefaut.Size = new global::System.Drawing.Size(120, 23);
			this.bt_restaurerDefaut.TabIndex = 71;
			this.bt_restaurerDefaut.Text = "valeurs par défaut";
			this.bt_restaurerDefaut.Click += new global::System.EventHandler(this.bt_restaurerDefaut_Click);
			this.bc_sauvegarder.Location = new global::System.Drawing.Point(112, 392);
			this.bc_sauvegarder.Name = "bc_sauvegarder";
			this.bc_sauvegarder.TabIndex = 70;
			this.bc_sauvegarder.Text = "sauvegarder";
			this.bc_sauvegarder.Click += new global::System.EventHandler(this.bt_sauvegarder_Click);
			this.bt_charger.Location = new global::System.Drawing.Point(24, 392);
			this.bt_charger.Name = "bt_charger";
			this.bt_charger.TabIndex = 69;
			this.bt_charger.Text = "charger";
			this.bt_charger.Click += new global::System.EventHandler(this.bt_charger_Click);
			this.bt_fermer.Location = new global::System.Drawing.Point(376, 392);
			this.bt_fermer.Name = "bt_fermer";
			this.bt_fermer.TabIndex = 68;
			this.bt_fermer.Text = "fermer";
			this.bt_fermer.Click += new global::System.EventHandler(this.bt_fermer_Click);
			this.sd_enregistrer.DefaultExt = "xml";
			this.sd_enregistrer.FileName = "param";
			this.sd_enregistrer.Filter = "Fichiers xml|*.xml";
			this.od_ouvrir.DefaultExt = "xml";
			this.od_ouvrir.Filter = "Fichiers xml|*.xml";
			this.p_memoriserPosition.Label = "Mémoriser position des démos";
			this.p_memoriserPosition.Location = new global::System.Drawing.Point(16, 320);
			this.p_memoriserPosition.Name = "p_memoriserPosition";
			this.p_memoriserPosition.Size = new global::System.Drawing.Size(208, 24);
			this.p_memoriserPosition.TabIndex = 98;
			this.p_memoriserPosition.Valeur = false;
			this.p_memoriserPosition.ValeurDefaut = false;
			base.AcceptButton = this.bt_fermer;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(504, 423);
			base.Controls.Add(this.tc_onglets);
			base.Controls.Add(this.bt_restaurerDefaut);
			base.Controls.Add(this.bc_sauvegarder);
			base.Controls.Add(this.bt_charger);
			base.Controls.Add(this.bt_fermer);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "Param";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Paramétrage";
			this.tc_onglets.ResumeLayout(false);
			this.tp_conception.ResumeLayout(false);
			this.tp_ethernet.ResumeLayout(false);
			this.tp_tcpIp.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400040A RID: 1034
		private global::Simulateur.ParamCouleur p_surbrillancePointConnexion;

		// Token: 0x0400040B RID: 1035
		private global::Simulateur.ParamCouleur p_couleurConnexionConception;

		// Token: 0x0400040C RID: 1036
		private global::Simulateur.ParamNumericUpDown p_longueurCableMax;

		// Token: 0x0400040D RID: 1037
		private global::Simulateur.ParamCouleur p_selectionStylo;

		// Token: 0x0400040E RID: 1038
		private global::Simulateur.ParamNumericUpDown p_longueurCableDefaut;

		// Token: 0x0400040F RID: 1039
		private global::Simulateur.ParamNumericUpDown p_nbPortsCascadeSwitch;

		// Token: 0x04000410 RID: 1040
		private global::Simulateur.ParamNumericUpDown p_nbPortsSwitch;

		// Token: 0x04000411 RID: 1041
		private global::Simulateur.ParamNumericUpDown p_nbPortsCascadeHub;

		// Token: 0x04000412 RID: 1042
		private global::Simulateur.ParamCouleur p_normalStylo;

		// Token: 0x04000413 RID: 1043
		private global::Simulateur.ParamNumericUpDown p_nbPortsHub;

		// Token: 0x04000414 RID: 1044
		private global::Simulateur.ParamNumericUpDown p_nbMetresParTick;

		// Token: 0x04000415 RID: 1045
		private global::Simulateur.ParamNumericUpDown p_tempsDelaiTransmissionSwitch;

		// Token: 0x04000416 RID: 1046
		private global::Simulateur.ParamNumericUpDown p_coefEmissionTrameLongue;

		// Token: 0x04000417 RID: 1047
		private global::Simulateur.ParamNumericUpDown p_tempsDelaiTransmissionHub;

		// Token: 0x04000418 RID: 1048
		private global::Simulateur.ParamNumericUpDown p_coefEmissionTrameCourte;

		// Token: 0x04000419 RID: 1049
		private global::Simulateur.ParamNumericUpDown p_tempsEmissionTrame;

		// Token: 0x0400041A RID: 1050
		private global::Simulateur.ParamNumericUpDown p_tempsAttenteEcoute;

		// Token: 0x0400041B RID: 1051
		private global::Simulateur.ParamNumericUpDown p_tempsAttenteDemoDefaut;

		// Token: 0x0400041C RID: 1052
		private global::Simulateur.ParamBool p_traceParDefaut;

		// Token: 0x0400041D RID: 1053
		private global::Simulateur.ParamCouleur p_couleurErreurEthernet;

		// Token: 0x0400041E RID: 1054
		private global::Simulateur.ParamCouleur p_couleurActifEthernet;

		// Token: 0x0400041F RID: 1055
		private global::Simulateur.ParamCouleur p_couleurAllumeEthernet;

		// Token: 0x04000420 RID: 1056
		private global::Simulateur.ParamCouleur p_cableActifStylo2;

		// Token: 0x04000421 RID: 1057
		private global::Simulateur.ParamCouleur p_cableActifStylo1;

		// Token: 0x04000422 RID: 1058
		private global::Simulateur.ParamCouleur p_styloCollision;

		// Token: 0x04000423 RID: 1059
		protected global::System.Windows.Forms.Button bt_restaurerDefaut;

		// Token: 0x04000424 RID: 1060
		protected global::System.Windows.Forms.Button bc_sauvegarder;

		// Token: 0x04000425 RID: 1061
		protected global::System.Windows.Forms.Button bt_charger;

		// Token: 0x04000426 RID: 1062
		protected global::System.Windows.Forms.Button bt_fermer;

		// Token: 0x04000427 RID: 1063
		private global::System.Windows.Forms.SaveFileDialog sd_enregistrer;

		// Token: 0x04000428 RID: 1064
		private global::System.Windows.Forms.OpenFileDialog od_ouvrir;

		// Token: 0x04000429 RID: 1065
		private global::Simulateur.TabParam tc_onglets;

		// Token: 0x0400042A RID: 1066
		private global::System.Windows.Forms.TabPage tp_conception;

		// Token: 0x0400042B RID: 1067
		private global::System.Windows.Forms.TabPage tp_ethernet;

		// Token: 0x0400042C RID: 1068
		private global::Simulateur.ParamBool p_storeAndForward;

		// Token: 0x0400042D RID: 1069
		private global::Simulateur.ParamBool p_spanningTree;

		// Token: 0x0400042E RID: 1070
		private global::Simulateur.ParamCouleur p_couleurBloqueEthernet;

		// Token: 0x0400042F RID: 1071
		private global::Simulateur.ParamNumericUpDown p_tempsInterTrames;

		// Token: 0x04000430 RID: 1072
		private global::Simulateur.ParamNumericUpDown p_tauxRalenti;

		// Token: 0x04000431 RID: 1073
		private global::System.Windows.Forms.Label lbl_delaiReemission;

		// Token: 0x04000432 RID: 1074
		private global::Simulateur.ParamNumericUpDown p_delaiReemissionW;

		// Token: 0x04000433 RID: 1075
		private global::Simulateur.ParamNumericUpDown p_delaiReemissionZ;

		// Token: 0x04000434 RID: 1076
		private global::Simulateur.ParamNumericUpDown p_delaiReemissionY;

		// Token: 0x04000435 RID: 1077
		private global::Simulateur.ParamNumericUpDown p_delaiReemissionX;

		// Token: 0x04000436 RID: 1078
		private global::Simulateur.ParamNumericUpDown p_nbPorts8021qSwitch;

		// Token: 0x04000437 RID: 1079
		private global::Simulateur.ParamNumericUpDown p_niveauVlanSwitch;

		// Token: 0x04000438 RID: 1080
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000439 RID: 1081
		private global::Simulateur.ParamCouleur p_stylo8021q;

		// Token: 0x0400043A RID: 1082
		private global::Simulateur.ParamBool p_annonceStations;

		// Token: 0x0400043B RID: 1083
		private global::System.Windows.Forms.TabPage tp_tcpIp;

		// Token: 0x0400043C RID: 1084
		private global::Simulateur.ParamCouleur p_styloPaquet;

		// Token: 0x0400043D RID: 1085
		private global::Simulateur.ParamNumericUpDown p_longueurRoute;

		// Token: 0x0400043E RID: 1086
		private global::Simulateur.ParamBool p_trameModeIp;

		// Token: 0x0400043F RID: 1087
		private global::Simulateur.ParamNumericUpDown p_ttlCacheArp;

		// Token: 0x04000440 RID: 1088
		private global::Simulateur.ParamNumericUpDown p_attentePing;

		// Token: 0x04000441 RID: 1089
		private global::Simulateur.ParamNumericUpDown p_nbSautsMax;

		// Token: 0x04000442 RID: 1090
		private global::Simulateur.ParamListe p_cheminPaquet;

		// Token: 0x04000443 RID: 1091
		private global::System.ComponentModel.Container components = null;

		// Token: 0x04000444 RID: 1092
		private global::Simulateur.ParamBool p_demoInternet;

		// Token: 0x04000445 RID: 1093
		private global::Simulateur.ParamBool p_cachesArpAutoIp;

		// Token: 0x04000446 RID: 1094
		private global::Simulateur.ParamBool p_icones;

		// Token: 0x04000447 RID: 1095
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000448 RID: 1096
		private global::Simulateur.ParamBool p_traitsEpais;

		// Token: 0x04000449 RID: 1097
		private global::Simulateur.ParamBool p_memoriserPosition;
	}
}
