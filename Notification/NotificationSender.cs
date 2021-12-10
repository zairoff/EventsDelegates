using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification
{
    public class NotificationSender
    {
        private readonly List<INotificationService> _services;

        public NotificationSender()
        {
            _services = new List<INotificationService>();
        }

        public void Subscribe(INotificationService service)
        {
            _services.Add(service);
        }

        public void Notify()
        {
            _services.ForEach(service => service.Send("Encoding is ready"));
        }
    }
}
