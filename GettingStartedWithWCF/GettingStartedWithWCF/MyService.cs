using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GettingStartedWithWCF
{
    [DataContract]
    public class Name
    {
        [DataMember]
        public string First { get; set; }
        [DataMember]
        public string Last { get; set; }
    }

    [DataContract]
    public class Eval
    {
        [DataMember]
        public string Submitter;
        [DataMember]
        public string TimeSent;
        [DataMember]
        public string Comments;
    }

    [ServiceContract]
    public interface IEvalService
    {
        [OperationContract]
        void Submit(Eval eval);
        [OperationContract]
        List<Eval> GetEvals();
    }

    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        string SayHello(Name personName);
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EvalService : IEvalService
    {
        List<Eval> evals = new List<Eval>(); 
        public void Submit(Eval eval)
        {
            evals.Add(eval);
        }

        public List<Eval> GetEvals()
        {
            return evals;
        }
    }
    public class MyService:IMyService
    {
        public string SayHello(Name personName)
        {
            return "Hello " + personName.First + personName.Last;
        }
    }
}
