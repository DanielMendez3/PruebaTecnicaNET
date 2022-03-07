using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PruebaTecnicaNET.BLO.Interfaces;
using PruebaTecnicaNET.BLO.Services;
using PruebaTecnicaNET.DAL.Models;
using PruebaTecnicaNET.ViewModels.EmpleadosViewModel;
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
        private readonly IEmpleadoService _empleadoService;
        private readonly IMapper _mapper;
        public AboutController(IEmpleadoHabilidadService empleadoHabilidad, IEmpleadoService empleadoService, IMapper mapper)
        {
            _empleadoHabilidadService = empleadoHabilidad;
            _empleadoService = empleadoService;
            _mapper = mapper;
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

        [HttpGet]
        public async Task<ActionResult> Habilidades(int IdEmpleado)
        {
            HabilidadEmpleadoViewModel model = await GetViewModel(IdEmpleado);
            return View(model);
        }

        private async Task<HabilidadEmpleadoViewModel> GetViewModel(int IdEmpleado)
        {
            var empleado = await _empleadoService.GetEmpleadoById(IdEmpleado);
            if (empleado == null)
            {
                return new HabilidadEmpleadoViewModel();
            }
            var habilidades = await _empleadoHabilidadService.GetHabilidadesByEmpleadoId(IdEmpleado);
            var modelHabilidades = _mapper.Map<List<EmpleadoHabilidadesResponse>>(habilidades);
            HabilidadEmpleadoViewModel model = new HabilidadEmpleadoViewModel();           
            model.IdEmpleado = empleado.IdEmpleado;
            model.NombreEmpleado = empleado.NombreCompleto;
            model.EmpleadoHabilidades = modelHabilidades;
            return model;
        }

        [HttpPost]
        public async Task<JsonResult> AddNewHabilidad(string json)
        {

            var request = JsonConvert.DeserializeObject<NuevaHabilidadRequest>(json);
            var empleadoHabilidad = _mapper.Map<EmpleadoHabilidad>(request);
                await _empleadoHabilidadService.AddHabilidadByEmpleado(empleadoHabilidad);
            HabilidadEmpleadoViewModel model = await GetViewModel(request.IdEmpleado);
            return Json(model.EmpleadoHabilidades);

        }
        [HttpPost]
        public async Task<JsonResult> DeleteHabilidad(string json)
        {

            var request = JsonConvert.DeserializeObject<DeleteHabilidad>(json);
            var empleadoHabilidad = _mapper.Map<EmpleadoHabilidad>(request);
            await _empleadoHabilidadService.DeleteHabilidadEmpleado(empleadoHabilidad);
            HabilidadEmpleadoViewModel model = await GetViewModel(request.IdEmpleado);
            return Json(model.EmpleadoHabilidades);

        }
    }
}
