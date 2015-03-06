using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace PesquisasNet.Util
{
    public class Seguranca
    {
        public static string GerarPBKDF2(string valor)
        {
            var saltString = "ABCDEF123456";
            var saltBytes = new byte[saltString.Length * sizeof(char)];

            // Copia string padrão de salt para array de bytes
            Buffer.BlockCopy(saltString.ToCharArray(), 0, saltBytes, 0, saltBytes.Length);

            using (var pbkdf2 = new Rfc2898DeriveBytes(valor, saltBytes))
            {
                var pseudoRandomKey = pbkdf2.GetBytes(24);

                return Convert.ToBase64String(pseudoRandomKey);
            }
        }
    }
}