using System;
using System.Collections;
using System.IO;
using System.Management;

namespace Simulateur
{
	// Token: 0x0200007A RID: 122
	public class Protection
	{
		// Token: 0x0600076E RID: 1902 RVA: 0x00045A50 File Offset: 0x00044A50
		private static string getLicence(string numeroDisque)
		{
			long num = (long)numeroDisque.GetHashCode();
			int num2 = numeroDisque.Length / 6;
			int num3 = numeroDisque.Length % 6;
			int num4 = 1;
			for (int i = 0; i < 6; i++)
			{
				string text = numeroDisque.Substring(num3, num2);
				num += (long)(num4 * text.GetHashCode());
				num4 = -num4;
				num3 += num2;
			}
			return Math.Abs(Convert.ToDecimal(num)).ToString();
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x00045ABC File Offset: 0x00044ABC
		private static string getDisque()
		{
			string result;
			try
			{
				ManagementScope scope = new ManagementScope("\\\\.\\root\\cimv2");
				ObjectQuery query = new ObjectQuery("select * from Win32_DiskDrive");
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(scope, query);
				ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
				IEnumerator enumerator = managementObjectCollection.GetEnumerator();
				enumerator.MoveNext();
				ManagementObject managementObject = (ManagementObject)enumerator.Current;
				result = managementObject["PNPDeviceId"].ToString();
			}
			catch (Exception)
			{
				result = "???";
			}
			return result;
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x00045C40 File Offset: 0x00044C40
		private static string getKey(string licence)
		{
			int[] array = new int[]
			{
				15,
				1,
				12,
				4,
				9,
				6,
				13,
				44,
				25,
				18,
				3,
				7,
				9,
				12,
				5,
				7,
				13,
				17,
				2,
				3
			};
			int[] array2 = new int[]
			{
				1,
				4,
				9,
				7,
				3,
				5,
				6,
				4,
				8,
				2,
				1,
				5,
				19,
				4,
				7,
				6,
				8,
				2,
				5,
				9
			};
			int[] array3 = new int[]
			{
				22,
				7,
				5,
				3,
				8,
				8,
				25,
				12,
				7,
				9,
				0,
				2,
				10,
				5,
				9,
				3,
				4,
				1,
				2,
				7
			};
			string text = "";
			string text2 = licence;
			int num;
			if ((double)(text2.Length / 2) == (double)text2.Length / 2.0)
			{
				licence = "";
				num = text2.Length - 2;
			}
			else
			{
				licence = text2[text2.Length - 1].ToString();
				num = text2.Length - 3;
			}
			for (int i = 0; i <= num; i += 2)
			{
				licence = licence + text2[i + 1].ToString() + text2[i].ToString();
			}
			int num2 = 0;
			for (int j = 0; j < licence.Length; j++)
			{
				num2 += int.Parse(licence[j].ToString());
			}
			for (int k = 0; k < licence.Length; k++)
			{
				int num3 = int.Parse(licence[k].ToString());
				num3 = num2 * ((num3 + array[k]) * array2[k]) - array3[k];
				num3 = Math.Abs(num3);
				num3 %= 26;
				text += Convert.ToChar(65 + num3).ToString();
			}
			return text;
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x00045DC4 File Offset: 0x00044DC4
		public static bool OkToGo()
		{
			bool result;
			try
			{
				StreamReader streamReader = new StreamReader("keys.lic");
				bool flag = false;
				string disque = Protection.getDisque();
				if (disque != "???")
				{
					string licence = Protection.getLicence(disque);
					string key = Protection.getKey(licence);
					string text = streamReader.ReadLine();
					while (!flag && text != null)
					{
						string[] array = text.Split(new char[]
						{
							'\t'
						});
						if (array[1] == licence && array[2] == key)
						{
							flag = true;
						}
						else
						{
							text = streamReader.ReadLine();
						}
					}
				}
				streamReader.Close();
				result = flag;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
	}
}
