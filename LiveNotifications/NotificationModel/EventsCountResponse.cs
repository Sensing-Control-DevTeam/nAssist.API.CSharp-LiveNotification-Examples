using System.Collections.Generic;

namespace LiveNotifications.NotificationModel
{
    public class EventsCountResponse : ResponseBase
    {
        public Dictionary<string, int> EventGroupsCount { get; set; }

        public int TotalCount { get; set; }

        public EventsCountResponse()
        {
            EventGroupsCount = new Dictionary<string, int>();
        }
    }
}
