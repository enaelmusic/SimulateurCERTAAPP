using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Simulateur
{
	// Token: 0x02000003 RID: 3
	public class Ap_Message : ElementReseau
	{
		// Token: 0x06000038 RID: 56 RVA: 0x00002820 File Offset: 0x00001820
		public Ap_Message()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002840 File Offset: 0x00001840
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000286C File Offset: 0x0000186C
		private void InitializeComponent()
		{
			base.Name = "Ap_Message";
			base.Size = new Size(22, 18);
			base.Paint += this.Ap_Message_Paint;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000028A8 File Offset: 0x000018A8
		private void Ap_Message_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.DrawRectangle(this.stylo, 0, 0, 21, 17);
			graphics.DrawRectangle(this.stylo, 14, 2, 4, 4);
			graphics.DrawLine(this.stylo, 3, 9, 4, 9);
			graphics.DrawLine(this.stylo, 6, 9, 9, 9);
			graphics.DrawLine(this.stylo, 11, 9, 17, 9);
			graphics.DrawLine(this.stylo, 3, 11, 3, 11);
			graphics.DrawLine(this.stylo, 5, 11, 7, 11);
			graphics.DrawLine(this.stylo, 12, 11, 17, 11);
			graphics.DrawLine(this.stylo, 3, 13, 6, 13);
			graphics.DrawLine(this.stylo, 8, 13, 13, 13);
			graphics.DrawLine(this.stylo, 15, 13, 17, 13);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000298C File Offset: 0x0000198C
		public override void StockerXml(XmlTextWriter writer)
		{
			writer.WriteStartElement("iconeMessage");
			writer.WriteEndElement();
		}

		// Token: 0x04000014 RID: 20
		private IContainer components = null;
	}
}
