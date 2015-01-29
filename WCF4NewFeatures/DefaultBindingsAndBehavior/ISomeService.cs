using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace DefaultBindingsAndBehavior
{
    [ServiceContract]
    public interface ISomeService
    {
        [OperationContract]
        int Echo(int value);

        [OperationContract]
        int JustThrowException(int value);

        [OperationContract]
        [WebGet(UriTemplate = "/REST?input={input}")]
        string SaySomething(string input);
    }
}