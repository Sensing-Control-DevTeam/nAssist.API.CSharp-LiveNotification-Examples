using nassist.ServiceImplementation.SignalR.Hubs;

namespace LiveNotifications.NotificationInterfaces
{
    public interface IRuleHubClient : IBaseHubClient
    {
        void receiveRuleDeleted(long Id);
        void receiveRuleIsEnabledStatus(long Id, bool IsEnabled);
    }

    public interface IRuleHubServer : IBaseHubServer
    { }
}
