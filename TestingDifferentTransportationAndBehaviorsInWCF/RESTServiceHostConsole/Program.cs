using System;
using System.ServiceModel.Web;
using RESTService;

namespace RESTServiceHostConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var webServiceHost = new WebServiceHost(typeof(MyRESTService),new Uri("http://localhost:1234"));
            webServiceHost.Open();
            foreach (var endpoint in webServiceHost.Description.Endpoints)
            {
                Console.WriteLine(endpoint.Address);
            }
            Console.ReadLine();
        }
    }
}
