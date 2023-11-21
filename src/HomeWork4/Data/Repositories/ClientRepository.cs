using DbModels;
using Microsoft.EntityFrameworkCore;
using Data.Interfaces;
using Provider;

namespace Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly HomeWork4DbContext _dbContext = new();

        public List<DbClient> GetClients()
        {
            return _dbContext.Clients.ToList();
        }

        public DbClient GetClient(Guid clientId)
        {
            return _dbContext.Clients
              .AsNoTracking()
              .Where(u => u.Id == clientId)
              .FirstOrDefault();
        }

        public void CreateClient(DbClient client)
        {
            _dbContext.Add(client);

            _dbContext.SaveChanges();
        }

        public void EditClient(DbClient client)
        {
            var _client = _dbContext.Clients.FirstOrDefault(u => u.Id == client.Id);

            _client.Name = client.Name;
            _client.PhoneNumber = client.PhoneNumber;

            _dbContext.SaveChanges();
        }

        public void DeleteClient(Guid clientId)
        {
            var _client = _dbContext.Clients.FirstOrDefault(u => u.Id == clientId);

            _dbContext.Remove(_client);

            _dbContext.SaveChanges();
        }
    }
}
