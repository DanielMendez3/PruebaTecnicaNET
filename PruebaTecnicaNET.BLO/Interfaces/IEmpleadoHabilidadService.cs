using PruebaTecnicaNET.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaNET.BLO.Interfaces
{
    public interface IEmpleadoHabilidadService
    {
        Task<IEnumerable<Jerarquia>> GetJerarquia();
        Task<IEnumerable<EmpleadoHabilidad>> GetHabilidadesByEmpleadoId(int IdEmpleado);
        Task<EmpleadoHabilidad> GetHabilidad(int IdHabilidad);
        Task AddHabilidadByEmpleado(EmpleadoHabilidad empleadoHabilidad);
        Task DeleteHabilidadEmpleado(EmpleadoHabilidad empleadoHabilidad);
    }
}
