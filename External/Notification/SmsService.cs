using External.Encoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace External.Notification
{
    public class SmsService : INotificationService
    {
        public void Send(object source, EncodedEventArgs args)
        {
            Console.WriteLine($"Sending sms... {args.Data}");
        }
    }
}
