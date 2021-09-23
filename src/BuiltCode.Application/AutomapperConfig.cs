using AutoMapper;
using BuiltCode.Application.Dto.MedicoViewModel;
using BuiltCode.Application.Dto.PacienteViewModel;
using BuiltCode.Application.Dto.ParceiroViewModel;
using BuiltCode.Application.Dto.UsuariosViewModel;
using BuiltCode.Domain.Models.MedicoAggregate;
using BuiltCode.Domain.Models.PacienteAggregate;
using BuiltCode.Domain.Models.ParceiroAggregate;
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

            CreateMap<UsuarioRegistroViewModel, Usuario>().ReverseMap()
                .ForMember(dest => dest.Perfil, opt => opt.MapFrom(src => Enum.GetName(typeof(EPerfil), src.Perfil)));


            CreateMap<Parceiro, ParceiroRegistroViewModel>().ReverseMap();
            CreateMap<Parceiro, ParceiroResponseViewModel>().ReverseMap();


            CreateMap<Medico, MedicoResponseViewModel>().ReverseMap();
            CreateMap<Medico, MedicoRegistroViewModel>().ReverseMap();


            CreateMap<Paciente, PacienteResponseViewModel>().ReverseMap();
            CreateMap<Paciente, PacienteRegistroViewModel>().ReverseMap();
        }
    }
}
