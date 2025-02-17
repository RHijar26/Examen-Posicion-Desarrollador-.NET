using ExamenDesarrollador.Data.Context;
using ExamenDesarrollador.Entitys.Clients;
using ExamenDesarrollador.Entitys.Clients.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Data.Repositorys.Clients
{
    public class RepositoryClient : RepositoryGeneric<Client>, IRepositoryClient
    {
        public RepositoryClient(ContextDBO context) : base(context)
        {
        }
    }
}
