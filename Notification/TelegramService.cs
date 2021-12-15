using System;

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
