using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodoTama.Domain.Entities
{
    public class Paciente
    {
        public int IdPaciente { get; set; }              // Clave primaria
        public string? Nombre { get; set; }       // Nombre del paciente
        public int Edad { get; set; }     // Edad
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Observaciones { get; set; }

        // Relación con citas
        //public ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }

}
