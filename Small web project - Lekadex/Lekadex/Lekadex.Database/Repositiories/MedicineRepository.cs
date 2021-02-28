using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lekadex.Database
{
    public class MedicineRepository : BaseRepostirory<Medicine>, IMedicineRepository
    {
        protected override DbSet<Medicine> DbSet => _db.Medicines;

        public MedicineRepository(LekadexAppDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Medicine> GetAllMedicines()
        {
            //Filtrowanie wyżej (db)
            return DbSet.Select(x=>x);
        }
    }
}
