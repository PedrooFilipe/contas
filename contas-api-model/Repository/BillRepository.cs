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
        private Contexto _contexto;

        public BillRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void VerificaSeNumeroDeParcelasEstaZerado(Bill bill)
        {
            if(bill.FormaPagamentoId == (int)HelperEnum.FormaPagamentoEnum.PARCELADO && !bill.NumeroParcelas.HasValue) 
            {
                throw new Exception("Não é possível salvar uma bill parcelada com o número de parcelas zerado!");
            }
        }
        
        public void VerificaDataDeValidade(Bill bill)
        {
            if(bill.DataValidade > DateTime.UtcNow) 
            {
                throw new Exception("Não é possível salvar uma bill com a data de vencimento maior que a data de hoje!");
            }
        }

        public async Task Save(Bill bill)
        {
            VerificaSeNumeroDeParcelasEstaZerado(bill);
            VerificaDataDeValidade(bill);

            await _contexto.Bills.AddAsync(bill);
            await _contexto.SaveChangesAsync();
        }


        public async Task Update(Bill bill, int oldBillId)
        {
            using (var t  = _contexto.Database.BeginTransaction())
            {
                try
                {
                    Bill oldBill = await this.Find(oldBillId);
                    if (oldBill != null)
                    {
                        bill.Id = oldBill.Id;

                        _contexto.Entry(bill).State = EntityState.Modified;
                        await _contexto.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("Record not found!");
                    }

                    t.Commit();
                }
                catch (Exception e)
                {
                    t.Rollback();
                    throw;
                }
            }
        }

        public async Task<Bill> Find(int id)
        {
            return await _contexto.Bills.Where(c => c.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<List<Bill>> ListByUser(int userId)
        {
          
            List<Bill> bills = await _contexto.Bills.Where(b => b.u)

        };

    }
}
