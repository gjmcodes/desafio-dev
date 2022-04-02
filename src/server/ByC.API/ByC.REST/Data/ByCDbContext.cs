using ByC.Domain.Transactions.Entities;
using Microsoft.EntityFrameworkCore;

namespace ByC.REST.Data
{
    public class ByCDbContext : DbContext
    {
        public ByCDbContext(DbContextOptions<ByCDbContext> options)
           : base(options)
        {

        }
        public DbSet<TransactionRoot> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionRoot>().HasKey(t => t.Id);
            modelBuilder.Entity<TransactionRoot>().Property(p => p.Type)
                .IsRequired()
                .HasMaxLength(1);
            modelBuilder.Entity<TransactionRoot>().Property(p => p.Date)
               .IsRequired();
            modelBuilder.Entity<TransactionRoot>().Property(p => p.Value)
                .IsRequired()
                .HasPrecision(12, 2);
            modelBuilder.Entity<TransactionRoot>().Property(p => p.Document)
                .IsRequired()
                .HasMaxLength(11);
            modelBuilder.Entity<TransactionRoot>().Property(p => p.Card)
                .IsRequired()
                .HasMaxLength(12);
            modelBuilder.Entity<TransactionRoot>().Property(p => p.Hour)
                .IsRequired()
                .HasMaxLength(6);
            modelBuilder.Entity<TransactionRoot>().Property(p => p.StoreOwnerName)
                .IsRequired()
                .HasMaxLength(14);
            modelBuilder.Entity<TransactionRoot>().Property(p => p.StoreName)
              .IsRequired()
              .HasMaxLength(18);
            modelBuilder.Entity<TransactionRoot>().Ignore(p => p.cnab);

            base.OnModelCreating(modelBuilder);
        }
    }
}
