using contas_api_model.Entity;
using Microsoft.EntityFrameworkCore;

namespace contas_api_model
{
    public class MySqlContext : DbContext
    {
        public DbSet<Bill> Bills { get; set; }
        public DbSet<TypePayment> TypePayments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Portion> Portions { get; set; }
        public DbSet<StatusPortion> SituacaoParcelas { get; set; }
        public DbSet<User> Users { get; set; }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
    }
}
