using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000021 RID: 33
	public partial class DemoArp : DemoDialogue
	{
		// Token: 0x06000212 RID: 530 RVA: 0x000115A8 File Offset: 0x000105A8
		public DemoArp()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000213 RID: 531 RVA: 0x000115D4 File Offset: 0x000105D4
		private void MontrerTable(Control c, bool modifiable)
		{
			if (c.GetType() == typeof(CacheArpEdit))
			{
				if (modifiable)
				{
					base.Size = new Size(348, 164);
				}
				else
				{
					base.Size = new Size(328, 164);
				}
			}
			else if (c.Name == this.pn_paquetArp.Name)
			{
				base.Size = new Size(452, 168);
			}
			else if (c.Name == this.pn_paquetIp.Name)
			{
				base.Size = new Size(292, 144);
			}
			this.cacheArpEdit1.Visible = false;
			this.pn_paquetArp.Visible = false;
			this.pn_paquetIp.Visible = false;
			c.Visible = true;
			base.InScreen();
		}

		// Token: 0x06000214 RID: 532 RVA: 0x000116B4 File Offset: 0x000106B4
		private void cacherTable()
		{
			base.Size = new Size(228, 80);
			this.cacheArpEdit1.Visible = false;
			this.pn_paquetArp.Visible = false;
			this.pn_paquetIp.Visible = false;
			base.InScreen();
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00012254 File Offset: 0x00011254
		protected override void init()
		{
			this.cacheArpEdit1.init(((Station)this.carte.NoeudAttache).Ip, true);
			this.tb_resultat.Text = "";
			this.chercherSource();
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00012298 File Offset: 0x00011298
		private void chercherSource()
		{
			this.itemIpSource = this.cacheArpEdit1.IndexOf(Ip_quartet.FormatFixe(this.paquet.AdrSource));
			if (this.itemIpSource != -1)
			{
				this.macSource = CacheArpEdit.GetMac(this.cacheArpEdit1.GetTable(), this.paquet.AdrSource);
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000219 RID: 537 RVA: 0x000122F0 File Offset: 0x000112F0
		private CarteReseau carte
		{
			get
			{
				return (CarteReseau)this.elt;
			}
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00012308 File Offset: 0x00011308
		private void ajouterSource()
		{
			this.cacheArpEdit1.AjouterLigne(this.paquet.AdrSource, this.paquet.MacSource, this.carte.NumeroOrdre);
			this.cacheArpEdit1.Maj();
			this.chercherSource();
			this.cacheArpEdit1.selectIndex(this.itemIpSource);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00012364 File Offset: 0x00011364
		private string getLibellePhase(int numPhase)
		{
			if (numPhase == 1)
			{
				return "Couche ARP";
			}
			if (numPhase == 9)
			{
				return "Envoi du paquet IP en attente";
			}
			if (numPhase < 6)
			{
				return "Maj cache";
			}
			return "Réponse";
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00012398 File Offset: 0x00011398
		protected override void executerPhase()
		{
			this.cacherTable();
			base.LibellePhase = this.getLibellePhase(this.numPhaseSuivante);
			switch (this.numPhaseSuivante)
			{
			case 0:
				this.tb_resultat.Text = string.Concat(new object[]
				{
					this.paquet.MacSource,
					" (",
					this.paquet.AdrSource,
					")"
				});
				this.numPhaseSuivante = 2;
				return;
			case 1:
				if (this.paquet.Type == TypeDePaquetIp.ArpReply)
				{
					this.tb_resultat.Text = "ARP reply";
					this.numPhaseSuivante = 9;
					return;
				}
				this.tb_resultat.Text = "ARP request";
				this.numPhaseSuivante = 6;
				return;
			case 2:
				this.MontrerTable(this.cacheArpEdit1, false);
				if (this.itemIpSource == -1)
				{
					this.tb_resultat.Text = "IP source inconnue";
					this.numPhaseSuivante = 3;
					return;
				}
				this.cacheArpEdit1.selectIndex(this.itemIpSource);
				if (CacheArpEdit.GetType(this.cacheArpEdit1.GetTable(), this.paquet.AdrSource) == "Stat.")
				{
					this.tb_resultat.Text = "Entrée cache statique, ne rien faire";
					this.numPhaseSuivante = 1;
					return;
				}
				if (this.macSource != this.paquet.MacSource)
				{
					this.tb_resultat.Text = "MAC source erronée";
					this.numPhaseSuivante = 4;
					return;
				}
				this.tb_resultat.Text = "MAC source connue et correcte";
				this.numPhaseSuivante = 5;
				return;
			case 3:
				base.TablesModifiees = true;
				this.ajouterSource();
				this.MontrerTable(this.cacheArpEdit1, false);
				this.tb_resultat.Text = "IP source ajoutée";
				this.numPhaseSuivante = 1;
				return;
			case 4:
				base.TablesModifiees = true;
				this.ajouterSource();
				this.MontrerTable(this.cacheArpEdit1, false);
				this.tb_resultat.Text = "MAC source modifiée";
				this.numPhaseSuivante = 1;
				return;
			case 5:
				base.TablesModifiees = true;
				this.ajouterSource();
				this.MontrerTable(this.cacheArpEdit1, false);
				this.tb_resultat.Text = "TTL réinitialisé";
				this.numPhaseSuivante = 1;
				return;
			case 6:
				this.tb_resultat.Text = this.paquet.AdrDest.ToString();
				this.numPhaseSuivante = 7;
				return;
			case 7:
				this.tb_resultat.Text = this.carte.Ip.Adresse.ToString();
				this.numPhaseSuivante = 8;
				return;
			case 8:
				if (this.paquet.AdrDest.ToString() == this.carte.Ip.Adresse.ToString())
				{
					this.tb_resultat.Text = "Envoyer un ARP Reply";
				}
				else
				{
					this.tb_resultat.Text = "Ne pas répondre";
				}
				this.numPhaseSuivante = 11;
				return;
			case 9:
				this.tb_resultat.Text = ((Station)((CarteReseau)this.elt).NoeudAttache).Ip.TypePaquetEnCours + " vers " + this.paquet.MacSource;
				this.numPhaseSuivante = 11;
				return;
			default:
				return;
			}
		}

		// Token: 0x0600021D RID: 541 RVA: 0x000126C4 File Offset: 0x000116C4
		private void calculerResultatManuel()
		{
			this.tableOk = (SortedList)((Station)this.carte.NoeudAttache).Ip.CacheArp.Clone();
			this.cacheArpEdit1.AjouterLigneDynCache(this.tableOk, this.paquet.AdrSource, this.paquet.MacSource, this.carte.NumeroOrdre);
			if (this.paquet.Type == TypeDePaquetIp.ArpReply)
			{
				this.phasesAValider.Add(4);
				this.macDestPaquetIp = this.paquet.MacSource;
				return;
			}
			if (this.paquet.AdrDest.ToString() == this.carte.Ip.Adresse.ToString())
			{
				this.phasesAValider.Add(3);
				this.paquetArpOk = new Ip_PaquetIpDemoManuel(this.paquet.MacSource, this.carte.AdresseMac, -1, this.carte.Ip.Adresse.ToString(), this.paquet.AdrSource.ToString(), TypeDePaquetIp.ArpReply);
				return;
			}
			this.phasesAValider.Add(5);
		}

		// Token: 0x0600021E RID: 542 RVA: 0x000127F8 File Offset: 0x000117F8
		protected override void initManuel()
		{
			this.init();
			this.Text = string.Concat(new object[]
			{
				this.carte.AdresseMac,
				" : interface ",
				this.carte.NumeroOrdre,
				" (",
				this.carte.Ip.Adresse,
				")"
			});
			this.nbPhasesManuelles = 6;
			base.initManuel();
			this.cacheArpEdit1.ChangerMode(false);
			this.cacheArpEdit1.EntreesStatiques = false;
			this.cacherTable();
			this.cb_adrMacSource.Items.Clear();
			foreach (object obj in this.carte.NoeudAttache.Controls)
			{
				CarteReseau carteReseau = (CarteReseau)obj;
				this.cb_adrMacSource.Items.Add(carteReseau.AdresseMac);
			}
			this.tb_typePaquetIp.Text = ((Station)this.carte.NoeudAttache).Ip.TypePaquetEnCours;
			this.cb_action.Items.Clear();
			this.cb_action.Items.Add("Editer le cache ARP...");
			this.cb_action.Items.Add("Préparer un nouveau paquet ARP...");
			this.cb_action.Items.Add("Adresser le paquet IP en attente...");
			this.cb_action.Items.Add("Envoyer le paquet ARP préparé -->");
			this.cb_action.Items.Add("Envoyer le paquet IP en attente -->");
			this.cb_action.Items.Add("Ne pas répondre -->");
			this.calculerResultatManuel();
		}

		// Token: 0x0600021F RID: 543 RVA: 0x000129D8 File Offset: 0x000119D8
		protected override void executerPhaseManuelle(int numPhaseManuelle)
		{
			this.cacherTable();
			switch (numPhaseManuelle)
			{
			case 0:
				this.MontrerTable(this.cacheArpEdit1, true);
				this.messageManuelOk = "Mettez à jour le cache ARP...";
				this.okManuel = true;
				return;
			case 1:
				this.MontrerTable(this.pn_paquetArp, true);
				this.messageManuelOk = "Paramétrez le paquet ARP...";
				this.okManuel = true;
				return;
			case 2:
				this.MontrerTable(this.pn_paquetIp, true);
				this.messageManuelOk = "Indiquez MAC destinataire...";
				this.okManuel = true;
				return;
			case 3:
				if (this.phasesAValider.Contains(3))
				{
					if (HashTableEdit.Identiques(this.tableOk, this.cacheArpEdit1.GetTable()))
					{
						this.messageManuelErreur = "Paquet incorrect !";
						TypeDePaquetIp p_type;
						if (this.cb_typePaquet.SelectedIndex == -1)
						{
							p_type = TypeDePaquetIp.Aucun;
						}
						else
						{
							p_type = (TypeDePaquetIp)Enum.Parse(typeof(TypeDePaquetIp), this.cb_typePaquet.Items[this.cb_typePaquet.SelectedIndex].ToString());
						}
						int p_ttl = -1;
						string p_macSource;
						if (this.cb_adrMacSource.SelectedIndex == -1)
						{
							p_macSource = "";
						}
						else
						{
							p_macSource = this.cb_adrMacSource.Items[this.cb_adrMacSource.SelectedIndex].ToString();
						}
						this.paquetArpPropose = new Ip_PaquetIpDemoManuel(this.tb_adrMacDest.Text, p_macSource, p_ttl, this.tb_adrIpSource.Text, this.tb_adrIpDest.Text, p_type);
						this.okManuel = this.paquetArpPropose.Idem(this.paquetArpOk);
						return;
					}
					this.messageManuelErreur = "Cache ARP incorrect !";
					return;
				}
				break;
			case 4:
				if (this.phasesAValider.Contains(4))
				{
					if (!HashTableEdit.Identiques(this.tableOk, this.cacheArpEdit1.GetTable()))
					{
						this.messageManuelErreur = "Cache ARP incorrect !";
						return;
					}
					if (this.tb_adrMacDestPaquetIp.Text == this.macDestPaquetIp)
					{
						this.okManuel = true;
						return;
					}
					this.messageManuelErreur = "Adr MAC destinataire incorrecte !";
					return;
				}
				break;
			case 5:
				if (this.phasesAValider.Contains(5))
				{
					if (HashTableEdit.Identiques(this.tableOk, this.cacheArpEdit1.GetTable()))
					{
						this.okManuel = true;
						return;
					}
					this.messageManuelErreur = "Cache ARP incorrect !";
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00012C20 File Offset: 0x00011C20
		public DemoArp(Form f) : base(f)
		{
			this.InitializeComponent();
			base.Owner = f;
			this.actions = new ArrayList();
			this.actions.Add("Examiner source du paquet");
			this.actions.Add("Examiner type paquet ARP");
			this.actions.Add("Chercher IP source ds cache");
			this.actions.Add("Ajouter IP source ds cache");
			this.actions.Add("Modifier MAC ds cache");
			this.actions.Add("Réinitialiser TTL IP source");
			this.actions.Add("Examiner IP destination");
			this.actions.Add("Examiner mon adresse IP");
			this.actions.Add("Traiter la requête ARP");
			this.actions.Add("Adresser le paquet IP");
			this.actions.Add("Fin de la démonstration");
			base.initTables(null);
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00012D20 File Offset: 0x00011D20
		protected override ArrayList getTables()
		{
			SortedList sortedList = new SortedList();
			sortedList["itemIpSource"] = this.itemIpSource;
			return new ArrayList
			{
				sortedList.Clone(),
				this.cacheArpEdit1.GetTable().Clone()
			};
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00012D74 File Offset: 0x00011D74
		protected override void setTables(ArrayList p_tables)
		{
			SortedList sortedList = (SortedList)p_tables[0];
			this.itemIpSource = int.Parse(sortedList["itemIpSource"].ToString());
			this.cacheArpEdit1.SetTable((SortedList)((SortedList)p_tables[1]).Clone());
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00012DCC File Offset: 0x00011DCC
		private void cb_bcast_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cb_bcast.Checked)
			{
				this.tb_adrMacDest.Text = this.carte.Reseau.Pref.AdrMacBroadcast;
				return;
			}
			this.tb_adrMacDest.Text = "Clic sur la carte";
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00012E18 File Offset: 0x00011E18
		private void tb_adrMacDest_Enter(object sender, EventArgs e)
		{
			this.MacAttenteOn(this.tb_adrMacDest);
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00012E34 File Offset: 0x00011E34
		private void tb_adrMacDest_Leave(object sender, EventArgs e)
		{
			this.MacAttenteOff(this.tb_adrMacDest);
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00012E50 File Offset: 0x00011E50
		private void cb_bcastPaquetIp_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cb_bcastPaquetIp.Checked)
			{
				this.tb_adrMacDestPaquetIp.Text = this.carte.Reseau.Pref.AdrMacBroadcast;
				return;
			}
			this.tb_adrMacDestPaquetIp.Text = "Clic sur la carte";
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00012E9C File Offset: 0x00011E9C
		private void tb_adrMacDestPaquetIp_Enter(object sender, EventArgs e)
		{
			this.MacAttenteOn(this.tb_adrMacDestPaquetIp);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00012EB8 File Offset: 0x00011EB8
		private void tb_adrMacDestPaquetIp_Leave(object sender, EventArgs e)
		{
			this.MacAttenteOff(this.tb_adrMacDestPaquetIp);
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00012ED4 File Offset: 0x00011ED4
		public void MacAttenteOn(TextBox tb)
		{
			if (tb.Focused)
			{
				this.carte.Reseau.AdrMacAttente = tb;
			}
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00012EFC File Offset: 0x00011EFC
		public void MacAttenteOff(TextBox tb)
		{
			if (this.carte.Reseau.AdrMacAttente == tb)
			{
				this.carte.Reseau.AdrMacAttente = null;
			}
		}

		// Token: 0x0400012B RID: 299
		private int itemIpSource;

		// Token: 0x0400013F RID: 319
		private string macSource = "";

		// Token: 0x04000140 RID: 320
		private SortedList tableOk;

		// Token: 0x04000141 RID: 321
		private Ip_PaquetIpDemoManuel paquetArpOk;

		// Token: 0x04000142 RID: 322
		private Ip_PaquetIpDemoManuel paquetArpPropose;

		// Token: 0x04000143 RID: 323
		private string macDestPaquetIp;
	}
}
