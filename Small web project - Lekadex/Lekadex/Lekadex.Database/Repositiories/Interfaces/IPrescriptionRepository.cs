using System.Collections.Generic;

namespace Lekadex.Database
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        IEnumerable<Prescription> GetAllPrescriptions();
    }
}
