using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.DecodeRadioFrequencies
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').ToArray();
           
            var leftWord = new StringBuilder();
            var rightWord = new StringBuilder();

            foreach (var item in numbers)
            {
                var nums = item.Split('.').ToArray();
                var left = nums[0];
                var right = nums[1];

                char leftCharacter = (char)int.Parse(left);
                char rightCharacter = (char)int.Parse(right);

                if (leftCharacter != 0)
                {
                    leftWord.Append(leftCharacter);
                }
                if (rightCharacter != 0)
                {
                    rightWord.Append(rightCharacter);
                }
            }
            string rightRes = new string(rightWord.ToString().Reverse().ToArray());
            string result = leftWord.ToString() + rightRes;
            Console.WriteLine(result);
            
            
        }
    }
}
