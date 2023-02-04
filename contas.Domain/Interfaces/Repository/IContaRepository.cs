using contas_api_model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contas_api_model.Interfaces
{
    public interface IBillRepository
    {
        Task SaveAsync(Bill bill);
        Task UpdateAsync(Bill newBill, int oldBillId);
        Task<Bill> FindAsync(int id);
    }
}
