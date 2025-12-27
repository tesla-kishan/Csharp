using System;
using System.Collections.Generic;
class Program
{
    public static  void Main(string [] args)
    {
        Console.WriteLine("Enter the number of products");
        int n = Convert.ToInt32(Console.ReadLine());
        int [] arr = new int [n];
        for(int i=0 ; i<n ; i++)
        {
            while(true){
                Console.WriteLine($"Enter the number :- {i+1}");
                int number = Convert.ToInt32(Console.ReadLine());
                if(number > 0)
                {
                    arr[i] = number;
                    break;
                }
                else
                {
                    Console.WriteLine("Please Enter only Positive number");
                }
                }
        }
        int sum=0;
        foreach(int x in arr)
        {
            sum += x;
        }
        double averagePrice = (double)sum/n;
        System.Array.Sort(arr);
        for(int i=0 ; i<n ; i++)
        {
            if (arr[i] < averagePrice)
            {
                arr[i]=0;
            }
        }
        int[] arr1 = new int[n+5];
        int nn = arr1.Length;
        for(int i=0 ;i<n ; i++)
        {
            arr1[i] = arr[i];
        }
        for(int i=n ; i<nn ; i++)
        {
            arr1[i] = (int)averagePrice;
        }
        for(int i=0 ; i<nn ; i++)
        {
            Console.WriteLine("Position " + (i+1) + "=" + arr1[i]);
        }


        Console.WriteLine("Enter the number of Branches");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the number of Months");
        int m = Convert.ToInt32(Console.ReadLine());
        int [,] mat = new int [b,m];
        int maxsale= int.MinValue;
        for(int i=0 ; i<b ; i++)
        {
            int branchTotal = 0;
            for(int j=0 ; j<m ; j++)
            {
                Console.WriteLine($"Enter sales for Branch {i + 1}, Month {j + 1}");
                mat[i,j] = Convert.ToInt32(Console.ReadLine());
                branchTotal += mat[i,j];
                maxsale = Math.Max(mat[i,j], maxsale);
            } 
            Console.WriteLine("Total sales of Branch " + (i + 1) + " = " + branchTotal);
        }
        Console.WriteLine("Highest Monthly Sale = " + maxsale);

        int [][] jagged = new int [b][];
        for (int i = 0; i < b; i++)
        {
            List<int> temp = new List<int>();

            for (int j = 0; j < m; j++)
            {
                if (mat[i, j] >= averagePrice)
                {
                    temp.Add(mat[i, j]);
                }
            }
            jagged[i] = temp.ToArray();
        }
        for (int i = 0; i < jagged.Length; i++)
        {
            Console.Write("Branch " + (i + 1) + ": ");

            foreach (int val in jagged[i])
            {
                Console.Write(val + " ");
            }

            Console.WriteLine();
            
        }
        Console.WriteLine("Number of Customer Transaction");
        int t = Convert.ToInt32(Console.ReadLine());
        List<int> customers = new List<int>();
        for (int i = 0; i < t; i++)
        {
            Console.Write("Enter customer ID: ");
            customers.Add(Convert.ToInt32(Console.ReadLine()));
        }
        HashSet<int> uniqueCustomers = new HashSetr<int>(customers);
        List<int> cleanedCustomers = new List<int>(uniqueCustomers);
        Console.WriteLine("Cleaned Customer List:");
        foreach (int id in cleanedCustomers)
        {
            Console.Write(id + " ");
        }
        Console.WriteLine("\nDuplicates Removed = " + (customers.Count - cleanedCustomers.Count));

        Console.Write("Enter number of transactions: ");
        int ft = Convert.ToInt32(Console.ReadLine());
        Dictionary<int, double> transactions = new Dictionary<int, double>();
        for (int i = 0; i < ft; i++)
        {
            Console.Write("Enter transaction ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (transactions.ContainsKey(id))
            {
                Console.WriteLine("Duplicate transaction ID not allowed.");
                i--;
                continue;
            }

            Console.Write("Enter transaction amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());
            transactions.Add(id, amount);
        }
        SortedList<int, double> highValueTransactions = new SortedList<int, double>();
        foreach (var item in transactions)
        {
            if (item.Value >= averagePrice)
            {
                highValueTransactions.Add(item.Key, item.Value);
            }
        }
        Console.WriteLine("High Value Transactions (Sorted):");
        foreach (var item in highValueTransactions)
        {
            Console.WriteLine(item.Key + " -> " + item.Value);
        }

        Console.Write("Enter number of operations: ");
        int ops = Convert.ToInt32(Console.ReadLine());

        Queue<string> processQueue = new Queue<string>();
        Stack<string> undoStack = new Stack<string>();

        for (int i = 0; i < ops; i++)
        {
            Console.Write("Enter operation: ");
            string op = Console.ReadLine();
            processQueue.Enqueue(op);
            undoStack.Push(op);
        }

        Console.WriteLine("Processing Operations (Queue):");
        while (processQueue.Count > 0)
        {
            Console.WriteLine(processQueue.Dequeue());
        }

        Console.WriteLine("Undo Last Two Operations:");
        if (undoStack.Count > 0) Console.WriteLine(undoStack.Pop());
        if (undoStack.Count > 0) Console.WriteLine(undoStack.Pop());

        Console.Write("Enter number of users: ");
        int u = Convert.ToInt32(Console.ReadLine());

        Hashtable userRoles = new Hashtable();
        ArrayList legacyList = new ArrayList();

        for (int i = 0; i < u; i++)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter role: ");
            string role = Console.ReadLine();

            userRoles[username] = role;
            legacyList.Add(username);
            legacyList.Add(role);
        }

        Console.WriteLine("Hashtable Data:");
        foreach (DictionaryEntry entry in userRoles)
        {
            Console.WriteLine(entry.Key + " -> " + entry.Value);
        }

        Console.WriteLine("ArrayList Data (Mixed Types):");
        foreach (object obj in legacyList)
        {
            Console.WriteLine(obj);
        }
    }
}
