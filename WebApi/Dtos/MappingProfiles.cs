using AutoMapper;
using CoreEntities.Entities;

namespace WebApi.Dtos
{
    public class MappingProfiles : Profile
    {
        //instalamos en el paqute nuggets AutoMapper
        public MappingProfiles()
        {
            CreateMap<Producto, ProductoDto>()
                .ForMember(p => p.CategoriaNombre, X => X.MapFrom(a => a.Categoria.Nombre))//tenemos que irlo a llamar desde program.cs  en configureservices
                .ForMember(p => p.MarcaNombre, X => X.MapFrom(a => a.Marca.Nombre));//tenemos que irlo a llamar desde program.cs  en configureservices
        }
    }
}