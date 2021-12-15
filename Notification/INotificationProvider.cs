using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification
{
    public interface INotificationProvider
    {
        void Add(INotificationService service);
        void Remove(INotificationService service);
        void Notify(string message);
    }
}
