using contas_api_model.Entity;
using Microsoft.EntityFrameworkCore;

namespace contas_api_model
{
    public class MySqlContext : DbContext
    {
        public DbSet<Bill> Bills { get; set; }
        public DbSet<TypePayment> FormaPagamento { get; set; }
        public DbSet<Payment> Pagamentos { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }
        public DbSet<StatusPortion> SituacaoParcelas { get; set; }
        public DbSet<User> Users { get; set; }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
    }
}
