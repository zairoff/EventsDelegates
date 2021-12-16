using Encoder;
using Encoder.Factory;
using Encoder.Source;
using Notification;
using System;
using System.Text;

namespace Demo
{
    class Program
    {
        private static INotificationProvider _notificationProvider;
        static void Main(string[] args)
        {
            var smsService = new SmsService();
            var emailService = new EmailService();
            var telegramService = new TelegramService();
            _notificationProvider = new NotificationProvider();

            _notificationProvider.Add(telegramService);
            _notificationProvider.Add(emailService);
            _notificationProvider.Add(smsService);

            Console.WriteLine(ShowEncoders());

            var encoderType = Console.ReadKey();
            Console.Write(Environment.NewLine);

            try
            {
                var encoder = GetEncoder(encoderType.KeyChar);
                SubscribeToEvents(encoder);
                encoder.Encode();
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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

        private static string ShowEncoders()
        {
            var encoders = new StringBuilder();
            encoders.Append("Welcome! Please, choose the encoder type:");
            encoders.Append(Environment.NewLine);
            encoders.Append("a) Audio Encoder");
            encoders.Append(Environment.NewLine);
            encoders.Append("v) Video Encoder");
            encoders.Append(Environment.NewLine);
            encoders.Append("i) Integer Encoder");
            encoders.Append(Environment.NewLine);
            encoders.Append("default encoder is AudioEncoder");
            encoders.Append(Environment.NewLine);

            return encoders.ToString();
        }

        private static BaseEncoder GetEncoder(char encoderType)
        {
            return encoderType switch
            {
                'a' => new AudioFactory().GetEncoder(new Audio()),
                'v' => new VideoFactory().GetEncoder(new Video()),
                'i' => new IntegerFactory().GetEncoder(new Random().Next(1, 100)),
                _ => new AudioFactory().GetEncoder(new Audio())
            };
        }
    }
}
