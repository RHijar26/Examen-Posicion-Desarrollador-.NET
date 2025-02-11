using MediatR;

namespace ExamenDesarrollador.Bussiness.Configuration.Commands
{
    public class CommandBase : ICommand
    {
    }

    public abstract class CommandBase<TResult> : ICommand<TResult>
    {
        private readonly IMediator _mediator;

    }
}
