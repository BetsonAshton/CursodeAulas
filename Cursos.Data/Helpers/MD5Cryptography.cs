using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Data.Helpers
{
    public class MD5Cryptography
    {
        public static string Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);

                var builder = new StringBuilder();
                foreach (var item in hashBytes)
                    builder.Append(item.ToString("x2"));

                return builder.ToString();
            }
        }
    }
}
