using System.Collections.Generic;

namespace PruebaTecnicaNET.ViewModels.EmpleadosViewModel
{
    public class HabilidadEmpleadoViewModel
    {
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public List<EmpleadoHabilidadesResponse> EmpleadoHabilidades { get; set; }
    }
}
