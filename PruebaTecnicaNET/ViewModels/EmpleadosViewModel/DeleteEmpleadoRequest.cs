using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaNET.ViewModels.EmpleadosViewModel
{
    public class DeleteEmpleadoRequest
    {
        [Display(Name = "Código Empleado")]
        public int IdEmpleado { get; set; }

        [Display(Name = "Nombre")]
        public string NombreCompleto { get; set; }
    }
}
