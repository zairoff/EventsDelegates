using Notification;
using System;
using Xunit;

namespace NotificationTest
{
    public class NotificationProviderTests
    {
        [Fact]
        public void Add_Should_Add_Services_To_Provider()
        {
            var notificationProvider = new NotificationProvider();

            notificationProvider.Add(new TelegramService());
            notificationProvider.Add(new EmailService());

            var result = notificationProvider.Count();

            Assert.Equal(2, result);
        }

        [Fact]
        public void Add_ShouldNot_Add_DuplicateServices_To_Provider()
        {
            var notificationProvider = new NotificationProvider();
            var telegramService = new TelegramService();

            notificationProvider.Add(telegramService);
            notificationProvider.Add(telegramService);

            var result = notificationProvider.Count();

            Assert.Equal(1, result);
        }

        [Fact]
        public void Remove_Should_Remove_Service_From_Provider()
        {
            var notificationProvider = new NotificationProvider();
            var telegramService = new TelegramService();
            var emailService = new EmailService();

            notificationProvider.Add(telegramService);
            notificationProvider.Add(emailService);

            notificationProvider.Remove(telegramService);

            var result = notificationProvider.Count();

            Assert.Equal(1, result);
        }

        [Fact]
        public void Remove_ShouldNot_RemoveUnregisteredService_From_Provider()
        {
            var notificationProvider = new NotificationProvider();
            var telegramService = new TelegramService();

            notificationProvider.Remove(telegramService);

            var result = notificationProvider.Count();

            Assert.Equal(0, result);
        }
    }
}
