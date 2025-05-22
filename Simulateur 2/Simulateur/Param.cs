using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using IAppliParam;

namespace Simulateur
{
	// Token: 0x0200006A RID: 106
	public partial class Param : Form
	{
		// Token: 0x06000603 RID: 1539 RVA: 0x0003D2F4 File Offset: 0x0003C2F4
		public Param(IAppliParam p_appli)
		{
			this.InitializeComponent();
			this.controlerTempsEmission();
			this.appli = p_appli;
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000606 RID: 1542 RVA: 0x00040860 File Offset: 0x0003F860
		public int numVersionDocumentsSimulateur
		{
			get
			{
				return 200;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000607 RID: 1543 RVA: 0x00040874 File Offset: 0x0003F874
		// (set) Token: 0x06000608 RID: 1544 RVA: 0x00040894 File Offset: 0x0003F894
		public int NbPortsHub
		{
			get
			{
				return (int)this.p_nbPortsHub.Valeur;
			}
			set
			{
				this.p_nbPortsHub.Valeur = value;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000609 RID: 1545 RVA: 0x000408B4 File Offset: 0x0003F8B4
		// (set) Token: 0x0600060A RID: 1546 RVA: 0x000408D4 File Offset: 0x0003F8D4
		public int NbPortsCascadeHub
		{
			get
			{
				return (int)this.p_nbPortsCascadeHub.Valeur;
			}
			set
			{
				this.p_nbPortsCascadeHub.Valeur = value;
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x0600060B RID: 1547 RVA: 0x000408F4 File Offset: 0x0003F8F4
		// (set) Token: 0x0600060C RID: 1548 RVA: 0x00040914 File Offset: 0x0003F914
		public int NbPortsSwitch
		{
			get
			{
				return (int)this.p_nbPortsSwitch.Valeur;
			}
			set
			{
				this.p_nbPortsSwitch.Valeur = value;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x0600060D RID: 1549 RVA: 0x00040934 File Offset: 0x0003F934
		// (set) Token: 0x0600060E RID: 1550 RVA: 0x00040954 File Offset: 0x0003F954
		public int NbPortsCascadeSwitch
		{
			get
			{
				return (int)this.p_nbPortsCascadeSwitch.Valeur;
			}
			set
			{
				this.p_nbPortsCascadeSwitch.Valeur = value;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600060F RID: 1551 RVA: 0x00040974 File Offset: 0x0003F974
		// (set) Token: 0x06000610 RID: 1552 RVA: 0x00040994 File Offset: 0x0003F994
		public int NbPorts8021qSwitch
		{
			get
			{
				return (int)this.p_nbPorts8021qSwitch.Valeur;
			}
			set
			{
				this.p_nbPorts8021qSwitch.Valeur = value;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000611 RID: 1553 RVA: 0x000409B4 File Offset: 0x0003F9B4
		// (set) Token: 0x06000612 RID: 1554 RVA: 0x000409D4 File Offset: 0x0003F9D4
		public int LongueurCableDefaut
		{
			get
			{
				return (int)this.p_longueurCableDefaut.Valeur;
			}
			set
			{
				this.p_longueurCableDefaut.Valeur = value;
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000613 RID: 1555 RVA: 0x000409F4 File Offset: 0x0003F9F4
		// (set) Token: 0x06000614 RID: 1556 RVA: 0x00040A14 File Offset: 0x0003FA14
		public int LongueurCableMax
		{
			get
			{
				return (int)this.p_longueurCableMax.Valeur;
			}
			set
			{
				this.p_longueurCableMax.Valeur = value;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000615 RID: 1557 RVA: 0x00040A34 File Offset: 0x0003FA34
		// (set) Token: 0x06000616 RID: 1558 RVA: 0x00040A4C File Offset: 0x0003FA4C
		public Pen NormalStylo
		{
			get
			{
				return this.p_normalStylo.Stylo;
			}
			set
			{
				this.p_normalStylo.Valeur = value.Color;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000617 RID: 1559 RVA: 0x00040A6C File Offset: 0x0003FA6C
		// (set) Token: 0x06000618 RID: 1560 RVA: 0x00040A84 File Offset: 0x0003FA84
		public Pen SelectionStylo
		{
			get
			{
				return this.p_selectionStylo.Stylo;
			}
			set
			{
				this.p_selectionStylo.Valeur = value.Color;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000619 RID: 1561 RVA: 0x00040AA4 File Offset: 0x0003FAA4
		// (set) Token: 0x0600061A RID: 1562 RVA: 0x00040ABC File Offset: 0x0003FABC
		public Color CouleurConnexionConception
		{
			get
			{
				return this.p_couleurConnexionConception.Valeur;
			}
			set
			{
				this.p_couleurConnexionConception.Valeur = value;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600061B RID: 1563 RVA: 0x00040AD8 File Offset: 0x0003FAD8
		// (set) Token: 0x0600061C RID: 1564 RVA: 0x00040AF0 File Offset: 0x0003FAF0
		public Color SurbrillancePointConnexion
		{
			get
			{
				return this.p_surbrillancePointConnexion.Valeur;
			}
			set
			{
				this.p_surbrillancePointConnexion.Valeur = value;
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x0600061D RID: 1565 RVA: 0x00040B0C File Offset: 0x0003FB0C
		// (set) Token: 0x0600061E RID: 1566 RVA: 0x00040B24 File Offset: 0x0003FB24
		public bool SpanningTree
		{
			get
			{
				return this.p_spanningTree.Valeur;
			}
			set
			{
				this.p_spanningTree.Valeur = value;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x0600061F RID: 1567 RVA: 0x00040B40 File Offset: 0x0003FB40
		// (set) Token: 0x06000620 RID: 1568 RVA: 0x00040B58 File Offset: 0x0003FB58
		public bool StoreAndForward
		{
			get
			{
				return this.p_storeAndForward.Valeur;
			}
			set
			{
				this.p_storeAndForward.Valeur = value;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000621 RID: 1569 RVA: 0x00040B74 File Offset: 0x0003FB74
		// (set) Token: 0x06000622 RID: 1570 RVA: 0x00040B94 File Offset: 0x0003FB94
		public int NiveauVlanSwitch
		{
			get
			{
				return (int)this.p_niveauVlanSwitch.Valeur;
			}
			set
			{
				this.p_niveauVlanSwitch.Valeur = value;
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000623 RID: 1571 RVA: 0x00040BB4 File Offset: 0x0003FBB4
		// (set) Token: 0x06000624 RID: 1572 RVA: 0x00040BCC File Offset: 0x0003FBCC
		public bool TraitsEpais
		{
			get
			{
				return this.p_traitsEpais.Valeur;
			}
			set
			{
				this.p_traitsEpais.Valeur = value;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000625 RID: 1573 RVA: 0x00040BE8 File Offset: 0x0003FBE8
		// (set) Token: 0x06000626 RID: 1574 RVA: 0x00040C00 File Offset: 0x0003FC00
		public bool MemoriserPosDemo
		{
			get
			{
				return this.p_memoriserPosition.Valeur;
			}
			set
			{
				this.p_memoriserPosition.Valeur = value;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000627 RID: 1575 RVA: 0x00040C1C File Offset: 0x0003FC1C
		// (set) Token: 0x06000628 RID: 1576 RVA: 0x00040C60 File Offset: 0x0003FC60
		public Pen Stylo8021q
		{
			get
			{
				if (this.TraitsEpais)
				{
					this.p_stylo8021q.EpaisseurStylo = this.epaisseurTraitEpais;
				}
				else
				{
					this.p_stylo8021q.EpaisseurStylo = 2f;
				}
				return this.p_stylo8021q.Stylo;
			}
			set
			{
				this.p_stylo8021q.Valeur = value.Color;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000629 RID: 1577 RVA: 0x00040C80 File Offset: 0x0003FC80
		// (set) Token: 0x0600062A RID: 1578 RVA: 0x00040CC4 File Offset: 0x0003FCC4
		public Pen StyloCollision
		{
			get
			{
				if (this.TraitsEpais)
				{
					this.p_styloCollision.EpaisseurStylo = this.epaisseurTraitEpais;
				}
				else
				{
					this.p_styloCollision.EpaisseurStylo = 2f;
				}
				return this.p_styloCollision.Stylo;
			}
			set
			{
				this.p_styloCollision.Valeur = value.Color;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600062B RID: 1579 RVA: 0x00040CE4 File Offset: 0x0003FCE4
		// (set) Token: 0x0600062C RID: 1580 RVA: 0x00040D28 File Offset: 0x0003FD28
		public Pen CableActifStylo1
		{
			get
			{
				if (this.TraitsEpais)
				{
					this.p_cableActifStylo1.EpaisseurStylo = this.epaisseurTraitEpais;
				}
				else
				{
					this.p_cableActifStylo1.EpaisseurStylo = 2f;
				}
				return this.p_cableActifStylo1.Stylo;
			}
			set
			{
				this.p_cableActifStylo1.Valeur = value.Color;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600062D RID: 1581 RVA: 0x00040D48 File Offset: 0x0003FD48
		// (set) Token: 0x0600062E RID: 1582 RVA: 0x00040D8C File Offset: 0x0003FD8C
		public Pen CableActifStylo2
		{
			get
			{
				if (this.TraitsEpais)
				{
					this.p_cableActifStylo2.EpaisseurStylo = this.epaisseurTraitEpais;
				}
				else
				{
					this.p_cableActifStylo2.EpaisseurStylo = 2f;
				}
				return this.p_cableActifStylo2.Stylo;
			}
			set
			{
				this.p_cableActifStylo2.Valeur = value.Color;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x0600062F RID: 1583 RVA: 0x00040DAC File Offset: 0x0003FDAC
		// (set) Token: 0x06000630 RID: 1584 RVA: 0x00040DC4 File Offset: 0x0003FDC4
		public Color CouleurAllumeEthernet
		{
			get
			{
				return this.p_couleurAllumeEthernet.Valeur;
			}
			set
			{
				this.p_couleurAllumeEthernet.Valeur = value;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000631 RID: 1585 RVA: 0x00040DE0 File Offset: 0x0003FDE0
		// (set) Token: 0x06000632 RID: 1586 RVA: 0x00040DF8 File Offset: 0x0003FDF8
		public Color CouleurActifEthernet
		{
			get
			{
				return this.p_couleurActifEthernet.Valeur;
			}
			set
			{
				this.p_couleurActifEthernet.Valeur = value;
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000633 RID: 1587 RVA: 0x00040E14 File Offset: 0x0003FE14
		// (set) Token: 0x06000634 RID: 1588 RVA: 0x00040E2C File Offset: 0x0003FE2C
		public Color CouleurErreurEthernet
		{
			get
			{
				return this.p_couleurErreurEthernet.Valeur;
			}
			set
			{
				this.p_couleurErreurEthernet.Valeur = value;
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000635 RID: 1589 RVA: 0x00040E48 File Offset: 0x0003FE48
		// (set) Token: 0x06000636 RID: 1590 RVA: 0x00040E60 File Offset: 0x0003FE60
		public Color CouleurBloqueEthernet
		{
			get
			{
				return this.p_couleurBloqueEthernet.Valeur;
			}
			set
			{
				this.p_couleurBloqueEthernet.Valeur = value;
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000637 RID: 1591 RVA: 0x00040E7C File Offset: 0x0003FE7C
		// (set) Token: 0x06000638 RID: 1592 RVA: 0x00040E94 File Offset: 0x0003FE94
		public bool TraceParDefaut
		{
			get
			{
				return this.p_traceParDefaut.Valeur;
			}
			set
			{
				this.p_traceParDefaut.Valeur = value;
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000639 RID: 1593 RVA: 0x00040EB0 File Offset: 0x0003FEB0
		// (set) Token: 0x0600063A RID: 1594 RVA: 0x00040EC8 File Offset: 0x0003FEC8
		public bool AnnonceStations
		{
			get
			{
				return this.p_annonceStations.Valeur;
			}
			set
			{
				this.p_annonceStations.Valeur = value;
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x0600063B RID: 1595 RVA: 0x00040EE4 File Offset: 0x0003FEE4
		// (set) Token: 0x0600063C RID: 1596 RVA: 0x00040F04 File Offset: 0x0003FF04
		public int TempsAttenteDemoDefaut
		{
			get
			{
				return (int)this.p_tempsAttenteDemoDefaut.Valeur;
			}
			set
			{
				this.p_tempsAttenteDemoDefaut.Valeur = value;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x0600063D RID: 1597 RVA: 0x00040F24 File Offset: 0x0003FF24
		// (set) Token: 0x0600063E RID: 1598 RVA: 0x00040F44 File Offset: 0x0003FF44
		public int TempsInterTrames
		{
			get
			{
				return (int)this.p_tempsInterTrames.Valeur;
			}
			set
			{
				this.p_tempsInterTrames.Valeur = value;
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x0600063F RID: 1599 RVA: 0x00040F64 File Offset: 0x0003FF64
		// (set) Token: 0x06000640 RID: 1600 RVA: 0x00040F84 File Offset: 0x0003FF84
		public int TauxRalenti
		{
			get
			{
				return (int)this.p_tauxRalenti.Valeur;
			}
			set
			{
				this.p_tauxRalenti.Valeur = value;
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000641 RID: 1601 RVA: 0x00040FA4 File Offset: 0x0003FFA4
		// (set) Token: 0x06000642 RID: 1602 RVA: 0x00040FC4 File Offset: 0x0003FFC4
		public double DelaiReemissionW
		{
			get
			{
				return (double)this.p_delaiReemissionW.Valeur;
			}
			set
			{
				this.p_delaiReemissionW.Valeur = (decimal)value;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000643 RID: 1603 RVA: 0x00040FE4 File Offset: 0x0003FFE4
		// (set) Token: 0x06000644 RID: 1604 RVA: 0x00041004 File Offset: 0x00040004
		public int DelaiReemissionX
		{
			get
			{
				return (int)this.p_delaiReemissionX.Valeur;
			}
			set
			{
				this.p_delaiReemissionX.Valeur = value;
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000645 RID: 1605 RVA: 0x00041024 File Offset: 0x00040024
		// (set) Token: 0x06000646 RID: 1606 RVA: 0x00041044 File Offset: 0x00040044
		public int DelaiReemissionY
		{
			get
			{
				return (int)this.p_delaiReemissionY.Valeur;
			}
			set
			{
				this.p_delaiReemissionY.Valeur = value;
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000647 RID: 1607 RVA: 0x00041064 File Offset: 0x00040064
		// (set) Token: 0x06000648 RID: 1608 RVA: 0x00041084 File Offset: 0x00040084
		public int DelaiReemissionZ
		{
			get
			{
				return (int)this.p_delaiReemissionZ.Valeur;
			}
			set
			{
				this.p_delaiReemissionZ.Valeur = value;
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000649 RID: 1609 RVA: 0x000410A4 File Offset: 0x000400A4
		// (set) Token: 0x0600064A RID: 1610 RVA: 0x000410C4 File Offset: 0x000400C4
		public int TempsAttenteEcoute
		{
			get
			{
				return (int)this.p_tempsAttenteEcoute.Valeur;
			}
			set
			{
				this.p_tempsAttenteEcoute.Valeur = value;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x0600064B RID: 1611 RVA: 0x000410E4 File Offset: 0x000400E4
		// (set) Token: 0x0600064C RID: 1612 RVA: 0x00041104 File Offset: 0x00040104
		public int TempsEmissionTrame
		{
			get
			{
				return (int)this.p_tempsEmissionTrame.Valeur;
			}
			set
			{
				this.p_tempsEmissionTrame.Valeur = value;
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600064D RID: 1613 RVA: 0x00041124 File Offset: 0x00040124
		// (set) Token: 0x0600064E RID: 1614 RVA: 0x00041144 File Offset: 0x00040144
		public double CoefEmissionTrameCourte
		{
			get
			{
				return (double)this.p_coefEmissionTrameCourte.Valeur;
			}
			set
			{
				this.p_coefEmissionTrameCourte.Valeur = (decimal)value;
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600064F RID: 1615 RVA: 0x00041164 File Offset: 0x00040164
		// (set) Token: 0x06000650 RID: 1616 RVA: 0x00041184 File Offset: 0x00040184
		public double CoefEmissionTrameLongue
		{
			get
			{
				return (double)this.p_coefEmissionTrameLongue.Valeur;
			}
			set
			{
				this.p_coefEmissionTrameLongue.Valeur = (decimal)value;
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000651 RID: 1617 RVA: 0x000411A4 File Offset: 0x000401A4
		// (set) Token: 0x06000652 RID: 1618 RVA: 0x000411C4 File Offset: 0x000401C4
		public int TempsDelaiTransmissionHub
		{
			get
			{
				return (int)this.p_tempsDelaiTransmissionHub.Valeur;
			}
			set
			{
				this.p_tempsDelaiTransmissionHub.Valeur = value;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000653 RID: 1619 RVA: 0x000411E4 File Offset: 0x000401E4
		// (set) Token: 0x06000654 RID: 1620 RVA: 0x00041204 File Offset: 0x00040204
		public int TempsDelaiTransmissionSwitch
		{
			get
			{
				return (int)this.p_tempsDelaiTransmissionSwitch.Valeur;
			}
			set
			{
				this.p_tempsDelaiTransmissionSwitch.Valeur = value;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000655 RID: 1621 RVA: 0x00041224 File Offset: 0x00040224
		// (set) Token: 0x06000656 RID: 1622 RVA: 0x00041244 File Offset: 0x00040244
		public float NbMetresParTick
		{
			get
			{
				return (float)this.p_nbMetresParTick.Valeur;
			}
			set
			{
				this.p_nbMetresParTick.Valeur = (decimal)value;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000657 RID: 1623 RVA: 0x00041264 File Offset: 0x00040264
		// (set) Token: 0x06000658 RID: 1624 RVA: 0x000412A8 File Offset: 0x000402A8
		public Pen StyloPaquet
		{
			get
			{
				if (this.TraitsEpais)
				{
					this.p_styloPaquet.EpaisseurStylo = 3f;
				}
				else
				{
					this.p_styloPaquet.EpaisseurStylo = 2f;
				}
				return this.p_styloPaquet.Stylo;
			}
			set
			{
				this.p_styloPaquet.Valeur = value.Color;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000659 RID: 1625 RVA: 0x000412C8 File Offset: 0x000402C8
		// (set) Token: 0x0600065A RID: 1626 RVA: 0x000412E8 File Offset: 0x000402E8
		public int LongueurRouteIp
		{
			get
			{
				return (int)this.p_longueurRoute.Valeur;
			}
			set
			{
				this.p_longueurRoute.Valeur = value;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600065B RID: 1627 RVA: 0x00041308 File Offset: 0x00040308
		// (set) Token: 0x0600065C RID: 1628 RVA: 0x00041320 File Offset: 0x00040320
		public bool TrameModeIp
		{
			get
			{
				return this.p_trameModeIp.Valeur;
			}
			set
			{
				this.p_trameModeIp.Valeur = value;
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x0600065D RID: 1629 RVA: 0x0004133C File Offset: 0x0004033C
		public bool CablesVirtuelIp
		{
			get
			{
				return this.p_cheminPaquet.Valeur == "IP";
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x0600065E RID: 1630 RVA: 0x00041360 File Offset: 0x00040360
		// (set) Token: 0x0600065F RID: 1631 RVA: 0x00041378 File Offset: 0x00040378
		public bool DemosInternet
		{
			get
			{
				return this.p_demoInternet.Valeur;
			}
			set
			{
				this.p_demoInternet.Valeur = value;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000660 RID: 1632 RVA: 0x00041394 File Offset: 0x00040394
		// (set) Token: 0x06000661 RID: 1633 RVA: 0x000413B4 File Offset: 0x000403B4
		public int TtlCacheArp
		{
			get
			{
				return (int)this.p_ttlCacheArp.Valeur;
			}
			set
			{
				this.p_ttlCacheArp.Valeur = value;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000662 RID: 1634 RVA: 0x000413D4 File Offset: 0x000403D4
		// (set) Token: 0x06000663 RID: 1635 RVA: 0x000413F4 File Offset: 0x000403F4
		public int AttentePing
		{
			get
			{
				return (int)this.p_attentePing.Valeur;
			}
			set
			{
				this.p_attentePing.Valeur = value;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x00041414 File Offset: 0x00040414
		// (set) Token: 0x06000665 RID: 1637 RVA: 0x00041434 File Offset: 0x00040434
		public int NbSautsMax
		{
			get
			{
				return (int)this.p_nbSautsMax.Valeur;
			}
			set
			{
				this.p_nbSautsMax.Valeur = value;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000666 RID: 1638 RVA: 0x00041454 File Offset: 0x00040454
		// (set) Token: 0x06000667 RID: 1639 RVA: 0x0004146C File Offset: 0x0004046C
		public bool CachesArpAutoIp
		{
			get
			{
				return this.p_cachesArpAutoIp.Valeur;
			}
			set
			{
				this.p_cachesArpAutoIp.Valeur = value;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000668 RID: 1640 RVA: 0x00041488 File Offset: 0x00040488
		// (set) Token: 0x06000669 RID: 1641 RVA: 0x000414A0 File Offset: 0x000404A0
		public bool Icones
		{
			get
			{
				return this.p_icones.Valeur;
			}
			set
			{
				this.p_icones.Valeur = value;
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600066A RID: 1642 RVA: 0x000414BC File Offset: 0x000404BC
		// (set) Token: 0x0600066B RID: 1643 RVA: 0x000414D4 File Offset: 0x000404D4
		public Pen StyloMessage
		{
			get
			{
				return this.p_styloPaquet.Stylo;
			}
			set
			{
				this.p_styloPaquet.Valeur = value.Color;
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x0600066C RID: 1644 RVA: 0x000414F4 File Offset: 0x000404F4
		public int LongueurCheminAppl
		{
			get
			{
				return 50;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x0600066D RID: 1645 RVA: 0x00041504 File Offset: 0x00040504
		public bool TrameModeAp
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x0600066E RID: 1646 RVA: 0x00041514 File Offset: 0x00040514
		public bool RouteModeAp
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x0600066F RID: 1647 RVA: 0x00041524 File Offset: 0x00040524
		public int DistanceConnecteursPaire
		{
			get
			{
				return this.distanceConnecteursPaire;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000670 RID: 1648 RVA: 0x00041538 File Offset: 0x00040538
		public Pen EpaisStylo
		{
			get
			{
				return this.epaisStylo;
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000671 RID: 1649 RVA: 0x0004154C File Offset: 0x0004054C
		public Pen TresEpaisStylo
		{
			get
			{
				return this.tresEpaisStylo;
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000672 RID: 1650 RVA: 0x00041560 File Offset: 0x00040560
		// (set) Token: 0x06000673 RID: 1651 RVA: 0x00041574 File Offset: 0x00040574
		public int NbTicksAttenteCercleCollision
		{
			get
			{
				return this.nbTicksAttenteCercleCollision;
			}
			set
			{
				this.nbTicksAttenteCercleCollision = value;
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000674 RID: 1652 RVA: 0x00041588 File Offset: 0x00040588
		// (set) Token: 0x06000675 RID: 1653 RVA: 0x0004159C File Offset: 0x0004059C
		public int DistanceCercleCollision
		{
			get
			{
				return this.distanceCercleCollision;
			}
			set
			{
				this.distanceCercleCollision = value;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000676 RID: 1654 RVA: 0x000415B0 File Offset: 0x000405B0
		// (set) Token: 0x06000677 RID: 1655 RVA: 0x000415C4 File Offset: 0x000405C4
		public int LimiteCercleCollision
		{
			get
			{
				return this.limiteCercleCollision;
			}
			set
			{
				this.limiteCercleCollision = value;
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000678 RID: 1656 RVA: 0x000415D8 File Offset: 0x000405D8
		// (set) Token: 0x06000679 RID: 1657 RVA: 0x000415F0 File Offset: 0x000405F0
		public Pen StyloCable
		{
			get
			{
				return this.p_normalStylo.Stylo;
			}
			set
			{
				this.p_normalStylo.Valeur = value.Color;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600067A RID: 1658 RVA: 0x00041610 File Offset: 0x00040610
		// (set) Token: 0x0600067B RID: 1659 RVA: 0x00041624 File Offset: 0x00040624
		public int HauteurOutils
		{
			get
			{
				return this.hauteurOutils;
			}
			set
			{
				this.hauteurOutils = value;
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600067C RID: 1660 RVA: 0x00041638 File Offset: 0x00040638
		// (set) Token: 0x0600067D RID: 1661 RVA: 0x0004164C File Offset: 0x0004064C
		public Font Police
		{
			get
			{
				return this.police;
			}
			set
			{
				this.police = value;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600067E RID: 1662 RVA: 0x00041660 File Offset: 0x00040660
		// (set) Token: 0x0600067F RID: 1663 RVA: 0x00041674 File Offset: 0x00040674
		public string AdrMacBroadcast
		{
			get
			{
				return this.adrMacBroadcast;
			}
			set
			{
				this.adrMacBroadcast = value;
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000680 RID: 1664 RVA: 0x00041688 File Offset: 0x00040688
		// (set) Token: 0x06000681 RID: 1665 RVA: 0x0004169C File Offset: 0x0004069C
		public int DelaiTickTraceLigne
		{
			get
			{
				return this.delaiTickTraceLigne;
			}
			set
			{
				this.delaiTickTraceLigne = value;
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000682 RID: 1666 RVA: 0x000416B0 File Offset: 0x000406B0
		// (set) Token: 0x06000683 RID: 1667 RVA: 0x000416C4 File Offset: 0x000406C4
		public bool MontrerTrame
		{
			get
			{
				return this.montrerTrame;
			}
			set
			{
				this.montrerTrame = value;
			}
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x000416D8 File Offset: 0x000406D8
		private void bt_fermer_Click(object sender, EventArgs e)
		{
			base.Hide();
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x000416EC File Offset: 0x000406EC
		public void bt_sauvegarder_Click(object sender, EventArgs e)
		{
			if (this.sd_enregistrer.ShowDialog() == DialogResult.OK)
			{
				try
				{
					this.tc_onglets.SauvegarderXml(this.sd_enregistrer.FileName);
				}
				catch
				{
					MessageBox.Show("Problème pendant la sauvegarde !");
				}
			}
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x0004174C File Offset: 0x0004074C
		public void bt_charger_Click(object sender, EventArgs e)
		{
			if (this.od_ouvrir.ShowDialog() == DialogResult.OK)
			{
				try
				{
					this.ChargerXml(this.od_ouvrir.FileName);
				}
				catch
				{
					MessageBox.Show("Fichier de paramètres incorrect !");
				}
			}
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x000417A4 File Offset: 0x000407A4
		private void bt_restaurerDefaut_Click(object sender, EventArgs e)
		{
			this.tc_onglets.RestaurerParamDefaut();
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x000417BC File Offset: 0x000407BC
		private void normalStyloChanged(object sender, EventArgs e)
		{
			this.epaisStylo.Color = this.p_normalStylo.Valeur;
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x000417E0 File Offset: 0x000407E0
		private void p_tempsDelaiTransmissionHubSwitch_ValueChanged(object sender, EventArgs e)
		{
			this.controlerTempsEmission();
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x000417F4 File Offset: 0x000407F4
		private void controlerTempsEmission()
		{
			this.p_tempsEmissionTrame.Minimum = 10m * Math.Max(this.p_tempsDelaiTransmissionHub.Valeur, this.p_tempsDelaiTransmissionSwitch.Valeur);
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x00041834 File Offset: 0x00040834
		private void longueurCableMaxChanged(object sender, EventArgs e)
		{
			this.p_longueurCableDefaut.Maximum = this.p_longueurCableMax.Valeur;
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x00041858 File Offset: 0x00040858
		public void ChargerXml(string nomFichier)
		{
			this.tc_onglets.ChargerXml(nomFichier);
			this.appli.PrendreEnCompteParams(false);
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x00041880 File Offset: 0x00040880
		public void RestaurerParamDefaut()
		{
			this.tc_onglets.RestaurerParamDefaut();
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x00041898 File Offset: 0x00040898
		private void p_delaiReemissionW_Leave(object sender, EventArgs e)
		{
			this.modifTextDelaiReemission();
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x000418AC File Offset: 0x000408AC
		private void modifTextDelaiReemission()
		{
			if (this.p_delaiReemissionW.Valeur == 0m)
			{
				this.lbl_delaiReemission.Text = "Délai réémission : nb d'essais * X * nb aléatoire(entre 1 et Y ) + Z";
				return;
			}
			this.lbl_delaiReemission.Text = "Délai réémission : n° trame * w * nb d'essais * X * nb aléatoire(entre 1 et Y ) + Z";
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x000418F4 File Offset: 0x000408F4
		private void p_delaiReemissionW_ValueChanged(object sender, EventArgs e)
		{
			this.modifTextDelaiReemission();
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x00041908 File Offset: 0x00040908
		private void p_montrerRouteAp_ValueChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0400044A RID: 1098
		private IAppliParam appli;

		// Token: 0x0400044B RID: 1099
		private float epaisseurTraitEpais = 2.7f;

		// Token: 0x0400044C RID: 1100
		private int distanceConnecteursPaire = 2;

		// Token: 0x0400044D RID: 1101
		private Pen epaisStylo = new Pen(Color.Black, 2f);

		// Token: 0x0400044E RID: 1102
		private Pen tresEpaisStylo = new Pen(Color.Black, 4f);

		// Token: 0x0400044F RID: 1103
		private int nbTicksAttenteCercleCollision = 20;

		// Token: 0x04000450 RID: 1104
		private int distanceCercleCollision = 8;

		// Token: 0x04000451 RID: 1105
		private int limiteCercleCollision = 32;

		// Token: 0x04000452 RID: 1106
		private int hauteurOutils = 40;

		// Token: 0x04000453 RID: 1107
		private Font police = new Font("Times New Roman", 8f);

		// Token: 0x04000454 RID: 1108
		private string adrMacBroadcast = "BCAST";

		// Token: 0x04000455 RID: 1109
		private int delaiTickTraceLigne = 30;

		// Token: 0x04000456 RID: 1110
		private bool montrerTrame = true;
	}
}
