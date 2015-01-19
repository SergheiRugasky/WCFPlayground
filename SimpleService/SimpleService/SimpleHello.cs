using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace SimpleService
{
    [ServiceContract]
    public interface ISimpleHello
    {
        [OperationContract]
        string SayHello(Person person);
    }

    
    public class SimpleHello : ISimpleHello
    {
        
        public string SayHello(Person person)
        {
            return String.Format("Hello,{0} {1}!",person.FirstName,person.LastName);
        }
    }
}
