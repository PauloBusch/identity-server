using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Identity.Domain.Security
{
    public class SigningConfig
    {
        public SecurityKey Key { get; private set; }
        public SigningCredentials Credentials { get; private set; }

        public SigningConfig(TokenConfig config)
        {
            Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.Key));
            Credentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
