using DbModels;

namespace Data.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task CreateClientAsync(DbClient client);
        Task DeleteClientAsync(Guid id);
        Task EditClientAsync(DbClient client);
        Task<DbClient> GetClientAsync(Guid id);
        List<DbClient> GetClients();
    }
}
