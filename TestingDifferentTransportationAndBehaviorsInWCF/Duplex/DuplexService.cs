using System;
using System.ServiceModel;
using System.Threading;
using Infrastructure;

namespace Duplex
{
    public class DuplexService : IDuplexService
    {
        public void DoSomeShitThatTakesSeconds(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            new HandleCallbak().Notify(seconds.ToString());
        }
    }

    public class HandleCallbak
    {
        public void Notify(string seconds)
        {
            var callbackChannel = OperationContext.Current.GetCallbackChannel<IDuplexCallback>();
            callbackChannel.ProcessComplete(seconds);
        }
    }
}