using PruebaTecnicaNET.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaNET.DAL.Repositories
{
    public interface IEmpleadoRepository
    {
        List<Empleado> GetAll();

        Task<Empleado> AddAsync(Empleado empleado);

        Task<Empleado> UpdateAsync(Empleado empleado);
    }
}
