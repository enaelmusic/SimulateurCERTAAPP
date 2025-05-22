using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000052 RID: 82
	public partial class InputBox : Form
	{
		// Token: 0x0600045E RID: 1118 RVA: 0x0002F2D8 File Offset: 0x0002E2D8
		public InputBox()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x0002F554 File Offset: 0x0002E554
		public static bool Saisir(string titre, string question, ref string reponse)
		{
			InputBox inputBox = new InputBox();
			inputBox.Text = titre;
			inputBox.lb_question.Text = question;
			inputBox.tb_reponse.Text = reponse;
			if (inputBox.ShowDialog() == DialogResult.OK)
			{
				reponse = inputBox.tb_reponse.Text;
				return true;
			}
			return false;
		}
	}
}
