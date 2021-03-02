using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lekadex.Database
{


    public abstract class BaseRepostirory<Entity> : IRepository<Entity> where Entity : BaseEntity
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

        public bool SaveChanges()
        {
            return _db.SaveChanges() > 0;
        }

        public bool AddNew(Entity entity)
        {
            DbSet.Add(entity);
            return SaveChanges();
        }
        public bool Delete(Entity entity)
        {
            var foundEntity = DbSet.FirstOrDefault(x => x.Id == entity.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return SaveChanges();
            }
            return false;
        }
    }

}
