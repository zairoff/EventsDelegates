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

            Console.WriteLine("Choose encoder type:" + Environment.NewLine +
                                "a) Audio Encoder " + Environment.NewLine +
                                "b) Video Encoder" + Environment.NewLine +
                                "c) Integer Encoder" + Environment.NewLine +
                                "Default encoder is AudioEncoder");

            var encoderType = Console.ReadLine();

            var encoderFactory = EncoderFactoryExtension.GetEncoderFactory(encoderType);

            var encoder = encoderFactory.GetEncoder();

            encoder.Preparing += (sender, args) => Console.WriteLine(args.Message);
            encoder.Starting += (sender, args) => Console.WriteLine(args.Message);
            encoder.Finishing += (sender, args) => Console.WriteLine(args.Message);

            encoder.Encoded += (sender, args) => notificationProvider.Notify();

            encoder.Encode(null);
        }
    }
}
