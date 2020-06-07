using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace Security
{
    public class TokenHandler : ITokenHandler
    {
        private readonly TokenOptions tokenOptions;
        public TokenHandler(IOptions<TokenOptions> tokenOptions)
        {
            this.tokenOptions = tokenOptions.Value;
        }


        public AccessToken CreateAccessToken(TUser user)
        {

            var accesstokenExpiration = DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration);

            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var securityKey = SignHandler.GetSecurityKey(tokenOptions.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: accesstokenExpiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials,
                claims: GetClaim(user)
                );

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);
            AccessToken accessToken = new AccessToken();
            accessToken.Token = token;
            accessToken.RefreshToken = CreateRefreshToken();
            accessToken.Expiration = accesstokenExpiration;

            return accessToken;
        }

        private IEnumerable<Claim> GetClaim(TUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email.ToString()),
                new Claim(ClaimTypes.Name, $"{user.Name} {user.SurName}"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            return claims;
        }

        private string CreateRefreshToken()
        {
            //return Guid.NewGuid();
            var numberByte = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(numberByte);
                return Convert.ToBase64String(numberByte);
            }

        }

        public void RevokeRefreshToken(TUser user)
        {
            user.RefreshToken = null;
            //db save
        }
    }
}
