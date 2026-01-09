using System;
using System.IO;

class Program
{
    static void Main()
    {
        // string path = "data.txt";
        // File.WriteAllText(path, "File I/O Example in C#");

        // Console.WriteLine("Data written to file.");



        // string content = File.ReadAllText("data.txt");

        // Console.WriteLine("File Content:");
        // Console.WriteLine(content);



        // using (StreamWriter writer = new StreamWriter("log.txt"))
        // {
        //     writer.WriteLine("Application Started");
        //     writer.WriteLine("Processing Data");
        //     writer.WriteLine("Application Ended");
        // }

        // using (StreamReader reader = new StreamReader("log.txt"))
        // {
        //     string line;
        //     while ((line = reader.ReadLine()) != null) // null check
        //     {
        //         Console.WriteLine(line);
        //     }
        // }



        // User user = new User { Id = 1, Name = "Alice" };

        // using (StreamWriter writer = new StreamWriter("user.txt"))
        // {
        //     writer.WriteLine(user.Id);
        //     writer.WriteLine(user.Name);

        //     user.Id = 2;
        //     user.Name = "Bob";

        //     writer.WriteLine(user.Id);
        //     writer.WriteLine(user.Name);
        // }

        // Console.WriteLine("User data saved.");




        // User user = new User();

        // using (StreamReader reader = new StreamReader("user.txt"))
        // {
        //     user.Id = int.Parse(reader.ReadLine()); // 1
        //     user.Name = reader.ReadLine();
        // }

        // Console.WriteLine($"User Loaded: {user.Id}, {user.Name}");


        // User user = new User { Id = 2, Name = "Bob" };

        // using (BinaryWriter writer = new BinaryWriter(File.Open("user.bin", FileMode.Create)))
        // {
        //     writer.Write(user.Id);
        //     writer.Write(user.Name);
        // }

        // Console.WriteLine("Binary user data saved.");




        // using (StreamReader reader = new StreamReader("log.txt"))
        // {
        //     string content = reader.ReadToEnd();
        //     Console.WriteLine(content);
        // }



        // Alternative: Line-by-Line Reading (Best Practice for Large Files)

        // using (StreamReader reader = new StreamReader("log.txt"))
        // {
        //     string line;
        //     while ((line = reader.ReadLine()) != null)
        //     {
        //         Console.WriteLine(line);
        //     }
        // }



        // // Writing employee data to a file
        // using (StreamWriter writer = new StreamWriter("employees.txt"))
        // {
        //     writer.WriteLine("Employee Report");
        //     writer.WriteLine("---------------");
        //     writer.WriteLine("ID: 101, Name: John, Department: IT");
        //     writer.WriteLine("ID: 102, Name: Emma, Department: HR");
        //     writer.WriteLine("ID: 103, Name: David, Department: Finance");
        // }

        // // Reading employee data from the file
        // using (StreamReader reader = new StreamReader("employees.txt"))
        // {
        //     string data = reader.ReadToEnd();
        //     Console.WriteLine(data);
        // }



        // Writing binary data
        using (BinaryWriter writer = new BinaryWriter(File.Open("data.bin", FileMode.Create)))
        {
            writer.Write(101);
            writer.Write("Binary Data");
        }

        // Reading binary data
        using (BinaryReader reader = new BinaryReader(File.Open("data.bin", FileMode.Open)))
        {
            Console.WriteLine(reader.ReadInt32());
            Console.WriteLine(reader.ReadString());
        }







    }
}

