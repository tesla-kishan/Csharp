using System.Runtime.InteropServices;
using System.Collections;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        // int [] numbers;
        // int [] numbers = new int [8];

        // int [] numbers = {1,2,3,4,5}; 
        // Array.Clear(numbers,0,numbers.Length);
        // Array.Clear(numbers,0,numbers.Length-2);
        // Array.Clear(numbers,0,2);

        // for(int i=0 ;i<numbers.Length ; i++)
        // {
        //     Console.WriteLine(numbers[i]);
        // }

        // foreach(int x in numbers)
        // {
        //     Console.WriteLine(x);
        // }

        // int [,] matrix = new int [2,3];

        // int [,] matrix =
        // {
        //     {1,2,5},
        //     {3,4,8}
        // };

        // Console.WriteLine(matrix[1,1]);


        // for(int i=0 ;i<matrix.GetLength(0) ; i++)
        // {
        //     for(int j=0 ; j<matrix.GetLength(1) ; j++)
        //     {
        //         Console.Write(matrix[i,j]+ " ");
        //     }
        //     Console.WriteLine();
        // }

        // Console.WriteLine(matrix.GetLength(0));
        // Console.WriteLine(matrix.GetLength(1));

        // int [][] jagged = new int [2][];
        // jagged[0] = new int [] {1,2};
        // jagged[1] = new int [] {3,4,5};
        // for(int i=0 ;i<jagged.Length ; i++)
        // {
        //     for(int j=0 ; j<jagged[i].Length ; j++)
        //     {
        //         Console.Write(jagged[i][j]+ " ");
        //     }
        //     Console.WriteLine();
        // }
        // Console.WriteLine(jagged[1][2]);

        // int []a = {1,2,3};
        // int []b = new int [3];

        // // Array.Copy(a,b,3);
        // Array.Copy(a,b,2);

        // for(int i=0 ;i<a.Length ; i++)
        // {
        //     Console.WriteLine(b[i]);
        // }


        // int []a = {1,2,3};
        // Array.Resize(ref a,4);
        // Array.Resiz(a,4);
        //without ref copy is passed
        // Array.Resize(ref a,1);
        // Array.Resize(ref a,3);
        // for(int i=0 ;i<a.Length ; i++)
        // {
        //     Console.WriteLine(a[i]);
        // }

    //     List<int> numbers1 = new List<int>();
    //     numbers1.Add(10);
    //     numbers1.Add(230);

    //     ArrayList list1 = new ArrayList();
    //     list1.Add("Hello");
    //     list1.Add(23);

    //     Console.WriteLine("List contents:");
    //     foreach (int num in numbers1)
    //     {
    //         Console.Write(num + " ");
    //     }
    //     Console.WriteLine();

    //     Console.WriteLine("ArrayList contents:");
    //     foreach (object item in list1)
    //     {
    //         Console.Write(item + " ");
    //     }
    //     Console.WriteLine();

    // Hashtable ht = new Hashtable();
    // ht.Add(1, "Kishan");
    // ht.Add(2, "Anurag");
    // ht.Add(3, "Aryan");
    // ht.Add(4, "Abhishek");
    // Console.WriteLine(ht[1]);


    // Stack stack = new Stack();
    // stack.Push(10);
    // stack.Push(20);
    // Console.WriteLine(stack.Pop());


    // Queue queue = new Queue();
    // queue.Enqueue(10);
    // queue.Enqueue(20);
    // Console.WriteLine(queue.Dequeue());

    //genenri - type safety , u mentioned teh datatypes - list , dict  
    // data type written , generic 

    //non generic - no type safety 

    

    // Dictionary <int , string> users = new Dictionary<int, string> ();
    // users.Add(1,"Admin");
    // users.Add(2,"User");

    // Console.WriteLine(users[1]);
    // Console.WriteLine(users[2]);

    // Console.WriteLine("Dictionary contents:");
    // foreach (KeyValuePair<int, string> kvp in users)
    // {
    //     Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
    // }
    
    
    //HashSet is unordered collection framework
    // HashSet<int> set  = new HashSet<int>();
    // set.Add(1);
    // set.Add(2);
    // set.Add(2);
    // set.Add(2);
    // set.Add(3);

    // foreach(int x in set)
     //    {Console.WriteLine(x);
    //  


    SortedList<string, string> list = new SortedList<string,string>();
    list.Add("b","B");
    list.Add("a","A");

    //in ascending
    foreach (KeyValuePair<string, string> kvp in list)
    {
        Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
    }

    // Method 1: Using Reverse() (already shown)
    Console.WriteLine("Method 1 - Using Reverse():");
    foreach (KeyValuePair<string, string> kvp in list.Reverse())
    {
        Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
    }

    // Method 2: Using LINQ OrderByDescending
    Console.WriteLine("Method 2 - Using LINQ OrderByDescending:");
    foreach (KeyValuePair<string, string> kvp in list.OrderByDescending(kvp => kvp.Key))
    {
        Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
    }

    // Method 3: Iterating Keys in reverse
    Console.WriteLine("Method 3 - Iterating Keys.Reverse():");
    foreach (string key in list.Keys.Reverse())
    {
        Console.WriteLine($"Key: {key}, Value: {list[key]}");
    }

    

    
    }


}
