using PruebaTecnicaNET.BLO.Interfaces;
using PruebaTecnicaNET.DAL.Models;
using PruebaTecnicaNET.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNET.BLO.Services
{
    public class EmpleadoHabilidadService : IEmpleadoHabilidadService
    {
        private readonly IEmpleadoHabilidadRepository _empleadoHabilidadRepository;

        public EmpleadoHabilidadService(IEmpleadoHabilidadRepository empleadoHabilidadRepository)
        {
            _empleadoHabilidadRepository = empleadoHabilidadRepository;
        }

        public async Task AddHabilidadByEmpleado(EmpleadoHabilidad empleadoHabilidad)
        {
           await _empleadoHabilidadRepository.AddHabilidadByEmpleado(empleadoHabilidad);
        }

        public async Task DeleteHabilidadEmpleado(EmpleadoHabilidad empleadoHabilidad)
        {
            await _empleadoHabilidadRepository.DeleteHabilidadEmpleado(empleadoHabilidad);
        }

        public async Task<EmpleadoHabilidad> GetHabilidad(int IdHabilidad)
        {
            return await _empleadoHabilidadRepository.GetHabilidad(IdHabilidad);
        }

        public async Task<IEnumerable<EmpleadoHabilidad>> GetHabilidadesByEmpleadoId(int IdEmpleado)
        {
            return await _empleadoHabilidadRepository.GetHabilidadesByEmpleadoId(IdEmpleado);
        }

        public async Task<IEnumerable<Jerarquia>> GetJerarquia()
        {
            return await _empleadoHabilidadRepository.GetJerarquia();
        }
    }
}
