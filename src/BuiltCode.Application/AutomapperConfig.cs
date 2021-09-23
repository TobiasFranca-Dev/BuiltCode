using AutoMapper;
using BuiltCode.Application.Dto.UsuariosViewModel;
using BuiltCode.Domain.Models.UsuarioAggregate;
using BuiltCode.Domain.Models.UsuarioAggregate.Enums;
using System;

namespace BuiltCode.Application
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<UsuarioListViewModel, Usuario>().ReverseMap()
                .ForMember(dest => dest.Perfil, opt => opt.MapFrom(src=> Enum.GetName(typeof(EPerfil), src.Perfil)));
        }
    }
}
