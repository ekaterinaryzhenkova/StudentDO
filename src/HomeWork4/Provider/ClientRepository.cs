﻿using DbModels;
using Microsoft.EntityFrameworkCore;

namespace Provider
{
    public class ClientRepository
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

        public void EditClient(Guid clientId, string name, string phoneNumber)
        {
            var client = _dbContext.Clients.FirstOrDefault(u => u.Id == clientId);

            client.Name = name;
            client.PhoneNumber = phoneNumber;

            _dbContext.SaveChanges();
        }

        public void DeleteClient(Guid clientId)
        {
            var client = _dbContext.Clients.FirstOrDefault(u => u.Id == clientId);

            _dbContext.Remove(client);

            _dbContext.SaveChanges();
        }
    }
}
