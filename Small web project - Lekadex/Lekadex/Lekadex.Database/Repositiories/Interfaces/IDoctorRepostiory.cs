using System.Collections.Generic;

namespace Lekadex.Database
{
    public interface IDoctorRepostiory : Irepository<Doctor>
    {
        IEnumerable<Doctor> GetAllDoctors();
    }
}
