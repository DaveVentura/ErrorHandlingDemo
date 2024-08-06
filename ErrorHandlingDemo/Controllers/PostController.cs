using ErrorHandlingDemo.Contracts;
using ErrorHandlingDemo.Extensions;
using ErrorHandlingDemo.Model;
using ErrorHandlingDemo.Services;
using Microsoft.AspNetCore.Mvc;

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

            return postResult.ToResultResponse(p => { return p; });
        }

        [HttpPut]
        public IActionResult UpdatePost(PostRequest postRequest)
        {
            var post = _postService.Update(new Post { Title = postRequest.Title, Content = postRequest.Content });
            return Ok(post);
        }
    }
}
