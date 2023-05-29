namespace uNotes.Application.Responses.Usuario
{
    public class LoginObterResponse
    {
        public string Token { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public Guid? CargoId { get; set; }
    }
}
