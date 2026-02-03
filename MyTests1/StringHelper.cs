namespace Tests1;
public class StringHelper
{
    public string Reverse(string text)
    {
        char[] arr = text.ToCharArray();
        Array.Reverse(arr);
        return new string (arr);
    }
}