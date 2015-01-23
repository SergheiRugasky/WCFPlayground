using System.ServiceModel;

namespace Infrastructure
{
    public interface IDuplexCallback
    {
        [OperationContract(IsOneWay = true)]
        void ProcessComplete(string seconds);
    }

    [ServiceContract(CallbackContract = typeof (IDuplexCallback))]
    public interface IDuplexService
    {
        [OperationContract(IsOneWay = true)]
        void DoSomeShitThatTakesSeconds(int seconds);
    }
}