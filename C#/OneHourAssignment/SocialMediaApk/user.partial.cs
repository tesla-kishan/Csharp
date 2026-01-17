namespace MiniSocialMedia
{
    // Extends User class using partial keyword
    public partial class User
    {
        // Returns formatted display name
        public string GetDisplayName()
        {
            return $"User: {Username} <{Email}>";
        }
    }
}