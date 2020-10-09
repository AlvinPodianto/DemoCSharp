using DemoDataService.CQRS.Commands;
using DemoDataService.CQRS.Queries;
using DemoDataService.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace DemoDataService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartementsController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public DepartementsController(IMediator mediator) =>
            _mediatr = mediator;

        [HttpGet]
        public async Task<ActionResult<List<DepartementVM>>> Get([FromQuery]int page, [FromQuery]int itemsPerPage)
        {
            var result = await _mediatr.Send(new GetDepatementsQuery { Page = page, ItemsPerPage = itemsPerPage });
            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<EmployeeDetailVM>> Get(long id)
        {
            try 
            {
                var result = await _mediatr.Send(new GetDepartementByIdQuery { Id = id });
                return Ok(result);
            }
            catch (NullReferenceException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody]CreateDepartemenVM departemenVM)
        {
            var result = await _mediatr.Send(new CreateDepartementCommand { Payload = departemenVM });

            if (result.Success)
                return Ok("Success");
            else
                return BadRequest(result.Reason);
        }

        [HttpDelete("{id:long}")]
        public ActionResult<EmployeeDetailVM> Delete(long id)
        {
            var result = _mediatr.Send(new DeleteDepartementCommand { Id = id }).Result;

            if (result.Success)
                return Ok("Success");
            else
                return BadRequest(result.Reason);
        }
    }
}