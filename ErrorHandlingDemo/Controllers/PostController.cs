﻿using ErrorHandlingDemo.Contracts;
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
        public IActionResult CreatePost(PostCreateRequest postRequest)
        {
            var postResult = _postService.Create(new Post { Title = postRequest.Title, Content = postRequest.Content });

            return Ok(postResult);
        }

        [HttpPut]
        public IActionResult UpdatePost(PostCreateRequest postRequest)
        {
            var post = _postService.Update(new Post { Title = postRequest.Title, Content = postRequest.Content });
            return Ok(post);
        }
    }
}
