using ExamenDesarrollador.Data.Context;
using ExamenDesarrollador.Entitys.Clients;
using ExamenDesarrollador.Entitys.Clients.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Client> GetClientByUser(string user)
        {
            var client = await _context.Client.FirstOrDefaultAsync(c => c.User == user);


            return client;
        }

        public async Task<List<Client>> GetClients()
        {
            var clients = await _context.Client.ToListAsync();
            
            return clients;
        }

        public async Task<Client> GetUser(string user, string passWord)
        {
            var userDB = await _context.Client.FirstOrDefaultAsync(c => c.User == user);

            if (userDB == null)
            {
                throw new Exception("No se ha Encontrado el Usuario");
            }

            PasswordHasher<Client> passwordHasher = new PasswordHasher<Client>();

            PasswordVerificationResult resultVerification = passwordHasher.VerifyHashedPassword(
                userDB,
                userDB.PassWord,
                passWord
            );

            
            if (resultVerification == PasswordVerificationResult.SuccessRehashNeeded || userDB.PassWord == passWord)
            {
                PasswordHasher<Client> hasher = new PasswordHasher<Client>();
                string newPassWord = hasher.HashPassword(userDB, userDB.PassWord);

                userDB.PassWord = newPassWord;
                await _context.SaveChangesAsync();
            }else if (resultVerification == PasswordVerificationResult.Failed)
            {
                throw new Exception("Contraseña Incorrecta");
            }

            return userDB;

        }
    }
}
