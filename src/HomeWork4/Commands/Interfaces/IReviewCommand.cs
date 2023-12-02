using Microsoft.AspNetCore.Mvc;
using Requests.Request;

namespace Commands.Interfaces
{
    public interface IReviewCommand
    {
        IActionResult CreateReview(ReviewRequest request);
        IActionResult GetReview(Guid id);
        IActionResult GetReviews();
        IActionResult DeleteReview(Guid id);
        IActionResult UpdateReview(ReviewRequest request, Guid id);
    }
}
