using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Plans.Foundation.AuthOptions
{
    public static class JwtAuthOptions
    {
        public const string ISSUER = "Plans";
        public const string AUDIENCE = "Browser";
        public const string KEY = "UnbelievablyComplexKey";
        public const int LIFETIME = 1;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}