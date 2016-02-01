using nassist.ServiceImplementation.SignalR.Hubs;

namespace LiveNotifications.NotificationInterfaces
{
    public interface IWarningHubClient : IBaseHubClient
    {
        void receiveImmediateWarning(int id, string message, string type, bool isPersistent);
    }

    public interface IWarningHubServer : IBaseHubServer
    { }
}
