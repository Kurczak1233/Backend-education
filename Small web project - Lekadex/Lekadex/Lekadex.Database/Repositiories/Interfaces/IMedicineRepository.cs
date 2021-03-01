using System.Collections.Generic;

namespace Lekadex.Database
{
    public interface IMedicineRepository : IRepository<Medicine>
    {
        IEnumerable<Medicine> GetAllMedicines();
    }
}
