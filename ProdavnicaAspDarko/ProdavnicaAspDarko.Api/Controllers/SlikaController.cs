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

namespace ProdavnicaAspDarko.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlikaController : ControllerBase
    {
        public readonly IApplicationActor actor;
        public readonly UseCaseExecutor executor;

        public SlikaController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

       

        // GET: api/Slika/5
        [Authorize]
        [HttpGet("{id}", Name = "Dohvatanje Slika")]
        public IActionResult Get(int id, [FromServices] IGetProizvodSlikeQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Slika
        [Authorize]
        [HttpPost]
        public void Post([FromForm] SlikaDto slikaDto,[FromServices] ICreateSlikaCommand command)
        {
            executor.ExecuteCommand(command, slikaDto);
        }

        // PUT: api/Slika/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete]
        public void Delete([FromBody]IEnumerable<ProizvodNjegoveSlikeDto> proizvodSlikeDto,[FromServices] IDeleteSlikeProizvodaCommand command)
        {
            executor.ExecuteCommand(command, proizvodSlikeDto);
        }
    }
}
