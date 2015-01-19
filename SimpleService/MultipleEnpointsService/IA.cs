using System.ServiceModel;

namespace MultipleEndpointsService
{
    [ServiceContract]
    public interface IMultipleEndpointsService
    {
        [OperationContract]
        string DescribeYourself();
    }

    public class MultipleEndpointsService : IMultipleEndpointsService
    {
        public string DescribeYourself()
        {
            return "I am here";
        }
    }
}
