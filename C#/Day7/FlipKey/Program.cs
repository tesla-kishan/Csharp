class Program
{
    public static void Main(string[] args)
    {
        string ans = CleanseAndInvert("Cowages");
        if (ans == "")
            Console.WriteLine("Invalid Input");
        else
            Console.WriteLine("The generated key is - " + ans);
    }
    public static string CleanseAndInvert(string input)
    {
        string str = input;
        int length = str.Length;
        if (string.IsNullOrEmpty(str) || length < 6)
        {
            return "";
        }
        foreach (char ch in str)
        {
            if (!char.IsLetter(ch)) return "";
        }
        string strLower = str.ToLower();
        string filtered = "";
        foreach (char c in strLower)
        {
            if ((int)c % 2 != 0)
            {
                filtered += c;
            }
        }
        string revString = Rev(filtered);
        char[] resultArr = revString.ToCharArray();
        for (int i = 0; i < revString.Length; i++)
        {
            if (i % 2 == 0)
            {
                resultArr[i] = char.ToUpper(resultArr[i]);
            }
        }
        return new string(resultArr);
    }
    public static string Rev(string s)
    {
        string rev = "";
        for (int i = s.Length - 1; i >= 0; i--)
        {
            rev += s[i];
        }
        return rev;
    }
}