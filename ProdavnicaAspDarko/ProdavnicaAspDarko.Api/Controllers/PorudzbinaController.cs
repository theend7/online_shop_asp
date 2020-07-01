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
using ProdavnicaAspDarko.Domain;

namespace ProdavnicaAspDarko.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PorudzbinaController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public PorudzbinaController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/Porudzbina
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] PorudzbinaSearch search, [FromServices] IGetPorudzbineQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Porudzbina/5
        [Authorize]
        [HttpGet("{id}", Name = "DohvatanjePorudzbine")]
        public IActionResult Get([FromRoute] int id, [FromServices] IGetPorudzbinaByIdQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Porudzbina
        [Authorize]
        [HttpPost]
        public void Post([FromBody] CreatePorudzbinaDto  porudzbinaDto,[FromServices] ICreatePorudzbinaCommand command)
        {
            executor.ExecuteCommand(command, porudzbinaDto);
        }



        [Authorize]
        [HttpPost("changestatus")]

        public void ChangeStatus([FromBody] CreateChangeStatusPorudzbineDto statusDto,[FromServices] ICreateChangeStatusCommand command)
        {
            executor.ExecuteCommand(command, statusDto);
        }
    }
}
