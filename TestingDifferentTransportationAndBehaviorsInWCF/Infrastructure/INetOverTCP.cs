using System.ServiceModel;

namespace Infrastructure
{
    [ServiceContract]
    public interface INetOverTCP
    {
        [OperationContract(Name = "1")]
        string Talk(string message);

        [OperationContract]
        string Talk(bool merge);

    }
}