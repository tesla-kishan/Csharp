
class Cons
{
    int id;
    public Cons(int id)
    {
        this.id = id;
        Console.WriteLine($"value of id is {id}");
    }
}


class Parent
{
    public Parent(int x)
    {
        Console.WriteLine("Parent constructor: " + x);
    }
}

class Child : Parent
{
    public Child() : base(10)
    {
        Console.WriteLine("Child constructor");
    }
}


class Product
{
    public string? Name;
    public int Price;

    public Product() {Console.WriteLine("k"); }

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
        Console.WriteLine("l");
    }
}