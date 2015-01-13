using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using Entities;
using ServiceCalculator;

namespace RuntimeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceEndpointCollection = MetadataResolver.Resolve(typeof (ICalculatorService), new EndpointAddress("http://localhost:12345/endpointmex"));

            var endpoint = serviceEndpointCollection.FirstOrDefault();

            var factory = new ChannelFactory<ICalculatorService>(endpoint.Binding,endpoint.Address);

            var calculatorService = factory.CreateChannel();

            Complex first = new Complex
            {
                Real = 1,
                Imaginary = 2
            };

            Complex second = new Complex()
            {
                Real = 3,
                Imaginary = 4
            };

            var sum = calculatorService.Add(first, second);

            Console.WriteLine("sum="+sum);
            Console.ReadLine();
        }
    }
}
