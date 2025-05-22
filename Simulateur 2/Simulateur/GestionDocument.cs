using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace Simulateur
{
	// Token: 0x0200004C RID: 76
	public class GestionDocument : MainMenu
	{
		// Token: 0x060003C3 RID: 963 RVA: 0x0002B084 File Offset: 0x0002A084
		public void Init(DelegueAction pde_nouv, DelegueConfirmation pde_ouv, DelegueConfirmation pde_enreg, DelegueAction pde_actionComplementaire, string actionComplementaire)
		{
			this.etat = EtatDocument.vide;
			this.installerMenus(actionComplementaire);
			this.de_enregistrement = pde_enreg;
			this.de_actionComplementaire = pde_actionComplementaire;
			this.de_ouverture = pde_ouv;
			this.de_nouveau = pde_nouv;
			this.InitMenus();
			this.od_ouvrir.DefaultExt = this.extension;
			this.od_ouvrir.Filter = this.filtre;
			this.sd_enregistrer.DefaultExt = this.extension;
			this.sd_enregistrer.Filter = this.filtre;
			this.chargerDocs();
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0002B110 File Offset: 0x0002A110
		public void Init(DelegueAction pde_nouv, DelegueConfirmation pde_ouv, DelegueConfirmation pde_enreg)
		{
			this.Init(pde_nouv, pde_ouv, pde_enreg, null, "");
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x0002B12C File Offset: 0x0002A12C
		private void chargerDocs()
		{
			try
			{
				XmlTextReader xmlTextReader = new XmlTextReader(Application.StartupPath + "\\derniers.xml");
				while (xmlTextReader.Read())
				{
					if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.LocalName == "document")
					{
						xmlTextReader.Read();
						this.docs.Add(xmlTextReader.Value);
					}
				}
				xmlTextReader.Close();
				if (this.docs.Count > 0)
				{
					this.mi_fichier.MenuItems.Add(new MenuItem("-"));
					for (int i = 0; i < this.docs.Count; i++)
					{
						this.mi_fichier.MenuItems.Add(new MenuItem(this.docs[i].ToString(), new EventHandler(this.docs_Click)));
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0002B228 File Offset: 0x0002A228
		private void sauvegarderDocs()
		{
			try
			{
				XmlTextWriter xmlTextWriter = new XmlTextWriter(Application.StartupPath + "\\derniers.xml", null);
				xmlTextWriter.Formatting = Formatting.Indented;
				xmlTextWriter.WriteStartDocument();
				xmlTextWriter.WriteStartElement("derniersDocumentsOuverts");
				foreach (object obj in this.docs)
				{
					string text = (string)obj;
					xmlTextWriter.WriteStartElement("document");
					xmlTextWriter.WriteString(text);
					xmlTextWriter.WriteEndElement();
				}
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.WriteEndDocument();
				xmlTextWriter.Close();
			}
			catch
			{
			}
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0002B2FC File Offset: 0x0002A2FC
		private void installerMenus(string actionComplementaire)
		{
			this.mi_nouveau.Index = 0;
			this.mi_nouveau.Text = "Nouveau";
			this.mi_nouveau.Click += this.mi_nouveau_Click;
			this.mi_ouvrir.Index = 1;
			this.mi_ouvrir.Text = "Ouvrir";
			this.mi_ouvrir.Click += this.mi_ouvrir_Click;
			this.mi_enregistrer.Index = 2;
			this.mi_enregistrer.Text = "Enregistrer";
			this.mi_enregistrer.Click += this.mi_enregistrer_Click;
			this.mi_enregistrerSous.Index = 3;
			this.mi_enregistrerSous.Text = "Enregistrer sous";
			this.mi_enregistrerSous.Click += this.mi_enregistrerSous_Click;
			this.mi_actionComplementaire.Index = 4;
			this.mi_actionComplementaire.Text = actionComplementaire;
			this.mi_actionComplementaire.Click += this.mi_actionComplementaire_Click;
			if (actionComplementaire == "")
			{
				this.mi_actionComplementaire.Visible = false;
			}
			this.mi_separ.Index = 5;
			this.mi_separ.Text = "-";
			this.mi_quitter.Index = 6;
			this.mi_quitter.Text = "Quitter";
			this.mi_quitter.Click += this.mi_quitter_Click;
			base.GetForm().Closing += this.Application_Closing;
			this.mi_fichier.Index = 7;
			this.mi_fichier.MenuItems.AddRange(new MenuItem[]
			{
				this.mi_nouveau,
				this.mi_ouvrir,
				this.mi_enregistrer,
				this.mi_enregistrerSous,
				this.mi_actionComplementaire,
				this.mi_separ,
				this.mi_quitter
			});
			this.mi_fichier.Text = "Fichier";
			base.MenuItems.Add(0, this.mi_fichier);
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x0002B50C File Offset: 0x0002A50C
		private void Application_Closing(object sender, CancelEventArgs e)
		{
			if (this.FaireAction(ActionDocument.quitter))
			{
				this.sauvegarderDocs();
				return;
			}
			e.Cancel = true;
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0002B530 File Offset: 0x0002A530
		private void mi_nouveau_Click(object sender, EventArgs e)
		{
			this.FaireAction(ActionDocument.nouveau);
		}

		// Token: 0x060003CA RID: 970 RVA: 0x0002B548 File Offset: 0x0002A548
		private void mi_ouvrir_Click(object sender, EventArgs e)
		{
			this.FaireAction(ActionDocument.ouvrir);
		}

		// Token: 0x060003CB RID: 971 RVA: 0x0002B560 File Offset: 0x0002A560
		private void mi_enregistrer_Click(object sender, EventArgs e)
		{
			this.FaireAction(ActionDocument.enregistrer);
		}

		// Token: 0x060003CC RID: 972 RVA: 0x0002B578 File Offset: 0x0002A578
		private void mi_enregistrerSous_Click(object sender, EventArgs e)
		{
			this.FaireAction(ActionDocument.enregistrerSous);
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0002B590 File Offset: 0x0002A590
		private void mi_actionComplementaire_Click(object sender, EventArgs e)
		{
			this.de_actionComplementaire();
		}

		// Token: 0x060003CE RID: 974 RVA: 0x0002B5A8 File Offset: 0x0002A5A8
		private void mi_quitter_Click(object sender, EventArgs e)
		{
			base.GetForm().Close();
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0002B5C0 File Offset: 0x0002A5C0
		private bool confirmerEnregModifDoc()
		{
			return MessageBox.Show("Voulez-vous enregistrer les modifications ?", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes;
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060003D0 RID: 976 RVA: 0x0002B5E0 File Offset: 0x0002A5E0
		// (set) Token: 0x060003D1 RID: 977 RVA: 0x0002B5F4 File Offset: 0x0002A5F4
		public string Extension
		{
			get
			{
				return this.extension;
			}
			set
			{
				this.extension = value;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060003D2 RID: 978 RVA: 0x0002B608 File Offset: 0x0002A608
		// (set) Token: 0x060003D3 RID: 979 RVA: 0x0002B61C File Offset: 0x0002A61C
		public string Filtre
		{
			get
			{
				return this.filtre;
			}
			set
			{
				this.filtre = value;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060003D4 RID: 980 RVA: 0x0002B630 File Offset: 0x0002A630
		public string DocumentCourant
		{
			get
			{
				return this.documentCourant;
			}
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x0002B644 File Offset: 0x0002A644
		public void InitMenus()
		{
			switch (this.etat)
			{
			case EtatDocument.vide:
				this.mi_nouveau.Enabled = false;
				this.mi_ouvrir.Enabled = true;
				this.mi_enregistrer.Enabled = false;
				this.mi_enregistrerSous.Enabled = false;
				this.mi_actionComplementaire.Enabled = false;
				return;
			case EtatDocument.nonEnregistre:
				this.mi_nouveau.Enabled = true;
				this.mi_ouvrir.Enabled = true;
				this.mi_enregistrer.Enabled = false;
				this.mi_enregistrerSous.Enabled = true;
				this.mi_actionComplementaire.Enabled = false;
				return;
			case EtatDocument.enregistre:
				this.mi_nouveau.Enabled = true;
				this.mi_ouvrir.Enabled = true;
				this.mi_enregistrer.Enabled = false;
				this.mi_enregistrerSous.Enabled = true;
				this.mi_actionComplementaire.Enabled = true;
				return;
			case EtatDocument.modifie:
				this.mi_nouveau.Enabled = true;
				this.mi_ouvrir.Enabled = true;
				this.mi_enregistrer.Enabled = true;
				this.mi_enregistrerSous.Enabled = true;
				this.mi_actionComplementaire.Enabled = true;
				return;
			default:
				return;
			}
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x0002B764 File Offset: 0x0002A764
		public void ajouterDoc(string nomFichier)
		{
			int num = this.mi_fichier.MenuItems.Count - 7;
			for (int i = 0; i < num; i++)
			{
				this.mi_fichier.MenuItems.RemoveAt(7);
			}
			this.documentCourant = nomFichier;
			if (!this.docs.Contains(nomFichier))
			{
				if (this.docs.Count < this.docs.Capacity)
				{
					this.docs.Insert(0, nomFichier);
				}
				else
				{
					for (int j = this.docs.Count - 1; j > 0; j--)
					{
						this.docs[j] = this.docs[j - 1];
					}
					this.docs[0] = nomFichier;
				}
			}
			else
			{
				int num2 = this.docs.IndexOf(nomFichier);
				for (int k = num2; k > 0; k--)
				{
					this.docs[k] = this.docs[k - 1];
				}
				this.docs[0] = nomFichier;
			}
			this.mi_fichier.MenuItems.Add(new MenuItem("-"));
			for (int l = 0; l < this.docs.Count; l++)
			{
				this.mi_fichier.MenuItems.Add(new MenuItem(this.docs[l].ToString(), new EventHandler(this.docs_Click)));
			}
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0002B8D0 File Offset: 0x0002A8D0
		private void docs_Click(object sender, EventArgs e)
		{
			switch (this.etat)
			{
			case EtatDocument.nonEnregistre:
				if (this.confirmerEnregModifDoc() && this.sd_enregistrer.ShowDialog() == DialogResult.OK && this.de_enregistrement(this.sd_enregistrer.FileName))
				{
					this.etat = EtatDocument.enregistre;
					this.ajouterDoc(this.sd_enregistrer.FileName);
				}
				break;
			case EtatDocument.modifie:
				if (this.confirmerEnregModifDoc() && this.de_enregistrement(this.documentCourant))
				{
					this.etat = EtatDocument.enregistre;
				}
				break;
			}
			if (!this.de_ouverture(((MenuItem)sender).Text))
			{
				this.mi_fichier.MenuItems.Remove((MenuItem)sender);
				this.docs.Remove(((MenuItem)sender).Text);
				if (this.docs.Count == 0)
				{
					this.mi_fichier.MenuItems.RemoveAt(7);
				}
				this.etat = EtatDocument.vide;
				this.documentCourant = "non enregistré";
			}
			else
			{
				this.etat = EtatDocument.enregistre;
				this.ajouterDoc(((MenuItem)sender).Text);
			}
			this.InitMenus();
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x0002B9F8 File Offset: 0x0002A9F8
		public void AnnulerOuvrir()
		{
			this.etat = EtatDocument.vide;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0002BA0C File Offset: 0x0002AA0C
		public bool FaireAction(ActionDocument action)
		{
			bool result = true;
			switch (this.etat)
			{
			case EtatDocument.vide:
				switch (action)
				{
				case ActionDocument.ouvrir:
					if (this.od_ouvrir.ShowDialog() == DialogResult.OK && this.de_ouverture(this.od_ouvrir.FileName))
					{
						this.ajouterDoc(this.od_ouvrir.FileName);
						this.etat = EtatDocument.enregistre;
					}
					break;
				case ActionDocument.modifier:
					this.etat = EtatDocument.nonEnregistre;
					break;
				}
				break;
			case EtatDocument.nonEnregistre:
				switch (action)
				{
				case ActionDocument.nouveau:
				{
					bool flag = true;
					if (this.confirmerEnregModifDoc())
					{
						if (this.sd_enregistrer.ShowDialog() == DialogResult.OK)
						{
							if (this.de_enregistrement(this.sd_enregistrer.FileName))
							{
								this.ajouterDoc(this.sd_enregistrer.FileName);
							}
							else
							{
								flag = false;
							}
						}
						else
						{
							flag = false;
						}
					}
					if (flag)
					{
						this.de_nouveau();
						this.documentCourant = "non enregistré";
						this.etat = EtatDocument.vide;
					}
					break;
				}
				case ActionDocument.ouvrir:
				{
					bool flag = true;
					if (this.confirmerEnregModifDoc())
					{
						if (this.sd_enregistrer.ShowDialog() == DialogResult.OK)
						{
							if (this.de_enregistrement(this.sd_enregistrer.FileName))
							{
								this.ajouterDoc(this.sd_enregistrer.FileName);
								this.etat = EtatDocument.enregistre;
							}
							else
							{
								flag = false;
							}
						}
						else
						{
							flag = false;
						}
					}
					if (flag && this.od_ouvrir.ShowDialog() == DialogResult.OK)
					{
						if (this.de_ouverture(this.od_ouvrir.FileName))
						{
							this.ajouterDoc(this.od_ouvrir.FileName);
							this.etat = EtatDocument.enregistre;
						}
						else
						{
							this.documentCourant = "non enregistré";
							this.etat = EtatDocument.vide;
						}
					}
					break;
				}
				case ActionDocument.enregistrerSous:
					if (this.sd_enregistrer.ShowDialog() == DialogResult.OK && this.de_enregistrement(this.sd_enregistrer.FileName))
					{
						this.ajouterDoc(this.sd_enregistrer.FileName);
						this.etat = EtatDocument.enregistre;
					}
					break;
				case ActionDocument.quitter:
					if (this.confirmerEnregModifDoc())
					{
						if (this.sd_enregistrer.ShowDialog() == DialogResult.OK)
						{
							if (this.de_enregistrement(this.sd_enregistrer.FileName))
							{
								this.ajouterDoc(this.sd_enregistrer.FileName);
							}
							else
							{
								result = false;
							}
						}
						else
						{
							result = false;
						}
					}
					break;
				}
				break;
			case EtatDocument.enregistre:
				switch (action)
				{
				case ActionDocument.nouveau:
					this.de_nouveau();
					this.etat = EtatDocument.vide;
					break;
				case ActionDocument.ouvrir:
					if (this.od_ouvrir.ShowDialog() == DialogResult.OK && this.de_ouverture(this.od_ouvrir.FileName))
					{
						this.ajouterDoc(this.od_ouvrir.FileName);
						this.etat = EtatDocument.enregistre;
					}
					break;
				case ActionDocument.modifier:
					this.etat = EtatDocument.modifie;
					break;
				case ActionDocument.enregistrerSous:
					if (this.sd_enregistrer.ShowDialog() == DialogResult.OK && this.de_enregistrement(this.sd_enregistrer.FileName))
					{
						this.ajouterDoc(this.sd_enregistrer.FileName);
					}
					break;
				}
				break;
			case EtatDocument.modifie:
				switch (action)
				{
				case ActionDocument.nouveau:
				{
					bool flag = true;
					if (this.confirmerEnregModifDoc() && !this.de_enregistrement(this.documentCourant))
					{
						flag = false;
					}
					if (flag)
					{
						this.de_nouveau();
						this.documentCourant = "non enregistré";
						this.etat = EtatDocument.vide;
					}
					break;
				}
				case ActionDocument.ouvrir:
				{
					bool flag = true;
					if (this.confirmerEnregModifDoc())
					{
						if (this.de_enregistrement(this.documentCourant))
						{
							this.etat = EtatDocument.enregistre;
						}
						else
						{
							flag = false;
						}
					}
					if (flag && this.od_ouvrir.ShowDialog() == DialogResult.OK && this.de_ouverture(this.od_ouvrir.FileName))
					{
						this.ajouterDoc(this.od_ouvrir.FileName);
						this.etat = EtatDocument.enregistre;
					}
					break;
				}
				case ActionDocument.enregistrer:
					if (this.de_enregistrement(this.documentCourant))
					{
						this.etat = EtatDocument.enregistre;
					}
					break;
				case ActionDocument.enregistrerSous:
					if (this.sd_enregistrer.ShowDialog() == DialogResult.OK && this.de_enregistrement(this.sd_enregistrer.FileName))
					{
						this.ajouterDoc(this.sd_enregistrer.FileName);
						this.etat = EtatDocument.enregistre;
					}
					break;
				case ActionDocument.quitter:
					if (this.confirmerEnregModifDoc() && !this.de_enregistrement(this.documentCourant))
					{
						result = false;
					}
					break;
				}
				break;
			}
			this.InitMenus();
			return result;
		}

		// Token: 0x040002F5 RID: 757
		private MenuItem mi_fichier = new MenuItem();

		// Token: 0x040002F6 RID: 758
		private MenuItem mi_nouveau = new MenuItem();

		// Token: 0x040002F7 RID: 759
		private MenuItem mi_ouvrir = new MenuItem();

		// Token: 0x040002F8 RID: 760
		private MenuItem mi_enregistrer = new MenuItem();

		// Token: 0x040002F9 RID: 761
		private MenuItem mi_enregistrerSous = new MenuItem();

		// Token: 0x040002FA RID: 762
		private MenuItem mi_actionComplementaire = new MenuItem();

		// Token: 0x040002FB RID: 763
		private MenuItem mi_separ = new MenuItem();

		// Token: 0x040002FC RID: 764
		private MenuItem mi_quitter = new MenuItem();

		// Token: 0x040002FD RID: 765
		private OpenFileDialog od_ouvrir = new OpenFileDialog();

		// Token: 0x040002FE RID: 766
		private SaveFileDialog sd_enregistrer = new SaveFileDialog();

		// Token: 0x040002FF RID: 767
		private string extension;

		// Token: 0x04000300 RID: 768
		private string filtre;

		// Token: 0x04000301 RID: 769
		private string documentCourant;

		// Token: 0x04000302 RID: 770
		private ArrayList docs = new ArrayList(5);

		// Token: 0x04000303 RID: 771
		private EtatDocument etat;

		// Token: 0x04000304 RID: 772
		private DelegueAction de_nouveau;

		// Token: 0x04000305 RID: 773
		private DelegueConfirmation de_ouverture;

		// Token: 0x04000306 RID: 774
		private DelegueConfirmation de_enregistrement;

		// Token: 0x04000307 RID: 775
		private DelegueAction de_actionComplementaire;
	}
}
