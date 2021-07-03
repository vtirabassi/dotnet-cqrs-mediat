using System.Threading;
using System.Threading.Tasks;
using MediatorCQRS.Domain.Command;
using MediatorCQRS.Domain.Entity;
using MediatorCQRS.Domain.Notifications;
using MediatorCQRS.Repository;
using MediatR;

namespace MediatorCQRS.Domain.Handler
{
    public class ProdutoCreateHandler : IRequestHandler<ProdutoCreateCommand, string>
    {

        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _repository;

        public ProdutoCreateHandler(IMediator mediator, IRepository<Produto> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(ProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto()
            {
                Nome = request.Nome,
                Preco = request.Preco
            };

            try
            {
                await _repository.Add(produto);
                await _mediator.Publish(new ProdutoCreateNotification(){Id = produto.Id, Nome = produto.Nome, Preco = produto.Preco});

                return await Task.FromResult("Produto criado com sucesso.");
            }
            catch (System.Exception ex)
            {
                await _mediator.Publish(new ProdutoCreateNotification(){Id = produto.Id, Nome = produto.Nome, Preco = produto.Preco});
                await _mediator.Publish(new ErrorNotification(){Erro = ex.Message, PilhaErro = ex.StackTrace});
                
                return await Task.FromResult("Erro ao criar produto.");
            }
        }
    }
}