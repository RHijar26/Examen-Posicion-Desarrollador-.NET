using ExamenDesarrollador.Bussiness.Configuration.Commands;
using ExamenDesarrollador.Entitys.Clients.Interfaces;
using ExamenDesarrollador.Entitys.Products.Interfaces;
using ExamenDesarrollador.Entitys.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Bussiness.Clients.RemoveClient
{
    public class RemoveClientCommand  : CommandBase<bool>
    {
        public int ClientId { get; set; }

        public RemoveClientCommand(int clientId)
        {
            ClientId = clientId;
        }
    }
    public class RemoveClientCommandHandler : ICommandHandler<RemoveClientCommand, bool>
    {
        private readonly IRepositoryClient repositoryClient;
        public IUnitOfWork UnitOfWork {  get; set; }



        public async Task<bool> Handle(RemoveClientCommand request, CancellationToken cancellationToken)
        {
            if (request.ClientId == 0)
            {
                throw new Exception("El ID del Cliente no Puede ser 0");
            }

            var clientBD = await repositoryClient.GetById(request.ClientId);
            if (clientBD == null)
            {
                throw new Exception("No se ha Encontrado el Cliente");
            }

            await repositoryClient.Delete(clientBD);

            await UnitOfWork.CommitAsync();

            return true;
        }
    }
}
