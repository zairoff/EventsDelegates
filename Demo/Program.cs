using Encoder;
using Encoder.Source;
using Notification;
using System;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Demo
{
    class Program
    {
        private static INotificationProvider _notificationProvider;
        static void Main(string[] args)
        {
            var emailService = new EmailService();
            var smsService = new SmsService();
            var telegramService = new TelegramService();
            _notificationProvider = new NotificationProvider();
            _notificationProvider.Add(emailService);
            _notificationProvider.Add(smsService);
            _notificationProvider.Add(telegramService);

            Console.WriteLine(SourceUploadMessage());

            var sourceType = Console.ReadKey();
            Console.WriteLine(Environment.NewLine);

            var source = sourceType.KeyChar.GetSource();

            Console.WriteLine(EncoderChooseMessage());

            var encoderType = Console.ReadKey();
            Console.WriteLine(Environment.NewLine);

            var encoder = encoderType.KeyChar.GetEncoder(source);

            SubscribeToEvents(encoder);

            encoder.Encode();
        }

        private static void SubscribeToEvents(BaseEncoder encoder)
        {
            encoder.Preparing += EncoderOnPreparing;
            encoder.Starting += EncoderOnStarting;
            encoder.Finishing += EncoderOnFinishing;
            encoder.Encoded += EncoderOnEncoded;
        }
        private static void EncoderOnPreparing(object sender, EncoderEventArgs args)
        {
            // TODO: need to find another way
            if(sender is int)
            {
                var encoder = (IntegerEncoder)sender;
                if (encoder.Source % 2 != 0)
                    args.Stop = true;
            }

            Console.WriteLine(args.Message);
        }

        private static void EncoderOnStarting(object sender, EncoderEventArgs args)
        {
            Console.WriteLine(args.Message);
        }

        private static void EncoderOnFinishing(object sender, EncoderEventArgs args)
        {
            Console.WriteLine(args.Message);
        }

        private static void EncoderOnEncoded(object sender, EncoderEventArgs args)
        {
            _notificationProvider.Notify(args.Message);
        }

        private static StringBuilder EncoderChooseMessage()
        {
            var message = new StringBuilder();
            message.Append("Welcome! Please, choose the encoder type:");
            message.Append(Environment.NewLine);
            message.Append("a) Audio Encoder");
            message.Append(Environment.NewLine);
            message.Append("v) Video Encoder");
            message.Append(Environment.NewLine);
            message.Append("i) Integer Encoder");
            message.Append(Environment.NewLine);
            message.Append("default encoder is AudioEncoder");
            message.Append(Environment.NewLine);

            return message;
        }

        private static StringBuilder SourceUploadMessage()
        {
            var message = new StringBuilder();
            message.Append("Welcome! Please, load source to encode:");
            message.Append(Environment.NewLine);
            message.Append("a) Audio");
            message.Append(Environment.NewLine);
            message.Append("v) Video");
            message.Append(Environment.NewLine);
            message.Append("i) Integer");
            message.Append(Environment.NewLine);

            return message;
        }
    }
}
