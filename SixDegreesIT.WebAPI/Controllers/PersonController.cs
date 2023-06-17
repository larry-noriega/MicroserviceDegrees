using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SixDegreesIT.Core;
using SixDegreesIT.Core.Interfaces;
using SixDegreesIT.Core.SQL;
using SixDegreesIT.Infrastructure.Repository;

namespace SixDegreesIT.WebAPI.Controllers
{
    [Route("api/persons")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IRepository<Person> _repository;
        private readonly IOptions<SQLSettings> _options;

        public PersonController(IOptions<SQLSettings> options)
        {
            _options = options;
            _repository = new Repository<Person>(_options);
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPersons()
        {
            var result = await _repository.List();

            return Ok(result);
        }
    }
}