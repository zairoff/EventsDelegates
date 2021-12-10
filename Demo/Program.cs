using External.Encoder;
using External.Notification;
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

            videoEncoder.Encoded += emailService.Send;
            videoEncoder.Encoded += smsService.Send;
            audioEncoder.Encoded += emailService.Send;
            audioEncoder.Encoded += smsService.Send;

            videoEncoder.Encode(new byte[10]);         
            audioEncoder.Encode(null);
        }
    }
}
