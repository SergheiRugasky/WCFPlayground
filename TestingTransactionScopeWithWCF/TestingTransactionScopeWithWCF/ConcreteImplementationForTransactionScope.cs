using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Transactions;

namespace TestingTransactionScopeWithWCF
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ConcreteImplementationForTransactionScope : InterfaceForTransactionScope,IEnlistmentNotification
    {
        private readonly string fileName;
        private readonly List<string> myList = new List<string>();

        public ConcreteImplementationForTransactionScope()
            : this("test")
        {
        }

        
        public ConcreteImplementationForTransactionScope(string fileName)
        {
            this.fileName = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) +@"\" + fileName + ".txt";
        }

        
        [OperationBehavior(TransactionScopeRequired = true)]
        public void WriteStringToFile(string value)
        {
            Transaction.Current.EnlistVolatile(this, EnlistmentOptions.EnlistDuringPrepareRequired);
            myList.Add(value);
            //File.AppendAllText(fileName,value + Environment.NewLine);
        }

        public string GetFileContent()
        {
            if (myList == null || myList.Count == 0)
            {
                return "Nothing here";
            }
            return myList.Aggregate((i, j) => i + j);
            return File.ReadAllText(fileName);
        }

        public void Clean()
        {
            myList.Clear();
            //File.WriteAllText(fileName,string.Empty);
        }

        public void ThrowException()
        {
            throw new FaultException();
        }

        public void Prepare(PreparingEnlistment preparingEnlistment)
        {
            
            preparingEnlistment.Done();
        }

        public void Commit(Enlistment enlistment)
        {
            enlistment.Done();
        }

        public void Rollback(Enlistment enlistment)
        {
            Clean();
        }

        public void InDoubt(Enlistment enlistment)
        {
            enlistment.Done();
        }
    }
}