using Data.Repositories.Interfaces;
using DbModels;
using Microsoft.EntityFrameworkCore;
using Provider;

namespace Data.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly HomeWork4DbContext _dbContext = new();

        public List<DbSession> GetSessions()
        {
            return _dbContext.Sessions.ToList();
        }

        public DbSession GetSession(Guid sessionId)
        {
            return _dbContext.Sessions
              .AsNoTracking()
              .Where(u => u.Id == sessionId)
              .FirstOrDefault();
        }

        public void CreateSession(DbSession session)
        {
            _dbContext.Add(session);

            _dbContext.SaveChanges();
        }

        public void EditSession(DbSession session)
        {
            var _session = _dbContext.Sessions.FirstOrDefault(u => u.Id == session.Id);

            _session.ClientId = session.ClientId;
            _session.MasseurId = session.MasseurId;
            _session.DateTime = session.DateTime;
            _session.TypeOfMassage = session.TypeOfMassage;

            _dbContext.SaveChanges();
        }

        public void DeleteSession(Guid sessionId)
        {
            var session = _dbContext.Sessions.FirstOrDefault(u => u.Id == sessionId);

            _dbContext.Remove(session);

            _dbContext.SaveChanges();
        }
    }
}
