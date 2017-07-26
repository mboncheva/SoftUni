using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Mammal :Animals
{
    private string livingRegion;

    public Mammal(string animalType, string animalName, double animalWeight, string animalLivingRegion) 
        : base(animalType, animalName, animalWeight, animalLivingRegion)
    {
    }

    public string LivingRegion { get { return this.livingRegion; } set { this.livingRegion = value; } }

   
    public override string ToString()
    {
        return base.ToString();
    }
}