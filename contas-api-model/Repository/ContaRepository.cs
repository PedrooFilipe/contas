using contas_api_model.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contas_api_model.Entity
{
    public class ContaRepository : IContaRepository
    {
        private Contexto _contexto;

        public ContaRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void VerifyIfCanUpdate(Conta conta)
        {
            if (conta == null)
            {
                throw new Exception("Erro ao alterar conta!");
            }
        }

        public async Task Salvar(Conta conta)
        {
            await _contexto.Contas.AddAsync(conta);
            await _contexto.SaveChangesAsync();
        }


        public async Task Alterar(Conta conta, int contaIdAntigo)
        {
            VerifyIfCanUpdate(conta);
            try
            {
                Conta contaAntiga = await this.Procurar(contaIdAntigo);
                if (contaAntiga != null)
                {
                    conta.Id = contaAntiga.Id;

                    _contexto.Entry(conta).State = EntityState.Modified;
                    await _contexto.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Conta não encontrada!");
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Conta> Procurar(int id)
        {
            return await _contexto.Contas.Where(c => c.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

    }
}
