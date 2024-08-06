﻿using ErrorHandlingDemo.Exceptions;
using ErrorHandlingDemo.Model;
using LanguageExt.Common;
using System.ComponentModel.DataAnnotations;

namespace ErrorHandlingDemo.Services
{
    public class PostService(ILogger<PostService> logger)
    {
        private readonly ILogger<PostService> _logger = logger;
        public Result<Post> Create(Post post)
        {
            if (post == null)
            {
                throw new CustomException("Post Not found", 404);
            }
            post.Id = Guid.NewGuid().ToString();
            _logger.LogInformation(post.Content);

            return Validate(post);

            //return post;
        }

        public Result<Post> Update(Post post)
        {
            return new Result<Post>(new NotImplementedException())
        }

        private void ValidatePostAndThrow(Post post)
        {
            var isValid = false;

            if (!isValid)
            {
                throw new ValidationException("Invalid post");
            }
        }

        private Result<Post> Validate(Post post)
        {
            var isValid = false;
            if (!isValid)
            {
                return new Result<Post>(new ValidationException("Invalid post"));
            }
            return new Result<Post>(post);
        }
    }

}
