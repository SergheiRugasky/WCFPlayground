using System;
using System.Linq;
using Client.Eval;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            EvalServiceClient client = new EvalServiceClient("NetTcpBinding_IEvalService");
            var eval1 = new Eval.Eval {Comments = "First", TimeSent = DateTime.Now.ToLongDateString()};
            client.Submit(eval1);

            var eval2 = new Eval.Eval { Comments = "Second", TimeSent = DateTime.Now.ToLongDateString() };
            client.Submit(eval2);

            var eval3 = new Eval.Eval { Comments = "Third", TimeSent = DateTime.Now.ToLongDateString() };
            client.Submit(eval3);

            var comments = client.GetEvals().Select(i => i.Comments).Aggregate((i, j) => i + " " + j);
            Console.WriteLine(comments);
            Console.ReadLine();
        }
    }
}
