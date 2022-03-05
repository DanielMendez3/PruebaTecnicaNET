using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PruebaTecnicaNET.BLO.Services;
using PruebaTecnicaNET.DAL.Models;
using PruebaTecnicaNET.Helpers;
using PruebaTecnicaNET.ViewModels.EmpleadosViewModel;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PruebaTecnicaNET.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IAreaService _areaService;
        private readonly IMapper _mapper;
        public EmpleadosController(IEmpleadoService empleadoService, IAreaService areaService, IMapper mapper)
        {
            _empleadoService = empleadoService;
            _areaService = areaService;
            _mapper = mapper;
        }
        // GET: EmpeladosController
        public async Task<ActionResult> Index()
        {
            var empleados = await _empleadoService.GetEmpleados();
            var viewModel = _mapper.Map<List<EmpleadoResponse>>(empleados);
            return View(viewModel);
        }

        // GET: EmpeladosController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: EmpeladosController/Create
        public async Task<ActionResult> Create()
        {
            var areas = await _areaService.GetAreas();
            var empleados = await _empleadoService.GetEmpleados();
            empleados.Insert(0, new Empleado() { IdEmpleado = 0, NombreCompleto = "SELECCIONE UN EMPLEADO" });
            ViewBag.IdArea = new SelectList(areas, "IdArea", "Nombre");
            ViewBag.IdJefe = new SelectList(empleados, "IdEmpleado", "NombreCompleto");
            return View();
        }

        // POST: EmpeladosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] CreateEmpleadoRequest createEmpleadoRequest)
        {
            try
            {
                var areas = await _areaService.GetAreas();
                var empleados = await _empleadoService.GetEmpleados();
                empleados.Insert(0, new Empleado() { IdEmpleado = 0, NombreCompleto = "SELECCIONE UN EMPLEADO" });
                ViewBag.IdArea = new SelectList(areas, "IdArea", "Nombre");
                ViewBag.IdJefe = new SelectList(empleados, "IdEmpleado", "NombreCompleto");

                if (ModelState.IsValid)
                {
                   
                    //mapeamos modelo
                    var empleado = _mapper.Map<Empleado>(createEmpleadoRequest);
                    using (var ms = new MemoryStream())
                    {
                        createEmpleadoRequest.Image.CopyTo(ms);
                        empleado.Foto = ms.ToArray();
                    }

                    if (createEmpleadoRequest.IdJefe == 0) empleado.IdJefe = null;

                    await _empleadoService.AgregarEmpleado(empleado);
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpeladosController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var empleado = await _empleadoService.GetEmpleadoById(id);
            if (empleado != null)
            {
                var model = _mapper.Map<UpdateEmpleadoRequest>(empleado);
                var areas = await _areaService.GetAreas();
                var empleados = await _empleadoService.GetEmpleados();
                empleados.Insert(0, new Empleado() { IdEmpleado = 0, NombreCompleto = "SELECCIONE UN EMPLEADO" });
                ViewBag.IdArea = new SelectList(areas, "IdArea", "Nombre", model.IdArea);
                ViewBag.IdJefe = new SelectList(empleados, "IdEmpleado", "NombreCompleto", model.IdJefe);
                return View(model);
            }

            return NotFound();
            
        }

        // POST: EmpeladosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm] UpdateEmpleadoRequest updateEmpleadoRequest)
        {
            try
            {
                var areas = await _areaService.GetAreas();
                var empleados = await _empleadoService.GetEmpleados();
                empleados.Insert(0, new Empleado() { IdEmpleado = 0, NombreCompleto = "SELECCIONE UN EMPLEADO" });
                ViewBag.IdArea = new SelectList(areas, "IdArea", "Nombre", updateEmpleadoRequest.IdArea);
                ViewBag.IdJefe = new SelectList(empleados, "IdEmpleado", "NombreCompleto", updateEmpleadoRequest.IdJefe);
                //Validacion de jefe
                if (updateEmpleadoRequest.IdEmpleado == updateEmpleadoRequest.IdJefe)
                {
                    ModelState.AddModelError("IdJefe", "Seleccione otro jefe por favor");
                    return View();
                }

                if (ModelState.IsValid)
                {

                    //mapeamos modelo
                    var empleado = await _empleadoService.GetEmpleadoById(updateEmpleadoRequest.IdEmpleado);
                    _mapper.Map(updateEmpleadoRequest, empleado);

                    if (updateEmpleadoRequest.IdJefe == 0) empleado.IdJefe = null;

                    await _empleadoService.EditarEmpleado(empleado);
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpeladosController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var empleado = await _empleadoService.GetEmpleadoById(id);
            if (empleado != null)
            {
                var model = _mapper.Map<DeleteEmpleadoRequest>(empleado);
                return View(model);
            }

            return NotFound();
        }

        // POST: EmpeladosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(DeleteEmpleadoRequest deleteEmpleadoRequest)
        {
            try
            {
                var empleadoExist = await _empleadoService.GetEmpleadoById(deleteEmpleadoRequest.IdEmpleado);
                if (empleadoExist != null)
                {
                    var empleado = _mapper.Map<Empleado>(empleadoExist);
                    await _empleadoService.DeleteEmpleado(empleado);
                    return RedirectToAction("Index");
                }

                return NotFound();

            }
            catch
            {
                return View();
            }
        }
    }
}
