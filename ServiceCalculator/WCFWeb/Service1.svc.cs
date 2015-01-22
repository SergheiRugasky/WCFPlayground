using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFWeb
{
    public class HelloService : IHelloService
    {
        public string SayHello(string name,string body)
        {
            return "Hello," + name + "!";
        }
    }
}
