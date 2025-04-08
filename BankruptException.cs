using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_03_25
{
    internal class BankruptException : Exception
    {
        public BankruptException(string message) : base(message) { Console.WriteLine(message); }
    }
}
