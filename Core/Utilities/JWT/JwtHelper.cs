using Core.Entities;
using Core.Utilities.Encryption;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.JWT
{
    public class JwtHelper :ITokenHelper
    { 
        private readonly TokenOptions _tokenOptions;
        //token test 01:14
        public JwtHelper(TokenOptions tokenOptions)
        {
            _tokenOptions = tokenOptions;
        }



        //jwt yi create edecek ve geriye döndürecek class 41.dk
        public AccessToken CreateToken(BaseUser user)
        {
            //özellikleri oku ve tokeni yaz.
            DateTime expirationTime = DateTime.UtcNow.AddMinutes(_tokenOptions.ExpirationTime);
            SecurityKey key = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()), // Kullanıcının ID'si
                new Claim(JwtRegisteredClaimNames.Email, user.Email), // Kullanıcının emaili
                new Claim("ReceiverId", user.Id.ToString()) // Kullanıcının ID'si custom claim olarak
                // Diğer claimleri burada ekleyebilirsiniz
            };

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expirationTime,
                signingCredentials: signingCredentials);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            string jwtToken =  jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken() { Token = jwtToken, ExpirationDate = expirationTime };
        }
    }
}
