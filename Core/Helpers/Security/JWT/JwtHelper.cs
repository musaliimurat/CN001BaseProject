using Core.Entities.Concrete;
using Core.Extensions;
using Core.Helpers.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        private DateTime _expirationDate;
        private TokenOptions _tokenOptions;
        private IConfiguration _configuration { get; }


        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateAccessToken(User user, List<OperationClaim> opeartionClaims)
        {
            _expirationDate = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredential(securityKey);
            var jwt = CreateJwtSecurityToken(user, _tokenOptions, signingCredentials, opeartionClaims);
            var jwtSecurityHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityHandler.WriteToken(jwt);

            return new AccessToken
            {
                Expiration = _expirationDate,
                Token = token,
            };
        }

        private SecurityToken CreateJwtSecurityToken(User user, TokenOptions tokenOptions, SigningCredentials signingCredentials, List<OperationClaim> opeartionClaims)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                 issuer: tokenOptions.Issuer,
                 audience: tokenOptions.Audience,
                 expires: _expirationDate,
                 notBefore: DateTime.Now,
                 signingCredentials: signingCredentials,
                 claims: SetClaims( user, opeartionClaims)
                );
            return jwtSecurityToken;
        }

        private static List<Claim> SetClaims(User user, List<OperationClaim> opeartionClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier($"{user.Id}");
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddEmail(user.Email);
            claims.AddRoles(opeartionClaims.Select(r=>r.Name).ToArray());

            {
                //id: 2
                // name : murad musali
                // Email: musalimurat@gmail.com
                // Role : [admin, moderator]
            }
            //List<Claim> claims = [
            //    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            //    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            //    new Claim(ClaimTypes.Email, user.Email),
            //    ];

            //foreach (var claim in opeartionClaims)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, claim.Name));
            //}


            return claims;

        }
    }
}
