using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumptionFor1km;
    private double distanceTraveled;

    private List<Car> listCar = new List<Car>();

    public string Model { get { return this.model; } set { this.model = value; } }
    public double FuelAmount { get { return this.fuelAmount; } set { this.fuelAmount = value; } }
    public double FuelConsumptionFor1km { get { return this.fuelConsumptionFor1km; } set { this.fuelConsumptionFor1km = value; } }
    public double DistanceTraveled { get { return this.distanceTraveled; } set { this.distanceTraveled = value; } }

    public List<Car> ListCar { get { return this.listCar; } set { this.listCar = value; } }

    public void GetCar(Car car)
    {
        this.listCar.Add(car);
    }

    public void CalculateFuel(string model,double distance)
    {
        var currentCar = listCar.Where(x => x.Model == model).ToList()[0];

        var maxDistance = currentCar.FuelAmount / currentCar.FuelConsumptionFor1km;
        var usedFuel = currentCar.FuelConsumptionFor1km * distance;

        if (maxDistance >= distance)
        {
            currentCar.FuelAmount -= usedFuel;
            currentCar.DistanceTraveled += distance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}