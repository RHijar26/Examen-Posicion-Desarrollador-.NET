namespace ExamenDesarrollador.Entitys.SeedWork
{

    public interface IUnitOfWork
    {
        Task<int> CommitAsync(int IdUsuario, CancellationToken cancellationToken = default(CancellationToken));

        Task<int> CommitAsync();

    }
}
