using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaNET.ViewModels.JerarquiaViewModel
{
    public class JerarquiaModel
    {
        public JefeModel Jefe { get; set; }
        public List<EmpleadoModel> Empleados { get; set; }
    }
}
