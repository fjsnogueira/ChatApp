using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TeamOfOne
{
    public class PostsController : Controller
    {
        private IPostRepository _postRepository { get; set; }

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public List<Post> GetPosts()
        {
            return _postRepository.GetAll();
        }

        [HttpGet]
        public Post GetPost(int id)
        {
            return _postRepository.GetPost(id);
        }

        [HttpPost]
        public void AddPost(Post post)
        {
            _postRepository.AddPost(post);
        }
    }
}
