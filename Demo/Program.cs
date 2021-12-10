using Encoder;
using Notification;
using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var videoEncoder = new VideoEncoder();
            var audioEncoder = new AudioEncoder();

            var emailService = new EmailService();
            var smsService = new SmsService();

            var notificationProvider = new NotificationProvider();
            notificationProvider.Add(emailService);
            notificationProvider.Add(smsService);

            videoEncoder.Preparing += (sender, args) => Console.WriteLine("Preparing to encode");
            videoEncoder.Starting += (sender, args) => Console.WriteLine("Starting to encode");
            audioEncoder.Finishing += (sender, args) => Console.WriteLine("Finishing to encode");

            audioEncoder.Encoded += (sender, args) => notificationProvider.Notify();

            videoEncoder.Encode(null);
            audioEncoder.Encode(null);
        }
    }
}
