using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.DTOs.Animal;
using CleanArchMvc.Application.DTOs.CompraGado;
using CleanArchMvc.Application.DTOs.Pecuarista;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category          , CategoryDTO>().ReverseMap();
            CreateMap<Product           , ProductDTO>().ReverseMap();
            
            CreateMap<Animal            , AnimalDTO>().ReverseMap();
            CreateMap<Animal            , AnimalDTOCreate>().ReverseMap();

            CreateMap<Pecuarista        , PecuaristaDTO>().ReverseMap();
            CreateMap<Pecuarista        , PecuaristaDTOCreate>().ReverseMap();
            
            CreateMap<CompraGado        , CompraGadoDTO>().ReverseMap();
            CreateMap<CompraGadoItemDTO , CompraGadoItemDTO>().ReverseMap();
        }
    }
}
