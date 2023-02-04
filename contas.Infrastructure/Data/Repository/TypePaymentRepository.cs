using contas_api_model.Entity;
using System;
using System.Threading.Tasks;

namespace contas_api_model.Repository
{
    public class TypePaymentRepository
    {
        private MySqlContext _context;

        public async Task Save(TypePayment typePayment)
        {
            await _context.TypePayments.AddAsync(typePayment);
            await _context.SaveChangesAsync();
        }
    }
}
