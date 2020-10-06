using DemoAPI.Contracts;
using DemoAPI.Models;
using DemoAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoAPI.Repos
{
    public class DepartementRepo : IDepartementRepo
    {
        private readonly DemoContext _context;

        public DepartementRepo(DemoContext context)
        {
            _context = context;
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
                    Location = vm.Location,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedBy = "Actor",
                    CreatedDate = DateTime.Now,

                    ModifiedBy = "Actor",
                    ModifiedDate = DateTime.Now
                };

                _context.Departments.Add(department);
                _context.SaveChanges();

                result.Success = true;
            }

            return result;
        }

        public SuccessResponse DeleteDepartement(long id)
        {
            throw new NotImplementedException();
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
