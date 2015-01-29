using System;
using System.Linq;
using System.ServiceModel;
using DefaultBindingsAndBehavior;

namespace DefaultBindingsAndBehaviorsHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(SomeService));
            serviceHost.AddDefaultEndpoints();
            serviceHost.Open();
            foreach (var endpoint in serviceHost.Description.Endpoints)
            {
                Console.WriteLine("{0},{1}", endpoint.Address, endpoint.Binding.ReceiveTimeout);
            }
            Console.ReadLine();
        }
    }
}