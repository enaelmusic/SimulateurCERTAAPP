using System;

namespace Simulateur
{
	// Token: 0x02000057 RID: 87
	public class Ip_masque : Ip_quartet
	{
		// Token: 0x060004C3 RID: 1219 RVA: 0x00033120 File Offset: 0x00032120
		public Ip_masque(string adresse) : base(adresse)
		{
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x00033134 File Offset: 0x00032134
		public static string GetMasqueDefaut(string adresse)
		{
			string result = "";
			Ip_adresse ip_adresse = new Ip_adresse(adresse);
			switch (ip_adresse.Classe)
			{
			case 'a':
				result = "255.0.0.0";
				break;
			case 'b':
				result = "255.255.0.0";
				break;
			case 'c':
				result = "255.255.255.0";
				break;
			}
			return result;
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x00033184 File Offset: 0x00032184
		public static Ip_masque GetMasqueDefaut(Ip_adresse adresse)
		{
			Ip_masque result = new Ip_masque("0.0.0.0");
			switch (adresse.Classe)
			{
			case 'a':
				result = new Ip_masque("255.0.0.0");
				break;
			case 'b':
				result = new Ip_masque("255.255.0.0");
				break;
			case 'c':
				result = new Ip_masque("255.255.255.0");
				break;
			}
			return result;
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x000331E0 File Offset: 0x000321E0
		public static int NbBits(Ip_masque m)
		{
			int num = 0;
			int num2 = 0;
			while (num2 < 4 && m[num2] != 0)
			{
				num += (int)Math.Round(Math.Log((double)m[num2], 2.0));
				num2++;
			}
			return num;
		}
	}
}
