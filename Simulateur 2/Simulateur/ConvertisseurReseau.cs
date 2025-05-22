using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Simulateur
{
	// Token: 0x0200001B RID: 27
	public class ConvertisseurReseau
	{
		// Token: 0x060001BC RID: 444 RVA: 0x0000E884 File Offset: 0x0000D884
		public static void elementXmlSuivant(XmlTextReader reader, bool getValeur)
		{
			while (reader.Read() && reader.NodeType != XmlNodeType.Element)
			{
			}
			if (!reader.HasAttributes && getValeur)
			{
				reader.Read();
			}
		}

		// Token: 0x060001BD RID: 445 RVA: 0x0000E8B4 File Offset: 0x0000D8B4
		public static void Convertir(string nomFichier, int numVersionReseau, Simulation p_s)
		{
			ConvertisseurReseau.s = p_s;
			if (numVersionReseau != 100)
			{
				return;
			}
			ConvertisseurReseau.ChargerXmlVersion100(nomFichier);
			Internet.SetAdressesInternetDispo(ConvertisseurReseau.s);
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0000E8E0 File Offset: 0x0000D8E0
		private static void ChargerXmlVersion100(string nomFichier)
		{
			Hashtable hashtable = new Hashtable();
			SortedList sortedList = new SortedList();
			XmlTextReader xmlTextReader = new XmlTextReader(nomFichier);
			ConvertisseurReseau.elementXmlSuivant(xmlTextReader, false);
			if (xmlTextReader.LocalName != "simRes")
			{
				throw new Exception();
			}
			xmlTextReader.MoveToNextAttribute();
			if (xmlTextReader.LocalName != "version" || xmlTextReader.Value != "1.0")
			{
				throw new Exception();
			}
			xmlTextReader.MoveToNextAttribute();
			int num = int.Parse(xmlTextReader.Value);
			ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
			int nbHubs = int.Parse(xmlTextReader.Value);
			ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
			int nbswitchs = int.Parse(xmlTextReader.Value);
			ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
			int nbCartesReseau = int.Parse(xmlTextReader.Value);
			ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
			int nbStations = int.Parse(xmlTextReader.Value);
			ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
			int dernierIdNoeud = int.Parse(xmlTextReader.Value);
			for (int i = 1; i <= num; i++)
			{
				ConvertisseurReseau.elementXmlSuivant(xmlTextReader, false);
				string text;
				if ((text = xmlTextReader.LocalName) != null)
				{
					text = string.IsInterned(text);
					if (text != "station")
					{
						if (text != "hub")
						{
							if (text != "switch")
							{
								if (text != "cable")
								{
									if (text == "iconeMessage")
									{
										ConvertisseurReseau.s.Controls.Add(new Ap_Message());
									}
								}
								else
								{
									ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
									Cable.TypeCable type = (Cable.TypeCable)Enum.Parse(typeof(Cable.TypeCable), xmlTextReader.Value, false);
									ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
									int longueur = int.Parse(xmlTextReader.Value);
									PointConnexion pointConnexion;
									ConvertisseurReseau.chargerPointConnexionXmlVersion100(xmlTextReader, out pointConnexion);
									PointConnexion extremite;
									ConvertisseurReseau.chargerPointConnexionXmlVersion100(xmlTextReader, out extremite);
									ConvertisseurReseau.creerCableVersion100(pointConnexion);
									ConvertisseurReseau.s.TerminerCable(extremite);
									pointConnexion.Lien.Type = type;
									pointConnexion.Lien.Longueur = longueur;
								}
							}
							else
							{
								string nomNoeud;
								int idNoeud;
								int num2;
								Point point;
								ConvertisseurReseau.chargerNoeudXmlVersion100(xmlTextReader, out nomNoeud, out idNoeud, out num2, out point);
								ConvertisseurReseau.s.creerSwitch(ConvertisseurReseau.s, new MouseEventArgs(MouseButtons.Left, 1, point.X, point.Y, 0));
								Switch @switch = (Switch)ConvertisseurReseau.s.Schema.Controls[ConvertisseurReseau.s.Schema.Controls.Count - 1];
								@switch.Location = new Point(point.X, point.Y);
								@switch.Controls.Clear();
								@switch.NomNoeud = nomNoeud;
								@switch.IdNoeud = idNoeud;
								ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
								int nbPortsNormaux = int.Parse(xmlTextReader.Value);
								ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
								int nbCascade = int.Parse(xmlTextReader.Value);
								@switch.NbPointsConnexion = 0;
								ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
								@switch.SpanningTree = bool.Parse(xmlTextReader.Value);
								ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
								int nb8021q = int.Parse(xmlTextReader.Value);
								ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
								@switch.NiveauVlan = int.Parse(xmlTextReader.Value);
								@switch.InitialiserPorts(nbPortsNormaux, nbCascade, nb8021q);
								ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
								@switch.TypeSwitch = (Switch.TypeDeSwitch)Enum.Parse(typeof(Switch.TypeDeSwitch), xmlTextReader.Value, false);
								for (int j = 0; j < num2; j++)
								{
									ConvertisseurReseau.elementXmlSuivant(xmlTextReader, false);
									xmlTextReader.MoveToNextAttribute();
									ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
									int x = int.Parse(xmlTextReader.Value);
									ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
									int y = int.Parse(xmlTextReader.Value);
									((PortSwitch)@switch.Controls[j]).PosDemoEmission = new Point(x, y);
								}
								@switch.PortVlanNiv1 = new SortedList();
								HashTableEdit.ChargerTableXml(@switch.PortVlanNiv1, xmlTextReader);
								HashTableEdit.ChargerTableXml(@switch.MacVlanNiv2, xmlTextReader);
								hashtable.Add(@switch.NomNoeud, @switch);
								sortedList.Add(@switch.NomNoeud, @switch);
								@switch.SetContenuInfoBulle();
							}
						}
						else
						{
							string nomNoeud;
							int idNoeud;
							int num2;
							Point point;
							ConvertisseurReseau.chargerNoeudXmlVersion100(xmlTextReader, out nomNoeud, out idNoeud, out num2, out point);
							ConvertisseurReseau.s.creerHub(ConvertisseurReseau.s, new MouseEventArgs(MouseButtons.Left, 1, point.X, point.Y, 0));
							Hub hub = (Hub)ConvertisseurReseau.s.Schema.Controls[ConvertisseurReseau.s.Schema.Controls.Count - 1];
							hub.Location = new Point(point.X, point.Y);
							hub.Controls.Clear();
							hub.NomNoeud = nomNoeud;
							hub.IdNoeud = idNoeud;
							ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
							int nbPortsNormaux = int.Parse(xmlTextReader.Value);
							ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
							int nbCascade = int.Parse(xmlTextReader.Value);
							hub.NbPointsConnexion = 0;
							hub.InitialiserPorts(nbPortsNormaux, nbCascade, 0);
							hashtable.Add(hub.NomNoeud, hub);
							sortedList.Add(hub.NomNoeud, hub);
						}
					}
					else
					{
						string nomNoeud;
						int idNoeud;
						int num2;
						Point point;
						ConvertisseurReseau.chargerNoeudXmlVersion100(xmlTextReader, out nomNoeud, out idNoeud, out num2, out point);
						ConvertisseurReseau.s.creerStation(ConvertisseurReseau.s, new MouseEventArgs(MouseButtons.Left, 1, point.X, point.Y, 0));
						Station station = (Station)ConvertisseurReseau.s.Schema.Controls[ConvertisseurReseau.s.Schema.Controls.Count - 1];
						station.Location = new Point(point.X, point.Y);
						station.NomNoeud = nomNoeud;
						station.IdNoeud = idNoeud;
						ConvertisseurReseau.ipStationChargerXmlVersion100(xmlTextReader, station.Ip);
						CarteReseau carteReseau = (CarteReseau)station.Controls[0];
						ConvertisseurReseau.elementXmlSuivant(xmlTextReader, false);
						xmlTextReader.MoveToNextAttribute();
						carteReseau.AdresseMac = xmlTextReader.Value;
						ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
						int x = int.Parse(xmlTextReader.Value);
						ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
						int y = int.Parse(xmlTextReader.Value);
						carteReseau.PosDemoEmission = new Point(x, y);
						ConvertisseurReseau.ipCarteChargerXmlVersion100(xmlTextReader, carteReseau.Ip);
						for (int k = 1; k < num2; k++)
						{
							ConvertisseurReseau.elementXmlSuivant(xmlTextReader, false);
							xmlTextReader.MoveToNextAttribute();
							carteReseau = new CarteReseau(ConvertisseurReseau.s);
							station.AjouterPointConnexion(carteReseau);
							carteReseau.AdresseMac = xmlTextReader.Value;
							ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
							x = int.Parse(xmlTextReader.Value);
							ConvertisseurReseau.elementXmlSuivant(xmlTextReader, true);
							y = int.Parse(xmlTextReader.Value);
							carteReseau.PosDemoEmission = new Point(x, y);
							ConvertisseurReseau.ipCarteChargerXmlVersion100(xmlTextReader, carteReseau.Ip);
						}
						hashtable.Add(station.NomNoeud, station);
						sortedList.Add(station.NomNoeud, station);
					}
				}
			}
			ConvertisseurReseau.s.NbHubs = nbHubs;
			ConvertisseurReseau.s.NbCartesReseau = nbCartesReseau;
			ConvertisseurReseau.s.Nbswitchs = nbswitchs;
			ConvertisseurReseau.s.NbStations = nbStations;
			ConvertisseurReseau.s.DernierIdNoeud = dernierIdNoeud;
			ConvertisseurReseau.s.Noeuds = hashtable;
			ConvertisseurReseau.s.NoeudsNonDemo = sortedList;
			foreach (object obj in ConvertisseurReseau.s.Noeuds.Values)
			{
				Noeud noeud = (Noeud)obj;
				if (noeud.NomNoeud == "Internet")
				{
					int num3 = 0;
					do
					{
						Noeud noeud2 = noeud;
						string str = "Internet";
						int num4;
						num3 = (num4 = num3 + 1);
						noeud2.NomNoeud = str + num4.ToString();
					}
					while (ConvertisseurReseau.s.Noeuds.Contains(noeud.NomNoeud));
				}
			}
			xmlTextReader.Close();
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0000F100 File Offset: 0x0000E100
		private static void chargerNoeudXmlVersion100(XmlTextReader reader, out string p_nom, out int p_id, out int p_nbPtsConn, out Point p_pos)
		{
			reader.MoveToNextAttribute();
			p_nom = reader.Value;
			ConvertisseurReseau.elementXmlSuivant(reader, true);
			p_id = int.Parse(reader.Value);
			ConvertisseurReseau.elementXmlSuivant(reader, true);
			p_nbPtsConn = int.Parse(reader.Value);
			ConvertisseurReseau.elementXmlSuivant(reader, true);
			int x = int.Parse(reader.Value);
			ConvertisseurReseau.elementXmlSuivant(reader, true);
			int y = int.Parse(reader.Value);
			p_pos = new Point(x, y);
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x0000F174 File Offset: 0x0000E174
		private static void ipStationChargerXmlVersion100(XmlTextReader reader, Ip_station ip)
		{
			Simulation.elementXmlSuivant(reader, true);
			Simulation.elementXmlSuivant(reader, true);
			ip.Passerelle = new Ip_adresse(reader.Value);
			Simulation.elementXmlSuivant(reader, true);
			ip.RoutageActif = bool.Parse(reader.Value);
			Simulation.elementXmlSuivant(reader, true);
			ip.ServeurDns = new Ip_adresse(reader.Value);
			HashTableEdit.ChargerTableXml(ip.Routes, reader);
			HashTableEdit.ChargerTableXml(ip.CacheArp, reader);
			HashTableEdit.ChargerTableXml(ip.FichierHosts, reader);
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0000F1F4 File Offset: 0x0000E1F4
		private static void ipCarteChargerXmlVersion100(XmlTextReader reader, Ip_carte ipc)
		{
			Simulation.elementXmlSuivant(reader, true);
			Simulation.elementXmlSuivant(reader, true);
			ipc.Dhcp = bool.Parse(reader.Value);
			Simulation.elementXmlSuivant(reader, true);
			ipc.Adresse = new Ip_adresse(reader.Value);
			Simulation.elementXmlSuivant(reader, true);
			ipc.Masque = new Ip_masque(reader.Value);
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0000F250 File Offset: 0x0000E250
		private static void chargerPointConnexionXmlVersion100(XmlTextReader reader, out PointConnexion pt)
		{
			pt = new PointConnexion();
			ConvertisseurReseau.elementXmlSuivant(reader, true);
			int num = int.Parse(reader.Value);
			ConvertisseurReseau.elementXmlSuivant(reader, true);
			int num2 = int.Parse(reader.Value);
			bool flag = false;
			int num3 = 1;
			while (!flag)
			{
				Noeud noeud = (Noeud)ConvertisseurReseau.s.Schema.Controls[num3];
				if (noeud.IdNoeud == num)
				{
					flag = true;
					pt = (PointConnexion)noeud.Controls[num2 - 1];
				}
				else
				{
					num3++;
				}
			}
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x0000F2D8 File Offset: 0x0000E2D8
		private static void creerCableVersion100(PointConnexion origine)
		{
			ConvertisseurReseau.s.NouveauCable = new Cable(ConvertisseurReseau.s);
			ConvertisseurReseau.s.NouveauCable.DebuterLiaison(origine);
			origine.Lien = ConvertisseurReseau.s.NouveauCable;
			origine.BackColor = ConvertisseurReseau.s.Pref.CouleurConnexionConception;
			ConvertisseurReseau.s.TraceNouveauCable = new CableEnCours(ConvertisseurReseau.s);
			ConvertisseurReseau.s.TraceNouveauCable.A = origine.Centre;
			ConvertisseurReseau.s.TraceNouveauCable.B = new Point(origine.Centre.X, origine.Centre.Y);
			ConvertisseurReseau.s.Schema.Controls.Add(ConvertisseurReseau.s.TraceNouveauCable);
		}

		// Token: 0x040000E3 RID: 227
		private static Simulation s;
	}
}
