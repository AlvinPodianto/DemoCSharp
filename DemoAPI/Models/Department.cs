using DemoDataService.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoDataService.Models
{
    public class Department : BaseEntity, IEntity
    {
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Location { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public Department()
        {
            Employees = new HashSet<Employee>();
        }
    }
}