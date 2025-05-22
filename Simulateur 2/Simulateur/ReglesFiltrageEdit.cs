using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200007D RID: 125
	public class ReglesFiltrageEdit : HashTableEdit
	{
		// Token: 0x0600078A RID: 1930 RVA: 0x00046714 File Offset: 0x00045714
		public ReglesFiltrageEdit()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x00046740 File Offset: 0x00045740
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x0004676C File Offset: 0x0004576C
		private void InitializeComponent()
		{
			this.tb_ordre = new TextBox();
			this.label6 = new Label();
			this.tb_portDest = new TextBox();
			this.label5 = new Label();
			this.tb_ipDest = new TextBox();
			this.label7 = new Label();
			this.tb_portSource = new TextBox();
			this.label4 = new Label();
			this.tb_ipSource = new TextBox();
			this.label3 = new Label();
			this.cb_protocole = new ComboBox();
			this.label1 = new Label();
			this.cb_interfaceArrivee = new ComboBox();
			this.label2 = new Label();
			this.cb_interfaceDepart = new ComboBox();
			this.label8 = new Label();
			this.cb_action = new ComboBox();
			this.label9 = new Label();
			base.SuspendLayout();
			this.lb_valeurs.Name = "lb_valeurs";
			this.lb_valeurs.Size = new Size(560, 56);
			this.bthte_modifier.Location = new Point(564, 60);
			this.bthte_modifier.Name = "bthte_modifier";
			this.bthte_supprimer.Location = new Point(564, 40);
			this.bthte_supprimer.Name = "bthte_supprimer";
			this.bthte_ajouter.Location = new Point(564, 20);
			this.bthte_ajouter.Name = "bthte_ajouter";
			this.bthte_annuler.Location = new Point(564, 0);
			this.bthte_annuler.Name = "bthte_annuler";
			this.bthte_annulerSaisie.Name = "bthte_annulerSaisie";
			this.bthte_validerSaisie.Name = "bthte_validerSaisie";
			this.tb_ordre.Location = new Point(0, 20);
			this.tb_ordre.Name = "tb_ordre";
			this.tb_ordre.Size = new Size(28, 20);
			this.tb_ordre.TabIndex = 91;
			this.tb_ordre.Text = "";
			this.label6.Location = new Point(4, 4);
			this.label6.Name = "label6";
			this.label6.Size = new Size(24, 16);
			this.label6.TabIndex = 90;
			this.label6.Text = "N°";
			this.tb_portDest.Location = new Point(448, 20);
			this.tb_portDest.Name = "tb_portDest";
			this.tb_portDest.Size = new Size(40, 20);
			this.tb_portDest.TabIndex = 105;
			this.tb_portDest.Text = "";
			this.tb_portDest.TextAlign = HorizontalAlignment.Right;
			this.label5.Location = new Point(444, 4);
			this.label5.Name = "label5";
			this.label5.Size = new Size(40, 16);
			this.label5.TabIndex = 104;
			this.label5.Text = "Pt dest";
			this.tb_ipDest.Location = new Point(344, 20);
			this.tb_ipDest.Name = "tb_ipDest";
			this.tb_ipDest.Size = new Size(104, 20);
			this.tb_ipDest.TabIndex = 102;
			this.tb_ipDest.Text = "255.255.255.255/32";
			this.label7.Location = new Point(352, 4);
			this.label7.Name = "label7";
			this.label7.Size = new Size(60, 16);
			this.label7.TabIndex = 103;
			this.label7.Text = "Ip dest/n";
			this.tb_portSource.Location = new Point(304, 20);
			this.tb_portSource.Name = "tb_portSource";
			this.tb_portSource.Size = new Size(40, 20);
			this.tb_portSource.TabIndex = 101;
			this.tb_portSource.Text = "";
			this.tb_portSource.TextAlign = HorizontalAlignment.Right;
			this.label4.Location = new Point(304, 4);
			this.label4.Name = "label4";
			this.label4.Size = new Size(40, 16);
			this.label4.TabIndex = 100;
			this.label4.Text = "Pt sce";
			this.tb_ipSource.Location = new Point(200, 20);
			this.tb_ipSource.Name = "tb_ipSource";
			this.tb_ipSource.Size = new Size(104, 20);
			this.tb_ipSource.TabIndex = 98;
			this.tb_ipSource.Text = "255.255.255.255/32";
			this.label3.Location = new Point(204, 4);
			this.label3.Name = "label3";
			this.label3.Size = new Size(84, 16);
			this.label3.TabIndex = 99;
			this.label3.Text = "Ip source/n";
			this.cb_protocole.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cb_protocole.Items.AddRange(new object[]
			{
				"*",
				"TCP",
				"UDP",
				"ICMP"
			});
			this.cb_protocole.Location = new Point(148, 20);
			this.cb_protocole.Name = "cb_protocole";
			this.cb_protocole.Size = new Size(52, 21);
			this.cb_protocole.TabIndex = 97;
			this.label1.Location = new Point(156, 4);
			this.label1.Name = "label1";
			this.label1.Size = new Size(28, 16);
			this.label1.TabIndex = 96;
			this.label1.Text = "Prot.";
			this.cb_interfaceArrivee.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cb_interfaceArrivee.DropDownWidth = 150;
			this.cb_interfaceArrivee.Location = new Point(28, 20);
			this.cb_interfaceArrivee.Name = "cb_interfaceArrivee";
			this.cb_interfaceArrivee.Size = new Size(60, 21);
			this.cb_interfaceArrivee.TabIndex = 107;
			this.label2.Location = new Point(28, 4);
			this.label2.Name = "label2";
			this.label2.Size = new Size(44, 16);
			this.label2.TabIndex = 106;
			this.label2.Text = "Entrée";
			this.cb_interfaceDepart.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cb_interfaceDepart.DropDownWidth = 150;
			this.cb_interfaceDepart.Location = new Point(88, 20);
			this.cb_interfaceDepart.Name = "cb_interfaceDepart";
			this.cb_interfaceDepart.Size = new Size(60, 21);
			this.cb_interfaceDepart.TabIndex = 109;
			this.label8.Location = new Point(96, 4);
			this.label8.Name = "label8";
			this.label8.Size = new Size(40, 16);
			this.label8.TabIndex = 108;
			this.label8.Text = "Sortie";
			this.cb_action.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cb_action.Items.AddRange(new object[]
			{
				"Accepter",
				"Bloquer"
			});
			this.cb_action.Location = new Point(488, 20);
			this.cb_action.Name = "cb_action";
			this.cb_action.Size = new Size(72, 21);
			this.cb_action.TabIndex = 111;
			this.label9.Location = new Point(508, 4);
			this.label9.Name = "label9";
			this.label9.Size = new Size(40, 16);
			this.label9.TabIndex = 110;
			this.label9.Text = "Action";
			base.Controls.Add(this.cb_action);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.cb_interfaceDepart);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.cb_interfaceArrivee);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.tb_portDest);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.tb_ipDest);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.tb_portSource);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.tb_ipSource);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.cb_protocole);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.tb_ordre);
			base.Controls.Add(this.label6);
			base.Name = "ReglesFiltrageEdit";
			base.Size = new Size(580, 80);
			base.Controls.SetChildIndex(this.lb_valeurs, 0);
			base.Controls.SetChildIndex(this.bthte_modifier, 0);
			base.Controls.SetChildIndex(this.bthte_supprimer, 0);
			base.Controls.SetChildIndex(this.bthte_ajouter, 0);
			base.Controls.SetChildIndex(this.bthte_annuler, 0);
			base.Controls.SetChildIndex(this.bthte_validerSaisie, 0);
			base.Controls.SetChildIndex(this.bthte_annulerSaisie, 0);
			base.Controls.SetChildIndex(this.label6, 0);
			base.Controls.SetChildIndex(this.tb_ordre, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.cb_protocole, 0);
			base.Controls.SetChildIndex(this.label3, 0);
			base.Controls.SetChildIndex(this.tb_ipSource, 0);
			base.Controls.SetChildIndex(this.label4, 0);
			base.Controls.SetChildIndex(this.tb_portSource, 0);
			base.Controls.SetChildIndex(this.label7, 0);
			base.Controls.SetChildIndex(this.tb_ipDest, 0);
			base.Controls.SetChildIndex(this.label5, 0);
			base.Controls.SetChildIndex(this.tb_portDest, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.cb_interfaceArrivee, 0);
			base.Controls.SetChildIndex(this.label8, 0);
			base.Controls.SetChildIndex(this.cb_interfaceDepart, 0);
			base.Controls.SetChildIndex(this.label9, 0);
			base.Controls.SetChildIndex(this.cb_action, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x00047300 File Offset: 0x00046300
		public void init(Trs_station p_trs, bool lectureSeule)
		{
			this.trs = p_trs;
			base.init(this.trs.ReglesFiltrage, lectureSeule, true, true);
			CarteReseau carteReseau = (CarteReseau)this.trs.St.Controls[0];
			this.adrIpCarte1 = carteReseau.Ip.Adresse.ToString();
			this.cb_interfaceDepart.Items.Clear();
			this.cb_interfaceArrivee.Items.Clear();
			this.cb_interfaceDepart.Items.Add("*");
			this.cb_interfaceArrivee.Items.Add("*");
			int num = 1;
			this.cartes = new Hashtable();
			this.cartes.Add("*", 0);
			foreach (object obj in this.trs.St.Controls)
			{
				CarteReseau carteReseau2 = (CarteReseau)obj;
				this.cartes.Add(carteReseau2.AdresseMac, num++);
				this.cb_interfaceArrivee.Items.Add(carteReseau2.AdresseMac + "   (" + carteReseau2.Ip.Adresse.ToString() + ")");
				this.cb_interfaceDepart.Items.Add(carteReseau2.AdresseMac + "   (" + carteReseau2.Ip.Adresse.ToString() + ")");
			}
			int[] array = new int[]
			{
				20,
				64,
				104,
				132,
				204,
				230,
				300,
				330
			};
			HashTableEdit.SendMessage(this.lb_valeurs.Handle, base.LB_SETTABSTOPS, array.Length, array);
			this.ToListe();
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x000474EC File Offset: 0x000464EC
		public static string CalculerClef(ArrayList ligne)
		{
			return string.Concat(new string[]
			{
				(string)ligne[2],
				(string)ligne[3],
				(string)ligne[4],
				(string)ligne[5],
				(string)ligne[6],
				(string)ligne[7],
				(string)ligne[8]
			});
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x00047570 File Offset: 0x00046570
		protected override string genererLigne(ArrayList ligne)
		{
			return string.Concat(new object[]
			{
				ligne[0],
				"\t",
				ligne[2],
				"\t",
				ligne[3],
				"\t",
				ligne[4],
				"\t",
				ligne[5],
				"\t",
				ligne[6],
				"\t",
				ligne[7],
				"\t",
				ligne[8],
				"\t",
				ligne[9]
			});
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x00047630 File Offset: 0x00046630
		protected override void ToListe()
		{
			base.ToListe();
			this.tb_ordre.Visible = false;
			this.cb_interfaceArrivee.Visible = false;
			this.cb_interfaceDepart.Visible = false;
			this.cb_protocole.Visible = false;
			this.tb_ipSource.Visible = false;
			this.tb_portSource.Visible = false;
			this.tb_ipDest.Visible = false;
			this.tb_portDest.Visible = false;
			this.cb_action.Visible = false;
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x000476B0 File Offset: 0x000466B0
		protected override void ToSaisie()
		{
			base.ToSaisie();
			this.tb_ordre.Text = (string)this.ligneEdit[0];
			if (this.ligneEdit[2].ToString() == "*")
			{
				this.cb_interfaceArrivee.SelectedIndex = 0;
			}
			else
			{
				this.cb_interfaceArrivee.SelectedIndex = int.Parse(this.cartes[this.ligneEdit[2].ToString()].ToString());
			}
			if (this.ligneEdit[3].ToString() == "*")
			{
				this.cb_interfaceDepart.SelectedIndex = 0;
			}
			else
			{
				this.cb_interfaceDepart.SelectedIndex = int.Parse(this.cartes[this.ligneEdit[3].ToString()].ToString());
			}
			this.cb_protocole.SelectedItem = this.ligneEdit[4];
			this.tb_ipSource.Text = ((string)this.ligneEdit[5]).Trim();
			this.tb_portSource.Text = this.ligneEdit[6].ToString();
			this.tb_ipDest.Text = ((string)this.ligneEdit[7]).Trim();
			this.tb_portDest.Text = this.ligneEdit[8].ToString();
			this.cb_action.SelectedItem = this.ligneEdit[9];
			this.tb_ordre.Visible = true;
			this.cb_interfaceArrivee.Visible = true;
			this.cb_interfaceDepart.Visible = true;
			this.cb_protocole.Visible = true;
			this.tb_ipSource.Visible = true;
			this.tb_portSource.Visible = true;
			this.tb_ipDest.Visible = true;
			this.tb_portDest.Visible = true;
			this.cb_action.Visible = true;
			this.tb_ordre.Focus();
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x000478B8 File Offset: 0x000468B8
		protected override void renseignerNewLigne()
		{
			this.ligneEdit.Add(HashTableEdit.DeuxChiffres(this.table.Count + 1));
			this.ligneEdit.Add("");
			this.ligneEdit.Add("*");
			this.ligneEdit.Add("*");
			this.ligneEdit.Add("*");
			this.ligneEdit.Add("*");
			this.ligneEdit.Add("*");
			this.ligneEdit.Add("*");
			this.ligneEdit.Add("*");
			this.ligneEdit.Add("Bloquer");
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x0004797C File Offset: 0x0004697C
		protected override void recupererLigne()
		{
			this.ligneEdit[0] = HashTableEdit.DeuxChiffres(int.Parse(this.tb_ordre.Text));
			if (this.cb_interfaceArrivee.SelectedItem.ToString() != "*")
			{
				this.ligneEdit[2] = this.cb_interfaceArrivee.SelectedItem.ToString().Substring(0, 6).Trim();
			}
			else
			{
				this.ligneEdit[2] = "*";
			}
			if (this.cb_interfaceDepart.SelectedItem.ToString() != "*")
			{
				this.ligneEdit[3] = this.cb_interfaceDepart.SelectedItem.ToString().Substring(0, 6).Trim();
			}
			else
			{
				this.ligneEdit[3] = "*";
			}
			this.ligneEdit[4] = this.cb_protocole.SelectedItem;
			if (this.tb_ipSource.Text != "*")
			{
				this.ligneEdit[5] = this.tb_ipSource.Text;
			}
			else
			{
				this.ligneEdit[5] = "*";
			}
			this.ligneEdit[6] = this.tb_portSource.Text;
			if (this.tb_ipDest.Text != "*")
			{
				this.ligneEdit[7] = this.tb_ipDest.Text;
			}
			else
			{
				this.ligneEdit[7] = "*";
			}
			this.ligneEdit[8] = this.tb_portDest.Text;
			this.ligneEdit[9] = this.cb_action.SelectedItem;
			this.ligneEdit[1] = ReglesFiltrageEdit.CalculerClef(this.ligneEdit);
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x00047B50 File Offset: 0x00046B50
		protected override bool ligneOk()
		{
			if (this.tb_ipSource.Text == "")
			{
				this.tb_ipSource.Text = "*";
			}
			if (this.tb_ipDest.Text == "")
			{
				this.tb_ipDest.Text = "*";
			}
			if (this.tb_portSource.Text == "")
			{
				this.tb_portSource.Text = "*";
			}
			if (this.tb_portDest.Text == "")
			{
				this.tb_portDest.Text = "*";
			}
			if (this.tb_ipSource.Text != "*")
			{
				string text = Ip_adresse.WithNbBits(this.tb_ipSource.Text);
				if (text == null)
				{
					return false;
				}
				this.tb_ipSource.Text = text;
			}
			if (this.tb_ipDest.Text != "*")
			{
				string text = Ip_adresse.WithNbBits(this.tb_ipDest.Text);
				if (text == null)
				{
					return false;
				}
				this.tb_ipDest.Text = text;
			}
			string text2 = this.tb_portSource.Text;
			string text3 = this.tb_portDest.Text;
			if (text2 == "*")
			{
				text2 = "0";
			}
			if (text3 == "*")
			{
				text3 = "0";
			}
			bool result;
			try
			{
				int.Parse(this.tb_ordre.Text);
				int.Parse(text2);
				int.Parse(text3);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x00047CF0 File Offset: 0x00046CF0
		public static void MajCarteSupprimee(ref SortedList regles, CarteReseau c)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in regles.Values)
			{
				ArrayList arrayList2 = (ArrayList)obj;
				if (arrayList2[2].ToString() == c.AdresseMac || arrayList2[3].ToString() == c.AdresseMac)
				{
					arrayList.Add(arrayList2[0]);
				}
			}
			foreach (object objClef in arrayList)
			{
				HashTableEdit.TriRemoveLigne(ref regles, objClef);
			}
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x00047DE8 File Offset: 0x00046DE8
		public override void supprimerLigne(object objClef)
		{
			HashTableEdit.TriRemoveLigne(ref this.table, objClef);
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x00047E04 File Offset: 0x00046E04
		public static bool ItemDifferent(ArrayList regle, string valeur, int pos)
		{
			if (valeur == null)
			{
				return !(regle[pos].ToString() == "*");
			}
			if (regle[pos].ToString() == "*")
			{
				return false;
			}
			if (pos == 5 || pos == 7)
			{
				Ip_adresse adr;
				int num;
				Ip_masque masque;
				Ip_adresse.SeparerAdrEtNbBits(regle[pos].ToString(), out adr, out num, out masque);
				return !Ip_quartet.MemeReseau(adr, new Ip_adresse(valeur), masque);
			}
			return regle[pos].ToString() != valeur;
		}

		// Token: 0x0400049E RID: 1182
		private TextBox tb_ordre;

		// Token: 0x0400049F RID: 1183
		private Label label6;

		// Token: 0x040004A0 RID: 1184
		private TextBox tb_portDest;

		// Token: 0x040004A1 RID: 1185
		private Label label5;

		// Token: 0x040004A2 RID: 1186
		private TextBox tb_ipDest;

		// Token: 0x040004A3 RID: 1187
		private Label label7;

		// Token: 0x040004A4 RID: 1188
		private TextBox tb_portSource;

		// Token: 0x040004A5 RID: 1189
		private Label label4;

		// Token: 0x040004A6 RID: 1190
		private TextBox tb_ipSource;

		// Token: 0x040004A7 RID: 1191
		private Label label3;

		// Token: 0x040004A8 RID: 1192
		private ComboBox cb_protocole;

		// Token: 0x040004A9 RID: 1193
		private Label label1;

		// Token: 0x040004AA RID: 1194
		private Label label2;

		// Token: 0x040004AB RID: 1195
		private ComboBox cb_interfaceArrivee;

		// Token: 0x040004AC RID: 1196
		private ComboBox cb_interfaceDepart;

		// Token: 0x040004AD RID: 1197
		private Label label8;

		// Token: 0x040004AE RID: 1198
		private ComboBox cb_action;

		// Token: 0x040004AF RID: 1199
		private Label label9;

		// Token: 0x040004B0 RID: 1200
		private IContainer components = null;

		// Token: 0x040004B1 RID: 1201
		private Trs_station trs;

		// Token: 0x040004B2 RID: 1202
		private string adrIpCarte1;

		// Token: 0x040004B3 RID: 1203
		private Hashtable cartes = new Hashtable();
	}
}
