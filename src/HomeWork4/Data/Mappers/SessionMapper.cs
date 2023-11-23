using Data.Mappers.Interfaces;
using DbModels;
using Requests.Request;

namespace Data.Mappers
{
    public class SessionMapper : ISessionMapper
    {
        DbSession ISessionMapper.Map(SessionRequest request)
        {
            if (request is null)
            {
                return null;
            }

            return new DbSession
            {
                Id = Guid.NewGuid(),
                MasseurId = request.MasseurId,
                ClientId = request.ClientId,
                DateTime = request.DateTime,
                TypeOfMassage = request.TypeOfMassage
            };
        }

        DbSession ISessionMapper.Map(SessionRequest request, Guid id)
        {
            if (request is null)
            {
                return null;
            }

            return new DbSession
            {
                Id = id,
                MasseurId = request.MasseurId,
                ClientId = request.ClientId,
                DateTime = request.DateTime,
                TypeOfMassage = request.TypeOfMassage
            };
        }
    }
}
