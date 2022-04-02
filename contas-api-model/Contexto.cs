using contas_api_model.Entity;
using Microsoft.EntityFrameworkCore;

namespace contas_api_model
{
    public class Contexto : DbContext
    {
        public DbSet<Conta> Contas { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }
        public DbSet<SituacaoParcela> SituacaoParcelas { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    }
}
