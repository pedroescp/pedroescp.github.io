namespace uNotes.Domain.Entidades
{
    public class TokenUsuario
    {
        public string Token { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataExpiracao { get; set; }
    }
}
