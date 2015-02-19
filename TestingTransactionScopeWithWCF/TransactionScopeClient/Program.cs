using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Transactions;
using TestingTransactionScopeWithWCF;

namespace TransactionScopeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var section = (ClientSection)ConfigurationManager.GetSection("system.serviceModel/client");

            var channelFactory = new ChannelFactory<InterfaceForTransactionScope>("clientEndpoint");
            var proxy = channelFactory.CreateChannel();
            var actions = new List<Action>
            {
                proxy.Enlist,
                () => proxy.WriteStringToList("My First Line"),
                () => proxy.ThrowException(true),
                () => proxy.WriteStringToList("My Second Line"),
                () => proxy.WriteStringToList("Third")
            };
            try
            {
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required))
                {
                    try
                    {
                        foreach (
                            var action in
                                actions.Where(
                                    action =>
                                        Transaction.Current.TransactionInformation.Status == TransactionStatus.Active))
                        {
                            action();
                        }
                        transactionScope.Complete();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            
            finally
            {
                var fileContent = proxy.GetValues();
                Console.WriteLine(fileContent);
            }
            
            

            
            Console.ReadLine();
        }
    }
}
