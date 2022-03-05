using PruebaTecnicaNET.DAL.Models;
using PruebaTecnicaNET.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaNET.BLO.Services
{
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository _areaRepository;

        public AreaService(IAreaRepository areaRepository)
        {
            this._areaRepository = areaRepository;
        }

        public async Task CrearArea(Area area)
        {
            await _areaRepository.CrearArea(area);
        }

        public async Task EditarArea(Area area)
        {
            await _areaRepository.EditarArea(area);
        }

        public async Task EliminarArea(Area area)
        {
            await _areaRepository.EliminarArea(area);
        }

        public async Task<Area> GetAreaById(int id)
        {
            return await _areaRepository.GetAreaById(id);
        }

        public async Task<List<Area>> GetAreas()
        {
            return await _areaRepository.GetAreas();
            
        }
    }
}
