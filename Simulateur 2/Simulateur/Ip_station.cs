using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Simulateur
{
	// Token: 0x02000061 RID: 97
	public class Ip_station
	{
		// Token: 0x06000543 RID: 1347 RVA: 0x000357BC File Offset: 0x000347BC
		public Ip_station(Station s)
		{
			this.st = s;
			this.passerelle = new Ip_adresse("0.0.0.0");
			this.serveurDns = new Ip_adresse("0.0.0.0");
			this.routes = new SortedList();
			this.cacheArp = new SortedList();
			this.fichierHosts = new SortedList();
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000544 RID: 1348 RVA: 0x0003585C File Offset: 0x0003485C
		// (set) Token: 0x06000545 RID: 1349 RVA: 0x00035870 File Offset: 0x00034870
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

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000546 RID: 1350 RVA: 0x00035884 File Offset: 0x00034884
		// (set) Token: 0x06000547 RID: 1351 RVA: 0x00035898 File Offset: 0x00034898
		public SortedList Routes
		{
			get
			{
				return this.routes;
			}
			set
			{
				this.routes = value;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000548 RID: 1352 RVA: 0x000358AC File Offset: 0x000348AC
		// (set) Token: 0x06000549 RID: 1353 RVA: 0x000358C0 File Offset: 0x000348C0
		public SortedList CacheArp
		{
			get
			{
				return this.cacheArp;
			}
			set
			{
				this.cacheArp = value;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600054A RID: 1354 RVA: 0x000358D4 File Offset: 0x000348D4
		// (set) Token: 0x0600054B RID: 1355 RVA: 0x000358E8 File Offset: 0x000348E8
		public SortedList FichierHosts
		{
			get
			{
				return this.fichierHosts;
			}
			set
			{
				this.fichierHosts = value;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600054C RID: 1356 RVA: 0x000358FC File Offset: 0x000348FC
		// (set) Token: 0x0600054D RID: 1357 RVA: 0x00035914 File Offset: 0x00034914
		public string NomHote
		{
			get
			{
				return this.st.NomNoeud;
			}
			set
			{
				this.st.NomNoeud = value;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x0600054E RID: 1358 RVA: 0x00035930 File Offset: 0x00034930
		// (set) Token: 0x0600054F RID: 1359 RVA: 0x00035944 File Offset: 0x00034944
		public Ip_adresse Passerelle
		{
			get
			{
				return this.passerelle;
			}
			set
			{
				this.passerelle = value;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000550 RID: 1360 RVA: 0x00035958 File Offset: 0x00034958
		// (set) Token: 0x06000551 RID: 1361 RVA: 0x0003596C File Offset: 0x0003496C
		public bool RoutageActif
		{
			get
			{
				return this.routageActif;
			}
			set
			{
				this.routageActif = value;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000552 RID: 1362 RVA: 0x00035980 File Offset: 0x00034980
		// (set) Token: 0x06000553 RID: 1363 RVA: 0x00035994 File Offset: 0x00034994
		public Ip_adresse ServeurDns
		{
			get
			{
				return this.serveurDns;
			}
			set
			{
				this.serveurDns = value;
			}
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x000359A8 File Offset: 0x000349A8
		public CarteReseau TrouverCarteMemeReseau(Ip_quartet adresse)
		{
			foreach (object obj in this.st.Controls)
			{
				CarteReseau carteReseau = (CarteReseau)obj;
				if (Ip_quartet.MemeReseau(carteReseau.Ip.Adresse, adresse, carteReseau.Ip.Masque))
				{
					return carteReseau;
				}
			}
			return null;
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x00035A30 File Offset: 0x00034A30
		public CarteReseau TrouverCarteMemeReseau(Ip_quartet adresse, CarteReseau carteExclue)
		{
			foreach (object obj in this.st.Controls)
			{
				CarteReseau carteReseau = (CarteReseau)obj;
				if (carteReseau != carteExclue && Ip_quartet.MemeReseau(carteReseau.Ip.Adresse, adresse, carteReseau.Ip.Masque))
				{
					return carteReseau;
				}
			}
			return null;
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x00035ABC File Offset: 0x00034ABC
		private void affecterPasserelle(Ip_adresse p_passerelle, CarteReseau carteExclue)
		{
			CarteReseau carteReseau = this.TrouverCarteMemeReseau(p_passerelle);
			if (carteReseau != null && !carteReseau.Ip.Adresse.Isnul() && carteReseau != carteExclue)
			{
				this.majRoutes(p_passerelle, carteReseau.Ip.Adresse);
				return;
			}
			this.passerelle = new Ip_adresse("0.0.0.0");
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x00035B10 File Offset: 0x00034B10
		public void MajRoutes(Ip_adresse passerelle)
		{
			HashTableEdit.TriRemoveLigne(ref this.routes, "0.0.0.0");
			this.affecterPasserelle(passerelle, null);
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x00035B38 File Offset: 0x00034B38
		public void supprimerRoute(string adr)
		{
			HashTableEdit.TriRemoveLigne(ref this.routes, adr);
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x00035B54 File Offset: 0x00034B54
		private void majRoutes(Ip_adresse passerelle, Ip_adresse carte)
		{
			if (!passerelle.Isnul())
			{
				HashTableEdit.TriAddLigne(ref this.routes, (ArrayList)new ArrayList
				{
					HashTableEdit.DeuxChiffres(this.routes.Count + 1),
					"0.0.0.0",
					"0.0.0.0",
					passerelle.ToString(),
					carte.ToString(),
					"1"
				}.Clone());
			}
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x00035BDC File Offset: 0x00034BDC
		public void MajRoutesCarteSupprimee(CarteReseau c)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.routes.Values)
			{
				ArrayList arrayList2 = (ArrayList)obj;
				if (RouteEdit.GetInterface(arrayList2).Trim() == c.Ip.Adresse.ToString())
				{
					arrayList.Add(arrayList2[1]);
				}
			}
			foreach (object obj2 in arrayList)
			{
				string clef = (string)obj2;
				HashTableEdit.TriRemoveLigne(ref this.routes, clef);
			}
			CarteReseau carteReseau = this.TrouverCarteMemeReseau(c.Ip.Adresse, c);
			if (carteReseau != null && !carteReseau.Ip.Adresse.Isnul())
			{
				HashTableEdit.TriAddLigne(ref this.routes, (ArrayList)new ArrayList
				{
					"02",
					carteReseau.Ip.Adresse.AdresseReseau(carteReseau.Ip.Masque),
					carteReseau.Ip.Masque.ToString(),
					carteReseau.Ip.Adresse.ToString(),
					carteReseau.Ip.Adresse.ToString(),
					"1"
				}.Clone());
				HashTableEdit.TriAddLigne(ref this.routes, (ArrayList)new ArrayList
				{
					"03",
					carteReseau.Ip.Adresse.AdresseBroadcast(carteReseau.Ip.Masque),
					"255.255.255.255",
					carteReseau.Ip.Adresse.ToString(),
					carteReseau.Ip.Adresse.ToString(),
					"1"
				}.Clone());
			}
			if (!this.passerelle.Isnul() && RouteEdit.GetRoutePasserelle(this.routes) == null)
			{
				this.affecterPasserelle(this.passerelle, c);
			}
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x00035E6C File Offset: 0x00034E6C
		public void MajRoutes(Ip_adresse oldAdresse, Ip_masque oldMasque, Ip_adresse newAdresse, Ip_masque masque)
		{
			if (oldAdresse.ToString() != newAdresse.ToString())
			{
				ArrayList routePasserelle = RouteEdit.GetRoutePasserelle(this.routes);
				if (routePasserelle != null)
				{
					if (RouteEdit.GetInterface(routePasserelle) == oldAdresse.ToString())
					{
						if (!newAdresse.Isnul() && Ip_quartet.MemeReseau(newAdresse, this.passerelle, masque))
						{
							routePasserelle[4] = newAdresse.ToString();
						}
						else
						{
							HashTableEdit.TriRemoveLigne(ref this.routes, routePasserelle[1].ToString());
							this.affecterPasserelle(this.passerelle, null);
						}
					}
				}
				else if (!this.passerelle.Isnul())
				{
					if (!newAdresse.Isnul() && Ip_quartet.MemeReseau(this.passerelle, newAdresse, masque))
					{
						this.majRoutes(this.passerelle, newAdresse);
					}
					else
					{
						this.affecterPasserelle(this.passerelle, null);
					}
				}
				if (!oldAdresse.Isnul())
				{
					HashTableEdit.TriRemoveLigne(ref this.routes, oldAdresse.ToString());
					CarteReseau carteReseau = this.TrouverCarteMemeReseau(oldAdresse);
					if (carteReseau == null || carteReseau.Ip.Adresse.Isnul())
					{
						HashTableEdit.TriRemoveLigne(ref this.routes, oldAdresse.AdresseReseau(oldMasque));
						HashTableEdit.TriRemoveLigne(ref this.routes, oldAdresse.AdresseBroadcast(oldMasque));
					}
					else
					{
						ArrayList arrayList = HashTableEdit.TriGetLigneClef(this.routes, oldAdresse.AdresseReseau(oldMasque));
						if (arrayList != null && RouteEdit.GetInterface(arrayList).Trim() == oldAdresse.ToString())
						{
							arrayList[4] = carteReseau.Ip.Adresse.ToString();
							arrayList[3] = carteReseau.Ip.Adresse.ToString();
						}
						arrayList = HashTableEdit.TriGetLigneClef(this.routes, oldAdresse.AdresseBroadcast(oldMasque));
						if (arrayList != null && RouteEdit.GetInterface(arrayList).Trim() == oldAdresse.ToString())
						{
							arrayList[4] = carteReseau.Ip.Adresse.ToString();
							arrayList[3] = carteReseau.Ip.Adresse.ToString();
						}
					}
					ArrayList arrayList2 = new ArrayList();
					foreach (object obj in this.routes.Values)
					{
						ArrayList arrayList3 = (ArrayList)obj;
						if (RouteEdit.GetInterface(arrayList3).Trim() == oldAdresse.ToString())
						{
							arrayList2.Add(arrayList3[1]);
						}
					}
					foreach (object obj2 in arrayList2)
					{
						string clef = (string)obj2;
						HashTableEdit.TriRemoveLigne(ref this.routes, clef);
					}
				}
				if (!newAdresse.Isnul())
				{
					HashTableEdit.TriAddLigne(ref this.routes, (ArrayList)new ArrayList
					{
						"01",
						newAdresse.ToString(),
						"255.255.255.255",
						newAdresse.ToString(),
						newAdresse.ToString(),
						"1"
					}.Clone());
					HashTableEdit.TriAddLigne(ref this.routes, (ArrayList)new ArrayList
					{
						"02",
						newAdresse.AdresseReseau(masque),
						masque.ToString(),
						newAdresse.ToString(),
						newAdresse.ToString(),
						"1"
					}.Clone());
					HashTableEdit.TriAddLigne(ref this.routes, (ArrayList)new ArrayList
					{
						"03",
						newAdresse.AdresseBroadcast(masque),
						"255.255.255.255",
						newAdresse.ToString(),
						newAdresse.ToString(),
						"1"
					}.Clone());
				}
			}
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x000362A4 File Offset: 0x000352A4
		public void StockerXml(XmlTextWriter writer)
		{
			writer.WriteStartElement("ConfigIpStation");
			writer.WriteElementString("passerelle", this.passerelle.ToString());
			writer.WriteElementString("routageActif", this.routageActif.ToString());
			writer.WriteElementString("natPatActif", this.st.Trs.NatPatActif.ToString());
			if (this.st.Trs.NatPatActif)
			{
				writer.WriteElementString("carteQuiNat", this.st.Trs.CarteQuiNat.NumeroOrdre.ToString());
			}
			else
			{
				writer.WriteElementString("carteQuiNat", "-1");
			}
			writer.WriteElementString("serveurDns", this.serveurDns.ToString());
			HashTableEdit.StockerTableXml(this.routes, writer, "Routes");
			SortedList sortedList = (SortedList)this.cacheArp.Clone();
			CacheArpEdit.SupprimerDynamiques(sortedList);
			HashTableEdit.StockerTableXml(sortedList, writer, "CacheARP");
			HashTableEdit.StockerTableXml(this.fichierHosts, writer, "FichierHosts");
			HashTableEdit.StockerTableXml(this.st.Trs.PortsEcoutes, writer, "PortsEcoutes");
			SortedList sortedList2 = (SortedList)this.st.Trs.NatPat.Clone();
			NatPatEdit.SupprimerNatPats(sortedList2);
			HashTableEdit.StockerTableXml(sortedList2, writer, "NatPat");
			SortedList t = HashTableEdit.SortedListToXml(this.st.Trs.ReglesFiltrage);
			HashTableEdit.StockerTableXml(t, writer, "ReglesFiltrage");
			writer.WriteEndElement();
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x00036424 File Offset: 0x00035424
		public void ChargerXml(XmlTextReader reader)
		{
			Simulation.elementXmlSuivant(reader, true);
			Simulation.elementXmlSuivant(reader, true);
			this.passerelle = new Ip_adresse(reader.Value);
			Simulation.elementXmlSuivant(reader, true);
			this.routageActif = bool.Parse(reader.Value);
			Simulation.elementXmlSuivant(reader, true);
			this.st.Trs.NatPatActif = bool.Parse(reader.Value);
			Simulation.elementXmlSuivant(reader, true);
			this.st.Trs.NumCarteQuiNat = int.Parse(reader.Value);
			Simulation.elementXmlSuivant(reader, true);
			this.serveurDns = new Ip_adresse(reader.Value);
			HashTableEdit.ChargerTableXml(this.routes, reader);
			HashTableEdit.ChargerTableXml(this.cacheArp, reader);
			HashTableEdit.ChargerTableXml(this.fichierHosts, reader);
			HashTableEdit.ChargerTableXml(this.st.Trs.PortsEcoutes, reader);
			HashTableEdit.ChargerTableXml(this.st.Trs.NatPat, reader);
			SortedList sortedList = new SortedList();
			HashTableEdit.ChargerTableXml(sortedList, reader);
			this.st.Trs.ReglesFiltrage = HashTableEdit.XmlToSortedList(sortedList, new ClefTable(ReglesFiltrageEdit.CalculerClef));
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x00036544 File Offset: 0x00035544
		public void eteindre()
		{
			CacheArpEdit.SupprimerDynamiques(this.cacheArp);
			this.st.Trs.ViderInfosTrs();
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x0003656C File Offset: 0x0003556C
		private void demarrerSimulationIp()
		{
			if (this.st.Reseau.Pref.CachesArpAutoIp)
			{
				Ip_station.RemplirCachesArp(this.st.Reseau.Schema, "Dyn.");
			}
			this.st.Reseau.DerniereSimulationIp.DemoIp = TypeSimulationIp.ping;
			Ip_station.attenteDecolorerCables.Interval = (int)((float)this.st.Reseau.Pref.AttentePing * this.st.Reseau.CoefVitesseDemo);
			Ip_station.attenteDecolorerCables.Start();
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

		// Token: 0x06000560 RID: 1376 RVA: 0x0003668C File Offset: 0x0003568C
		private void arreterSimulationIp()
		{
			if (this.etat != IpEtat.attenteEchoPing)
			{
				this.etat = IpEtat.inactif;
				Ip_station ip_station = null;
				this.st.Invalidate();
				this.st.Demo = null;
				int nbActif = this.getNbActif(ref ip_station);
				if (nbActif == 1 && ip_station.etat == IpEtat.attenteEchoPing)
				{
					if (Ip_station.EchecReponsePing != null)
					{
						Ip_station.EchecReponsePing(this, new PaquetIpEventArgs(this.paquetEnCours, this));
						return;
					}
				}
				else if (nbActif == 0 && Ip_station.stationQuiPing == null)
				{
					this.st.Reseau.TimerTraceTrame.Stop();
					this.st.Reseau.CacherPaquet(true);
					this.st.Reseau.EtatIpActif = Simulation.EtatIp.attente;
					this.st.Reseau.SetEnabledMenus(true);
					this.st.Reseau.LibererReglages();
					this.st.Reseau.Bt_stopBisIp.Text = "bis";
					this.st.Reseau.BisIpEnCours = false;
					this.st.Reseau.Bt_pauseRepriseIp.ImageIndex = 0;
					this.st.Reseau.Bt_pauseRepriseIp.Enabled = false;
					Ip_station.attenteDecolorerCables.Stop();
				}
			}
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x000367C8 File Offset: 0x000357C8
		private int getNbActif(ref Ip_station active)
		{
			int num = 0;
			foreach (object obj in this.st.Reseau.Schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if ((elementReseau.GetType() == typeof(Station) || elementReseau.GetType() == typeof(Internet)) && ((Station)elementReseau).Ip.etat != IpEtat.inactif)
				{
					active = ((Station)elementReseau).Ip;
					num++;
				}
			}
			return num;
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000562 RID: 1378 RVA: 0x00036880 File Offset: 0x00035880
		public Ip_DialogueSaisieIP Dialogue
		{
			get
			{
				return this.dialogue;
			}
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x00036894 File Offset: 0x00035894
		public void EnvoyerPing()
		{
			if (this.st.Reseau.NoBouclesHubGeneral())
			{
				this.demarrerSimulationIp();
				this.etat = IpEtat.pinging;
				this.dialogue = new Ip_DialogueSaisieIP(new SuiteOk(this.SuiteEnvoyerPing), new SuiteAnnuler(this.AnnulerEnvoyerPaquet), this.st);
				this.st.Reseau.DialoguePing = this.dialogue;
				this.dialogue.Text = "Hôte de destination";
				if (this.st.Reseau.BisIpEnCours)
				{
					this.dialogue.AdrIpSaisie = this.st.Reseau.DerniereSimulationIp.AdrIp;
					this.dialogue.BloquerSaisie();
				}
				else
				{
					this.dialogue.AdrIpSaisie = this.derniereIpSaisie;
				}
				this.dialogue.Location = this.st.posDialogueDemo();
				this.dialogue.InScreen();
				this.dialogue.Show();
				return;
			}
			MessageBox.Show("Impossible, le réseau comporte des boucles !");
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x0003699C File Offset: 0x0003599C
		public void AnnulerEnvoyerPaquet()
		{
			this.st.Reseau.DialoguePing = null;
			this.arreterSimulationIp();
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x000369C0 File Offset: 0x000359C0
		public void SuiteEnvoyerPing(object p_strAdrIp)
		{
			this.derniereIpSaisie = p_strAdrIp.ToString();
			this.strAdrIpCourante = p_strAdrIp.ToString();
			if (!this.st.Reseau.BisIpEnCours)
			{
				this.st.Reseau.DerniereSimulation.InitTablesSwitch();
				this.st.Reseau.DerniereSimulationIp.InitCachesArpStation();
				this.st.Reseau.DerniereSimulationIp.StationPing = this.st;
				this.st.Reseau.DerniereSimulationIp.AdrIp = this.strAdrIpCourante;
			}
			this.st.Reseau.Bt_stopBisIp.Enabled = true;
			this.st.Reseau.DialoguePing = null;
			if (this.st.Reseau.TypeDemoIp == Simulation.TypeDeDemo.noDemo)
			{
				this.st.Reseau.Bt_pauseRepriseIp.Enabled = true;
				this.st.Reseau.Bt_pauseRepriseIp.ImageIndex = 1;
				this.st.Reseau.Bt_pauseRepriseIp.Tag = "pause";
				this.SuiteEnvoyerPingNoDemo(p_strAdrIp);
				return;
			}
			this.st.Demo = new DemoPing(this.st.Reseau);
			this.st.Demo.TitreDialogue = this.st.NomNoeud;
			this.st.Demo.DemoTerminee += this.ping_DemoTerminee;
			this.st.Demo.DemarrerDemo(this.st, p_strAdrIp.ToString(), this.st.Reseau.TypeDemoIp);
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x00036B5C File Offset: 0x00035B5C
		private void ping_DemoTerminee(object sender, EventArgs e)
		{
			if (this.st.Demo != null)
			{
				this.st.Demo.DemoTerminee -= this.ping_DemoTerminee;
			}
			this.SuiteEnvoyerPingNoDemo(this.strAdrIpCourante);
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x00036BA0 File Offset: 0x00035BA0
		private void Ip_station_finEnvoiPaquetEchecPingNoRoutage(object sender, EventArgs e)
		{
			Ip_station.EchecReponsePing = (PaquetIpEventHandler)Delegate.Remove(Ip_station.EchecReponsePing, new PaquetIpEventHandler(this.Ip_station_EchecReponsePing));
			this.finEnvoiPaquet = (EventHandler)Delegate.Remove(this.finEnvoiPaquet, new EventHandler(this.Ip_station_finEnvoiPaquetEchecPingNoRoutage));
			if (this.st.Reseau.TypeDemoIp == Simulation.TypeDeDemo.noDemo)
			{
				this.echecPing_DemoTerminee(null, null);
				return;
			}
			this.st.Demo = new DemoEchecPing(this.st.Reseau);
			this.st.Demo.TitreDialogue = this.st.NomNoeud;
			this.st.Demo.DemoTerminee += this.echecPing_DemoTerminee;
			this.st.Demo.DemarrerDemo(this.st, "", this.st.Reseau.TypeDemoIp);
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x00036C88 File Offset: 0x00035C88
		public void SuiteEnvoyerPingNoDemo(object p_strAdrIp)
		{
			string text = (string)p_strAdrIp;
			if (!Ip_adresse.Ok(text))
			{
				text = FichierHostsEdit.GetAdrIp(this.fichierHosts, text);
			}
			if (!Ip_adresse.Ok(text) || Ip_quartet.Isnul(text))
			{
				this.st.Message.ShowDialog("Adresse IP incorrecte !", "ip");
				this.arreterSimulationIp();
				return;
			}
			if (text == "127.0.0.1")
			{
				this.st.Message.ShowDialog("L'hôte a bien renvoyé le paquet", "ip");
				this.etat = IpEtat.inactif;
				this.st.StyloRelief = this.st.Reseau.StyloEfface;
				this.arreterSimulationIp();
				return;
			}
			CarteReseau carteReseau = null;
			string text2 = null;
			this.TrouverRoute(new Ip_adresse(text), ref carteReseau, ref text2);
			if (carteReseau != null && Ip_quartet.ValPoste(new Ip_quartet(text), carteReseau.Ip.Masque) == 0U && Ip_quartet.MemeReseau(new Ip_quartet(text), carteReseau.Ip.Adresse, carteReseau.Ip.Masque))
			{
				this.st.Message.ShowDialog("Adresse IP incorrecte !", "ip");
				this.etat = IpEtat.inactif;
				this.st.StyloRelief = this.st.Reseau.StyloEfface;
				this.arreterSimulationIp();
				return;
			}
			if (carteReseau == null || carteReseau.EtatConnexion != PointConnexion.EtatsConnexion.actif)
			{
				this.st.Message.ShowDialog("Hôte non joignable !", "ip");
				this.etat = IpEtat.inactif;
				this.st.StyloRelief = this.st.Reseau.StyloEfface;
				this.arreterSimulationIp();
				return;
			}
			if (carteReseau.Ip.Adresse.ToString() == text)
			{
				this.st.Message.ShowDialog("L'hôte a bien renvoyé le paquet", "ip");
				this.etat = IpEtat.inactif;
				this.st.StyloRelief = this.st.Reseau.StyloEfface;
				this.arreterSimulationIp();
				return;
			}
			Ip_station.stationQuiPing = this;
			this.paquetEnCours = new Ip_PaquetIp(this.st, new Ip_adresse(text), TypeDePaquetIp.IcmpEchoRequest, text);
			this.etat = IpEtat.attenteEchoPing;
			CarteReseau carteReseau2 = Ip_station.TrouverCarteIpDansReseau(this.st.Reseau.Schema, this.paquetEnCours.AdrDest.ToString());
			bool flag = false;
			if (carteReseau2 != null && this.RouteIpOk(carteReseau, carteReseau2) && this.RouteIpOk(carteReseau2, carteReseau))
			{
				int nbSautsMax = this.st.Reseau.Pref.NbSautsMax;
				int nbSautsMax2 = this.st.Reseau.Pref.NbSautsMax;
				if (this.okJoindreIp(carteReseau2.Ip.Adresse, ref nbSautsMax) && ((Station)carteReseau2.NoeudAttache).Ip.okJoindreIp(carteReseau.Ip.Adresse, ref nbSautsMax2))
				{
					flag = true;
				}
			}
			if (!flag)
			{
				Ip_station.EchecReponsePing = (PaquetIpEventHandler)Delegate.Combine(Ip_station.EchecReponsePing, new PaquetIpEventHandler(this.Ip_station_EchecReponsePing));
			}
			this.SuiteEnvoyerPaquetIp();
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x00036F74 File Offset: 0x00035F74
		private bool okJoindreIp(Ip_adresse ipDest, ref int nbSauts)
		{
			CarteReseau carteReseau = this.TrouverCarteIp(ipDest.ToString());
			if (carteReseau != null && carteReseau.EtatConnexion == PointConnexion.EtatsConnexion.actif)
			{
				return true;
			}
			CarteReseau carteReseau2 = null;
			string text = null;
			if (this.TrouverRoute(ipDest, ref carteReseau2, ref text) == -1)
			{
				return false;
			}
			Station station;
			if (text == null)
			{
				station = Ip_station.trouverStationIp(this.st.Reseau.Schema, ipDest.ToString());
				return station.Ip.okJoindreIp(ipDest, ref nbSauts);
			}
			if (nbSauts == 0)
			{
				return false;
			}
			station = Ip_station.trouverStationIp(this.st.Reseau.Schema, text);
			nbSauts--;
			return station.Ip.okJoindreIp(ipDest, ref nbSauts);
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x00037010 File Offset: 0x00036010
		private void Ip_station_finEnvoiPaquet(object sender, EventArgs e)
		{
			this.finEnvoiPaquet = (EventHandler)Delegate.Remove(this.finEnvoiPaquet, new EventHandler(this.Ip_station_finEnvoiPaquet));
			if (this != Ip_station.stationQuiPing)
			{
				this.st.StyloRelief = this.st.Reseau.StyloEfface;
			}
			this.arreterSimulationIp();
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x0600056C RID: 1388 RVA: 0x0003707C File Offset: 0x0003607C
		// (set) Token: 0x0600056B RID: 1387 RVA: 0x00037068 File Offset: 0x00036068
		public bool OkRouteIp
		{
			get
			{
				return this.okRouteIp;
			}
			set
			{
				this.okRouteIp = value;
			}
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x00037090 File Offset: 0x00036090
		public bool RouteIpOk(CarteReseau source, CarteReseau dest)
		{
			if (source == null || source.EtatConnexion != PointConnexion.EtatsConnexion.actif)
			{
				return false;
			}
			CarteReseau carteReseau = null;
			string text = null;
			((Station)source.NoeudAttache).Ip.TrouverRoute(dest.Ip.Adresse, ref carteReseau, ref text);
			if (carteReseau == null)
			{
				return false;
			}
			if (text != null)
			{
				CarteReseau carteReseau2 = Ip_station.TrouverCarteIpDansReseau(this.st.Reseau.Schema, text);
				source = carteReseau;
				((Station)source.NoeudAttache).Ip.okRouteIp = false;
				if (carteReseau2 != null && carteReseau2.EtatConnexion == PointConnexion.EtatsConnexion.actif)
				{
					Ip_PaquetIp ip_PaquetIp = new Ip_PaquetIp(source, carteReseau2, carteReseau2.Ip.Adresse, TypeDePaquetIp.Aucun, "");
					Ip_station.cablesTraverses = new ArrayList();
					ip_PaquetIp.Route.Add(carteReseau2.NoeudAttache);
					source.Lien.TransmissionRapideEthernet(false, source, ip_PaquetIp, false, new ReactionStation(Station.ReactionValiderRoute), null);
					ip_PaquetIp.Route.Add(source.NoeudAttache);
					Ip_station.cablesTraverses = new ArrayList();
				}
			}
			if (text == null || ((Station)source.NoeudAttache).Ip.okRouteIp)
			{
				source = carteReseau;
				((Station)source.NoeudAttache).Ip.okRouteIp = false;
				Ip_PaquetIp ip_PaquetIp2 = new Ip_PaquetIp(source, dest, dest.Ip.Adresse, TypeDePaquetIp.Aucun, "");
				Ip_station.cablesTraverses = new ArrayList();
				ip_PaquetIp2.Route.Add(dest.NoeudAttache);
				source.Lien.TransmissionRapideEthernet(false, source, ip_PaquetIp2, false, new ReactionStation(Station.ReactionValiderRoute), null);
				ip_PaquetIp2.Route.Add(source.NoeudAttache);
				Ip_station.cablesTraverses = new ArrayList();
				return ((Station)source.NoeudAttache).Ip.okRouteIp;
			}
			return false;
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x0003724C File Offset: 0x0003624C
		public bool CalculerRoute(Ip_PaquetIp paquetMessage)
		{
			CarteReseau carteReseau = Ip_station.TrouverCarteIpDansReseau(this.st.Reseau.Schema, paquetMessage.AdrDest.ToString());
			if (carteReseau == null)
			{
				return false;
			}
			CarteReseau carteReseau2 = null;
			string text = null;
			this.TrouverRoute(paquetMessage.AdrDest, ref carteReseau2, ref text);
			Ip_adresse adrPasserelle;
			if (text == null)
			{
				CacheArpEdit.GetMac(this.st.Ip.CacheArp, paquetMessage.AdrDest);
				adrPasserelle = paquetMessage.AdrDest;
			}
			else
			{
				CacheArpEdit.GetMac(this.st.Ip.CacheArp, new Ip_adresse(text));
				adrPasserelle = new Ip_adresse(text);
			}
			paquetMessage.AdrPasserelle = adrPasserelle;
			if (carteReseau2 == null || carteReseau2.EtatConnexion != PointConnexion.EtatsConnexion.actif)
			{
				return false;
			}
			CarteReseau carteReseau3 = carteReseau2;
			if (text != null)
			{
				CarteReseau carteReseau4 = Ip_station.TrouverCarteIpDansReseau(this.st.Reseau.Schema, text);
				((Station)carteReseau3.NoeudAttache).Ip.okRouteIp = false;
				if (carteReseau4 != null && carteReseau4.EtatConnexion == PointConnexion.EtatsConnexion.actif)
				{
					Ip_PaquetIp ip_PaquetIp = new Ip_PaquetIp(carteReseau3, carteReseau4, carteReseau4.Ip.Adresse, TypeDePaquetIp.Aucun, "");
					Ip_station.cablesTraverses = new ArrayList();
					ip_PaquetIp.Route.Add(carteReseau4.NoeudAttache);
					carteReseau3.Lien.TransmissionRapideEthernet(false, carteReseau3, ip_PaquetIp, false, new ReactionStation(Station.ReactionValiderRoute), null);
					ip_PaquetIp.Route.Add(carteReseau3.NoeudAttache);
					Ip_station.cablesTraverses = new ArrayList();
				}
			}
			if (text != null && !((Station)carteReseau3.NoeudAttache).Ip.okRouteIp)
			{
				return false;
			}
			((Station)carteReseau2.NoeudAttache).Ip.okRouteIp = false;
			Ip_PaquetIp ip_PaquetIp2 = new Ip_PaquetIp(carteReseau2, carteReseau, paquetMessage.AdrDest, TypeDePaquetIp.Aucun, "");
			Ip_station.cablesTraverses = new ArrayList();
			ip_PaquetIp2.Route.Add(carteReseau.NoeudAttache);
			bool flag;
			if (carteReseau.NoeudAttache != this.st)
			{
				carteReseau2.Lien.TransmissionRapideEthernet(false, carteReseau2, ip_PaquetIp2, false, new ReactionStation(Station.ReactionValiderRoute), null);
				flag = ((Station)carteReseau2.NoeudAttache).Ip.okRouteIp;
			}
			else
			{
				flag = true;
			}
			ip_PaquetIp2.Route.Add(carteReseau2.NoeudAttache);
			paquetMessage.CablesTraverses = (ArrayList)Ip_station.cablesTraverses.Clone();
			Ip_station.cablesTraverses = new ArrayList();
			if (flag)
			{
				paquetMessage.Route = ip_PaquetIp2.Route;
				return true;
			}
			return false;
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x000374B0 File Offset: 0x000364B0
		private void envoyerResultatPaquet()
		{
			if (this.finEnvoiPaquet != null)
			{
				this.finEnvoiPaquet(this, new EventArgs());
			}
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x000374D8 File Offset: 0x000364D8
		public void DecrementerTtlCachesArp()
		{
			foreach (object obj in this.st.Reseau.Schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Station))
				{
					CacheArpEdit.DecrementerTtls(((Station)elementReseau).Ip.cacheArp);
				}
			}
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x0003756C File Offset: 0x0003656C
		public void SuiteEnvoyerPaquetIp()
		{
			this.DecrementerTtlCachesArp();
			this.st.StyloRelief = this.st.Reseau.Pref.StyloPaquet;
			this.st.Invalidate();
			bool flag = true;
			CarteReseau carteReseau = null;
			string text = null;
			this.TrouverRoute(this.paquetEnCours.AdrDest, ref carteReseau, ref text);
			if (carteReseau == null || carteReseau.EtatConnexion != PointConnexion.EtatsConnexion.actif)
			{
				this.envoyerResultatPaquet();
				return;
			}
			this.carteEmission = carteReseau;
			Ip_adresse ip_adresse = null;
			string text2;
			if (text == null)
			{
				if (carteReseau.Ip.Adresse.ToString() == this.paquetEnCours.AdrDest.ToString())
				{
					flag = false;
					text2 = carteReseau.AdresseMac;
					this.paquetEnCours.CarteDestLocale = true;
					this.envoyerResultatPaquet();
				}
				else
				{
					if (this.carteEmission.GetType() == typeof(CarteAccesDistant) || this.carteEmission.GetType() == typeof(PortFai))
					{
						text2 = ((CarteReseau)this.carteEmission.Lien.Oppose(this.carteEmission)).AdresseMac;
					}
					else
					{
						text2 = CacheArpEdit.GetMac(this.cacheArp, this.paquetEnCours.AdrDest);
					}
					ip_adresse = this.paquetEnCours.AdrDest;
				}
			}
			else
			{
				if (this.carteEmission.GetType() == typeof(CarteAccesDistant) || this.carteEmission.GetType() == typeof(PortFai))
				{
					text2 = ((CarteReseau)this.carteEmission.Lien.Oppose(this.carteEmission)).AdresseMac;
				}
				else
				{
					text2 = CacheArpEdit.GetMac(this.cacheArp, new Ip_adresse(text));
				}
				ip_adresse = new Ip_adresse(text);
			}
			this.paquetEnCours.AdrPasserelle = ip_adresse;
			if (flag)
			{
				if (text2 == null)
				{
					Ip_station.nbcablesConcernes = 0;
					Ip_PaquetIp ip_PaquetIp = new Ip_PaquetIp(carteReseau, null, ip_adresse, TypeDePaquetIp.Aucun, "");
					Ip_station.cablesTraverses = new ArrayList();
					Ip_station.NbStationsConcernes = 0;
					carteReseau.Lien.TransmissionRapideEthernet(false, carteReseau, ip_PaquetIp, false, new ReactionStation(Station.ReactionCompterStations), null);
					Ip_station.nbcablesConcernes = Ip_station.cablesTraverses.Count;
					this.adrMacReponseArp = "";
					ip_PaquetIp = new Ip_PaquetIp(carteReseau, null, ip_adresse, TypeDePaquetIp.ArpRequest, "Target IP : " + ip_adresse);
					this.st.Reseau.AfficherPaquet(ip_PaquetIp, "arp", ip_PaquetIp.Type.ToString() + " - " + ip_PaquetIp.Donnees);
					Ip_station.cablesTraverses = new ArrayList();
					this.paquetArpEnCours = ip_PaquetIp;
					if (this.st.Reseau.TypeDemoIp != Simulation.TypeDeDemo.noDemo && this.st.Reseau.DemoArp && Ip_station.nbStationsConcernes > 0)
					{
						Ip_carte.UneDemoArpTerminee += this.Ip_carte_uneDemoArpTerminee;
					}
					else
					{
						Cable.TransmissionRapideTerminee += this.EnvoyerFinRequeteArp;
					}
					carteReseau.Lien.TransmissionRapideEthernet(true, carteReseau, ip_PaquetIp, false, new ReactionStation(Station.ReactionRenseignerAdrArp), new ReactionSwitch(Switch.ReactionMajTables));
					return;
				}
				this.adrMacReponseArp = text2;
				this.FinEnvoyerPaquet();
			}
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x00037874 File Offset: 0x00036874
		private void Ip_carte_uneDemoArpTerminee(object sender, EventArgs e)
		{
			Ip_station.nbStationsConcernes--;
			if (Ip_station.nbStationsConcernes == 0)
			{
				Ip_carte.UneDemoArpTerminee -= this.Ip_carte_uneDemoArpTerminee;
				this.EnvoyerFinRequeteArp(null, null);
			}
		}

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000573 RID: 1395 RVA: 0x000378B0 File Offset: 0x000368B0
		// (remove) Token: 0x06000574 RID: 1396 RVA: 0x000378D4 File Offset: 0x000368D4
		private event EventHandler finEnvoiPaquet;

		// Token: 0x06000575 RID: 1397 RVA: 0x000378F8 File Offset: 0x000368F8
		public void EnvoyerFinRequeteArp(object sender, EventArgs e)
		{
			Cable.TransmissionRapideTerminee -= this.EnvoyerFinRequeteArp;
			this.paquetArpEnCours.Type = TypeDePaquetIp.ArpRequestTermine;
			if (this.PaquetTransmis != null)
			{
				this.PaquetTransmis(this, new PaquetIpEventArgs(this.paquetArpEnCours, this));
			}
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x00037944 File Offset: 0x00036944
		public void SuiteRequeteArp()
		{
			foreach (object obj in Ip_station.cablesTraverses)
			{
				Cable cable = (Cable)obj;
				cable.Stylo = this.st.Reseau.Pref.NormalStylo;
			}
			this.st.Reseau.Schema.Invalidate(false);
			if (this.adrMacReponseArp == "")
			{
				if (this.etat != IpEtat.attenteEchoPing)
				{
					this.etat = IpEtat.inactif;
					this.st.StyloRelief = this.st.Reseau.StyloEfface;
					this.arreterSimulationIp();
					return;
				}
				if (Ip_station.EchecReponsePing != null)
				{
					Ip_station.EchecReponsePing(this, new PaquetIpEventArgs(this.paquetEnCours, this));
					return;
				}
			}
			else
			{
				CarteReseau carteReseau = CarteReseau.TrouverCarte(this.adrMacReponseArp, this.st.Reseau);
				Station station = (Station)carteReseau.NoeudAttache;
				Ip_PaquetIp ip_PaquetIp = new Ip_PaquetIp(carteReseau, this.carteEmission, this.carteEmission.Ip.Adresse, TypeDePaquetIp.Aucun, "");
				Ip_station.cablesTraverses = new ArrayList();
				carteReseau.Lien.TransmissionRapideEthernet(false, carteReseau, ip_PaquetIp, false, null, null);
				Ip_station.nbcablesConcernes = Ip_station.cablesTraverses.Count;
				ip_PaquetIp = new Ip_PaquetIp(carteReseau, this.carteEmission, this.carteEmission.Ip.Adresse, TypeDePaquetIp.ArpReply, "Target MAC : " + carteReseau.AdresseMac);
				this.st.Reseau.AfficherPaquet(ip_PaquetIp, "arp", ip_PaquetIp.Type.ToString() + " - " + ip_PaquetIp.Donnees);
				Ip_station.cablesTraverses = new ArrayList();
				carteReseau.Lien.TransmissionRapideEthernet(true, carteReseau, ip_PaquetIp, false, null, new ReactionSwitch(Switch.ReactionMajTables));
				this.paquetArpEnCours = ip_PaquetIp;
				Cable.TransmissionRapideTerminee += this.FinRequeteArp;
			}
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x00037B50 File Offset: 0x00036B50
		public void FinRequeteArp(object sender, EventArgs e)
		{
			Cable.TransmissionRapideTerminee -= this.FinRequeteArp;
			if (this.PaquetTransmis != null)
			{
				this.PaquetTransmis(this, new PaquetIpEventArgs(this.paquetArpEnCours, this));
			}
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x00037B90 File Offset: 0x00036B90
		public void FinEnvoyerPaquet()
		{
			if (!(this.adrMacReponseArp != ""))
			{
				this.envoyerResultatPaquet();
				return;
			}
			if (this.carteEmission.GetType() != typeof(CarteAccesDistant) && this.carteEmission.GetType() != typeof(PortFai))
			{
				this.AjoutCacheArp(this.paquetEnCours.AdrPasserelle, this.adrMacReponseArp, this.carteEmission, "Dyn.");
			}
			this.paquetEnCours.MacSource = this.carteEmission.AdresseMac;
			CarteReseau carteReseau = CarteReseau.TrouverCarte(this.adrMacReponseArp, this.st.Reseau);
			if (carteReseau != null)
			{
				this.paquetEnCours.MacDest = carteReseau.AdresseMac;
			}
			if (carteReseau == null || carteReseau.EtatConnexion != PointConnexion.EtatsConnexion.actif)
			{
				if (this.st.Reseau.Pref.TrameModeIp)
				{
					this.ColorerRapideEthernet(this.carteEmission);
				}
				if (Ip_station.stationQuiPing == this)
				{
					this.finEnvoiPaquet = (EventHandler)Delegate.Combine(this.finEnvoiPaquet, new EventHandler(this.Ip_station_finEnvoiPaquetEchecPingNoRoutage));
				}
				Ip_station.attenteDecolorerCables.Tick += this.attenteDecolorerCables_Tick;
				return;
			}
			Station stationDest = (Station)carteReseau.NoeudAttache;
			if (this.paquetEnCours.AdrSource == null)
			{
				this.paquetEnCours.AdrSource = this.carteEmission.Ip.Adresse;
			}
			this.paquetEnCours.CarteDest = carteReseau;
			this.paquetEnCours.CarteSource = this.carteEmission;
			this.paquetEnCours.StationDest = stationDest;
			if (!this.paquetEnCours.CarteDestLocale)
			{
				this.EnvoyerPaquetIp();
				return;
			}
			this.envoyerResultatPaquet();
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x00037D34 File Offset: 0x00036D34
		private void attenteDecolorerCables_Tick(object sender, EventArgs e)
		{
			Ip_station.attenteDecolorerCables.Tick -= this.attenteDecolorerCables_Tick;
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
			this.envoyerResultatPaquet();
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600057B RID: 1403 RVA: 0x00037E30 File Offset: 0x00036E30
		// (set) Token: 0x0600057A RID: 1402 RVA: 0x00037E1C File Offset: 0x00036E1C
		public static int NbcablesConcernes
		{
			get
			{
				return Ip_station.nbcablesConcernes;
			}
			set
			{
				Ip_station.nbcablesConcernes = value;
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x0600057D RID: 1405 RVA: 0x00037E58 File Offset: 0x00036E58
		// (set) Token: 0x0600057C RID: 1404 RVA: 0x00037E44 File Offset: 0x00036E44
		public static int NbStationsConcernes
		{
			get
			{
				return Ip_station.nbStationsConcernes;
			}
			set
			{
				Ip_station.nbStationsConcernes = value;
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600057E RID: 1406 RVA: 0x00037E6C File Offset: 0x00036E6C
		// (set) Token: 0x0600057F RID: 1407 RVA: 0x00037E80 File Offset: 0x00036E80
		public static ArrayList CablesTraverses
		{
			get
			{
				return Ip_station.cablesTraverses;
			}
			set
			{
				Ip_station.cablesTraverses = value;
			}
		}

		// Token: 0x170000C1 RID: 193
		// (set) Token: 0x06000580 RID: 1408 RVA: 0x00037E94 File Offset: 0x00036E94
		public string AdrMacReponseArp
		{
			set
			{
				this.adrMacReponseArp = value;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000581 RID: 1409 RVA: 0x00037EA8 File Offset: 0x00036EA8
		// (set) Token: 0x06000582 RID: 1410 RVA: 0x00037EBC File Offset: 0x00036EBC
		public Ip_PaquetIp PaquetEnCours
		{
			get
			{
				return this.paquetEnCours;
			}
			set
			{
				this.paquetEnCours = value;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000583 RID: 1411 RVA: 0x00037ED0 File Offset: 0x00036ED0
		public string TypePaquetEnCours
		{
			get
			{
				if (this.paquetEnCours == null)
				{
					return "";
				}
				return this.paquetEnCours.Type.ToString();
			}
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x00037F00 File Offset: 0x00036F00
		public void EnvoyerPaquetIp()
		{
			Ip_station.cablesTraverses = new ArrayList();
			this.paquetEnCours.CarteSource.Lien.TransmissionRapideEthernet(false, this.paquetEnCours.CarteSource, this.paquetEnCours, false, null, null);
			this.st.Reseau.AfficherPaquet(this.paquetEnCours, "ip", this.paquetEnCours.Type.ToString() + " - " + this.paquetEnCours.Donnees);
			Ip_CableVirtuel ip_CableVirtuel = new Ip_CableVirtuel(this.paquetEnCours);
			if (this.st.Reseau.CablesVirtuelIp)
			{
				ip_CableVirtuel.Tracer(new SuiteTracerCableVirtuelIp(this.FinTracerPaquet));
			}
			else
			{
				ArrayList arrayList = new ArrayList();
				ArrayList arrayList2 = new ArrayList();
				this.paquetEnCours.CarteSource.Lien.Oppose(this.paquetEnCours.CarteSource).CalculerCheminIp(this.paquetEnCours.CarteDest, ref arrayList, ref arrayList2);
				arrayList.Add(this.paquetEnCours.CarteSource.Lien.Oppose(this.paquetEnCours.CarteSource));
				arrayList.Add(this.paquetEnCours.CarteSource);
				Pen p_premierStylo;
				if (this.st.Reseau.Pref.TrameModeIp)
				{
					if (this.paquetEnCours.CarteSource.GetType() == typeof(CarteAccesDistant) || this.paquetEnCours.CarteSource.GetType() == typeof(PortFai))
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
				ip_CableVirtuel.Tracer(new SuiteTracerCableVirtuelIp(this.FinTracerPaquet), arrayList, p_premierStylo);
			}
			if (this.st.Reseau.Pref.TrameModeIp)
			{
				this.ColorerRapideEthernet(this.paquetEnCours.CarteSource);
			}
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x00038128 File Offset: 0x00037128
		public void ColorerRapideEthernet(CarteReseau depart)
		{
			Ip_station.cablesTraverses = new ArrayList();
			Pen stylo;
			if (depart.GetType() == typeof(CarteAccesDistant) || depart.GetType() == typeof(PortFai))
			{
				stylo = new Pen(this.st.Reseau.Pref.CableActifStylo2.Brush, 1f);
			}
			else
			{
				stylo = new Pen(this.st.Reseau.Pref.CableActifStylo1.Brush, 1f);
			}
			depart.Lien.TransmissionRapideEthernet(false, depart, this.paquetEnCours, false, null, new ReactionSwitch(Switch.ReactionMajTables));
			foreach (object obj in Ip_station.cablesTraverses)
			{
				Cable cable = (Cable)obj;
				cable.Stylo = stylo;
			}
			this.st.Reseau.Schema.Invalidate(false);
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x00038240 File Offset: 0x00037240
		public void FinTracerPaquet(object obj)
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
			if (this != Ip_station.stationQuiPing)
			{
				this.st.StyloRelief = this.st.Reseau.StyloEfface;
				this.st.Invalidate();
			}
			if (this.PaquetTransmis != null && !this.paquetEnCours.CarteDestLocale)
			{
				this.PaquetTransmis(this, new PaquetIpEventArgs(this.paquetEnCours, this.paquetEnCours.StationDest.Ip));
			}
			this.envoyerResultatPaquet();
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x00038378 File Offset: 0x00037378
		public int TrouverRoute(Ip_adresse adrIpDest, ref CarteReseau maCarte, ref string passerelle)
		{
			int result = -1;
			bool flag = false;
			int num = 0;
			ArrayList route = null;
			while (num < this.routes.Count && !flag)
			{
				route = HashTableEdit.TriGetLignePos(this.routes, num);
				if (Ip_quartet.MemeReseau(RouteEdit.GetAdrDest(route), adrIpDest.ToString(), RouteEdit.GetMasque(route)))
				{
					result = num;
					flag = true;
				}
				else
				{
					num++;
				}
			}
			if (!flag)
			{
				maCarte = null;
				passerelle = null;
			}
			else
			{
				maCarte = this.TrouverCarteIp(RouteEdit.GetInterface(route));
				passerelle = RouteEdit.GetPasserelle(route);
				if (passerelle == RouteEdit.GetInterface(route))
				{
					passerelle = null;
				}
			}
			return result;
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x00038404 File Offset: 0x00037404
		public static void ViderCachesArp(Control reseau)
		{
			foreach (object obj in reseau.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Station))
				{
					((Station)elementReseau).Ip.cacheArp = new SortedList();
				}
			}
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x0003848C File Offset: 0x0003748C
		public static void RemplirCachesArp(Control reseau, string type)
		{
			foreach (object obj in reseau.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Station))
				{
					((Station)elementReseau).Ip.cacheArp = new SortedList();
				}
			}
			foreach (object obj2 in reseau.Controls)
			{
				ElementReseau elementReseau2 = (ElementReseau)obj2;
				if (elementReseau2.GetType() == typeof(Station))
				{
					foreach (object obj3 in elementReseau2.Controls)
					{
						CarteReseau carteReseau = (CarteReseau)obj3;
						if (carteReseau.Lien != null && !carteReseau.Ip.Adresse.Isnul())
						{
							Ip_station.cablesTraverses = new ArrayList();
							Ip_PaquetIp paquet = new Ip_PaquetIp(carteReseau, null, new Ip_adresse("0.0.0.0"), TypeDePaquetIp.Aucun, type);
							carteReseau.Lien.TransmissionRapideEthernet(false, carteReseau, paquet, true, new ReactionStation(Station.ReactionMajCacheArp), null);
						}
					}
				}
			}
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x00038630 File Offset: 0x00037630
		public void AjoutCacheArp(Ip_adresse ip, string mac, CarteReseau c, string type)
		{
			bool flag = true;
			if (type == "Stat.")
			{
				this.cacheArp.Remove(Ip_quartet.FormatFixe(ip));
			}
			else if (CacheArpEdit.GetType(this.cacheArp, ip) == "Dyn.")
			{
				this.cacheArp.Remove(Ip_quartet.FormatFixe(ip));
			}
			else if (CacheArpEdit.GetType(this.cacheArp, ip) == "Stat.")
			{
				flag = false;
			}
			if (flag)
			{
				ArrayList arrayList = new ArrayList();
				arrayList.Add(Ip_quartet.FormatFixe(ip));
				arrayList.Add(mac);
				arrayList.Add(type);
				arrayList.Add(c.NumeroOrdre.ToString());
				if (type == "Dyn.")
				{
					arrayList.Add(this.st.Reseau.Pref.TtlCacheArp.ToString());
				}
				else
				{
					arrayList.Add("---");
				}
				this.cacheArp.Add(arrayList[0], arrayList);
			}
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x0003873C File Offset: 0x0003773C
		private bool possederCarteMac(string adrMac)
		{
			foreach (object obj in this.st.Controls)
			{
				CarteReseau carteReseau = (CarteReseau)obj;
				if (carteReseau.AdresseMac == adrMac)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x000387B4 File Offset: 0x000377B4
		public bool possederCarteIp(string adrIp)
		{
			foreach (object obj in this.st.Controls)
			{
				CarteReseau carteReseau = (CarteReseau)obj;
				if (carteReseau.Ip.Adresse.ToString() == adrIp)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x00038838 File Offset: 0x00037838
		public static CarteReseau TrouverCarteNoInternetIp(Control reseau, string adrIp1, string adrIp2, string adrIp3, string adrIp4)
		{
			foreach (object obj in reseau.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Station))
				{
					CarteReseau carteReseau = ((Station)elementReseau).Ip.TrouverCarteIp(adrIp1);
					if (carteReseau != null)
					{
						return carteReseau;
					}
					carteReseau = ((Station)elementReseau).Ip.TrouverCarteIp(adrIp2);
					if (carteReseau != null)
					{
						return carteReseau;
					}
					carteReseau = ((Station)elementReseau).Ip.TrouverCarteIp(adrIp3);
					if (carteReseau != null)
					{
						return carteReseau;
					}
					carteReseau = ((Station)elementReseau).Ip.TrouverCarteIp(adrIp4);
					if (carteReseau != null)
					{
						return carteReseau;
					}
				}
			}
			return null;
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x0003891C File Offset: 0x0003791C
		private static Station trouverStationIp(Control reseau, string adrIp)
		{
			foreach (object obj in reseau.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if ((elementReseau.GetType() == typeof(Station) || elementReseau.GetType() == typeof(Internet)) && ((Station)elementReseau).Ip.possederCarteIp(adrIp))
				{
					return (Station)elementReseau;
				}
			}
			return null;
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x000389C0 File Offset: 0x000379C0
		public CarteReseau TrouverCarteIp(string adrIp)
		{
			foreach (object obj in this.st.Controls)
			{
				CarteReseau carteReseau = (CarteReseau)obj;
				if (carteReseau.Ip.Adresse.ToString() == adrIp.Trim())
				{
					return carteReseau;
				}
			}
			return null;
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x00038A48 File Offset: 0x00037A48
		public CarteReseau trouverCarteMac(string adrMac)
		{
			foreach (object obj in this.st.Controls)
			{
				CarteReseau carteReseau = (CarteReseau)obj;
				if (carteReseau.AdresseMac == adrMac)
				{
					return carteReseau;
				}
			}
			return null;
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x00038AC0 File Offset: 0x00037AC0
		public static CarteReseau TrouverCarteIpDansReseau(Control reseau, string adrIp)
		{
			foreach (object obj in reseau.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Station) || elementReseau.GetType() == typeof(Internet))
				{
					CarteReseau carteReseau = ((Station)elementReseau).Ip.TrouverCarteIp(adrIp);
					if (carteReseau != null)
					{
						return carteReseau;
					}
				}
			}
			return null;
		}

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x06000592 RID: 1426 RVA: 0x00038B64 File Offset: 0x00037B64
		// (remove) Token: 0x06000593 RID: 1427 RVA: 0x00038B88 File Offset: 0x00037B88
		public event PaquetIpEventHandler PaquetTransmis;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06000594 RID: 1428 RVA: 0x00038BAC File Offset: 0x00037BAC
		// (remove) Token: 0x06000595 RID: 1429 RVA: 0x00038BD0 File Offset: 0x00037BD0
		private static event PaquetIpEventHandler EchecReponsePing;

		// Token: 0x06000596 RID: 1430 RVA: 0x00038BF4 File Offset: 0x00037BF4
		public void InstallerGestionEvenements()
		{
			foreach (object obj in this.st.Reseau.Schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Station) || elementReseau.GetType() == typeof(Internet))
				{
					Ip_station ip = ((Station)elementReseau).Ip;
					ip.PaquetTransmis = (PaquetIpEventHandler)Delegate.Combine(ip.PaquetTransmis, new PaquetIpEventHandler(this.Ip_PaquetTransmis));
				}
			}
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x00038CB4 File Offset: 0x00037CB4
		public void DesinstallerGestionEvenements()
		{
			foreach (object obj in this.st.Reseau.Schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Station) || elementReseau.GetType() == typeof(Internet))
				{
					Ip_station ip = ((Station)elementReseau).Ip;
					ip.PaquetTransmis = (PaquetIpEventHandler)Delegate.Remove(ip.PaquetTransmis, new PaquetIpEventHandler(this.Ip_PaquetTransmis));
				}
			}
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x00038D74 File Offset: 0x00037D74
		private void Ip_PaquetTransmis(Ip_station sender, PaquetIpEventArgs e)
		{
			if (e.Cible == this)
			{
				switch (e.Paquet.Type)
				{
				case TypeDePaquetIp.IcmpEchoRequest:
					this.suitePaquetIpTransmis(e.Paquet);
					return;
				case TypeDePaquetIp.IcmpEchoResponse:
					this.suitePaquetIpTransmis(e.Paquet);
					return;
				case TypeDePaquetIp.ArpRequest:
					break;
				case TypeDePaquetIp.ArpReply:
					this.suiteArpReplyTransmis(e.Paquet);
					break;
				case TypeDePaquetIp.ArpRequestTermine:
					this.SuiteRequeteArp();
					return;
				default:
					return;
				}
			}
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x00038DE0 File Offset: 0x00037DE0
		private void suiteArpReplyTransmis(Ip_PaquetIp paquet)
		{
			if (this.st.Reseau.TypeDemoIp != Simulation.TypeDeDemo.noDemo && this.st.Reseau.DemoArp)
			{
				this.st.Demo = new DemoArp(this.st.Reseau);
				this.st.Demo.TitreDialogue = this.st.NomNoeud;
				this.st.Demo.DemoTerminee += this.Demo_DemoArpReplyTerminee;
				this.st.Demo.DemarrerDemo(paquet.CarteDest, paquet, this.st.Reseau.TypeDemoIp);
				return;
			}
			if (!this.st.Reseau.Pref.TrameModeIp)
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
			this.FinEnvoyerPaquet();
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x00038F54 File Offset: 0x00037F54
		private void Demo_DemoArpReplyTerminee(object sender, EventArgs e)
		{
			this.st.Demo.DemoTerminee -= this.Demo_DemoArpReplyTerminee;
			this.FinEnvoyerPaquet();
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x00038F84 File Offset: 0x00037F84
		public void suitePaquetIpTransmis(Ip_PaquetIp paquet)
		{
			if (this.st.GetType() == typeof(Internet) && (!this.st.Reseau.Pref.DemosInternet || this.st.Reseau.TypeDemoIp == Simulation.TypeDeDemo.manuel))
			{
				this.finPaquetIpTransmis(paquet);
				return;
			}
			if (this.st.Reseau.TypeDemoIp != Simulation.TypeDeDemo.noDemo)
			{
				this.argEtat = this.etat;
				this.etat = IpEtat.enDemo;
				this.argPaquet = paquet;
				this.st.Demo = new DemoPaquetIp(this.st.Reseau);
				this.st.Demo.TitreDialogue = this.st.NomNoeud;
				this.st.Demo.DemoTerminee += this.Demo_DemoPaquetIpTerminee;
				this.st.Demo.DemarrerDemo(this.st, paquet, this.st.Reseau.TypeDemoIp);
				return;
			}
			this.finPaquetIpTransmis(paquet);
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x0003908C File Offset: 0x0003808C
		private void Demo_DemoPaquetIpTerminee(object sender, EventArgs e)
		{
			this.st.Demo.DemoTerminee -= this.Demo_DemoPaquetIpTerminee;
			this.etat = this.argEtat;
			this.finPaquetIpTransmis(this.argPaquet);
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x000390D0 File Offset: 0x000380D0
		private void finPaquetIpTransmis(Ip_PaquetIp paquet)
		{
			CarteReseau carteReseau = this.TrouverCarteIp(paquet.AdrDest.ToString());
			if (carteReseau != null)
			{
				if (carteReseau.EtatConnexion == PointConnexion.EtatsConnexion.actif)
				{
					if (Ip_quartet.MemeReseau(paquet.AdrDest, paquet.CarteDest.Ip.Adresse, carteReseau.Ip.Masque))
					{
						this.traiterPaquet(paquet);
						return;
					}
					if (this.routageActif)
					{
						this.traiterPaquet(paquet);
						return;
					}
					this.traiterPaquet(paquet);
					return;
				}
				else if (Ip_station.EchecReponsePing != null)
				{
					Ip_station.EchecReponsePing(this, new PaquetIpEventArgs(paquet, this));
					return;
				}
			}
			else
			{
				if (paquet.NbSauts > 0 && this.routageActif)
				{
					this.routerPaquet(paquet);
					return;
				}
				if (Ip_station.EchecReponsePing != null)
				{
					Ip_station.EchecReponsePing(this, new PaquetIpEventArgs(paquet, this));
				}
			}
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x00039190 File Offset: 0x00038190
		private void traiterPaquet(Ip_PaquetIp paquet)
		{
			switch (paquet.Type)
			{
			case TypeDePaquetIp.IcmpEchoRequest:
				this.etat = IpEtat.reponsePing;
				this.paquetEnCours = new Ip_PaquetIp(this.st, paquet.AdrSource, TypeDePaquetIp.IcmpEchoResponse, paquet.Donnees);
				this.finEnvoiPaquet = (EventHandler)Delegate.Combine(this.finEnvoiPaquet, new EventHandler(this.Ip_station_finEnvoiPaquet));
				this.SuiteEnvoyerPaquetIp();
				return;
			case TypeDePaquetIp.IcmpEchoResponse:
				if (this.etat != IpEtat.inactif)
				{
					this.st.Message.ShowDialog("L'hôte a bien renvoyé le paquet", "ip");
					this.etat = IpEtat.inactif;
					Ip_station.stationQuiPing = null;
					this.st.StyloRelief = this.st.Reseau.StyloEfface;
					this.arreterSimulationIp();
				}
				return;
			default:
				return;
			}
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x00039254 File Offset: 0x00038254
		private void routerPaquet(Ip_PaquetIp paquet)
		{
			this.etat = IpEtat.routagePaquet;
			this.paquetEnCours = new Ip_PaquetIp(this.st, paquet.AdrDest, paquet.Type, paquet.Donnees);
			this.paquetEnCours.NbSauts = paquet.NbSauts - 1;
			this.paquetEnCours.AdrSource = paquet.AdrSource;
			this.finEnvoiPaquet = (EventHandler)Delegate.Combine(this.finEnvoiPaquet, new EventHandler(this.Ip_station_finEnvoiPaquet));
			this.SuiteEnvoyerPaquetIp();
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x000392D8 File Offset: 0x000382D8
		public string GetEtat()
		{
			string result = "";
			switch (this.etat)
			{
			case IpEtat.inactif:
				result = "";
				break;
			case IpEtat.pinging:
				result = "Ping " + this.strAdrIpCourante;
				break;
			case IpEtat.attenteEchoPing:
				result = "Ping " + this.paquetEnCours.AdrDest.ToString();
				break;
			case IpEtat.reponsePing:
				result = "Pong...";
				break;
			case IpEtat.routagePaquet:
				result = "Routage paquet";
				break;
			}
			return result;
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x00039358 File Offset: 0x00038358
		private void Ip_station_EchecReponsePing(Ip_station sender, PaquetIpEventArgs e)
		{
			Ip_station.EchecReponsePing = (PaquetIpEventHandler)Delegate.Remove(Ip_station.EchecReponsePing, new PaquetIpEventHandler(this.Ip_station_EchecReponsePing));
			this.attenteReponsePing.Interval = (int)((float)this.st.Reseau.Pref.AttentePing * this.st.Reseau.CoefVitesseDemo);
			this.attenteReponsePing.Tick += this.attenteReponsePing_Tick;
			this.attenteReponsePing.Start();
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x000393DC File Offset: 0x000383DC
		private void attenteReponsePing_Tick(object sender, EventArgs e)
		{
			this.attenteReponsePing.Stop();
			this.attenteReponsePing.Tick -= this.attenteReponsePing_Tick;
			if (this.st.Reseau.TypeDemoIp == Simulation.TypeDeDemo.noDemo)
			{
				this.echecPing_DemoTerminee(null, null);
				return;
			}
			this.st.Demo = new DemoEchecPing(this.st.Reseau);
			this.st.Demo.TitreDialogue = this.st.NomNoeud;
			this.st.Demo.DemoTerminee += this.echecPing_DemoTerminee;
			this.st.Demo.DemarrerDemo(this.st, "", this.st.Reseau.TypeDemoIp);
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x000394A4 File Offset: 0x000384A4
		private void echecPing_DemoTerminee(object sender, EventArgs e)
		{
			if (this.st.Demo != null)
			{
				this.st.Demo.DemoTerminee -= this.echecPing_DemoTerminee;
			}
			this.st.Message.ShowDialog("Délai d'attente dépassé !", "ip");
			this.etat = IpEtat.inactif;
			Ip_station.stationQuiPing = null;
			this.st.StyloRelief = this.st.Reseau.StyloEfface;
			this.arreterSimulationIp();
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x00039524 File Offset: 0x00038524
		public void StopperSimulation()
		{
			this.attenteReponsePing.Stop();
			this.attenteReponsePing.Tick -= this.attenteReponsePing_Tick;
			Ip_station.EchecReponsePing = (PaquetIpEventHandler)Delegate.Remove(Ip_station.EchecReponsePing, new PaquetIpEventHandler(this.Ip_station_EchecReponsePing));
			Cable.TransmissionRapideTerminee -= this.EnvoyerFinRequeteArp;
			Cable.TransmissionRapideTerminee -= this.FinRequeteArp;
			this.st.StyloRelief = this.st.Reseau.StyloEfface;
			this.paquetEnCours = null;
			Ip_station.stationQuiPing = null;
			this.etat = IpEtat.inactif;
			if (this.st.Demo != null)
			{
				this.st.Demo.DemoTerminee -= this.ping_DemoTerminee;
				this.st.Demo.DemoTerminee -= this.Demo_DemoArpReplyTerminee;
				this.st.Demo.DemoTerminee -= this.Demo_DemoPaquetIpTerminee;
				this.st.Demo.DemoTerminee -= this.echecPing_DemoTerminee;
			}
			this.st.Demo = null;
			Ip_carte.UneDemoArpTerminee -= this.Ip_carte_uneDemoArpTerminee;
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060005A5 RID: 1445 RVA: 0x00039660 File Offset: 0x00038660
		// (set) Token: 0x060005A6 RID: 1446 RVA: 0x00039674 File Offset: 0x00038674
		public int HauteurTableRoutage
		{
			get
			{
				return this.hauteurTableRoutage;
			}
			set
			{
				this.hauteurTableRoutage = value;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060005A7 RID: 1447 RVA: 0x00039688 File Offset: 0x00038688
		// (set) Token: 0x060005A8 RID: 1448 RVA: 0x0003969C File Offset: 0x0003869C
		public int HauteurCacheArp
		{
			get
			{
				return this.hauteurCacheArp;
			}
			set
			{
				this.hauteurCacheArp = value;
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060005A9 RID: 1449 RVA: 0x000396B0 File Offset: 0x000386B0
		// (set) Token: 0x060005AA RID: 1450 RVA: 0x000396C4 File Offset: 0x000386C4
		public int HauteurFichierHosts
		{
			get
			{
				return this.hauteurFichierHosts;
			}
			set
			{
				this.hauteurFichierHosts = value;
			}
		}

		// Token: 0x040003AC RID: 940
		private Station st;

		// Token: 0x040003AD RID: 941
		private SortedList routes;

		// Token: 0x040003AE RID: 942
		private SortedList cacheArp;

		// Token: 0x040003AF RID: 943
		private SortedList fichierHosts;

		// Token: 0x040003B0 RID: 944
		private Ip_adresse passerelle;

		// Token: 0x040003B1 RID: 945
		private bool routageActif;

		// Token: 0x040003B2 RID: 946
		private Ip_adresse serveurDns;

		// Token: 0x040003B3 RID: 947
		public static Ip_station stationQuiPing = null;

		// Token: 0x040003B4 RID: 948
		private Ip_DialogueSaisieIP dialogue;

		// Token: 0x040003B5 RID: 949
		private string derniereIpSaisie = "";

		// Token: 0x040003B6 RID: 950
		private string strAdrIpCourante;

		// Token: 0x040003B7 RID: 951
		private bool okRouteIp = false;

		// Token: 0x040003B9 RID: 953
		private static Timer attenteDecolorerCables = new Timer();

		// Token: 0x040003BA RID: 954
		private Timer attenteReponsePing = new Timer();

		// Token: 0x040003BB RID: 955
		private CarteReseau carteEmission;

		// Token: 0x040003BC RID: 956
		private static int nbcablesConcernes;

		// Token: 0x040003BD RID: 957
		private static int nbStationsConcernes;

		// Token: 0x040003BE RID: 958
		private static ArrayList cablesTraverses = new ArrayList();

		// Token: 0x040003BF RID: 959
		private string adrMacReponseArp;

		// Token: 0x040003C0 RID: 960
		private Ip_PaquetIp paquetEnCours;

		// Token: 0x040003C1 RID: 961
		private Ip_PaquetIp paquetArpEnCours;

		// Token: 0x040003C4 RID: 964
		private Ip_PaquetIp argPaquet;

		// Token: 0x040003C5 RID: 965
		private IpEtat argEtat;

		// Token: 0x040003C6 RID: 966
		private IpEtat etat = IpEtat.inactif;

		// Token: 0x040003C7 RID: 967
		private int hauteurTableRoutage = DialogueHashTable.Hauteur;

		// Token: 0x040003C8 RID: 968
		private int hauteurCacheArp = DialogueHashTable.Hauteur;

		// Token: 0x040003C9 RID: 969
		private int hauteurFichierHosts = DialogueHashTable.Hauteur;
	}
}
