using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MultipleEndpointsService;
using SimpleService;

namespace SimpleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var channelFactory = new ChannelFactory<ISimpleHello>(new BasicHttpBinding(), "http://localhost/12345");
            var simpleHello = channelFactory.CreateChannel();
            string hello = simpleHello.SayHello(new Person()
            {
                FirstName = "Serghei",
                LastName = "Rugasky"
            });

            Console.WriteLine(hello);

            //var tcpChannelFactory = new ChannelFactory<IMultipleEndpointsService>(new BasicHttpBinding());
            //IMultipleEndpointsService multipleEndpointsService = tcpChannelFactory.CreateChannel(new EndpointAddress("http://localhost:5555/merge"));
            //string describeYourself = multipleEndpointsService.DescribeYourself();


            var serviceEndpointCollection =
                MetadataResolver.Resolve(typeof (IMultipleEndpointsService),
                    new EndpointAddress("http://localhost:12345/endpointmex"));

            ServiceEndpoint endpoint = serviceEndpointCollection.FirstOrDefault();

            var factory = new ChannelFactory<IMultipleEndpointsService>(endpoint.Binding,endpoint.Address);
            var endpointsService = factory.CreateChannel();
            var describeYourself = endpointsService.DescribeYourself();
            Console.WriteLine(describeYourself);
            Console.ReadLine();
        }
    }
}
