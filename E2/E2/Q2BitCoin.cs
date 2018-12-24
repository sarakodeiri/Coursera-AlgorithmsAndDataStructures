using System;
using System.Security.Cryptography;

namespace E2
{
    public class Q2BitCoin
    {
        private SHA256Managed Hasher= new SHA256Managed();

        /// <summary>
        /// این پیاده سازی کار نمیکنه چون فقط یک عدد را امتحان میکند
        /// باید این پیاده سازی را طوری عوض کنید که یک 
        /// nonce 
        /// درست را پیدا کند.
        /// </summary>
        public bool Mine(byte[] data, int difficultyLevel, out uint nonce)
        {
            Random rnd = new Random(0);

            for (int i=0; i<int.MaxValue; i++)
            {
                nonce = (uint)i;

                BitConverter.GetBytes(nonce).CopyTo(data, sizeof(uint));

                byte[] doubleHash = Hasher.ComputeHash(Hasher.ComputeHash(data));

                int zeroBytes = CountEndingZeroBytes(
                    doubleHash,
                    difficultyLevel);

                if (zeroBytes >= difficultyLevel)
                    return true;
            }

            nonce = 0;
            return false;
            
        }

        public static int CountEndingZeroBytes(byte[] doubleHash, int? maxBytesToCheck = null)
        {
            int zeroBytes = 0;
            for (int i = doubleHash.Length - 1;
                     i >= doubleHash.Length - (maxBytesToCheck??doubleHash.Length);
                     i--, zeroBytes++)
            {
                if (doubleHash[i] > 0)
                    break;
            }
            return zeroBytes;
        }
    }
}