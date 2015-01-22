using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Infrastructure;

namespace MSMQTransportation
{
    public class MSMQTransportation : IMSMQTransport
    {
        public void Talk(string message)
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "proof.txt", string.Format("I have received this message over MSMQ : '{0}'", message));
        }
    }
}
