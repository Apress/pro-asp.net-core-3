using Microsoft.EntityFrameworkCore;

namespace Platform.Models {

    public class CalculationContext : DbContext {

        public CalculationContext(DbContextOptions<CalculationContext> opts)
            : base(opts) { }

        public DbSet<Calculaton> Calculations { get; set; }
    }
}
