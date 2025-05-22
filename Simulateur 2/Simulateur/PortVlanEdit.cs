using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000079 RID: 121
	public class PortVlanEdit : HashTableEdit
	{
		// Token: 0x06000761 RID: 1889 RVA: 0x000453B4 File Offset: 0x000443B4
		public PortVlanEdit()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x000453D4 File Offset: 0x000443D4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x00045400 File Offset: 0x00044400
		private void InitializeComponent()
		{
			this.label2 = new Label();
			this.label1 = new Label();
			this.ud_port = new NumericUpDown();
			this.ud_vlan = new NumericUpDown();
			((ISupportInitialize)this.ud_port).BeginInit();
			((ISupportInitialize)this.ud_vlan).BeginInit();
			base.SuspendLayout();
			this.lb_valeurs.Name = "lb_valeurs";
			this.bthte_modifier.Name = "bthte_modifier";
			this.bthte_supprimer.Name = "bthte_supprimer";
			this.bthte_ajouter.Name = "bthte_ajouter";
			this.bthte_annuler.Name = "bthte_annuler";
			this.bthte_annulerSaisie.Name = "bthte_annulerSaisie";
			this.bthte_validerSaisie.Name = "bthte_validerSaisie";
			this.label2.Location = new Point(88, 4);
			this.label2.Name = "label2";
			this.label2.Size = new Size(48, 16);
			this.label2.TabIndex = 72;
			this.label2.Text = "Vlan";
			this.label1.Location = new Point(4, 4);
			this.label1.Name = "label1";
			this.label1.Size = new Size(60, 16);
			this.label1.TabIndex = 71;
			this.label1.Text = "Port";
			this.ud_port.Location = new Point(4, 24);
			NumericUpDown numericUpDown = this.ud_port;
			int[] array = new int[4];
			array[0] = 1;
			numericUpDown.Minimum = new decimal(array);
			this.ud_port.Name = "ud_port";
			this.ud_port.Size = new Size(40, 20);
			this.ud_port.TabIndex = 73;
			NumericUpDown numericUpDown2 = this.ud_port;
			array = new int[4];
			array[0] = 1;
			numericUpDown2.Value = new decimal(array);
			this.ud_vlan.Location = new Point(88, 24);
			NumericUpDown numericUpDown3 = this.ud_vlan;
			array = new int[4];
			array[0] = 9;
			numericUpDown3.Maximum = new decimal(array);
			NumericUpDown numericUpDown4 = this.ud_vlan;
			array = new int[4];
			array[0] = 1;
			numericUpDown4.Minimum = new decimal(array);
			this.ud_vlan.Name = "ud_vlan";
			this.ud_vlan.Size = new Size(40, 20);
			this.ud_vlan.TabIndex = 74;
			NumericUpDown numericUpDown5 = this.ud_vlan;
			array = new int[4];
			array[0] = 1;
			numericUpDown5.Value = new decimal(array);
			base.Controls.Add(this.ud_vlan);
			base.Controls.Add(this.ud_port);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Name = "PortVlanEdit";
			base.Controls.SetChildIndex(this.lb_valeurs, 0);
			base.Controls.SetChildIndex(this.bthte_modifier, 0);
			base.Controls.SetChildIndex(this.bthte_supprimer, 0);
			base.Controls.SetChildIndex(this.bthte_ajouter, 0);
			base.Controls.SetChildIndex(this.bthte_annuler, 0);
			base.Controls.SetChildIndex(this.bthte_validerSaisie, 0);
			base.Controls.SetChildIndex(this.bthte_annulerSaisie, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.ud_port, 0);
			base.Controls.SetChildIndex(this.ud_vlan, 0);
			((ISupportInitialize)this.ud_port).EndInit();
			((ISupportInitialize)this.ud_vlan).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x000457B4 File Offset: 0x000447B4
		public void init(Switch s, bool lectureSeule)
		{
			base.init(s.PortVlanNiv1, lectureSeule, false);
			this.sw = s;
			this.ud_port.Maximum = s.NbPointsConnexion - s.NbPorts8021q;
			this.ToListe();
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x000457FC File Offset: 0x000447FC
		protected override string genererLigne(ArrayList ligne)
		{
			return ligne[0].ToString() + "\t\t" + ligne[1];
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x00045828 File Offset: 0x00044828
		protected override void ToListe()
		{
			base.ToListe();
			this.ud_port.Visible = false;
			this.ud_vlan.Visible = false;
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x00045854 File Offset: 0x00044854
		protected override void ToSaisie()
		{
			base.ToSaisie();
			this.ud_port.Value = int.Parse(this.ligneEdit[0].ToString());
			this.ud_vlan.Value = int.Parse(this.ligneEdit[1].ToString());
			this.ud_port.Visible = true;
			this.ud_vlan.Visible = true;
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x000458CC File Offset: 0x000448CC
		protected override void renseignerNewLigne()
		{
			this.ligneEdit.Add(PortVlanEdit.numPortFormat(((PortSwitch)this.sw.Controls[0]).NumeroOrdre));
			this.ligneEdit.Add(1);
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x00045918 File Offset: 0x00044918
		public void AjouterLigne(int numPort, int vlan)
		{
			string text = PortVlanEdit.numPortFormat(numPort);
			this.table[text] = new ArrayList();
			((ArrayList)this.table[text]).Add(text);
			((ArrayList)this.table[text]).Add(vlan.ToString());
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x00045974 File Offset: 0x00044974
		protected override void recupererLigne()
		{
			this.ligneEdit[0] = PortVlanEdit.numPortFormat(((PortSwitch)this.sw.Controls[(int)this.ud_port.Value - 1]).NumeroOrdre);
			this.ligneEdit[1] = this.ud_vlan.Value;
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x000459DC File Offset: 0x000449DC
		public static string numPortFormat(int numPort)
		{
			if (numPort < 10)
			{
				return "0" + numPort.ToString();
			}
			return numPort.ToString();
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x00045A08 File Offset: 0x00044A08
		public static int GetNumVlan(SortedList table, int numPort)
		{
			string key = PortVlanEdit.numPortFormat(numPort);
			ArrayList arrayList = (ArrayList)table[key];
			return int.Parse(arrayList[1].ToString());
		}

		// Token: 0x0400048F RID: 1167
		private Label label2;

		// Token: 0x04000490 RID: 1168
		private Label label1;

		// Token: 0x04000491 RID: 1169
		private NumericUpDown ud_port;

		// Token: 0x04000492 RID: 1170
		private NumericUpDown ud_vlan;

		// Token: 0x04000493 RID: 1171
		private IContainer components = null;

		// Token: 0x04000494 RID: 1172
		private Switch sw;
	}
}
