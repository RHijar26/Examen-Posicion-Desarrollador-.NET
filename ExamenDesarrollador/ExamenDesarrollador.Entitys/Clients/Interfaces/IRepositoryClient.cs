﻿using ExamenDesarrollador.Entitys.Comuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Entitys.Clients.Interfaces
{
    public interface IRepositoryClient : IRepositoryGeneric<Client>
    {
        Task<List<Client>> GetClients();
        Task<Client> GetClientByUser(string user);
        Task<Client> GetUser(string user, string passWord);
        Task<string> GetHashedPassword(Client client);
    }
}
