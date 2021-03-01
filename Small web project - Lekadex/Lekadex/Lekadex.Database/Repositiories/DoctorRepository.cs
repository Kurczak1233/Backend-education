using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lekadex.Database
{
    public class DoctorRepository : BaseRepostirory<Doctor>, IDoctorRepostiory
    {
        protected override DbSet<Doctor> DbSet => _db.Doctors;

        public DoctorRepository(LekadexAppDbContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Doctor> GetAllDoctors()
        {
            //Filtrowanie wyżej (db)
            return DbSet.Include(x => x.PresiptionsList).ThenInclude(x=>x.MedicinesList).Select(x => x); //INCLUDE DODAJE LEKI DO PRESCRIPTION!
        } //THEN INCLUDE WCHODZI DO OBIEKTU BY DOBRAĆ SIĘ GŁĘBIEJ DO DANYCH
    }
}
