using ExamenDesarrollador.Bussiness.Configuration.Queries;
using ExamenDesarrollador.Entitys.Clients;
using ExamenDesarrollador.Entitys.Clients.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Bussiness.Clients.GetClients
{
    public class GetClientsQuery : IQuery<List<Client>>
    {

    }
    public class GetClientsQueryHandler : IQueryHandler<GetClientsQuery, List<Client>>
    {
        private readonly IRepositoryClient repositoryClient;

        public GetClientsQueryHandler(IRepositoryClient repositoryClient)
        {
            this.repositoryClient = repositoryClient;
        }

        public async Task<List<Client>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            var result = await repositoryClient.GetClients();

            return result;
        }
    }
}
