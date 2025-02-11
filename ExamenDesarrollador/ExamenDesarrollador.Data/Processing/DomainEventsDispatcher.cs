using ExamenDesarrollador.Bussiness.Configuration.DomainEvents;
using ExamenDesarrollador.Data.Context;
using ExamenDesarrollador.Entitys.SeedWork;
using MediatR;

namespace ExamenDesarrollador.Data.Processing
{
    public class DomainEventsDispatcher : IDomainEventsDispatcher
    {
        private readonly IMediator _mediator;
        //private readonly ILifetimeScope _scope;
        private readonly ContextDBO _context;

        public DomainEventsDispatcher(IMediator mediator, ContextDBO context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task DispatchEventsAsync()
        {
            var domainEntities = this._context.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            var domainEventNotifications = new List<IDomainEventNotification<IDomainEvent>>();
            foreach (var domainEvent in domainEvents)
            {
                Type domainEvenNotificationType = typeof(IDomainEventNotification<>);
                var domainNotificationWithGenericType = domainEvenNotificationType.MakeGenericType(domainEvent.GetType());
                //var domainNotification = _scope.ResolveOptional(domainNotificationWithGenericType, new List<Parameter>
                //{
                //    new NamedParameter("domainEvent", domainEvent)
                //});

                //if (domainNotification != null)
                //{
                //    domainEventNotifications.Add(domainNotification as IDomainEventNotification<IDomainEvent>);
                //}
            }

            domainEntities
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await _mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);

            //foreach (var domainEventNotification in domainEventNotifications)
            //{
            //    string type = domainEventNotification.GetType().FullName;
            //    var data = JsonConvert.SerializeObject(domainEventNotification);
            //    OutboxMessage outboxMessage = new OutboxMessage(
            //        domainEventNotification.DomainEvent.OccurredOn,
            //        type,
            //        data);
            //    this._context.OutboxMessages.Add(outboxMessage);
            //}
        }

    }
}
