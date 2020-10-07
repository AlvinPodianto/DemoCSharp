using DemoAPI.Models;
using System.Collections.Generic;

namespace DemoAPI.Contracts
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<IEntity> GetEntities();
        IEntity GetById(long id);
        bool Create(IEntity entity);
        bool Update(IEntity entity);
        bool Delete(IEntity entity);
    }

    public interface IDepartementRepository : IRepository<Department> { }
    public interface IEmployeeRepository : IRepository<Employee> { }
}
