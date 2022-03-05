using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaNET.ViewModels.EmpleadosViewModel
{
    public class InfoEmpleadoResponse
    {
        [Display(Name = "Código Empleado")]
        public int IdEmpleado { get; set; }
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; }
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }
        [Display(Name = "Correo")]
        public string Correo { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        public DateTime? FechaNacimiento { get; set; }
        public string YearsOld { get; set; }
        [Display(Name = "Fecha de ingreso")]
        public DateTime FechaIngreso { get; set; }
        public string YearsWorked { get; set; }
        [Display(Name = "Jefe")]
        public string Jefe { get; set; }
        [Display(Name = "Área")]
        public string Area { get; set; }
        [Display(Name = "Foto")]
        public string Image { get; set; }
    }
}
