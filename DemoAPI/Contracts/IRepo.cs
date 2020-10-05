using DemoAPI.Models;
using System.Collections.Generic;

namespace DemoAPI.Contracts
{
    public interface IPersonRepo
    {
        List<Person> GetListPerson(int page, int itemsPerPage);
        Person GetPersonById(long id);
        SuccessResponse AddPerson(Person person);
    }
}
