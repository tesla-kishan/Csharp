//ipostable
using System.Collections.Generic;
namespace MiniSocialMedia
{
    //interface defining posting capability
    public interface IPostable
    {
        //method to add a new post
        void AddPost(string content);

        //method to retreive post in read only form
        IReadOnlyList<Post> GetPosts();
    }
}