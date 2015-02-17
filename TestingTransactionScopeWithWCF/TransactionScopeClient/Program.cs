using System;
using System.Configuration;
using System.IO;
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
            try
            {
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required))
                {

                    proxy.Clean();
                    proxy.WriteStringToFile("My First Line");
                   // proxy.ThrowException();
                    //try
                    //{
                    //}
                    //catch (Exception ex)
                    //{
                    //    Console.WriteLine(ex.Message);
                    //}

                    proxy.WriteStringToFile("My Second Line");
                    transactionScope.Complete();
                }
            }
            finally
            {
                var fileContent = proxy.GetFileContent();
                Console.WriteLine(fileContent);
            }
            
            

            
            Console.ReadLine();
        }
    }
}
