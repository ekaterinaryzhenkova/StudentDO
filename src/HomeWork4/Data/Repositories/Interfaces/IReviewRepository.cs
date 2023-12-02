using DbModels;

namespace Data.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        void CreateReview(DbReview client);
        void DeleteReview(Guid id);
        void EditReview(DbReview client);
        DbReview GetReview(Guid id);
        List<DbReview> GetReviews();
    }
}
