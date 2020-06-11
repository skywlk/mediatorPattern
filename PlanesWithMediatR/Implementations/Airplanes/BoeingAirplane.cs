using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlanesWithMediatR
{
    public class BoeingAirplane : AirplaneBase, INotificationHandler<AirbusNotificationMessage>
    {
        public BoeingAirplane(IMediator mediator) : base(mediator)
        {
        }

        public override void Send(string notification)
        {
            Console.WriteLine("Boeing airplane sends message: " + notification);
            _mediator.Publish(new BoingNotificationMessage(notification));
        }

        public override void Notify(NotificationMessage notification)
        {
            Console.WriteLine("Boeing airplane gets message: " + notification.NotifyText);
        }

        public Task Handle(AirbusNotificationMessage notification, CancellationToken cancellationToken)
        {
            Notify(notification);
            return Task.CompletedTask;
        }
    }
}