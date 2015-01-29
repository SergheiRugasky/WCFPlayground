using System.ServiceModel;

namespace DefaultEndpoints
{
    [ServiceContract]
    public interface ISomeService
    {
        [OperationContract]
        string Lala(int input);
    }

    public class SomeService : ISomeService
    {
        public string Lala(int input)
        {
            return string.Format("you have given this input : {0}", input);
        }
    }
}