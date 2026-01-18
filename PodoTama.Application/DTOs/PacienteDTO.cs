using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodoTama.Application.DTOs
{
    public class PacienteDTO
    {
        [Key]
        public int IdPaciente { get; set; }  // Clave primaria

        [Required(ErrorMessage = "El nombre del paciente es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string? Nombre { get; set; }   // Nombre del paciente

        [Required(ErrorMessage = "La edad es obligatoria.")]
        [Range(0, 120, ErrorMessage = "La edad debe estar entre 0 y 120 años.")]
        public int? Edad { get; set; }

        [Phone(ErrorMessage = "El número de teléfono no es válido.")]
        [StringLength(15, ErrorMessage = "El teléfono no puede superar los 15 caracteres.")]
        public string? Telefono { get; set; }

        [StringLength(200, ErrorMessage = "La dirección no puede superar los 200 caracteres.")]
        public string? Direccion { get; set; }

        [StringLength(500, ErrorMessage = "Las observaciones no pueden superar los 500 caracteres.")]
        public string? Observaciones { get; set; }
    }
}
