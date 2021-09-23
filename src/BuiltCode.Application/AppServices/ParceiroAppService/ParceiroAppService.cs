using AutoMapper;
using BuiltCode.Application.Dto.ParceiroViewModel;
using BuiltCode.Domain.Core.Notifications;
using BuiltCode.Domain.Models.ParceiroAggregate;
using BuiltCode.Domain.Services.ParceiroService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuiltCode.Application.AppServices.ParceiroAppService
{
    public class ParceiroAppService : BaseService, IParceiroAppService
    {
        private readonly IParceiroService _parceiroService;
        private readonly IMapper _mapper;
        public ParceiroAppService(IParceiroService parceiroService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _parceiroService = parceiroService;
            _mapper = mapper;
        }

        public async Task<List<ParceiroResponseViewModel>> ObterTodos()
        {
            var lista = await _parceiroService.ObterTodos();

            return _mapper.Map<List<ParceiroResponseViewModel>>(lista);
        }

        public async Task<ParceiroResponseViewModel> Cadastrar(ParceiroRegistroViewModel registroViewModel)
        {
            var parceiro = _mapper.Map<Parceiro>(registroViewModel);

            parceiro.ApiKey = Guid.NewGuid();

            var result = await _parceiroService.Cadastrar(parceiro);

            return _mapper.Map<ParceiroResponseViewModel>(result);
           
        }

        public async Task<ParceiroResponseViewModel> AlterarApiKey(Guid id)
        {
            var original = await _parceiroService.ObterPorId(id);

            if(original == null)
            {
                Notificar("Não foi possível encontrar um parceiro com o ID informado");
                return null;
            }

            original.ApiKey = Guid.NewGuid();

            await _parceiroService.Atualizar(original);

            return _mapper.Map<ParceiroResponseViewModel>(original);
        }

        public void Dispose()
        {
            _parceiroService?.Dispose();
        }
    }
}
