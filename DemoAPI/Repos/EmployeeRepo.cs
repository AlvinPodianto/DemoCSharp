﻿using DemoDataService.Contracts;
using DemoDataService.Models;
using DemoDataService.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoDataService.Repos
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly DemoContext _context;

        public EmployeeRepo(DemoContext context) =>
            _context = context;

        public SuccessResponse AddEmployee(CreateEmployeeVM vm)
        {
            var result = new SuccessResponse();

            if (_context.Departments.SingleOrDefault(x => x.Id == vm.DepartementId) == null)
                result.Reason = $"Departement with Id'{vm.DepartementId}' not found.";
            else if (_context.Employees.Where(x=> x.FirstName.ToLower().Contains(vm.FirstName.ToLower()) 
                                                    && x.LastName.ToLower().Contains(vm.LastName.ToLower()))
                                       .Count() != 0)
                result.Reason = $"'{vm.FirstName} {vm.LastName}' already existed.";
            else
            {
                var employee = new Employee
                {
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    DepartmentId = vm.DepartementId,
                    JoinDate = vm.JoinDate,

                    IsActive = true,
                    IsDeleted = false,
                    CreatedBy = "Actor",
                    CreatedDate = DateTime.Now,

                    ModifiedBy = "Actor",
                    ModifiedDate = DateTime.Now
                };

                _context.Employees.Add(employee);
                _context.SaveChanges();

                result.Success = true;
            }

            return result;
        }

        public SuccessResponse DeleteEmployee(long id)
        {
            throw new NotImplementedException();
        }

        public EmployeeDetailVM GetEmployeeById(long id) =>
            _context.Employees.Include(x => x.Department)
                              .Where(x => x.Id == id)
                              .Select(x => new EmployeeDetailVM 
                                        {
                                            Id = x.Id,
                                            FirstName = x.FirstName,
                                            LastName = x.LastName,
                                            JoinDate = x.JoinDate,
                                            Department = new DepartementVM
                                                         {
                                                             Id = x.Department.Id,
                                                             Name = x.Department.Name,
                                                             Location = x.Department.Location
                                                         }
                                        })
                              .FirstOrDefault();

        public List<EmployeeVM> GetEmployees(int page, int itemsPerPage)
        {
            throw new NotImplementedException();
        }

        public SuccessResponse UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
