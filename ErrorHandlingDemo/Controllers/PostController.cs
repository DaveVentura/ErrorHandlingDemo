using ErrorHandlingDemo.Contracts;
using ErrorHandlingDemo.Model;
using ErrorHandlingDemo.Services;
using ErrorHandlingDemo.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ErrorHandlingDemo.Controllers
{
    [ApiController]
    [Route("posts")]
    public class PostController(PostService postService) : ControllerBase
    {
        private readonly PostService _postService = postService;
        [HttpPost]
        public IActionResult CreatePost(PostRequest postRequest)
        {
            var postResult = _postService.Create(new Post { Title = postRequest.Title, Content = postRequest.Content });
            return Ok(postResult);
        }

        [HttpPut]
        public IActionResult UpdatePost(PostRequest postRequest)
        {
            var post = _postService.Update(new Post { Title = postRequest.Title, Content = postRequest.Content });
            return Ok(post);
        }
    }
}
