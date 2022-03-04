using Microsoft.EntityFrameworkCore;
using PruebaTecnicaNET.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaNET.DAL.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        protected readonly ExamenContext _examenContext;

        public AreaRepository(ExamenContext examenContext)
        {
            this._examenContext = examenContext;
        }

        public async Task<Area> GetAreaById(int id)
        {
            return await  _examenContext.Area.FirstOrDefaultAsync(x => x.IdArea == id);
        }

        public async Task<List<Area>> GetAreas()
        {
            return await _examenContext.Area.ToListAsync();
        }
    }
}
