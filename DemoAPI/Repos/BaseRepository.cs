using DemoAPI.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DemoAPI.Repos
{
    public class BaseRepository : IRepository<IEntity>
    {
        private readonly DemoContext _context;

        public BaseRepository(DemoContext context) =>
            _context = context;

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

                _context.Set<IEntity>().Add(entity);
                _context.SaveChanges();

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

                _context.Set<IEntity>().Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual IEntity GetById(long id) =>
            _context.Set<IEntity>().Find(id);

        public virtual IEnumerable<IEntity> GetEntities() =>
            _context.Set<IEntity>().AsEnumerable();

        public IEnumerable<IEntity> GetEntities(Expression<Func<IEntity, bool>> predicate) =>
            _context.Set<IEntity>().Where(predicate)
                                   .AsEnumerable();

        public virtual bool Update(IEntity entity)
        {
            try 
            {
                entity.IsDeleted = false;

                entity.ModifiedBy = "Actor";
                entity.ModifiedDate = DateTime.Now;

                _context.Set<IEntity>().Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}