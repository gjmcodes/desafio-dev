using ByC.Domain.Transactions.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ByC.REST.Data
{
    public class ByCDbContext : DbContext
    {
        public ByCDbContext(DbContextOptions<ByCDbContext> options)
           : base(options)
        {

        }
        public DbSet<TransactionRoot> Transactions { get; set; }
        public DbSet<CnabRoot> Cnabs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if MIGRATIONS
            Environment.SetEnvironmentVariable("DB_CONN", "server=localhost;port=3307;database=byc_db;uid=root;pwd=root");
#endif
            string connString = Environment.GetEnvironmentVariable("DB_CONN");

            if (string.IsNullOrEmpty(connString))
                throw new Exception("DB_CONN is empty");

            optionsBuilder.UseMySql(connString, ServerVersion.AutoDetect(connString));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder = BuildTransactionRoot(modelBuilder);
            modelBuilder = BuildCnabRoot(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        ModelBuilder BuildTransactionRoot(ModelBuilder modelBuilder)
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

            return modelBuilder;
        }

        ModelBuilder BuildCnabRoot(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CnabRoot>().HasKey(p => p.Value);
            modelBuilder.Entity<CnabRoot>().Property(p => p.Value).IsRequired();
            modelBuilder.Entity<CnabRoot>().HasMany(p => p.TransactionRoots)
                .WithOne(p => p.Cnab)
                .HasForeignKey(p => p.CnabId)
                .OnDelete(DeleteBehavior.Cascade);

            return modelBuilder;
        }


    }
}
