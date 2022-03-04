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
