using System;

namespace Simulateur
{
	// Token: 0x02000055 RID: 85
	public class Ip_quartet
	{
		// Token: 0x060004A3 RID: 1187 RVA: 0x00032860 File Offset: 0x00031860
		public Ip_quartet()
		{
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x00032880 File Offset: 0x00031880
		public Ip_quartet(string val)
		{
			string[] array = val.Split(new char[]
			{
				'.'
			});
			for (int i = 0; i < 4; i++)
			{
				this.octets[i] = byte.Parse(array[i]);
			}
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x000328D0 File Offset: 0x000318D0
		public Ip_quartet(uint valBinaire)
		{
			this.octets[0] = (byte)(valBinaire / 16777216U);
			valBinaire -= (uint)this.octets[0] * 16777216U;
			this.octets[1] = (byte)(valBinaire / 65536U);
			valBinaire -= (uint)this.octets[1] * 65536U;
			this.octets[2] = (byte)(valBinaire / 256U);
			valBinaire -= (uint)this.octets[2] * 256U;
			this.octets[3] = (byte)valBinaire;
		}

		// Token: 0x1700008B RID: 139
		public byte this[int i]
		{
			get
			{
				return this.octets[i];
			}
			set
			{
				this.octets[i] = value;
			}
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x00032990 File Offset: 0x00031990
		public static uint ValBinaire(Ip_quartet adr)
		{
			return (uint)adr[3] + (uint)adr[2] * 256U + (uint)adr[1] * 65536U + (uint)adr[0] * 16777216U;
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x000329D0 File Offset: 0x000319D0
		public static bool MemeReseau(string adresse1, string adresse2, string masque)
		{
			return Ip_quartet.MemeReseau(new Ip_quartet(adresse1), new Ip_quartet(adresse2), new Ip_quartet(masque));
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x000329F4 File Offset: 0x000319F4
		public static uint ValReseau(Ip_quartet adr, Ip_quartet masque)
		{
			uint num = Ip_quartet.ValBinaire(adr);
			uint num2 = Ip_quartet.ValBinaire(masque);
			return num & num2;
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00032A14 File Offset: 0x00031A14
		public static uint ValPoste(Ip_quartet adr, Ip_quartet masque)
		{
			uint num = Ip_quartet.ValBinaire(adr);
			uint num2 = Ip_quartet.ValBinaire(masque);
			return num - (num & num2);
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x00032A34 File Offset: 0x00031A34
		public static uint Full1(Ip_quartet masque)
		{
			Ip_quartet adr = new Ip_quartet("255.255.255.255");
			return Ip_quartet.ValPoste(adr, masque);
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x00032A58 File Offset: 0x00031A58
		public static bool MemeReseau(Ip_quartet adr1, Ip_quartet adr2, Ip_quartet masque)
		{
			uint num = Ip_quartet.ValReseau(adr1, masque);
			uint num2 = Ip_quartet.ValReseau(adr2, masque);
			return num == num2;
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x00032A7C File Offset: 0x00031A7C
		public static bool Ok(string adresse)
		{
			int startIndex = 0;
			int num = 0;
			for (int num2 = adresse.IndexOf('.', startIndex); num2 != -1; num2 = adresse.IndexOf('.', startIndex))
			{
				num++;
				startIndex = num2 + 1;
			}
			bool flag = num == 3;
			if (flag)
			{
				try
				{
					byte[] array = new byte[4];
					string[] array2 = adresse.Split(new char[]
					{
						'.'
					});
					for (int i = 0; i < 4; i++)
					{
						array[i] = byte.Parse(array2[i]);
					}
					return true;
				}
				catch
				{
					return false;
				}
				return flag;
			}
			return flag;
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x00032B24 File Offset: 0x00031B24
		public static bool IsNull(Ip_quartet q)
		{
			return q.octets[0] == 0 && q.octets[1] == 0 && q.octets[2] == 0 && q.octets[3] == 0;
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00032B5C File Offset: 0x00031B5C
		public static bool MasqueOk(string masque)
		{
			if (!Ip_quartet.Ok(masque))
			{
				return false;
			}
			Ip_quartet ip_quartet = new Ip_quartet(masque);
			for (int i = 0; i < 4; i++)
			{
				if (!Ip_quartet.OctetMasqueOk(ip_quartet[i]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00032B98 File Offset: 0x00031B98
		public static bool OctetMasqueOk(byte octet)
		{
			return octet == 0 || octet == 128 || octet == 192 || octet == 224 || octet == 240 || octet == 248 || octet == 252 || octet == 254 || octet == byte.MaxValue;
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x00032BEC File Offset: 0x00031BEC
		public override string ToString()
		{
			string str = "";
			for (int i = 0; i < 3; i++)
			{
				str = str + this.octets[i].ToString() + ".";
			}
			return str + this.octets[3].ToString();
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00032C44 File Offset: 0x00031C44
		public static string FormatFixe(Ip_quartet q)
		{
			return Ip_quartet.FormatFixe(q.ToString());
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x00032C5C File Offset: 0x00031C5C
		public static string FormatFixe(string sq)
		{
			int num = 15 - sq.Length;
			for (int i = 0; i < num; i++)
			{
				sq += " ";
			}
			return sq;
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x00032C90 File Offset: 0x00031C90
		public bool IsAdressePrivee()
		{
			return this.octets[0] == 10 || (this.octets[0] == 172 && this.octets[1] >= 16 && this.octets[1] <= 31) || (this.octets[0] == 192 && this.octets[1] == 168);
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00032CF8 File Offset: 0x00031CF8
		public static bool Isnul(string strAdr)
		{
			if (Ip_quartet.Ok(strAdr))
			{
				Ip_adresse ip_adresse = new Ip_adresse(strAdr);
				return ip_adresse.Isnul();
			}
			return false;
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00032D1C File Offset: 0x00031D1C
		public bool Isnul()
		{
			return this.ToString().Trim() == "0.0.0.0";
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x00032D40 File Offset: 0x00031D40
		public string AdresseReseau(Ip_masque masque)
		{
			uint valBinaire = Ip_quartet.ValReseau(this, masque);
			Ip_quartet ip_quartet = new Ip_quartet(valBinaire);
			return ip_quartet.ToString();
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x00032D64 File Offset: 0x00031D64
		public string AdresseBroadcast(Ip_masque masque)
		{
			uint num = Ip_quartet.ValReseau(this, masque);
			uint num2 = Ip_quartet.ValPoste(new Ip_quartet("255.255.255.255"), masque);
			Ip_quartet ip_quartet = new Ip_quartet(num | num2);
			return ip_quartet.ToString();
		}

		// Token: 0x04000354 RID: 852
		private byte[] octets = new byte[4];

		// Token: 0x04000355 RID: 853
		private static Random rnd = new Random();
	}
}
