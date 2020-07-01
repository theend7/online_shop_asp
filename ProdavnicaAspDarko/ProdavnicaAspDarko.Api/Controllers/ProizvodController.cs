using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdavnicaAspDarko.Application;
using ProdavnicaAspDarko.Application.Commands;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Application.Queries;
using ProdavnicaAspDarko.Application.Searches;
using ProdavnicaAspDarko.Domain;

namespace ProdavnicaAspDarko.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProizvodController : ControllerBase
    {
        public readonly IApplicationActor actor;
        public readonly UseCaseExecutor executor;
        

        public ProizvodController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        // GET: api/Proizvod
        [HttpGet]
        
        public IActionResult Get([FromQuery] ProizvodSearch search,[FromServices] IGetProizvodiQuery query)
        {
            return Ok(executor.ExecuteQuery(query,search));
        }

        // GET: api/Proizvod/5
        [HttpGet("{id}", Name = "DohvatiProizvod")]
        public IActionResult Get([FromRoute] int id, [FromServices] IGetProizvodByIdQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Proizvod
        [Authorize]
        [HttpPost]
        public void Post([FromForm] ProizvodSlikaCenaDto proizvodDto,[FromServices] ICreateProizvodCommand command)
        {
            executor.ExecuteCommand(command, proizvodDto);
        }

        // PUT: api/Proizvod/5
        [Authorize]
        [HttpPut]
        public void Put([FromForm] ProizvodUpdateDto proizvodUpdateDto, [FromServices] IUpdateProizvodCommand command)
        {
            executor.ExecuteCommand(command, proizvodUpdateDto);
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteProizvodCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
