using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000069 RID: 105
	public partial class NoeudsDemoDialogue : Form
	{
		// Token: 0x060005F8 RID: 1528 RVA: 0x0003CA38 File Offset: 0x0003BA38
		public NoeudsDemoDialogue()
		{
			this.InitializeComponent();
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x0003CA58 File Offset: 0x0003BA58
		public NoeudsDemoDialogue(SortedList traces, SortedList nonTraces, Simulation s)
		{
			this.InitializeComponent();
			this.reseau = s;
			foreach (object obj in traces.Values)
			{
				Noeud noeud = (Noeud)obj;
				this.lb_traces.Items.Add(noeud.NomNoeud);
			}
			foreach (object obj2 in nonTraces.Values)
			{
				Noeud noeud2 = (Noeud)obj2;
				if (noeud2.GetType() != typeof(Internet))
				{
					this.lb_nonTraces.Items.Add(noeud2.NomNoeud);
				}
			}
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x0003D0A4 File Offset: 0x0003C0A4
		private void transferer(ListBox source, ListBox dest)
		{
			SortedList sortedList = new SortedList();
			foreach (object obj in source.SelectedIndices)
			{
				int num = (int)obj;
				sortedList.Add(num, num);
			}
			for (int i = sortedList.Count - 1; i >= 0; i--)
			{
				int index = (int)sortedList.GetByIndex(i);
				object item = source.Items[index];
				source.Items.RemoveAt(index);
				dest.Items.Add(item);
			}
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x0003D16C File Offset: 0x0003C16C
		private void transfererTout(ListBox source, ListBox dest)
		{
			int count = source.Items.Count;
			for (int i = count - 1; i > -1; i--)
			{
				object item = source.Items[i];
				source.Items.RemoveAt(i);
				dest.Items.Add(item);
			}
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x0003D1BC File Offset: 0x0003C1BC
		private void bt_ok_Click(object sender, EventArgs e)
		{
			this.reseau.NoeudsNonDemo.Clear();
			this.reseau.NoeudsDemo.Clear();
			for (int i = 0; i < this.lb_nonTraces.Items.Count; i++)
			{
				string key = this.lb_nonTraces.Items[i].ToString();
				Noeud value = (Noeud)this.reseau.Noeuds[key];
				this.reseau.NoeudsNonDemo.Add(key, value);
			}
			if (this.reseau.InternetPresent)
			{
				this.reseau.NoeudsNonDemo.Add("", this.reseau.ReseauInternet);
			}
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x0003D274 File Offset: 0x0003C274
		private void bt_versTraces_Click(object sender, EventArgs e)
		{
			this.transferer(this.lb_nonTraces, this.lb_traces);
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x0003D294 File Offset: 0x0003C294
		private void bt_versNonTraces_Click(object sender, EventArgs e)
		{
			this.transferer(this.lb_traces, this.lb_nonTraces);
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0003D2B4 File Offset: 0x0003C2B4
		private void bt_tousVersTraces_Click(object sender, EventArgs e)
		{
			this.transfererTout(this.lb_nonTraces, this.lb_traces);
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x0003D2D4 File Offset: 0x0003C2D4
		private void bt_tousVersNonTraces_Click(object sender, EventArgs e)
		{
			this.transfererTout(this.lb_traces, this.lb_nonTraces);
		}

		// Token: 0x04000409 RID: 1033
		private Simulation reseau;
	}
}
