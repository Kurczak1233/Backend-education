using System.Collections.Generic;

namespace Lekadex.Database
{
    public interface IPrescriptionRepository : Irepository<Prescription>
    {
        IEnumerable<Prescription> GetAllPrescriptions();
    }
}
