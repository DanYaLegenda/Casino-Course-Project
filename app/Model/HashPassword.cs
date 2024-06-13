using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CasinoSimulation.Model
{
    public class HashPassword
    {
        public static string Hash(string password)
        {
            MD5 mD5 = MD5.Create();
            byte[] b = Encoding.ASCII.GetBytes(password);
            byte[] hash = mD5.ComputeHash(b);

            StringBuilder sb = new StringBuilder();
            foreach (byte b2 in hash)
            {
                sb.Append(b2);
            }

            return Convert.ToString(sb);
        }
    }
}
