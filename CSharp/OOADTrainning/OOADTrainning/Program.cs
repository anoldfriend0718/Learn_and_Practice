using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADTrainning
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = new PhoneNumber("8601012345678");
            var printer = new PhoneNumberPrinter();
            printer.Print(number);
            Console.ReadKey();
        }
    }
}
