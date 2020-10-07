using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DemoAPI.Contracts
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<IEntity> GetEntities();
        IEnumerable<IEntity> GetEntities(Expression<Func<IEntity, bool>> predicate);
        IEntity GetById(long id);
        bool Create(IEntity entity);
        bool Update(IEntity entity);
        bool Delete(IEntity entity);
    }

    public interface IDepartementRepository : IRepository<Department> { }
    public interface IEmployeeRepository : IRepository<Employee> { }
}