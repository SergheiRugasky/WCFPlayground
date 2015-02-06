using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Discovery;
using System.Text;
using AdHocDiscovery;

namespace AdHocDiscoveryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //var dynamicEndpoint = new DynamicEndpoint(ContractDescription.GetContract(typeof (ITestService)),
            //    new WSHttpBinding());
            //var testService = new ChannelFactory<ITestService>(dynamicEndpoint).CreateChannel();
            //var connect = testService.Connect();

            var discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint());
            var findCriteria = new FindCriteria(typeof (ITestService));
            findCriteria.Scopes.Add(new Uri("http://localhost:12121/v2"));
            findCriteria.ScopeMatchBy = FindCriteria.ScopeMatchByExact;
            var findResponse = discoveryClient.Find(findCriteria);
            string connect;
            if (findResponse.Endpoints.Count>0)
            {
                var testService = new ChannelFactory<ITestService>(new WSHttpBinding()).CreateChannel(findResponse.Endpoints.First().Address);
                connect = testService.Connect();
            }
            else
            {
                connect = "No endpoint found!";
            }
            Console.WriteLine(connect);
            Console.ReadLine();
        }
    }
}
