using System;
using System.Threading;
using System.Threading.Tasks;
using MediatorCQRS.Domain.Notifications;
using MediatR;

namespace MediatorCQRS.Domain.Handler
{
    public class LogEnventHandler : INotificationHandler<ProdutoCreateNotification>,
    INotificationHandler<ProdutoUpdateNotification>,
    INotificationHandler<ProdutoDeleteNotification>,
    INotificationHandler<ErrorNotification>
    {
        public Task Handle(ProdutoCreateNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() => 
            {
                Console.WriteLine($"Produto criado: Id: '{notification.Id}' - Nome: '{notification.Nome}' - Preço: '{notification.Preco}'");
            });
        }

        public Task Handle(ProdutoUpdateNotification notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(ProdutoDeleteNotification notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}