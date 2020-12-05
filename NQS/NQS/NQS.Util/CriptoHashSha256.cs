using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Leega.Util
{
    public static class CriptoHashSha256
    {
        public static string GetSha256Hash(this string entrada)
        {
            entrada = entrada + "BP=Atun}`+1S*nOmD||x,m&=QSPu4*-d#)duwKGL@;%_a*89+h[)RGXJ6&C_ok|_";
            byte[] data = Encoding.ASCII.GetBytes(entrada);
            data = new SHA256Managed().ComputeHash(data);
            var hash = string.Empty;
            foreach (byte theByte in data)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}
