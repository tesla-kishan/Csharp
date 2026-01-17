using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MiniSocialMedia
{
    // Core User class
    public partial class User : IPostable, IComparable<User>
    {
        // Username (init-only)
        public string Username { get; init; }

        // Email (init-only)
        public string Email { get; init; }

        // Internal list of posts
        private readonly List<Post> _posts = new();

        // Stores followed usernames (case-insensitive)
        private readonly HashSet<string> _following =
            new(StringComparer.OrdinalIgnoreCase);

        // Event triggered when a new post is added
        public event Action<Post>? OnNewPost;

        // Constructor
        public User(string username, string email)
        {
            // Validate username
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Invalid username", nameof(username));

            // Validate email using regex
            if (!Regex.IsMatch(email ?? "",
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new SocialException("Invalid email format");

            // Normalize values
            Username = username.Trim();
            Email = email.Trim().ToLowerInvariant();
        }

        // Follow another user
        public void Follow(string username)
        {
            // Prevent self-follow
            if (string.Equals(Username, username,
                StringComparison.OrdinalIgnoreCase))
                throw new SocialException("Cannot follow yourself");

            // HashSet ensures no duplicates
            _following.Add(username);
        }

        // Check if user is following someone
        public bool IsFollowing(string username)
        {
            return _following.Contains(username);
        }

        // Add a new post
        public void AddPost(string content)
        {
            // Validate content
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Post content cannot be empty");

            // Validate length
            if (content.Length > 280)
                throw new SocialException("Post too long (max 280 characters)");

            // Create post
            Post post = new Post(this, content.Trim());

            // Store post
            _posts.Add(post);

            // Trigger event safely
            OnNewPost?.Invoke(post);
        }

        // Return posts as read-only list
        public IReadOnlyList<Post> GetPosts()
        {
            return _posts.AsReadOnly();
        }

        // Compare users alphabetically
        public int CompareTo(User? other)
        {
            if (other == null)
                return 1;

            return string.Compare(
                Username,
                other.Username,
                StringComparison.OrdinalIgnoreCase);
        }

        // Display user as @username
        public override string ToString()
        {
            return $"@{Username}";
        }
    }
}