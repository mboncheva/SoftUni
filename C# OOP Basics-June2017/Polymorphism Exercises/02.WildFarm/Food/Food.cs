﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Food
{
    private int quantity;

    public int Quantity { get { return this.quantity; } set { this.quantity = value; } }

    public Food(int quantity)
    {
        this.Quantity = quantity;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}