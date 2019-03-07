using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TripTracker.BacksServce.Models;

namespace TripTracker.BacksServce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private Repository _repository;

        public TripsController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Trip> Get()
        {
            return _repository.Get();
        }

        [HttpGet("{id}")]
        public Trip Get(int id)
        {
            return _repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] Trip value)
        {
            _repository.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Trip value)
        {
            _repository.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Remove(id);
        }
    }
}
