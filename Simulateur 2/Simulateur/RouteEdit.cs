using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200007F RID: 127
	public class RouteEdit : HashTableEdit
	{
		// Token: 0x060007A9 RID: 1961 RVA: 0x00048EAC File Offset: 0x00047EAC
		public RouteEdit()
		{
			this.InitializeComponent();
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x00048ECC File Offset: 0x00047ECC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x00048EF8 File Offset: 0x00047EF8
		private void InitializeComponent()
		{
			ResourceManager resourceManager = new ResourceManager(typeof(RouteEdit));
			this.tb_adrDest = new TextBox();
			this.label1 = new Label();
			this.tb_masque = new TextBox();
			this.label2 = new Label();
			this.tb_passerelle = new TextBox();
			this.label3 = new Label();
			this.tb_interface = new TextBox();
			this.label4 = new Label();
			this.label5 = new Label();
			this.ud_metrique = new NumericUpDown();
			this.label6 = new Label();
			this.tb_ordre = new TextBox();
			((ISupportInitialize)this.ud_metrique).BeginInit();
			base.SuspendLayout();
			this.lb_valeurs.Name = "lb_valeurs";
			this.lb_valeurs.Size = new Size(468, 56);
			this.lb_valeurs.TabStop = false;
			this.bthte_modifier.Image = (Image)resourceManager.GetObject("bthte_modifier.Image");
			this.bthte_modifier.ImageIndex = -1;
			this.bthte_modifier.ImageList = null;
			this.bthte_modifier.Location = new Point(472, 60);
			this.bthte_modifier.Name = "bthte_modifier";
			this.bthte_modifier.TabIndex = 11;
			this.bthte_supprimer.Image = (Image)resourceManager.GetObject("bthte_supprimer.Image");
			this.bthte_supprimer.ImageIndex = -1;
			this.bthte_supprimer.ImageList = null;
			this.bthte_supprimer.Location = new Point(472, 40);
			this.bthte_supprimer.Name = "bthte_supprimer";
			this.bthte_supprimer.TabIndex = 10;
			this.bthte_ajouter.Image = (Image)resourceManager.GetObject("bthte_ajouter.Image");
			this.bthte_ajouter.ImageIndex = -1;
			this.bthte_ajouter.ImageList = null;
			this.bthte_ajouter.Location = new Point(472, 20);
			this.bthte_ajouter.Name = "bthte_ajouter";
			this.bthte_ajouter.TabIndex = 9;
			this.bthte_annuler.Image = (Image)resourceManager.GetObject("bthte_annuler.Image");
			this.bthte_annuler.ImageIndex = -1;
			this.bthte_annuler.ImageList = null;
			this.bthte_annuler.Location = new Point(472, 0);
			this.bthte_annuler.Name = "bthte_annuler";
			this.bthte_annuler.TabIndex = 8;
			this.bthte_annulerSaisie.Name = "bthte_annulerSaisie";
			this.bthte_annulerSaisie.TabIndex = 7;
			this.bthte_validerSaisie.Name = "bthte_validerSaisie";
			this.bthte_validerSaisie.TabIndex = 6;
			this.tb_adrDest.Location = new Point(40, 20);
			this.tb_adrDest.Name = "tb_adrDest";
			this.tb_adrDest.Size = new Size(88, 20);
			this.tb_adrDest.TabIndex = 1;
			this.tb_adrDest.Text = "255.255.255.255";
			this.label1.Location = new Point(48, 4);
			this.label1.Name = "label1";
			this.label1.Size = new Size(60, 16);
			this.label1.TabIndex = 59;
			this.label1.Text = "Adr Dest";
			this.tb_masque.Location = new Point(136, 20);
			this.tb_masque.Name = "tb_masque";
			this.tb_masque.Size = new Size(88, 20);
			this.tb_masque.TabIndex = 2;
			this.tb_masque.Text = "255.255.255.255";
			this.label2.Location = new Point(144, 4);
			this.label2.Name = "label2";
			this.label2.Size = new Size(60, 16);
			this.label2.TabIndex = 72;
			this.label2.Text = "Masque";
			this.tb_passerelle.Location = new Point(232, 20);
			this.tb_passerelle.Name = "tb_passerelle";
			this.tb_passerelle.Size = new Size(88, 20);
			this.tb_passerelle.TabIndex = 3;
			this.tb_passerelle.Text = "255.255.255.255";
			this.label3.Location = new Point(240, 4);
			this.label3.Name = "label3";
			this.label3.Size = new Size(60, 16);
			this.label3.TabIndex = 74;
			this.label3.Text = "Passerelle";
			this.tb_interface.Location = new Point(328, 20);
			this.tb_interface.Name = "tb_interface";
			this.tb_interface.Size = new Size(88, 20);
			this.tb_interface.TabIndex = 4;
			this.tb_interface.Text = "255.255.255.255";
			this.label4.Location = new Point(336, 4);
			this.label4.Name = "label4";
			this.label4.Size = new Size(60, 16);
			this.label4.TabIndex = 76;
			this.label4.Text = "Interface";
			this.label5.Location = new Point(420, 4);
			this.label5.Name = "label5";
			this.label5.Size = new Size(48, 16);
			this.label5.TabIndex = 78;
			this.label5.Text = "Métrique";
			this.ud_metrique.Location = new Point(424, 20);
			NumericUpDown numericUpDown = this.ud_metrique;
			int[] array = new int[4];
			array[0] = 16;
			numericUpDown.Maximum = new decimal(array);
			NumericUpDown numericUpDown2 = this.ud_metrique;
			array = new int[4];
			array[0] = 1;
			numericUpDown2.Minimum = new decimal(array);
			this.ud_metrique.Name = "ud_metrique";
			this.ud_metrique.Size = new Size(40, 20);
			this.ud_metrique.TabIndex = 5;
			NumericUpDown numericUpDown3 = this.ud_metrique;
			array = new int[4];
			array[0] = 1;
			numericUpDown3.Value = new decimal(array);
			this.label6.Location = new Point(4, 4);
			this.label6.Name = "label6";
			this.label6.Size = new Size(24, 16);
			this.label6.TabIndex = 80;
			this.label6.Text = "N°";
			this.tb_ordre.Location = new Point(4, 20);
			this.tb_ordre.Name = "tb_ordre";
			this.tb_ordre.Size = new Size(28, 20);
			this.tb_ordre.TabIndex = 81;
			this.tb_ordre.Text = "";
			base.Controls.Add(this.tb_ordre);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.ud_metrique);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.tb_interface);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.tb_passerelle);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.tb_masque);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.tb_adrDest);
			base.Controls.Add(this.label1);
			base.Name = "RouteEdit";
			base.Size = new Size(488, 80);
			base.Controls.SetChildIndex(this.lb_valeurs, 0);
			base.Controls.SetChildIndex(this.bthte_modifier, 0);
			base.Controls.SetChildIndex(this.bthte_supprimer, 0);
			base.Controls.SetChildIndex(this.bthte_ajouter, 0);
			base.Controls.SetChildIndex(this.bthte_annuler, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.tb_adrDest, 0);
			base.Controls.SetChildIndex(this.bthte_validerSaisie, 0);
			base.Controls.SetChildIndex(this.bthte_annulerSaisie, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.tb_masque, 0);
			base.Controls.SetChildIndex(this.label3, 0);
			base.Controls.SetChildIndex(this.tb_passerelle, 0);
			base.Controls.SetChildIndex(this.label4, 0);
			base.Controls.SetChildIndex(this.tb_interface, 0);
			base.Controls.SetChildIndex(this.label5, 0);
			base.Controls.SetChildIndex(this.ud_metrique, 0);
			base.Controls.SetChildIndex(this.label6, 0);
			base.Controls.SetChildIndex(this.tb_ordre, 0);
			((ISupportInitialize)this.ud_metrique).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x0004984C File Offset: 0x0004884C
		public void init(Ip_station p_ip, bool lectureSeule)
		{
			this.ip = p_ip;
			base.init(this.ip.Routes, lectureSeule, true);
			this.ToListe();
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x0004987C File Offset: 0x0004887C
		public void init(Ip_station p_ip, bool lectureSeule, bool p_tri)
		{
			this.ip = p_ip;
			base.init(this.ip.Routes, lectureSeule, true, p_tri);
			this.ToListe();
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x000498AC File Offset: 0x000488AC
		protected override string genererLigne(ArrayList ligne)
		{
			string str = (string)ligne[0] + "\t";
			str = str + Ip_quartet.FormatFixe((string)ligne[1]) + "\t";
			str = str + Ip_quartet.FormatFixe((string)ligne[2]) + "\t";
			str = str + Ip_quartet.FormatFixe((string)ligne[3]) + "\t";
			str = str + Ip_quartet.FormatFixe((string)ligne[4]) + "\t";
			return str + (string)ligne[5];
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x00049958 File Offset: 0x00048958
		protected override void ToListe()
		{
			base.ToListe();
			this.tb_ordre.Visible = false;
			this.tb_adrDest.Visible = false;
			this.tb_masque.Visible = false;
			this.tb_passerelle.Visible = false;
			this.tb_interface.Visible = false;
			this.ud_metrique.Visible = false;
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x000499B4 File Offset: 0x000489B4
		protected override void ToSaisie()
		{
			base.ToSaisie();
			this.tb_ordre.Text = (string)this.ligneEdit[0];
			this.tb_adrDest.Text = ((string)this.ligneEdit[1]).Trim();
			this.tb_masque.Text = ((string)this.ligneEdit[2]).Trim();
			this.tb_passerelle.Text = ((string)this.ligneEdit[3]).Trim();
			this.tb_interface.Text = ((string)this.ligneEdit[4]).Trim();
			this.ud_metrique.Value = int.Parse(this.ligneEdit[5].ToString());
			this.tb_ordre.Visible = true;
			this.tb_adrDest.Visible = true;
			this.tb_masque.Visible = true;
			this.tb_passerelle.Visible = true;
			this.tb_interface.Visible = true;
			this.ud_metrique.Visible = true;
			this.tb_adrDest.Focus();
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x00049AE4 File Offset: 0x00048AE4
		protected override void renseignerNewLigne()
		{
			int val = 1;
			if (this.table.Count > 0)
			{
				ArrayList arrayList = (ArrayList)this.table.GetByIndex(this.table.Count - 1);
				if (arrayList[1].ToString().Trim() == "0.0.0.0")
				{
					val = this.table.Count;
				}
				else
				{
					val = this.table.Count + 1;
				}
			}
			this.ligneEdit.Add(HashTableEdit.DeuxChiffres(val));
			this.ligneEdit.Add(Ip_quartet.FormatFixe("0.0.0.0"));
			this.ligneEdit.Add(Ip_quartet.FormatFixe("0.0.0.0"));
			this.ligneEdit.Add(Ip_quartet.FormatFixe("0.0.0.0"));
			this.ligneEdit.Add(Ip_quartet.FormatFixe("0.0.0.0"));
			this.ligneEdit.Add("1");
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x00049BD4 File Offset: 0x00048BD4
		protected override void recupererLigne()
		{
			this.ligneEdit[0] = HashTableEdit.DeuxChiffres(int.Parse(this.tb_ordre.Text));
			this.ligneEdit[1] = Ip_quartet.FormatFixe(this.tb_adrDest.Text);
			this.ligneEdit[2] = Ip_quartet.FormatFixe(this.tb_masque.Text);
			this.ligneEdit[3] = Ip_quartet.FormatFixe(this.tb_passerelle.Text);
			this.ligneEdit[4] = Ip_quartet.FormatFixe(this.tb_interface.Text);
			this.ligneEdit[5] = ((int)this.ud_metrique.Value).ToString();
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x00049C98 File Offset: 0x00048C98
		protected override bool ligneOk()
		{
			if (!Ip_adresse.Ok(this.tb_adrDest.Text))
			{
				return false;
			}
			if (!Ip_quartet.Ok(this.tb_masque.Text) || !Ip_quartet.MasqueOk(this.tb_masque.Text))
			{
				return false;
			}
			if (!Ip_adresse.Ok(this.tb_passerelle.Text))
			{
				return false;
			}
			if (Ip_quartet.Isnul(this.tb_passerelle.Text))
			{
				return false;
			}
			if (!Ip_adresse.Ok(this.tb_interface.Text))
			{
				return false;
			}
			if (Ip_quartet.Isnul(this.tb_interface.Text))
			{
				return false;
			}
			CarteReseau carteReseau = this.ip.TrouverCarteIp(this.tb_interface.Text);
			if (carteReseau == null)
			{
				return false;
			}
			if (!Ip_quartet.MemeReseau(this.tb_passerelle.Text, this.tb_interface.Text, carteReseau.Ip.Masque.ToString()))
			{
				return false;
			}
			if (Ip_quartet.Isnul(this.tb_adrDest.Text))
			{
				if (!Ip_quartet.Isnul(this.tb_masque.Text))
				{
					return false;
				}
				((Station)carteReseau.NoeudAttache).Ip.Passerelle = new Ip_adresse(this.tb_passerelle.Text);
				((Station)carteReseau.NoeudAttache).SetContenuInfoBulle();
			}
			return true;
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x00049DD8 File Offset: 0x00048DD8
		public override void supprimerLigne(object objClef)
		{
			HashTableEdit.TriRemoveLigne(ref this.table, objClef);
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x00049DF4 File Offset: 0x00048DF4
		public static string GetAdrDest(ArrayList route)
		{
			return route[1].ToString().Trim();
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x00049E14 File Offset: 0x00048E14
		public static string GetMasque(ArrayList route)
		{
			return route[2].ToString().Trim();
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x00049E34 File Offset: 0x00048E34
		public static string GetPasserelle(ArrayList route)
		{
			return route[3].ToString().Trim();
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x00049E54 File Offset: 0x00048E54
		public static string GetInterface(ArrayList route)
		{
			return route[4].ToString().Trim();
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x00049E74 File Offset: 0x00048E74
		public static ArrayList GetRoutePasserelle(SortedList routes)
		{
			if (routes.Count <= 0)
			{
				return null;
			}
			ArrayList arrayList = (ArrayList)routes[HashTableEdit.DeuxChiffres(routes.Count)];
			if (RouteEdit.GetAdrDest(arrayList).Trim() == "0.0.0.0")
			{
				return arrayList;
			}
			return null;
		}

		// Token: 0x040004C2 RID: 1218
		private Label label1;

		// Token: 0x040004C3 RID: 1219
		private TextBox tb_adrDest;

		// Token: 0x040004C4 RID: 1220
		private TextBox tb_masque;

		// Token: 0x040004C5 RID: 1221
		private Label label2;

		// Token: 0x040004C6 RID: 1222
		private TextBox tb_passerelle;

		// Token: 0x040004C7 RID: 1223
		private Label label3;

		// Token: 0x040004C8 RID: 1224
		private TextBox tb_interface;

		// Token: 0x040004C9 RID: 1225
		private Label label4;

		// Token: 0x040004CA RID: 1226
		private Label label5;

		// Token: 0x040004CB RID: 1227
		private NumericUpDown ud_metrique;

		// Token: 0x040004CC RID: 1228
		private Label label6;

		// Token: 0x040004CD RID: 1229
		private TextBox tb_ordre;

		// Token: 0x040004CE RID: 1230
		private IContainer components = null;

		// Token: 0x040004CF RID: 1231
		private Ip_station ip;
	}
}
