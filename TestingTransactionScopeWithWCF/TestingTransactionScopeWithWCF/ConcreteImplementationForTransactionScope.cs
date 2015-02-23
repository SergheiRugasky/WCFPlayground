using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Transactions;

namespace TestingTransactionScopeWithWCF
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,ReleaseServiceInstanceOnTransactionComplete = false)]
    public class ConcreteImplementationForTransactionScope : InterfaceForTransactionScope
    {
        private readonly FirstVolatileResourceManager firstVolatileResourceManager = new FirstVolatileResourceManager();
        private readonly SecondVolatileResourceManager secondVolatileResourceManager = new SecondVolatileResourceManager();
       
        
        [OperationBehavior(TransactionScopeRequired = true)]
        public void Enlist()
        {
            Transaction.Current.EnlistVolatile(secondVolatileResourceManager, EnlistmentOptions.None);
            Transaction.Current.EnlistVolatile(firstVolatileResourceManager, EnlistmentOptions.None);
        }

        [OperationBehavior(TransactionScopeRequired = true,TransactionAutoComplete = true)]
        public void WriteStringToList(string value)
        {
            firstVolatileResourceManager.Add(value);
        }

        public string GetValues()
        {
            return firstVolatileResourceManager.GetValues();
        }

        

        public void ThrowException(bool shouldThrowException)
        {
            secondVolatileResourceManager.ThrowException(shouldThrowException);
        }
    }

    internal class SecondVolatileResourceManager : IEnlistmentNotification
    {
        public void Prepare(PreparingEnlistment preparingEnlistment)
        {
            Console.WriteLine("Second resource manager is prepared");
            preparingEnlistment.Prepared();
        }

        public void Commit(Enlistment enlistment)
        {
            Console.WriteLine("Second resource manager commited");
            enlistment.Done();
        }

        public void Rollback(Enlistment enlistment)
        {
            Console.WriteLine("Second resource manager rollback");
        }

        public void InDoubt(Enlistment enlistment)
        {
            Console.WriteLine("Second resource manager is in doubt");
            enlistment.Done();
        }

        public void ThrowException(bool shouldThrowException)
        {
            if (shouldThrowException)
            {
                throw new FaultException("Some shitty fault");
            }
        }
    }


    public class FirstVolatileResourceManager : IEnlistmentNotification
    {
        private readonly List<string> myList = new List<string>();
        public void Clean()
        {
            myList.Clear();
        }
        public void Prepare(PreparingEnlistment preparingEnlistment)
        {
            Console.WriteLine("First resource manager is prepared");
            preparingEnlistment.Prepared();
        }

        public void Commit(Enlistment enlistment)
        {
            Console.WriteLine("First resource manager commited");
            enlistment.Done();
        }

        public void Rollback(Enlistment enlistment)
        {
            Console.WriteLine("First resource manager rollback");
            Clean();
        }

        public void InDoubt(Enlistment enlistment)
        {
            Console.WriteLine("First resource manager is in doubt");
            enlistment.Done();
        }

        public string GetValues()
        {
            if (myList == null || myList.Count == 0)
            {
                return "Nothing here";
            }
            return myList.Aggregate((i, j) => i + Environment.NewLine + j);
        }

        public void Add(string value)
        {
            myList.Add(value);
        }
    }
}