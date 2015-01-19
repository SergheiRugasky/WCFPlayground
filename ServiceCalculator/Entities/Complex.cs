using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Text;

namespace Entities
{
    [DataContract]
    public class Complex
    {
        [DataMember]
        public int Real { get; set; }
        [DataMember]
        public int Imaginary { get; set; }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex
            {
                Real = a.Real + b.Real,
                Imaginary = a.Imaginary + b.Imaginary
            };
        }

        public static Complex operator -(Complex first, Complex second)
        {
            return new Complex
            {
                Real = first.Real - second.Real,
                Imaginary = first.Imaginary - second.Imaginary
            };
        }

        public static Complex operator *(Complex first, Complex second)
        {
            return new Complex
            {
                Real = first.Real*second.Real - first.Imaginary*second.Imaginary,
                Imaginary = first.Real*second.Imaginary + first.Imaginary*second.Real
            };
        }

        public override string ToString()
        {
            return Real + "+" + Imaginary + "i";
        }
    }
}
