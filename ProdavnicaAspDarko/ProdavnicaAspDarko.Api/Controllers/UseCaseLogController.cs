using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdavnicaAspDarko.Application;
using ProdavnicaAspDarko.Application.Queries;
using ProdavnicaAspDarko.Application.Searches;

namespace ProdavnicaAspDarko.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCaseLogController : ControllerBase
    {
       private readonly UseCaseExecutor executor;

        public UseCaseLogController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/UseCaseLog
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] UseCaseLogSearch search, [FromServices] IGetUseCaseLogsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        [HttpGet("{id}", Name = "Dohvatanje Podataka iz UseCaseLoga")]
        public string Get(int id)
        {
            return "value";
        }



    }
}
