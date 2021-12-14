using Encoder;
using Notification;
using System;
using System.Text;

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

            var welcomeMessage = GetWelcomeMessage();

            Console.WriteLine(welcomeMessage);

            var encoderType = Console.ReadKey();

            var encoderFactory = encoderType.KeyChar.GetEncoderFactory();

            var encoder = encoderFactory.GetEncoder();

            SubscribeToEvents(encoder, notificationProvider);

            encoder.Encode(null);
        }

        private static void SubscribeToEvents(BaseEncoder encoder, NotificationProvider notificationProvider)
        {
            encoder.Preparing += (sender, args) => Console.WriteLine(args.Message);
            encoder.Starting += (sender, args) => Console.WriteLine(args.Message);
            encoder.Finishing += (sender, args) => Console.WriteLine(args.Message);

            encoder.Encoded += (sender, args) => notificationProvider.Notify();
        }

        private static StringBuilder GetWelcomeMessage()
        {
            var welcomeMessage = new StringBuilder();
            welcomeMessage.Append("Welcome! Please, choose the encoder type:");
            welcomeMessage.Append(Environment.NewLine);
            welcomeMessage.Append("a) Audio Encoder");
            welcomeMessage.Append(Environment.NewLine);
            welcomeMessage.Append("v) Video Encoder");
            welcomeMessage.Append(Environment.NewLine);
            welcomeMessage.Append("i) Integer Encoder");
            welcomeMessage.Append(Environment.NewLine);
            welcomeMessage.Append("default encoder is AudioEncoder");
            welcomeMessage.Append(Environment.NewLine);

            return welcomeMessage;
        }
    }
}
