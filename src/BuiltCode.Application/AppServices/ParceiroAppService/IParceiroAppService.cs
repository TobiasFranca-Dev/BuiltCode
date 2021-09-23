using BuiltCode.Application.Dto.ParceiroViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuiltCode.Application.AppServices.ParceiroAppService
{
    public interface IParceiroAppService: IDisposable
    {
        Task<List<ParceiroResponseViewModel>> ObterTodos();
        Task<ParceiroResponseViewModel> Cadastrar(ParceiroRegistroViewModel registroViewModel);
        Task<ParceiroResponseViewModel> AlterarApiKey(Guid id);
    }
}
