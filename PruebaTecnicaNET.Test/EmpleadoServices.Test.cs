using Moq;
using PruebaTecnicaNET.BLO.Services;
using PruebaTecnicaNET.DAL.Models;
using PruebaTecnicaNET.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebaTecnicaNET.Test
{
    public class EmpleadoServices
    {
        [Fact]
        public void CalculateYearsOld()
        {
            DateTime fechaNacimiento = DateTime.Parse("04/05/2000 0:00:00"); //obtenemos este valor desde bd
            DateTime today = DateTime.Parse("04/05/2018 0:00:00");
            var days = (today - fechaNacimiento).TotalDays;
            double años = Math.Round((days / 365),2);
            Assert.Equal(18.01, años);
        }

        [Fact]
        public void CalculateYearsWorked()
        {
            DateTime fechaNacimiento = DateTime.Parse("01/09/2021 0:00:00"); //obtenemos este valor desde bd
            DateTime today = DateTime.Parse("01/03/2022 0:00:00");
            var days = (today - fechaNacimiento).TotalDays;
            double años = Math.Round((days / 365), 2);
            Assert.Equal(0.5, años);
        }

        [Fact]
        public async Task TestGetEmpleadosAsync()
        {
            // Arrange
            var mockRepo = new Mock<IEmpleadoRepository>();
            var mockRepo2 = new Mock<IAreaRepository>();
            List<Empleado> empleados = await Multiple();
            mockRepo.Setup(repo => repo.GetEmpleados()).Returns(Multiple);
            var service = new EmpleadoService(mockRepo.Object, mockRepo2.Object);

            // Action
            var result = await service.GetEmpleados();

            // Assert
            var model = Assert.IsAssignableFrom<List<Empleado>>(result);
            Assert.Equal(3, model.Count);
        }

        private async Task<List<Empleado>> Multiple()
        {
            var r = new List<Empleado>();
            await Task.Run(()=>
                {

                    
                    r.Add(new Empleado()
                    {
                        IdEmpleado = 1,
                        NombreCompleto = "Test One",
                        Cedula = "SL1"
                    });
                    r.Add(new Empleado()
                    {
                        IdEmpleado = 2,
                        NombreCompleto = "Test Two",
                        Cedula = "SL2"
                    });
                    r.Add(new Empleado()
                    {
                        IdEmpleado = 3,
                        NombreCompleto = "Test Three",
                        Cedula = "SL3"
                    });
                });
            
            return r;
        }
    }
}
