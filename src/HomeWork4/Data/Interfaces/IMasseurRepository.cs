using DbModels;

namespace Data.Interfaces
{
    public interface IMasseurRepository
    {
        void CreateMasseur(DbMasseur client);
        void DeleteMasseur(Guid id);
        void EditMasseur(DbMasseur client);
        DbMasseur GetMasseur(Guid id);
        List<DbMasseur> GetMasseurs();
    }
}
