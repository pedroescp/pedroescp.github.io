﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace uNotes.Api.Security
{
    public sealed class JwtTokenBuilder
    {
        private SecurityKey securityKey = null;
        private string subject = "";
        private string issuer = "";
        private string audience = "";
        private Dictionary<string, string> claims = new Dictionary<string, string>();
        private int expiryInMinutes = 5;

        public JwtTokenBuilder AddSecurityKey(SecurityKey securityKey)
        {
            this.securityKey = securityKey;
            return this;
        }

        public JwtTokenBuilder AddSubject(string subject)
        {
            this.subject = subject;
            return this;
        }

        public JwtTokenBuilder AddIssuer(string issuer)
        {
            this.issuer = issuer;
            return this;
        }

        public JwtTokenBuilder AddAudience(string audience)
        {
            this.audience = audience;
            return this;
        }

        public JwtTokenBuilder AddClaim(string type, string value)
        {
            this.claims.Add(type, value);
            return this;
        }

        public JwtTokenBuilder AddClaims(Dictionary<string, string> claims)
        {
            this.claims.Union(claims);
            return this;
        }

        public JwtTokenBuilder AddExpiry(int expiryInMinutes)
        {
            this.expiryInMinutes = expiryInMinutes;
            return this;
        }

        public JwtToken Build(string codigo, string nome)
        {
            EnsureArguments();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, this.subject),
                new Claim(JwtRegisteredClaimNames.Jti, "WebAPI.Security.Bearer"),
                new Claim(ClaimTypes.NameIdentifier, codigo),
                new Claim(ClaimTypes.Name, nome)

            }
            .Union(this.claims.Select(item => new Claim(item.Key, item.Value)));

            var token = new JwtSecurityToken(
                              issuer: this.issuer,
                              audience: this.audience,
                              claims: claims,
                              expires: DateTime.Now.AddDays(1), //DateTime.UtcNow.AddMinutes(expiryInMinutes),
                              signingCredentials: new SigningCredentials(
                                                        this.securityKey,
                                                        SecurityAlgorithms.HmacSha256));

            return new JwtToken(token);
        }

        public string GetSession(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(token))
                return string.Concat("IP: ", context.Connection.RemoteIpAddress.ToString());

            var identity = context.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                //IEnumerable<Claim> claims = identity.Claims;
                //// or
                //identity.FindFirst("ClaimName").Value;
            }

            //    token = token.Replace("Bearer ", string.Empty);

            //    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            //    ClaimsPrincipal principal = tokenHandler.GetPrincipal(token);

            //    return string.Concat("CodigoBeneficiario: ", principal.FindFirst(ClaimTypes.NameIdentifier).Value);

            return "";
        }

        private void EnsureArguments()
        {
            if (this.securityKey == null)
                throw new ArgumentNullException("Security Key");

            if (string.IsNullOrEmpty(this.subject))
                throw new ArgumentNullException("Subject");

            if (string.IsNullOrEmpty(this.issuer))
                throw new ArgumentNullException("Issuer");

            if (string.IsNullOrEmpty(this.audience))
                throw new ArgumentNullException("Audience");
        }
    }
}
