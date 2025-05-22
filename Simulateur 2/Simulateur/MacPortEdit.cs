using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000065 RID: 101
	public class MacPortEdit : HashTableEdit
	{
		// Token: 0x060005B7 RID: 1463 RVA: 0x00039BC0 File Offset: 0x00038BC0
		public MacPortEdit()
		{
			this.InitializeComponent();
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x00039BE0 File Offset: 0x00038BE0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x00039C0C File Offset: 0x00038C0C
		private void InitializeComponent()
		{
			ResourceManager resourceManager = new ResourceManager(typeof(MacPortEdit));
			this.bt_reintialiserTtl = new Button();
			this.ud_port = new NumericUpDown();
			this.tb_ttl = new TextBox();
			this.tb_adrMac = new TextBox();
			this.lbl_ttl = new Label();
			this.label2 = new Label();
			this.label1 = new Label();
			((ISupportInitialize)this.ud_port).BeginInit();
			base.SuspendLayout();
			this.lb_valeurs.Name = "lb_valeurs";
			this.lb_valeurs.Size = new Size(200, 56);
			this.bthte_modifier.Image = (Image)resourceManager.GetObject("bthte_modifier.Image");
			this.bthte_modifier.ImageIndex = -1;
			this.bthte_modifier.ImageList = null;
			this.bthte_modifier.Location = new Point(204, 60);
			this.bthte_modifier.Name = "bthte_modifier";
			this.bthte_supprimer.Image = (Image)resourceManager.GetObject("bthte_supprimer.Image");
			this.bthte_supprimer.ImageIndex = -1;
			this.bthte_supprimer.ImageList = null;
			this.bthte_supprimer.Location = new Point(204, 40);
			this.bthte_supprimer.Name = "bthte_supprimer";
			this.bthte_ajouter.Image = (Image)resourceManager.GetObject("bthte_ajouter.Image");
			this.bthte_ajouter.ImageIndex = -1;
			this.bthte_ajouter.ImageList = null;
			this.bthte_ajouter.Location = new Point(204, 20);
			this.bthte_ajouter.Name = "bthte_ajouter";
			this.bthte_annuler.Image = (Image)resourceManager.GetObject("bthte_annuler.Image");
			this.bthte_annuler.ImageIndex = -1;
			this.bthte_annuler.ImageList = null;
			this.bthte_annuler.Location = new Point(204, 0);
			this.bthte_annuler.Name = "bthte_annuler";
			this.bthte_annulerSaisie.Name = "bthte_annulerSaisie";
			this.bthte_validerSaisie.Name = "bthte_validerSaisie";
			this.bt_reintialiserTtl.Location = new Point(132, 56);
			this.bt_reintialiserTtl.Name = "bt_reintialiserTtl";
			this.bt_reintialiserTtl.Size = new Size(64, 20);
			this.bt_reintialiserTtl.TabIndex = 65;
			this.bt_reintialiserTtl.Text = "réinit. TTL";
			this.bt_reintialiserTtl.Click += this.bt_reintialiserTtl_Click;
			this.ud_port.Location = new Point(84, 20);
			NumericUpDown numericUpDown = this.ud_port;
			int[] array = new int[4];
			array[0] = 1;
			numericUpDown.Minimum = new decimal(array);
			this.ud_port.Name = "ud_port";
			this.ud_port.Size = new Size(40, 20);
			this.ud_port.TabIndex = 2;
			NumericUpDown numericUpDown2 = this.ud_port;
			array = new int[4];
			array[0] = 1;
			numericUpDown2.Value = new decimal(array);
			this.ud_port.ValueChanged += this.ud_port_ValueChanged;
			this.tb_ttl.Location = new Point(132, 20);
			this.tb_ttl.Name = "tb_ttl";
			this.tb_ttl.ReadOnly = true;
			this.tb_ttl.Size = new Size(60, 20);
			this.tb_ttl.TabIndex = 63;
			this.tb_ttl.TabStop = false;
			this.tb_ttl.Text = "";
			this.tb_adrMac.Location = new Point(0, 20);
			this.tb_adrMac.Name = "tb_adrMac";
			this.tb_adrMac.ReadOnly = true;
			this.tb_adrMac.Size = new Size(80, 20);
			this.tb_adrMac.TabIndex = 1;
			this.tb_adrMac.Text = "Clic sur la carte";
			this.tb_adrMac.TextChanged += this.tb_adrMac_TextChanged;
			this.tb_adrMac.Leave += this.tb_adrMac_Leave;
			this.tb_adrMac.Enter += this.tb_adrMac_Enter;
			this.lbl_ttl.Location = new Point(136, 4);
			this.lbl_ttl.Name = "lbl_ttl";
			this.lbl_ttl.Size = new Size(48, 16);
			this.lbl_ttl.TabIndex = 61;
			this.lbl_ttl.Text = "TTL";
			this.label2.Location = new Point(88, 4);
			this.label2.Name = "label2";
			this.label2.Size = new Size(48, 16);
			this.label2.TabIndex = 60;
			this.label2.Text = "Port";
			this.label1.Location = new Point(4, 4);
			this.label1.Name = "label1";
			this.label1.Size = new Size(60, 16);
			this.label1.TabIndex = 59;
			this.label1.Text = "Adresse";
			base.Controls.Add(this.bt_reintialiserTtl);
			base.Controls.Add(this.ud_port);
			base.Controls.Add(this.tb_ttl);
			base.Controls.Add(this.tb_adrMac);
			base.Controls.Add(this.lbl_ttl);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Name = "MacPortEdit";
			base.Size = new Size(220, 80);
			base.Controls.SetChildIndex(this.lb_valeurs, 0);
			base.Controls.SetChildIndex(this.bthte_modifier, 0);
			base.Controls.SetChildIndex(this.bthte_supprimer, 0);
			base.Controls.SetChildIndex(this.bthte_ajouter, 0);
			base.Controls.SetChildIndex(this.bthte_annuler, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.lbl_ttl, 0);
			base.Controls.SetChildIndex(this.tb_adrMac, 0);
			base.Controls.SetChildIndex(this.tb_ttl, 0);
			base.Controls.SetChildIndex(this.ud_port, 0);
			base.Controls.SetChildIndex(this.bt_reintialiserTtl, 0);
			base.Controls.SetChildIndex(this.bthte_validerSaisie, 0);
			base.Controls.SetChildIndex(this.bthte_annulerSaisie, 0);
			((ISupportInitialize)this.ud_port).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x0003A2EC File Offset: 0x000392EC
		public void init(Switch s, bool lectureSeule)
		{
			base.init(s.PortAdresseMac, lectureSeule, true);
			this.sw = s;
			this.ud_port.Maximum = s.NbPointsConnexion;
			this.ToListe();
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x0003A32C File Offset: 0x0003932C
		protected override string genererLigne(ArrayList ligne)
		{
			return string.Concat(new object[]
			{
				(string)ligne[0],
				"\t\t",
				((PortSwitch)ligne[1]).NumeroOrdre.ToString(),
				"\t",
				ligne[2]
			});
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x0003A38C File Offset: 0x0003938C
		protected override void ToListe()
		{
			base.ToListe();
			this.tb_adrMac.Visible = false;
			this.ud_port.Visible = false;
			this.tb_ttl.Visible = false;
			this.bt_reintialiserTtl.Visible = false;
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x0003A3D0 File Offset: 0x000393D0
		protected override void ToSaisie()
		{
			base.ToSaisie();
			if (base.Modification)
			{
				this.bt_reintialiserTtl.Visible = true;
			}
			else
			{
				this.bt_reintialiserTtl.Visible = false;
			}
			this.tb_adrMac.Text = (string)this.ligneEdit[0];
			this.ud_port.Value = ((PortSwitch)this.ligneEdit[1]).NumeroOrdre;
			this.tb_ttl.Text = this.ligneEdit[2].ToString();
			this.tb_adrMac.Visible = true;
			this.ud_port.Visible = true;
			this.tb_ttl.Visible = true;
			this.tb_adrMac.Focus();
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0003A494 File Offset: 0x00039494
		protected override void renseignerNewLigne()
		{
			this.ligneEdit.Add("Clic sur la carte");
			this.ligneEdit.Add(this.sw.Controls[0]);
			this.ligneEdit.Add(Switch.TtlSwitch.Maximum);
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0003A4E4 File Offset: 0x000394E4
		public void AjouterLigne(string adrMac, PortSwitch port)
		{
			this.table[adrMac] = new ArrayList();
			((ArrayList)this.table[adrMac]).Add(adrMac);
			((ArrayList)this.table[adrMac]).Add(port);
			((ArrayList)this.table[adrMac]).Add(Switch.TtlSwitch.Maximum);
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0003A550 File Offset: 0x00039550
		protected override void recupererLigne()
		{
			this.ligneEdit[0] = this.tb_adrMac.Text;
			this.ligneEdit[1] = this.sw.Controls[(int)this.ud_port.Value - 1];
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x0003A5A4 File Offset: 0x000395A4
		private void bt_reintialiserTtl_Click(object sender, EventArgs e)
		{
			this.ligneEdit[2] = Switch.TtlSwitch.Maximum;
			this.tb_ttl.Text = Switch.TtlSwitch.Maximum.ToString();
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x0003A5DC File Offset: 0x000395DC
		private void tb_adrMac_Enter(object sender, EventArgs e)
		{
			this.MacAttenteOn();
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x0003A5F0 File Offset: 0x000395F0
		private void tb_adrMac_Leave(object sender, EventArgs e)
		{
			this.MacAttenteOff();
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0003A604 File Offset: 0x00039604
		public void MacAttenteOn()
		{
			if (this.tb_adrMac.Focused)
			{
				this.sw.Reseau.AdrMacAttente = this.tb_adrMac;
			}
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x0003A634 File Offset: 0x00039634
		public void MacAttenteOff()
		{
			if (this.sw.Reseau.AdrMacAttente == this.tb_adrMac)
			{
				this.sw.Reseau.AdrMacAttente = null;
			}
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x0003A66C File Offset: 0x0003966C
		protected override void bthte_ajouter_Click(object sender, EventArgs e)
		{
			base.bthte_ajouter_Click(sender, e);
			this.bthte_validerSaisie.Enabled = false;
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x0003A690 File Offset: 0x00039690
		private void tb_adrMac_TextChanged(object sender, EventArgs e)
		{
			this.bthte_validerSaisie.Enabled = true;
			this.tb_adrMac.Focus();
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x0003A6B8 File Offset: 0x000396B8
		private void ud_port_ValueChanged(object sender, EventArgs e)
		{
			this.tb_adrMac.Focus();
		}

		// Token: 0x040003DB RID: 987
		private Button bt_reintialiserTtl;

		// Token: 0x040003DC RID: 988
		private NumericUpDown ud_port;

		// Token: 0x040003DD RID: 989
		private TextBox tb_ttl;

		// Token: 0x040003DE RID: 990
		private TextBox tb_adrMac;

		// Token: 0x040003DF RID: 991
		private Label lbl_ttl;

		// Token: 0x040003E0 RID: 992
		private Label label2;

		// Token: 0x040003E1 RID: 993
		private Label label1;

		// Token: 0x040003E2 RID: 994
		private IContainer components = null;

		// Token: 0x040003E3 RID: 995
		private Switch sw;
	}
}
