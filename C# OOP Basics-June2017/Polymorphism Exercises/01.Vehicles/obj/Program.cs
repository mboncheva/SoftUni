using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Program
{
    public static void Main(string[] args)
    {
        var firstLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var secondLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var car = new Car(double.Parse(firstLine[1]), double.Parse(firstLine[2]) + 0.9);
        var truck = new Truck(double.Parse(secondLine[1]), double.Parse(secondLine[2]) + 1.6);

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string command = input[0];
            string typeVehicle = input[1];
            double distanceOrLiters = double.Parse(input[2]);


            switch (command)
            {
                case "Drive":
                    if (typeVehicle == "Car")
                    {
                        car.TryTravelDistance(distanceOrLiters);
                    }
                    else if (typeVehicle == "Truck")
                    {
                        truck.TryTravelDistance(distanceOrLiters);
                    }

                    break;

                case "Refuel":
                    if (typeVehicle == "Car")
                    {
                        car.Refuel(distanceOrLiters);
                    }
                    else if (typeVehicle == "Truck")
                    {
                        truck.Refuel(distanceOrLiters);
                    }

                    break;

                default: break;
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
    }
}
