using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper    // işin içerisinde şifreleme olan sistemlerde bizim her şeyi bir byte aray formatında veriyor olmamız lazım 
    {
        public static SecurityKey CreateSecurityKey(string securityKey)// appjson.app yazdıgımız securityKey ver ve onu byte çevir simetrik
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)); // ?????
        }
    }
}
