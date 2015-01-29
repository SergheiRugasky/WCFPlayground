using System;

namespace DefaultBindingsAndBehavior
{
    public class SomeService : ISomeService
    {
        public int Echo(int value)
        {
            return value;
        }

        public int JustThrowException(int value)
        {
            throw new NotImplementedException("boo-hoo");
        }

        public string SaySomething(string input)
        {
            return string.Format("this was your input : {0}", input);
        }
    }
}