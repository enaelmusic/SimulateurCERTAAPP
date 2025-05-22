using System;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x0200007C RID: 124
	public class RamSwitch
	{
		// Token: 0x06000783 RID: 1923 RVA: 0x000465FC File Offset: 0x000455FC
		public RamSwitch()
		{
			this.buffers[0] = new BufferTrame();
			this.buffers[1] = new BufferTrame();
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000784 RID: 1924 RVA: 0x00046638 File Offset: 0x00045638
		public Timer DelaiReemissionTrameComplete0
		{
			get
			{
				return this.buffers[0].DelaiReemissionTrameComplete;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000785 RID: 1925 RVA: 0x00046654 File Offset: 0x00045654
		public Timer DelaiReemissionTrameComplete1
		{
			get
			{
				return this.buffers[1].DelaiReemissionTrameComplete;
			}
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x00046670 File Offset: 0x00045670
		public BufferTrame BufferLibre()
		{
			if (this.buffers[0].NumeroTrame == 0)
			{
				return this.buffers[0];
			}
			return this.buffers[1];
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x000466A0 File Offset: 0x000456A0
		public int numeroBuffer(BufferTrame buffer)
		{
			if (this.buffers[0] == buffer)
			{
				return 0;
			}
			return 1;
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x000466BC File Offset: 0x000456BC
		public BufferTrame getBuffer(int numBuffer)
		{
			if (numBuffer == 0)
			{
				return this.buffers[0];
			}
			return this.buffers[1];
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x000466E0 File Offset: 0x000456E0
		public BufferTrame getBufferTrame(int numeroTrame)
		{
			if (this.buffers[0].Trame.NumeroTrame == numeroTrame)
			{
				return this.buffers[0];
			}
			return this.buffers[1];
		}

		// Token: 0x0400049D RID: 1181
		private BufferTrame[] buffers = new BufferTrame[2];
	}
}
