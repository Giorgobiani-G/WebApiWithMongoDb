using Microsoft.AspNetCore.Mvc;
using WebApiWithMongoDb.Services;
using WebApiWithMongoDb.Services.Persons;

namespace WebApiWithMongoDb.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get(CancellationToken cancellationToken = default)
        {
            return await _service.Get(cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> Create(CreatePersonCommand student, CancellationToken cancellationToken = default)
        {
            return await _service.Create(student, cancellationToken);
        }
    }
}