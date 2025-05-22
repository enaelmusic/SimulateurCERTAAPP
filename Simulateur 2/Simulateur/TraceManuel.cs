using System;
using System.ComponentModel;
using System.Drawing;

namespace Simulateur
{
	// Token: 0x02000006 RID: 6
	public class TraceManuel : ElementReseau
	{
		// Token: 0x0600004A RID: 74 RVA: 0x00003AC4 File Offset: 0x00002AC4
		public TraceManuel()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003AE4 File Offset: 0x00002AE4
		public TraceManuel(Simulation s) : base(s)
		{
			this.InitializeComponent();
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003B08 File Offset: 0x00002B08
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003B34 File Offset: 0x00002B34
		private void InitializeComponent()
		{
			base.Name = "TraceManuel";
			base.Size = new Size(1, 1);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003B5C File Offset: 0x00002B5C
		public virtual Rectangle RectangleTrace()
		{
			return new Rectangle(0, 0, 0, 0);
		}

		// Token: 0x0400002E RID: 46
		private Container components = null;
	}
}
