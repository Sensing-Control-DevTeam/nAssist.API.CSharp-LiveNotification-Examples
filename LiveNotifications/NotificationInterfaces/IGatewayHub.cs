using nassist.ServiceImplementation.SignalR.Hubs;

namespace LiveNotifications.NotificationInterfaces
{
    public interface IGatewayHubClient : IBaseHubClient
    {
        void receiveLogsUpdate(string DriverID, string Link);
        void receiveUpdateStatus(string GatewayId, string UpdateStatus);
        void receiveNetworkStatus(string GatewayId, string NetworkStatus);
        void receiveAddOrRemoveSensor(string GatewayId, bool IsAdded);
        void receiveGWVersion(string Id, string GWVersion);
        void receiveSensorConfigured(string Id, string SensorId);
        void receiveMainThermostatChanged(string Id, string Name);
        void receiveBackupCreated(string Id, bool IsCreated);
        void receiveSystemBackupCreated(string Id, bool IsCreated);
    }

    public interface IGatewayHubServer : IBaseHubServer
    { }
}
