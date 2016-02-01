using System.Collections.Generic;

namespace LiveNotifications.NotificationModel
{
    public class LiveSensorValuesMapping
    {
        public List<SensorDataPoint> Sensors { get; set; }
        public double MasterValue { get; set; }
    }
}
