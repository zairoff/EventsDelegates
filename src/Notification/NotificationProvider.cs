using System.Linq;
using System.Collections.Generic;

namespace Notification
{
    public class NotificationProvider : INotificationProvider
    {
        private readonly HashSet<INotificationService> _services;

        public NotificationProvider()
        {
            _services = new HashSet<INotificationService>();
        }

        public void Add(INotificationService service)
        {
            _services.Add(service);
        }

        public void Remove(INotificationService service)
        {
            _services.Remove(service);
        }

        public void Notify(string message)
        {
            _services.ToList().ForEach(service => service.Send(message));
        }

        public int Count()
        {
            return _services.Count;
        }
    }
}
