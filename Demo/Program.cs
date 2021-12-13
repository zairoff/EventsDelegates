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
            EncoderFactory encoderFactory = null;

            Console.WriteLine("Choose encoder type: a) Audio Encoder/n b) Video Encoder/n Default encoder is AudioEncoder");

            var encoderType = Console.ReadLine();

            encoderFactory = encoderType.ToLower() switch
            {
                "a" => new AudioFactory(),
                "b" => new VideoFactory(),
                _ => new AudioFactory(),
            };
            var encoder = encoderFactory.GetEncoder();

            var emailService = new EmailService();
            var smsService = new SmsService();

            var notificationProvider = new NotificationProvider();
            notificationProvider.Add(emailService);
            notificationProvider.Add(smsService);

            encoder.Preparing += (sender, args) => Console.WriteLine(args.Message);
            encoder.Starting += (sender, args) => Console.WriteLine(args.Message);
            encoder.Finishing += (sender, args) => Console.WriteLine(args.Message);

            encoder.Encoded += (sender, args) => notificationProvider.Notify();

            encoder.Encode(null);
        }
    }
}
