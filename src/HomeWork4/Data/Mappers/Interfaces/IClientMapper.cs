using DbModels;
using Requests.Request;

namespace Data.Mappers.Interfaces
{
    public interface IClientMapper
    {
        DbClient Map(CreateClientRequest request);
        DbClient Map(UpdateClientRequest request);
    }
}
