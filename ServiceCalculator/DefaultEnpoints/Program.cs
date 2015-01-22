using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace DefaultEnpoints
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(EchoService),new Uri("net.tcp://localhost/echo"),new Uri("http://localhost/echo"));
            //serviceHost.Description.Behaviors.Add(new ServiceMetadataBehavior()
            //{
            //    HttpGetEnabled = true
            //});
            //var serviceBehavior = (ServiceDebugBehavior)serviceHost.Description.Behaviors.First(item => item.GetType() == typeof (ServiceDebugBehavior));
            //serviceBehavior.IncludeExceptionDetailInFaults = true;
            //serviceHost.AddServiceEndpoint(typeof(IMetadataExchange),MetadataExchangeBindings.CreateMexHttpBinding(),"/mex");
            serviceHost.AddDefaultEndpoints();
            serviceHost.Open();
            foreach (var endpoint in serviceHost.Description.Endpoints)
            {
                Console.WriteLine(endpoint.Address);
            }

            Console.ReadLine();
        }
    }

    public class EchoService:IIntEchoService,IStringEchoService
    {
        public int EchoInt(int value)
        {
            return value;
        }

        public string EchoString(string value)
        {
            return value;
        }

        public string EchoString()
        {
            return "Just testing default behavior";
        }
        
    }

    [ServiceContract]
    public interface IDefaultBehaviorTest
    {
        [OperationContract]
        string EchoString();
    }

    [ServiceContract]
    public interface IStringEchoService
    {
        [OperationContract]
        string EchoString(string value);

        
    }

    [ServiceContract]
    public interface IIntEchoService
    {
        [OperationContract]
        int EchoInt(int value);
    }
}
