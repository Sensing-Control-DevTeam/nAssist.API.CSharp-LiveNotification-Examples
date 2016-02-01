using nassist.ServiceImplementation.SignalR.Hubs;

namespace LiveNotifications.NotificationInterfaces
{
    public interface ICameraHubClient : IBaseHubClient
    {
        void receiveNewCameraPhoto(string cameraId, string cameraName, string date);
    }

    public interface ICameraHubServer : IBaseHubServer
    { }
}
