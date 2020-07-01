using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdavnicaAspDarko.Application;
using ProdavnicaAspDarko.Application.Commands;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Application.Exceptions;
using ProdavnicaAspDarko.Application.Queries;
using ProdavnicaAspDarko.Application.Searches;

namespace ProdavnicaAspDarko.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlijentController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public KlijentController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }
        // GET: api/Klijent
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] KlijentSearch search, [FromServices] IGetKlijentiQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Klijent/5
        [Authorize]
        [HttpGet("{id}", Name = "DohvatiKlijenta")]
        public IActionResult Get([FromRoute] int id, [FromServices] IGetKlijentById query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Klijent
        [HttpPost]
        public void Post([FromBody] KlijentDto klijentDto,[FromServices] ICreateKlijentCommand command)
        {
            executor.ExecuteCommand(command, klijentDto);
        }

        // PUT: api/Klijent/5
        [HttpPut]
        public void Put([FromBody]KlijentUpdateDto klijentUpdateDto, [FromServices] IUpdateKlijentCommand command)
        {
            executor.ExecuteCommand(command, klijentUpdateDto);
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices]IDeleteKlijentCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();

        }
    }
}
