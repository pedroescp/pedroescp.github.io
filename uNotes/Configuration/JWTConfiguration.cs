using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using uNotes.Infra.CrossCutting.Configuracoes;

namespace uNotes.Api.Configuration
{
    public static class JWTConfiguration
    {
        public static void AddJwtAuthentication(this IServiceCollection services)
        {
            var secretKey = JwtConfig.ObterChaveSecreta;

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(IdentityConstants.ApplicationScheme);
        }
    }
}
