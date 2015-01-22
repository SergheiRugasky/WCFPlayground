using System.ServiceModel;

namespace Infrastructure
{
    [ServiceContract]
    public interface IMSMQTransport
    {
        [OperationContract(IsOneWay = true)]
        void Talk(string message);
    }
}
