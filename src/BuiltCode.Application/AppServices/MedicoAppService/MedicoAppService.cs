using AutoMapper;
using BuiltCode.Application.AppServices.PacienteAppService;
using BuiltCode.Application.Dto.MedicoViewModel;
using BuiltCode.Domain.Core.Notifications;
using BuiltCode.Domain.Models.MedicoAggregate;
using BuiltCode.Domain.Services.MedicoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuiltCode.Application.AppServices.MedicoAppService
{
    public class MedicoAppService: BaseService, IMedicoAppService
    {
        private readonly IMedicoService _medicoService;
        private readonly IPacienteAppService _pacienteAppService;
        private IMapper _mapper;

        public MedicoAppService(IMapper mapper, IPacienteAppService pacienteAppService, IMedicoService medicoService, INotificador notificador) : base(notificador)
        {
            _medicoService = medicoService;
            _pacienteAppService = pacienteAppService;
            _mapper = mapper;
        }

        public async Task<List<MedicoResponseViewModel>> ObterTodos()
        {
            var lista = await _medicoService.ObterTodos();

            return _mapper.Map<List<MedicoResponseViewModel>>(lista);
        }

        public async Task<MedicoResponseViewModel> Cadastrar(MedicoRegistroViewModel viewModel)
        {
            var medicosPorCrm = await _medicoService.ObterPorCrm(viewModel.Crm, viewModel.UfCrm);

            if(medicosPorCrm != null)
            {
                Notificar("Já existe um cadastro com o CRM e UF informado!");
                return null;
            }

            var medico = _mapper.Map<Medico>(viewModel);

            var result = await _medicoService.Cadastrar(medico);

            return _mapper.Map<MedicoResponseViewModel>(result);
        }

        public async Task<MedicoResponseViewModel> Atualizar(Guid id, MedicoRegistroViewModel viewModel)
        {
            var medicoPorCrm = await _medicoService.ObterPorCrm(viewModel.Crm, viewModel.UfCrm);

            if(medicoPorCrm != null && medicoPorCrm.Id != id)
            {
                Notificar("Já existe outro cadastro com o CRM e UF Crm informado!");
                return null;
            }

            var original = await _medicoService.ObterPorId(id);

            original.Especialidade = viewModel.Especialidade;
            original.Crm = viewModel.Crm;
            original.UfCrm = viewModel.UfCrm;
            original.Nome = viewModel.Nome;

            await _medicoService.Atualizar(original);

            return _mapper.Map<MedicoResponseViewModel>(original);            
        }

        public async Task Excluir(Guid id)
        {
            var pacientes = await _pacienteAppService.ObterPorMedico(id);

            if (pacientes.Any())
            {
                Notificar("Não é possível excluir um médico associado a um ou mais pacientes!");
                return;
            }

            var original = await _medicoService.ObterPorId(id);

            if(original == null)
            {
                Notificar("Nenhum médico encontrado com o ID informado!");
                return;
            }

            await _medicoService.Excluir(original);
        }

        public void Dispose()
        {
            _medicoService?.Dispose();
            _pacienteAppService?.Dispose();
        }

        public async Task<List<MedicoResponseViewModel>> ObterPorUfCrm(string ufCrm)
        {
            var lista = await _medicoService.ObterPorUfCrm(ufCrm);

            return _mapper.Map<List<MedicoResponseViewModel>>(lista);
        }
    }
}
