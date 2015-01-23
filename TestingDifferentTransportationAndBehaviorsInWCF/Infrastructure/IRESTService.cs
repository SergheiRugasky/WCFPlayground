using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Infrastructure
{
    [ServiceContract]
    public interface IRESTService
    {
        [WebGet(UriTemplate = "rest?name={name}")]
        [OperationContract]
        string SayHellTo(string name);

        [WebInvoke(UriTemplate = "rest/print?name={name}",Method = "PUT")]
        [OperationContract]
        void PrintHello(string name);

        [WebGet(UriTemplate = "rest?something={*}")]
        [OperationContract]
        string TestingURITemplate(string something, string anotherthing);

    }

    public class SomeClass
    {
        public static UriTemplate TestingURITemplate
        {
            get
            {
                return new UriTemplate("");
            }
        }
    }
    
}