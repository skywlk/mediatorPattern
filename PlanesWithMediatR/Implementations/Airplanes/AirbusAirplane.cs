using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlanesWithMediatR
{
    public class AirbusAirplane : AirplaneBase, INotificationHandler<BoingNotificationMessage>
    {
        public AirbusAirplane(IMediator mediator) : base(mediator)
        {
        }

        public override void Send(string notification)
        {
            Console.WriteLine("Airbus airplane sends message: " + notification);
            _mediator.Publish(new AirbusNotificationMessage(notification));
        }

        public override void Notify(NotificationMessage notification)
        {
            Console.WriteLine("Airbus airplane gets message: " + notification.NotifyText);
        }

        public Task Handle(BoingNotificationMessage notification, CancellationToken cancellationToken)
        {
            Notify(notification);
            return Task.CompletedTask;
        }
    }
}