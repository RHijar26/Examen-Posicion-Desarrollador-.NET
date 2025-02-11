using ExamenDesarrollador.Data.Context;
using ExamenDesarrollador.Data.Processing;
using ExamenDesarrollador.Entitys.SeedWork;

namespace ExamenDesarrollador.Data.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ContextDBO _context;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;

        public UnitOfWork(
            ContextDBO ordersContext,
            IDomainEventsDispatcher domainEventsDispatcher)
        {
            this._context = ordersContext;
            this._domainEventsDispatcher = domainEventsDispatcher;
        }

        public async Task<int> CommitAsync(int IdUsuario, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this._domainEventsDispatcher.DispatchEventsAsync();

            //return await this._context.SaveChangesAsync(cancellationToken);
            return await this._context.SaveChangesAsync();
        }

        public async Task<int> CommitAsync()
        {
            await this._domainEventsDispatcher.DispatchEventsAsync();
            return await this._context.SaveChangesAsync();

        }

    }
}
