using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodoTama.Application.DTOs
{
    public class ProfesionalDTO
    {
        [Key]
        public int IdProfesional { get; set; }
        [Required(ErrorMessage = "El nombre del profesional es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string? Nombre { get; set; }
        [Phone(ErrorMessage = "La especialidad no es válida o no tiene el formato correcto.")]
        [StringLength(100, ErrorMessage = "La especialidad no puede superar los 100 caracteres.")]
        public string? Especialidad { get; set; }
        [Phone(ErrorMessage = "El número de teléfono no es válido.")]
        [StringLength(15, ErrorMessage = "El teléfono no puede superar los 15 caracteres.")]
        public string? Telefono { get; set; }
        [EmailAddress(ErrorMessage = "El email no es válido.")]
        [StringLength(100, ErrorMessage = "El email no puede superar los 100 caracteres.")]
        public string? Email { get; set; }

    }
}
