using Microsoft.EntityFrameworkCore;
using PodoTama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodoTama.Infraestructure.Persistence
{
    public class PodoTamaDbContext : DbContext
    {
        public PodoTamaDbContext(DbContextOptions<PodoTamaDbContext> options): base(options)
        {
            
        }
        public DbSet<Paciente> Pacientes { get; set; }
        //public DbSet<Cita> Citas { get; set; }
        //public DbSet<Podologo> Podologos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(p => p.IdPaciente);
                entity.Property(p => p.Nombre)
                      .IsRequired()
                      .HasMaxLength(100);
            });
        }


    }
}
