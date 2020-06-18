using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEA
{
	public class TEA
    {
		
		// Ctor
		public TEA()
		{
		}

		public string Encrypt(string Data, string Key)
		{
			/*if (Data.Length == 0)
			throw new ArgumentException("Data must be at least 1 character in length.");
			*/
			uint[] formattedKey = FormatKey(Key);

			if (Data.Length % 2 != 0) Data += '\0'; // Make sure array is even in length.		
			byte[] dataBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(Data);

			string cipher = string.Empty;
			uint[] tempData = new uint[2];
			for (int i = 0; i < dataBytes.Length; i += 2)
			{
				tempData[0] = dataBytes[i];
				tempData[1] = dataBytes[i + 1];
				code(tempData, formattedKey);
				cipher += Util.ConvertUIntToString(tempData[0]) + Util.ConvertUIntToString(tempData[1]);
			}

			return cipher;
		}

		public string Decrypt(string Data, string Key)
		{
			uint[] formattedKey = FormatKey(Key);

			int x = 0;
			uint[] tempData = new uint[2];
			byte[] dataBytes = new byte[Data.Length / 8 * 2];
			for (int i = 0; i < Data.Length; i += 8)
			{
				tempData[0] = Util.ConvertStringToUInt(Data.Substring(i, 4));
				tempData[1] = Util.ConvertStringToUInt(Data.Substring(i + 4, 4));
				decode(tempData, formattedKey);
				dataBytes[x++] = (byte)tempData[0];
				dataBytes[x++] = (byte)tempData[1];
			}

			string decipheredString = System.Text.ASCIIEncoding.ASCII.GetString(dataBytes, 0, dataBytes.Length);
			if (decipheredString[decipheredString.Length - 1] == '\0') // Strip the null char if it was added.
				decipheredString = decipheredString.Substring(0, decipheredString.Length - 1);
			return decipheredString;
		}

		public uint[] FormatKey(string Key)
		{
			/*if (Key.Length == 0)
				throw new ArgumentException("Key must be between 1 and 16 characters in length");
			*/
			Key = Key.PadRight(16, ' ').Substring(0, 16); // Ensure that the key is 16 chars in length.
			uint[] formattedKey = new uint[4];

			// Get the key into the correct format for TEA usage.
			int j = 0;
			for (int i = 0; i < Key.Length; i += 4)
				formattedKey[j++] = Util.ConvertStringToUInt(Key.Substring(i, 4));

			return formattedKey;
		}

		#region Tea Algorithm
		public void code(uint[] v, uint[] k)
		{
			uint y = v[0];
			uint z = v[1];
			uint sum = 0;
			uint delta = 0x9e3779b9;
			uint n = 32;

			while (n-- > 0)
			{
				sum += delta;
				y += (z << 4) + k[0] ^ z + sum ^ (z >> 5) + k[1];
				z += (y << 4) + k[2] ^ y + sum ^ (y >> 5) + k[3];
			}

			v[0] = y;
			v[1] = z;
		}

		public void decode(uint[] v, uint[] k)
		{
			uint n = 32;
			uint sum;
			uint y = v[0];
			uint z = v[1];
			uint delta = 0x9e3779b9;

			sum = delta << 5;

			while (n-- > 0)
			{
				z -= (y << 4) + k[2] ^ y + sum ^ (y >> 5) + k[3];
				y -= (z << 4) + k[0] ^ z + sum ^ (z >> 5) + k[1];
				sum -= delta;
			}

			v[0] = y;
			v[1] = z;
		}
		#endregion
	}
}
