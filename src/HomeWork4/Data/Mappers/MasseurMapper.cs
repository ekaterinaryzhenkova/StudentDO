using DbModels;
using Requests.Request;

namespace Data.Mappers
{
    public class MasseurMapper : IMasseurMapper
    {
        DbMasseur IMasseurMapper.Map(MasseurRequest request)
        {
            if (request is null)
            {
                return null;
            }

            return new DbMasseur
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Specialization = request.Specialization,
            };
        }

        DbMasseur IMasseurMapper.Map(MasseurRequest request, Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }

            return new DbMasseur
            {
                Id = id,
                Name = request.Name,
                Specialization = request.Specialization,
            };
        }
    }
}
