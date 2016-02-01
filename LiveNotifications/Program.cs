using System;
using Microsoft.AspNet.SignalR.Client;
using ServiceStack;

namespace LiveNotifications
{
    public class Program
    {
        private static HubConnection con;
        private static IHubProxy installationHub;
        private static IHubProxy sensorHub;
        
        private const string NOTIFICATIONS_URL = "http://dev.nassist-test.com";
        private const string INSTALLATION_SECURITY_EVENT = "receiveNewInstallationSecurityStatus";
        private const string SENSOR_NEW_VALUE_EVENT = "receiveNewSensorData";

        private const string INSTALLATION_ID = "00000000-0000-0000-0000-b827eb9e544b";
        private const string SENSOR_ID = "2e74636a-3dad-44ad-82a8-c42a2a8eb925";

        private const string UserName = "demo";
        private const string Password = "demo";

        private static readonly JsonServiceClient Client = new JsonServiceClient(NOTIFICATIONS_URL + "/api");

        public static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start and a second time to exit the program");

            Console.ReadKey();

            // Authenticate on the platform
            Client.Post(new Authenticate { UserName = UserName, Password = Password });

            // Create a connection against the nofications system and configure it to use the obtained credentials
            con = new HubConnection(NOTIFICATIONS_URL)
            {
                CookieContainer = Client.CookieContainer
            };

            con.StateChanged += change =>
            {
                switch (change.NewState)
                {
                    case ConnectionState.Connected:
                        Console.WriteLine("Connected!");

                        // Methods to call on server must be camel case
                        installationHub.Invoke("joinGroup", INSTALLATION_ID);
                        sensorHub.Invoke("joinGroup", SENSOR_ID);

                        break;

                    case ConnectionState.Disconnected:
                        Console.WriteLine("Disconnected!");
                        break;
                }
            };

            // Hub names must be camel case
            installationHub = con.CreateHubProxy("installationHub");
            sensorHub = con.CreateHubProxy("sensorHub");

            // Subscribe to desired events on each Hub
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
    }

}