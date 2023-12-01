using DbModels;
using Microsoft.EntityFrameworkCore;
using Provider;
using Data.Repositories.Interfaces;
using System.Net;

namespace Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly HomeWork4DbContext _dbContext = new();

        public List<DbClient> GetClients()
        {
            return _dbContext.Clients.ToList();
        }

        public async Task<DbClient> GetClientAsync(Guid clientId)
        {
            return await _dbContext.Clients.FirstOrDefaultAsync(u => u.Id == clientId);
        }

        public async Task CreateClientAsync(DbClient client)
        {
            _dbContext.Add(client);

            await _dbContext.SaveChangesAsync();
        }

        public async Task EditClientAsync(DbClient client)
        {
            var _client = _dbContext.Clients.FirstOrDefault(u => u.Id == client.Id);

            _client.Name = client.Name;
            _client.PhoneNumber = client.PhoneNumber;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteClientAsync(Guid clientId)
        {
            var _client = _dbContext.Clients.FirstOrDefault(u => u.Id == clientId);

             _dbContext.Remove(_client);

            await _dbContext.SaveChangesAsync();
        }
    }
}
