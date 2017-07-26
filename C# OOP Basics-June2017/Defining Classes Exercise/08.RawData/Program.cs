using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        var listCars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(' ');
            var model = input[0];
            var engineSpeed = double.Parse(input[1]);
            var enginePower = double.Parse(input[2]);
            var cargoWeight = double.Parse(input[3]);
            var cargoType = input[4];
            var tire1Pressure = double.Parse(input[5]);
            var tire1Age = double.Parse(input[6]);
            var tire2Pressure = double.Parse(input[7]);
            var tire2Age = double.Parse(input[8]);
            var tire3Pressure = double.Parse(input[9]);
            var tire3Age = double.Parse(input[10]);
            var tire4Pressure = double.Parse(input[11]);
            var tire4Age = double.Parse(input[12]);

            Car current = new Car
                (model,
               engineSpeed, enginePower,
               cargoWeight, cargoType,
               tire1Pressure, tire1Age,
               tire2Pressure, tire2Age,
               tire3Pressure, tire3Age,
               tire4Pressure, tire4Age);

            listCars.Add(current);
        }

        var command = Console.ReadLine();
        if (command == "fragile")
        {
            var result = listCars.Where(x => x.Cargo.CargoType == command &&
              (x.Tire.Tire1Pressure < 1 ||
               x.Tire.Tire2Pressure < 1 ||
               x.Tire.Tire3Pressure < 1 ||
               x.Tire.Tire4Pressure < 1));

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Model}");
            }
        }
        else if (command == "flamable")
        {
            var result = listCars.Where(x => x.Cargo.CargoType == command && (x.Engine.EnginePower > 250));
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Model}");
            }
        }
    }
}
