using MediatR;

namespace PlanesWithMediatR
{
    public abstract class AirplaneBase
    {
        protected readonly IMediator _mediator;

        public AirplaneBase(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public abstract void Send(string notification);

        public abstract void Notify(NotificationMessage notification);
    }
}