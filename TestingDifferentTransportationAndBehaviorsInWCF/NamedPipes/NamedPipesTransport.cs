using Infrastructure;

namespace NamedPipes
{
    public class NamedPipesTransport : INamedPipesTransport
    {
        public string Talk(string message)
        {
            return string.Format("This message was transported via Named Pipes : {0}", message);
        }
    }
}