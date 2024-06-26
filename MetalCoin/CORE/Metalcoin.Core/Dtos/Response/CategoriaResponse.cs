namespace Metalcoin.Core.Dtos.Response
{
    public class CategoriaResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
        public string FotoCapa { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
