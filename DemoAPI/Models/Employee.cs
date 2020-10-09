using DemoDataService.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDataService.Models
{
    public class Employee : BaseEntity, IEntity
    {
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        public DateTime JoinDate { get; set; }

        [ForeignKey("department_id")]
        public long DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
