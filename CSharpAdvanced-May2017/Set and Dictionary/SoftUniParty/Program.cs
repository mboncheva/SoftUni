using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var startComming = Console.ReadLine();
            var vip = new SortedSet<string>();
            var regular = new SortedSet<string>();

            while (startComming != "PARTY")
            {
                int num;
                if (int.TryParse(startComming[0].ToString(),out num))
                {
                    vip.Add(startComming);
                }
                else
                {
                    regular.Add(startComming);
                }
                startComming = Console.ReadLine();
            }

            var endComming = Console.ReadLine();
            while (endComming != "END")
            {
                if (vip.Contains(endComming))
                {
                    vip.Remove(endComming);
                }
                else if (regular.Contains(endComming))
                {
                    regular.Remove(endComming);
                }

                endComming = Console.ReadLine();
            }

            var guestCount = vip.Count + regular.Count;
            Console.WriteLine(guestCount);
            foreach (var vipGuests in vip)
            {
                Console.WriteLine(vipGuests);
            }
            foreach (var regularGuests in regular)
            {
                Console.WriteLine(regularGuests);
            }
        }
    }
}
