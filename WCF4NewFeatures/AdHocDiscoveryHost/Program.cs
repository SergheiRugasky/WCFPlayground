using System;
using System.ServiceModel;
using AdHocDiscovery;

namespace AdHocDiscoveryHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceHostVersionOne = new ServiceHost(typeof(TestServiceVersionOne));
            var serviceHostVersionTwo = new ServiceHost(typeof(TestServiceVersionTwo));

            serviceHostVersionOne.Open();
            serviceHostVersionTwo.Open();

            foreach (var endpoint in serviceHostVersionOne.Description.Endpoints)
            {
                Console.WriteLine("v1:{0}",endpoint.Address);
            }

            foreach (var endpoint in serviceHostVersionTwo.Description.Endpoints)
            {
                Console.WriteLine("v2:{0}", endpoint.Address);
            }

            Console.ReadLine();
        }
    }
}
