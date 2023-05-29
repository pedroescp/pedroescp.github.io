using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.Configuracoes;

namespace uNotes.Domain.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepository _usuarioRepository;

        public AutenticacaoService(IConfiguration configuration, IUsuarioRepository usuarioRepository)
        {
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
        }

        public string GerarTokenClaims(string email)
        {
            var usuario = _usuarioRepository.ObterPorEmailOuLogin(email);

            var claims = ObterClaimsDoUsuario(usuario);

            var chaveSecreta = _configuration["JWT:ChaveSecreta"];
            var expiracaoHorasStr = _configuration["JWT:ExpiracaoHoras"];
            var issuer = _configuration["JWT:Issuer"];
            var audience = _configuration["JWT:Audience"];
            var expiracaoHoras = int.Parse(expiracaoHorasStr);

            var token = JwtService.GerarToken(claims, issuer, audience, chaveSecreta, expiracaoHoras);

            return token;
        }

        private static List<Claim> ObterClaimsDoUsuario(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim("Cargo", usuario.Cargo?.Nome ?? "")
            };
            return claims;
        }

    }
}

