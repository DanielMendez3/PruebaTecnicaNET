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
            CreateMap<EditAreaRequest, Area>().ReverseMap();
            CreateMap<DeleteAreaRequest, Area>().ReverseMap();

            //Map Empleado ENtity
            CreateMap<Empleado, EmpleadoResponse>();
            CreateMap<CreateEmpleadoRequest, Empleado>();
            CreateMap<DeleteEmpleadoRequest, Empleado>().ReverseMap();
            CreateMap<Empleado, UpdateEmpleadoRequest>();
            CreateMap<UpdateEmpleadoRequest, Empleado>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignoramos propiedades null
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));
        }
    }
}
