using contas_api_model.Entity;
using contas_api_model.Enums;
using contas_api_model.Interfaces;
using contas_api_model.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contas_api_model.Services
{
    public class BillService : IBillService
    {

        private IBillRepository _billRepository;

        public BillService(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public async Task SaveAsync(Bill bill)
        {
            if (bill.TypePaymentId == (int)HelperEnum.FormaPagamentoEnum.PARCELADO && !bill.PortionCount.HasValue)
            {
                throw new Exception("Não é possível salvar uma conta parcelada com o número de parcelas zerado!");
            }

            if (bill.ExpirationDate < DateTime.UtcNow)
            {
                throw new Exception("Não é possível salvar uma conta com a data de vencimento menor que a data de hoje!");
            }

            await _billRepository.SaveAsync(bill);
        }

        public Task<Bill> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Bill>> ListByUserAsync(int userId, DateTime? initialData, DateTime? finalDate, int? statusBill)
        {
            throw new NotImplementedException();
        }
    }
}
