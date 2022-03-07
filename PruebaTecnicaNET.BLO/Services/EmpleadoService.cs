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
        private readonly IAreaRepository _areaRepository;

        public EmpleadoService(IEmpleadoRepository empleadoRepository, IAreaRepository areaRepository)
        {
            _empleadoRepository = empleadoRepository;
            _areaRepository = areaRepository;
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
            var empleado = await _empleadoRepository.GetEmpleadoById(id);
            if (empleado != null)
            {
                empleado.IdJefeNavigation = await _empleadoRepository.GetEmpleadoById(empleado.IdJefe ?? 0);
                empleado.IdAreaNavigation = await _areaRepository.GetAreaById(empleado.IdArea);
            }
           
            return empleado;
        }

        public async Task<List<Empleado>> GetEmpleados()
        {
            return await _empleadoRepository.GetEmpleados();
        }

        public string CalcularAnios(DateTime oldDate)
        {
            DateTime today = DateTime.Today;
            var days = (today - oldDate).TotalDays;
            double años = Math.Round((days / 365), 2);
            return años.ToString();
        }
    }
}
