using Data.Mappers.Interfaces;
using DbModels;
using Requests.Request;

namespace Data.Mappers
{
    public class ClientMapper : IClientMapper
    {
        DbClient IClientMapper.Map(CreateClientRequest request)
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

        DbClient IClientMapper.Map(UpdateClientRequest request)
        {
            if (Guid.TryParse(request.Id, out Guid result))
            {
                return new DbClient
                {
                    Id = result,
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                };
            }

            return null;
        }
    }
}
