using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000017 RID: 23
	public partial class FormConfig : Form
	{
		// Token: 0x06000190 RID: 400 RVA: 0x0000CEC4 File Offset: 0x0000BEC4
		public FormConfig()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0000CF48 File Offset: 0x0000BF48
		public virtual void Verrouiller()
		{
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0000CF58 File Offset: 0x0000BF58
		public virtual void DeVerrouiller()
		{
		}
	}
}
