using System.Text;
StringBuilder sb = new StringBuilder();
// sb.Append("hello");
// sb.Append(" ");
// sb.Append("World");
// Console.WriteLine(sb.ToString());

sb.Append("Text");
sb.AppendLine("Line");
// Console.WriteLine(sb.ToString());


sb.Insert(0,"Start");
// Console.WriteLine(sb.ToString());


// sb.Remove(0,5);
sb.Append("Old");
sb.Replace("Old","New");
// Console.WriteLine(sb.ToString());
sb.Clear();
Console.WriteLine(sb.ToString());



// for(int i=0 ; i<10000 ; i++)
// {
//     sb.Append(i);
// }

// string result = sb.ToString();
// Console.WriteLine(GC.GetTotalMemory(true));
// Console.WriteLine(result);

StringBuilder sb1 = new StringBuilder("Hello");
StringBuilder sb2 = new StringBuilder("Hello");
Console.WriteLine(sb1.Equals(sb2));
Console.WriteLine(Object.ReferenceEquals(sb1,sb2));
StringBuilder sb3 = sb2;
Console.WriteLine(sb3.Equals(sb2));

Console.WriteLine(sb1 == sb2);      // False (reference check)
Console.WriteLine(sb3 == sb2);

