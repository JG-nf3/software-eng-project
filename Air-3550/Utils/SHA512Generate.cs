using System;
using System.Security.Cryptography;
using System.Text;

namespace Air_3550.Utils
{
    /// <summary>
    /// Class to help with SHA512 hshing
    /// </summary>
    internal class SHA512Generate
    {
        /// <summary>
        /// Generate SHA512 hash
        /// </summary>
        /// <param name="password"> string (preferrably password) to hash</param>
        /// <returns>String representation of hash.</returns>
        public static string GenerateSHA512(string password)
        {
            SHA512 shaM = SHA512.Create();
            byte[] data = Encoding.UTF8.GetBytes(password);
            byte[] result = shaM.ComputeHash(data);
            return BitConverter.ToString(result);
        }
    }
}