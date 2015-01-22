using System.ServiceModel;

namespace ServicesToBeRouted
{
    [ServiceContract]
    public class HelloWorld
    {
        [OperationContract]
        public string SayHi(string name)
        {
            return string.Format("Hello,{0}!", name);
        }
    }
}
