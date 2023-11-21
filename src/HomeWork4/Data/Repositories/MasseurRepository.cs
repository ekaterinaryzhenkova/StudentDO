using Data.Interfaces;
using DbModels;
using Microsoft.EntityFrameworkCore;
using Provider;

namespace Data.Repositories
{
    public class MasseurRepository : IMasseurRepository
    {
        private readonly HomeWork4DbContext _dbContext = new();

        public List<DbMasseur> GetMasseurs()
        {
            return _dbContext.Masseurs.ToList();
        }

        public DbMasseur GetMasseur(Guid masseurId)
        {
            return _dbContext.Masseurs
              .AsNoTracking()
              .Where(u => u.Id == masseurId)
              .FirstOrDefault();
        }

        public void CreateMasseur(DbMasseur masseur)
        {
            _dbContext.Add(masseur);

            _dbContext.SaveChanges();
        }

        public void EditMasseur(DbMasseur masseur)
        {
            var _masseur = _dbContext.Masseurs.FirstOrDefault(u => u.Id == masseur.Id);

            _masseur.Name = masseur.Name;
            _masseur.Specialization = masseur.Specialization;

            _dbContext.SaveChanges();
        }

        public void DeleteMasseur(Guid masseurId)
        {
            var masseur = _dbContext.Masseurs.FirstOrDefault(u => u.Id == masseurId);

            _dbContext.Remove(masseur);

            _dbContext.SaveChanges();
        }
    }
}
