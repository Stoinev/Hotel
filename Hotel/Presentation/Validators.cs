using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Presentation
{
    public static class Validators
    {
        public static bool IsStringNoValid(string str)
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }

        public static bool IsIntNoValid(int number)
        {
            return int.IsNegative(number) || number == 0;
        }

        public static bool IsDoubleNoValid(double number)
        {
            return double.IsNegative(number) || number == 0;
        }
    }
}
