using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;

namespace Simulateur
{
	// Token: 0x0200000C RID: 12
	public class HashTableEdit : UserControl
	{
		// Token: 0x060000A3 RID: 163
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int[] lParam);

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00006290 File Offset: 0x00005290
		public int LB_SETTABSTOPS
		{
			get
			{
				return 402;
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000062A4 File Offset: 0x000052A4
		public HashTableEdit()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000062DC File Offset: 0x000052DC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00006308 File Offset: 0x00005308
		private void InitializeComponent()
		{
			this.components = new Container();
			ResourceManager resourceManager = new ResourceManager(typeof(HashTableEdit));
			this.lb_valeurs = new ListBox();
			this.bthte_modifier = new Button();
			this.il_images = new ImageList(this.components);
			this.bthte_supprimer = new Button();
			this.bthte_ajouter = new Button();
			this.bthte_annuler = new Button();
			this.bthte_annulerSaisie = new Button();
			this.bthte_validerSaisie = new Button();
			this.tmpFocus = new TextBox();
			base.SuspendLayout();
			this.lb_valeurs.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.lb_valeurs.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lb_valeurs.ForeColor = SystemColors.WindowText;
			this.lb_valeurs.Location = new Point(0, 20);
			this.lb_valeurs.Name = "lb_valeurs";
			this.lb_valeurs.Size = new Size(208, 56);
			this.lb_valeurs.TabIndex = 33;
			this.lb_valeurs.DoubleClick += this.lb_valeurs_DoubleClick;
			this.lb_valeurs.Enter += this.lb_valeurs_Enter;
			this.bthte_modifier.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.bthte_modifier.ImageIndex = 3;
			this.bthte_modifier.ImageList = this.il_images;
			this.bthte_modifier.Location = new Point(212, 60);
			this.bthte_modifier.Name = "bthte_modifier";
			this.bthte_modifier.Size = new Size(16, 16);
			this.bthte_modifier.TabIndex = 34;
			this.bthte_modifier.Click += this.bthte_modifier_Click;
			this.il_images.ImageSize = new Size(16, 16);
			this.il_images.ImageStream = (ImageListStreamer)resourceManager.GetObject("il_images.ImageStream");
			this.il_images.TransparentColor = Color.White;
			this.bthte_supprimer.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.bthte_supprimer.ImageIndex = 2;
			this.bthte_supprimer.ImageList = this.il_images;
			this.bthte_supprimer.Location = new Point(212, 40);
			this.bthte_supprimer.Name = "bthte_supprimer";
			this.bthte_supprimer.Size = new Size(16, 16);
			this.bthte_supprimer.TabIndex = 35;
			this.bthte_supprimer.Click += this.bthte_supprimer_Click;
			this.bthte_ajouter.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.bthte_ajouter.ImageIndex = 1;
			this.bthte_ajouter.ImageList = this.il_images;
			this.bthte_ajouter.Location = new Point(212, 20);
			this.bthte_ajouter.Name = "bthte_ajouter";
			this.bthte_ajouter.Size = new Size(16, 16);
			this.bthte_ajouter.TabIndex = 36;
			this.bthte_ajouter.Click += this.bthte_ajouter_Click;
			this.bthte_annuler.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.bthte_annuler.ImageIndex = 0;
			this.bthte_annuler.ImageList = this.il_images;
			this.bthte_annuler.Location = new Point(212, 0);
			this.bthte_annuler.Name = "bthte_annuler";
			this.bthte_annuler.Size = new Size(16, 16);
			this.bthte_annuler.TabIndex = 37;
			this.bthte_annuler.Click += this.bthte_annuler_Click;
			this.bthte_annulerSaisie.Location = new Point(60, 56);
			this.bthte_annulerSaisie.Name = "bthte_annulerSaisie";
			this.bthte_annulerSaisie.Size = new Size(52, 20);
			this.bthte_annulerSaisie.TabIndex = 69;
			this.bthte_annulerSaisie.Text = "annuler";
			this.bthte_annulerSaisie.Click += this.bthte_annulerSaisie_Click;
			this.bthte_validerSaisie.Location = new Point(4, 56);
			this.bthte_validerSaisie.Name = "bthte_validerSaisie";
			this.bthte_validerSaisie.Size = new Size(48, 20);
			this.bthte_validerSaisie.TabIndex = 68;
			this.bthte_validerSaisie.Text = "valider";
			this.bthte_validerSaisie.Click += this.bthte_validerSaisie_Click;
			this.tmpFocus.Location = new Point(0, 0);
			this.tmpFocus.Name = "tmpFocus";
			this.tmpFocus.Size = new Size(0, 20);
			this.tmpFocus.TabIndex = 70;
			this.tmpFocus.Text = "";
			base.Controls.Add(this.tmpFocus);
			base.Controls.Add(this.bthte_annulerSaisie);
			base.Controls.Add(this.bthte_validerSaisie);
			base.Controls.Add(this.bthte_annuler);
			base.Controls.Add(this.bthte_ajouter);
			base.Controls.Add(this.bthte_supprimer);
			base.Controls.Add(this.bthte_modifier);
			base.Controls.Add(this.lb_valeurs);
			base.Name = "HashTableEdit";
			base.Size = new Size(228, 80);
			base.ResumeLayout(false);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00006888 File Offset: 0x00005888
		public static SortedList CopieProfonde(SortedList sl)
		{
			SortedList sortedList = new SortedList();
			foreach (object obj in sl.Values)
			{
				ArrayList arrayList = (ArrayList)obj;
				sortedList.Add(arrayList[0].ToString(), arrayList.Clone());
			}
			return sortedList;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00006908 File Offset: 0x00005908
		public void init(SortedList ht, bool lectureSeule, bool ajoutSupp)
		{
			this.tableInitiale = ht;
			this.lb_valeurs.Items.Clear();
			this.table = HashTableEdit.CopieProfonde(ht);
			this.remplirListe();
			this.lectureSeule = lectureSeule;
			if (!ajoutSupp)
			{
				this.bthte_ajouter.Enabled = false;
				this.bthte_supprimer.Enabled = false;
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00006960 File Offset: 0x00005960
		public void init(SortedList ht, bool lectureSeule, bool ajoutSupp, bool p_tri)
		{
			this.init(ht, lectureSeule, ajoutSupp);
			this.tri = p_tri;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00006980 File Offset: 0x00005980
		public void ChangerMode(bool lectureSeule)
		{
			this.lectureSeule = lectureSeule;
			this.ToListe();
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000AC RID: 172 RVA: 0x0000699C File Offset: 0x0000599C
		public bool LectureSeule
		{
			get
			{
				return this.lectureSeule;
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000069B0 File Offset: 0x000059B0
		public SortedList GetTable()
		{
			return this.table;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000069C4 File Offset: 0x000059C4
		public void SetTable(SortedList l)
		{
			this.table = l;
			this.remplirListe();
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000069E0 File Offset: 0x000059E0
		protected void remplirListe()
		{
			this.cles.Clear();
			this.lb_valeurs.Items.Clear();
			foreach (object obj in this.table.Values)
			{
				ArrayList arrayList = (ArrayList)obj;
				this.cles.Add(arrayList[0]);
				this.lb_valeurs.Items.Add(this.genererLigne(arrayList));
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00006A8C File Offset: 0x00005A8C
		public void Maj()
		{
			this.remplirListe();
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00006AA0 File Offset: 0x00005AA0
		protected virtual void ToSaisie()
		{
			this.lb_valeurs.Visible = false;
			this.bthte_ajouter.Visible = false;
			this.bthte_annuler.Visible = false;
			this.bthte_modifier.Visible = false;
			this.bthte_supprimer.Visible = false;
			this.bthte_annulerSaisie.Visible = true;
			this.bthte_validerSaisie.Visible = true;
			if (this.DebutEdition != null)
			{
				this.DebutEdition(this, null);
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00006B18 File Offset: 0x00005B18
		protected virtual void ToListe()
		{
			this.lb_valeurs.Visible = true;
			if (this.lectureSeule)
			{
				this.bthte_ajouter.Visible = false;
				this.bthte_annuler.Visible = false;
				this.bthte_modifier.Visible = false;
				this.bthte_supprimer.Visible = false;
				this.bthte_annulerSaisie.Visible = false;
				this.bthte_validerSaisie.Visible = false;
			}
			else
			{
				this.bthte_ajouter.Visible = true;
				this.bthte_annuler.Visible = true;
				this.bthte_modifier.Visible = true;
				this.bthte_supprimer.Visible = true;
				this.bthte_annulerSaisie.Visible = false;
				this.bthte_validerSaisie.Visible = false;
			}
			if (this.FinEdition != null)
			{
				this.FinEdition(this, null);
			}
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00006BE0 File Offset: 0x00005BE0
		public ArrayList htLigne(int index)
		{
			return (ArrayList)this.table[this.cles[index]];
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00006C0C File Offset: 0x00005C0C
		public int IndexOf(object clef)
		{
			return this.cles.IndexOf(clef);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00006C28 File Offset: 0x00005C28
		public void selectIndex(int index)
		{
			this.lb_valeurs.SelectedIndex = index;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00006C44 File Offset: 0x00005C44
		public void SetModeSelection(SelectionMode mode)
		{
			this.lb_valeurs.SelectionMode = mode;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00006C60 File Offset: 0x00005C60
		public void SetSelectedIndexMultiple(int index, bool selected)
		{
			this.lb_valeurs.SetSelected(index, selected);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00006C7C File Offset: 0x00005C7C
		public void ClearSelectionMultiple()
		{
			this.lb_valeurs.ClearSelected();
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00006C94 File Offset: 0x00005C94
		protected virtual string genererLigne(ArrayList ligne)
		{
			return "";
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00006CA8 File Offset: 0x00005CA8
		protected bool Modification
		{
			get
			{
				return this.modification;
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00006CBC File Offset: 0x00005CBC
		protected virtual void bthte_modifier_Click(object sender, EventArgs e)
		{
			if (this.lb_valeurs.SelectedIndex != -1)
			{
				this.modification = true;
				this.ligneEdit = (ArrayList)this.htLigne(this.lb_valeurs.SelectedIndex).Clone();
				this.ancienneClef = (string)this.ligneEdit[0];
				if (this.tri)
				{
					this.ancienneClefTri = (string)this.ligneEdit[1];
				}
				this.ToSaisie();
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00006D3C File Offset: 0x00005D3C
		protected virtual void bthte_supprimer_Click(object sender, EventArgs e)
		{
			if (this.lb_valeurs.SelectedIndex != -1)
			{
				this.supprimerLigne(this.cles[this.lb_valeurs.SelectedIndex]);
				this.remplirListe();
				return;
			}
			this.table.Clear();
			this.remplirListe();
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00006D8C File Offset: 0x00005D8C
		protected virtual void renseignerNewLigne()
		{
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00006D9C File Offset: 0x00005D9C
		public virtual void supprimerLigne(object clef)
		{
			this.table.Remove(clef);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00006DB8 File Offset: 0x00005DB8
		protected virtual void bthte_ajouter_Click(object sender, EventArgs e)
		{
			this.modification = false;
			this.ligneEdit = new ArrayList();
			this.renseignerNewLigne();
			this.ToSaisie();
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00006DE4 File Offset: 0x00005DE4
		private void bthte_annuler_Click(object sender, EventArgs e)
		{
			this.lb_valeurs.Items.Clear();
			this.table = (SortedList)this.tableInitiale.Clone();
			this.remplirListe();
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00006E20 File Offset: 0x00005E20
		public static bool Identiques(ArrayList a1, ArrayList a2)
		{
			bool flag = a1.Count == a2.Count;
			int num = 0;
			while (num < a1.Count && flag)
			{
				flag = (a1[num].ToString().Trim() == a2[num].ToString().Trim());
				num++;
			}
			return flag;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00006E7C File Offset: 0x00005E7C
		public static bool Identiques(SortedList h1, SortedList h2)
		{
			if (h1.Count == h2.Count)
			{
				foreach (object key in h1.Keys)
				{
					if (!h2.ContainsKey(key) || !HashTableEdit.Identiques((ArrayList)h1[key], (ArrayList)h2[key]))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00006F14 File Offset: 0x00005F14
		public bool Nochange()
		{
			return HashTableEdit.Identiques(this.table, this.tableInitiale);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00006F34 File Offset: 0x00005F34
		private void bthte_annulerSaisie_Click(object sender, EventArgs e)
		{
			this.ToListe();
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00006F48 File Offset: 0x00005F48
		protected virtual void recupererLigne()
		{
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00006F58 File Offset: 0x00005F58
		private void bthte_validerSaisie_Click(object sender, EventArgs e)
		{
			if (this.ligneOk())
			{
				bool flag = false;
				this.recupererLigne();
				if (this.tri)
				{
					if (this.modification)
					{
						if (((string)this.ligneEdit[1]).Trim() != this.ancienneClefTri.Trim())
						{
							if (HashTableEdit.TriGetPositionClef(this.table, (string)this.ligneEdit[1]) != -1)
							{
								MessageBox.Show("Opération impossible, données dupliquées !");
							}
							else
							{
								flag = true;
								HashTableEdit.TriRemoveLigne(ref this.table, this.ancienneClefTri);
								HashTableEdit.TriAddLigne(ref this.table, this.ligneEdit);
							}
						}
						else
						{
							flag = true;
							HashTableEdit.TriRemoveLigne(ref this.table, this.ancienneClefTri);
							HashTableEdit.TriAddLigne(ref this.table, this.ligneEdit);
						}
					}
					else if (HashTableEdit.TriGetPositionClef(this.table, (string)this.ligneEdit[1]) != -1)
					{
						MessageBox.Show("Opération impossible, données dupliquées !");
					}
					else
					{
						flag = true;
						HashTableEdit.TriAddLigne(ref this.table, this.ligneEdit);
					}
				}
				else if (this.modification)
				{
					if ((string)this.ligneEdit[0] != this.ancienneClef)
					{
						if (this.table.ContainsKey(this.ligneEdit[0]))
						{
							MessageBox.Show("Opération impossible, données dupliquées !");
						}
						else
						{
							flag = true;
							this.table.Remove(this.ancienneClef);
							this.table[this.ligneEdit[0]] = this.ligneEdit;
						}
					}
					else
					{
						flag = true;
						this.table[this.ligneEdit[0]] = this.ligneEdit;
					}
				}
				else if (this.table.ContainsKey(this.ligneEdit[0]))
				{
					MessageBox.Show("Opération impossible, données dupliquées !");
				}
				else
				{
					flag = true;
					this.table[this.ligneEdit[0]] = this.ligneEdit;
				}
				if (flag)
				{
					this.remplirListe();
					this.ToListe();
					return;
				}
			}
			else
			{
				MessageBox.Show(this.messageErreur);
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00007184 File Offset: 0x00006184
		protected virtual bool ligneOk()
		{
			return true;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00007194 File Offset: 0x00006194
		private void lb_valeurs_Enter(object sender, EventArgs e)
		{
			if (this.lectureSeule)
			{
				this.tmpFocus.Focus();
			}
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060000C9 RID: 201 RVA: 0x000071B8 File Offset: 0x000061B8
		// (remove) Token: 0x060000CA RID: 202 RVA: 0x000071DC File Offset: 0x000061DC
		public event EventHandler DebutEdition;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060000CB RID: 203 RVA: 0x00007200 File Offset: 0x00006200
		// (remove) Token: 0x060000CC RID: 204 RVA: 0x00007224 File Offset: 0x00006224
		public event EventHandler FinEdition;

		// Token: 0x060000CD RID: 205 RVA: 0x00007248 File Offset: 0x00006248
		public static void StockerTableXml(SortedList t, XmlTextWriter writer, string nomTable)
		{
			writer.WriteStartElement(nomTable);
			writer.WriteAttributeString("nbLignes", t.Count.ToString());
			foreach (object obj in t.Values)
			{
				writer.WriteStartElement("ligne");
				writer.WriteAttributeString("nbValeurs", ((ArrayList)obj).Count.ToString());
				writer.WriteAttributeString("clef", ((ArrayList)obj)[0].ToString());
				for (int i = 0; i < ((ArrayList)obj).Count; i++)
				{
					string value = ((ArrayList)obj)[i].ToString();
					writer.WriteElementString("valeur", value);
				}
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00007354 File Offset: 0x00006354
		public static void ChargerTableXml(SortedList t, XmlTextReader reader)
		{
			Simulation.elementXmlSuivant(reader, false);
			reader.MoveToNextAttribute();
			int num = int.Parse(reader.Value);
			for (int i = 1; i <= num; i++)
			{
				Simulation.elementXmlSuivant(reader, false);
				reader.MoveToNextAttribute();
				int num2 = int.Parse(reader.Value);
				reader.MoveToNextAttribute();
				string value = reader.Value;
				t[value] = new ArrayList();
				for (int j = 1; j <= num2; j++)
				{
					Simulation.elementXmlSuivant(reader, true);
					string value2 = reader.Value;
					((ArrayList)t[value]).Add(value2);
				}
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x000073F0 File Offset: 0x000063F0
		private void lb_valeurs_DoubleClick(object sender, EventArgs e)
		{
			if (!this.lectureSeule)
			{
				if (this.lb_valeurs.SelectedIndex == -1)
				{
					this.bthte_ajouter_Click(sender, e);
					return;
				}
				this.bthte_modifier_Click(sender, e);
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00007424 File Offset: 0x00006424
		public static void SetLigne(SortedList table, ArrayList ligne)
		{
			table.Add(ligne[0].ToString(), ligne);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00007444 File Offset: 0x00006444
		public static string DeuxChiffres(int val)
		{
			if (val < 10)
			{
				return "0" + val.ToString();
			}
			return val.ToString();
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00007470 File Offset: 0x00006470
		public static void TriRemoveLigne(ref SortedList table, object objClef)
		{
			ArrayList arrayList = (ArrayList)table[objClef];
			if (arrayList != null)
			{
				string clef = arrayList[1].ToString();
				HashTableEdit.TriRemoveLigne(ref table, clef);
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000074A4 File Offset: 0x000064A4
		public static int TriGetPositionClef(SortedList table, string clef)
		{
			int num = 0;
			bool flag = false;
			while (!flag && num < table.Count)
			{
				ArrayList arrayList = (ArrayList)table.GetByIndex(num);
				if (arrayList[1].ToString().Trim() == clef.Trim())
				{
					flag = true;
				}
				else
				{
					num++;
				}
			}
			if (!flag)
			{
				num = -1;
			}
			return num;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000074FC File Offset: 0x000064FC
		public static ArrayList TriGetLignePos(SortedList table, int pos)
		{
			return (ArrayList)table.GetByIndex(pos);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00007518 File Offset: 0x00006518
		public static ArrayList TriGetLigneClef(SortedList table, string clef)
		{
			int num = 0;
			bool flag = false;
			ArrayList arrayList = null;
			while (!flag && num < table.Count)
			{
				arrayList = (ArrayList)table.GetByIndex(num);
				if (arrayList[1].ToString().Trim() == clef.Trim())
				{
					flag = true;
				}
				else
				{
					num++;
				}
			}
			if (!flag)
			{
				arrayList = null;
			}
			return arrayList;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00007574 File Offset: 0x00006574
		public static string TriGetClef(SortedList table, int pos)
		{
			ArrayList arrayList = (ArrayList)table.GetByIndex(pos);
			return arrayList[1].ToString().Trim();
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000075A0 File Offset: 0x000065A0
		public static void TriRemoveLigne(ref SortedList table, string clef)
		{
			int num = 0;
			bool flag = false;
			while (!flag && num < table.Count)
			{
				ArrayList arrayList = (ArrayList)table.GetByIndex(num);
				if (arrayList[1].ToString().Trim() == clef.Trim())
				{
					flag = true;
				}
				else
				{
					num++;
				}
			}
			if (flag)
			{
				table.RemoveAt(num);
				SortedList sortedList = new SortedList();
				num = 1;
				foreach (object obj in table.Values)
				{
					ArrayList arrayList2 = (ArrayList)obj;
					arrayList2[0] = HashTableEdit.DeuxChiffres(num);
					HashTableEdit.SetLigne(sortedList, arrayList2);
					num++;
				}
				table = sortedList;
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00007680 File Offset: 0x00006680
		public static void TriAddLigne(ref SortedList table, ArrayList p_ligne)
		{
			int num = int.Parse(p_ligne[0].ToString());
			if (num > table.Count + 1)
			{
				num = table.Count + 1;
				p_ligne[0] = HashTableEdit.DeuxChiffres(num);
			}
			bool flag = false;
			foreach (object obj in table.Values)
			{
				ArrayList arrayList = (ArrayList)obj;
				if (arrayList[1].ToString().Trim() == p_ligne[1].ToString().Trim())
				{
					flag = true;
				}
			}
			if (!flag)
			{
				SortedList sortedList = new SortedList();
				for (int i = 0; i < num - 1; i++)
				{
					HashTableEdit.SetLigne(sortedList, (ArrayList)table.GetByIndex(i));
				}
				HashTableEdit.SetLigne(sortedList, p_ligne);
				for (int i = num - 1; i < table.Count; i++)
				{
					ArrayList arrayList2 = (ArrayList)table.GetByIndex(i);
					arrayList2[0] = HashTableEdit.DeuxChiffres(i + 2);
					HashTableEdit.SetLigne(sortedList, arrayList2);
				}
				table = sortedList;
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x000077C4 File Offset: 0x000067C4
		public static SortedList SortedListToXml(SortedList sl)
		{
			SortedList sortedList = new SortedList();
			foreach (object obj in sl.Values)
			{
				ArrayList arrayList = (ArrayList)obj;
				ArrayList arrayList2 = new ArrayList();
				arrayList2.Add(arrayList[0]);
				for (int i = 2; i < arrayList.Count; i++)
				{
					arrayList2.Add(arrayList[i]);
				}
				sortedList.Add(arrayList2[0].ToString(), arrayList2.Clone());
			}
			return sortedList;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000787C File Offset: 0x0000687C
		public static SortedList XmlToSortedList(SortedList xml, ClefTable calculerClef)
		{
			SortedList sortedList = new SortedList();
			foreach (object obj in xml.Values)
			{
				ArrayList arrayList = (ArrayList)obj;
				ArrayList arrayList2 = new ArrayList();
				arrayList2.Add(arrayList[0]);
				arrayList2.Add("");
				for (int i = 1; i < arrayList.Count; i++)
				{
					arrayList2.Add(arrayList[i]);
				}
				arrayList2[1] = calculerClef(arrayList2);
				sortedList.Add(arrayList2[0].ToString(), arrayList2.Clone());
			}
			return sortedList;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00007950 File Offset: 0x00006950
		protected string FormatFixe(string val, string reference)
		{
			string text = val.ToString();
			string text2 = text;
			Graphics graphics = this.lb_valeurs.CreateGraphics();
			int num = (int)graphics.MeasureString(reference, this.lb_valeurs.Font).Width;
			int i;
			for (i = (int)graphics.MeasureString(text, this.lb_valeurs.Font).Width; i < num; i = (int)graphics.MeasureString(text2, this.lb_valeurs.Font).Width)
			{
				text2 += "j";
			}
			int num2 = i - num;
			text = text.PadRight(text2.Length - 1);
			int num3 = (int)graphics.MeasureString(text, this.lb_valeurs.Font).Width;
			if (num2 > num3)
			{
				return text;
			}
			return text.PadRight(text2.Length);
		}

		// Token: 0x0400005A RID: 90
		protected ListBox lb_valeurs;

		// Token: 0x0400005B RID: 91
		protected Button bthte_modifier;

		// Token: 0x0400005C RID: 92
		protected Button bthte_supprimer;

		// Token: 0x0400005D RID: 93
		protected Button bthte_ajouter;

		// Token: 0x0400005E RID: 94
		protected Button bthte_annuler;

		// Token: 0x0400005F RID: 95
		private ImageList il_images;

		// Token: 0x04000060 RID: 96
		protected Button bthte_annulerSaisie;

		// Token: 0x04000061 RID: 97
		protected Button bthte_validerSaisie;

		// Token: 0x04000062 RID: 98
		private TextBox tmpFocus;

		// Token: 0x04000063 RID: 99
		private IContainer components;

		// Token: 0x04000064 RID: 100
		private bool tri = false;

		// Token: 0x04000065 RID: 101
		private string ancienneClefTri;

		// Token: 0x04000066 RID: 102
		protected bool lectureSeule;

		// Token: 0x04000067 RID: 103
		protected SortedList table;

		// Token: 0x04000068 RID: 104
		private SortedList tableInitiale;

		// Token: 0x04000069 RID: 105
		private ArrayList cles = new ArrayList();

		// Token: 0x0400006A RID: 106
		protected ArrayList ligneEdit;

		// Token: 0x0400006B RID: 107
		private string ancienneClef;

		// Token: 0x0400006C RID: 108
		private bool modification;

		// Token: 0x0400006D RID: 109
		protected string messageErreur = "Données incorrectes";
	}
}
