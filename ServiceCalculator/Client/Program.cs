﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using Client.client;
using Entities;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new CalculatorServiceClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:12345"));
            //var factory = new ChannelFactory<ICalculatorService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:12345"));
            //var service = factory.CreateChannel();
            //var factory = new ChannelFactory<ICalculatorService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:12345"));
            var a = new Complex {Real = 1,Imaginary = 2};
            var b = new Complex {Real = 3,Imaginary = 4};
            var sum = service.Add(a, b);
            var diff = service.Substract(b, a);
            var multiply = service.Multiply(a, b);
            Console.WriteLine("a="+a);
            Console.WriteLine("b="+b);
            Console.WriteLine("sum=" + sum);
            Console.WriteLine("diff=" + diff);
            Console.WriteLine("multiply=" + multiply);
            try
            {
                service.ThrowError();
            }
            catch (FaultException faultException)
            {
                Console.WriteLine(faultException.Message);
            }
            service.TestingAsyncCallCompleted += AsynchCallEnded;
            service.TestingAsyncCallAsync("first call");
            service.TestingAsyncCallAsync("second call");
            Console.ReadLine();
        }

        private static void AsynchCallEnded(object sender, TestingAsyncCallCompletedEventArgs e)
        {
            Console.WriteLine(e.Result + " on the callback");
        }
    }
}
