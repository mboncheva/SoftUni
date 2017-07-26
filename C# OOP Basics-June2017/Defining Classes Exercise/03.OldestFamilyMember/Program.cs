using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

class Program
    {
        static void Main(string[] args)
        {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
}

        var family = new Family();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(' ');
            string name = input[0];
            var age = int.Parse(input[1]);

            var person = new Person();
            person.Name = name;
            person.Age = age;

            family.AddMember(person);
        }

        var oldes = family.GetOldestMember();
        Console.WriteLine($"{oldes.Name} {oldes.Age}");
    }
}
