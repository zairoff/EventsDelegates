namespace Notification
{
    public interface INotificationProvider
    {
        void Add(INotificationService service);
        void Remove(INotificationService service);
        void Notify(string message);
        int Count();
    }
}
