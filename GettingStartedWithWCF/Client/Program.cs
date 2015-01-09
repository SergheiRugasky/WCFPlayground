using System;
using System.ServiceModel;
using Client.HelloMotherfucka;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MyServiceClient("NetTcpBinding_IMyService");
            Name name = new Name();
            name.First = "Ion";
            name.Last = "Iliescu";
            var sayHello = client.SayHello(name);
            Console.WriteLine(sayHello);
            Console.ReadLine();
        }
    }
}
