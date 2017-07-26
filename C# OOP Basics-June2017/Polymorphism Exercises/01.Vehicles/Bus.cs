using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Bus : Vehicles
{
    public Bus(double fuelQuantity, double litersPerKm, double tankCapacity) : base(fuelQuantity, litersPerKm, tankCapacity)
    {
    }

    public override void Refuel(double quantity)
    {
        if (quantity <=0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        if (quantity > base.TankCapacity- base.FuelQuantity)
        {
            throw new ArgumentException("Cannot fit in tank");
        }
        base.FuelQuantity += quantity;

    }

    public override void TryTravelDistance(double distance)
    {
        var maxDistance = base.FuelQuantity / base.LitersPerKm;
        if (maxDistance >= distance)
        {
            Console.WriteLine($"Bus travelled {distance} km");
            base.FuelQuantity -= distance * base.LitersPerKm;
        }
        else
        {
            Console.WriteLine("Bus needs refueling");
        }
    }

    public void DriveEmpty(double distance)
    {

        var maxDistance = base.FuelQuantity / (base.LitersPerKm - 1.4);
        if (maxDistance >= distance)
        {
            Console.WriteLine($"Bus travelled {distance} km");
            base.FuelQuantity -= distance * (base.LitersPerKm - 1.4 );
        }
        else
        {
            Console.WriteLine("Bus needs refueling");
        }
    }

    public override string ToString()
    {
        return "Bus: " + base.ToString();
    }
}