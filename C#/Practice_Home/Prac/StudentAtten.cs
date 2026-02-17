using System;
using System.Collections.Generic;
using System.Text;

class StudentAtten
{
    static void Main()
    {
        string input = "101:Present,102:Absent,103:Present,104:,105:Present,ABC:Present,106:Absent";
        Dictionary<int,bool?> dict = new Dictionary<int,bool?>();
        string [] entries = input.Split(',');
        foreach(string entry in entries)
        {
            string[] parts = entry.Split(':');
            int id;
            if (!int.TryParse(parts[0], out id))
                continue;  
            if (parts[1] == "")
                dict[id] = null;
            else if (parts[1] == "Present")
                dict[id] = true;
            else if (parts[1] == "Absent")
                dict[id] = false;
        }
        int present = 0, absent = 0, notMarked = 0;
        StringBuilder sb = new StringBuilder();
        foreach (var d in dict)
        {
            if (d.Value == true)
            {
                sb.AppendLine(d.Key + " -> Present");
                present++;
            }
            else if (d.Value == false)
            {
                sb.AppendLine(d.Key + " -> Absent");
                absent++;
            }
            else
            {
                sb.AppendLine(d.Key + " -> Not Marked");
                notMarked++;
            }
        }
        sb.AppendLine();
        sb.AppendLine("Total Present: " + present);
        sb.AppendLine("Total Absent: " + absent);
        sb.AppendLine("Not Marked: " + notMarked);

        Console.WriteLine(sb);
    }
}