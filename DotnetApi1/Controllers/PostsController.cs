using DotnetApi1.Models;
using DotnetApi1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace DotnetApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostService _postService;
        private IConfiguration _configs;
        public PostsController(IConfiguration configuration) { 
            _postService = new PostService();
            _configs = configuration;
        }
        [HttpGet]
        [Route("GetAllPosts")]
        public async Task<ActionResult> GetPost()
        {
            var post = await _postService.GetAllPosts();
            return Ok(post);
        }
        
        
        [HttpGet]
        [Route("GetPostById/{id}")]
        public async Task<ActionResult<Post>> GetPostById(int id) {
            Post post = await _postService.GetPost(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }
        
        
        [HttpPut]
        [Route("CreatePost")]
        public ActionResult CreatePost(Post post)
        {
            _postService.CreatePost(post);
            return CreatedAtAction(nameof(GetPost), new {id = post.Id}, post);
        }
        [HttpGet]
        [Route("my-key")]
        public ActionResult GetMyKey()
        {
            var myKey = _configs["Tutor"];
            return Ok(myKey);
        }



    }
}
