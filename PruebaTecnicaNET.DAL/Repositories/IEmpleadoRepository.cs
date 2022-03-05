using PruebaTecnicaNET.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaNET.DAL.Repositories
{
    public interface IEmpleadoRepository
    {
        Task<List<Empleado>> GetEmpleados();

        Task<Empleado> AddEmpleado(Empleado empleado);

        Task UpdateEmpleado(Empleado empleado);
        Task DeleteEmpleado(Empleado empleado);
        Task<Empleado> GetEmpleadoById(int id);
    }
}
