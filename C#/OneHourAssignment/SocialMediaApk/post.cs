using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MiniSocialMedia
{
    // Represents a single post
    public class Post
    {
        // Author of the post (immutable after creation)
        public User Author { get; init; }

        // Post content (immutable)
        public string Content { get; init; }

        // Time of post creation (UTC)
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

        // Constructor
        public Post(User author, string content)
        {
            // Validate author
            if (author == null)
                throw new ArgumentException(nameof(author));

            Author = author;
            Content = content;
        }

        // Returns formatted post output
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            // Line 1: Author + timestamp
            sb.AppendLine($"{Author} • {CreatedAt:MMM dd HH:mm}");

            // Line 2: Post content
            sb.AppendLine(Content);

            // Extract hashtags using regex
            var hashtags = Regex.Matches(Content, @"#[A-Za-z]+");

            // If hashtags exist, add Tags line
            if (hashtags.Count > 0)
            {
                sb.Append("Tags: ");
                sb.AppendJoin(", ", hashtags.Cast<Match>().Select(m => m.Value));
            }

            // Remove trailing newline if any
            return sb.ToString().TrimEnd();
        }
    }
}