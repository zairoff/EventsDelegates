using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification
{
    public class TelegramService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending telegram message: {message}");
        }
    }
}
