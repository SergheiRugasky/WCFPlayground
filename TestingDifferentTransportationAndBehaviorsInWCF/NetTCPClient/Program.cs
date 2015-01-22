using System;
using System.ServiceModel;
using Infrastructure;

namespace NetTCPClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var netTCPFactory = new ChannelFactory<INetOverTCP>(new NetTcpBinding());
            INetOverTCP netOverTcpChannel = netTCPFactory.CreateChannel(new EndpointAddress("net.tcp://localhost/12321"));
            string netTCPResponse = netOverTcpChannel.Talk("beek-a-boo");
            Console.WriteLine(netTCPResponse);

            var MSMQFactory = new ChannelFactory<IMSMQTransport>(new NetMsmqBinding());
            var msmqOverTcpChannel = MSMQFactory.CreateChannel(new EndpointAddress("net.msmq://localhost/private/serghei"));
            msmqOverTcpChannel.Talk("beek-a-boo");
            Console.ReadLine();
        }
    }
}