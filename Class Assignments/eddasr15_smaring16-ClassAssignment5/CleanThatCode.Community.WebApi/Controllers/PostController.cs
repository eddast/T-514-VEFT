using CleanThatCode.Community.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanThatCode.Community.WebApi.Controllers
{
    [Route("api/posts")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;

        public PostController(IPostService postService, ICommentService commentService)
        {
            _postService = postService;
            _commentService = commentService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllPosts([FromQuery] string titleFilter = "", [FromQuery] string authorFilter = "")
        {
            return Ok(_postService.GetAllPosts(titleFilter, authorFilter));
        }

        [HttpGet]
        [Route("{postId:int}/comments")]
        public IActionResult GetCommentsByPostId(int postId)
        {
            return Ok(_commentService.GetAllCommentByPostId(postId));
        }
    }
}