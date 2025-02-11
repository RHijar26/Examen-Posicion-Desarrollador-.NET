using MediatR;

namespace ExamenDesarrollador.Bussiness.Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}