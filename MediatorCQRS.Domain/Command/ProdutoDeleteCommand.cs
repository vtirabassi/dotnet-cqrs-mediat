using MediatR;

namespace MediatorCQRS.Domain.Command
{
    public class ProdutoDeleteCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}