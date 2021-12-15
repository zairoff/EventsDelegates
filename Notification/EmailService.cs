using System;

namespace Notification
{
    public class EmailService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending email message: {message}");
        }
    }
}
