using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaNET.BLO.Interfaces;
using PruebaTecnicaNET.ViewModels.JerarquiaViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaNET.Controllers
{
    public class AboutController : Controller
    {
        private readonly IEmpleadoHabilidadService _empleadoHabilidadService;

        public AboutController(IEmpleadoHabilidadService empleadoHabilidad)
        {
            _empleadoHabilidadService = empleadoHabilidad;
        }

        public async Task<ActionResult> Index()
        {
            var jerarquia = await _empleadoHabilidadService.GetJerarquia();
            var groupbynivel = jerarquia.GroupBy(p => new { p.NombreJefe, p.Nivel,p.IdJefe }, (key, g) => new
           JerarquiaModel {
                Jefe = new JefeModel() { IdEmpleado = key.IdJefe, Jefe = key.NombreJefe, Nivel = key.Nivel },
                Empleados = g.Select(s => new EmpleadoModel() { IdEmpleado = s.IdEmpleado, NombreCompleto = s.NombreCompleto}).ToList()
            }).ToList();
            return View(groupbynivel);
        }
    }
}
