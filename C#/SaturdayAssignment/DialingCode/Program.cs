namespace DialingCodesApp;
class Program
{
    public static void Main(string[]args)
    {
        // Task 1: Create Empty Dictionary
        Dictionary<int, string> emptyDict = DialingCodes.GetEmptyDictionary();
        Console.WriteLine("Empty Dictionary Count: " + emptyDict.Count);
        Console.WriteLine();

        // Task 2: Existing Dictionary
        Dictionary<int, string> existingDict = DialingCodes.GetExistingDictionary();
        Console.WriteLine("Existing Dictionary:");
        DialingCodes.PrintDictionary(existingDict);
        Console.WriteLine();

        // Task 3: Add Country to Empty Dictionary
        Dictionary<int, string> singleEntryDict =
            DialingCodes.AddCountryToEmptyDictionary(81, "Japan");
        Console.WriteLine("Single Entry Dictionary:");
        DialingCodes.PrintDictionary(singleEntryDict);
        Console.WriteLine();

        // Task 4: Add Country to Existing Dictionary
        DialingCodes.AddCountryToExistingDictionary(existingDict, 44, "United Kingdom");
        Console.WriteLine("After Adding United Kingdom:");
        DialingCodes.PrintDictionary(existingDict);
        Console.WriteLine();

        // Task 5: Retrieve Country Name
        string country = DialingCodes.GetCountryNameFromDictionary(existingDict, 91);
        Console.WriteLine("Country with code 91: " + country);
        Console.WriteLine();

        // Task 6: Check If Code Exists
        bool exists = DialingCodes.CheckCodeExists(existingDict, 55);
        Console.WriteLine("Does code 55 exist? " + exists);
        Console.WriteLine();

        // Task 7: Update Brazil Name
        DialingCodes.UpdateDictionary(existingDict, 55, "Federative Republic of Brazil");
        Console.WriteLine("After Updating Brazil:");
        DialingCodes.PrintDictionary(existingDict);
        Console.WriteLine();

        // Task 8: Remove USA
        DialingCodes.RemoveCountryFromDictionary(existingDict, 1);
        Console.WriteLine("After Removing USA:");
        DialingCodes.PrintDictionary(existingDict);
        Console.WriteLine();

        // Task 9: Find Longest Country Name
        string longestName = DialingCodes.FindLongestCountryName(existingDict);
        Console.WriteLine("Longest Country Name: " + longestName);
    }
}