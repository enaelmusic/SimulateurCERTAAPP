using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200007E RID: 126
	public class ReqTrsEdit : HashTableEdit
	{
		// Token: 0x06000798 RID: 1944 RVA: 0x00047E8C File Offset: 0x00046E8C
		public ReqTrsEdit()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x00047EAC File Offset: 0x00046EAC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x00047ED8 File Offset: 0x00046ED8
		private void InitializeComponent()
		{
			this.tb_portServeur = new TextBox();
			this.lbl_portServeur = new Label();
			this.tb_ipServeur = new TextBox();
			this.label7 = new Label();
			this.tb_portClient = new TextBox();
			this.label4 = new Label();
			this.tb_ipClient = new TextBox();
			this.label3 = new Label();
			this.label2 = new Label();
			this.tb_ordre = new TextBox();
			this.label6 = new Label();
			this.cb_protocole = new ComboBox();
			base.SuspendLayout();
			this.lb_valeurs.Items.AddRange(new object[]
			{
				"",
				"",
				"rrrrrrrrr rrrrrrrrrrrrrrrr rrrrrrrrrrrrrrrrrrrrrrrrrrrrrr rrrrrrrrrrrrrrrrrr rrrrrrrrrrrrrrrrrrrrrrrrrrrrrr rrrrrrrrrrrrrrrrrr "
			});
			this.lb_valeurs.Name = "lb_valeurs";
			this.lb_valeurs.Size = new Size(384, 56);
			this.bthte_modifier.Location = new Point(388, 60);
			this.bthte_modifier.Name = "bthte_modifier";
			this.bthte_supprimer.Location = new Point(388, 40);
			this.bthte_supprimer.Name = "bthte_supprimer";
			this.bthte_ajouter.Location = new Point(388, 20);
			this.bthte_ajouter.Name = "bthte_ajouter";
			this.bthte_annuler.Location = new Point(388, 0);
			this.bthte_annuler.Name = "bthte_annuler";
			this.bthte_annulerSaisie.Name = "bthte_annulerSaisie";
			this.bthte_validerSaisie.Name = "bthte_validerSaisie";
			this.tb_portServeur.Location = new Point(320, 24);
			this.tb_portServeur.Name = "tb_portServeur";
			this.tb_portServeur.Size = new Size(60, 20);
			this.tb_portServeur.TabIndex = 107;
			this.tb_portServeur.Text = "";
			this.tb_portServeur.TextAlign = HorizontalAlignment.Right;
			this.lbl_portServeur.Location = new Point(324, 4);
			this.lbl_portServeur.Name = "lbl_portServeur";
			this.lbl_portServeur.Size = new Size(60, 16);
			this.lbl_portServeur.TabIndex = 106;
			this.lbl_portServeur.Text = "Port dest.";
			this.tb_ipServeur.Location = new Point(232, 24);
			this.tb_ipServeur.Name = "tb_ipServeur";
			this.tb_ipServeur.Size = new Size(88, 20);
			this.tb_ipServeur.TabIndex = 104;
			this.tb_ipServeur.Text = "255.255.255.255";
			this.label7.Location = new Point(252, 4);
			this.label7.Name = "label7";
			this.label7.Size = new Size(56, 16);
			this.label7.TabIndex = 105;
			this.label7.Text = "Ip dest.";
			this.tb_portClient.Location = new Point(172, 24);
			this.tb_portClient.Name = "tb_portClient";
			this.tb_portClient.Size = new Size(60, 20);
			this.tb_portClient.TabIndex = 103;
			this.tb_portClient.Text = "";
			this.tb_portClient.TextAlign = HorizontalAlignment.Right;
			this.tb_portClient.TextChanged += this.tb_portClient_TextChanged;
			this.label4.Location = new Point(156, 4);
			this.label4.Name = "label4";
			this.label4.Size = new Size(88, 16);
			this.label4.TabIndex = 102;
			this.label4.Text = "Port sce/Id Icmp";
			this.label4.TextAlign = ContentAlignment.TopRight;
			this.tb_ipClient.Location = new Point(84, 24);
			this.tb_ipClient.Name = "tb_ipClient";
			this.tb_ipClient.Size = new Size(88, 20);
			this.tb_ipClient.TabIndex = 100;
			this.tb_ipClient.Text = "255.255.255.255";
			this.label3.Location = new Point(96, 4);
			this.label3.Name = "label3";
			this.label3.Size = new Size(60, 16);
			this.label3.TabIndex = 101;
			this.label3.Text = "Ip source";
			this.label2.Location = new Point(36, 4);
			this.label2.Name = "label2";
			this.label2.Size = new Size(52, 16);
			this.label2.TabIndex = 99;
			this.label2.Text = "Protocole";
			this.tb_ordre.Enabled = false;
			this.tb_ordre.Location = new Point(4, 24);
			this.tb_ordre.Name = "tb_ordre";
			this.tb_ordre.Size = new Size(28, 20);
			this.tb_ordre.TabIndex = 97;
			this.tb_ordre.Text = "";
			this.tb_ordre.TextAlign = HorizontalAlignment.Center;
			this.label6.Location = new Point(8, 4);
			this.label6.Name = "label6";
			this.label6.Size = new Size(24, 16);
			this.label6.TabIndex = 96;
			this.label6.Text = "N°";
			this.cb_protocole.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cb_protocole.Items.AddRange(new object[]
			{
				"TCP",
				"UDP",
				"ICMP"
			});
			this.cb_protocole.Location = new Point(32, 24);
			this.cb_protocole.Name = "cb_protocole";
			this.cb_protocole.Size = new Size(52, 21);
			this.cb_protocole.TabIndex = 108;
			this.cb_protocole.SelectedIndexChanged += this.cb_protocole_SelectedIndexChanged;
			base.Controls.Add(this.cb_protocole);
			base.Controls.Add(this.tb_portServeur);
			base.Controls.Add(this.lbl_portServeur);
			base.Controls.Add(this.tb_ipServeur);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.tb_portClient);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.tb_ipClient);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.tb_ordre);
			base.Controls.Add(this.label6);
			base.Name = "ReqTrsEdit";
			base.Size = new Size(404, 80);
			base.Controls.SetChildIndex(this.lb_valeurs, 0);
			base.Controls.SetChildIndex(this.bthte_modifier, 0);
			base.Controls.SetChildIndex(this.bthte_supprimer, 0);
			base.Controls.SetChildIndex(this.bthte_ajouter, 0);
			base.Controls.SetChildIndex(this.bthte_annuler, 0);
			base.Controls.SetChildIndex(this.bthte_validerSaisie, 0);
			base.Controls.SetChildIndex(this.bthte_annulerSaisie, 0);
			base.Controls.SetChildIndex(this.label6, 0);
			base.Controls.SetChildIndex(this.tb_ordre, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.label3, 0);
			base.Controls.SetChildIndex(this.tb_ipClient, 0);
			base.Controls.SetChildIndex(this.label4, 0);
			base.Controls.SetChildIndex(this.tb_portClient, 0);
			base.Controls.SetChildIndex(this.label7, 0);
			base.Controls.SetChildIndex(this.tb_ipServeur, 0);
			base.Controls.SetChildIndex(this.lbl_portServeur, 0);
			base.Controls.SetChildIndex(this.tb_portServeur, 0);
			base.Controls.SetChildIndex(this.cb_protocole, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x0004877C File Offset: 0x0004777C
		public void init(Trs_station p_trs, SortedList table, bool lectureSeule)
		{
			this.trs = p_trs;
			base.init(table, lectureSeule, true);
			int[] array = new int[]
			{
				24,
				60,
				124,
				158,
				230
			};
			HashTableEdit.SendMessage(this.lb_valeurs.Handle, base.LB_SETTABSTOPS, array.Length, array);
			this.ToListe();
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x000487CC File Offset: 0x000477CC
		protected override string genererLigne(ArrayList ligne)
		{
			string result;
			if (ligne[1].ToString() == "ICMP")
			{
				result = string.Concat(new object[]
				{
					ligne[0],
					"\t",
					ligne[1],
					"\t",
					ligne[2],
					"\tId ",
					ligne[3],
					"\t",
					ligne[4],
					"\t---"
				});
			}
			else
			{
				result = string.Concat(new object[]
				{
					ligne[0],
					"\t",
					ligne[1],
					"\t",
					ligne[2],
					"\t",
					ligne[3],
					"\t",
					ligne[4],
					"\t",
					ligne[5]
				});
			}
			return result;
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x000488D4 File Offset: 0x000478D4
		protected override void ToListe()
		{
			base.ToListe();
			this.tb_ordre.Visible = false;
			this.cb_protocole.Visible = false;
			this.tb_ipClient.Visible = false;
			this.tb_portClient.Visible = false;
			this.tb_ipServeur.Visible = false;
			this.tb_portServeur.Visible = false;
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x00048930 File Offset: 0x00047930
		protected override void ToSaisie()
		{
			base.ToSaisie();
			this.tb_ordre.Text = (string)this.ligneEdit[0];
			this.cb_protocole.SelectedItem = this.ligneEdit[1];
			this.tb_ipClient.Text = ((string)this.ligneEdit[2]).Trim();
			this.tb_portClient.Text = this.ligneEdit[3].ToString();
			this.tb_ipServeur.Text = ((string)this.ligneEdit[4]).Trim();
			this.tb_portServeur.Text = this.ligneEdit[5].ToString();
			this.tb_ordre.Visible = true;
			this.cb_protocole.Visible = true;
			this.tb_ipClient.Visible = true;
			this.tb_portClient.Visible = true;
			this.tb_ipServeur.Visible = true;
			this.tb_portServeur.Visible = true;
			this.tb_ordre.Focus();
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x00048A44 File Offset: 0x00047A44
		private static int maxOrdre(SortedList table)
		{
			int num = 0;
			foreach (object obj in table.Values)
			{
				ArrayList arrayList = (ArrayList)obj;
				if (int.Parse(arrayList[0].ToString()) > num)
				{
					num = int.Parse(arrayList[0].ToString());
				}
			}
			return num;
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x00048ACC File Offset: 0x00047ACC
		protected override void renseignerNewLigne()
		{
			this.ligneEdit.Add(HashTableEdit.DeuxChiffres(ReqTrsEdit.maxOrdre(this.table) + 1));
			this.ligneEdit.Add("");
			this.ligneEdit.Add("");
			this.ligneEdit.Add("");
			this.ligneEdit.Add("");
			this.ligneEdit.Add("");
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x00048B4C File Offset: 0x00047B4C
		protected override void recupererLigne()
		{
			this.ligneEdit[0] = HashTableEdit.DeuxChiffres(int.Parse(this.tb_ordre.Text));
			this.ligneEdit[1] = this.cb_protocole.SelectedItem;
			this.ligneEdit[2] = this.tb_ipClient.Text;
			this.ligneEdit[3] = this.tb_portClient.Text;
			this.ligneEdit[4] = this.tb_ipServeur.Text;
			this.ligneEdit[5] = this.tb_portServeur.Text;
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x00048BF0 File Offset: 0x00047BF0
		protected override bool ligneOk()
		{
			return true;
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x00048C00 File Offset: 0x00047C00
		public static void AjouterLigne(SortedList table, string protocole, Ip_adresse ipClient, int portClient, Ip_adresse ipServeur, int portServeur)
		{
			string text = HashTableEdit.DeuxChiffres(ReqTrsEdit.maxOrdre(table) + 1);
			table[text] = new ArrayList();
			((ArrayList)table[text]).Add(text);
			((ArrayList)table[text]).Add(protocole);
			((ArrayList)table[text]).Add(Ip_quartet.FormatFixe(ipClient));
			((ArrayList)table[text]).Add(portClient.ToString());
			((ArrayList)table[text]).Add(Ip_quartet.FormatFixe(ipServeur));
			((ArrayList)table[text]).Add(portServeur.ToString());
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x00048CB0 File Offset: 0x00047CB0
		public static object GetClef(SortedList table, ProtocoleTrs protocole, Ip_adresse ipClient, int portClient, Ip_adresse ipServeur, int portServeur, ref int index)
		{
			object result = null;
			index = -1;
			int num = 0;
			foreach (object obj in table.Values)
			{
				ArrayList arrayList = (ArrayList)obj;
				if (arrayList[1].ToString() == protocole.ToString() && Ip_quartet.FormatFixe(ipClient) == arrayList[2].ToString() && arrayList[3].ToString() == portClient.ToString() && Ip_quartet.FormatFixe(ipServeur) == arrayList[4].ToString() && arrayList[5].ToString() == portServeur.ToString())
				{
					result = arrayList[0];
					index = num;
					break;
				}
				num++;
			}
			return result;
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x00048DB8 File Offset: 0x00047DB8
		public override void supprimerLigne(object objClef)
		{
			this.table.Remove(objClef);
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x00048DD4 File Offset: 0x00047DD4
		public static void SupprimerReqTrs(ref SortedList table, object objClef)
		{
			table.Remove(objClef);
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x00048DEC File Offset: 0x00047DEC
		private void cb_protocole_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cb_protocole.SelectedIndex == -1)
			{
				this.lbl_portServeur.Visible = true;
				this.tb_portServeur.Visible = true;
				return;
			}
			if (this.cb_protocole.SelectedIndex == 2)
			{
				this.lbl_portServeur.Visible = false;
				this.tb_portServeur.Visible = false;
				this.tb_portServeur.Text = this.tb_portClient.Text;
				return;
			}
			this.lbl_portServeur.Visible = true;
			this.tb_portServeur.Visible = true;
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x00048E78 File Offset: 0x00047E78
		private void tb_portClient_TextChanged(object sender, EventArgs e)
		{
			if (this.cb_protocole.SelectedIndex == 2)
			{
				this.tb_portServeur.Text = this.tb_portClient.Text;
			}
		}

		// Token: 0x040004B4 RID: 1204
		private Label label7;

		// Token: 0x040004B5 RID: 1205
		private Label label4;

		// Token: 0x040004B6 RID: 1206
		private Label label3;

		// Token: 0x040004B7 RID: 1207
		private Label label2;

		// Token: 0x040004B8 RID: 1208
		private TextBox tb_ordre;

		// Token: 0x040004B9 RID: 1209
		private Label label6;

		// Token: 0x040004BA RID: 1210
		private TextBox tb_portServeur;

		// Token: 0x040004BB RID: 1211
		private TextBox tb_ipServeur;

		// Token: 0x040004BC RID: 1212
		private TextBox tb_portClient;

		// Token: 0x040004BD RID: 1213
		private TextBox tb_ipClient;

		// Token: 0x040004BE RID: 1214
		private ComboBox cb_protocole;

		// Token: 0x040004BF RID: 1215
		private Label lbl_portServeur;

		// Token: 0x040004C0 RID: 1216
		private IContainer components = null;

		// Token: 0x040004C1 RID: 1217
		private Trs_station trs;
	}
}
