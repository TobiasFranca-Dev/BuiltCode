using AutoMapper;
using BuiltCode.Application.Dto.UsuariosViewModel;
using BuiltCode.Domain.Core.Notifications;
using BuiltCode.Domain.Models.UsuarioAggregate;
using BuiltCode.Domain.Models.UsuarioAggregate.Enums;
using BuiltCode.Domain.Services.UsuarioService;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuiltCode.Application.AppServices.UsuarioAppService
{
    public class UsuarioAppService : BaseService, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public UsuarioAppService(IUsuarioService usuarioService, IMapper mapper, IOptions<AppSettings> appSettings, INotificador notificador): base(notificador)
        {
            _usuarioService = usuarioService;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public async Task<UsuarioListViewModel> Adicionar(UsuarioRegistroViewModel usuarioRegistro)
        {
            var usuarioEmailExist = await _usuarioService.ObterPorEmail(usuarioRegistro.Email);

            if(usuarioEmailExist != null)
            {
                Notificar("Email informado já cadastrado!");
                return null;
            }

            usuarioRegistro.Senha = HashService.GerarHash(usuarioRegistro.Senha);

            var usuario = _mapper.Map<Usuario>(usuarioRegistro);

            return _mapper.Map<UsuarioListViewModel>(await _usuarioService.Cadastrar(usuario));             
        }

        public async Task<UserLoginResponseViewModel> Login(LoginViewModel viewModel)
        {
            var user = await _usuarioService.Login(viewModel.Email, HashService.GerarHash(viewModel.Password));

            if (user == null)
            {
                Notificar("Usuário ou senha inválido!");
                return null;
            }

            var token = TokenService.GerarToken(user, _appSettings);

            return new UserLoginResponseViewModel
            {
                AccessToken = token,
                ExpiresIn = DateTime.UtcNow.AddHours(_appSettings.ExpiresIn).ToString(),
                UserInfo = new
                {
                    Email = user.Email,
                    Name = user.Nome,
                    Perfil = Enum.GetName(typeof(EPerfil), user.Perfil)
                }
            };
        }

        public async Task<List<UsuarioListViewModel>> ObterTodos()
        {
            var lista = await _usuarioService.ObterTodos();
            return _mapper.Map<List<UsuarioListViewModel>>(lista);
        }

        public void Dispose()
        {
            _usuarioService?.Dispose();
        }
    }
}
