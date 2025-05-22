using System;
using System.ComponentModel;
using System.Drawing;

namespace Simulateur
{
	// Token: 0x0200002C RID: 44
	public partial class DialogueHashTable : FormConfig
	{
		// Token: 0x060002C5 RID: 709 RVA: 0x000251D4 File Offset: 0x000241D4
		public DialogueHashTable()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x000251F4 File Offset: 0x000241F4
		public static int Hauteur
		{
			get
			{
				return 147;
			}
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0002527C File Offset: 0x0002427C
		protected virtual HashTableEdit getHashTableEdit()
		{
			return null;
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0002528C File Offset: 0x0002428C
		public override void Verrouiller()
		{
			base.Verrouiller();
			this.modeAvantVerrouillage = this.getHashTableEdit().LectureSeule;
			this.getHashTableEdit().ChangerMode(true);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x000252BC File Offset: 0x000242BC
		public override void DeVerrouiller()
		{
			base.DeVerrouiller();
			this.getHashTableEdit().ChangerMode(this.modeAvantVerrouillage);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x000252E0 File Offset: 0x000242E0
		public void InScreen()
		{
			Dialogue.InScreen(this);
		}

		// Token: 0x04000275 RID: 629
		private bool modeAvantVerrouillage;
	}
}
