using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using DefaultBindingsAndBehavior;

namespace DefaultBindingsAndBehaviorsClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var serviceEndpoint = MetadataResolver.Resolve(typeof (SomeService), new EndpointAddress("http://localhost:12321/meta")).First();

            var channelFactory = new ChannelFactory<ISomeService>(serviceEndpoint);

            var someService = channelFactory.CreateChannel();

            var input = Console.ReadLine();
            try
            {
                var justThrowException = someService.JustThrowException(int.Parse(input));
            }
            catch (FaultException exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.ReadLine();
        }
    }
}