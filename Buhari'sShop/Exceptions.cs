using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buhari_sShop
{
    internal class WrongPlanException : Exception
    {
        public WrongPlanException() { }
        public WrongPlanException(string message) : base(message) { } 
        public WrongPlanException (string message, Exception innerException) : base(message, innerException) { }
    }

    internal class InvalidCustomerNameException : Exception
    {
        public InvalidCustomerNameException() { }
        public InvalidCustomerNameException(string message) : base(message) { }
        public InvalidCustomerNameException(string message, Exception innerException) : base(message, innerException) { }
    }

    internal class InvalidAmountException : Exception
    {
        public InvalidAmountException() { }
        public InvalidAmountException(string message) : base(message) { }
        public InvalidAmountException(string message, Exception innerException) : base(message, innerException) { }
    }
}
