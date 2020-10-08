using DemoAPI.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DemoAPI.Repos
{
    public class BaseRepository : IRepository<IEntity>
    {
        protected readonly DemoContext Context;

        public BaseRepository(DemoContext context) =>
            Context = context;

        public virtual bool Create(IEntity entity)
        {
            try
            {
                entity.IsActive = true;
                entity.IsDeleted = false;

                entity.CreatedBy = "Actor";
                entity.CreatedDate = DateTime.Now;

                entity.ModifiedBy = "Actor";
                entity.ModifiedDate = DateTime.Now;

                Context.Set<IEntity>().Add(entity);
                Context.SaveChanges();

                return true;
            }
            catch (Exception exception) 
            {
                throw exception;
            }
        }

        public virtual bool Delete(IEntity entity)
        {
            try
            {
                entity.IsDeleted = true;

                entity.ModifiedBy = "Actor";
                entity.ModifiedDate = DateTime.Now;

                Context.Set<IEntity>().Update(entity);
                Context.SaveChanges();

                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual IEntity GetById(long id) =>
            Context.Set<IEntity>().Find(id);

        public virtual IEnumerable<IEntity> GetEntities() =>
            Context.Set<IEntity>().AsEnumerable();

        public IEnumerable<IEntity> GetEntities(Expression<Func<IEntity, bool>> predicate) =>
            Context.Set<IEntity>().Where(predicate)
                                   .AsEnumerable();

        public virtual bool Update(IEntity entity)
        {
            try 
            {
                entity.IsDeleted = false;

                entity.ModifiedBy = "Actor";
                entity.ModifiedDate = DateTime.Now;

                Context.Set<IEntity>().Update(entity);
                Context.SaveChanges();

                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}