using DbModels;
using Requests.Request;

namespace Data.Mappers.Interfaces
{
    public interface ISessionMapper
    {
        DbSession Map(SessionRequest request);
        DbSession Map(SessionRequest request, Guid id);
    }
}
