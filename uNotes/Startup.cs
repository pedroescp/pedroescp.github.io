using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Text;
using uNotes.Api.Configuration;
using uNotes.Infra.CrossCutting.Constantes;
using uNotes.Infra.CrossCutting.IoC;
using uNotes.Infra.Data.Contexto;
using WebSocketManager;

namespace uNotes.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.RegisterServices(Configuration.GetConnectionString("DefaultConnection"));
            services.AddControllers();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "uNotes.Api.Security.Bearer",
                    ValidAudience = "uNotes.Api.Security.Bearer",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(ConstantesSistema.Seguranca.SymmetricSecurityKey))
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        return Task.CompletedTask;
                    }
                };
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api - uNotes", Version = "v1" });
            });

            services.AddCors();
            services.AddSwaggerConfig();
            services.AddWebSocketManager();
        }

        public void Configure(IApplicationBuilder app, ConfiguracoesSeed configSeed, IWebHostEnvironment env)
        {
            try
            {
                configSeed.SeedData().Wait();
            }
            catch (Exception)
            {

                throw;
            }

            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api - uNotes v1");
                });
            }
            app.UseCors(x => x
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyOrigin());

            var host = new WebHostBuilder()
                            .UseKestrel()
                            .UseContentRoot(Directory.GetCurrentDirectory())
                            .UseUrls("http://localhost:10010")
                            .UseIISIntegration()
                            .UseStartup<Startup>()
                            .Build();

            //app.UseDefaultFiles();

            //app.UseStaticFiles();

            //app.UseHttpsRedirection();


            //app.UseCors("AllowSpecificOrigin");

            //var websocketOptions = new WebSocketOptions
            //{
            //    KeepAliveInterval = TimeSpan.FromMinutes(1)
            //};

            //app.UseWebSockets(websocketOptions);

            app.UseRouting();

            app.UseMiddleware<WebSocketMiddleware>();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                app.UseWebSockets();
            });
        }
    }
}
