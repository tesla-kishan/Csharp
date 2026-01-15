using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MiniSocialMedia
{
 
    // Task 1 : Custom Exception

    public class SocialException : Exception
    {
        public SocialException(string message) : base(message) { }
        public SocialException(string message, Exception inner) : base(message, inner) { }
    }


    // Task 2 : IPostable
   
    public interface IPostable
    {
        void AddPost(string content);
        IReadOnlyList<Post> GetPosts();
    }

  
    // Task 3 : User Class (Partial)
    
    public partial class User : IPostable, IComparable<User>
    {
        public string Username { get; init; }
        public string Email { get; init; }

        private readonly List<Post> _posts = new();
        private readonly HashSet<string> _following =
            new(StringComparer.OrdinalIgnoreCase);

        public event Action<Post>? OnNewPost;

        // Constructor
        public User(string username, string email)
        {
            // Username validation
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Invalid username", nameof(username));

            // Email validation
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email ?? "", pattern))
                throw new SocialException("Invalid email format");

            Username = username.Trim();
            Email = email.Trim().ToLower();
        }

        // Follow Method
        public void Follow(string username)
        {
            if (string.Equals(username, Username, StringComparison.OrdinalIgnoreCase))
                throw new SocialException("Cannot follow yourself");

            _following.Add(username);
        }

        // IsFollowing (Lambda style logic)
        public bool IsFollowing(string username)
        {
            return _following.Contains(username);
        }

        // AddPost
        public void AddPost(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Post content cannot be empty");

            if (content.Length > 280)
                throw new SocialException("Post too long (max 280 characters)");

            string cleaned = content.Trim();

            Post post = new Post(this, cleaned);
            _posts.Add(post);

            // Fire event safely
            OnNewPost?.Invoke(post);
        }

        // GetPosts
        public IReadOnlyList<Post> GetPosts()
        {
            return _posts.AsReadOnly();
        }

        // CompareTo
        public int CompareTo(User? other)
        {
            if (other == null) return 1;

            return string.Compare(Username, other.Username,
                StringComparison.OrdinalIgnoreCase);
        }

        // ToString
        public override string ToString()
        {
            return "@" + Username;
        }
    }


    // Task : Partial Extension

    public partial class User
    {
        public string GetDisplayName()
        {
            return $"User: {Username} <{Email}>";
        }
    }

    // Task : Post Class
    public class Post
    {
        public User Author { get; }
        public string Content { get; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;

        public Post(User author, string content)
        {
            if (author == null)
                throw new ArgumentException("Author cannot be null", nameof(author));

            Author = author;
            Content = content;
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.Append($"{Author} • {CreatedAt:MMM dd HH:mm}");
            sb.AppendLine();
            sb.Append(Content);

            // Hashtag detection
            var hashtags = Regex.Matches(Content, @"#[A-Za-z]+");
            if (hashtags.Count > 0)
            {
                sb.AppendLine();
                sb.Append("Tags: ");
                sb.AppendJoin(", ", hashtags.Cast<Match>().Select(m => m.Value));
            }

            return sb.ToString();
        }
    }

    // Task : Generic Repository
    public class Repository<T> where T : class
    {
        private readonly List<T> _items = new();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public IReadOnlyList<T> GetAll()
        {
            return _items.AsReadOnly();
        }

        public T? Find(Predicate<T> match)
        {
            return _items.Find(match);
        }
    }

    // Bonus : User Extension
    public static class UserExtensions
    {
        public static IEnumerable<string> GetFollowingNames(this User user,
            IEnumerable<User> allUsers)
        {
            return allUsers
                .Where(u => user.IsFollowing(u.Username))
                .Select(u => u.Username);
        }
    }
}