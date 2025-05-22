namespace Simulateur
{
	// Token: 0x02000069 RID: 105
	public partial class NoeudsDemoDialogue : global::System.Windows.Forms.Form
	{
		// Token: 0x060005FA RID: 1530 RVA: 0x0003CB60 File Offset: 0x0003BB60
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x0003CB8C File Offset: 0x0003BB8C
		private void InitializeComponent()
		{
			this.lb_nonTraces = new global::System.Windows.Forms.ListBox();
			this.lb_traces = new global::System.Windows.Forms.ListBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.bt_versTraces = new global::System.Windows.Forms.Button();
			this.bt_tousVersTraces = new global::System.Windows.Forms.Button();
			this.bt_versNonTraces = new global::System.Windows.Forms.Button();
			this.bt_tousVersNonTraces = new global::System.Windows.Forms.Button();
			this.bt_ok = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.lb_nonTraces.Location = new global::System.Drawing.Point(16, 40);
			this.lb_nonTraces.Name = "lb_nonTraces";
			this.lb_nonTraces.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiSimple;
			this.lb_nonTraces.Size = new global::System.Drawing.Size(120, 134);
			this.lb_nonTraces.Sorted = true;
			this.lb_nonTraces.TabIndex = 0;
			this.lb_nonTraces.DoubleClick += new global::System.EventHandler(this.bt_versTraces_Click);
			this.lb_traces.Location = new global::System.Drawing.Point(200, 40);
			this.lb_traces.Name = "lb_traces";
			this.lb_traces.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiSimple;
			this.lb_traces.Size = new global::System.Drawing.Size(120, 134);
			this.lb_traces.Sorted = true;
			this.lb_traces.TabIndex = 1;
			this.lb_traces.DoubleClick += new global::System.EventHandler(this.bt_versNonTraces_Click);
			this.label1.Location = new global::System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(100, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Noeuds non tracés";
			this.label2.Location = new global::System.Drawing.Point(200, 16);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(100, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Noeuds tracés";
			this.bt_versTraces.Location = new global::System.Drawing.Point(152, 48);
			this.bt_versTraces.Name = "bt_versTraces";
			this.bt_versTraces.Size = new global::System.Drawing.Size(32, 23);
			this.bt_versTraces.TabIndex = 4;
			this.bt_versTraces.Text = ">";
			this.bt_versTraces.Click += new global::System.EventHandler(this.bt_versTraces_Click);
			this.bt_tousVersTraces.Location = new global::System.Drawing.Point(152, 80);
			this.bt_tousVersTraces.Name = "bt_tousVersTraces";
			this.bt_tousVersTraces.Size = new global::System.Drawing.Size(32, 23);
			this.bt_tousVersTraces.TabIndex = 5;
			this.bt_tousVersTraces.Text = ">>";
			this.bt_tousVersTraces.Click += new global::System.EventHandler(this.bt_tousVersTraces_Click);
			this.bt_versNonTraces.Location = new global::System.Drawing.Point(152, 112);
			this.bt_versNonTraces.Name = "bt_versNonTraces";
			this.bt_versNonTraces.Size = new global::System.Drawing.Size(32, 23);
			this.bt_versNonTraces.TabIndex = 6;
			this.bt_versNonTraces.Text = "<";
			this.bt_versNonTraces.Click += new global::System.EventHandler(this.bt_versNonTraces_Click);
			this.bt_tousVersNonTraces.Location = new global::System.Drawing.Point(152, 144);
			this.bt_tousVersNonTraces.Name = "bt_tousVersNonTraces";
			this.bt_tousVersNonTraces.Size = new global::System.Drawing.Size(32, 23);
			this.bt_tousVersNonTraces.TabIndex = 7;
			this.bt_tousVersNonTraces.Text = "<<";
			this.bt_tousVersNonTraces.Click += new global::System.EventHandler(this.bt_tousVersNonTraces_Click);
			this.bt_ok.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.bt_ok.Location = new global::System.Drawing.Point(128, 192);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.Size = new global::System.Drawing.Size(80, 23);
			this.bt_ok.TabIndex = 8;
			this.bt_ok.Text = "OK";
			this.bt_ok.Click += new global::System.EventHandler(this.bt_ok_Click);
			base.AcceptButton = this.bt_ok;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(338, 239);
			base.ControlBox = false;
			base.Controls.AddRange(new global::System.Windows.Forms.Control[]
			{
				this.bt_ok,
				this.bt_tousVersNonTraces,
				this.bt_versNonTraces,
				this.bt_tousVersTraces,
				this.bt_versTraces,
				this.label2,
				this.label1,
				this.lb_traces,
				this.lb_nonTraces
			});
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.Name = "NoeudsDemoDialogue";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Noeuds à tracer";
			base.ResumeLayout(false);
		}

		// Token: 0x040003FF RID: 1023
		private global::System.Windows.Forms.ListBox lb_nonTraces;

		// Token: 0x04000400 RID: 1024
		private global::System.Windows.Forms.ListBox lb_traces;

		// Token: 0x04000401 RID: 1025
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000402 RID: 1026
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000403 RID: 1027
		private global::System.Windows.Forms.Button bt_versTraces;

		// Token: 0x04000404 RID: 1028
		private global::System.Windows.Forms.Button bt_tousVersTraces;

		// Token: 0x04000405 RID: 1029
		private global::System.Windows.Forms.Button bt_versNonTraces;

		// Token: 0x04000406 RID: 1030
		private global::System.Windows.Forms.Button bt_tousVersNonTraces;

		// Token: 0x04000407 RID: 1031
		private global::System.Windows.Forms.Button bt_ok;

		// Token: 0x04000408 RID: 1032
		private global::System.ComponentModel.Container components = null;
	}
}
