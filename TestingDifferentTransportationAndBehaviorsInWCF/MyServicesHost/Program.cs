using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using NetTCP;

namespace MyServicesHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            var tcpServiceHost = new ServiceHost(typeof(NetOverTCP)); 
            tcpServiceHost.Open();
            foreach (var endpoint in tcpServiceHost.Description.Endpoints)
            {
                Console.WriteLine(endpoint.Address);
            }

            var msmqServiceHost = new ServiceHost(typeof(MSMQTransportation.MSMQTransportation));
            msmqServiceHost.Open();
            foreach (var endpoint in msmqServiceHost.Description.Endpoints)
            {
                Console.WriteLine(endpoint.Address);
            }
            Console.ReadLine();
        }
    }
}
