using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification
{
    public class NotificationProvider
    {
        private readonly List<INotificationService> _services;

        public NotificationProvider()
        {
            _services = new List<INotificationService>();
        }

        public void Add(INotificationService service)
        {
            _services.Add(service);
        }

        public void Notify()
        {
            _services.ForEach(service => service.Send("Encoding is ready"));
        }
    }
}
