using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SimpleServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceHost = new ServiceHost(typeof(SimpleService.SimpleHello),new Uri("http://localhost/12345"));
            serviceHost.Open();
            foreach (var endpoint in serviceHost.Description.Endpoints)
            {
                Console.WriteLine(String.Format("endpoint at:{0}", endpoint.Address));
            }

            Console.ReadLine();
        }
    }
}
