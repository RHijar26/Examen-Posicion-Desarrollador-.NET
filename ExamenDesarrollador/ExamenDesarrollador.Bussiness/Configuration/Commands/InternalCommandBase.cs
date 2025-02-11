namespace ExamenDesarrollador.Bussiness.Configuration.Commands
{
    public abstract class InternalCommandBase : ICommand
    {        
    }

    public abstract class InternalCommandBase<TResult> : ICommand<TResult>
    {
     
    }
}
