using Commands.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Requests.Request;

namespace Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewCommand _reviewCommand;

        public ReviewController(IReviewCommand command)
        {
            _reviewCommand = command;
        }

        [HttpPost]
        public IActionResult Create(
        [FromBody] ReviewRequest request)
        {
            return _reviewCommand.CreateReview(request);
        }

        [HttpGet]
        public IActionResult Get(
        [FromQuery] Guid id)
        {
            return _reviewCommand.GetReview(id);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return _reviewCommand.GetReviews();
        }

        [HttpDelete]
        public IActionResult Delete(
        [FromQuery] Guid id)
        {
            return _reviewCommand.DeleteReview(id);
        }

        [HttpPut]
        public IActionResult Update(
        [FromQuery] Guid id,
        [FromBody] ReviewRequest request)
        {
            return _reviewCommand.UpdateReview(request, id);
        }
    }
}
