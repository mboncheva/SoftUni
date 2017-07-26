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

        var cars = new Car();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(' ');
            var model = input[0];
            var fuelAmount = double.Parse(input[1]);
            var fuelFor1km = double.Parse(input[2]);

            var car = new Car
            {
                Model = model,
                FuelAmount = fuelAmount,
                FuelConsumptionFor1km = fuelFor1km
            };

            cars.GetCar(car);
        
        }

        var command = Console.ReadLine();
        while (command != "End")
        {
            var currentCommand = command.Split(' ');

            var model = currentCommand[1];
            var distance = double.Parse(currentCommand[2]);

            cars.CalculateFuel(model, distance);
            command = Console.ReadLine();
        }

        foreach (var item in cars.ListCar)
        {
            Console.WriteLine($"{item.Model} {item.FuelAmount:f2} {item.DistanceTraveled}");
        }
    }
}
