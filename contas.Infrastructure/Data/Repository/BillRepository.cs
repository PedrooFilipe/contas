using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contas_api_model.Entity;
using contas_api_model.Enums;
using contas_api_model.Interfaces;

namespace contas_api_model.Repository
{
    public class BillRepository : IBillRepository
    {
        private MySqlContext _context;

        public BillRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(Bill bill)
        {
            await _context.Bills.AddAsync(bill);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(Bill bill, int oldBillId)
        {
            using (var t  = _context.Database.BeginTransaction())
            {
                try
                {
                    Bill oldBill = await FindAsync(oldBillId);
                    if(oldBill == null)
                    {
                        throw new Exception("Record not found!");
                    }

                    bill.Id = oldBill.Id;

                    _context.Entry(bill).State = EntityState.Modified;
                    await _context.SaveChangesAsync();                   

                    t.Commit();
                }
                catch (Exception)
                {
                    t.Rollback();
                    throw;
                }
            }
        }

        public async Task<Bill> FindAsync(int id)
        {
            return await _context.Bills.Where(c => c.Id == id).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<Bill>> ListByUserAsync(int userId)
        {
            return null;
        }

    }
}
