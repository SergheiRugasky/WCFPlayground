using System.ServiceModel;

namespace TestingTransactionScopeWithWCF
{
    [ServiceContract]
    public interface InterfaceForTransactionScope
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void WriteStringToList(string value);

        [OperationContract]
        string GetValues();

        [OperationContract]
        void ThrowException(bool shouldThrowException);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void Enlist();
    }
}
