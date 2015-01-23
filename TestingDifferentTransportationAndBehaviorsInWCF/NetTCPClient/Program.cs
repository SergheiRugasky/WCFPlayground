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

            var namedPipesFactory = new ChannelFactory<INamedPipesTransport>(new NetNamedPipeBinding());
            var namedPipesChannel = namedPipesFactory.CreateChannel(new EndpointAddress("net.pipe://localhost/NamedPipe"));
            var namedPipesResponse = namedPipesChannel.Talk("oooohh");
            Console.WriteLine(namedPipesResponse);

            try
            {
                var netTCPFactory1 = new ChannelFactory<INetOverTCP>(new NetTcpBinding());
                INetOverTCP netOverTcpChannel1 = netTCPFactory1.CreateChannel(new EndpointAddress("net.tcp://localhost/12321"));
                string netTCPResponse1 = netOverTcpChannel1.Talk(true);
                Console.WriteLine(netTCPResponse1);
            }
            catch (FaultException faultException)
            {
                Console.WriteLine("Fault exception thrown with message : {0}", faultException.Message);
            }
            

            var duplexFactory = new DuplexChannelFactory<IDuplexService>(new InstanceContext(new HandleCallbak()),new WSDualHttpBinding());
            var duplexService = duplexFactory.CreateChannel(new EndpointAddress("http://localhost/11122"));
            duplexService.DoSomeShitThatTakesSeconds(5);
            Console.ReadLine();
        }
    }

    public class HandleCallbak:IDuplexCallback{
        public void ProcessComplete(string seconds)
        {
            Console.WriteLine(string.Format("waited for {0} seconds",seconds));
        }
    }
}