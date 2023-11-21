using DbModels;
using Requests.Request;

namespace Data.Mappers
{
    public class ClientMapper : IClientMapper
    {
        DbClient IClientMapper.Map(ClientRequest request)
        {
            if (request is null)
            {
                return null;
            }

            return new DbClient
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
            };
        }

        DbClient IClientMapper.Map(ClientRequest request, Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }

            return new DbClient
            {
                Id = id,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
            };
        }
    }
}
