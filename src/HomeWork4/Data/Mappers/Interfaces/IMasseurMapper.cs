using DbModels;
using Requests.Request;

namespace Data.Mappers.Interfaces
{
    public interface IMasseurMapper
    {
        DbMasseur Map(MasseurRequest request);
        DbMasseur Map(MasseurRequest request, Guid id);
    }
}
