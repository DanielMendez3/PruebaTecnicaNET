using PruebaTecnicaNET.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaNET.BLO.Services
{
    public interface IAreaService
    {
        Task<Area> GetAreaById(int id);

        Task<List<Area>> GetAreas();
    }
}
