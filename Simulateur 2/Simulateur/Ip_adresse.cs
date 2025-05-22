using System;
using System.Windows.Forms;

namespace Simulateur
{
	// Token: 0x02000056 RID: 86
	public class Ip_adresse : Ip_quartet
	{
		// Token: 0x060004BB RID: 1211 RVA: 0x00032DB4 File Offset: 0x00031DB4
		public Ip_adresse(string adresse) : base(adresse)
		{
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x00032DC8 File Offset: 0x00031DC8
		public Ip_adresse(Ip_quartet q) : base(q.ToString())
		{
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060004BD RID: 1213 RVA: 0x00032DE4 File Offset: 0x00031DE4
		public char Classe
		{
			get
			{
				if (base[0] >= 192)
				{
					return 'c';
				}
				if (base[0] >= 128)
				{
					return 'b';
				}
				return 'a';
			}
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00032E18 File Offset: 0x00031E18
		public new static bool Ok(string adresse)
		{
			if (Ip_quartet.Ok(adresse))
			{
				Ip_quartet ip_quartet = new Ip_quartet(adresse);
				return ip_quartet[0] < 224;
			}
			return false;
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x00032E44 File Offset: 0x00031E44
		public static bool Existe(string adr, Control reseau)
		{
			if (adr != "0.0.0.0")
			{
				foreach (object obj in reseau.Controls)
				{
					ElementReseau elementReseau = (ElementReseau)obj;
					if (elementReseau.GetType() == typeof(Station))
					{
						foreach (object obj2 in ((Station)elementReseau).Controls)
						{
							CarteReseau carteReseau = (CarteReseau)obj2;
							if (carteReseau.Ip.Adresse.ToString() == adr)
							{
								return true;
							}
						}
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x00032F44 File Offset: 0x00031F44
		public static bool Ok(string adresse, string masque)
		{
			if (adresse == "0.0.0.0")
			{
				return true;
			}
			if (!Ip_quartet.MasqueOk(masque))
			{
				return false;
			}
			if (Ip_quartet.Ok(adresse))
			{
				Ip_quartet ip_quartet = new Ip_quartet(adresse);
				Ip_quartet masque2 = new Ip_quartet(masque);
				return ip_quartet[0] < 224 && ip_quartet[0] != 0 && ip_quartet[0] != 127 && Ip_quartet.ValPoste(ip_quartet, masque2) != 0U && Ip_quartet.ValPoste(ip_quartet, masque2) != Ip_quartet.Full1(masque2);
			}
			return false;
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00032FC4 File Offset: 0x00031FC4
		public static void SeparerAdrEtNbBits(string ipStr, out Ip_adresse adrIp, out int nbBits, out Ip_masque masque)
		{
			int num = ipStr.IndexOf("/");
			string adresse = ipStr.Substring(0, num);
			string s = ipStr.Substring(num + 1);
			adrIp = new Ip_adresse(adresse);
			nbBits = int.Parse(s);
			uint num2 = 0U;
			int num3 = 31;
			for (int i = nbBits; i > 0; i--)
			{
				num2 += (uint)Math.Pow(2.0, (double)num3--);
			}
			masque = new Ip_masque(new Ip_quartet(num2).ToString());
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x00033044 File Offset: 0x00032044
		public static string WithNbBits(string adrIp)
		{
			int num = adrIp.IndexOf("/");
			string result;
			if (num == -1)
			{
				if (!Ip_adresse.Ok(adrIp))
				{
					return null;
				}
				Ip_adresse adr = new Ip_adresse(adrIp);
				Ip_masque ip_masque = new Ip_masque(Ip_masque.GetMasqueDefaut(adrIp));
				if (Ip_quartet.ValBinaire(adr) != Ip_quartet.ValReseau(adr, ip_masque))
				{
					result = adrIp + "/32";
				}
				else
				{
					result = adrIp + "/" + Ip_masque.NbBits(ip_masque).ToString();
				}
			}
			else
			{
				string adresse = adrIp.Substring(0, num);
				string s = adrIp.Substring(num + 1);
				if (!Ip_adresse.Ok(adresse))
				{
					return null;
				}
				try
				{
					int num2 = int.Parse(s);
					if (num2 > 0 && num2 <= 32)
					{
						return adrIp;
					}
					return null;
				}
				catch
				{
					return null;
				}
				return result;
			}
			return result;
		}
	}
}
