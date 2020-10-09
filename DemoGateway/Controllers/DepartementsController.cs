using DemoGateway.Contracts;
using DemoGateway.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceProto.Departement;

namespace DemoGateway.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartementsController : ControllerBase
    {
        public readonly ProtoDepartement.ProtoDepartementClient _departement;

        public DepartementsController(IGrpcClient client) =>
            _departement = new ProtoDepartement.ProtoDepartementClient(client.DepartementChannel);

        [HttpPost]
        public ActionResult<string> Post([FromBody]AddDepartementRequest request)
        {
            var result = _departement.AddDepartement(new AddDepartementMessage { Name = request.Name, Location = request.Location });

            if (result.Success)
                return Ok("Success");
            else
                return BadRequest(result.Reason);
        }
    }
}