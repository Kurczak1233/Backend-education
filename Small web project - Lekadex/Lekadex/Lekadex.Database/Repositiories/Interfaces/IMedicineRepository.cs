using System.Collections.Generic;

namespace Lekadex.Database
{
    public interface IMedicineRepository : Irepository<Medicine>
    {
        IEnumerable<Medicine> GetAllMedicines();
    }
}
