using System.Collections.Generic;
using System.Linq;

namespace TeamOfOne
{
    public class PostRepository : IPostRepository
    {
        private List<Post> _posts = new List<Post>()
        {
            new Post(1, "Obi-Wan Kenobi","These are not the droids you're looking for"),
            new Post(2, "Darth Vader","I find your lack of faith disturbing")
        };
        public void AddPost(Post post)
        {
            _posts.Add(post);
        }

        public List<Post> GetAll()
        {
            return _posts;
        }

        public Post GetPost(int id)
        {
            return _posts.FirstOrDefault(p => p.Id == id);
        }
    }
}