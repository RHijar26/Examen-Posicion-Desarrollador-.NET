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
using System.Timers;

namespace ExamenDesarrollador.Bussiness.Clients.InsertClient
{
    public class InsertClientCommand : CommandBase<Client>
    {
        public Client Client { get; set; }

        public InsertClientCommand(Client client)
        {
            Client = client;
        }
    }

    public class InsertClientCommandHandler : ICommandHandler<InsertClientCommand, Client>
    {
        private readonly IRepositoryClient repositoryClient;
        public IUnitOfWork UnitOfWork { get; set; }

        public InsertClientCommandHandler(IRepositoryClient repositoryClient, IUnitOfWork unitOfWork)
        {
            this.repositoryClient = repositoryClient;
            UnitOfWork = unitOfWork;
        }

        public async Task<Client> Handle(InsertClientCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Client.Name))
            {
                throw new Exception("El Nombre del cliente es Requerido");
            }

            if (string.IsNullOrEmpty(request.Client.Address))
            {
                throw new Exception("La Dirección del cliente es Requerida");
            }

            var existingUser = await repositoryClient.GetClientByUser(request.Client.User);

            if(existingUser != null)
            {
                throw new Exception("El nombre de Usuario ya está Registrado");
            }

            await repositoryClient.Insert(request.Client);

            await UnitOfWork.CommitAsync();

            return request.Client;            
        }
    }
}
