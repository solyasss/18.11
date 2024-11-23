using System;
using System.Runtime.Serialization;

[Serializable]
public class Student : Person
{
    protected double average;
    protected int number_of_group;

    public double Average
    {
        get { return average; }
        set
        {
            if (value < 0 || value > 10)
                throw new ArgumentException("Your average must be from 0 to 10");
            average = value;
        }
    }
    public int Number_Of_Group
    {
        get { return number_of_group; }
        set { number_of_group = value; }
    }
    public Student() { }
    public Student(string name, string surname, int age, string phone, double average, int number_of_group)
        : base(name, surname, age, phone)
    {
        Average = average;
        Number_Of_Group = number_of_group;
    }
    public override void print()
    {
        base.print();
        Console.WriteLine($"Average:        {Average}");
        Console.WriteLine($"Group Number:   {Number_Of_Group}");
        Console.WriteLine("------------------------------");
    }
}