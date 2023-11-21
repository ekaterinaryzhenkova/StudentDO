using DbModels;

namespace Data.Interfaces
{
    public interface IClientRepository
    {
        void CreateClient(DbClient client);
        void DeleteClient(Guid id);
        void EditClient(DbClient client);
        DbClient GetClient(Guid id);
        List<DbClient> GetClients();
    }
}
