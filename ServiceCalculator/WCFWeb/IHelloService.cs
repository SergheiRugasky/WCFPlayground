using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCFWeb
{
    [ServiceContract]
    internal interface IHelloService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "{name}",Method = "PUT")]
        string SayHello(string name,string body);
    }

    
}