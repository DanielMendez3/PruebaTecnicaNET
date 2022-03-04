using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaNET.BLO.Services;
using PruebaTecnicaNET.ViewModels.EmpleadosViewModel;
using System.Collections.Generic;

namespace PruebaTecnicaNET.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IMapper _mapper;
        public EmpleadosController(IEmpleadoService empleadoService, IMapper mapper)
        {
            _empleadoService = empleadoService;
            _mapper = mapper;
        }
        // GET: EmpeladosController
        public ActionResult Index()
        {
            var empleados = _empleadoService.GetAll();
            var viewModel = _mapper.Map<List<EmpleadoResponse>>(empleados);
            return View(viewModel);
        }

        // GET: EmpeladosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpeladosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpeladosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpeladosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpeladosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpeladosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpeladosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
