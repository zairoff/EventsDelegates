using System;

namespace Notification
{
    public class SmsService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending sms message: {message}");
        }
    }
}
