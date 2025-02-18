using ExamenDesarrollador.Bussiness.Configuration.Commands;
using ExamenDesarrollador.Entitys.Clients;
using ExamenDesarrollador.Entitys.Clients.Interfaces;
using ExamenDesarrollador.Entitys.Products.Interfaces;
using ExamenDesarrollador.Entitys.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Bussiness.Clients.UpdateClient
{
    public class UpdateClientCommand : CommandBase<Client>
    {
        public Client Client { get; set; }

        public UpdateClientCommand(Client client)
        {
            Client = client;
        }
    }

    public class UpdateClientCommandHandler : ICommandHandler<UpdateClientCommand, Client>
    {
        private readonly IRepositoryClient repositoryClient;
        public IUnitOfWork UnitOfWork { get; set; }

        public UpdateClientCommandHandler(IRepositoryClient repositoryClient, IUnitOfWork unitOfWork)
        {
            this.repositoryClient = repositoryClient;
            UnitOfWork = unitOfWork;
        }

        public async Task<Client> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            if (request.Client.Id == 0)
            {
                throw new Exception("El ID del Cliente no Puede ser 0");
            }

            if (string.IsNullOrEmpty(request.Client.Name))
            {
                throw new Exception("El Nombre del cliente es Requerido");
            }

            if (string.IsNullOrEmpty(request.Client.Address))
            {
                throw new Exception("La Dirección del cliente es Requerida");
            }

            var clientBD = await repositoryClient.GetById(request.Client.Id);
            clientBD = request.Client;

            await repositoryClient.Update(clientBD, clientBD.Id);

            await UnitOfWork.CommitAsync();

            return clientBD;
        }
    }

}
