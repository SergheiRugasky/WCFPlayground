﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using ServiceCalculator;

namespace ServiceCalculatorHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ServiceHost(typeof(CalculatorService));
            service.Open();
            Console.WriteLine("Service calculator is running");
            Console.ReadLine();
        }
    }
}
