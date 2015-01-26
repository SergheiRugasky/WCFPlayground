using System;
using System.ServiceModel;
using Entities;

namespace SimpleService
{
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface ISimpleHello
    {
        [OperationContract(IsOneWay = false)]
        string SayHello(Person person);
    }


    public class SimpleHello : ISimpleHello
    {
        public string SayHello(Person person)
        {
            return String.Format("Hello,{0} {1}!", person.FirstName, person.LastName);
        }
    }
}