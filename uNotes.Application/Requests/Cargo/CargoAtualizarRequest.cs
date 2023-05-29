namespace uNotes.Application.Requests.Cargo
{
    public class CargoAtualizarRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
