using System;

public class Cat : Animal
{
    public Cat(string name, string favouriteFood)
    {
        this.Name = name;
        this.FavoriteFood = favouriteFood;
    }

    public override string ExplainMyself()
    {
        return base.ExplainMyself() + Environment.NewLine + "MEEOW";
    }
}