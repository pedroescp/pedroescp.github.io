namespace uNotes.Infra.CrossCutting.Configuracoes
{
    public static class JwtConfig
    {
        private const string SECTION = "JWT";
        private const string SECRET = "ChaveSecreta";
        private const string EXPIRACAOHORAS = "ExpiracaoHoras";

        public static string ObterChaveSecreta = Configuracoes.GetSectionValue(SECTION, SECRET);
        public static int TempoExpiracao = Configuracoes.GetSectionValueInt(SECTION, EXPIRACAOHORAS);
    }
}
