using PruebaTecnicaNET.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaNET.BLO.Services
{
    public interface IEmpleadoService
    {
        List<Empleado> GetAll();

        Task<Empleado> AddAsync(Empleado empleado);

        Task<Empleado> UpdateAsync(Empleado empleado);
    }
}
