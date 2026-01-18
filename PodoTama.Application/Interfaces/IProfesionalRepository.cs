using PodoTama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodoTama.Application.Interfaces
{
    public interface IProfesionalRepository
    {
        Task<IEnumerable<Profesional>> GetAllAsync();
        Task<Profesional?> GetByIdAsync(int id);
        Task AddAsync(Profesional paciente);
        Task UpdateAsync(Profesional paciente);
        Task DeleteAsync(int id);
    }
}
