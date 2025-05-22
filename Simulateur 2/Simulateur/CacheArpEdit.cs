using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200000D RID: 13
	public class CacheArpEdit : HashTableEdit
	{
		// Token: 0x060000DC RID: 220 RVA: 0x00007A28 File Offset: 0x00006A28
		public CacheArpEdit()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00007A50 File Offset: 0x00006A50
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00007A7C File Offset: 0x00006A7C
		private void InitializeComponent()
		{
			this.tb_adrIP = new TextBox();
			this.label3 = new Label();
			this.tb_type = new TextBox();
			this.tb_ttl = new TextBox();
			this.tb_adrMac = new TextBox();
			this.lbl_ttl = new Label();
			this.label2 = new Label();
			this.label1 = new Label();
			this.bt_reintialiserTtl = new Button();
			this.tb_interface = new TextBox();
			this.label4 = new Label();
			base.SuspendLayout();
			this.lb_valeurs.Name = "lb_valeurs";
			this.lb_valeurs.Size = new Size(316, 56);
			this.bthte_modifier.Location = new Point(320, 60);
			this.bthte_modifier.Name = "bthte_modifier";
			this.bthte_supprimer.Location = new Point(320, 40);
			this.bthte_supprimer.Name = "bthte_supprimer";
			this.bthte_ajouter.Location = new Point(320, 20);
			this.bthte_ajouter.Name = "bthte_ajouter";
			this.bthte_ajouter.Click += this.bthte_ajouter_Click;
			this.bthte_annuler.Location = new Point(320, 0);
			this.bthte_annuler.Name = "bthte_annuler";
			this.bthte_annulerSaisie.Name = "bthte_annulerSaisie";
			this.bthte_validerSaisie.Name = "bthte_validerSaisie";
			this.tb_adrIP.Location = new Point(0, 20);
			this.tb_adrIP.Name = "tb_adrIP";
			this.tb_adrIP.ReadOnly = true;
			this.tb_adrIP.Size = new Size(88, 20);
			this.tb_adrIP.TabIndex = 75;
			this.tb_adrIP.TabStop = false;
			this.tb_adrIP.Text = "";
			this.label3.Location = new Point(0, 4);
			this.label3.Name = "label3";
			this.label3.Size = new Size(60, 16);
			this.label3.TabIndex = 81;
			this.label3.Text = "Adresse IP";
			this.tb_type.Location = new Point(180, 20);
			this.tb_type.Name = "tb_type";
			this.tb_type.ReadOnly = true;
			this.tb_type.Size = new Size(44, 20);
			this.tb_type.TabIndex = 80;
			this.tb_type.TabStop = false;
			this.tb_type.Text = "";
			this.tb_ttl.Location = new Point(280, 20);
			this.tb_ttl.Name = "tb_ttl";
			this.tb_ttl.ReadOnly = true;
			this.tb_ttl.Size = new Size(32, 20);
			this.tb_ttl.TabIndex = 79;
			this.tb_ttl.TabStop = false;
			this.tb_ttl.Text = "";
			this.tb_adrMac.Location = new Point(92, 20);
			this.tb_adrMac.Name = "tb_adrMac";
			this.tb_adrMac.ReadOnly = true;
			this.tb_adrMac.Size = new Size(84, 20);
			this.tb_adrMac.TabIndex = 74;
			this.tb_adrMac.Text = "Clic sur la carte";
			this.tb_adrMac.TextChanged += this.tb_adrMac_TextChanged;
			this.tb_adrMac.Leave += this.tb_adrMac_Leave;
			this.tb_adrMac.Enter += this.tb_adrMac_Enter;
			this.lbl_ttl.Location = new Point(284, 4);
			this.lbl_ttl.Name = "lbl_ttl";
			this.lbl_ttl.Size = new Size(28, 16);
			this.lbl_ttl.TabIndex = 78;
			this.lbl_ttl.Text = "TTL";
			this.label2.Location = new Point(188, 4);
			this.label2.Name = "label2";
			this.label2.Size = new Size(36, 16);
			this.label2.TabIndex = 77;
			this.label2.Text = "Type";
			this.label1.Location = new Point(96, 4);
			this.label1.Name = "label1";
			this.label1.Size = new Size(76, 16);
			this.label1.TabIndex = 76;
			this.label1.Text = "Adresse MAC";
			this.bt_reintialiserTtl.Location = new Point(132, 56);
			this.bt_reintialiserTtl.Name = "bt_reintialiserTtl";
			this.bt_reintialiserTtl.Size = new Size(64, 20);
			this.bt_reintialiserTtl.TabIndex = 82;
			this.bt_reintialiserTtl.Text = "réinit. TTL";
			this.bt_reintialiserTtl.Click += this.bt_reintialiserTtl_Click;
			this.tb_interface.Location = new Point(228, 20);
			this.tb_interface.Name = "tb_interface";
			this.tb_interface.ReadOnly = true;
			this.tb_interface.Size = new Size(48, 20);
			this.tb_interface.TabIndex = 84;
			this.tb_interface.TabStop = false;
			this.tb_interface.Text = "";
			this.label4.Location = new Point(228, 4);
			this.label4.Name = "label4";
			this.label4.Size = new Size(48, 16);
			this.label4.TabIndex = 83;
			this.label4.Text = "Interface";
			base.Controls.Add(this.tb_interface);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.bt_reintialiserTtl);
			base.Controls.Add(this.tb_adrIP);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.tb_type);
			base.Controls.Add(this.tb_ttl);
			base.Controls.Add(this.tb_adrMac);
			base.Controls.Add(this.lbl_ttl);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Name = "CacheArpEdit";
			base.Size = new Size(336, 80);
			base.Controls.SetChildIndex(this.lb_valeurs, 0);
			base.Controls.SetChildIndex(this.bthte_modifier, 0);
			base.Controls.SetChildIndex(this.bthte_supprimer, 0);
			base.Controls.SetChildIndex(this.bthte_ajouter, 0);
			base.Controls.SetChildIndex(this.bthte_annuler, 0);
			base.Controls.SetChildIndex(this.bthte_validerSaisie, 0);
			base.Controls.SetChildIndex(this.bthte_annulerSaisie, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.lbl_ttl, 0);
			base.Controls.SetChildIndex(this.tb_adrMac, 0);
			base.Controls.SetChildIndex(this.tb_ttl, 0);
			base.Controls.SetChildIndex(this.tb_type, 0);
			base.Controls.SetChildIndex(this.label3, 0);
			base.Controls.SetChildIndex(this.tb_adrIP, 0);
			base.Controls.SetChildIndex(this.bt_reintialiserTtl, 0);
			base.Controls.SetChildIndex(this.label4, 0);
			base.Controls.SetChildIndex(this.tb_interface, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000082A4 File Offset: 0x000072A4
		public void init(Ip_station p_ip, bool lectureSeule)
		{
			this.ip = p_ip;
			base.init(this.ip.CacheArp, lectureSeule, true);
			this.ToListe();
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x000082D4 File Offset: 0x000072D4
		protected override string genererLigne(ArrayList ligne)
		{
			return string.Concat(new string[]
			{
				(string)ligne[0],
				"\t",
				(string)ligne[1],
				"\t\t",
				(string)ligne[2],
				"\t",
				ligne[3].ToString(),
				"\t",
				ligne[4].ToString()
			});
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000835C File Offset: 0x0000735C
		protected override void ToListe()
		{
			base.ToListe();
			this.tb_adrIP.Visible = false;
			this.tb_adrMac.Visible = false;
			this.tb_type.Visible = false;
			this.tb_ttl.Visible = false;
			this.lbl_ttl.Visible = true;
			this.tb_interface.Visible = false;
			this.bt_reintialiserTtl.Visible = false;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000083C4 File Offset: 0x000073C4
		protected override void ToSaisie()
		{
			base.ToSaisie();
			if (base.Modification && this.ligneEdit[2].ToString() != "Stat.")
			{
				this.lbl_ttl.Visible = true;
				this.tb_ttl.Visible = true;
				this.bt_reintialiserTtl.Visible = true;
			}
			else
			{
				this.bt_reintialiserTtl.Visible = false;
				this.lbl_ttl.Visible = false;
				this.tb_ttl.Visible = false;
			}
			this.tb_adrIP.Text = (string)this.ligneEdit[0];
			this.tb_adrMac.Text = (string)this.ligneEdit[1];
			this.tb_type.Text = this.ligneEdit[2].ToString();
			this.tb_interface.Text = this.ligneEdit[3].ToString();
			this.tb_ttl.Text = this.ligneEdit[4].ToString();
			this.tb_adrIP.Visible = true;
			this.tb_adrMac.Visible = true;
			this.tb_type.Visible = true;
			this.tb_interface.Visible = true;
			this.tb_adrMac.Focus();
		}

		// Token: 0x17000013 RID: 19
		// (set) Token: 0x060000E3 RID: 227 RVA: 0x00008510 File Offset: 0x00007510
		public bool EntreesStatiques
		{
			set
			{
				this.entreesStatiques = value;
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00008524 File Offset: 0x00007524
		protected override void renseignerNewLigne()
		{
			this.ligneEdit.Add("0.0.0.0");
			this.ligneEdit.Add("Clic sur la carte");
			if (this.entreesStatiques)
			{
				this.ligneEdit.Add("Stat.");
				this.ligneEdit.Add("");
				this.ligneEdit.Add("---");
				return;
			}
			this.ligneEdit.Add("Dyn.");
			this.ligneEdit.Add("");
			this.ligneEdit.Add(this.ip.St.Reseau.Pref.TtlCacheArp.ToString());
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000085E0 File Offset: 0x000075E0
		protected override void recupererLigne()
		{
			this.ligneEdit[0] = this.tb_adrIP.Text;
			this.ligneEdit[1] = this.tb_adrMac.Text;
			this.ligneEdit[2] = this.tb_type.Text;
			this.ligneEdit[3] = this.tb_interface.Text;
			this.ligneEdit[4] = this.tb_ttl.Text;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00008660 File Offset: 0x00007660
		private void bt_reintialiserTtl_Click(object sender, EventArgs e)
		{
			this.ligneEdit[4] = this.ip.St.Reseau.Pref.TtlCacheArp.ToString();
			this.tb_ttl.Text = this.ligneEdit[4].ToString();
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000086B8 File Offset: 0x000076B8
		private void tb_adrMac_Enter(object sender, EventArgs e)
		{
			this.MacAttenteOn();
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000086CC File Offset: 0x000076CC
		private void tb_adrMac_Leave(object sender, EventArgs e)
		{
			this.MacAttenteOff();
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000086E0 File Offset: 0x000076E0
		public void MacAttenteOn()
		{
			if (this.tb_adrMac.Focused)
			{
				this.ip.St.Reseau.AdrMacAttente = this.tb_adrMac;
			}
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00008718 File Offset: 0x00007718
		public void MacAttenteOff()
		{
			if (this.ip.St.Reseau.AdrMacAttente == this.tb_adrMac)
			{
				this.ip.St.Reseau.AdrMacAttente = null;
			}
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00008758 File Offset: 0x00007758
		protected override void bthte_ajouter_Click(object sender, EventArgs e)
		{
			base.bthte_ajouter_Click(sender, e);
			this.bthte_validerSaisie.Enabled = false;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000877C File Offset: 0x0000777C
		private void tb_adrMac_TextChanged(object sender, EventArgs e)
		{
			if (this.tb_adrMac.Text != "Clic sur la carte")
			{
				CarteReseau carteReseau = CarteReseau.TrouverCarte(this.tb_adrMac.Text, this.ip.St.Reseau);
				CarteReseau carteReseau2 = this.ip.TrouverCarteMemeReseau(carteReseau.Ip.Adresse);
				if (carteReseau2 != null && !Ip_quartet.IsNull(carteReseau2.Ip.Adresse) && this.ip.RouteIpOk(carteReseau2, carteReseau))
				{
					if (carteReseau.NoeudAttache == this.ip.St)
					{
						this.tb_adrMac.Text = "Clic sur la carte";
						this.tb_adrIP.Text = "";
						this.tb_interface.Text = "";
						MessageBox.Show("Carte située sur la station !");
					}
					else
					{
						this.tb_adrIP.Text = Ip_quartet.FormatFixe(carteReseau.Ip.Adresse);
						this.tb_interface.Text = carteReseau2.NumeroOrdre.ToString();
						this.bthte_validerSaisie.Enabled = true;
					}
				}
				else
				{
					this.tb_adrMac.Text = "Clic sur la carte";
					this.tb_adrIP.Text = "";
					this.tb_interface.Text = "";
					MessageBox.Show("Hôte de destination non joignable !");
				}
			}
			this.tb_adrMac.Focus();
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000088E4 File Offset: 0x000078E4
		public static void SupprimerDynamiques(SortedList cache)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in cache.Values)
			{
				ArrayList arrayList2 = (ArrayList)obj;
				if (arrayList2[2].ToString() == "Dyn.")
				{
					arrayList.Add(arrayList2[0]);
				}
			}
			foreach (object obj2 in arrayList)
			{
				string key = (string)obj2;
				cache.Remove(key);
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000089C4 File Offset: 0x000079C4
		public static string GetMac(SortedList cache, Ip_adresse ip)
		{
			string key = Ip_quartet.FormatFixe(ip);
			if (cache.ContainsKey(key))
			{
				return ((ArrayList)cache[key])[1].ToString();
			}
			return null;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000089FC File Offset: 0x000079FC
		public static string GetType(SortedList cache, Ip_adresse ip)
		{
			string key = Ip_quartet.FormatFixe(ip);
			if (cache.ContainsKey(key))
			{
				return ((ArrayList)cache[key])[2].ToString();
			}
			return null;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00008A34 File Offset: 0x00007A34
		public static void DecrementerTtls(SortedList cache)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in cache.Values)
			{
				ArrayList arrayList2 = (ArrayList)obj;
				if (arrayList2[2].ToString() == "Dyn.")
				{
					int num = int.Parse(arrayList2[4].ToString()) - 1;
					if (num == 0)
					{
						arrayList.Add(arrayList2[0]);
					}
					else
					{
						arrayList2[4] = num.ToString();
					}
				}
			}
			foreach (object obj2 in arrayList)
			{
				string key = (string)obj2;
				cache.Remove(key);
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00008B44 File Offset: 0x00007B44
		public void AjouterLigne(Ip_adresse adrIp, string mac, int numInterface)
		{
			string text = Ip_quartet.FormatFixe(adrIp);
			this.table[text] = new ArrayList();
			((ArrayList)this.table[text]).Add(text);
			((ArrayList)this.table[text]).Add(mac);
			((ArrayList)this.table[text]).Add("Dyn.");
			((ArrayList)this.table[text]).Add(numInterface.ToString());
			((ArrayList)this.table[text]).Add(this.ip.St.Reseau.Pref.TtlCacheArp.ToString());
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00008C0C File Offset: 0x00007C0C
		public void AjouterLigneDynCache(SortedList cache, Ip_adresse adrIp, string mac, int numInterface)
		{
			string text = Ip_quartet.FormatFixe(adrIp);
			bool flag = true;
			if (cache.ContainsKey(text) && ((ArrayList)cache[text])[2].ToString() == "Stat.")
			{
				flag = false;
			}
			if (flag)
			{
				cache[text] = new ArrayList();
				((ArrayList)cache[text]).Add(text);
				((ArrayList)cache[text]).Add(mac);
				((ArrayList)cache[text]).Add("Dyn.");
				((ArrayList)cache[text]).Add(numInterface.ToString());
				((ArrayList)cache[text]).Add(this.ip.St.Reseau.Pref.TtlCacheArp.ToString());
			}
		}

		// Token: 0x04000070 RID: 112
		private TextBox tb_adrIP;

		// Token: 0x04000071 RID: 113
		private Label label3;

		// Token: 0x04000072 RID: 114
		private TextBox tb_type;

		// Token: 0x04000073 RID: 115
		private TextBox tb_ttl;

		// Token: 0x04000074 RID: 116
		private TextBox tb_adrMac;

		// Token: 0x04000075 RID: 117
		private Label lbl_ttl;

		// Token: 0x04000076 RID: 118
		private Label label2;

		// Token: 0x04000077 RID: 119
		private Label label1;

		// Token: 0x04000078 RID: 120
		private Button bt_reintialiserTtl;

		// Token: 0x04000079 RID: 121
		private TextBox tb_interface;

		// Token: 0x0400007A RID: 122
		private Label label4;

		// Token: 0x0400007B RID: 123
		private IContainer components = null;

		// Token: 0x0400007C RID: 124
		private Ip_station ip;

		// Token: 0x0400007D RID: 125
		private bool entreesStatiques = true;
	}
}
