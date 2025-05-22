using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200009B RID: 155
	public class Trs_station
	{
		// Token: 0x060009EA RID: 2538 RVA: 0x0005D0AC File Offset: 0x0005C0AC
		public Trs_station(Station s)
		{
			this.st = s;
			this.ip = s.Ip;
			this.portsEcoutes = new SortedList();
			this.natPat = new SortedList();
			this.reqTrsEnvoyees = new SortedList();
			this.reqTrsRecues = new SortedList();
			this.reglesFiltrage = new SortedList();
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x060009EB RID: 2539 RVA: 0x0005D17C File Offset: 0x0005C17C
		// (set) Token: 0x060009EC RID: 2540 RVA: 0x0005D190 File Offset: 0x0005C190
		public Station St
		{
			get
			{
				return this.st;
			}
			set
			{
				this.st = value;
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x060009ED RID: 2541 RVA: 0x0005D1A4 File Offset: 0x0005C1A4
		// (set) Token: 0x060009EE RID: 2542 RVA: 0x0005D1B8 File Offset: 0x0005C1B8
		public Ip_station Ip
		{
			get
			{
				return this.ip;
			}
			set
			{
				this.ip = value;
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x060009EF RID: 2543 RVA: 0x0005D1CC File Offset: 0x0005C1CC
		// (set) Token: 0x060009F0 RID: 2544 RVA: 0x0005D1E0 File Offset: 0x0005C1E0
		public SortedList ReglesFiltrage
		{
			get
			{
				return this.reglesFiltrage;
			}
			set
			{
				this.reglesFiltrage = value;
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x060009F1 RID: 2545 RVA: 0x0005D1F4 File Offset: 0x0005C1F4
		// (set) Token: 0x060009F2 RID: 2546 RVA: 0x0005D208 File Offset: 0x0005C208
		public SortedList PortsEcoutes
		{
			get
			{
				return this.portsEcoutes;
			}
			set
			{
				this.portsEcoutes = value;
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x060009F3 RID: 2547 RVA: 0x0005D21C File Offset: 0x0005C21C
		// (set) Token: 0x060009F4 RID: 2548 RVA: 0x0005D230 File Offset: 0x0005C230
		public SortedList ReqTrsEnvoyees
		{
			get
			{
				return this.reqTrsEnvoyees;
			}
			set
			{
				this.reqTrsEnvoyees = value;
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x060009F5 RID: 2549 RVA: 0x0005D244 File Offset: 0x0005C244
		// (set) Token: 0x060009F6 RID: 2550 RVA: 0x0005D258 File Offset: 0x0005C258
		public SortedList ReqTrsRecues
		{
			get
			{
				return this.reqTrsRecues;
			}
			set
			{
				this.reqTrsRecues = value;
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x060009F7 RID: 2551 RVA: 0x0005D26C File Offset: 0x0005C26C
		// (set) Token: 0x060009F8 RID: 2552 RVA: 0x0005D280 File Offset: 0x0005C280
		public SortedList NatPat
		{
			get
			{
				return this.natPat;
			}
			set
			{
				this.natPat = value;
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x060009F9 RID: 2553 RVA: 0x0005D294 File Offset: 0x0005C294
		// (set) Token: 0x060009FA RID: 2554 RVA: 0x0005D2A8 File Offset: 0x0005C2A8
		public bool NatPatActif
		{
			get
			{
				return this.natPatActif;
			}
			set
			{
				this.natPatActif = value;
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x060009FB RID: 2555 RVA: 0x0005D2BC File Offset: 0x0005C2BC
		// (set) Token: 0x060009FC RID: 2556 RVA: 0x0005D2D0 File Offset: 0x0005C2D0
		public CarteReseau CarteQuiNat
		{
			get
			{
				return this.carteQuiNat;
			}
			set
			{
				this.carteQuiNat = value;
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x060009FD RID: 2557 RVA: 0x0005D2E4 File Offset: 0x0005C2E4
		// (set) Token: 0x060009FE RID: 2558 RVA: 0x0005D2F8 File Offset: 0x0005C2F8
		public int NumCarteQuiNat
		{
			get
			{
				return this.numCarteQuiNat;
			}
			set
			{
				this.numCarteQuiNat = value;
			}
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x0005D30C File Offset: 0x0005C30C
		public void SetCarteQuiNatSelonNum()
		{
			foreach (object obj in this.st.Controls)
			{
				CarteReseau carteReseau = (CarteReseau)obj;
				if (carteReseau.NumeroOrdre == this.numCarteQuiNat)
				{
					this.carteQuiNat = carteReseau;
					break;
				}
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000A00 RID: 2560 RVA: 0x0005D388 File Offset: 0x0005C388
		// (set) Token: 0x06000A01 RID: 2561 RVA: 0x0005D39C File Offset: 0x0005C39C
		public int HauteurPortsEcoutes
		{
			get
			{
				return this.hauteurPortsEcoutes;
			}
			set
			{
				this.hauteurPortsEcoutes = value;
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000A02 RID: 2562 RVA: 0x0005D3B0 File Offset: 0x0005C3B0
		// (set) Token: 0x06000A03 RID: 2563 RVA: 0x0005D3C4 File Offset: 0x0005C3C4
		public int HauteurNatPat
		{
			get
			{
				return this.hauteurNatPat;
			}
			set
			{
				this.hauteurNatPat = value;
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000A04 RID: 2564 RVA: 0x0005D3D8 File Offset: 0x0005C3D8
		// (set) Token: 0x06000A05 RID: 2565 RVA: 0x0005D3EC File Offset: 0x0005C3EC
		public int HauteurReglesFiltrage
		{
			get
			{
				return this.hauteurReglesFiltrage;
			}
			set
			{
				this.hauteurReglesFiltrage = value;
			}
		}

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x06000A06 RID: 2566 RVA: 0x0005D400 File Offset: 0x0005C400
		// (remove) Token: 0x06000A07 RID: 2567 RVA: 0x0005D424 File Offset: 0x0005C424
		public event SegmentTrsEventHandler SegmentTransmis;

		// Token: 0x06000A08 RID: 2568 RVA: 0x0005D448 File Offset: 0x0005C448
		public void InstallerGestionEvenements()
		{
			foreach (object obj in this.st.Reseau.Schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Station) || elementReseau.GetType() == typeof(Internet))
				{
					Trs_station trs = ((Station)elementReseau).Trs;
					trs.SegmentTransmis = (SegmentTrsEventHandler)Delegate.Combine(trs.SegmentTransmis, new SegmentTrsEventHandler(this.Trs_SegmentTransmis));
				}
			}
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x0005D508 File Offset: 0x0005C508
		public void DesinstallerGestionEvenements()
		{
			foreach (object obj in this.st.Reseau.Schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Station) || elementReseau.GetType() == typeof(Internet))
				{
					Trs_station trs = ((Station)elementReseau).Trs;
					trs.SegmentTransmis = (SegmentTrsEventHandler)Delegate.Remove(trs.SegmentTransmis, new SegmentTrsEventHandler(this.Trs_SegmentTransmis));
				}
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000A0A RID: 2570 RVA: 0x0005D5C8 File Offset: 0x0005C5C8
		public Trs_DialogueSaisie DialogueSaisieTrs
		{
			get
			{
				return this.dialogueTrs;
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000A0B RID: 2571 RVA: 0x0005D5DC File Offset: 0x0005C5DC
		public Trs_DialogueReponse DialogueReponseTrs
		{
			get
			{
				return this.dialogueReponse;
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000A0C RID: 2572 RVA: 0x0005D5F0 File Offset: 0x0005C5F0
		public static bool TrsReponse
		{
			get
			{
				return Trs_station.trsReponse;
			}
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x0005D604 File Offset: 0x0005C604
		public void EnvoyerTrs(bool p_reponse)
		{
			Trs_station.trsReponse = p_reponse;
			if (!this.st.Reseau.NoBouclesHubGeneral())
			{
				MessageBox.Show("Impossible, le réseau comporte des boucles !");
				return;
			}
			this.demarrerSimulationTrs();
			if (Trs_station.trsReponse)
			{
				this.dialogueReponse = new Trs_DialogueReponse(new SuiteOk(this.SuiteEnvoyerTrs), new SuiteAnnuler(this.arreterSimulationTrs), this.reqTrsRecues, this.st);
				if (this.st.Reseau.BisIpEnCours)
				{
					this.dialogueReponse.IndexRequete = this.st.Reseau.DerniereSimulationIp.TrsIndexRequete;
					this.dialogueReponse.BloquerSaisie();
				}
				this.dialogueReponse.Location = this.st.posDialogueDemo();
				this.dialogueReponse.InScreen();
				this.dialogueReponse.Show();
				return;
			}
			this.dialogueTrs = new Trs_DialogueSaisie(this, new SuiteOk(this.SuiteEnvoyerTrs), new SuiteAnnuler(this.arreterSimulationTrs), this.st);
			if (this.st.Reseau.BisIpEnCours)
			{
				this.dialogueTrs.AdrIpSaisie = this.st.Reseau.DerniereSimulationIp.AdrIp;
				this.dialogueTrs.Protocole = this.st.Reseau.DerniereSimulationIp.TrsProtocole;
				this.dialogueTrs.NumPort = this.st.Reseau.DerniereSimulationIp.TrsNumport;
				this.dialogueTrs.BloquerSaisie();
			}
			else
			{
				this.dialogueTrs.AdrIpSaisie = this.derniereAdrIpSaisie;
				this.dialogueTrs.Protocole = this.dernierProtocoleSaisi;
				if (this.dernierProtocoleSaisi == "ICMP")
				{
					this.dialogueTrs.NumPort = this.GenPort(ProtocoleTrs.ICMP).ToString();
				}
				else
				{
					this.dialogueTrs.NumPort = this.dernierNumPortSaisi;
				}
			}
			this.dialogueTrs.Location = this.st.posDialogueDemo();
			this.dialogueTrs.InScreen();
			this.dialogueTrs.Show();
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x0005D818 File Offset: 0x0005C818
		private void demarrerSimulationTrs()
		{
			Trs_station.attenteDecolorerCables.Interval = (int)((float)this.st.Reseau.Pref.AttentePing * this.st.Reseau.CoefVitesseDemo);
			Trs_station.attenteDecolorerCables.Start();
			Ip_station.RemplirCachesArp(this.st.Reseau.Schema, "Dyn.");
			this.st.Reseau.SetEnabledMenus(false);
			this.st.Reseau.BloquerReglages();
			this.st.Reseau.EtatIpActif = Simulation.EtatIp.simulationEnCours;
			this.st.Reseau.TimerTraceTrame.Start();
			this.st.Reseau.Bt_stopBisIp.Text = "stop";
			foreach (FormConfig formConfig in this.st.Reseau.OwnedForms)
			{
				formConfig.Close();
			}
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x0005D90C File Offset: 0x0005C90C
		private void initDerniereSimulationIp()
		{
			if (!this.st.Reseau.BisIpEnCours)
			{
				this.st.Reseau.DerniereSimulationIp.InitPortsGeneres();
				if (Trs_station.trsReponse)
				{
					this.st.Reseau.DerniereSimulationIp.DemoIp = TypeSimulationIp.reponseTrs;
				}
				else
				{
					this.st.Reseau.DerniereSimulationIp.DemoIp = TypeSimulationIp.envoiTrs;
				}
				this.st.Reseau.DerniereSimulation.InitTablesSwitch();
				this.st.Reseau.DerniereSimulationIp.InitNatPatEtRequetesTrs();
				this.st.Reseau.DerniereSimulationIp.StationPing = this.st;
			}
			else
			{
				this.st.Reseau.DerniereSimulationIp.InitPosDernierPort();
			}
			this.st.Reseau.Bt_stopBisIp.Enabled = true;
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x0005D9EC File Offset: 0x0005C9EC
		public void SuiteEnvoyerTrs(object p_infos)
		{
			this.initDerniereSimulationIp();
			ArrayList arrayList = (ArrayList)p_infos;
			if (Trs_station.trsReponse)
			{
				this.st.Reseau.DerniereSimulationIp.TrsIndexRequete = (int)arrayList[5];
			}
			else
			{
				this.st.Reseau.DerniereSimulationIp.AdrIp = arrayList[1].ToString();
				this.st.Reseau.DerniereSimulationIp.TrsProtocole = arrayList[0].ToString();
				this.st.Reseau.DerniereSimulationIp.TrsNumport = arrayList[2].ToString();
				this.derniereAdrIpSaisie = arrayList[1].ToString();
				this.dernierProtocoleSaisi = arrayList[0].ToString();
				this.dernierNumPortSaisi = arrayList[2].ToString();
			}
			string value = (string)arrayList[0];
			this.trsProtocole = (ProtocoleTrs)Enum.Parse(typeof(ProtocoleTrs), value, true);
			this.trsAdrIp = (string)arrayList[1];
			try
			{
				this.trsNumPort = int.Parse((string)arrayList[2]);
			}
			catch
			{
				this.trsNumPort = 0;
			}
			string p_adrIpSource = "";
			if (Trs_station.trsReponse)
			{
				this.trsNumPortReponse = int.Parse((string)arrayList[3]);
				p_adrIpSource = arrayList[6].ToString();
				this.numPortGenere = this.trsNumPortReponse;
			}
			else if (this.trsProtocole == ProtocoleTrs.ICMP)
			{
				this.numPortGenere = this.trsNumPort;
			}
			else
			{
				this.numPortGenere = this.GenPort(this.trsProtocole);
			}
			if (this.st.Reseau.TypeDemoIp == Simulation.TypeDeDemo.noDemo || (!this.st.Reseau.DemoRoutageSeul && !this.NatPatFiltrageActif()))
			{
				if (Trs_station.trsReponse)
				{
					ReqTrsEdit.SupprimerReqTrs(ref this.reqTrsRecues, arrayList[4]);
				}
				this.st.Reseau.Bt_pauseRepriseIp.Enabled = true;
				this.st.Reseau.Bt_pauseRepriseIp.ImageIndex = 1;
				this.st.Reseau.Bt_pauseRepriseIp.Tag = "pause";
				this.SuiteEnvoyerTrsNoDemo(this.numPortGenere);
				return;
			}
			if (Trs_station.trsReponse)
			{
				this.argClefReqRecue = arrayList[4];
			}
			this.st.Demo = new DemoEnvoyerSegment(this.st.Reseau);
			this.st.Demo.TitreDialogue = this.st.NomNoeud;
			this.st.Demo.DemoTerminee += this.requete_DemoTerminee;
			this.st.Demo.DemarrerDemo(this.st, p_adrIpSource, this.trsAdrIp, this.trsProtocole, this.trsNumPort, this.numPortGenere, this.st.Reseau.TypeDemoIp);
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000A11 RID: 2577 RVA: 0x0005DCF0 File Offset: 0x0005CCF0
		public int NumPortGenere
		{
			get
			{
				return this.numPortGenere;
			}
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x0005DD04 File Offset: 0x0005CD04
		private void requete_DemoTerminee(object sender, EventArgs e)
		{
			if (this.st.Demo != null)
			{
				this.st.Demo.DemoTerminee -= this.requete_DemoTerminee;
			}
			this.SuiteEnvoyerTrsNoDemo(this.numPortGenere);
			if (Trs_station.trsReponse)
			{
				ReqTrsEdit.SupprimerReqTrs(ref this.reqTrsRecues, this.argClefReqRecue);
			}
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x0005DD60 File Offset: 0x0005CD60
		private void arreterSimulationTrs()
		{
			Trs_station.attenteDecolorerCables.Stop();
			this.st.Reseau.TimerTraceTrame.Stop();
			this.st.Reseau.CacherPaquet(true);
			this.st.Reseau.EtatIpActif = Simulation.EtatIp.attente;
			this.st.Reseau.SetEnabledMenus(true);
			this.st.Reseau.LibererReglages();
			this.st.Reseau.Bt_stopBisIp.Text = "bis";
			this.st.Reseau.BisIpEnCours = false;
			this.st.Reseau.Bt_pauseRepriseIp.ImageIndex = 0;
			this.st.Reseau.Bt_pauseRepriseIp.Enabled = false;
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06000A14 RID: 2580 RVA: 0x0005DE28 File Offset: 0x0005CE28
		// (set) Token: 0x06000A15 RID: 2581 RVA: 0x0005DE3C File Offset: 0x0005CE3C
		public Trs_SegmentTrs SegmentEnCours
		{
			get
			{
				return this.segmentEnCours;
			}
			set
			{
				this.segmentEnCours = value;
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000A16 RID: 2582 RVA: 0x0005DE50 File Offset: 0x0005CE50
		public ProtocoleTrs TrsProtocole
		{
			get
			{
				return this.trsProtocole;
			}
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x0005DE64 File Offset: 0x0005CE64
		public bool RegleApplicable(ArrayList regle, Trs_SegmentTrs segment)
		{
			string valeur = segment.Protocole.ToString();
			string valeur2 = (segment.AdrIpSource == null) ? null : segment.AdrIpSource.ToString();
			string valeur3 = segment.NumPortSource.ToString();
			string valeur4 = (segment.AdrIpDest == null) ? null : segment.AdrIpDest.ToString();
			string valeur5 = segment.NumPortDest.ToString();
			return !ReglesFiltrageEdit.ItemDifferent(regle, segment.MacArrivee, 2) && !ReglesFiltrageEdit.ItemDifferent(regle, segment.MacDepart, 3) && !ReglesFiltrageEdit.ItemDifferent(regle, valeur, 4) && !ReglesFiltrageEdit.ItemDifferent(regle, valeur2, 5) && !ReglesFiltrageEdit.ItemDifferent(regle, valeur3, 6) && !ReglesFiltrageEdit.ItemDifferent(regle, valeur4, 7) && !ReglesFiltrageEdit.ItemDifferent(regle, valeur5, 8);
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x0005DF34 File Offset: 0x0005CF34
		private bool okFiltrage()
		{
			if (this.reglesFiltrage.Count == 0)
			{
				return true;
			}
			bool result = false;
			for (int i = 0; i < this.reglesFiltrage.Count; i++)
			{
				ArrayList arrayList = HashTableEdit.TriGetLignePos(this.reglesFiltrage, i);
				if (this.RegleApplicable(arrayList, this.segmentEnCours))
				{
					result = (arrayList[9].ToString() == "Accepter");
					break;
				}
			}
			return result;
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x0005DFA4 File Offset: 0x0005CFA4
		private void gererSegmentSurStation(Trs_SegmentTrs segment, bool joignable, bool ipCorrecte, ref bool filtrageOk)
		{
			filtrageOk = false;
			this.segmentEnCours = segment;
			if (ipCorrecte)
			{
				Station stationSource = segment.StationSource;
				if (joignable)
				{
					if (this.okFiltrage())
					{
						filtrageOk = true;
						if (Trs_station.trsReponse)
						{
							object objClef = null;
							if (PortsEcoutesEdit.Ecoute(this.reqTrsEnvoyees, segment.Protocole.ToString(), segment.NumPortDest, 1, 3, true, ref objClef))
							{
								this.st.Message.ShowDialog("L'envoi a été accepté", "trs");
								ReqTrsEdit.SupprimerReqTrs(ref this.reqTrsEnvoyees, objClef);
							}
							else
							{
								this.st.Message.ShowDialog("L'envoi a été refusé", "trs");
							}
						}
						else if (PortsEcoutesEdit.Ecoute(this.portsEcoutes, segment.Protocole.ToString(), segment.NumPortDest, 1, 2, false))
						{
							this.st.Message.ShowDialog("L'envoi a été accepté", "trs");
							ReqTrsEdit.AjouterLigne(this.reqTrsRecues, segment.Protocole.ToString(), segment.AdrIpSource, segment.NumPortSource, segment.AdrIpDest, segment.NumPortDest);
						}
						else
						{
							this.st.Message.ShowDialog("L'envoi a été refusé", "trs");
						}
					}
					else
					{
						this.st.Message.ShowDialog("L'envoi a été filtré", "trs");
					}
				}
				else
				{
					this.st.Message.ShowDialog("Hôte non joignable", "trs");
				}
			}
			else
			{
				this.st.Message.ShowDialog("Adresse IP incorrecte", "trs");
			}
			this.st.StyloRelief = this.st.Reseau.StyloEfface;
			this.st.Invalidate();
			this.arreterSimulationTrs();
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x0005E168 File Offset: 0x0005D168
		public void ajouterEnvoiTrs(string protocole, Ip_adresse ipSource, int portSource, Ip_adresse ipDest, int portDest)
		{
			if (!Trs_station.trsReponse)
			{
				ReqTrsEdit.AjouterLigne(this.reqTrsEnvoyees, protocole, ipSource, portSource, ipDest, portDest);
			}
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x0005E190 File Offset: 0x0005D190
		public void SuiteEnvoyerTrsNoDemo(int p_portClient)
		{
			bool flag = false;
			bool flag2 = false;
			string adrIp = this.trsAdrIp;
			if (!Ip_adresse.Ok(adrIp) || Ip_quartet.Isnul(adrIp))
			{
				adrIp = FichierHostsEdit.GetAdrIp(this.ip.FichierHosts, adrIp);
			}
			if (Ip_adresse.Ok(adrIp) && !Ip_quartet.Isnul(adrIp))
			{
				if (adrIp == "127.0.0.1")
				{
					this.gererSegmentSurStation(new Trs_SegmentTrs(this.st, this.trsProtocole, new Ip_adresse(adrIp), p_portClient, new Ip_adresse(adrIp), this.trsNumPort), true, true, ref flag);
					if (flag)
					{
						this.ajouterEnvoiTrs(this.trsProtocole.ToString(), new Ip_adresse(adrIp), p_portClient, new Ip_adresse(adrIp), this.trsNumPort);
						return;
					}
				}
				else
				{
					CarteReseau carteReseau = null;
					string text = null;
					this.ip.TrouverRoute(new Ip_adresse(adrIp), ref carteReseau, ref text);
					if (carteReseau != null && Ip_quartet.ValPoste(new Ip_quartet(adrIp), carteReseau.Ip.Masque) == 0U && Ip_quartet.MemeReseau(new Ip_quartet(adrIp), carteReseau.Ip.Adresse, carteReseau.Ip.Masque))
					{
						this.gererSegmentSurStation(new Trs_SegmentTrs(this.st, this.trsProtocole, null, 0, new Ip_adresse(adrIp), this.trsNumPort), true, false, ref flag);
						return;
					}
					if (carteReseau == null || carteReseau.EtatConnexion != PointConnexion.EtatsConnexion.actif)
					{
						this.gererSegmentSurStation(new Trs_SegmentTrs(this.st, this.trsProtocole, null, 0, new Ip_adresse(adrIp), this.trsNumPort), false, true, ref flag);
						return;
					}
					if (carteReseau.Ip.Adresse.ToString() == adrIp)
					{
						this.gererSegmentSurStation(new Trs_SegmentTrs(this.st, this.trsProtocole, carteReseau.Ip.Adresse, p_portClient, new Ip_adresse(adrIp), this.trsNumPort), true, true, ref flag);
						if (flag)
						{
							this.ajouterEnvoiTrs(this.trsProtocole.ToString(), carteReseau.Ip.Adresse, p_portClient, new Ip_adresse(adrIp), this.trsNumPort);
							return;
						}
					}
					else
					{
						this.ip.PaquetEnCours = new Ip_PaquetIp(this.st, new Ip_adresse(adrIp), TypeDePaquetIp.messageTrs, adrIp);
						if (Trs_station.trsReponse)
						{
							this.segmentEnCours = new Trs_SegmentTrs(this.st, this.trsProtocole, null, this.trsNumPortReponse, new Ip_adresse(adrIp), this.trsNumPort);
						}
						else
						{
							flag2 = true;
							this.segmentEnCours = new Trs_SegmentTrs(this.st, this.trsProtocole, null, p_portClient, new Ip_adresse(adrIp), this.trsNumPort);
						}
						this.SuiteEnvoyerSegmentTrs(ref flag);
						if (flag && flag2)
						{
							this.ajouterEnvoiTrs(this.trsProtocole.ToString(), carteReseau.Ip.Adresse, p_portClient, new Ip_adresse(adrIp), this.trsNumPort);
							return;
						}
					}
				}
			}
			else
			{
				this.gererSegmentSurStation(new Trs_SegmentTrs(this.st, this.trsProtocole, null, 0, null, this.trsNumPort), true, false, ref flag);
			}
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000A1C RID: 2588 RVA: 0x0005E46C File Offset: 0x0005D46C
		// (set) Token: 0x06000A1D RID: 2589 RVA: 0x0005E480 File Offset: 0x0005D480
		public static Random RndPort
		{
			get
			{
				return Trs_station.rndPort;
			}
			set
			{
				Trs_station.rndPort = value;
			}
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x0005E494 File Offset: 0x0005D494
		public int GenPort(ProtocoleTrs p)
		{
			int num;
			if (this.st.Reseau.BisIpEnCours)
			{
				num = this.st.Reseau.DerniereSimulationIp.portGenereSuivant();
			}
			else
			{
				num = Trs_station.rndPort.Next(2000, 10000);
				if (p == ProtocoleTrs.ICMP)
				{
					while (Trs_station.idIcmps.Contains(num))
					{
						num = Trs_station.rndPort.Next(2000, 10000);
					}
				}
				else
				{
					while (this.portsClient.Contains(num))
					{
						num = Trs_station.rndPort.Next(2000, 10000);
					}
				}
				this.st.Reseau.DerniereSimulationIp.AjouterPortGenere(num);
			}
			return num;
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x0005E554 File Offset: 0x0005D554
		public void SuiteEnvoyerSegmentTrs(ref bool filtrageOk)
		{
			filtrageOk = false;
			this.st.StyloRelief = this.st.Reseau.Pref.StyloPaquet;
			this.st.Invalidate();
			bool flag = true;
			CarteReseau carteReseau = null;
			string text = null;
			this.ip.TrouverRoute(this.ip.PaquetEnCours.AdrDest, ref carteReseau, ref text);
			if (carteReseau == null || carteReseau.EtatConnexion != PointConnexion.EtatsConnexion.actif)
			{
				this.gererSegmentSurStation(new Trs_SegmentTrs(this.st, this.trsProtocole, null, 0, this.ip.PaquetEnCours.AdrDest, this.trsNumPort), false, true, ref filtrageOk);
				return;
			}
			this.carteEmission = carteReseau;
			Ip_adresse adrPasserelle = null;
			if (text == null)
			{
				if (carteReseau.Ip.Adresse.ToString() == this.ip.PaquetEnCours.AdrDest.ToString())
				{
					flag = false;
					this.gererSegmentSurStation(new Trs_SegmentTrs(this.st, this.trsProtocole, null, 0, new Ip_adresse(this.ip.PaquetEnCours.AdrDest), this.trsNumPort), true, true, ref filtrageOk);
				}
				else if (this.carteEmission.GetType() == typeof(CarteAccesDistant) || this.carteEmission.GetType() == typeof(PortFai))
				{
					this.adrMacDest = ((CarteReseau)this.carteEmission.Lien.Oppose(this.carteEmission)).AdresseMac;
				}
				else
				{
					this.adrMacDest = CacheArpEdit.GetMac(this.ip.CacheArp, this.ip.PaquetEnCours.AdrDest);
				}
			}
			else if (this.carteEmission.GetType() == typeof(CarteAccesDistant) || this.carteEmission.GetType() == typeof(PortFai))
			{
				this.adrMacDest = ((CarteReseau)this.carteEmission.Lien.Oppose(this.carteEmission)).AdresseMac;
			}
			else
			{
				this.adrMacDest = CacheArpEdit.GetMac(this.ip.CacheArp, new Ip_adresse(text));
			}
			this.ip.PaquetEnCours.AdrPasserelle = adrPasserelle;
			if (flag)
			{
				this.FinEnvoyerSegment(ref filtrageOk);
			}
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x0005E77C File Offset: 0x0005D77C
		public void FinEnvoyerSegment(ref bool filtrageOk)
		{
			filtrageOk = false;
			CarteReseau carteReseau = CarteReseau.TrouverCarte(this.adrMacDest, this.st.Reseau);
			if (carteReseau != null && carteReseau.EtatConnexion == PointConnexion.EtatsConnexion.actif)
			{
				Station stationDest = (Station)carteReseau.NoeudAttache;
				if (this.ip.PaquetEnCours.AdrSource == null)
				{
					this.ip.PaquetEnCours.AdrSource = this.carteEmission.Ip.Adresse;
					this.segmentEnCours.AdrIpSource = this.carteEmission.Ip.Adresse;
				}
				this.ip.PaquetEnCours.CarteDest = carteReseau;
				this.ip.PaquetEnCours.CarteSource = this.carteEmission;
				this.ip.PaquetEnCours.MacDest = carteReseau.AdresseMac;
				this.ip.PaquetEnCours.MacSource = this.carteEmission.AdresseMac;
				this.ip.PaquetEnCours.StationDest = stationDest;
				if (this.ip.PaquetEnCours.CarteDestLocale)
				{
					this.gererSegmentSurStation(this.segmentEnCours, true, true, ref filtrageOk);
					return;
				}
				this.segmentEnCours.MacDepart = this.carteEmission.AdresseMac;
				if (this.okFiltrage())
				{
					filtrageOk = true;
					this.natterSegmentDepart(this.segmentEnCours);
					this.EnvoyerSegmentTrs();
					return;
				}
				this.st.Message.ShowDialog("L'envoi a été filtré", "trs");
				this.st.StyloRelief = this.st.Reseau.StyloEfface;
				this.st.Invalidate();
				this.arreterSimulationTrs();
				return;
			}
			else
			{
				if (carteReseau == null)
				{
					this.afficherMessageEtStopper("Carte de destination non joignable");
					return;
				}
				if (this.st.Reseau.Pref.TrameModeIp)
				{
					this.ip.ColorerRapideEthernet(this.carteEmission);
				}
				Trs_station.attenteDecolorerCables.Tick += this.attenteDecolorerCables_Tick;
				return;
			}
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x0005E964 File Offset: 0x0005D964
		private void attenteDecolorerCables_Tick(object sender, EventArgs e)
		{
			Trs_station.attenteDecolorerCables.Tick -= this.attenteDecolorerCables_Tick;
			if (this.st.Reseau.Pref.TrameModeIp)
			{
				foreach (object obj in this.st.Reseau.Schema.Controls)
				{
					ElementReseau elementReseau = (ElementReseau)obj;
					if (elementReseau.GetType() == typeof(Cable))
					{
						elementReseau.Stylo = this.st.Reseau.Pref.NormalStylo;
					}
				}
				this.st.Reseau.Schema.Invalidate(false);
			}
			this.st.StyloRelief = this.st.Reseau.StyloEfface;
			this.st.Invalidate();
			this.arreterSimulationTrs();
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x0005EA70 File Offset: 0x0005DA70
		public void EnvoyerSegmentTrs()
		{
			if (this.st.Reseau.Pref.TrameModeIp)
			{
				this.ip.ColorerRapideEthernet(this.ip.PaquetEnCours.CarteSource);
			}
			Ip_station.CablesTraverses = new ArrayList();
			this.ip.PaquetEnCours.CarteSource.Lien.TransmissionRapideEthernet(false, this.ip.PaquetEnCours.CarteSource, this.ip.PaquetEnCours, false, null, null);
			string p_donnees;
			if (this.segmentEnCours.Protocole == ProtocoleTrs.ICMP)
			{
				p_donnees = string.Concat(new object[]
				{
					"ICMP : ",
					this.ip.PaquetEnCours.AdrSource.ToString(),
					" --> ",
					this.ip.PaquetEnCours.AdrDest.ToString(),
					" (Id Icmp ",
					this.segmentEnCours.NumPortSource,
					")"
				});
			}
			else
			{
				p_donnees = string.Concat(new object[]
				{
					this.segmentEnCours.Protocole.ToString(),
					" : (",
					this.ip.PaquetEnCours.AdrSource.ToString(),
					" , ",
					this.segmentEnCours.NumPortSource,
					") --> (",
					this.ip.PaquetEnCours.AdrDest.ToString(),
					" , ",
					this.segmentEnCours.NumPortDest,
					")"
				});
			}
			this.st.Reseau.AfficherPaquet(this.ip.PaquetEnCours, "ip", p_donnees);
			Ip_CableVirtuel ip_CableVirtuel = new Ip_CableVirtuel(this.ip.PaquetEnCours);
			if (this.st.Reseau.CablesVirtuelIp)
			{
				ip_CableVirtuel.Tracer(new SuiteTracerCableVirtuelIp(this.FinTracerSegment));
				return;
			}
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			this.ip.PaquetEnCours.CarteSource.Lien.Oppose(this.ip.PaquetEnCours.CarteSource).CalculerCheminIp(this.ip.PaquetEnCours.CarteDest, ref arrayList, ref arrayList2);
			arrayList.Add(this.ip.PaquetEnCours.CarteSource.Lien.Oppose(this.ip.PaquetEnCours.CarteSource));
			arrayList.Add(this.ip.PaquetEnCours.CarteSource);
			Pen p_premierStylo;
			if (this.st.Reseau.Pref.TrameModeIp)
			{
				if (this.ip.PaquetEnCours.CarteSource.GetType() == typeof(CarteAccesDistant) || this.ip.PaquetEnCours.CarteSource.GetType() == typeof(PortFai))
				{
					p_premierStylo = new Pen(this.st.Reseau.Pref.CableActifStylo2.Brush, 1f);
				}
				else
				{
					p_premierStylo = new Pen(this.st.Reseau.Pref.CableActifStylo1.Brush, 1f);
				}
			}
			else
			{
				p_premierStylo = this.st.Reseau.Pref.StyloCable;
			}
			ip_CableVirtuel.Tracer(new SuiteTracerCableVirtuelIp(this.FinTracerSegment), arrayList, p_premierStylo);
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x0005EDF8 File Offset: 0x0005DDF8
		public void FinTracerSegment(object obj)
		{
			if (this.st.Reseau.Pref.TrameModeIp)
			{
				foreach (object obj2 in this.st.Reseau.Schema.Controls)
				{
					ElementReseau elementReseau = (ElementReseau)obj2;
					if (elementReseau.GetType() == typeof(Cable))
					{
						elementReseau.Stylo = this.st.Reseau.Pref.NormalStylo;
					}
				}
			}
			this.st.Reseau.Schema.Invalidate(false);
			this.st.StyloRelief = this.st.Reseau.StyloEfface;
			this.st.Invalidate();
			if (this.SegmentTransmis != null && !this.ip.PaquetEnCours.CarteDestLocale)
			{
				this.SegmentTransmis(this, new SegmentTrsEventArgs(this.segmentEnCours, this.ip.PaquetEnCours, this.ip.PaquetEnCours.StationDest.Trs));
			}
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x0005EF38 File Offset: 0x0005DF38
		private void Trs_SegmentTransmis(Trs_station sender, SegmentTrsEventArgs e)
		{
			if (e.Cible == this)
			{
				this.numPortGenere = this.GenPort(e.Segment.Protocole);
				if (this.st.Reseau.TypeDemoIp != Simulation.TypeDeDemo.noDemo)
				{
					if (this.st.GetType() == typeof(Internet))
					{
						if (this.st.Reseau.Pref.DemosInternet && this.st.Reseau.DemoRoutageSeul && this.st.Reseau.TypeDemoIp != Simulation.TypeDeDemo.manuel)
						{
							this.ip.PaquetEnCours = e.Paquet;
							e.Segment.MacArrivee = e.Paquet.MacDest;
							this.argSegment = e.Segment;
							this.st.Demo = new DemoPaquetIp(this.st.Reseau);
							this.st.Demo.TitreDialogue = this.st.NomNoeud;
							this.st.Demo.DemoTerminee += this.Demo_DemoSegmentTransmisInternetTerminee;
							this.st.Demo.DemarrerDemo(this.st, e.Paquet, this.st.Reseau.TypeDemoIp);
							return;
						}
						this.ip.PaquetEnCours = e.Paquet;
						e.Segment.MacArrivee = e.Paquet.MacDest;
						this.natterSegmentArrivee(e.Segment);
						this.finSegmentTrsTransmis(e.Segment);
						return;
					}
					else
					{
						if (this.st.Reseau.DemoRoutageSeul || this.NatPatFiltrageActif())
						{
							this.ip.PaquetEnCours = e.Paquet;
							e.Segment.MacArrivee = e.Paquet.MacDest;
							this.argSegment = e.Segment;
							this.st.Demo = new DemoSegmentTransmis(this.st.Reseau);
							this.st.Demo.TitreDialogue = this.st.NomNoeud;
							this.st.Demo.DemoTerminee += this.Demo_DemoSegmentTransmisTerminee;
							this.st.Demo.DemarrerDemo(this.st, e.Segment, e.Paquet, this.st.Reseau.TypeDemoIp);
							return;
						}
						this.ip.PaquetEnCours = e.Paquet;
						e.Segment.MacArrivee = e.Paquet.MacDest;
						this.natterSegmentArrivee(e.Segment);
						this.finSegmentTrsTransmis(e.Segment);
						return;
					}
				}
				else
				{
					this.ip.PaquetEnCours = e.Paquet;
					e.Segment.MacArrivee = e.Paquet.MacDest;
					this.natterSegmentArrivee(e.Segment);
					this.finSegmentTrsTransmis(e.Segment);
				}
			}
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x0005F224 File Offset: 0x0005E224
		private void Demo_DemoSegmentTransmisInternetTerminee(object sender, EventArgs e)
		{
			this.st.Demo.DemoTerminee -= this.Demo_DemoSegmentTransmisInternetTerminee;
			this.finSegmentTrsTransmis(this.argSegment);
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x0005F25C File Offset: 0x0005E25C
		private void Demo_DemoSegmentTransmisTerminee(object sender, EventArgs e)
		{
			this.st.Demo.DemoTerminee -= this.Demo_DemoSegmentTransmisTerminee;
			this.natterSegmentArrivee(this.argSegment);
			this.finSegmentTrsTransmis(this.argSegment);
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x0005F2A0 File Offset: 0x0005E2A0
		private void afficherMessageEtStopper(string message)
		{
			this.st.Message.ShowDialog(message, "trs");
			this.st.StyloRelief = this.st.Reseau.StyloEfface;
			this.st.Invalidate();
			this.arreterSimulationTrs();
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x0005F2F0 File Offset: 0x0005E2F0
		private void natterSegmentArrivee(Trs_SegmentTrs segment)
		{
			if (this.natPatActif && this.ip.PaquetEnCours.MacDest == this.carteQuiNat.AdresseMac && NatPatEdit.PublicContient(this.natPat, segment.Protocole.ToString(), segment.AdrIpDest, segment.NumPortDest))
			{
				Ip_adresse adrIpDest = segment.AdrIpDest;
				int numPortDest = segment.NumPortDest;
				segment.AdrIpDest = NatPatEdit.IpPrivee(this.natPat, segment.Protocole.ToString(), segment.AdrIpDest, segment.NumPortDest);
				this.ip.PaquetEnCours.AdrDest = segment.AdrIpDest;
				segment.NumPortDest = NatPatEdit.PortPrive(this.natPat, segment.Protocole.ToString(), adrIpDest, numPortDest);
				if (segment.Protocole == ProtocoleTrs.ICMP)
				{
					segment.NumPortSource = segment.NumPortDest;
				}
				NatPatEdit.SupprimerLignePubliqueSiNat(this.natPat, segment.Protocole.ToString(), adrIpDest, numPortDest);
			}
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x0005F400 File Offset: 0x0005E400
		public void NatterSegmentArrivee(Trs_SegmentTrs segment, ref object ClefNatPat, ref int index, ref string typeNat)
		{
			index = -1;
			typeNat = "";
			ClefNatPat = null;
			if (this.natPatActif && segment.MacArrivee == this.carteQuiNat.AdresseMac && NatPatEdit.PublicContient(this.natPat, segment.Protocole.ToString(), segment.AdrIpDest, segment.NumPortDest))
			{
				Ip_adresse adrIpDest = segment.AdrIpDest;
				int numPortDest = segment.NumPortDest;
				segment.AdrIpDest = NatPatEdit.IpPrivee(this.natPat, segment.Protocole.ToString(), segment.AdrIpDest, segment.NumPortDest);
				segment.NumPortDest = NatPatEdit.PortPrive(this.natPat, segment.Protocole.ToString(), adrIpDest, numPortDest);
				if (segment.Protocole == ProtocoleTrs.ICMP)
				{
					segment.NumPortSource = segment.NumPortDest;
				}
				index = NatPatEdit.IndexLignePublique(this.natPat, segment.Protocole.ToString(), adrIpDest, numPortDest, ref ClefNatPat, ref typeNat);
			}
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x0005F504 File Offset: 0x0005E504
		private void natterSegmentDepart(Trs_SegmentTrs segment)
		{
			if (this.natPatActif && this.ip.PaquetEnCours.MacSource == this.carteQuiNat.AdresseMac && segment.AdrIpSource != this.carteQuiNat.Ip.Adresse)
			{
				if (!NatPatEdit.PriveContient(this.natPat, segment.Protocole.ToString(), segment.AdrIpSource, segment.NumPortSource))
				{
					int portPublic = this.numPortGenere;
					NatPatEdit.InsererLigneNat(this.natPat, segment.Protocole.ToString(), this.CarteQuiNat.Ip.Adresse, portPublic, segment.AdrIpSource, segment.NumPortSource);
				}
				Ip_adresse adrIpSource = segment.AdrIpSource;
				int numPortSource = segment.NumPortSource;
				segment.AdrIpSource = NatPatEdit.IpPublique(this.natPat, segment.Protocole.ToString(), adrIpSource, numPortSource);
				this.ip.PaquetEnCours.AdrSource = segment.AdrIpSource;
				segment.NumPortSource = NatPatEdit.PortPublic(this.natPat, segment.Protocole.ToString(), adrIpSource, numPortSource);
				if (segment.Protocole == ProtocoleTrs.ICMP)
				{
					segment.NumPortDest = segment.NumPortSource;
				}
			}
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x0005F644 File Offset: 0x0005E644
		public void NatterSegmentDepart(Trs_SegmentTrs segment, ref int index, int portGenere)
		{
			SortedList table = HashTableEdit.CopieProfonde(this.natPat);
			index = -1;
			if (this.natPatActif && segment.MacDepart == this.carteQuiNat.AdresseMac && segment.AdrIpSource != this.carteQuiNat.Ip.Adresse)
			{
				index = NatPatEdit.IndexLignePrive(table, segment.Protocole.ToString(), segment.AdrIpSource, segment.NumPortSource);
				if (index == -1)
				{
					NatPatEdit.InsererLigneNat(table, segment.Protocole.ToString(), this.CarteQuiNat.Ip.Adresse, portGenere, segment.AdrIpSource, segment.NumPortSource);
				}
				Ip_adresse adrIpSource = segment.AdrIpSource;
				int numPortSource = segment.NumPortSource;
				segment.AdrIpSource = NatPatEdit.IpPublique(table, segment.Protocole.ToString(), adrIpSource, numPortSource);
				segment.NumPortSource = NatPatEdit.PortPublic(table, segment.Protocole.ToString(), adrIpSource, numPortSource);
				if (segment.Protocole == ProtocoleTrs.ICMP)
				{
					segment.NumPortDest = segment.NumPortSource;
				}
			}
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x0005F75C File Offset: 0x0005E75C
		private void finSegmentTrsTransmis(Trs_SegmentTrs segment)
		{
			bool flag = false;
			CarteReseau carteReseau = this.ip.TrouverCarteIp(this.ip.PaquetEnCours.AdrDest.ToString());
			if (carteReseau != null)
			{
				if (carteReseau.EtatConnexion != PointConnexion.EtatsConnexion.actif)
				{
					this.afficherMessageEtStopper("Carte de destination inactive");
					return;
				}
				if (Ip_quartet.MemeReseau(this.ip.PaquetEnCours.AdrDest, this.ip.PaquetEnCours.CarteDest.Ip.Adresse, carteReseau.Ip.Masque))
				{
					this.gererSegmentSurStation(segment, true, true, ref flag);
					return;
				}
				if (this.ip.RoutageActif)
				{
					this.gererSegmentSurStation(segment, true, true, ref flag);
					return;
				}
				this.gererSegmentSurStation(segment, true, true, ref flag);
				return;
			}
			else
			{
				if (segment.NbSauts > 0 && this.ip.RoutageActif)
				{
					this.routerSegment(segment);
					return;
				}
				this.segmentEnCours = segment;
				if (!this.ip.RoutageActif)
				{
					this.afficherMessageEtStopper("Routage inactif");
					return;
				}
				this.afficherMessageEtStopper("TTL du paquet épuisé");
				return;
			}
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x0005F860 File Offset: 0x0005E860
		private void routerSegment(Trs_SegmentTrs segment)
		{
			bool flag = false;
			Ip_adresse adrSource = this.ip.PaquetEnCours.AdrSource;
			this.segmentEnCours = segment;
			this.ip.PaquetEnCours = new Ip_PaquetIp(this.st, segment.AdrIpDest, this.ip.PaquetEnCours.Type, this.ip.PaquetEnCours.Donnees);
			this.segmentEnCours.NbSauts = this.segmentEnCours.NbSauts - 1;
			this.ip.PaquetEnCours.NbSauts = this.segmentEnCours.NbSauts;
			this.ip.PaquetEnCours.AdrSource = adrSource;
			this.finEnvoiSegment = (EventHandler)Delegate.Combine(this.finEnvoiSegment, new EventHandler(this.Trs_station_finEnvoiSegment));
			this.SuiteEnvoyerSegmentTrs(ref flag);
		}

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x06000A2E RID: 2606 RVA: 0x0005F934 File Offset: 0x0005E934
		// (remove) Token: 0x06000A2F RID: 2607 RVA: 0x0005F958 File Offset: 0x0005E958
		private event EventHandler finEnvoiSegment;

		// Token: 0x06000A30 RID: 2608 RVA: 0x0005F97C File Offset: 0x0005E97C
		private void Trs_station_finEnvoiSegment(object sender, EventArgs e)
		{
			this.finEnvoiSegment = (EventHandler)Delegate.Combine(this.finEnvoiSegment, new EventHandler(this.Trs_station_finEnvoiSegment));
			this.st.StyloRelief = this.st.Reseau.StyloEfface;
			this.st.Invalidate();
			this.arreterSimulationTrs();
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x0005F9D8 File Offset: 0x0005E9D8
		public static void SupprimerEchangesEnCours(Control reseau)
		{
			foreach (object obj in reseau.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Station))
				{
					((Station)elementReseau).Trs.ViderInfosTrs();
				}
			}
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x0005FA58 File Offset: 0x0005EA58
		public void ViderInfosTrs()
		{
			NatPatEdit.SupprimerNatPats(this.natPat);
			this.reqTrsEnvoyees = new SortedList();
			this.reqTrsRecues = new SortedList();
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x0005FA88 File Offset: 0x0005EA88
		public bool NatPatFiltrageActif()
		{
			return this.natPatActif || this.reglesFiltrage.Count != 0;
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x0005FAB0 File Offset: 0x0005EAB0
		public int ItemFiltrage(Trs_SegmentTrs segment, ref bool accepter)
		{
			accepter = false;
			if (this.st.Trs.ReglesFiltrage.Count == 0)
			{
				accepter = true;
				return -1;
			}
			int i;
			for (i = 0; i < this.st.Trs.ReglesFiltrage.Count; i++)
			{
				ArrayList arrayList = HashTableEdit.TriGetLignePos(this.reglesFiltrage, i);
				if (this.RegleApplicable(arrayList, segment))
				{
					accepter = (arrayList[9].ToString() == "Accepter");
					break;
				}
			}
			return i;
		}

		// Token: 0x04000665 RID: 1637
		private Station st;

		// Token: 0x04000666 RID: 1638
		private Ip_station ip;

		// Token: 0x04000667 RID: 1639
		private SortedList reglesFiltrage;

		// Token: 0x04000668 RID: 1640
		private SortedList portsEcoutes;

		// Token: 0x04000669 RID: 1641
		private SortedList reqTrsEnvoyees;

		// Token: 0x0400066A RID: 1642
		private SortedList reqTrsRecues;

		// Token: 0x0400066B RID: 1643
		private SortedList natPat;

		// Token: 0x0400066C RID: 1644
		private bool natPatActif = false;

		// Token: 0x0400066D RID: 1645
		private CarteReseau carteQuiNat = null;

		// Token: 0x0400066E RID: 1646
		private int numCarteQuiNat;

		// Token: 0x0400066F RID: 1647
		private int hauteurPortsEcoutes = DialogueHashTable.Hauteur;

		// Token: 0x04000670 RID: 1648
		private int hauteurNatPat = DialogueHashTable.Hauteur;

		// Token: 0x04000671 RID: 1649
		private int hauteurReglesFiltrage = DialogueHashTable.Hauteur;

		// Token: 0x04000673 RID: 1651
		private Trs_DialogueSaisie dialogueTrs;

		// Token: 0x04000674 RID: 1652
		private Trs_DialogueReponse dialogueReponse;

		// Token: 0x04000675 RID: 1653
		private static bool trsReponse;

		// Token: 0x04000676 RID: 1654
		private string derniereAdrIpSaisie = "";

		// Token: 0x04000677 RID: 1655
		private string dernierProtocoleSaisi = "TCP";

		// Token: 0x04000678 RID: 1656
		private string dernierNumPortSaisi = "";

		// Token: 0x04000679 RID: 1657
		private int numPortGenere = 0;

		// Token: 0x0400067A RID: 1658
		private object argClefReqRecue = null;

		// Token: 0x0400067B RID: 1659
		private Trs_SegmentTrs segmentEnCours;

		// Token: 0x0400067C RID: 1660
		private ProtocoleTrs trsProtocole;

		// Token: 0x0400067D RID: 1661
		private string trsAdrIp;

		// Token: 0x0400067E RID: 1662
		private int trsNumPort;

		// Token: 0x0400067F RID: 1663
		private int trsNumPortReponse;

		// Token: 0x04000680 RID: 1664
		private static Random rndPort;

		// Token: 0x04000681 RID: 1665
		private static ArrayList idIcmps = new ArrayList();

		// Token: 0x04000682 RID: 1666
		private ArrayList portsClient = new ArrayList();

		// Token: 0x04000683 RID: 1667
		private CarteReseau carteEmission;

		// Token: 0x04000684 RID: 1668
		private string adrMacDest = null;

		// Token: 0x04000685 RID: 1669
		private static Timer attenteDecolorerCables = new Timer();

		// Token: 0x04000686 RID: 1670
		private Trs_SegmentTrs argSegment;
	}
}
