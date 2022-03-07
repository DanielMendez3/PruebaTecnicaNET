using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaNET.ViewModels.EmpleadosViewModel
{
    public class EmpleadoHabilidadesResponse
    {
        [Display(Name = "IdHabilidad")]
        public int IdHabilidad { get; set; }
        [Display(Name = "IdEmpleado")]
        public int IdEmpleado { get; set; }
        [Display(Name = "Habailidad")]
        public string NombreHabilidad { get; set; }
    }
}
