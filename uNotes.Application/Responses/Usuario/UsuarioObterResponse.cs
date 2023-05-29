namespace uNotes.Application.Responses.Usuario
{
    public class UsuarioObterResponse
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Guid? Avatar { get; set; }
        public Guid CargoId { get; set; }
    }
}
