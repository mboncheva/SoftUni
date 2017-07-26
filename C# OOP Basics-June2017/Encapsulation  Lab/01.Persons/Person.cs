﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;

    public string FirstName { get { return this.firstName; }  }
   
    public int Age { get { return this.age; }}

    public Person(string firstName,string lastName,int age)
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.age = age;
    }

    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} is a {this.age} years old";
    }
}
