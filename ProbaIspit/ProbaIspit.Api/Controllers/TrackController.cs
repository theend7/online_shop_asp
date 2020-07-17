using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProbaIspit.Application;
using ProbaIspit.Application.Commands;
using ProbaIspit.Application.DataTransfer;

namespace ProbaIspit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public TrackController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/Track
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Track/5
        [HttpGet("{id}", Name = "GetPesma")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Track
        [HttpPost]
        public void Post([FromBody] TrackDto dto,[FromServices] ICreateTrackCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT: api/Track/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
