using System.ComponentModel.DataAnnotations;

namespace Lekadex.Database
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
