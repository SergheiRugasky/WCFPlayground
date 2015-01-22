using System.ServiceModel;

namespace Infrastructure
{
    [ServiceContract]
    public interface INetOverTCP
    {
        [OperationContract]
        string Talk(string message);
    }
}