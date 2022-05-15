using Api.Model;
using Api.Services;
using Api.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacientesService pacientesService;

        public PacientesController(IPacientesService pacientesService)
        {
            this.pacientesService = pacientesService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> Get(int id)
        {
            Paciente paciente = await pacientesService.Get(id);
            if (paciente == null)
                return NotFound();
            return Ok(paciente);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Paciente>> Index()
        {
            // add header pagination extraction
            var pacientes = pacientesService.Index(IndexOptions.DefaultOptions);
            return Ok(pacientes);
        }
    }
}
