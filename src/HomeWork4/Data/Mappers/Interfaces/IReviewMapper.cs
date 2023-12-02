using DbModels;
using Requests.Request;

namespace Data.Mappers.Interfaces
{
    public interface IReviewMapper
    {
        DbReview Map(ReviewRequest request);
        DbReview Map(ReviewRequest request, Guid id);
    }
}
