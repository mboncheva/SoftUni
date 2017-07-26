using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Vehicles
{
    private double fuelQuantity;
    private double litersPerKm;

    public double FuelQuantity { get { return this.fuelQuantity; } set { this.fuelQuantity = value; } }
    public double LitersPerKm { get { return this.litersPerKm; } set { this.litersPerKm = value; } }

    public Vehicles(double fuelQuantity, double litersPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.LitersPerKm = litersPerKm;
    }

    public abstract void TryTravelDistance(double distance);
    public abstract void Refuel(double quantity);

    public override string ToString()
    {
        return $"{this.FuelQuantity:f2}";
    }
}
