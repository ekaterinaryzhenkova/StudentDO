using Commands.Interfaces;
using Data.Mappers.Interfaces;
using Data.Repositories.Interfaces;
using Data.Validators.Interfaces;
using DbModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Requests.Request;

namespace CLient
{
    public class ReviewCommand: IReviewCommand
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IReviewMapper _reviewMapper;
        private readonly IReviewRequestValidator _reviewRequestValidator;

        public ReviewCommand(
            IReviewRepository reviewRepository,
            IReviewMapper reviewMapper,
            IReviewRequestValidator reviewRequestValidator)
        {
            _reviewRepository = reviewRepository;
            _reviewMapper = reviewMapper;
            _reviewRequestValidator = reviewRequestValidator;
        }

        public IActionResult CreateReview(ReviewRequest request)
        {
            ValidationResult validationResult = _reviewRequestValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors);
            }

            DbReview review = _reviewMapper.Map(request);
            _reviewRepository.CreateReview(review);

            return new OkObjectResult(review.Id);
        }

        public IActionResult DeleteReview(Guid id)
        {
            _reviewRepository.DeleteReview(id);

            return new OkResult();
        }

        public IActionResult GetReview(Guid id)
        {
            DbReview? dbReview = _reviewRepository.GetReview(id);

            if (dbReview is null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(dbReview);
        }

        public IActionResult GetReviews()
        {
            List<DbReview>? _reviews = _reviewRepository.GetReviews();

            if (_reviews is null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(_reviews);
        }

        public IActionResult UpdateReview(ReviewRequest request, Guid id)
        {
            DbReview? dbReview = _reviewRepository.GetReview(id);

            if (dbReview is null)
            {
                return new NotFoundResult();
            }

            ValidationResult validationResult = _reviewRequestValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors);
            }

            DbReview review = _reviewMapper.Map(request, id);

            _reviewRepository.EditReview(review);

            return new OkResult();
        }
    }
}
