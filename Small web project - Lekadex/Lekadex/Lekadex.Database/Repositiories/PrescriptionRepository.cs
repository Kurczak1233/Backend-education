using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lekadex.Database
{
    public class PrescriptionRepository : BaseRepostirory<Prescription>, IPrescriptionRepository
    {
        protected override DbSet<Prescription> DbSet => _db.Prescriptions;

        public PrescriptionRepository(LekadexAppDbContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Prescription> GetAllPrescriptions()
        {
            //Filtrowanie wyżej (db)
            return DbSet/*Include(x=>x.MedicinesList)*/.Select(x => x); //INCLUDE DODAJE LEKI DO PRESCRIPTION!
        }
    }

}

