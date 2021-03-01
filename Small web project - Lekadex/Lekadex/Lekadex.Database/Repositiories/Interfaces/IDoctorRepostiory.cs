using System.Collections.Generic;

namespace Lekadex.Database
{
    public interface IDoctorRepostiory : IRepository<Doctor>
    {
        IEnumerable<Doctor> GetAllDoctors();
    }
}
