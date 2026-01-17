using System;
namespace MiniSocialMedia
{
    //utility class
    public static class SocialUtils
    {
        //extension method for date and time
        public static string FormatTimeAgo(this DateTime time)
        {
            TimeSpan diff = DateTime.UtcNow - time;

            if (diff.TotalMinutes < 1)
                return "just now";

            if (diff.TotalMinutes < 60)
                return $"{(int)diff.TotalMinutes} min ago";

            if (diff.TotalHours < 24)
                return $"{(int)diff.TotalHours} h ago";

            // Older than 1 day
            return time.ToString("MMM dd");
        }
    }
}