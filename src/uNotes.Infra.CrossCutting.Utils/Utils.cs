using System.Text;

namespace uNotes.Infra.CrossCutting.Utils
{
    public class Utils
    {
        public static string? RemoverAcentos(string? palavra)
        {
            if (palavra == null)
                return null;
            var sb = new StringBuilder(palavra);

            sb.Replace("á", "a")
              .Replace("à", "a")
              .Replace("â", "a")
              .Replace("ã", "a")
              .Replace("é", "e")
              .Replace("è", "e")
              .Replace("ê", "e")
              .Replace("í", "i")
              .Replace("ì", "i")
              .Replace("î", "i")
              .Replace("ó", "o")
              .Replace("ò", "o")
              .Replace("ô", "o")
              .Replace("õ", "o")
              .Replace("ú", "u")
              .Replace("ù", "u")
              .Replace("û", "u")
              .Replace("ç", "c");

            return sb.ToString().ToLower();
        }
    }
}