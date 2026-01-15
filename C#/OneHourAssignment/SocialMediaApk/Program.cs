using System;
using MiniSocialMedia;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== MiniSocial Console ===");

        Repository<User> users = new();

        // Simple demo flow
        try
        {
            // Register users
            User aman = new User("Aman", "aman@mail.com");
            User rahul = new User("Rahul", "rahul@mail.com");

            users.Add(aman);
            users.Add(rahul);

            // Subscribe to post event
            aman.OnNewPost += post =>
            {
                Console.WriteLine("\n[Notification] New post created:");
                Console.WriteLine(post);
            };

            // Follow test
            rahul.Follow("Aman");

            // Create post
            aman.AddPost("Learning C# is fun #dotnet #coding");

            // Display timeline for Rahul
            Console.WriteLine("\n=== Rahul's Timeline ===");
            foreach (var u in users.GetAll())
            {
                if (rahul.IsFollowing(u.Username))
                {
                    foreach (var p in u.GetPosts())
                        Console.WriteLine(p + "\n");
                }
            }
        }
        catch (SocialException ex)
        {
            Console.WriteLine("Social Error: " + ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Argument Error: " + ex.Message);
        }

        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }
}