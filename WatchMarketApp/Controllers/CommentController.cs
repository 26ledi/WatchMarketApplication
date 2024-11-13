using Microsoft.AspNetCore.Mvc;
using WatchMarketApp.BusinessLogic.Dto_s;
using WatchMarketApp.BusinessLogic.Interfaces;

namespace WatchMarketApp.Controllers
{
    [ApiController]
    [Route("watchmarket")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("comments")]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentService.GetAllAsync();

            return Ok(comments);
        }

        [HttpPost("comments")]
        public async Task<IActionResult> Add([FromBody] CommentDto commentModel)
        {
            var comment = await _commentService.CreateAsync(commentModel);

            return Ok(comment);
        }

        [HttpPut("comment")]
        public async Task<IActionResult> Update([FromBody] CommentDto commentModel)
        {
            var comment = await _commentService.UpdateAsync(commentModel);

            return Ok(comment);
        }

        [HttpDelete("comment")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commentService.DeleteAsync(id);

            return NoContent();
        }
    }
}
