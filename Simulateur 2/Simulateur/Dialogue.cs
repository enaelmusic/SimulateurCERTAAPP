using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000013 RID: 19
	public partial class Dialogue : Form
	{
		// Token: 0x0600016D RID: 365 RVA: 0x0000BC3C File Offset: 0x0000AC3C
		public Dialogue()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000BE14 File Offset: 0x0000AE14
		public void InScreen()
		{
			Dialogue.InScreen(this);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000BE28 File Offset: 0x0000AE28
		public static void InScreen(Form f)
		{
			int num = f.Location.X + f.Width - Screen.PrimaryScreen.WorkingArea.Width;
			num = Math.Max(num, 0);
			int num2 = f.Location.Y + f.Height - Screen.PrimaryScreen.WorkingArea.Height;
			num2 = Math.Max(num2, 0);
			f.Location = new Point(f.Location.X - num, f.Location.Y - num2);
		}
	}
}
