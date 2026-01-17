using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace MiniSocialMedia
{
    class Program
    {
        //stores all users
        private static readonly Repository<User> _users=new();

        // Currently logged-in user
        private static User? _currentUser;

        // Data file for persistence
        private static readonly string _dataFile="socialdata.json";

        static void Main()
        {
            Console.Title="MiniSocial";
            LoadData();

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("=== MiniSocial ===");

                    if(_currentUser==null)
                       ShowLoginMenu();

                    else
                       ShowMainMenu();
                }

                catch (SocialException ex)
                {
                    ConsoleColorWrite("Unexpected error occurred: ",ConsoleColor.Red);
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        static void ShowLoginMenu()
        {
            Console.WriteLine("\n1. Register\n2. Login\n3. Exit");
            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1": Register(); break;
                case "2": Login(); break;
                case "3": SaveData(); Environment.Exit(0); break;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }

        static void Register()
        {
            Console.Write("username: ");
            string username=Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            if (_users.Find(u => u.Username.Equals(username,
                StringComparison.OrdinalIgnoreCase)) != null)
            {
                Console.WriteLine("User already exists");
                return;
            }

            User user = new User(username, email);
            _users.Add(user);

            Console.WriteLine("Registration successful!");
        }

        static void Login()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine()!;

            var user = _users.Find(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (user == null)
            {
                Console.WriteLine("User not found");
                return;
            }
            _currentUser = user;
            Console.WriteLine("Login successful");
        }

        static void ShowMainMenu(){
            Console.WriteLine($"\nLogged in as {_currentUser}");
            Console.WriteLine("1. Post\n2. My Posts\n3. Logout\n4. Exit");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1": PostMessage(); break;
                case "2": ShowPosts(_currentUser!.GetPosts()); break;
                case "3": _currentUser = null; break;
                case "4": SaveData(); Environment.Exit(0); break;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }

        static void PostMessage(){
            Console.Write("Post: ");
            string content = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(content))
                return;

            _currentUser!.AddPost(content);
            Console.WriteLine("Post added!");
        }

        static void ShowPosts(System.Collections.Generic.IReadOnlyList<Post> posts)
        {
            if (!posts.Any())
            {
                Console.WriteLine("No posts");
                return;
            }

            foreach (var post in posts)
            {
                Console.WriteLine(post);
                Console.WriteLine($"({post.CreatedAt.FormatTimeAgo()})");
                Console.WriteLine("----------------------");
            }
        }

        static void SaveData()
        {
            try
            {
                var json = JsonSerializer.Serialize(_users.GetAll());
                File.WriteAllText(_dataFile, json);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        static void LoadData()
        {
            try
            {
                if (!File.Exists(_dataFile)) return;
                // Simplified loading for assignment scope
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        static void LogError(Exception ex)
        {
            File.AppendAllText("error.log",
                $"{DateTime.Now}\n{ex}\n\n");
        }

        static void ConsoleColorWrite(string message, ConsoleColor color)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = old;
        }
    }
}

// MiniSocialMedia
// │
// ├── SocialException.cs
// ├── IPostable.cs
// ├── Post.cs
// ├── User.cs
// ├── User.Partial.cs
// ├── Repository.cs
// ├── SocialUtils.cs
// ├── UserExtensions.cs
// └── Program.cs