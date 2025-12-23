using System;
class Library
{
    private Dictionary<int, string> books = new Dictionary<int, string>();
    public string this[int id]
    {
        get
        {
            return books[id];
        }
        set
        {
            books[id]=value;
        }
    }
        public string this[String name]
        {
            get
            {
                return books.FirstOrDefault(e => e.Value == name).Value;
            }
        }
}
