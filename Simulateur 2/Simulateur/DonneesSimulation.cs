using System;
using System.Collections;
using System.IO;

namespace Simulateur
{
	// Token: 0x02000039 RID: 57
	public class DonneesSimulation
	{
		// Token: 0x06000343 RID: 835 RVA: 0x00027694 File Offset: 0x00026694
		public void initDelaisReemission()
		{
			this.delaisReemission = new ArrayList();
			this.delaisReemission.Add(2);
			this.delaisReemission.Add(1);
		}

		// Token: 0x06000344 RID: 836 RVA: 0x000276D0 File Offset: 0x000266D0
		public void ResetDelaisReemission()
		{
			this.delaisReemission[0] = 2;
		}

		// Token: 0x06000345 RID: 837 RVA: 0x000276F0 File Offset: 0x000266F0
		public void AjouterDelaiReemission(int delai)
		{
			this.delaisReemission.Add(delai);
			this.delaisReemission[1] = (int)this.delaisReemission[1] + 1;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00027734 File Offset: 0x00026734
		public bool GetDelaiReemission(ref int res)
		{
			bool result;
			if ((int)this.delaisReemission[0] > (int)this.delaisReemission[1])
			{
				result = false;
			}
			else
			{
				result = true;
				res = (int)this.delaisReemission[(int)this.delaisReemission[0]];
			}
			this.delaisReemission[0] = (int)this.delaisReemission[0] + 1;
			return result;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x000277B8 File Offset: 0x000267B8
		public void InitTablesSwitch()
		{
			this.tablesMacPortSwitch = new Hashtable();
			this.tablesPortVlanSwitch = new Hashtable();
			this.tablesMacVlanSwitch = new Hashtable();
			foreach (object obj in this.reseau.Schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Switch))
				{
					this.tablesMacPortSwitch.Add(((Switch)elementReseau).NomNoeud, new SortedList());
					foreach (object obj2 in ((Switch)elementReseau).PortAdresseMac.Values)
					{
						ArrayList arrayList = (ArrayList)obj2;
						((SortedList)this.tablesMacPortSwitch[((Switch)elementReseau).NomNoeud]).Add(arrayList[0], arrayList.Clone());
					}
					this.tablesPortVlanSwitch.Add(((Switch)elementReseau).NomNoeud, new SortedList());
					foreach (object obj3 in ((Switch)elementReseau).PortVlanNiv1.Values)
					{
						ArrayList arrayList2 = (ArrayList)obj3;
						((SortedList)this.tablesPortVlanSwitch[((Switch)elementReseau).NomNoeud]).Add(arrayList2[0], arrayList2.Clone());
					}
					this.tablesMacVlanSwitch.Add(((Switch)elementReseau).NomNoeud, new SortedList());
					foreach (object obj4 in ((Switch)elementReseau).MacVlanNiv2.Values)
					{
						ArrayList arrayList3 = (ArrayList)obj4;
						((SortedList)this.tablesMacVlanSwitch[((Switch)elementReseau).NomNoeud]).Add(arrayList3[0], arrayList3.Clone());
					}
				}
			}
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00027A58 File Offset: 0x00026A58
		public void RelireTablesSwitch()
		{
			foreach (object obj in this.reseau.Schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Switch))
				{
					((Switch)elementReseau).PortAdresseMac = new SortedList();
					foreach (object obj2 in ((SortedList)this.tablesMacPortSwitch[((Switch)elementReseau).NomNoeud]).Values)
					{
						ArrayList arrayList = (ArrayList)obj2;
						((Switch)elementReseau).PortAdresseMac.Add(arrayList[0], arrayList.Clone());
					}
					((Switch)elementReseau).PortVlanNiv1 = new SortedList();
					foreach (object obj3 in ((SortedList)this.tablesPortVlanSwitch[((Switch)elementReseau).NomNoeud]).Values)
					{
						ArrayList arrayList2 = (ArrayList)obj3;
						((Switch)elementReseau).PortVlanNiv1.Add(arrayList2[0], arrayList2.Clone());
					}
					((Switch)elementReseau).MacVlanNiv2 = new SortedList();
					foreach (object obj4 in ((SortedList)this.tablesMacVlanSwitch[((Switch)elementReseau).NomNoeud]).Values)
					{
						ArrayList arrayList3 = (ArrayList)obj4;
						((Switch)elementReseau).MacVlanNiv2.Add(arrayList3[0], arrayList3.Clone());
					}
				}
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000349 RID: 841 RVA: 0x00027CB4 File Offset: 0x00026CB4
		public DonneesTrame[] Trames
		{
			get
			{
				return this.trames;
			}
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00027CC8 File Offset: 0x00026CC8
		public DonneesSimulation(Simulation p_reseau)
		{
			this.reseau = p_reseau;
			this.deuxEmissions = false;
			this.trames = new DonneesTrame[2];
			this.trames[0] = new DonneesTrame();
			this.trames[1] = new DonneesTrame();
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600034B RID: 843 RVA: 0x00027D20 File Offset: 0x00026D20
		// (set) Token: 0x0600034C RID: 844 RVA: 0x00027D34 File Offset: 0x00026D34
		public int PremiereTrame
		{
			get
			{
				return this.premiereTrame;
			}
			set
			{
				this.premiereTrame = value - 1;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600034D RID: 845 RVA: 0x00027D4C File Offset: 0x00026D4C
		public int SecondeTrame
		{
			get
			{
				if (this.premiereTrame != 0)
				{
					return 0;
				}
				return 1;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600034E RID: 846 RVA: 0x00027D64 File Offset: 0x00026D64
		// (set) Token: 0x0600034F RID: 847 RVA: 0x00027D78 File Offset: 0x00026D78
		public CarteReseau PremiereCarte
		{
			get
			{
				return this.premiereCarte;
			}
			set
			{
				this.premiereCarte = value;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000350 RID: 848 RVA: 0x00027D8C File Offset: 0x00026D8C
		// (set) Token: 0x06000351 RID: 849 RVA: 0x00027DA0 File Offset: 0x00026DA0
		public CarteReseau SecondeCarte
		{
			get
			{
				return this.secondeCarte;
			}
			set
			{
				this.secondeCarte = value;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000352 RID: 850 RVA: 0x00027DB4 File Offset: 0x00026DB4
		// (set) Token: 0x06000353 RID: 851 RVA: 0x00027DC8 File Offset: 0x00026DC8
		public bool DeuxEmissions
		{
			get
			{
				return this.deuxEmissions;
			}
			set
			{
				this.deuxEmissions = value;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000354 RID: 852 RVA: 0x00027DDC File Offset: 0x00026DDC
		// (set) Token: 0x06000355 RID: 853 RVA: 0x00027DF0 File Offset: 0x00026DF0
		public bool DeuxTramesEmises
		{
			get
			{
				return this.deuxTramesEmises;
			}
			set
			{
				this.deuxTramesEmises = value;
			}
		}

		// Token: 0x06000356 RID: 854 RVA: 0x00027E04 File Offset: 0x00026E04
		public void Sauvegarder()
		{
			string text = this.reseau.GereDoc.DocumentCourant;
			if (text == null)
			{
				text = "nonEnregistre.xml";
			}
			text += ".log";
			StreamWriter streamWriter = new StreamWriter(text, false);
			streamWriter.WriteLine(this.reseau.TypeDemo.ToString());
			streamWriter.WriteLine(this.reseau.SimulationEthernet.ToString());
			streamWriter.WriteLine(this.reseau.FullDuplex.ToString());
			streamWriter.WriteLine(this.reseau.CoefVitesseDemo.ToString());
			streamWriter.WriteLine(this.reseau.MessageReception.ToString());
			streamWriter.WriteLine(this.reseau.DemoEmission.ToString());
			streamWriter.WriteLine(this.reseau.NoeudsNonDemo.Count.ToString());
			foreach (object obj in this.reseau.NoeudsNonDemo.Values)
			{
				Noeud noeud = (Noeud)obj;
				streamWriter.WriteLine(noeud.NomNoeud);
			}
			streamWriter.WriteLine(this.delaisReemission.Count.ToString());
			foreach (object obj2 in this.delaisReemission)
			{
				int num = (int)obj2;
				streamWriter.WriteLine(num.ToString());
			}
			streamWriter.WriteLine(this.premiereTrame.ToString());
			streamWriter.WriteLine(this.deuxEmissions.ToString());
			streamWriter.WriteLine(this.deuxTramesEmises.ToString());
			streamWriter.WriteLine(this.premiereCarte.AdresseMac);
			if (this.deuxEmissions)
			{
				streamWriter.WriteLine(this.secondeCarte.AdresseMac);
			}
			for (int i = 0; i < 2; i++)
			{
				streamWriter.WriteLine(this.trames[i].NumeroTrame.ToString());
				streamWriter.WriteLine(this.trames[i].TailleTrame.ToString());
				if (this.trames[i].Emetteur == null)
				{
					streamWriter.WriteLine("null");
				}
				else
				{
					streamWriter.WriteLine(this.trames[i].Emetteur.AdresseMac);
				}
				if (this.trames[i].AdrDestinataire == null)
				{
					streamWriter.WriteLine("null");
				}
				else
				{
					streamWriter.WriteLine(this.trames[i].AdrDestinataire);
				}
				streamWriter.WriteLine(this.trames[i].Envoyee.ToString());
			}
			if (this.deuxTramesEmises)
			{
				streamWriter.WriteLine(((int)(this.trames[this.SecondeTrame].MomentEmission - this.trames[this.PremiereTrame].MomentEmission).TotalMilliseconds).ToString());
			}
			streamWriter.WriteLine(this.tablesMacPortSwitch.Count.ToString());
			foreach (object obj3 in this.tablesMacPortSwitch.Keys)
			{
				string text2 = (string)obj3;
				streamWriter.WriteLine(text2);
				streamWriter.WriteLine(((SortedList)this.tablesMacPortSwitch[text2]).Count.ToString());
				foreach (object obj4 in ((SortedList)this.tablesMacPortSwitch[text2]).Values)
				{
					ArrayList arrayList = (ArrayList)obj4;
					streamWriter.WriteLine(arrayList[0]);
					streamWriter.WriteLine(arrayList[1]);
					streamWriter.WriteLine(arrayList[2]);
				}
			}
			streamWriter.WriteLine(this.tablesPortVlanSwitch.Count.ToString());
			foreach (object obj5 in this.tablesPortVlanSwitch.Keys)
			{
				string text3 = (string)obj5;
				streamWriter.WriteLine(text3);
				streamWriter.WriteLine(((SortedList)this.tablesPortVlanSwitch[text3]).Count.ToString());
				foreach (object obj6 in ((SortedList)this.tablesPortVlanSwitch[text3]).Values)
				{
					ArrayList arrayList2 = (ArrayList)obj6;
					streamWriter.WriteLine(arrayList2[0]);
					streamWriter.WriteLine(arrayList2[1]);
				}
			}
			streamWriter.WriteLine(this.tablesMacVlanSwitch.Count.ToString());
			foreach (object obj7 in this.tablesMacVlanSwitch.Keys)
			{
				string text4 = (string)obj7;
				streamWriter.WriteLine(text4);
				streamWriter.WriteLine(((SortedList)this.tablesMacVlanSwitch[text4]).Count.ToString());
				foreach (object obj8 in ((SortedList)this.tablesMacVlanSwitch[text4]).Values)
				{
					ArrayList arrayList3 = (ArrayList)obj8;
					streamWriter.WriteLine(arrayList3[0]);
					streamWriter.WriteLine(arrayList3[1]);
				}
			}
			streamWriter.Close();
		}

		// Token: 0x06000357 RID: 855 RVA: 0x000284F4 File Offset: 0x000274F4
		public void ChargerDebugBis()
		{
			StreamReader streamReader = new StreamReader(this.reseau.GereDoc.DocumentCourant + ".log");
			this.reseau.SetTypeDemo((Simulation.TypeDeDemo)Enum.Parse(typeof(Simulation.TypeDeDemo), streamReader.ReadLine()), (Simulation.TypeDeSimulationEthernet)Enum.Parse(typeof(Simulation.TypeDeSimulationEthernet), streamReader.ReadLine()));
			this.reseau.FullDuplex = bool.Parse(streamReader.ReadLine());
			this.reseau.CoefVitesseDemo = float.Parse(streamReader.ReadLine());
			this.reseau.MessageReception = bool.Parse(streamReader.ReadLine());
			this.reseau.DemoEmission = bool.Parse(streamReader.ReadLine());
			this.reseau.NoeudsNonDemo.Clear();
			this.reseau.NoeudsDemo.Clear();
			int num = int.Parse(streamReader.ReadLine());
			for (int i = 0; i < num; i++)
			{
				string key = streamReader.ReadLine();
				Noeud value = (Noeud)this.reseau.Noeuds[key];
				this.reseau.NoeudsNonDemo.Add(key, value);
			}
			this.reseau.setLibelleBt_noeudsDemo();
			int num2 = int.Parse(streamReader.ReadLine());
			this.delaisReemission = new ArrayList();
			for (int j = 0; j < num2; j++)
			{
				this.delaisReemission.Add(int.Parse(streamReader.ReadLine()));
			}
			this.premiereTrame = int.Parse(streamReader.ReadLine());
			this.deuxEmissions = bool.Parse(streamReader.ReadLine());
			this.deuxTramesEmises = bool.Parse(streamReader.ReadLine());
			string text = streamReader.ReadLine();
			this.premiereCarte = this.trouverCarte(text);
			if (this.deuxEmissions)
			{
				text = streamReader.ReadLine();
				this.secondeCarte = this.trouverCarte(text);
			}
			for (int k = 0; k < 2; k++)
			{
				this.trames[k].NumeroTrame = int.Parse(streamReader.ReadLine());
				this.trames[k].TailleTrame = int.Parse(streamReader.ReadLine());
				text = streamReader.ReadLine();
				if (text == "null")
				{
					this.trames[k].Emetteur = null;
				}
				else
				{
					this.trames[k].Emetteur = this.trouverCarte(text);
				}
				text = streamReader.ReadLine();
				if (text == "null")
				{
					this.trames[k].AdrDestinataire = null;
				}
				else
				{
					this.trames[k].AdrDestinataire = text;
				}
				this.trames[k].Envoyee = bool.Parse(streamReader.ReadLine());
			}
			if (this.deuxTramesEmises)
			{
				int num3 = int.Parse(streamReader.ReadLine());
				this.trames[this.PremiereTrame].MomentEmission = DateTime.Now;
				this.trames[this.SecondeTrame].MomentEmission = this.trames[this.PremiereTrame].MomentEmission.AddMilliseconds((double)num3);
			}
			else
			{
				this.trames[this.PremiereTrame].MomentEmission = DateTime.Now;
			}
			this.tablesMacPortSwitch = new Hashtable();
			int num4 = int.Parse(streamReader.ReadLine());
			for (int l = 0; l < num4; l++)
			{
				string text2 = streamReader.ReadLine();
				this.tablesMacPortSwitch.Add(text2, new SortedList());
				int num5 = int.Parse(streamReader.ReadLine());
				for (int m = 0; m < num5; m++)
				{
					ArrayList arrayList = new ArrayList();
					arrayList.Add(streamReader.ReadLine());
					int numeroPort = int.Parse(streamReader.ReadLine());
					arrayList.Add(this.trouverPortSwitch(text2, numeroPort));
					arrayList.Add((Switch.TtlSwitch)Enum.Parse(typeof(Switch.TtlSwitch), streamReader.ReadLine(), true));
					((SortedList)this.tablesMacPortSwitch[text2]).Add(arrayList[0], arrayList.Clone());
				}
			}
			this.tablesPortVlanSwitch = new Hashtable();
			int num6 = int.Parse(streamReader.ReadLine());
			for (int n = 0; n < num6; n++)
			{
				string text2 = streamReader.ReadLine();
				this.tablesPortVlanSwitch.Add(text2, new SortedList());
				int num5 = int.Parse(streamReader.ReadLine());
				for (int num7 = 0; num7 < num5; num7++)
				{
					ArrayList arrayList = new ArrayList();
					arrayList.Add(streamReader.ReadLine());
					arrayList.Add(streamReader.ReadLine());
					((SortedList)this.tablesPortVlanSwitch[text2]).Add(arrayList[0], arrayList.Clone());
				}
			}
			this.tablesMacVlanSwitch = new Hashtable();
			int num8 = int.Parse(streamReader.ReadLine());
			for (int num9 = 0; num9 < num8; num9++)
			{
				string text2 = streamReader.ReadLine();
				this.tablesMacVlanSwitch.Add(text2, new SortedList());
				int num5 = int.Parse(streamReader.ReadLine());
				for (int num10 = 0; num10 < num5; num10++)
				{
					ArrayList arrayList = new ArrayList();
					arrayList.Add(streamReader.ReadLine());
					arrayList.Add(streamReader.ReadLine());
					((SortedList)this.tablesMacVlanSwitch[text2]).Add(arrayList[0], arrayList.Clone());
				}
			}
			streamReader.Close();
			this.reseau.OkBis = true;
			this.reseau.PreparerBis();
		}

		// Token: 0x06000358 RID: 856 RVA: 0x00028A94 File Offset: 0x00027A94
		private PortSwitch trouverPortSwitch(string nomSwitch, int numeroPort)
		{
			foreach (object obj in this.reseau.Schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Switch) && ((Switch)elementReseau).NomNoeud == nomSwitch)
				{
					foreach (object obj2 in ((Switch)elementReseau).Controls)
					{
						PointConnexion pointConnexion = (PointConnexion)obj2;
						if (((PortSwitch)pointConnexion).NumeroOrdre == numeroPort)
						{
							return (PortSwitch)pointConnexion;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x00028BA0 File Offset: 0x00027BA0
		private CarteReseau trouverCarte(string adrMac)
		{
			foreach (object obj in this.reseau.Schema.Controls)
			{
				ElementReseau elementReseau = (ElementReseau)obj;
				if (elementReseau.GetType() == typeof(Station))
				{
					foreach (object obj2 in ((Station)elementReseau).Controls)
					{
						PointConnexion pointConnexion = (PointConnexion)obj2;
						if (((CarteReseau)pointConnexion).AdresseMac == adrMac)
						{
							return (CarteReseau)pointConnexion;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x040002AD RID: 685
		private ArrayList delaisReemission;

		// Token: 0x040002AE RID: 686
		private Hashtable tablesMacPortSwitch;

		// Token: 0x040002AF RID: 687
		private Hashtable tablesPortVlanSwitch;

		// Token: 0x040002B0 RID: 688
		private Hashtable tablesMacVlanSwitch;

		// Token: 0x040002B1 RID: 689
		private DonneesTrame[] trames;

		// Token: 0x040002B2 RID: 690
		private Simulation reseau;

		// Token: 0x040002B3 RID: 691
		private int premiereTrame;

		// Token: 0x040002B4 RID: 692
		private CarteReseau premiereCarte;

		// Token: 0x040002B5 RID: 693
		private CarteReseau secondeCarte;

		// Token: 0x040002B6 RID: 694
		private bool deuxEmissions = false;

		// Token: 0x040002B7 RID: 695
		private bool deuxTramesEmises = false;
	}
}
