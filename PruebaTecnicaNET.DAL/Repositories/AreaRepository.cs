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

        public async Task CrearArea(Area area)
        {
            await _examenContext.Area.AddAsync(area);
            await _examenContext.SaveChangesAsync();
        }

        public async Task EditarArea(Area area)
        {
            _examenContext.Entry(area).State = EntityState.Modified;
            await _examenContext.SaveChangesAsync();
        }

        public async Task EliminarArea(Area area)
        {
             _examenContext.Area.Remove(area);
            await _examenContext.SaveChangesAsync();
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
