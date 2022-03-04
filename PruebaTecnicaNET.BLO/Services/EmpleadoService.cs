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

        public async Task<Empleado> AddAsync(Empleado empleado)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> GetAll()
        {
            return _empleadoRepository.GetAll();
        }

        public Task<Empleado> UpdateAsync(Empleado empleado)
        {
            throw new NotImplementedException();
        }
    }
}
