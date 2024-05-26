using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManagerWPF.Services
{
    public class PasswordEncryptionService
    {
        private const byte Key = 0x7F; // Простий ключ XOR

        public static string Encrypt(string plainText)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            for (int i = 0; i < plainBytes.Length; i++)
            {
                plainBytes[i] = (byte)(plainBytes[i] ^ Key); // XOR операція з ключем
            }

            return Convert.ToBase64String(plainBytes); // Повертаємо у вигляді Base64
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

    public class XorTransform : ICryptoTransform
    {
        private readonly byte key;

        public XorTransform(byte key)
        {
            this.key = key;
        }

        public bool CanReuseTransform => false;
        public bool CanTransformMultipleBlocks => false;
        public int InputBlockSize => 1;
        public int OutputBlockSize => 1;

        public void Dispose()
        {
        }

        public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
        {
            for (int i = 0; i < inputCount; i++)
            {
                outputBuffer[outputOffset + i] = (byte)(inputBuffer[inputOffset + i] ^ key);
            }
            return inputCount;
        }

        public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
        {
            byte[] outputBuffer = new byte[inputCount];
            TransformBlock(inputBuffer, inputOffset, inputCount, outputBuffer, 0);
            return outputBuffer;
        }
    }
}
