using Microsoft.Extensions.Configuration;

namespace uNotes.Infra.CrossCutting.Configuracoes
{
    public static partial class Configuracoes
    {
        private const string TEMPO_SESSAO = "TempoDaSessao";
        private const string EMAIL = "EMAIL";
        public const string Usuario = "Usuario";
        public const string Senha = "Senha";
        private const string CONFIG_FILE_NAME = "appsettings.json";

        private static IConfiguration _configuration;

        public static IConfiguration Conf
        {
            get
            {
                if (_configuration == null)
                    _configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile(CONFIG_FILE_NAME)
                        .Build();

                return _configuration;
            }
        }

        public static string GetValueString(string value)
        {
            return Conf.GetValue<string>(value);
        }

        public static IConfigurationSection GetSection(string section)
        {
            return Conf.GetSection(section);
        }

        public static string GetSectionValue(string section, string value)
        {
            return Conf.GetSection(section).GetValue<string>(value);
        }

        public static int GetSectionValueInt(string section, string value)
        {
            return Conf.GetSection(section).GetValue<int>(value);
        }

        public static int ObterTempoSessao()
        {
            return Conf.GetValue<int>(TEMPO_SESSAO);
        }

        public static string ObterSenhaEmail()
        {
            return Conf.GetSection(EMAIL).GetValue<string>(Senha);
        }
    }
}