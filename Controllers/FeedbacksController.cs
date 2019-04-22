using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeedStorm.Core;
using SeedStorm.Core.Dtos;
using SeedStorm.Core.Entities;

namespace core_api.Controllers
{
    [Authorize]
    [Route("api/feedbacks")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DatabaseContext _context;

        public FeedbacksController(DatabaseContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Post a new feedback
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Feedback>> PostFeedback([FromBody] FeedbackDto feedbackDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user =  await _userManager.FindByIdAsync(userId);
            var feedback = new Feedback
            {
                Content = feedbackDto.Content,
                PostDateTime = DateTime.Now,
                RemoteIp = HttpContext.Connection.RemoteIpAddress.ToString(),
                Username = user.UserName
            };
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return Ok(feedback);
        }
    }
}
