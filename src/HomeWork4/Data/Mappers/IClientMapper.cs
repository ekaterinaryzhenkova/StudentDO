using DbModels;
using Requests.Request;

namespace Data.Mappers
{
    public interface IClientMapper
    {
        DbClient Map(ClientRequest request);
        DbClient Map(ClientRequest request, Guid id);
    }
}
