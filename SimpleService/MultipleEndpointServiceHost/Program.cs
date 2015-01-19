using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SimpleService;

namespace MultipleEndpointServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceHost = new ServiceHost(typeof(MultipleEndpointsService.MultipleEndpointsService));
            serviceHost.Open();

            foreach (var endpoint in serviceHost.Description.Endpoints)
            {
                Console.WriteLine(endpoint.Address);
            }

            Console.ReadLine();
        }
    }
}
