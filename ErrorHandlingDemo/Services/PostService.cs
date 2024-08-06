using ErrorHandlingDemo.Model;
using System.ComponentModel.DataAnnotations;
using LanguageExt.Common;

namespace ErrorHandlingDemo.Services
{
    public class PostService(ILogger<PostService> logger)
    {
        private readonly ILogger<PostService> _logger = logger;
        public Post Create(Post post)
        {
            post.Id = Guid.NewGuid().ToString();
            _logger.LogInformation(post.Content);

            ValidatePostAndThrow(post);

            return post;
        }

        public Post Update(Post post) 
        {
            throw new NotImplementedException();
        }

        private void ValidatePostAndThrow(Post post)
        {
            var isVaild = false;

            if (!isVaild)
            {
                throw new ValidationException("Invalid post");
            }
        }

        private Result<Post> Validate(Post post) {
            var isValid = false;
            if (!isValid)
            {
                return new Result<Post>(new ValidationException("Invalid post"));
            }
            return new Result<Post>(post);
        }
    }

}
