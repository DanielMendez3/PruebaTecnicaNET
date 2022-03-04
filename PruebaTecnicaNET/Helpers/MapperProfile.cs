using AutoMapper;
using PruebaTecnicaNET.DAL.Models;
using PruebaTecnicaNET.ViewModels.AreasViewModel;
using PruebaTecnicaNET.ViewModels.EmpleadosViewModel;

namespace PruebaTecnicaNET.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //Source - Destination

            //Map Area Entity
            CreateMap<AreaResponse, Area>().ReverseMap();
            CreateMap<CreateAreaRequest, Area>().ReverseMap();

            //Map Empelado ENtity
            CreateMap<Empleado, EmpleadoResponse>();
        }
    }
}
