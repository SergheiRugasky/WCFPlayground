using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    [DataContract]
    public class Homework
    {
        [DataMember]
        public string Student
        {
            get; set;
        }
        [DataMember]
        public string Task { get; set; }
    }


    [ServiceContract]
    public interface IHomeworkService
    {
        [OperationContract]
        string Do(Homework homework);
    }

    public class HomeworkService : IHomeworkService
    {
        
        public string Do(Homework homework)
        {
            return homework.Student + " has done his " + homework.Task + " homework";
        }
    }
}
