using System;
using System.ServiceModel;
using TestingTransactionScopeWithWCF;

namespace TransactionScopeServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceHost = new ServiceHost(typeof(ConcreteImplementationForTransactionScope));
            foreach (var endpoint in serviceHost.Description.Endpoints)
            {
                Console.WriteLine("Endpoint at {0} with binding {1}",endpoint.Address,endpoint.Binding);
            }
            serviceHost.Open();
            Console.ReadLine();
        }
    }
}
