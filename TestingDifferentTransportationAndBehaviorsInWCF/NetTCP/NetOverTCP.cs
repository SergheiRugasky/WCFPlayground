using System;
using Infrastructure;

namespace NetTCP
{
    public class NetOverTCP : INetOverTCP
    {
        public string Talk(string message)
        {
            return string.Format("I have received this message over TCP : '{0}'", message);
        }

        public string Talk(bool merge)
        {
            if (merge)
            {
                throw new NotImplementedException("Trying to throw an exception!");
            }
            return merge.ToString();
        }
    }
}
