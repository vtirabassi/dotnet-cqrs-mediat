using MediatR;

namespace MediatorCQRS.Domain.Command
{
    public class ProdutoCreateCommand : IRequest<string>
    {
        public string Nome { get; set; }

        public decimal Preco { get; set; }
    }
}