using System;

namespace MiniSocialMedia
{
    // Custom exception used for business rule violations
    // Example: invalid email, self-follow, long post, etc.
    public class SocialException : Exception
    {
        // Constructor that accepts only a custom error message
        public SocialException(string message)
            : base(message)
        {
        }

        // Constructor that accepts a message and an inner exception
        // Used when wrapping lower-level exceptions
        public SocialException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}