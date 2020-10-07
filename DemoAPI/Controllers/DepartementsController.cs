using DemoAPI.Contracts;
using DemoAPI.Models;
using DemoAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DemoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartementsController : ControllerBase
    {
        private readonly IDepartementRepo _departementRepo;

        public DepartementsController(IDepartementRepo departementRepo) =>
            _departementRepo = departementRepo;

        [HttpGet]
        public ActionResult<List<DepartementVM>> Get([FromQuery]int page, [FromQuery]int itemsPerPage)
        {
            var result = _departementRepo.GetDepartments(page, itemsPerPage);
            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public ActionResult<EmployeeDetailVM> Get(long id)
        {
            var result = _departementRepo.GetDepartmentById(id);

            if (result == null)
                return BadRequest($"Departement with ID '{id}' not found.");
            else
                return Ok(result);
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody]CreateDepartemenVM departemenVM)
        {
            var result = _departementRepo.AddDepartement(departemenVM);

            if (result.Success)
                return Ok("Success");
            else
                return BadRequest(result.Reason);
        }

        [HttpDelete("{id:long}")]
        public ActionResult<EmployeeDetailVM> Delete(long id)
        {
            var result = _departementRepo.DeleteDepartement(id);

            if (result.Success)
                return Ok("Success");
            else
                return BadRequest(result.Reason);
        }
    }
}