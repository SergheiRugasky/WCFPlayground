using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Entities;

namespace ServiceCalculator
{
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        Complex Add(Complex a, Complex b);

        [OperationContract]
        Complex Substract(Complex first, Complex second);

        [OperationContract]
        Complex Multiply(Complex first, Complex second);

        [OperationContract]
        void ThrowError();
    }

    public class CalculatorService : ICalculatorService
    {
        public Complex Add(Complex a, Complex b)
        {
            return a + b;
        }

        public Complex Substract(Complex first, Complex second)
        {
            return first - second;
        }

        public Complex Multiply(Complex first, Complex second)
        {
            return first*second;
        }

        public void ThrowError()
        {
            throw new FaultException("Hey asshole");
        }
    }
}
