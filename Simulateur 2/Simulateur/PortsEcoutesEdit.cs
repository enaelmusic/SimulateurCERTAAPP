using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000078 RID: 120
	public class PortsEcoutesEdit : HashTableEdit
	{
		// Token: 0x06000754 RID: 1876 RVA: 0x00044A48 File Offset: 0x00043A48
		public PortsEcoutesEdit()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x00044A68 File Offset: 0x00043A68
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x00044A94 File Offset: 0x00043A94
		private void InitializeComponent()
		{
			this.label2 = new Label();
			this.label1 = new Label();
			this.cb_protocole = new ComboBox();
			this.tb_numPort = new TextBox();
			this.tb_ordre = new TextBox();
			this.label6 = new Label();
			base.SuspendLayout();
			this.lb_valeurs.Name = "lb_valeurs";
			this.lb_valeurs.Size = new Size(200, 56);
			this.bthte_modifier.Location = new Point(204, 60);
			this.bthte_modifier.Name = "bthte_modifier";
			this.bthte_supprimer.Location = new Point(204, 40);
			this.bthte_supprimer.Name = "bthte_supprimer";
			this.bthte_ajouter.Location = new Point(204, 20);
			this.bthte_ajouter.Name = "bthte_ajouter";
			this.bthte_annuler.Location = new Point(204, 0);
			this.bthte_annuler.Name = "bthte_annuler";
			this.bthte_annulerSaisie.Name = "bthte_annulerSaisie";
			this.bthte_validerSaisie.Name = "bthte_validerSaisie";
			this.label2.Location = new Point(112, 4);
			this.label2.Name = "label2";
			this.label2.Size = new Size(84, 16);
			this.label2.TabIndex = 76;
			this.label2.Text = "Numéro de port";
			this.label1.Location = new Point(36, 4);
			this.label1.Name = "label1";
			this.label1.Size = new Size(60, 16);
			this.label1.TabIndex = 75;
			this.label1.Text = "Protocole";
			this.cb_protocole.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cb_protocole.Items.AddRange(new object[]
			{
				"TCP",
				"UDP"
			});
			this.cb_protocole.Location = new Point(40, 24);
			this.cb_protocole.Name = "cb_protocole";
			this.cb_protocole.Size = new Size(64, 21);
			this.cb_protocole.TabIndex = 77;
			this.tb_numPort.Location = new Point(108, 24);
			this.tb_numPort.Name = "tb_numPort";
			this.tb_numPort.Size = new Size(84, 20);
			this.tb_numPort.TabIndex = 78;
			this.tb_numPort.Text = "";
			this.tb_numPort.TextAlign = HorizontalAlignment.Right;
			this.tb_ordre.Enabled = false;
			this.tb_ordre.Location = new Point(4, 24);
			this.tb_ordre.Name = "tb_ordre";
			this.tb_ordre.Size = new Size(28, 20);
			this.tb_ordre.TabIndex = 83;
			this.tb_ordre.Text = "";
			this.label6.Location = new Point(4, 4);
			this.label6.Name = "label6";
			this.label6.Size = new Size(24, 16);
			this.label6.TabIndex = 82;
			this.label6.Text = "N°";
			base.Controls.Add(this.tb_ordre);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.tb_numPort);
			base.Controls.Add(this.cb_protocole);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Name = "PortsEcoutesEdit";
			base.Size = new Size(220, 80);
			base.Controls.SetChildIndex(this.lb_valeurs, 0);
			base.Controls.SetChildIndex(this.bthte_modifier, 0);
			base.Controls.SetChildIndex(this.bthte_supprimer, 0);
			base.Controls.SetChildIndex(this.bthte_ajouter, 0);
			base.Controls.SetChildIndex(this.bthte_annuler, 0);
			base.Controls.SetChildIndex(this.bthte_validerSaisie, 0);
			base.Controls.SetChildIndex(this.bthte_annulerSaisie, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.cb_protocole, 0);
			base.Controls.SetChildIndex(this.tb_numPort, 0);
			base.Controls.SetChildIndex(this.label6, 0);
			base.Controls.SetChildIndex(this.tb_ordre, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x00044F74 File Offset: 0x00043F74
		public void init(Trs_station p_trs, bool lectureSeule)
		{
			this.trs = p_trs;
			base.init(this.trs.PortsEcoutes, lectureSeule, true);
			this.ToListe();
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x00044FA4 File Offset: 0x00043FA4
		protected override string genererLigne(ArrayList ligne)
		{
			return string.Concat(new object[]
			{
				ligne[0].ToString(),
				"\t",
				ligne[1],
				"\t\t",
				ligne[2]
			});
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x00044FF4 File Offset: 0x00043FF4
		protected override void ToListe()
		{
			base.ToListe();
			this.tb_ordre.Visible = false;
			this.tb_numPort.Visible = false;
			this.cb_protocole.Visible = false;
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x0004502C File Offset: 0x0004402C
		protected override void ToSaisie()
		{
			base.ToSaisie();
			this.tb_ordre.Text = (string)this.ligneEdit[0];
			this.cb_protocole.SelectedItem = this.ligneEdit[1].ToString();
			this.tb_numPort.Text = this.ligneEdit[2].ToString();
			this.tb_ordre.Visible = true;
			this.tb_numPort.Visible = true;
			this.cb_protocole.Visible = true;
			this.cb_protocole.Focus();
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x000450C4 File Offset: 0x000440C4
		protected override void renseignerNewLigne()
		{
			this.ligneEdit.Add(HashTableEdit.DeuxChiffres(this.table.Count + 1));
			this.ligneEdit.Add("TCP");
			this.ligneEdit.Add("1");
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x00045114 File Offset: 0x00044114
		public override void supprimerLigne(object objClef)
		{
			HashTableEdit.TriRemoveLigne(ref this.table, objClef);
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x00045130 File Offset: 0x00044130
		protected override void recupererLigne()
		{
			this.ligneEdit[0] = HashTableEdit.DeuxChiffres(int.Parse(this.tb_ordre.Text));
			this.ligneEdit[1] = this.cb_protocole.SelectedItem;
			this.ligneEdit[2] = this.tb_numPort.Text;
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x0004518C File Offset: 0x0004418C
		protected override bool ligneOk()
		{
			bool result;
			try
			{
				int.Parse(this.tb_numPort.Text);
				bool flag = true;
				foreach (object obj in this.table.Values)
				{
					ArrayList arrayList = (ArrayList)obj;
					if (arrayList[1].ToString() == this.cb_protocole.SelectedItem.ToString() && arrayList[2].ToString() == this.tb_numPort.Text)
					{
						flag = false;
						break;
					}
				}
				result = flag;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x0004526C File Offset: 0x0004426C
		public static bool Ecoute(SortedList portsEcoutes, string protocole, int numPort, int posProtocole, int posPort, bool reponse)
		{
			if (protocole == "ICMP" && !reponse)
			{
				return true;
			}
			bool result = false;
			foreach (object obj in portsEcoutes.Values)
			{
				ArrayList arrayList = (ArrayList)obj;
				if (arrayList[posProtocole].ToString() == protocole && arrayList[posPort].ToString() == numPort.ToString())
				{
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x00045314 File Offset: 0x00044314
		public static bool Ecoute(SortedList portsEcoutes, string protocole, int numPort, int posProtocole, int posPort, bool reponse, ref object clef)
		{
			bool result = false;
			foreach (object obj in portsEcoutes.Values)
			{
				ArrayList arrayList = (ArrayList)obj;
				if (arrayList[posProtocole].ToString() == protocole && arrayList[posPort].ToString() == numPort.ToString())
				{
					clef = arrayList[0];
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x04000487 RID: 1159
		private Label label2;

		// Token: 0x04000488 RID: 1160
		private Label label1;

		// Token: 0x04000489 RID: 1161
		private ComboBox cb_protocole;

		// Token: 0x0400048A RID: 1162
		private TextBox tb_numPort;

		// Token: 0x0400048B RID: 1163
		private TextBox tb_ordre;

		// Token: 0x0400048C RID: 1164
		private Label label6;

		// Token: 0x0400048D RID: 1165
		private IContainer components = null;

		// Token: 0x0400048E RID: 1166
		private Trs_station trs;
	}
}
