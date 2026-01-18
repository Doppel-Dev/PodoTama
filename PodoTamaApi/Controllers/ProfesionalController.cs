using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PodoTama.Application.DTOs;
using PodoTama.Application.Interfaces;
using PodoTama.Application.UseCases;
using PodoTama.Domain.Entities;
using Profesional = PodoTama.Domain.Entities.Profesional;

namespace PodoTama.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesionalController : ControllerBase
    {
        private readonly IProfesionalRepository _repo;
        private readonly GetPacientesQuery _getPacientes;
        public ProfesionalController(IProfesionalRepository repo, GetPacientesQuery getPacientes)
        {
            _repo = repo;
            _getPacientes = getPacientes;
        }

        // GET: api/profesionales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesional>>> GetProfesionales()
        {
            var profesionales = await _repo.GetAllAsync();
            return Ok(profesionales);
        }

        // GET: api/profesionales/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesional>> GetProfesionales(int id)
        {
            var profesionales = await _repo.GetByIdAsync(id);
            if (profesionales == null)
                return NotFound();

            return Ok(profesionales);
        }

        // POST: api/profesionales
        [HttpPost]
        public async Task<ActionResult<Profesional>> PostProfesional(Profesional profesional)
        {
            await _repo.AddAsync(profesional);
            return CreatedAtAction(nameof(GetProfesionales), new { id = profesional.IdProfesional }, profesional);
        }

        // PUT: api/profesionales/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesional(int id, Profesional profesional)
        {
            if (id != profesional.IdProfesional)
                return BadRequest("El ID no coincide");

            await _repo.UpdateAsync(profesional);
            return NoContent(); // 204
        }

        // DELETE: api/profesionales/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesional(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _repo.DeleteAsync(id);
            return NoContent(); // 204
        }
    }


}
