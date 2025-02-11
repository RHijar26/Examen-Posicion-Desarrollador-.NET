using MediatR;

namespace ExamenDesarrollador.Entitys.SeedWork
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}
