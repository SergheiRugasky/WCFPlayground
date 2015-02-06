namespace AdHocDiscovery
{
    public class TestServiceVersionOne : ITestService
    {
        public string Connect()
        {
            return "Connected to v.1!";
        }
    }

    public class TestServiceVersionTwo : ITestService
    {
        public string Connect()
        {
            return "Connected to v.2!";
        }
    }

}