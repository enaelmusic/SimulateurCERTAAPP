using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000063 RID: 99
	public class LecteurDemo : UserControl
	{
		// Token: 0x060005AC RID: 1452 RVA: 0x00039700 File Offset: 0x00038700
		public LecteurDemo()
		{
			this.InitializeComponent();
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x00039720 File Offset: 0x00038720
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x0003974C File Offset: 0x0003874C
		private void InitializeComponent()
		{
			this.components = new Container();
			ResourceManager resourceManager = new ResourceManager(typeof(LecteurDemo));
			this.il_commandes = new ImageList(this.components);
			this.bt_reculer = new Button();
			this.bt_lecture = new Button();
			this.bt_stop = new Button();
			this.bt_pause = new Button();
			base.SuspendLayout();
			this.il_commandes.ImageSize = new Size(16, 16);
			this.il_commandes.ImageStream = (ImageListStreamer)resourceManager.GetObject("il_commandes.ImageStream");
			this.il_commandes.TransparentColor = Color.White;
			this.bt_reculer.ImageIndex = 2;
			this.bt_reculer.ImageList = this.il_commandes;
			this.bt_reculer.Location = new Point(32, 0);
			this.bt_reculer.Name = "bt_reculer";
			this.bt_reculer.Size = new Size(16, 16);
			this.bt_reculer.TabIndex = 3;
			this.bt_reculer.KeyPress += this.bt_lecteur_KeyPress;
			this.bt_reculer.Click += this.bt_reculer_Click;
			this.bt_lecture.ImageIndex = 3;
			this.bt_lecture.ImageList = this.il_commandes;
			this.bt_lecture.Location = new Point(48, 0);
			this.bt_lecture.Name = "bt_lecture";
			this.bt_lecture.Size = new Size(16, 16);
			this.bt_lecture.TabIndex = 0;
			this.bt_lecture.KeyPress += this.bt_lecteur_KeyPress;
			this.bt_lecture.Click += this.bt_lecture_Click;
			this.bt_stop.ImageIndex = 0;
			this.bt_stop.ImageList = this.il_commandes;
			this.bt_stop.Location = new Point(0, 0);
			this.bt_stop.Name = "bt_stop";
			this.bt_stop.Size = new Size(16, 16);
			this.bt_stop.TabIndex = 1;
			this.bt_stop.KeyPress += this.bt_lecteur_KeyPress;
			this.bt_stop.Click += this.bt_avancer_Click;
			this.bt_pause.ImageIndex = 1;
			this.bt_pause.ImageList = this.il_commandes;
			this.bt_pause.Location = new Point(16, 0);
			this.bt_pause.Name = "bt_pause";
			this.bt_pause.Size = new Size(16, 16);
			this.bt_pause.TabIndex = 2;
			this.bt_pause.KeyPress += this.bt_lecteur_KeyPress;
			this.bt_pause.Click += this.bt_pause_Click;
			base.Controls.Add(this.bt_pause);
			base.Controls.Add(this.bt_stop);
			base.Controls.Add(this.bt_lecture);
			base.Controls.Add(this.bt_reculer);
			base.Name = "LecteurDemo";
			base.Size = new Size(64, 16);
			base.ResumeLayout(false);
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x00039A94 File Offset: 0x00038A94
		private void bt_avancer_Click(object sender, EventArgs e)
		{
			((DemoDialogue)base.Parent).FinDemo(null, null);
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x00039AB4 File Offset: 0x00038AB4
		private void bt_lecture_Click(object sender, EventArgs e)
		{
			((DemoDialogue)base.Parent).Lecture();
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x00039AD4 File Offset: 0x00038AD4
		private void bt_reculer_Click(object sender, EventArgs e)
		{
			((DemoDialogue)base.Parent).Rewind();
		}

		// Token: 0x170000C7 RID: 199
		// (set) Token: 0x060005B2 RID: 1458 RVA: 0x00039AF4 File Offset: 0x00038AF4
		public BoutonPauseAction ActionPause
		{
			set
			{
				if (value == BoutonPauseAction.pause)
				{
					this.bt_pause.ImageIndex = 1;
				}
				else
				{
					this.bt_pause.ImageIndex = 4;
				}
				this.actionPause = value;
			}
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x00039B28 File Offset: 0x00038B28
		private void bt_pause_Click(object sender, EventArgs e)
		{
			if (this.actionPause == BoutonPauseAction.precedent)
			{
				((DemoDialogue)base.Parent).Precedent();
				return;
			}
			((DemoDialogue)base.Parent).Pause();
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x00039B60 File Offset: 0x00038B60
		private void bt_lecteur_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\u001b')
			{
				((DemoDialogue)base.Parent).Abandonner();
			}
		}

		// Token: 0x170000C8 RID: 200
		// (set) Token: 0x060005B5 RID: 1461 RVA: 0x00039B88 File Offset: 0x00038B88
		public bool Bt_pauseEnabled
		{
			set
			{
				this.bt_pause.Enabled = value;
			}
		}

		// Token: 0x170000C9 RID: 201
		// (set) Token: 0x060005B6 RID: 1462 RVA: 0x00039BA4 File Offset: 0x00038BA4
		public bool Bt_lectureEnabled
		{
			set
			{
				this.bt_lecture.Enabled = value;
			}
		}

		// Token: 0x040003D1 RID: 977
		private Button bt_reculer;

		// Token: 0x040003D2 RID: 978
		private Button bt_lecture;

		// Token: 0x040003D3 RID: 979
		private ImageList il_commandes;

		// Token: 0x040003D4 RID: 980
		private Button bt_pause;

		// Token: 0x040003D5 RID: 981
		private Button bt_stop;

		// Token: 0x040003D6 RID: 982
		private IContainer components;

		// Token: 0x040003D7 RID: 983
		private BoutonPauseAction actionPause = BoutonPauseAction.pause;
	}
}
