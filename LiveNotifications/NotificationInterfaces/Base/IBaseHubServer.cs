using System.Threading.Tasks;

namespace nassist.ServiceImplementation.SignalR.Hubs
{
    public interface IBaseHubServer
    {
        Task JoinGroup(string groupName);

        Task LeaveGroup(string groupName);
    }
}