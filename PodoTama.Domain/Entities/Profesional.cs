using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodoTama.Domain.Entities
{
    public class Profesional
    {
        public int IdProfesional { get; set; }
        public string? Nombre { get; set; } 
        public string? Especialidad { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }

    }
}
