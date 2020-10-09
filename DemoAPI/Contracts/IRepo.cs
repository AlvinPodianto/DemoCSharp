using DemoDataService.Models;
using DemoDataService.ViewModels;
using System.Collections.Generic;

namespace DemoDataService.Contracts
{
    public interface IPersonRepo
    {
        List<Person> GetListPerson(int page, int itemsPerPage);
        Person GetPersonById(long id);
        SuccessResponse AddPerson(Person person);
    }

    public interface IEmployeeRepo
    {
        List<EmployeeVM> GetEmployees (int page, int itemsPerPage);
        EmployeeDetailVM GetEmployeeById (long id);
        SuccessResponse AddEmployee(CreateEmployeeVM employee);
        SuccessResponse UpdateEmployee(Employee employee);
        SuccessResponse DeleteEmployee(long id);
    }
}