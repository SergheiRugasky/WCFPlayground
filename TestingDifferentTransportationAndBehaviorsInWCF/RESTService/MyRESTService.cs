using System;
using System.IO;
using Infrastructure;

namespace RESTService
{
    public class MyRESTService : IRESTService
    {
        public string SayHellTo(string name)
        {
            return string.Format("hello {0}!", name);
        }

        public void PrintHello(string name)
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "web.txt", string.Format("hello {0}!", name));
        }

        public string TestingURITemplate(string something, string anotherthing)
        {
            return string.Format("something : {0} \r\n anotherthing : {1}", something, anotherthing);
        }
    }
}