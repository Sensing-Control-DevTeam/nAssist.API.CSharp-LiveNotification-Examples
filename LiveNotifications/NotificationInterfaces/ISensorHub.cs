using nassist.ServiceImplementation.SignalR.Hubs;

namespace LiveNotifications.NotificationInterfaces
{
    public interface ISensorHubClient : IBaseHubClient
    {
        void receiveNewSensorData(string sensorId, string date, double? value);
        void receiveNewSensorStatus(string sensorId, string sensorName, string date, string status);
        void receiveCopyStartedOperation(string SourceSensorId, string TargetSensorId, string from, string to, string operationKey);
        void receiveCopyCompletedOperation(string operationKey);
        void receiveNewSensorLockStatus(string Id, bool IsLocked);
    }

    public interface ISensorHubServer : IBaseHubServer
    { }
}
