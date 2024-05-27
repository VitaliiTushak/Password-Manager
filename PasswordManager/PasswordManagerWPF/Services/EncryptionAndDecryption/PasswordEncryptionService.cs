using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManagerWPF.Services.EncryptionAndDecryption
{
    public class PasswordEncryptionService
    {
        private const byte Key = 0x7F;

        public static string Encrypt(string plainText)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            for (int i = 0; i < plainBytes.Length; i++)
            {
                plainBytes[i] = (byte)(plainBytes[i] ^ Key);
            }

            return Convert.ToBase64String(plainBytes);
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, new XorTransform(Key), CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}
