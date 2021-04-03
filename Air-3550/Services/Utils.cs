using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Air_3550.Services
{
    static class Utils
    {
        public static string GenerateSHA512(string password)
        {
            SHA512 shaM = SHA512.Create();
            byte[] data = Encoding.UTF8.GetBytes(password);
            byte[] result = shaM.ComputeHash(data);
            return BitConverter.ToString(result);
        }
    }
}
