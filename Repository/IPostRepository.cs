using System.Collections.Generic;

namespace TeamOfOne 
{
    public interface IPostRepository
    {
        List<Post> GetAll();
        Post GetPost(int id);
        void AddPost(Post post);
    }
}