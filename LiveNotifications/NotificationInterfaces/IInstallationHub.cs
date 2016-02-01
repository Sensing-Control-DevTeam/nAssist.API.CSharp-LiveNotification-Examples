using LiveNotifications.NotificationModel;
using nassist.ServiceImplementation.SignalR.Hubs;

namespace LiveNotifications.NotificationInterfaces
{
    public interface IInstallationHubClient : IBaseHubClient
    {
        void receiveNewInstallationActiveSchedules(string installationId, string date, int activeSchedules);
        void receiveNewInstallationActiveSchedulesByType(string installationId, string date, int activeSchedules, string type);
        void receiveNewInstallationComfortStatus(string installationId, string date, string CssName);
        void receiveNewInstallationComfortStatus(string installationId, string date, string CssName, string DisplayName);
        void receiveNewInstallationSecurityStatus(string installationId, string date, string securityStatus, string trigger);
        void receiveNewInstallationStatus(string installationId, string date, string status);
        void receiveNewInstallationDayEnergyTrend(string installationId, string date, string energyTrend, double? energyValue);
        void receiveNewInstallationOverallTemp(string installationId, double? newOverallTemp);
        void receiveNewInstallationOverallHumidity(string installationId, double? newOverallHumidity);
        void receiveNewRule(long ruleId, string name, string description, string category);
        void receiveNewCondition(long conditionId, string description);
        void receiveConditionDeleted(long conditionId);
        void receiveActionDeleted(long actionId);
        void receiveLiveSensorData(LiveSensorValuesMapping data);
    }

    public interface IInstallationHubServer : IBaseHubServer
    { }
}
