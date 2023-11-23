using Data.Repositories.Interfaces;
using DbModels;
using Microsoft.EntityFrameworkCore;
using Provider;

namespace Data.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly HomeWork4DbContext _dbContext = new();

        public List<DbReview> GetReviews()
        {
            return _dbContext.Reviews.ToList();
        }

        public DbReview GetReview(Guid reviewId)
        {
            return _dbContext.Reviews
              .AsNoTracking()
              .Where(u => u.Id == reviewId)
              .FirstOrDefault();
        }

        public void CreateReview(DbReview review)
        {
            _dbContext.Add(review);

            _dbContext.SaveChanges();
        }

        public void EditReview(DbReview review)
        {
            var _review = _dbContext.Reviews.FirstOrDefault(u => u.Id == review.Id);

            _review.Mark = review.Mark;
            _review.Comment = review.Comment;

            _dbContext.SaveChanges();
        }

        public void DeleteReview(Guid reviewId)
        {
            var review = _dbContext.Reviews.FirstOrDefault(u => u.Id == reviewId);

            _dbContext.Remove(review);

            _dbContext.SaveChanges();
        }
    }
}
