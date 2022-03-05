using PruebaTecnicaNET.DAL.Models;
using PruebaTecnicaNET.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaNET.BLO.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public async Task<Empleado> AgregarEmpleado(Empleado empleado)
        {
            return await _empleadoRepository.AddEmpleado(empleado);
        }

        public async Task DeleteEmpleado(Empleado empleado)
        {
            await _empleadoRepository.DeleteEmpleado(empleado);
        }

        public async Task EditarEmpleado(Empleado empleado)
        {
           await _empleadoRepository.UpdateEmpleado(empleado);
        }

        public async Task<Empleado> GetEmpleadoById(int id)
        {
            return await _empleadoRepository.GetEmpleadoById(id);
        }

        public async Task<List<Empleado>> GetEmpleados()
        {
            return await _empleadoRepository.GetEmpleados();
        }
    }
}
