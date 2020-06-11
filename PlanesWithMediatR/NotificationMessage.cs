using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanesWithMediatR
{

    public class NotificationMessage : INotification
    {
        public NotificationMessage(string text)
        {
            NotifyText = text;
        }
        public string NotifyText { get; set; }
    }

    public class AirbusNotificationMessage : NotificationMessage
    {
        public AirbusNotificationMessage(string text) : base(text)
        {
        }
    }

    public class BoingNotificationMessage : NotificationMessage
    {
        public BoingNotificationMessage(string text) : base(text)
        {
        }
    }
}
