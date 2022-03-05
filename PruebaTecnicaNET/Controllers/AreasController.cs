using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaNET.BLO.Services;
using PruebaTecnicaNET.DAL.Models;
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

        public async  Task<ActionResult> Index()
        {
            var areas = await _areaService.GetAreas();
            var model = _mapper.Map<List<AreaResponse>>(areas);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] CreateAreaRequest areaRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //mapeamos modelo
                    var area = _mapper.Map<Area>(areaRequest);
                    await _areaService.CrearArea(area);
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var area = await _areaService.GetAreaById(id);
            if (area != null)
            {
                var model = _mapper.Map<EditAreaRequest>(area);
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditAreaRequest editAreaRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //mapeamos modelo
                    var area = _mapper.Map<Area>(editAreaRequest);
                    await _areaService.EditarArea(area);
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var area = await _areaService.GetAreaById(id);
            if (area != null)
            {
                var model = _mapper.Map<DeleteAreaRequest>(area);
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(DeleteAreaRequest deleteAreaRequest)
        {
            try
            {
                var areaExist = await _areaService.GetAreaById(deleteAreaRequest.IdArea);
                if (areaExist != null)
                {
                    var area = _mapper.Map<Area>(areaExist);
                    await _areaService.EliminarArea(area);
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
