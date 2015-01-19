using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

            var tcpChannelFactory = new ChannelFactory<IMultipleEndpointsService>(new BasicHttpBinding());
            IMultipleEndpointsService multipleEndpointsService = tcpChannelFactory.CreateChannel(new EndpointAddress("http://localhost:5555/merge"));
            string describeYourself = multipleEndpointsService.DescribeYourself();

            tcpChannelFactory = new ChannelFactory<IMultipleEndpointsService>(new NetTcpBinding());
            IMultipleEndpointsService multipleEndpointsServiceOverTcp = tcpChannelFactory.CreateChannel(new EndpointAddress("net.tcp://server:8081/serghei"));
            describeYourself = multipleEndpointsServiceOverTcp.DescribeYourself();

            Console.WriteLine(describeYourself);
            Console.ReadLine();
        }
    }
}
