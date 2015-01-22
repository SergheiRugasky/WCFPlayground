using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ServicesToBeRouted
{
    [ServiceContract]
    class OneWayService
    {
        [OperationContract(IsOneWay = true)]
        void PrintHi(string name)
        {
            Console.WriteLine("Hello from {0}",name);
        }
    }
}
