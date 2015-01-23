using System.ServiceModel;

namespace Infrastructure
{
    [ServiceContract]
    public interface INamedPipesTransport
    {
        [OperationContract]
        string Talk(string message);
    }
}
