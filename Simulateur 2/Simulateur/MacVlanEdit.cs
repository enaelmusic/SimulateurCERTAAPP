using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000066 RID: 102
	public class MacVlanEdit : HashTableEdit
	{
		// Token: 0x060005C9 RID: 1481 RVA: 0x0003A6D4 File Offset: 0x000396D4
		public MacVlanEdit()
		{
			this.InitializeComponent();
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0003A6F4 File Offset: 0x000396F4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0003A720 File Offset: 0x00039720
		private void InitializeComponent()
		{
			this.ud_vlan = new NumericUpDown();
			this.tb_adrMac = new TextBox();
			this.label2 = new Label();
			this.label1 = new Label();
			((ISupportInitialize)this.ud_vlan).BeginInit();
			base.SuspendLayout();
			this.lb_valeurs.Name = "lb_valeurs";
			this.bthte_modifier.Name = "bthte_modifier";
			this.bthte_supprimer.Name = "bthte_supprimer";
			this.bthte_ajouter.Name = "bthte_ajouter";
			this.bthte_annuler.Name = "bthte_annuler";
			this.bthte_annulerSaisie.Name = "bthte_annulerSaisie";
			this.bthte_validerSaisie.Name = "bthte_validerSaisie";
			this.ud_vlan.Location = new Point(88, 20);
			NumericUpDown numericUpDown = this.ud_vlan;
			int[] array = new int[4];
			array[0] = 10;
			numericUpDown.Maximum = new decimal(array);
			NumericUpDown numericUpDown2 = this.ud_vlan;
			array = new int[4];
			array[0] = 2;
			numericUpDown2.Minimum = new decimal(array);
			this.ud_vlan.Name = "ud_vlan";
			this.ud_vlan.Size = new Size(40, 20);
			this.ud_vlan.TabIndex = 72;
			NumericUpDown numericUpDown3 = this.ud_vlan;
			array = new int[4];
			array[0] = 2;
			numericUpDown3.Value = new decimal(array);
			this.ud_vlan.ValueChanged += this.ud_vlan_ValueChanged;
			this.tb_adrMac.Location = new Point(4, 20);
			this.tb_adrMac.Name = "tb_adrMac";
			this.tb_adrMac.ReadOnly = true;
			this.tb_adrMac.Size = new Size(80, 20);
			this.tb_adrMac.TabIndex = 71;
			this.tb_adrMac.Text = "Clic sur la carte";
			this.tb_adrMac.TextChanged += this.tb_adrMac_TextChanged;
			this.tb_adrMac.Leave += this.tb_adrMac_Leave;
			this.tb_adrMac.Enter += this.tb_adrMac_Enter;
			this.label2.Location = new Point(92, 4);
			this.label2.Name = "label2";
			this.label2.Size = new Size(48, 16);
			this.label2.TabIndex = 74;
			this.label2.Text = "Vlan";
			this.label1.Location = new Point(8, 4);
			this.label1.Name = "label1";
			this.label1.Size = new Size(60, 16);
			this.label1.TabIndex = 73;
			this.label1.Text = "Adresse";
			base.Controls.Add(this.ud_vlan);
			base.Controls.Add(this.tb_adrMac);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Name = "MacVlanEdit";
			base.Controls.SetChildIndex(this.lb_valeurs, 0);
			base.Controls.SetChildIndex(this.bthte_modifier, 0);
			base.Controls.SetChildIndex(this.bthte_supprimer, 0);
			base.Controls.SetChildIndex(this.bthte_ajouter, 0);
			base.Controls.SetChildIndex(this.bthte_annuler, 0);
			base.Controls.SetChildIndex(this.bthte_validerSaisie, 0);
			base.Controls.SetChildIndex(this.bthte_annulerSaisie, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.tb_adrMac, 0);
			base.Controls.SetChildIndex(this.ud_vlan, 0);
			((ISupportInitialize)this.ud_vlan).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x0003AB00 File Offset: 0x00039B00
		public void init(Switch s, bool lectureSeule)
		{
			base.init(s.MacVlanNiv2, lectureSeule, true);
			this.sw = s;
			this.ToListe();
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x0003AB28 File Offset: 0x00039B28
		protected override string genererLigne(ArrayList ligne)
		{
			return ligne[0].ToString() + "\t\t" + ligne[1];
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x0003AB54 File Offset: 0x00039B54
		protected override void ToListe()
		{
			base.ToListe();
			this.tb_adrMac.Visible = false;
			this.ud_vlan.Visible = false;
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x0003AB80 File Offset: 0x00039B80
		protected override void ToSaisie()
		{
			base.ToSaisie();
			this.tb_adrMac.Text = (string)this.ligneEdit[0];
			this.ud_vlan.Value = int.Parse((string)this.ligneEdit[1]);
			this.tb_adrMac.Visible = true;
			this.ud_vlan.Visible = true;
			this.tb_adrMac.Focus();
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x0003ABFC File Offset: 0x00039BFC
		protected override void renseignerNewLigne()
		{
			this.ligneEdit.Add("Clic sur la carte");
			this.ligneEdit.Add("2");
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x0003AC2C File Offset: 0x00039C2C
		public void AjouterLigne(string adrMac, int numVlan)
		{
			this.table[adrMac] = new ArrayList();
			((ArrayList)this.table[adrMac]).Add(adrMac);
			((ArrayList)this.table[adrMac]).Add(numVlan.ToString());
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x0003AC80 File Offset: 0x00039C80
		protected override void recupererLigne()
		{
			this.ligneEdit[0] = this.tb_adrMac.Text;
			this.ligneEdit[1] = this.ud_vlan.Value.ToString();
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x0003ACC4 File Offset: 0x00039CC4
		private void tb_adrMac_Enter(object sender, EventArgs e)
		{
			this.MacAttenteOn();
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x0003ACD8 File Offset: 0x00039CD8
		private void tb_adrMac_Leave(object sender, EventArgs e)
		{
			this.MacAttenteOff();
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x0003ACEC File Offset: 0x00039CEC
		public void MacAttenteOn()
		{
			if (this.tb_adrMac.Focused)
			{
				this.sw.Reseau.AdrMacAttente = this.tb_adrMac;
			}
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x0003AD1C File Offset: 0x00039D1C
		public void MacAttenteOff()
		{
			if (this.sw.Reseau.AdrMacAttente == this.tb_adrMac)
			{
				this.sw.Reseau.AdrMacAttente = null;
			}
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x0003AD54 File Offset: 0x00039D54
		private void ud_vlan_ValueChanged(object sender, EventArgs e)
		{
			this.tb_adrMac.Focus();
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x0003AD70 File Offset: 0x00039D70
		protected override void bthte_ajouter_Click(object sender, EventArgs e)
		{
			base.bthte_ajouter_Click(sender, e);
			this.bthte_validerSaisie.Enabled = false;
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x0003AD94 File Offset: 0x00039D94
		private void tb_adrMac_TextChanged(object sender, EventArgs e)
		{
			this.bthte_validerSaisie.Enabled = true;
			this.tb_adrMac.Focus();
		}

		// Token: 0x040003E4 RID: 996
		private TextBox tb_adrMac;

		// Token: 0x040003E5 RID: 997
		private Label label2;

		// Token: 0x040003E6 RID: 998
		private Label label1;

		// Token: 0x040003E7 RID: 999
		private NumericUpDown ud_vlan;

		// Token: 0x040003E8 RID: 1000
		private IContainer components = null;

		// Token: 0x040003E9 RID: 1001
		private Switch sw;
	}
}
