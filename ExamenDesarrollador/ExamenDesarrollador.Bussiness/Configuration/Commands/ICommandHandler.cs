//using DuvezApi.Dominio.SeedWork;
using ExamenDesarrollador.Entitys.SeedWork;
using MediatR;

namespace ExamenDesarrollador.Bussiness.Configuration.Commands
{

    public interface ICommandHandler<in TCommand> :
        IRequestHandler<TCommand> where TCommand : ICommand
    {
        IUnitOfWork UnitOfWork { get; set; }        
    }

    public interface ICommandHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {
        IUnitOfWork UnitOfWork { get; set; }        
    }
}
