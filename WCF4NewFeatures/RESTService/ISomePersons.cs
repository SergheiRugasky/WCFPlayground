using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace RESTService
{
    [ServiceContract]
    public interface ISomePersons
    {
        [OperationContract]
        [WebInvoke(Method = "PUT",UriTemplate = "/Persons/put?name={name}")]
        void PutPerson(string name);
        [OperationContract]
        [WebGet(UriTemplate = "/Persons?id={id}")]
        string GetPerson(int id);
        [OperationContract]
        [WebInvoke(Method = "DELETE",UriTemplate = "/Persons/delete?name={name}")]
        void DeletePerson(string name);
        [OperationContract]
        [WebInvoke(Method = "POST",UriTemplate = "/Persons/post?name={name}")]
        void PostPerson(string name);

        [OperationContract]
        [WebGet(UriTemplate = "/Persons/all")]
        List<string> GetAll();

        [AspNetCacheProfile("10Seconds")]
        [OperationContract]
        [WebGet(UriTemplate = "/Cache")]
        string TestCache();
    }
}