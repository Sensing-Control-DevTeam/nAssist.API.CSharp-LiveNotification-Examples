using nassist.ServiceImplementation.SignalR.Hubs;

namespace LiveNotifications.NotificationInterfaces
{
    public interface IMonitorHubClient : IBaseHubClient
    {
        void receiveMessage(string message);
        void receiveTestMessage(string message);
        void receiveSchedulerMessage(string message, int count);
    }

    public interface IMonitorHubServer : IBaseHubServer
    {
        void sendTestMessage(string message);
    }
}
