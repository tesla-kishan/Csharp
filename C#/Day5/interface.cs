interface IPrintable
{
    void Print();
//    void Scan();
//    static int count;
}

class Report : IPrintable
{
    public void Print()
    {
        Console.WriteLine("Printing report");
    }
}