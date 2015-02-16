using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using DefaultEndpoints;

namespace DefaultEndpointsHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var defaultEndpointServiceHost = new ServiceHost(typeof(SomeService));
            //defaultEndpointServiceHost.AddDefaultEndpoints();
            defaultEndpointServiceHost.Open();
            foreach (var endpoint in defaultEndpointServiceHost.Description.Endpoints)
            {
				
                Console.WriteLine(endpoint.Address +" "+ endpoint.Binding+ " " +endpoint.Contract.ContractType +" " + endpoint.ListenUri);
            }
            Console.ReadLine();
        }
    }
}
