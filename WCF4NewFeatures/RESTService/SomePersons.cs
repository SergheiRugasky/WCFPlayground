using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace RESTService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class SomePersons : ISomePersons
    {
        private readonly List<string> persons = new List<string>();
 
        public void PutPerson(string name)
        {
            persons.Add(name);    
        }

        public string GetPerson(int id)
        {
            return persons[id];
        }

        public void DeletePerson(string name)
        {
            persons.Remove(name);
        }

        public void PostPerson(string name)
        {
            persons.Add(name);
        }

        public List<string> GetAll()
        {
            return persons;
        }

        public string TestCache()
        {
            return DateTime.Now.ToLongTimeString();
        }
    }
}
