using AutoMapper;
using BuiltCode.Application.Dto.PacienteViewModel;
using BuiltCode.Domain.Core.Notifications;
using BuiltCode.Domain.Models.PacienteAggregate;
using BuiltCode.Domain.Services.PacienteService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuiltCode.Application.AppServices.PacienteAppService
{
    public class PacienteAppService : BaseService, IPacienteAppService
    {
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public PacienteAppService(IPacienteService pacienteService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _pacienteService = pacienteService;
            _mapper = mapper;
        }

        public async Task<List<PacienteResponseViewModel>> ObterTodos()
        {
            var lista = await _pacienteService.ObterTodos();

            return _mapper.Map<List<PacienteResponseViewModel>>(lista);
        }

        public async Task<PacienteResponseViewModel> ObterPorId(Guid id)
        {
            var paciente = await _pacienteService.ObterPorId(id);

            return _mapper.Map<PacienteResponseViewModel>(paciente);
        }

        public async Task<List<PacienteResponseViewModel>> ObterPorMedico(Guid idMedico)
        {
            var lista = await _pacienteService.ObterPorMedico(idMedico);

            return _mapper.Map<List<PacienteResponseViewModel>>(lista);
        }

        public async Task<PacienteResponseViewModel> Cadastrar(PacienteRegistroViewModel viewModel)
        {
            var pacienteCpf = await _pacienteService.ObterPorCpf(viewModel.Cpf);

            if(pacienteCpf != null)
            {
                Notificar("Já existe outro paciente com CPF informado!");
                return null;
            }

            var paciente = _mapper.Map<Paciente>(viewModel);

            var result = await _pacienteService.Cadastrar(paciente);

            return _mapper.Map<PacienteResponseViewModel>(result);
        }

        public async Task<PacienteResponseViewModel> Atualizar(Guid id, PacienteRegistroViewModel viewModel)
        {
            var pacienteCpf = await _pacienteService.ObterPorCpf(viewModel.Cpf);

            if (pacienteCpf != null && pacienteCpf.Id != id)
            {
                Notificar("Já existe outro paciente com CPF informado!");
                return null;
            }

            var original = await _pacienteService.ObterPorId(id);

            original.Cpf = viewModel.Cpf;
            original.MedicoId = viewModel.MedicoId;
            original.Nome = viewModel.Nome;
            original.Telefone = viewModel.Telefone;

            var paciente = _mapper.Map<Paciente>(original);

            await _pacienteService.Atualizar(paciente);

            return _mapper.Map<PacienteResponseViewModel>(original);
        }

        public async Task Excluir(Guid id)
        {
            var original = await _pacienteService.ObterPorId(id);

            if(original == null)
            {
                Notificar("Não foi encontrado nenhum paciente com o ID informado!");
                return;
            }

            await _pacienteService.Excluir(original);
        }

        public void Dispose()
        {
            _pacienteService?.Dispose();
        }
    }
}
