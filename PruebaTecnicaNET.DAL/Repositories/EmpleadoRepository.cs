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

        public async Task<Empleado> AddAsync(Empleado empleado)
        {
           await  _examenContext.Empleado.AddAsync(empleado);
           await  _examenContext.SaveChangesAsync();
           return empleado;
        }

        public List<Empleado> GetAll()
        {
            return  _examenContext.Empleado.ToList();
        }

        public Task<Empleado> UpdateAsync(Empleado empleado)
        {
            throw new System.NotImplementedException();
        }
    }
}
