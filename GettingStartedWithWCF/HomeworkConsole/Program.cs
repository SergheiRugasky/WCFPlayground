﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Homework;

namespace HomeworkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var  homeworkHost = new ServiceHost(typeof(HomeworkService));
            homeworkHost.Open();
            foreach (var endpoint in homeworkHost.Description.Endpoints)
            {
                Console.WriteLine(endpoint.Address);
            }
            Console.WriteLine("homework is running");
            Console.ReadLine();
        }
    }
}
