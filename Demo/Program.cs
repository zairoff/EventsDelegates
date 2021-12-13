using Encoder;
using Encoder.Factory;
using Notification;
using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailService = new EmailService();
            var smsService = new SmsService();

            var notificationProvider = new NotificationProvider();
            notificationProvider.Add(emailService);
            notificationProvider.Add(smsService);

            Console.WriteLine("Choose encoder type:\n a) Audio Encoder\n b) Video Encoder\n Default encoder is AudioEncoder");

            EncoderFactory encoderFactory = null;
            var encoderType = Console.ReadLine();

            encoderFactory = encoderType.ToLower() switch
            {
                "a" => new AudioFactory(),
                "b" => new VideoFactory(),
                _ => new AudioFactory(),
            };

            var encoder = encoderFactory.GetEncoder();

            encoder.Preparing += (sender, args) => Console.WriteLine(args.Message);
            encoder.Starting += (sender, args) => Console.WriteLine(args.Message);
            encoder.Finishing += (sender, args) => Console.WriteLine(args.Message);

            encoder.Encoded += (sender, args) => notificationProvider.Notify();

            encoder.Encode(null);
        }
    }
}
