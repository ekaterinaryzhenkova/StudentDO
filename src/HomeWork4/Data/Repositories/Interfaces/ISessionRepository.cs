using DbModels;

namespace Data.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        void CreateSession(DbSession client);
        void DeleteSession(Guid id);
        void EditSession(DbSession client);
        DbSession GetSession(Guid id);
        List<DbSession> GetSessions();
    }
}
