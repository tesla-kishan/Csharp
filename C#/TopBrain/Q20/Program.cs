using System;

interface IArea
{
    double GetArea();
}

abstract class Shape : IArea
{
    public abstract double GetArea();
}

class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * radius * radius;
    }
}

class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public override double GetArea()
    {
        return width * height;
    }
}

class Triangle : Shape
{
    private double baseLength;
    private double height;

    public Triangle(double baseLength, double height)
    {
        this.baseLength = baseLength;
        this.height = height;
    }

    public override double GetArea()
    {
        return 0.5 * baseLength * height;
    }
}

class Program
{
    static double TotalArea(string[] shapes)
    {
        double total = 0;

        foreach (string shape in shapes)
        {
            string[] parts = shape.Split(' ');
            Shape obj = null;

            if (parts[0] == "C")
            {
                double r = double.Parse(parts[1]);
                obj = new Circle(r);
            }
            else if (parts[0] == "R")
            {
                double w = double.Parse(parts[1]);
                double h = double.Parse(parts[2]);
                obj = new Rectangle(w, h);
            }
            else if (parts[0] == "T")
            {
                double b = double.Parse(parts[1]);
                double h = double.Parse(parts[2]);
                obj = new Triangle(b, h);
            }

            if (obj != null)
            {
                total += obj.GetArea();
            }
        }

        return Math.Round(total, 2, MidpointRounding.AwayFromZero);
    }

    static void Main()
    {
        string[] shapes =
        {
            "C 10",
            "R 5 4",
            "T 6 8"
        };

        double result = TotalArea(shapes);
        Console.WriteLine(result);
    }
}