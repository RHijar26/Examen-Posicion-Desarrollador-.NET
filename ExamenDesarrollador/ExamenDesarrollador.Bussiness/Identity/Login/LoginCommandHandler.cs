using ExamenDesarrollador.Bussiness.Configuration.Commands;
using ExamenDesarrollador.Entitys.Clients.Interfaces;
using ExamenDesarrollador.Entitys.SeedWork;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Bussiness.Identity.Login
{
    public class LoginCommand : CommandBase<string>
    {
        public string User { get ; set; }
        public string Password { get; set; }

        public LoginCommand(string user, string password)
        {
            User = user;
            Password = password;
        }
    }
    public class LoginCommandHandler : ICommandHandler<LoginCommand, string>
    {
        private readonly IConfiguration _config;
        private readonly IRepositoryClient repositoryClient;
        public IUnitOfWork UnitOfWork { get;set; }

        public LoginCommandHandler(IConfiguration config, IRepositoryClient repositoryClient, IUnitOfWork unitOfWork)
        {
            _config = config;
            this.repositoryClient = repositoryClient;
            UnitOfWork = unitOfWork;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await repositoryClient.GetUser(request.User,request.Password);

            return (GenerateJwtToken(result.User));
        }

        private string GenerateJwtToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[] { new Claim(ClaimTypes.Name, username) };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
