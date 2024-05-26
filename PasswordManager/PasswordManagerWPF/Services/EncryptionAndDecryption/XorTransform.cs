using System.Security.Cryptography;

namespace PasswordManagerWPF.Services.EncryptionAndDecryption
{
    public class XorTransform(byte key) : ICryptoTransform
    {
        public bool CanReuseTransform => false;
        public bool CanTransformMultipleBlocks => false;
        public int InputBlockSize => 1;
        public int OutputBlockSize => 1;

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

        public void Dispose()
        {
        }
    }
}