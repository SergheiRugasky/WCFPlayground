using System.ServiceModel;

namespace AdHocDiscovery
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        string Connect();
    }
}