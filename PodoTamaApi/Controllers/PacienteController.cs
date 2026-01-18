using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PodoTama.Application.Interfaces;
using PodoTama.Application.UseCases;
using PodoTama.Domain.Entities;
using PodoTama.Infraestructure.Persistence;

namespace PodoTama.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _repo;
        private readonly GetPacientesQuery _getPacientes;
        public PacienteController(IPacienteRepository repo ,GetPacientesQuery getPacientes)
        {
            _repo = repo;
            _getPacientes = getPacientes;
        }

        // GET: api/pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
            var pacientes = await _repo.GetAllAsync();
            return Ok(pacientes);
        }

        // GET: api/pacientes/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPaciente(int id)
        {
            var paciente = await _repo.GetByIdAsync(id);
            if (paciente == null)
                return NotFound();

            return Ok(paciente);
        }

        // POST: api/pacientes
        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente(Paciente paciente)
        {
            await _repo.AddAsync(paciente);
            return CreatedAtAction(nameof(GetPaciente), new { id = paciente.IdPaciente }, paciente);
        }

        // PUT: api/pacientes/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(int id, Paciente paciente)
        {
            if (id != paciente.IdPaciente)
                return BadRequest("El ID no coincide");

            await _repo.UpdateAsync(paciente);
            return NoContent(); // 204
        }

        // DELETE: api/pacientes/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _repo.DeleteAsync(id);
            return NoContent(); // 204
        }
    }


}
