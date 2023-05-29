using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace uNotes.Infra.CrossCutting.Configuracoes
{
    public static class JwtService
    {
        public static string GerarToken(
            IEnumerable<Claim> claims,
            string issuer,
            string audience,
            string chaveSecreta,
            int tempoExpiracaoHoras)
        {
            var key = Encoding.ASCII.GetBytes(chaveSecreta);

            var tokenJwt = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(tempoExpiracaoHoras),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature));

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(tokenJwt);
        }

        public static JwtSecurityToken DescriptografarToken(string tokenCriptografado)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(tokenCriptografado);
            return token;
        }
    }
}
