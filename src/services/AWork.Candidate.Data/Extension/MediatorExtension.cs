using System.Linq;
using System.Threading.Tasks;
using AWork.Candidatos.Data.Context;
using AWork.Core.Communication.Mediator;
using AWork.Core.DomainObjects;

namespace AWork.Candidatos.Data.Extension
{
    public static class MediatorExtension
    {
        public static async Task PublishEvents(this IMediatorHandler mediator, CandidateContext context)
        {
            var domainEntities = context.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notification != null && x.Entity.Notification.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notification)
                .ToList();

            var tasks = domainEvents
                .Select(async (domainEvents) =>
                {
                    await mediator.PublishEvent(domainEvents);
                });

            await Task.WhenAll(tasks);
        }
    }
}
