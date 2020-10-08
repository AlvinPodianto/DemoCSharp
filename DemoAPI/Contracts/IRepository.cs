using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DemoAPI.Contracts
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> GetEntities();
        IEnumerable<T> GetEntities(Expression<Func<T, bool>> predicate);
        T GetById(long id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }

    public interface IDepartementRepository : IRepository<Department> { }
    public interface IEmployeeRepository : IRepository<Employee> { }
}