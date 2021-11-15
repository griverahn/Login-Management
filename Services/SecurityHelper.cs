using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagemet.Services
{
    public class SecurityHelper
    {
        public string encodePassword(string password)
        {
            SHA256Managed encode = new SHA256Managed();
            byte[] unEncodeString = Encoding.Default.GetBytes(password);

            byte[] encodedPassword = encode.ComputeHash(unEncodeString);

            return BitConverter.ToString(encodedPassword).Replace("-","");
        }
    }
}
