class Person
{
    public string Name{get;set;}
    public string Address{get;set;}
    public int age{get;set;}
}

class PersonImplementation
{
    public string GetName(IList<Person> persons)
    {
        string str = "";
        foreach(var p in persons)
        {
            str += p.Name + " " + p.Address + " ";
        }
        return str.Trim();
    }
}