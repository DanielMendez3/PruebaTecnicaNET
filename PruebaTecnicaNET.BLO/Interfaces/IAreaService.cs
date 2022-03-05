using PruebaTecnicaNET.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaNET.BLO.Services
{
    public interface IAreaService
    {
        Task<Area> GetAreaById(int id);

        Task<List<Area>> GetAreas();

        Task CrearArea(Area area);
        Task EditarArea(Area area);
        Task EliminarArea(Area area);
    }
}
