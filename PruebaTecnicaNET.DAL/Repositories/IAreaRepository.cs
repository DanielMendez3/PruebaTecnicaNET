using PruebaTecnicaNET.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaNET.DAL.Repositories
{
    public interface IAreaRepository
    {
            Task<Area> GetAreaById(int id);

            Task<List<Area>> GetAreas();
    }
}
