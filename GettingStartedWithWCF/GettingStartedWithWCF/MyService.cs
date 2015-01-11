using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GettingStartedWithWCF
{
    [DataContract]
    public class Name
    {
        [DataMember]
        public string First { get; set; }
        [DataMember]
        public string Last { get; set; }
    }

    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        string SayHello(Name personName);
    }
    
    public class MyService:IMyService
    {
        public string SayHello(Name personName)
        {
            return "Hello " + personName.First +" "+ personName.Last;
        }
    }
}
