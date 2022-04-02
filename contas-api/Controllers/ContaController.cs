using contas_api_model.Entity;
using contas_api_model.Interfaces;
using contas_api_model.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contas_api.Controllers
{
    [Route("contas")]
    public class ContaController : ControllerBase
    {
        private IContaRepository _contaRepository;
        public ContaController(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        [Route("salvar")]
        public async Task<RestResponse<Conta>> Salvar(Conta conta)
        {
            RestResponse<Conta> restResponse = new RestResponse<Conta>();
            try
            {
                await _contaRepository.Salvar(conta);
                restResponse.Message = "Sucesso!";
                restResponse.ResponseCode = 200;
            }
            catch
            {
                restResponse.Message = "Erro na requisição!";
                restResponse.ResponseCode = 500;
            }

            return restResponse;
        }
    }
}
