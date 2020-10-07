using DemoAPI.Contracts;
using DemoAPI.Models;
using DemoAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoAPI.Repos
{
    // Repo act as Business Facade ( Logic Handler )
    // Repository act as Data Access
    public class DepartementRepo : IDepartementRepo
    {
        private readonly DemoContext _context;
        private readonly IDepartementRepository _repository;

        public DepartementRepo(DemoContext context, IDepartementRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public SuccessResponse AddDepartement(CreateDepartemenVM vm)
        {
            var result = new SuccessResponse();

            if (_context.Departments.Where(x => x.Name.ToLower().Contains(vm.Name.ToLower())).Count() != 0)
                result.Reason = $"Departement '{vm.Name}' already existed.";
            else
            {
                var department = new Department
                {
                    Name = vm.Name,
                    Location = vm.Location
                };

                _repository.Create(department);

                result.Success = true;
            }

            return result;
        }

        public SuccessResponse DeleteDepartement(long id)
        {
            var result = new SuccessResponse();

            var departement = _context.Departments.Include(x=> x.Employees)
                                                  .Where(x=> x.Id == id)
                                                  .FirstOrDefault();

            if (departement == null)
                result.Reason = $"Departement with ID'{id}' not found.";
            else 
            {
                departement.IsDeleted = true;
                departement.ModifiedDate = DateTime.Now;

                departement.Employees = departement.Employees.Select(x => 
                                                                       { 
                                                                           x.IsDeleted = true; 
                                                                           x.ModifiedDate = DateTime.Now; 
                                                                           
                                                                           return x; 
                                                                       })
                                                             .ToList();

                _context.Departments.Update(departement);
                _context.SaveChanges();

                result.Success = true;
            }

            return result;
        }

        public DepartementDetailVM GetDepartmentById(long id) =>
            _context.Departments.Include(x => x.Employees)
                                .Where(x => x.Id == id)
                                .Select(x => new DepartementDetailVM
                                          {
                                              Id = x.Id,
                                              Name = x.Name,
                                              Location = x.Location,
                                              Employees = x.Employees.Select(y => new EmployeeVM
                                                                               {
                                                                                   Id = y.Id,
                                                                                   FirstName = y.FirstName,
                                                                                   LastName = y.LastName,
                                                                                   JoinDate = y.JoinDate
                                                                               })
                                                                     .ToList()
                                          })
                                .FirstOrDefault();

        public List<DepartementVM> GetDepartments(int page, int itemsPerPage) =>
            _context.Departments.Select(x => new DepartementVM 
                                          {
                                             Id = x.Id,
                                             Name = x.Name,
                                             Location = x.Location
                                          })
                                .Skip(itemsPerPage * (page - 1))
                                .Take(itemsPerPage)
                                .ToList();

        public SuccessResponse UpdateDepartement(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
