using ServiceStack;

namespace LiveNotifications.NotificationModel
{
    public abstract class ResponseBase
    {
        public ResponseStatus ResponseStatus { get; set; }

        protected ResponseBase()
        {
            ResponseStatus = new ResponseStatus();
        }
    }
}
