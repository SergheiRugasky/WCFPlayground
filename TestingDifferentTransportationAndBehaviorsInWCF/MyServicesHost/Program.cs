using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using Duplex;
using NamedPipes;
using NetTCP;

namespace MyServicesHost
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var tcpServiceHost = new ServiceHost(typeof (NetOverTCP));
            tcpServiceHost.Open();
            foreach (ServiceEndpoint endpoint in tcpServiceHost.Description.Endpoints)
            {
                Console.WriteLine(endpoint.Address);
            }

            var msmqServiceHost = new ServiceHost(typeof (MSMQTransportation.MSMQTransportation));
            msmqServiceHost.Open();
            foreach (ServiceEndpoint endpoint in msmqServiceHost.Description.Endpoints)
            {
                Console.WriteLine(endpoint.Address);
            }

            var namedPipesHost = new ServiceHost(typeof (NamedPipesTransport));
            namedPipesHost.Open();
            foreach (ServiceEndpoint endpoint in namedPipesHost.Description.Endpoints)
            {
                Console.WriteLine(endpoint.Address);
            }

            var duplexServiceHost = new ServiceHost(typeof (DuplexService));
            duplexServiceHost.Open();

            foreach (ServiceEndpoint endpoint in duplexServiceHost.Description.Endpoints)
            {
                Console.WriteLine(endpoint.Address);
            }

            Console.ReadLine();
        }
    }
}