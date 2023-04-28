using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Data;
using ToDoAPI.Services.Interfaces;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("get/{CandidateId}")]
        public async Task<ActionResult<IEnumerable<Commentinfo>>> GetCandidatesByCondition(int CandidateId)
        {
            return await _commentService.GetCandidateCondition(CandidateId);
        }

        [HttpPost]
        public async Task<ActionResult<Commentinfo>> CreateComment([FromBody] Commentinfo contract)
        {
            return await _commentService.CreateComment(contract);
        }

    }
}
