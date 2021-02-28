using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lekadex.Database
{


    public abstract class BaseRepostirory<Entity> where Entity : class
    {
        protected LekadexAppDbContext _db;
        protected abstract DbSet<Entity> DbSet { get; }
        public BaseRepostirory(LekadexAppDbContext db)
        {
            _db = db;
        }

        public List<Entity> GetAll()
        {
            var list = new List<Entity>();
            //var list2 = await _db.Settings.ToListAsync(); Simplier?
            var entities = DbSet; //Wszystkie settingi się tutaj znajdą.
            foreach (var entity in entities)
            {
                list.Add(entity);
            }
            return list;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }

}
