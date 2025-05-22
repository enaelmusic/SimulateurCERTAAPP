using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Simulateur
{
	// Token: 0x02000011 RID: 17
	public class CarteReseau : PointConnexion
	{
		// Token: 0x0600012E RID: 302 RVA: 0x00009F38 File Offset: 0x00008F38
		public CarteReseau()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00009F78 File Offset: 0x00008F78
		public CarteReseau(Simulation s) : base(s)
		{
			this.InitializeComponent();
			this.initialiser();
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00009FC0 File Offset: 0x00008FC0
		private void initialiser()
		{
			base.Size = new Size(11, 11);
			this.reseau.NbCartesReseau++;
			if (this.reseau.NbCartesReseau < 10)
			{
				this.adresseMac = "mac0" + this.reseau.NbCartesReseau.ToString();
			}
			else
			{
				this.adresseMac = "mac" + this.reseau.NbCartesReseau.ToString();
			}
			this.mi_configurer.Text = "Configuration";
			this.SetContenuInfoBulle();
			this.ip = new Ip_carte(this);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000A068 File Offset: 0x00009068
		protected override void initOkCables()
		{
			this.typePointConnexion = PointConnexion.TypesPointConnexion.carteReseau;
			this.okCableCroise.Add(PointConnexion.TypesPointConnexion.carteReseau);
			this.okCableCroise.Add(PointConnexion.TypesPointConnexion.portCascadeHub);
			this.okCableCroise.Add(PointConnexion.TypesPointConnexion.portCascadeSwitch);
			this.okCableDroit.Add(PointConnexion.TypesPointConnexion.portHub);
			this.okCableDroit.Add(PointConnexion.TypesPointConnexion.portSwitch);
			this.okCableCoaxial.Add(PointConnexion.TypesPointConnexion.carteReseau);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000A0E8 File Offset: 0x000090E8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000A114 File Offset: 0x00009114
		private void InitializeComponent()
		{
			this.mi_emettreTrame = new MenuItem();
			this.mi_configIp = new MenuItem();
			this.cm_ip.MenuItems.AddRange(new MenuItem[]
			{
				this.mi_configIp
			});
			this.cm_ethernet.MenuItems.AddRange(new MenuItem[]
			{
				this.mi_emettreTrame
			});
			this.mi_emettreTrame.Index = 0;
			this.mi_emettreTrame.Text = "Emettre une trame";
			this.mi_emettreTrame.Click += this.mi_emettreTrame_Click;
			this.mi_configIp.Index = 0;
			this.mi_configIp.Text = "Configuration IP";
			this.mi_configIp.Click += this.mi_configIp_Click;
			base.Name = "CarteReseau";
			base.Size = new Size(88, 197);
			base.MouseDown += this.CarteReseau_MouseDown;
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000134 RID: 308 RVA: 0x0000A210 File Offset: 0x00009210
		// (set) Token: 0x06000135 RID: 309 RVA: 0x0000A224 File Offset: 0x00009224
		public string AdresseMac
		{
			get
			{
				return this.adresseMac;
			}
			set
			{
				this.adresseMac = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000136 RID: 310 RVA: 0x0000A238 File Offset: 0x00009238
		// (set) Token: 0x06000137 RID: 311 RVA: 0x0000A24C File Offset: 0x0000924C
		public string Protocole
		{
			get
			{
				return this.protocole;
			}
			set
			{
				this.protocole = value;
			}
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000A260 File Offset: 0x00009260
		protected override ContextMenu menuConception()
		{
			ContextMenu contextMenu = new ContextMenu(new MenuItem[]
			{
				this.mi_configurer
			});
			if (this.lien != null)
			{
				contextMenu.MenuItems.AddRange(new MenuItem[]
				{
					this.mi_configurerCable,
					this.mi_supprimerCable
				});
			}
			return contextMenu;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000A2B4 File Offset: 0x000092B4
		protected override ContextMenu menuEthernet()
		{
			this.reseau.DeuxTrames = false;
			ContextMenu result;
			switch (this.reseau.EtatEthernetActif)
			{
			case Simulation.EtatEthernet.attente:
			{
				Simulation.TypeDeSimulationEthernet simulationEthernet = this.reseau.SimulationEthernet;
				if (simulationEthernet == Simulation.TypeDeSimulationEthernet.monteeCharge)
				{
					result = null;
				}
				else if (this.etatConnexion == PointConnexion.EtatsConnexion.actif)
				{
					result = this.cm_ethernet;
				}
				else
				{
					result = null;
				}
				break;
			}
			case Simulation.EtatEthernet.simulationEnPreparation:
				if (this.reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.trameReelle)
				{
					if (this.reseau.NbTrameCarte == 0)
					{
						result = this.cm_ethernet;
					}
					else if (this.reseau.NbTrameCarte == 1)
					{
						if (this.reseau.OkCollision(this))
						{
							result = this.cm_ethernet;
						}
						else
						{
							result = null;
						}
					}
					else
					{
						result = null;
					}
				}
				else
				{
					result = null;
				}
				break;
			case Simulation.EtatEthernet.simulationEnCours:
				result = null;
				break;
			default:
				result = null;
				break;
			}
			return result;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000A378 File Offset: 0x00009378
		private void modeDeuxPaires()
		{
			ArrayList arrayList = new ArrayList();
			if (this.lien.Type != Cable.TypeCable.coaxial)
			{
				this.lien.ModeDeuxPaires();
			}
			arrayList.Add(this.lien);
			this.lien.Oppose(this).NoeudAttache.ModeDeuxPaires(this.lien.Oppose(this), ref arrayList);
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000A3D8 File Offset: 0x000093D8
		public void ModeCableSimple()
		{
			this.reseau.DeuxTrames = false;
			ArrayList arrayList = new ArrayList();
			if (this.lien.Type != Cable.TypeCable.coaxial)
			{
				this.lien.ModeCableSimple();
			}
			arrayList.Add(this.lien);
			this.lien.Oppose(this).NoeudAttache.ModeCableSimple(this.lien.Oppose(this), ref arrayList);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0000A444 File Offset: 0x00009444
		public override void Configurer()
		{
			ConfigCarte configCarte = new ConfigCarte();
			if (base.GetType() == typeof(CarteAccesDistant))
			{
				configCarte.Text = "Configuration d'une carte d'accès distant";
			}
			configCarte.AdresseMac = this.adresseMac;
			configCarte.ShowDialog();
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000A488 File Offset: 0x00009488
		public void mi_emettreTrame_Click(object sender, EventArgs e)
		{
			if (this.reseau.NoBouclesHub(this.lien.Oppose(this).NoeudAttache))
			{
				this.reseau.PreparerSimulation();
				this.reseau.NbTrameCarte++;
				if (this.reseau.DialogueEmissionTrame1 == null)
				{
					if (!this.reseau.BisEnCours)
					{
						this.reseau.DerniereSimulation.PremiereCarte = this;
						this.reseau.DerniereSimulation.DeuxEmissions = false;
					}
					this.dialogueEmissionTrame = new EmissionTrameDialogue(this, 1);
					this.reseau.DialogueEmissionTrame1 = this.dialogueEmissionTrame;
				}
				else
				{
					if (!this.reseau.BisEnCours)
					{
						this.reseau.DerniereSimulation.SecondeCarte = this;
						this.reseau.DerniereSimulation.DeuxEmissions = true;
						this.reseau.DerniereSimulation.DeuxTramesEmises = false;
					}
					this.dialogueEmissionTrame = new EmissionTrameDialogue(this, 2);
					this.reseau.DialogueEmissionTrame2 = this.dialogueEmissionTrame;
				}
				this.dialogueEmissionTrame.Location = this.posDialogueDemo();
				this.dialogueEmissionTrame.InScreen();
				this.dialogueEmissionTrame.Show();
				this.reseau.PreparerStop();
				if (this.reseau.NbTrameCarte == 2)
				{
					if (this.lien.Type != Cable.TypeCable.coaxial)
					{
						this.reseau.DeuxTrames = true;
						this.reseau.MessageReception = false;
						this.reseau.DialogueEmissionTrame1.CollisionDeuxPaires = true;
						this.reseau.DialogueEmissionTrame2.CollisionDeuxPaires = true;
					}
					this.modeDeuxPaires();
					return;
				}
			}
			else
			{
				MessageBox.Show("Impossible, le réseau comporte des boucles !");
			}
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000A628 File Offset: 0x00009628
		public override void SuiteEmissionTrame(int taille)
		{
			this.collisionDurantEmission = false;
			if (this.reseau.EtatEthernetActif != Simulation.EtatEthernet.simulationEnCours)
			{
				if (this.reseau.Pref.MontrerTrame)
				{
					this.reseau.MontrerTrame(this.dialogueEmissionTrame.NumOrdreTrame, this.dialogueEmissionTrame.Destinataire, this.adresseMac);
				}
				this.reseau.DemarrerSimulation();
				this.reseau.TrameBienRecue = false;
				if (!this.reseau.BisEnCours)
				{
					this.reseau.DerniereSimulation.PremiereTrame = this.dialogueEmissionTrame.NumOrdreTrame;
				}
			}
			else if (!this.reseau.BisEnCours)
			{
				this.reseau.DerniereSimulation.DeuxTramesEmises = true;
			}
			bool collisionDeuxPaires;
			if (this.dialogueEmissionTrame.NumOrdreTrame == 1)
			{
				if (!this.reseau.BisEnCours)
				{
					this.reseau.SetDonneesSimulation(1, DateTime.Now, this, this.dialogueEmissionTrame.Destinataire, this.dialogueEmissionTrame.TailleTrame);
				}
				if (this.reseau.DialogueEmissionTrame2 != null)
				{
					this.reseau.DialogueEmissionTrame2.Desactiver(false);
				}
				collisionDeuxPaires = this.reseau.DialogueEmissionTrame1.CollisionDeuxPaires;
				this.trame = new TrameEthernet(1, 0, this, this.adresseMac, this.dialogueEmissionTrame.Destinataire, "bonjour de " + base.NoeudAttache.NomNoeud + ":" + this.adresseMac, this.reseau);
				this.reseau.DialogueEmissionTrame1 = null;
				base.AllumerReception(1);
			}
			else
			{
				if (!this.reseau.BisEnCours)
				{
					this.reseau.SetDonneesSimulation(2, DateTime.Now, this, this.dialogueEmissionTrame.Destinataire, this.dialogueEmissionTrame.TailleTrame);
				}
				if (this.reseau.DialogueEmissionTrame1 != null)
				{
					this.reseau.DialogueEmissionTrame1.Desactiver(false);
				}
				collisionDeuxPaires = this.reseau.DialogueEmissionTrame2.CollisionDeuxPaires;
				this.trame = new TrameEthernet(2, 0, this, this.adresseMac, this.dialogueEmissionTrame.Destinataire, "bonjour de " + base.NoeudAttache.NomNoeud + ":" + this.adresseMac, this.reseau);
				this.reseau.DialogueEmissionTrame2 = null;
				base.AllumerReception(2);
			}
			if (base.PosDemoEmission == new Point(0, 0))
			{
				base.PosDemoEmission = this.posDialogueDemo();
			}
			this.dialogueEmissionTrame.Close();
			this.dialogueEmissionTrame = null;
			this.trame.TailleTrame = taille;
			if (this.reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.trameReelle)
			{
				this.reseau.Bt_pauseReprise.Enabled = true;
				this.reseau.Bt_pauseReprise.ImageIndex = 1;
				this.reseau.Bt_pauseReprise.Tag = "pause";
				bool flag = this.reseau.FullDuplex;
				if (flag && (this.lien.Type == Cable.TypeCable.coaxial || this.lien.Oppose(this).GetType() == typeof(PortHub) || this.lien.Oppose(this).GetType() == typeof(PortDeCascadeHub)))
				{
					flag = false;
				}
				this.demoEmission = new DDialogPlusEmissionTrame(this, this.reseau, this.trame.TempsEmission(), collisionDeuxPaires, true);
				this.demoEmission.Text = base.NoeudAttache.NomNoeud + " : " + this.adresseMac;
				this.demoEmission.DemoTerminee += this.CarteReseau_DemoEmissionTerminee;
				this.demoEmission.DemarrerDemo(this.trame, this, base.PosDemoEmission, this.reseau.DemoEmission && base.NoeudAttache.trace(), false, flag);
				return;
			}
			this.trame.IncrementerNbTransmissions();
			base.transmettreTrame(this.trame, this.lien);
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x0600013F RID: 319 RVA: 0x0000AA00 File Offset: 0x00009A00
		// (remove) Token: 0x06000140 RID: 320 RVA: 0x0000AA24 File Offset: 0x00009A24
		public override event EtatTransitionEventHandler EvtEtatTransition;

		// Token: 0x06000141 RID: 321 RVA: 0x0000AA48 File Offset: 0x00009A48
		public override void DebutTrameSurCable()
		{
			this.trame.Collisee = false;
			this.trame.Annulee = false;
			this.reseau.IncrementerNbTramesEnCours("Carte " + this.adresseMac);
			this.trame.NbTransmissionsEnCours = 0;
			this.trame.IncrementerNbTransmissions();
			base.transmettreDebutTrame(this.trame, this.lien);
			base.AllumerReception(this.trame.NumeroTrame);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000AAC4 File Offset: 0x00009AC4
		public override void FinTrameSurCable(bool p_collisee)
		{
			if (!this.trame.Collisee)
			{
				this.trame.Collisee = p_collisee;
			}
			base.transmettreFinTrame(this.trame, this.lien);
			if (!this.trame.Collisee)
			{
				base.EteindreReception();
			}
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0000AB10 File Offset: 0x00009B10
		private void attendreRetablirCouleur(object sender, EventArgs e)
		{
			this.nbTicksRetablirCouleur++;
			if (this.nbTicksRetablirCouleur == 100)
			{
				this.nbTicksRetablirCouleur = 0;
				this.reseau.TimerTraceTrame.Tick -= this.attendreRetablirCouleur;
				this.retablirCouleur();
			}
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000AB60 File Offset: 0x00009B60
		private void retablirCouleur()
		{
			if (this.demoEmission == null)
			{
				base.changerEtat(this.etatConnexion);
				return;
			}
			if (this.trame.NumeroTrame == 1)
			{
				this.BackColor = this.reseau.Pref.CableActifStylo1.Color;
				return;
			}
			this.BackColor = this.reseau.Pref.CableActifStylo2.Color;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0000ABC8 File Offset: 0x00009BC8
		public void CarteReseau_DemoEmissionTerminee(object sender, EventArgs e)
		{
			if (this.demoEmission != null)
			{
				this.demoEmission.DemoTerminee -= this.CarteReseau_DemoEmissionTerminee;
				if (this.reseau.SimulationEthernet == Simulation.TypeDeSimulationEthernet.trameReelle)
				{
					if (this.reseau.NbTrameEnCours == 0 && this.reseau.NbCollisionsDeuxPaires == 0 && this.reseau.OwnedForms.GetLength(0) == 0)
					{
						this.reseau.ArreterSimulation(this);
					}
				}
				else if (this.reseau.NbTransmissionsTotales == 0 && this.reseau.NbCollisionsDeuxPaires == 0 && this.reseau.OwnedForms.GetLength(0) == 0)
				{
					this.reseau.ArreterSimulation(this);
				}
				this.demoEmission = null;
			}
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0000AC80 File Offset: 0x00009C80
		public override void AbandonEmissionTrame()
		{
			this.dialogueEmissionTrame.Close();
			if (this.dialogueEmissionTrame.NumOrdreTrame == 1)
			{
				this.reseau.DialogueEmissionTrame1 = null;
			}
			else
			{
				this.reseau.DialogueEmissionTrame2 = null;
			}
			this.reseau.NbTrameCarte--;
			this.reseau.TrameBienRecue = true;
			if (this.reseau.NbTrameCarte == 0)
			{
				this.reseau.ArreterSimulation(this);
				return;
			}
			if (this.reseau.EtatEthernetActif != Simulation.EtatEthernet.simulationEnCours)
			{
				if (this.reseau.DialogueEmissionTrame1 == null)
				{
					this.reseau.DialogueEmissionTrame2.CollisionDeuxPaires = false;
				}
				else
				{
					this.reseau.DialogueEmissionTrame1.CollisionDeuxPaires = false;
				}
				this.ModeCableSimple();
			}
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0000AD40 File Offset: 0x00009D40
		private void CarteReseau_TrameTransmise(ElementReseau sender, TrameEventArgs e)
		{
			if (e.Cible == this)
			{
				switch (this.reseau.SimulationEthernet)
				{
				case Simulation.TypeDeSimulationEthernet.circulationTrame:
					this.trameEnCours = e;
					if (base.NoeudAttache.trace())
					{
						this.demo = new DemoCarteReseau(this.reseau);
						this.demo.TitreDialogue = base.NoeudAttache.NomNoeud + " (" + this.adresseMac + ")";
						this.demo.DemoTerminee += this.CarteReseau_DemoTerminee;
						this.demo.DemarrerDemo(sender, this, e.Trame, this.reseau.TypeDemo);
						return;
					}
					this.CarteReseau_DemoTerminee(null, null);
					break;
				case Simulation.TypeDeSimulationEthernet.trameReelle:
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0000AE04 File Offset: 0x00009E04
		private void CarteReseau_DebutTrameTransmis(ElementReseau sender, TrameEventArgs e)
		{
			if (e.Cible == this)
			{
				this.trameEnCours = e;
				this.envoyerEvenementTransition(DDialogPlusEmissionTrame.TypEvtTransition.carteTrameRecue);
				if (this.reseau.SimulationEthernet != Simulation.TypeDeSimulationEthernet.trameReelle && (this.trameEnCours.Trame.MacDestinataire == this.adresseMac || this.trameEnCours.Trame.MacDestinataire == this.reseau.Pref.AdrMacBroadcast))
				{
					base.AllumerReception(this.trameEnCours.Trame.NumeroTrame);
				}
			}
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0000AE90 File Offset: 0x00009E90
		private void CarteReseau_FinTrameTransmis(ElementReseau sender, TrameEventArgs e)
		{
			if (e.Cible == this)
			{
				if (e.Trame.MacDestinataire == this.adresseMac || e.Trame.MacDestinataire == this.reseau.Pref.AdrMacBroadcast)
				{
					if (!this.reseau.DeuxTrames)
					{
						e.Trame.BienRecue = true;
					}
					if (this.reseau.MessageReception)
					{
						((Station)base.NoeudAttache).Message.ShowDialog(e.Trame.Info, base.NoeudAttache.NomNoeud + ":" + this.adresseMac);
					}
					base.EteindreReception();
					if (e.Trame.Collisee)
					{
						this.BackColor = this.reseau.Pref.StyloCollision.Color;
						this.reseau.TimerTraceTrame.Tick += this.attendreRetablirCouleur;
					}
				}
				this.Liberer();
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0000AF98 File Offset: 0x00009F98
		public void CarteReseau_DemoTerminee(object sender, EventArgs e)
		{
			if (this.demo != null)
			{
				this.demo.DemoTerminee -= this.CarteReseau_DemoTerminee;
			}
			if (this.trameEnCours.Trame.MacDestinataire == this.adresseMac || this.trameEnCours.Trame.MacDestinataire == this.reseau.Pref.AdrMacBroadcast)
			{
				this.trameEnCours.Trame.BienRecue = true;
				base.AllumerReception(this.trameEnCours.Trame.NumeroTrame);
				this.trameEnCours.Trame.TransmissionTrameAchevee += this.CarteReseau_TransmissionTrameAchevee;
			}
			base.receptionnerTrame(this.trameEnCours.Trame);
			this.trameEnCours = null;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000B064 File Offset: 0x0000A064
		private void CarteReseau_TransmissionTrameAchevee(ElementReseau sender, TrameEventArgs e)
		{
			e.Trame.TransmissionTrameAchevee -= this.CarteReseau_TransmissionTrameAchevee;
			if (this.reseau.MessageReception)
			{
				((Station)base.NoeudAttache).Message.ShowDialog(e.Trame.Info, base.NoeudAttache.NomNoeud + ":" + this.adresseMac);
			}
			base.EteindreReception();
			if (e.Trame.SegmentEmetteur && e.Trame.ToutesCartesPrevenues())
			{
				e.Trame.CarteEmetteur.EteindreReception();
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000B100 File Offset: 0x0000A100
		private void envoyerEvenementTransition(DDialogPlusEmissionTrame.TypEvtTransition evt)
		{
			if (this.EvtEtatTransition != null)
			{
				this.EvtEtatTransition(this, new EtatTransitionEventArgs((int)evt));
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0000B128 File Offset: 0x0000A128
		private void CarteReseau_CollisionRecue(ElementReseau sender, TrameEventArgs e)
		{
			if (e.Cible == this)
			{
				this.envoyerEvenementTransition(DDialogPlusEmissionTrame.TypEvtTransition.carteCollisionRecue);
			}
			if (this.collisionDurantEmission)
			{
				this.envoyerEvenementTransition(DDialogPlusEmissionTrame.TypEvtTransition.carteCollisionTransmise);
				return;
			}
			this.collisionDurantEmission = true;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000B15C File Offset: 0x0000A15C
		private void CarteReseau_CollisionDeuxPairesRecue(object sender, EventArgs e)
		{
			this.envoyerEvenementTransition(DDialogPlusEmissionTrame.TypEvtTransition.carteCollisionRecue);
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0000B170 File Offset: 0x0000A170
		private void CarteReseau_CollisionRepandue(object sender, EventArgs e)
		{
			this.Liberer();
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000B184 File Offset: 0x0000A184
		public override void Liberer()
		{
			this.trameEnCours = null;
			this.envoyerEvenementTransition(DDialogPlusEmissionTrame.TypEvtTransition.carteCableLibre);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000B1A0 File Offset: 0x0000A1A0
		public override void LibererEmission()
		{
			this.trameEnCours = null;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000B1B4 File Offset: 0x0000A1B4
		public override void LibererReception()
		{
			this.envoyerEvenementTransition(DDialogPlusEmissionTrame.TypEvtTransition.carteCableLibre);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000B1C8 File Offset: 0x0000A1C8
		public override void InstallerGestionEvenements()
		{
			if (this.lien != null)
			{
				this.lien.TrameTransmise += this.CarteReseau_TrameTransmise;
				this.lien.DebutTrameTransmis += this.CarteReseau_DebutTrameTransmis;
				this.lien.FinTrameTransmis += this.CarteReseau_FinTrameTransmis;
				Cable lien = this.lien;
				lien.CollisionRecue = (TrameEventHandler)Delegate.Combine(lien.CollisionRecue, new TrameEventHandler(this.CarteReseau_CollisionRecue));
				Cable lien2 = this.lien;
				lien2.CollisionDeuxPaires = (EventHandler)Delegate.Combine(lien2.CollisionDeuxPaires, new EventHandler(this.CarteReseau_CollisionDeuxPairesRecue));
				Cable lien3 = this.lien;
				lien3.CollisionRepandue = (EventHandler)Delegate.Combine(lien3.CollisionRepandue, new EventHandler(this.CarteReseau_CollisionRepandue));
			}
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000B29C File Offset: 0x0000A29C
		public override void DesinstallerGestionEvenements()
		{
			if (this.lien != null)
			{
				this.lien.TrameTransmise -= this.CarteReseau_TrameTransmise;
				this.lien.DebutTrameTransmis -= this.CarteReseau_DebutTrameTransmis;
				this.lien.FinTrameTransmis -= this.CarteReseau_FinTrameTransmis;
				Cable lien = this.lien;
				lien.CollisionRecue = (TrameEventHandler)Delegate.Remove(lien.CollisionRecue, new TrameEventHandler(this.CarteReseau_CollisionRecue));
				Cable lien2 = this.lien;
				lien2.CollisionDeuxPaires = (EventHandler)Delegate.Remove(lien2.CollisionDeuxPaires, new EventHandler(this.CarteReseau_CollisionDeuxPairesRecue));
				Cable lien3 = this.lien;
				lien3.CollisionRepandue = (EventHandler)Delegate.Remove(lien3.CollisionRepandue, new EventHandler(this.CarteReseau_CollisionRepandue));
				this.reseau.TimerTraceTrame.Tick -= this.attendreRetablirCouleur;
				this.retablirCouleur();
			}
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0000B390 File Offset: 0x0000A390
		public override string LibelleEmissionTrame()
		{
			return this.adresseMac;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000B3A4 File Offset: 0x0000A3A4
		private void CarteReseau_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				switch (this.reseau.ModeActif)
				{
				case Simulation.Mode.conceptionReseau:
					break;
				case Simulation.Mode.ethernet:
					if (this.reseau.AdrMacAttente != null)
					{
						this.reseau.AdrMacAttente.Text = this.adresseMac;
						return;
					}
					break;
				case Simulation.Mode.ip:
					if (this.reseau.AdrMacAttente != null)
					{
						this.reseau.AdrMacAttente.Text = this.adresseMac;
					}
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0000B424 File Offset: 0x0000A424
		public override Point posDialogueDemo()
		{
			return base.NoeudAttache.posDialogueDemo();
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0000B43C File Offset: 0x0000A43C
		public override void StockerXml(XmlTextWriter writer)
		{
			writer.WriteStartElement("carte");
			writer.WriteAttributeString("adresseMac", this.adresseMac);
			writer.WriteElementString("PosDemoEmission.X", base.PosDemoEmission.X.ToString());
			writer.WriteElementString("PosDemoEmission.Y", base.PosDemoEmission.Y.ToString());
			this.ip.StockerXml(writer);
			writer.WriteEndElement();
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0000B4BC File Offset: 0x0000A4BC
		public override void ReinitEthernet()
		{
			if (this.demoEmission != null)
			{
				this.demoEmission.DemoTerminee -= this.CarteReseau_DemoEmissionTerminee;
				this.demoEmission.ReinitEthernet();
				this.demoEmission = null;
			}
			if (this.demo != null)
			{
				this.demo.DemoTerminee -= this.CarteReseau_DemoTerminee;
				this.demo = null;
			}
			if (this.trameEnCours != null)
			{
				this.trameEnCours.Trame.TransmissionTrameAchevee -= this.CarteReseau_TransmissionTrameAchevee;
				this.trameEnCours = null;
			}
			this.senderEnCours = null;
			this.DesinstallerGestionEvenements();
			this.dialogueEmissionTrame = null;
			this.collisionDurantEmission = false;
			if (this.trame != null)
			{
				this.trame.ReinitEthernet();
				this.trame = null;
			}
			if (this.etatConnexion == PointConnexion.EtatsConnexion.actif)
			{
				base.EteindreReception();
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000B590 File Offset: 0x0000A590
		public override void ChangerMode(Simulation.Mode nouveauMode)
		{
			this.SetContenuInfoBulle();
			switch (nouveauMode)
			{
			case Simulation.Mode.conceptionReseau:
				this.infoBulle.Active = false;
				return;
			case Simulation.Mode.ethernet:
				this.infoBulle.Active = true;
				return;
			case Simulation.Mode.ip:
				this.infoBulle.Active = true;
				return;
			case Simulation.Mode.appl:
				this.infoBulle.Active = false;
				return;
			default:
				return;
			}
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0000B5F0 File Offset: 0x0000A5F0
		public override void SetContenuInfoBulle()
		{
			switch (this.reseau.ModeActif)
			{
			case Simulation.Mode.ethernet:
				this.infoBulle.SetToolTip(this, this.adresseMac);
				return;
			case Simulation.Mode.ip:
			{
				string caption = string.Concat(new string[]
				{
					this.adresseMac,
					" : ",
					this.ip.Adresse.ToString(),
					" (",
					this.ip.Masque.ToString(),
					")"
				});
				this.infoBulle.SetToolTip(this, caption);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0000B690 File Offset: 0x0000A690
		private void mi_configIp_Click(object sender, EventArgs e)
		{
			new Ip_ConfigIpCarte(this, new SuiteOk(this.ControleIpCarte))
			{
				Adresse = this.ip.Adresse.ToString(),
				Masque = this.ip.Masque.ToString(),
				Dhcp = this.ip.Dhcp
			}.Afficher();
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0000B6F4 File Offset: 0x0000A6F4
		public void ControleIpCarte(object p_dialogue)
		{
			this.reseau.BloquerBisIp();
			bool flag = true;
			Ip_ConfigIpCarte ip_ConfigIpCarte = (Ip_ConfigIpCarte)p_dialogue;
			ip_ConfigIpCarte.Adresse = ip_ConfigIpCarte.Adresse.Trim();
			ip_ConfigIpCarte.Masque = ip_ConfigIpCarte.Masque.Trim();
			if (ip_ConfigIpCarte.Adresse != this.ip.Adresse.ToString() && Ip_adresse.Existe(ip_ConfigIpCarte.Adresse, this.reseau.Schema))
			{
				MessageBox.Show("Adresse IP déjà utilisée !" + Environment.NewLine + "(Le simulateur n'autorise pas les adresses dupliquées, même sur des réseaux différents)");
				flag = false;
			}
			else
			{
				if (ip_ConfigIpCarte.Adresse == "0.0.0.0")
				{
					ip_ConfigIpCarte.Masque = "0.0.0.0";
				}
				if (!Ip_adresse.Ok(ip_ConfigIpCarte.Adresse, ip_ConfigIpCarte.Masque))
				{
					MessageBox.Show("Erreur de configuration !");
					flag = false;
				}
				else if (Internet.IsAdrReseauInternet(this.reseau, ip_ConfigIpCarte.Adresse))
				{
					MessageBox.Show("Adresse IP située dans un réseau réservé pour le composant Internet");
					flag = false;
				}
				else
				{
					this.ip.Adresse = new Ip_adresse(ip_ConfigIpCarte.Adresse);
					this.ip.Masque = new Ip_masque(ip_ConfigIpCarte.Masque);
					this.ip.Dhcp = ip_ConfigIpCarte.Dhcp;
					((Station)base.NoeudAttache).Ip.MajRoutes(ip_ConfigIpCarte.OldAdresse, ip_ConfigIpCarte.OldMasque, this.ip.Adresse, this.ip.Masque);
					this.SetContenuInfoBulle();
					((Station)base.NoeudAttache).SetContenuInfoBulle();
					this.reseau.GereDoc.FaireAction(ActionDocument.modifier);
				}
			}
			if (flag)
			{
				ip_ConfigIpCarte.Close();
			}
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0000B89C File Offset: 0x0000A89C
		protected override ContextMenu menuIp()
		{
			Simulation.EtatIp etatIpActif = this.reseau.EtatIpActif;
			ContextMenu result;
			if (etatIpActif == Simulation.EtatIp.attente)
			{
				result = this.cm_ip;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600015F RID: 351 RVA: 0x0000B8C8 File Offset: 0x0000A8C8
		public Ip_carte Ip
		{
			get
			{
				return this.ip;
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0000B8DC File Offset: 0x0000A8DC
		public static CarteReseau TrouverCarte(string adrMac, Simulation reseau)
		{
			foreach (object obj in reseau.Schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Station) || elementReseau.GetType() == typeof(Internet))
				{
					foreach (object obj2 in elementReseau.Controls)
					{
						CarteReseau carteReseau = (CarteReseau)obj2;
						if (carteReseau.adresseMac == adrMac)
						{
							return carteReseau;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000B9D4 File Offset: 0x0000A9D4
		public override bool EstSurStation()
		{
			return true;
		}

		// Token: 0x040000A0 RID: 160
		private IContainer components = null;

		// Token: 0x040000A1 RID: 161
		private MenuItem mi_emettreTrame;

		// Token: 0x040000A2 RID: 162
		private MenuItem mi_configIp;

		// Token: 0x040000A3 RID: 163
		private string adresseMac;

		// Token: 0x040000A4 RID: 164
		private string protocole = "eth";

		// Token: 0x040000A5 RID: 165
		private EmissionTrameDialogue dialogueEmissionTrame = null;

		// Token: 0x040000A6 RID: 166
		private TrameEthernet trame;

		// Token: 0x040000A7 RID: 167
		private DDialogPlusEmissionTrame demoEmission;

		// Token: 0x040000A9 RID: 169
		private int nbTicksRetablirCouleur = 0;

		// Token: 0x040000AA RID: 170
		private bool collisionDurantEmission = false;

		// Token: 0x040000AB RID: 171
		private Ip_carte ip;
	}
}
