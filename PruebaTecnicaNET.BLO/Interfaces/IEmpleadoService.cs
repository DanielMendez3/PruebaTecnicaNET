using PruebaTecnicaNET.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaNET.BLO.Services
{
    public interface IEmpleadoService
    {
        Task<List<Empleado>> GetEmpleados();

        Task<Empleado> AgregarEmpleado(Empleado empleado);

        Task EditarEmpleado(Empleado empleado);
        Task DeleteEmpleado(Empleado empleado);
        Task<Empleado> GetEmpleadoById(int id);
    }
}
