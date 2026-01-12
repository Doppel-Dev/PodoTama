using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PodoTama.Application.DTOs;
using PodoTama.Application.Interfaces;

namespace PodoTama.Application.UseCases
{
    public class GetPacientesQuery
    {
        private readonly IPacienteRepository _repository;

        public GetPacientesQuery(IPacienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PacienteDTO>> ExecuteAsync()
        {
            var pacientes = await _repository.GetAllAsync();

            return pacientes.Select(p => new PacienteDTO
            {
                IdPaciente = p.IdPaciente,
                Nombre = p.Nombre,
                Edad = p.Edad,
                Telefono = p.Telefono,
                Direccion = p.Direccion,
                Observaciones = p.Observaciones
            }).ToList();
        }
    }
}
