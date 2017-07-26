using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.NumberstoWords
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number > -100 && number < 100)
                {
                    continue;
                }
                if (number > 999)
                {
                    Console.WriteLine("too large");
                }
                else if (number < -999)
                {
                    Console.WriteLine("too small");
                }
                else
                {
                    if (number < 0)
                    {
                        var num = Letterize(Math.Abs(number));
                        var result = "minus" + " " + num;
                        Console.WriteLine(result);
                    }
                    else
                    {
                        var result = Letterize(number);
                        Console.WriteLine(result);
                    }

                }
            }
        }

        private static string Letterize(int number)
        {
            var numberWords = string.Empty;
            var condition = (number % 100) / 10 * 10;

            switch (number / 100)
            {
                case 1:
                    numberWords = "one-hundred";
                    break;
                case 2:
                    numberWords = "two-hundred";
                    break;
                case 3:
                    numberWords = "three-hundred";
                    break;
                case 4:
                    numberWords = "four-hundred";
                    break;
                case 5:
                    numberWords = "five-hundred";
                    break;
                case 6:
                    numberWords = "six-hundred";
                    break;
                case 7:
                    numberWords = "seven-hundred";
                    break;
                case 8:
                    numberWords = "eight-hundred";
                    break;
                case 9:
                    numberWords = "nine-hundred";
                    break;
            }
            switch (number % 100)
            {
                case 01: numberWords += " and one";break;
                case 02: numberWords += " and two"; break;
                case 03: numberWords += " and three"; break;
                case 04: numberWords += " and four"; break;
                case 05: numberWords += " and five"; break;
                case 06: numberWords += " and six"; break;
                case 07: numberWords += " and seven"; break;
                case 08: numberWords += " and eight"; break;
                case 09: numberWords += " and nine"; break;

            }
            if ((number % 100) < 20 && (number % 100) > 10)
            {
                switch (number % 100)
                {
                    case 11: numberWords += " and eleven"; break;
                    case 12: numberWords += " and twelve"; break;
                    case 13: numberWords += " and thirteen"; break;
                    case 14: numberWords += " and fourteen"; break;
                    case 15: numberWords += " and fifteen"; break;
                    case 16: numberWords += " and sixteen"; break;
                    case 17: numberWords += " and seventeen"; break;
                    case 18: numberWords += " and eighteen"; break;
                    case 19: numberWords += " and nineteen"; break;
                }
            }
            else if (condition != 0)
            {
                switch (condition)
                {
                    case 10: numberWords += " and ten"; break;
                    case 20: numberWords += " and twenty"; break;
                    case 30: numberWords += " and thirty"; break;
                    case 40: numberWords += " and fourty"; break;
                    case 50: numberWords += " and fifty"; break;
                    case 60: numberWords += " and sixty"; break;
                    case 70: numberWords += " and seventy"; break;
                    case 80: numberWords += " and eighty"; break;
                    case 90: numberWords += " and ninety"; break;
                }

                switch (number % 10)
                {
                    case 1: numberWords += " one"; break;
                    case 2: numberWords += " two"; break;
                    case 3: numberWords += " three"; break;
                    case 4: numberWords += " four"; break;
                    case 5: numberWords += " five"; break;
                    case 6: numberWords += " six"; break;
                    case 7: numberWords += " seven"; break;
                    case 8: numberWords += " eight"; break;
                    case 9: numberWords += " nine"; break;
                }
            }
            return numberWords;
        }
    }
}
    