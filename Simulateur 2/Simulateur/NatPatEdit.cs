using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000068 RID: 104
	public class NatPatEdit : HashTableEdit
	{
		// Token: 0x060005DF RID: 1503 RVA: 0x0003B08C File Offset: 0x0003A08C
		public NatPatEdit()
		{
			this.InitializeComponent();
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x0003B0B4 File Offset: 0x0003A0B4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0003B0E0 File Offset: 0x0003A0E0
		private void InitializeComponent()
		{
			this.tb_ordre = new TextBox();
			this.label6 = new Label();
			this.tb_type = new TextBox();
			this.cb_protocole = new ComboBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.tb_ipPublique = new TextBox();
			this.label3 = new Label();
			this.tb_portPublic = new TextBox();
			this.label4 = new Label();
			this.tb_portPrive = new TextBox();
			this.label5 = new Label();
			this.tb_ipPrivee = new TextBox();
			this.label7 = new Label();
			base.SuspendLayout();
			this.lb_valeurs.Name = "lb_valeurs";
			this.lb_valeurs.Size = new Size(448, 56);
			this.bthte_modifier.Location = new Point(452, 60);
			this.bthte_modifier.Name = "bthte_modifier";
			this.bthte_supprimer.Location = new Point(452, 40);
			this.bthte_supprimer.Name = "bthte_supprimer";
			this.bthte_ajouter.Location = new Point(452, 20);
			this.bthte_ajouter.Name = "bthte_ajouter";
			this.bthte_annuler.Location = new Point(452, 0);
			this.bthte_annuler.Name = "bthte_annuler";
			this.bthte_annulerSaisie.Name = "bthte_annulerSaisie";
			this.bthte_validerSaisie.Name = "bthte_validerSaisie";
			this.tb_ordre.Enabled = false;
			this.tb_ordre.Location = new Point(4, 24);
			this.tb_ordre.Name = "tb_ordre";
			this.tb_ordre.Size = new Size(28, 20);
			this.tb_ordre.TabIndex = 1;
			this.tb_ordre.Text = "";
			this.label6.Location = new Point(8, 4);
			this.label6.Name = "label6";
			this.label6.Size = new Size(24, 16);
			this.label6.TabIndex = 82;
			this.label6.Text = "N°";
			this.tb_type.Enabled = false;
			this.tb_type.Location = new Point(32, 24);
			this.tb_type.Name = "tb_type";
			this.tb_type.Size = new Size(52, 20);
			this.tb_type.TabIndex = 2;
			this.tb_type.Text = "mapping";
			this.cb_protocole.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cb_protocole.Items.AddRange(new object[]
			{
				"TCP",
				"UDP"
			});
			this.cb_protocole.Location = new Point(84, 24);
			this.cb_protocole.Name = "cb_protocole";
			this.cb_protocole.Size = new Size(64, 21);
			this.cb_protocole.TabIndex = 3;
			this.label1.Location = new Point(88, 4);
			this.label1.Name = "label1";
			this.label1.Size = new Size(52, 16);
			this.label1.TabIndex = 85;
			this.label1.Text = "Protocole";
			this.label2.Location = new Point(36, 4);
			this.label2.Name = "label2";
			this.label2.Size = new Size(44, 16);
			this.label2.TabIndex = 87;
			this.label2.Text = "Type";
			this.tb_ipPublique.Location = new Point(296, 24);
			this.tb_ipPublique.Name = "tb_ipPublique";
			this.tb_ipPublique.Size = new Size(88, 20);
			this.tb_ipPublique.TabIndex = 6;
			this.tb_ipPublique.Text = "255.255.255.255";
			this.label3.Location = new Point(308, 4);
			this.label3.Name = "label3";
			this.label3.Size = new Size(60, 16);
			this.label3.TabIndex = 89;
			this.label3.Text = "Ip publique";
			this.tb_portPublic.Location = new Point(384, 24);
			this.tb_portPublic.Name = "tb_portPublic";
			this.tb_portPublic.Size = new Size(60, 20);
			this.tb_portPublic.TabIndex = 7;
			this.tb_portPublic.Text = "";
			this.tb_portPublic.TextAlign = HorizontalAlignment.Right;
			this.label4.Location = new Point(380, 4);
			this.label4.Name = "label4";
			this.label4.Size = new Size(60, 16);
			this.label4.TabIndex = 90;
			this.label4.Text = "Port public";
			this.label4.TextAlign = ContentAlignment.TopRight;
			this.tb_portPrive.Location = new Point(236, 24);
			this.tb_portPrive.Name = "tb_portPrive";
			this.tb_portPrive.Size = new Size(60, 20);
			this.tb_portPrive.TabIndex = 5;
			this.tb_portPrive.Text = "";
			this.tb_portPrive.TextAlign = HorizontalAlignment.Right;
			this.label5.Location = new Point(236, 4);
			this.label5.Name = "label5";
			this.label5.Size = new Size(60, 16);
			this.label5.TabIndex = 94;
			this.label5.Text = "Port privé";
			this.label5.TextAlign = ContentAlignment.TopRight;
			this.tb_ipPrivee.Location = new Point(148, 24);
			this.tb_ipPrivee.Name = "tb_ipPrivee";
			this.tb_ipPrivee.Size = new Size(88, 20);
			this.tb_ipPrivee.TabIndex = 4;
			this.tb_ipPrivee.Text = "255.255.255.255";
			this.label7.Location = new Point(160, 4);
			this.label7.Name = "label7";
			this.label7.Size = new Size(60, 16);
			this.label7.TabIndex = 93;
			this.label7.Text = "Ip privée";
			base.Controls.Add(this.tb_portPrive);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.tb_ipPrivee);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.tb_portPublic);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.tb_ipPublique);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.cb_protocole);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.tb_type);
			base.Controls.Add(this.tb_ordre);
			base.Controls.Add(this.label6);
			base.Name = "NatPatEdit";
			base.Size = new Size(468, 80);
			base.Controls.SetChildIndex(this.lb_valeurs, 0);
			base.Controls.SetChildIndex(this.bthte_modifier, 0);
			base.Controls.SetChildIndex(this.bthte_supprimer, 0);
			base.Controls.SetChildIndex(this.bthte_ajouter, 0);
			base.Controls.SetChildIndex(this.bthte_annuler, 0);
			base.Controls.SetChildIndex(this.bthte_validerSaisie, 0);
			base.Controls.SetChildIndex(this.bthte_annulerSaisie, 0);
			base.Controls.SetChildIndex(this.label6, 0);
			base.Controls.SetChildIndex(this.tb_ordre, 0);
			base.Controls.SetChildIndex(this.tb_type, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.cb_protocole, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.label3, 0);
			base.Controls.SetChildIndex(this.tb_ipPublique, 0);
			base.Controls.SetChildIndex(this.label4, 0);
			base.Controls.SetChildIndex(this.tb_portPublic, 0);
			base.Controls.SetChildIndex(this.label7, 0);
			base.Controls.SetChildIndex(this.tb_ipPrivee, 0);
			base.Controls.SetChildIndex(this.label5, 0);
			base.Controls.SetChildIndex(this.tb_portPrive, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x0003BA30 File Offset: 0x0003AA30
		public void init(Trs_station p_trs, bool lectureSeule)
		{
			this.trs = p_trs;
			base.init(this.trs.NatPat, lectureSeule, true);
			int[] array = new int[]
			{
				24,
				60,
				104,
				168,
				200,
				260
			};
			HashTableEdit.SendMessage(this.lb_valeurs.Handle, base.LB_SETTABSTOPS, array.Length, array);
			this.ToListe();
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x0003BA8C File Offset: 0x0003AA8C
		protected override string genererLigne(ArrayList ligne)
		{
			return string.Concat(new object[]
			{
				ligne[0],
				"\t",
				ligne[1],
				"\t",
				ligne[2],
				"\t",
				ligne[5],
				"\t",
				ligne[6],
				"\t",
				ligne[3],
				"\t",
				ligne[4]
			});
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x0003BB24 File Offset: 0x0003AB24
		protected override void ToListe()
		{
			base.ToListe();
			this.tb_ordre.Visible = false;
			this.tb_type.Visible = false;
			this.cb_protocole.Visible = false;
			this.tb_ipPublique.Visible = false;
			this.tb_portPublic.Visible = false;
			this.tb_ipPrivee.Visible = false;
			this.tb_portPrive.Visible = false;
		}

		// Token: 0x170000CA RID: 202
		// (set) Token: 0x060005E5 RID: 1509 RVA: 0x0003BB8C File Offset: 0x0003AB8C
		public bool ModeNatPat
		{
			set
			{
				this.modeNatPat = value;
			}
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x0003BBA0 File Offset: 0x0003ABA0
		protected override void ToSaisie()
		{
			if (this.ligneEdit[1].ToString() == "mapping" || this.modeNatPat)
			{
				base.ToSaisie();
				if (this.modeNatPat)
				{
					this.cb_protocole.Items.Clear();
					this.cb_protocole.Items.Add("TCP");
					this.cb_protocole.Items.Add("UDP");
					this.cb_protocole.Items.Add("ICMP");
				}
				else
				{
					this.cb_protocole.Items.Clear();
					this.cb_protocole.Items.Add("TCP");
					this.cb_protocole.Items.Add("UDP");
				}
				this.tb_ordre.Text = (string)this.ligneEdit[0];
				this.tb_type.Text = this.ligneEdit[1].ToString();
				this.cb_protocole.SelectedItem = this.ligneEdit[2];
				this.tb_ipPublique.Text = ((string)this.ligneEdit[3]).Trim();
				this.tb_portPublic.Text = this.ligneEdit[4].ToString();
				this.tb_ipPrivee.Text = ((string)this.ligneEdit[5]).Trim();
				this.tb_portPrive.Text = this.ligneEdit[6].ToString();
				this.tb_ordre.Visible = true;
				this.tb_type.Visible = true;
				this.cb_protocole.Visible = true;
				this.tb_ipPublique.Visible = true;
				this.tb_portPublic.Visible = true;
				this.tb_ipPrivee.Visible = true;
				this.tb_portPrive.Visible = true;
				this.cb_protocole.Focus();
			}
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x0003BD9C File Offset: 0x0003AD9C
		protected override void renseignerNewLigne()
		{
			this.ligneEdit.Add(HashTableEdit.DeuxChiffres(this.table.Count + 1));
			if (this.modeNatPat)
			{
				this.ligneEdit.Add("natPat");
			}
			else
			{
				this.ligneEdit.Add("mapping");
			}
			this.ligneEdit.Add("TCP");
			this.ligneEdit.Add(Ip_quartet.FormatFixe("0.0.0.0"));
			this.ligneEdit.Add("1");
			this.ligneEdit.Add(Ip_quartet.FormatFixe("0.0.0.0"));
			this.ligneEdit.Add("1");
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x0003BE54 File Offset: 0x0003AE54
		protected override void recupererLigne()
		{
			this.ligneEdit[0] = HashTableEdit.DeuxChiffres(int.Parse(this.tb_ordre.Text));
			this.ligneEdit[1] = this.tb_type.Text;
			this.ligneEdit[2] = this.cb_protocole.SelectedItem;
			this.ligneEdit[3] = Ip_quartet.FormatFixe(this.tb_ipPublique.Text);
			this.ligneEdit[4] = this.tb_portPublic.Text;
			this.ligneEdit[5] = Ip_quartet.FormatFixe(this.tb_ipPrivee.Text);
			this.ligneEdit[6] = this.tb_portPrive.Text;
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x0003BF18 File Offset: 0x0003AF18
		protected override bool ligneOk()
		{
			if (!Ip_adresse.Ok(this.tb_ipPublique.Text))
			{
				return false;
			}
			if (!Ip_adresse.Ok(this.tb_ipPrivee.Text))
			{
				return false;
			}
			if (this.trs.St.Ip.TrouverCarteIp(this.tb_ipPublique.Text) == null)
			{
				return false;
			}
			CarteReseau carteReseau = Ip_station.TrouverCarteIpDansReseau(this.trs.St.Reseau.Schema, this.tb_ipPrivee.Text);
			if (carteReseau == null || carteReseau.NoeudAttache == this.trs.St)
			{
				return false;
			}
			bool result;
			try
			{
				int.Parse(this.tb_portPublic.Text);
				int.Parse(this.tb_portPrive.Text);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x0003BFF8 File Offset: 0x0003AFF8
		public void AjouterLigne(string protocole, Ip_adresse ipPublique, int portPublic, Ip_adresse ipPrivee, int portPrive)
		{
			string text = HashTableEdit.DeuxChiffres(this.table.Count + 1);
			this.table[text] = new ArrayList();
			((ArrayList)this.table[text]).Add(text);
			((ArrayList)this.table[text]).Add("natPat");
			((ArrayList)this.table[text]).Add(protocole);
			((ArrayList)this.table[text]).Add(Ip_quartet.FormatFixe(ipPublique));
			((ArrayList)this.table[text]).Add(portPublic.ToString());
			((ArrayList)this.table[text]).Add(Ip_quartet.FormatFixe(ipPrivee));
			((ArrayList)this.table[text]).Add(portPrive.ToString());
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x0003C0EC File Offset: 0x0003B0EC
		public override void supprimerLigne(object objClef)
		{
			HashTableEdit.TriRemoveLigne(ref this.table, objClef);
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x0003C108 File Offset: 0x0003B108
		public static void SupprimerNatPats(SortedList natPat)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in natPat.Values)
			{
				ArrayList arrayList2 = (ArrayList)obj;
				if (arrayList2[1].ToString() == "natPat")
				{
					arrayList.Add(arrayList2[0]);
				}
			}
			foreach (object obj2 in arrayList)
			{
				string key = (string)obj2;
				natPat.Remove(key);
			}
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x0003C1E8 File Offset: 0x0003B1E8
		protected override void bthte_supprimer_Click(object sender, EventArgs e)
		{
			if (this.lb_valeurs.SelectedIndex != -1)
			{
				ArrayList arrayList = (ArrayList)base.htLigne(this.lb_valeurs.SelectedIndex).Clone();
				if (arrayList[1].ToString() == "mapping" || this.modeNatPat)
				{
					base.bthte_supprimer_Click(sender, e);
				}
			}
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x0003C248 File Offset: 0x0003B248
		public static bool PublicContient(SortedList table, string protocole, Ip_adresse ip, int port)
		{
			bool result = false;
			foreach (object obj in table.Values)
			{
				ArrayList arrayList = (ArrayList)obj;
				if (arrayList[2].ToString() == protocole && arrayList[3].ToString().Trim() == ip.ToString().Trim() && arrayList[4].ToString() == port.ToString())
				{
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x0003C300 File Offset: 0x0003B300
		public static Ip_adresse IpPrivee(SortedList table, string protocole, Ip_adresse ip, int port)
		{
			Ip_adresse result = new Ip_adresse("0.0.0.0");
			foreach (object obj in table.Values)
			{
				ArrayList arrayList = (ArrayList)obj;
				if (arrayList[2].ToString() == protocole && arrayList[3].ToString().Trim() == ip.ToString().Trim() && arrayList[4].ToString() == port.ToString())
				{
					result = new Ip_adresse(arrayList[5].ToString());
					break;
				}
			}
			return result;
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x0003C3D0 File Offset: 0x0003B3D0
		public static int PortPrive(SortedList table, string protocole, Ip_adresse ip, int port)
		{
			int result = 0;
			foreach (object obj in table.Values)
			{
				ArrayList arrayList = (ArrayList)obj;
				if (arrayList[2].ToString() == protocole && arrayList[3].ToString().Trim() == ip.ToString().Trim() && arrayList[4].ToString() == port.ToString())
				{
					result = int.Parse(arrayList[6].ToString());
					break;
				}
			}
			return result;
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x0003C498 File Offset: 0x0003B498
		public static void SupprimerLignePubliqueSiNat(SortedList table, string protocole, Ip_adresse ip, int port)
		{
			object obj = null;
			foreach (object obj2 in table.Values)
			{
				ArrayList arrayList = (ArrayList)obj2;
				if (arrayList[1].ToString() == "natPat" && arrayList[2].ToString() == protocole && arrayList[3].ToString().Trim() == ip.ToString().Trim() && arrayList[4].ToString() == port.ToString())
				{
					obj = arrayList[0];
					break;
				}
			}
			if (obj != null)
			{
				table.Remove(obj);
			}
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x0003C578 File Offset: 0x0003B578
		public static int IndexLignePublique(SortedList table, string protocole, Ip_adresse ip, int port, ref object clef, ref string typeNat)
		{
			int result = -1;
			int num = 0;
			clef = null;
			typeNat = "";
			foreach (object obj in table.Values)
			{
				ArrayList arrayList = (ArrayList)obj;
				if (arrayList[2].ToString() == protocole && arrayList[3].ToString().Trim() == ip.ToString().Trim() && arrayList[4].ToString() == port.ToString())
				{
					result = num;
					clef = arrayList[0];
					typeNat = arrayList[1].ToString();
					break;
				}
				num++;
			}
			return result;
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x0003C660 File Offset: 0x0003B660
		public static int IndexLignePrive(SortedList table, string protocole, Ip_adresse ip, int port)
		{
			int result = -1;
			int num = 0;
			foreach (object obj in table.Values)
			{
				ArrayList arrayList = (ArrayList)obj;
				if (arrayList[2].ToString() == protocole && arrayList[5].ToString().Trim() == ip.ToString().Trim() && arrayList[6].ToString() == port.ToString())
				{
					result = num;
					break;
				}
				num++;
			}
			return result;
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x0003C720 File Offset: 0x0003B720
		public static bool PriveContient(SortedList table, string protocole, Ip_adresse ip, int port)
		{
			bool result = false;
			foreach (object obj in table.Values)
			{
				ArrayList arrayList = (ArrayList)obj;
				if (arrayList[2].ToString() == protocole && arrayList[5].ToString().Trim() == ip.ToString().Trim() && arrayList[6].ToString() == port.ToString())
				{
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x0003C7D8 File Offset: 0x0003B7D8
		public static Ip_adresse IpPublique(SortedList table, string protocole, Ip_adresse ip, int port)
		{
			Ip_adresse result = new Ip_adresse("0.0.0.0");
			foreach (object obj in table.Values)
			{
				ArrayList arrayList = (ArrayList)obj;
				if (arrayList[2].ToString() == protocole && arrayList[5].ToString().Trim() == ip.ToString().Trim() && arrayList[6].ToString() == port.ToString())
				{
					result = new Ip_adresse(arrayList[3].ToString());
					break;
				}
			}
			return result;
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x0003C8A8 File Offset: 0x0003B8A8
		public static int PortPublic(SortedList table, string protocole, Ip_adresse ip, int port)
		{
			int result = 0;
			foreach (object obj in table.Values)
			{
				ArrayList arrayList = (ArrayList)obj;
				if (arrayList[2].ToString() == protocole && arrayList[5].ToString().Trim() == ip.ToString().Trim() && arrayList[6].ToString() == port.ToString())
				{
					result = int.Parse(arrayList[4].ToString());
					break;
				}
			}
			return result;
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x0003C970 File Offset: 0x0003B970
		public static void InsererLigneNat(SortedList table, string protocole, Ip_adresse ipPublique, int portPublic, Ip_adresse ipPrivee, int portPrive)
		{
			string text = HashTableEdit.DeuxChiffres(table.Count + 1);
			table[text] = new ArrayList();
			((ArrayList)table[text]).Add(text);
			((ArrayList)table[text]).Add("natPat");
			((ArrayList)table[text]).Add(protocole);
			((ArrayList)table[text]).Add(Ip_quartet.FormatFixe(ipPublique));
			((ArrayList)table[text]).Add(portPublic.ToString());
			((ArrayList)table[text]).Add(Ip_quartet.FormatFixe(ipPrivee));
			((ArrayList)table[text]).Add(portPrive.ToString());
		}

		// Token: 0x040003EE RID: 1006
		private TextBox tb_ordre;

		// Token: 0x040003EF RID: 1007
		private Label label6;

		// Token: 0x040003F0 RID: 1008
		private ComboBox cb_protocole;

		// Token: 0x040003F1 RID: 1009
		private Label label1;

		// Token: 0x040003F2 RID: 1010
		private Label label2;

		// Token: 0x040003F3 RID: 1011
		private TextBox tb_ipPublique;

		// Token: 0x040003F4 RID: 1012
		private Label label3;

		// Token: 0x040003F5 RID: 1013
		private TextBox tb_portPublic;

		// Token: 0x040003F6 RID: 1014
		private Label label4;

		// Token: 0x040003F7 RID: 1015
		private TextBox tb_portPrive;

		// Token: 0x040003F8 RID: 1016
		private Label label5;

		// Token: 0x040003F9 RID: 1017
		private TextBox tb_ipPrivee;

		// Token: 0x040003FA RID: 1018
		private Label label7;

		// Token: 0x040003FB RID: 1019
		private TextBox tb_type;

		// Token: 0x040003FC RID: 1020
		private IContainer components = null;

		// Token: 0x040003FD RID: 1021
		private Trs_station trs;

		// Token: 0x040003FE RID: 1022
		private bool modeNatPat = false;
	}
}
