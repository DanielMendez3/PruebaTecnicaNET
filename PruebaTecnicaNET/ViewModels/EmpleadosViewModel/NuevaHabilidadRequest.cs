using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaNET.ViewModels.EmpleadosViewModel
{
    public class NuevaHabilidadRequest
    {
        [Required]
        public int IdEmpleado { get; set; }
        [Required]
        public string NombreHabilidad {get; set;}
    }
}
