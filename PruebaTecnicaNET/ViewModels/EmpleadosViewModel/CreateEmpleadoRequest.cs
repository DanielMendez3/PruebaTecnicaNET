using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaNET.ViewModels.EmpleadosViewModel
{
    public class CreateEmpleadoRequest
    {
        [Display(Name = "Nombre completo")]
        [Required(ErrorMessage = "El campo Nombre Completo es obligatorio")]
        [MaxLength(100)]
        public string NombreCompleto { get; set; }

        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "El campo Cédula es obligatorio")]
        [MaxLength(50)]
        public string Cedula { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Ingrese un correo válido")]
        public string Correo { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "El campo Fecha de Nacimiento es obligatorio")]
        public DateTime? FechaNacimiento { get; set; }

        [Display(Name = "Fecha de ingreso")]
        [Required(ErrorMessage = "El campo Fecha de Ingreso es obligatorio")]
        public DateTime FechaIngreso { get; set; }

        [Display(Name = "Jefe")]
        public int? IdJefe { get; set; }

        [Display(Name = "Area")]
        [Required(ErrorMessage = "El campo Área es obligatorio")]
        public int IdArea { get; set; }

        [Display(Name = "Foto")]
        [Required(ErrorMessage = "El campo Foto es obligatorio")]
        public IFormFile Image { get; set; }
    }
}
