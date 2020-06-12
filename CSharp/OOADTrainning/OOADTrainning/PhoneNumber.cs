using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADTrainning
{
    public class PhoneNumber
    {
        public string AreaCode { get; set; }
        public string PhoneCode { get; set; }

        public string InternationalCode { get; set; }

        private string UnformattedPhoneNumber { get; set; }

        public PhoneNumber(string unformattedPhoneNumber)
        {
            UnformattedPhoneNumber = unformattedPhoneNumber;
            if (unformattedPhoneNumber.Length != 11 && unformattedPhoneNumber.Length != 13)
            {
                throw new ArgumentException("Not Valid PhoneNumber");
            }


            if (unformattedPhoneNumber.Length == 11)
            {
                ParsePhoneNumberWithoutInternationalCode(unformattedPhoneNumber);
            }

            if (unformattedPhoneNumber.Length == 13)
            {
                ParsePhoneNumberWithInternationalCode(unformattedPhoneNumber);
            }
                    

        }

        private void ParsePhoneNumberWithInternationalCode(string unformattedPhoneNumber)
        {
            InternationalCode = unformattedPhoneNumber.Substring(0, 2);
            AreaCode = unformattedPhoneNumber.Substring(2, 3);
            PhoneCode = unformattedPhoneNumber.Substring(5, 8);
        }

        private void ParsePhoneNumberWithoutInternationalCode(string unformattedPhoneNumber)
        {
            InternationalCode = "";
            AreaCode = unformattedPhoneNumber.Substring(0, 3);
            PhoneCode = unformattedPhoneNumber.Substring(3, 8);
        }

        public string ToFormattedPhoneNumber()
        {
            if (InternationalCode == "")
            {
                return $"{AreaCode}-{PhoneCode}";
            }
            return $"{InternationalCode}-{AreaCode}-{PhoneCode}";
        }

        //public void SetPrintMethod(Action printMethod)
        //{
        //    _printPhoneNumber = printMethod;
        //}

        //public void PrintPhoneNumber()
        //{
        //    _printPhoneNumber(this);
        //}


        
    }

    public class PhoneNumberPrinter
    {

        private Action<PhoneNumber> _printMethod;

        private static void _consolePrint(PhoneNumber number)
        {
            Console.WriteLine(number.ToFormattedPhoneNumber());
        }

        public PhoneNumberPrinter() : this(_consolePrint) { }
        
      
        public PhoneNumberPrinter(Action<PhoneNumber> printMethod)
        {
            _printMethod = printMethod;
        }

        public void Print(PhoneNumber number)
        {
            _printMethod(number);
        }






    }
}
