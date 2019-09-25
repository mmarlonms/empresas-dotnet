using Empresas.Domain.Adapters;
using Empresas.Domain.OauthModels;
using Empresas.Domain.Services;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Empresas.Service
{
    public class AuthService : IAuthService
    {
        private readonly IIoasysApiAdapter ioasysApiAdapter;
        private readonly SigningConfigurations signingConfigurations;
        private readonly TokenConfigurations tokenConfigurations;

        public AuthService(IIoasysApiAdapter ioasysApiAdapter, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations)
        {
            this.ioasysApiAdapter = ioasysApiAdapter;
            this.signingConfigurations = signingConfigurations;
            this.tokenConfigurations = tokenConfigurations;
        }

        public object Authorize(string user, string pass)
        {
            var investor = ioasysApiAdapter.Authorize(user, pass);

            if (investor == null)
                throw new Exception();

            ClaimsIdentity identity = new ClaimsIdentity(
                        new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(nameof(investor.Autentication.AccesToken), investor.Autentication.AccesToken ),
                        new Claim(nameof(investor.Autentication.Client), investor.Autentication.Client ),
                        new Claim(nameof(investor.Autentication.Uid), investor.Autentication.Uid ),
                        new Claim("Investor", JsonConvert.SerializeObject(investor)),
                        }
                    );

            return WriteToken(identity);
        }

        private object WriteToken(ClaimsIdentity claimsIdentity)
        {
            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao +
                TimeSpan.FromSeconds(tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = claimsIdentity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });

            var token = handler.WriteToken(securityToken);
            
            var tokenResponse = new
            {
                authenticated = true,
                created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                expires_in = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                access_token = token,
                message = "OK",
                token_type = "Bearer"
            };

            return tokenResponse;
        }
    }
}