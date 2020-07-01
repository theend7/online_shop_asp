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

namespace ProdavnicaAspDarko.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CenaController : ControllerBase
    {
        public readonly IApplicationActor actor;
        public readonly UseCaseExecutor executor;

        public CenaController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        // GET: api/Cena
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cena/5
        [HttpGet("{id}", Name = "DohvatanjeCene")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cena
        [Authorize]
        [HttpPost]
        public void Post([FromBody] CenaDto cenaDto,[FromServices] ICreateCenaCommand command)
        {
            executor.ExecuteCommand(command, cenaDto);
        }

        // PUT: api/Cena/5
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
