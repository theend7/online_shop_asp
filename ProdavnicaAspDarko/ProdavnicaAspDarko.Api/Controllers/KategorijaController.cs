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
    public class KategorijaController : ControllerBase
    {
        public readonly IApplicationActor actor;
        public readonly UseCaseExecutor executor;

        public KategorijaController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        // GET: api/Kategorija
        [HttpGet]
        public IActionResult Get([FromQuery] KategorijaSearch search, [FromServices] IGetKategorijeQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Kategorija/5
        [HttpGet("{id}", Name = "DohvatanjeKategorije")]
        public IActionResult Get([FromRoute] int id, [FromServices] IGetKategorijaByIdQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Kategorija
        [Authorize]
        [HttpPost]
        public void Post([FromBody] KategorijaDto kategorijaDto,[FromServices] ICreateKategorijaCommand command)
        {
            executor.ExecuteCommand(command, kategorijaDto);
        }

        // PUT: api/Kategorija/5
        [Authorize]
        [HttpPut]
        public void Put([FromBody] KategorijaUpdateDto ulogaKategorijaDto, [FromServices] IUpdateKategorijaCommand command)
        {
            executor.ExecuteCommand(command, ulogaKategorijaDto);
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices]IDeleteKategorijaCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();

        }
    }
}
