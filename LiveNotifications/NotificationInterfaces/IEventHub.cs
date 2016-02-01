using nassist.ServiceImplementation.SignalR.Hubs;

namespace LiveNotifications.NotificationInterfaces
{
    public interface IEventHubClient : IBaseHubClient
    {
        void receiveNewEvent(string rowKey, string type, string subtype, string installation, string InstallationId, string translatedDescription, bool pending, string date, string cameraTrigger);
        void receivePendingCountUpdate(int count);

        void receiveNewSecurityEvent(string eventId, string eventDescription, string date);

        void receiveNewEnergyEvent(string eventId, string eventDescription, string date);
    }

    public interface IEventHubServer : IBaseHubServer
    { }
}
