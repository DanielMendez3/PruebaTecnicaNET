using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaNET.BLO.Services;
using PruebaTecnicaNET.ViewModels.AreasViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaNET.Controllers
{
    public class AreasController : Controller
    {
        private readonly IAreaService _areaService;
        private readonly IMapper _mapper;
        public AreasController(IAreaService areaService, IMapper mapper)
        {
            _areaService = areaService;
            _mapper = mapper;
        }

        // GET: AreasController
        public async  Task<ActionResult> Index()
        {
            var areas = await _areaService.GetAreas();
            var viewModel = _mapper.Map<List<AreaResponse>>(areas);
            return View(viewModel);
        }

        // GET: AreasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AreasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreasController/Create
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

        // GET: AreasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AreasController/Edit/5
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

        // GET: AreasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AreasController/Delete/5
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
