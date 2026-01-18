using Microsoft.EntityFrameworkCore;
using PodoTama.Application.Interfaces;
using PodoTama.Domain.Entities;
using PodoTama.Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodoTama.Infraestructure.Repositories
{
    public class ProfesionalRepository : IProfesionalRepository
    {
        private readonly PodoTamaDbContext _context;

        public ProfesionalRepository(PodoTamaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profesional>> GetAllAsync()
        {
            return await _context.Profesionales.ToListAsync();
        }

        public async Task<Profesional?> GetByIdAsync(int id)
        {
            return await _context.Profesionales.FindAsync(id);
        }

        public async Task AddAsync(Profesional profesional)
        {
            _context.Profesionales.Add(profesional);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Profesional profesional)
        {
            _context.Entry(profesional).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var profesional = await _context.Profesionales.FindAsync(id);
            if (profesional != null)
            {
                _context.Profesionales.Remove(profesional);
                await _context.SaveChangesAsync();
            }
        }
    }
}

