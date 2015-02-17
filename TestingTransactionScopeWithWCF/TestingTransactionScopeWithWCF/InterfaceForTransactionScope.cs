using System.ServiceModel;

namespace TestingTransactionScopeWithWCF
{
    [ServiceContract]
    
    public interface InterfaceForTransactionScope
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        [FaultContract(typeof(int))]
        void WriteStringToFile(string value);

        [OperationContract]
        string GetFileContent();

        [OperationContract]
        void Clean();

        [OperationContract]
        void ThrowException();
    }
}
