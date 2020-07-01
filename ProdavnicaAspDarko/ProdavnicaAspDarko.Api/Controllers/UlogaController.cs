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
using ProdavnicaAspDarko.Application.Queries;
using ProdavnicaAspDarko.Application.Searches;

namespace ProdavnicaAspDarko.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UlogaController : ControllerBase
    {
        public readonly IApplicationActor actor;
        public readonly UseCaseExecutor executor;

        public UlogaController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        // GET: api/Uloga
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] UlogaSearch search, [FromServices] IGetUlogeQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Uloga/5
        [Authorize]
        [HttpGet("{id}", Name = "DohvatanjeUloge")]
        public IActionResult Get([FromRoute] int id, [FromServices] IGetUlogaByIdQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Uloga
        [Authorize]
        [HttpPost]
        public void Post([FromBody] UlogaDto ulogaDto,[FromServices] ICreateUlogaCommand command)
        {
            executor.ExecuteCommand(command, ulogaDto);
        }

        // PUT: api/Uloga/5
        [Authorize]
        [HttpPut]
        public void Put([FromBody] UlogaUpdateDto ulogaUpdateDto, [FromServices] IUpdateUlogaCommand command)
        {
            executor.ExecuteCommand(command, ulogaUpdateDto);
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices]IDeleteUlogaCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
