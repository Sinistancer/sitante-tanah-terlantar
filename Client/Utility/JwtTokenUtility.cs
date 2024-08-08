using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Blazor.Client.Utility
{
    public class JwtTokenUtility
    {
        public static List<Claim> DecodeJwtTokenUtility(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();

            if (handler.CanReadToken(accessToken))
            {
                var token = handler.ReadJwtToken(accessToken);
                var claims = token.Claims;

                var claimsList = new List<Claim>();
                foreach (var claim in claims)
                {
                    claimsList.Add(new Claim(claim.Type, claim.Value));
                }

                var sid = Guid.NewGuid().ToString("N").ToUpper();
                claimsList.Add(new Claim("sid", sid));

                return claimsList;
            }

            return null;
        }
    }
}   
