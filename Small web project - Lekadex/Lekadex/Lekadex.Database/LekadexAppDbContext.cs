using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lekadex.Database
{
    public class LekadexAppDbContext : DbContext
    {
        public LekadexAppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
