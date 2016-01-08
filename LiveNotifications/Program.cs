using System;
using Microsoft.AspNet.SignalR.Client;

namespace LiveNotifications
{
    public class Program
    {
        private static HubConnection con = null;
        private static IHubProxy installationHub = null;
        private static IHubProxy sensorHub = null;

        private const int JOIN_RETRIES = 3;

        private const string NOTIFICATIONS_URL = "http://dev.nassist-test.com";
        private const string INSTALLATIONS_CHANNEL_NAME = "signalinstallations-";
        private const string SENSORS_CHANNEL_NAME = "signalsensors-";
        private const string INSTALLATION_SECURITY_EVENT = "receiveNewInstallationSecurityStatus";
        private const string SENSOR_NEW_VALUE_EVENT = "receiveNewSensorData";

        private const string INSTALLATION_ID = "00000000-0000-0000-0000-b827eb9e544b";
        private const string SENSOR_ID = "2e74636a-3dad-44ad-82a8-c42a2a8eb925";

        public static void Main(string[] args)
        {

            Console.WriteLine("Press any key to start and a second time to exit the program");

            Console.ReadKey();

            con = new HubConnection(NOTIFICATIONS_URL);

            con.StateChanged += change =>
            {
                switch (change.NewState)
                {
                    case ConnectionState.Connected:
                        JoinGroup(installationHub, INSTALLATIONS_CHANNEL_NAME + INSTALLATION_ID, JOIN_RETRIES);
                        JoinGroup(sensorHub, SENSORS_CHANNEL_NAME + SENSOR_ID, JOIN_RETRIES);

                        break;

                    case ConnectionState.Disconnected:
                        break;
                }
            };

            installationHub = con.CreateHubProxy("installationHub");
            sensorHub = con.CreateHubProxy("sensorHub");
            installationHub.On<string, string, string, string>(INSTALLATION_SECURITY_EVENT, (installationId, date, status, trigger) =>
            {
                Console.WriteLine("Received Security Status change notification");
                Console.WriteLine("Installation Id: " + installationId);
                Console.WriteLine("Date: " + date);
                Console.WriteLine("Status: " + status);
                Console.WriteLine("Trigger: " + trigger);
            });

            sensorHub.On<string, string, string>(SENSOR_NEW_VALUE_EVENT, (sensorId, date, value) =>
            {
                Console.WriteLine("Received New Sensor value notification");
                Console.WriteLine("Sensor Id: " + sensorId);
                Console.WriteLine("Date: " + date);
                Console.WriteLine("Value: " + value);
            });

            con.Start();

            Console.ReadKey();

            con.Stop();
        }

        public static async void JoinGroup(IHubProxy hub, string groupName, int retries)
        {
            Console.WriteLine("JoinGroupInstallation: " + groupName + ". Retries: " + retries);

            bool error = true;
            while (retries > 0 && error)
            {
                try
                {
                    await hub.Invoke("joinGroup", groupName);
                    error = false;
                }
                catch (Exception)
                {
                    error = true;
                }

                retries--;
            }
        }
    }

}