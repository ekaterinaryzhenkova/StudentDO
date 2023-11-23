using Data.Mappers.Interfaces;
using DbModels;
using Requests.Request;

namespace Data.Mappers
{
    public class ReviewMapper : IReviewMapper
    {
        DbReview IReviewMapper.Map(ReviewRequest request)
        {
            if (request is null)
            {
                return null;
            }

            return new DbReview
            {
                Id = Guid.NewGuid(),
                ClientId = request.ClientId,
                MasseurId = request.MasseurId,
                Mark = request.Mark,
                Comment = request.Comment
            };
        }

        DbReview IReviewMapper.Map(ReviewRequest request, Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }

            return new DbReview
            {
                Id = id,
                ClientId = request.ClientId,
                MasseurId = request.MasseurId,
                Mark = request.Mark,
                Comment = request.Comment
            };
        }
    }
}
