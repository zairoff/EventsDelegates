using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification
{
    public class SmsService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine(message);
        }
    }
}
