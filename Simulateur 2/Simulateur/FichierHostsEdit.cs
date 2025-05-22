using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000046 RID: 70
	public class FichierHostsEdit : HashTableEdit
	{
		// Token: 0x060003AC RID: 940 RVA: 0x0002A974 File Offset: 0x00029974
		public FichierHostsEdit()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0002A994 File Offset: 0x00029994
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0002A9C0 File Offset: 0x000299C0
		private void InitializeComponent()
		{
			this.tb_adrIp = new TextBox();
			this.tb_nomHote = new TextBox();
			this.label2 = new Label();
			this.label1 = new Label();
			base.SuspendLayout();
			this.lb_valeurs.Name = "lb_valeurs";
			this.lb_valeurs.Size = new Size(296, 56);
			this.bthte_modifier.Location = new Point(300, 60);
			this.bthte_modifier.Name = "bthte_modifier";
			this.bthte_supprimer.Location = new Point(300, 40);
			this.bthte_supprimer.Name = "bthte_supprimer";
			this.bthte_ajouter.Location = new Point(300, 20);
			this.bthte_ajouter.Name = "bthte_ajouter";
			this.bthte_annuler.Location = new Point(300, 0);
			this.bthte_annuler.Name = "bthte_annuler";
			this.bthte_annulerSaisie.Name = "bthte_annulerSaisie";
			this.bthte_validerSaisie.Name = "bthte_validerSaisie";
			this.tb_adrIp.Location = new Point(4, 24);
			this.tb_adrIp.Name = "tb_adrIp";
			this.tb_adrIp.Size = new Size(88, 20);
			this.tb_adrIp.TabIndex = 0;
			this.tb_adrIp.Text = "";
			this.tb_nomHote.Location = new Point(92, 24);
			this.tb_nomHote.Name = "tb_nomHote";
			this.tb_nomHote.Size = new Size(200, 20);
			this.tb_nomHote.TabIndex = 1;
			this.tb_nomHote.Text = "";
			this.label2.Location = new Point(100, 4);
			this.label2.Name = "label2";
			this.label2.Size = new Size(76, 16);
			this.label2.TabIndex = 74;
			this.label2.Text = "Nom d'hôte";
			this.label1.Location = new Point(4, 4);
			this.label1.Name = "label1";
			this.label1.Size = new Size(60, 16);
			this.label1.TabIndex = 73;
			this.label1.Text = "Adresse IP";
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.tb_nomHote);
			base.Controls.Add(this.tb_adrIp);
			base.Name = "FichierHostsEdit";
			base.Size = new Size(316, 80);
			base.Controls.SetChildIndex(this.lb_valeurs, 0);
			base.Controls.SetChildIndex(this.tb_adrIp, 0);
			base.Controls.SetChildIndex(this.bthte_modifier, 0);
			base.Controls.SetChildIndex(this.bthte_supprimer, 0);
			base.Controls.SetChildIndex(this.bthte_ajouter, 0);
			base.Controls.SetChildIndex(this.bthte_annuler, 0);
			base.Controls.SetChildIndex(this.bthte_validerSaisie, 0);
			base.Controls.SetChildIndex(this.bthte_annulerSaisie, 0);
			base.Controls.SetChildIndex(this.tb_nomHote, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0002AD60 File Offset: 0x00029D60
		public void init(Ip_station p_ipSt, bool lectureSeule)
		{
			this.ipSt = p_ipSt;
			base.init(this.ipSt.FichierHosts, lectureSeule, true);
			int[] array = new int[]
			{
				70
			};
			HashTableEdit.SendMessage(this.lb_valeurs.Handle, base.LB_SETTABSTOPS, array.Length, array);
			this.ToListe();
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0002ADB8 File Offset: 0x00029DB8
		protected override string genererLigne(ArrayList ligne)
		{
			return ligne[1].ToString() + "\t" + ligne[0];
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0002ADE4 File Offset: 0x00029DE4
		protected override void ToListe()
		{
			base.ToListe();
			this.tb_adrIp.Visible = false;
			this.tb_nomHote.Visible = false;
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0002AE10 File Offset: 0x00029E10
		protected override void ToSaisie()
		{
			base.ToSaisie();
			this.tb_nomHote.Text = this.ligneEdit[0].ToString();
			this.tb_adrIp.Text = this.ligneEdit[1].ToString();
			this.tb_adrIp.Visible = true;
			this.tb_nomHote.Visible = true;
			this.tb_adrIp.Focus();
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0002AE80 File Offset: 0x00029E80
		protected override void renseignerNewLigne()
		{
			this.ligneEdit.Add("");
			this.ligneEdit.Add("");
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0002AEB0 File Offset: 0x00029EB0
		public void AjouterLigne(string adr, string nom)
		{
			this.table[nom] = new ArrayList();
			((ArrayList)this.table[nom]).Add(nom);
			((ArrayList)this.table[nom]).Add(adr);
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0002AF00 File Offset: 0x00029F00
		protected override void recupererLigne()
		{
			this.ligneEdit[0] = this.tb_nomHote.Text;
			this.ligneEdit[1] = this.tb_adrIp.Text;
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0002AF3C File Offset: 0x00029F3C
		public static string GetAdrIp(SortedList hosts, string nom)
		{
			if (hosts.ContainsKey(nom))
			{
				return ((ArrayList)hosts[nom])[1].ToString();
			}
			return "";
		}

		// Token: 0x040002E2 RID: 738
		private TextBox tb_adrIp;

		// Token: 0x040002E3 RID: 739
		private TextBox tb_nomHote;

		// Token: 0x040002E4 RID: 740
		private Label label2;

		// Token: 0x040002E5 RID: 741
		private Label label1;

		// Token: 0x040002E6 RID: 742
		private IContainer components = null;

		// Token: 0x040002E7 RID: 743
		private Ip_station ipSt;
	}
}
