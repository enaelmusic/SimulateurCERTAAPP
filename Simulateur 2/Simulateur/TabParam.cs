using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace Simulateur
{
	// Token: 0x0200008E RID: 142
	public class TabParam : TabControl
	{
		// Token: 0x06000925 RID: 2341 RVA: 0x00056FA8 File Offset: 0x00055FA8
		public TabParam()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x00056FD4 File Offset: 0x00055FD4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x00057000 File Offset: 0x00056000
		protected void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x00057018 File Offset: 0x00056018
		public void ChargerXml(string nomFichier)
		{
			this.RestaurerParamDefaut();
			XmlTextReader xmlTextReader = new XmlTextReader(nomFichier);
			while (xmlTextReader.Read())
			{
				if (xmlTextReader.NodeType == XmlNodeType.Element)
				{
					int num = 0;
					bool flag = false;
					while (num < base.TabPages.Count && !flag)
					{
						TabPage tabPage = base.TabPages[num];
						int num2 = 0;
						while (num2 < tabPage.Controls.Count && !flag)
						{
							if (tabPage.Controls[num2].GetType().BaseType == typeof(Parametre))
							{
								flag = ((Parametre)tabPage.Controls[num2]).SetXmlRead(xmlTextReader);
							}
							num2++;
						}
						num++;
					}
				}
			}
			xmlTextReader.Close();
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x000570D0 File Offset: 0x000560D0
		public void RestaurerParamDefaut()
		{
			foreach (object obj in base.TabPages)
			{
				TabPage tabPage = (TabPage)obj;
				foreach (object obj2 in tabPage.Controls)
				{
					Control control = (Control)obj2;
					if (control.GetType().BaseType == typeof(Parametre))
					{
						((Parametre)control).restaurerDefaut();
					}
				}
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x0600092A RID: 2346 RVA: 0x000571A4 File Offset: 0x000561A4
		// (set) Token: 0x0600092B RID: 2347 RVA: 0x000571B8 File Offset: 0x000561B8
		public string TitreXml
		{
			get
			{
				return this.titreXml;
			}
			set
			{
				this.titreXml = value;
			}
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x000571CC File Offset: 0x000561CC
		public void SauvegarderXml(string nomFichier)
		{
			XmlTextWriter xmlTextWriter = new XmlTextWriter(nomFichier, null);
			xmlTextWriter.Formatting = Formatting.Indented;
			xmlTextWriter.WriteStartDocument();
			xmlTextWriter.WriteStartElement(this.titreXml);
			foreach (object obj in base.TabPages)
			{
				TabPage tabPage = (TabPage)obj;
				foreach (object obj2 in tabPage.Controls)
				{
					Control control = (Control)obj2;
					if (control.GetType().BaseType == typeof(Parametre))
					{
						((Parametre)control).XmlWrite(xmlTextWriter);
					}
				}
			}
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndDocument();
			xmlTextWriter.Close();
		}

		// Token: 0x040005BC RID: 1468
		public Container components = null;

		// Token: 0x040005BD RID: 1469
		private string titreXml = "parametres";
	}
}
