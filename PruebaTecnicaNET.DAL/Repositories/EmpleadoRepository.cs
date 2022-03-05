using Microsoft.EntityFrameworkCore;
using PruebaTecnicaNET.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaNET.DAL.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        protected readonly ExamenContext _examenContext;

        public EmpleadoRepository(ExamenContext examenContext)
        {
            this._examenContext = examenContext;
        }

        public async Task<Empleado> AddEmpleado(Empleado empleado)
        {
           await  _examenContext.Empleado.AddAsync(empleado);
           await  _examenContext.SaveChangesAsync();
           return empleado;
        }

        public async Task<List<Empleado>> GetEmpleados()
        {
            return await _examenContext.Empleado.ToListAsync();
        }

        public async Task UpdateEmpleado(Empleado empleado)
        {
             _examenContext.Entry(empleado).State = EntityState.Modified;
            await _examenContext.SaveChangesAsync();
        }

        public async Task<Empleado> GetEmpleadoById(int id)
        {
            return await _examenContext.Empleado.FirstOrDefaultAsync(x => x.IdEmpleado == id);
        }

        public async Task DeleteEmpleado(Empleado empleado)
        {
             _examenContext.Empleado.Remove(empleado);
            await _examenContext.SaveChangesAsync();
        }
    }
}
