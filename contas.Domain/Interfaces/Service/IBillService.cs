using contas_api_model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace contas_api_model.Interfaces.Service
{
    public interface IBillService
    {
        Task SaveAsync(Bill bill);

        Task<Bill> FindAsync(int id);

        Task<List<Bill>> ListByUserAsync(int userId, DateTime? initialData, DateTime? finalDate, int? statusBill);
    }
}
