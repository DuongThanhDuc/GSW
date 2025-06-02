using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessModel.Model
{
    public class DBContext: IdentityDbContext
    {

        public DBContext()
        {

        }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("GameSalesWebsite"));
        }

        public DbSet<SystemTag> System_Tags { get; set; }
        public DbSet<SystemCategory> System_Categories { get; set; }
        public DbSet<GamesInfo> Games_Info { get; set; }
        public DbSet<GamesCategory> Games_Categories { get; set; }
        public DbSet<GamesTag> Games_Tags { get; set; }
        public DbSet<GamesReview> Games_Reviews { get; set; }
        public DbSet<GamesUpload> Games_Uploads { get; set; }
        public DbSet<StoreOrder> Store_Orders { get; set; }
        public DbSet<StoreOrderDetail> Store_OrderDetails { get; set; }
        public DbSet<StoreRefundRequest> Store_RefundRequests { get; set; }
        public DbSet<StoreTransaction> Store_Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optional: Add constraints or indexes if needed
            modelBuilder.Entity<SystemTag>()
                .Property(t => t.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<SystemCategory>()
                .Property(c => c.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<GamesInfo>()
                .Property(g => g.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<GamesCategory>()
                .Property(gc => gc.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<GamesTag>()
                .Property(gt => gt.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<GamesReview>()
                .Property(r => r.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<GamesUpload>()
                .Property(u => u.UploadDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<StoreOrder>()
                .Property(o => o.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<StoreOrder>()
                .Property(o => o.OrderDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<StoreOrderDetail>()
                .Property(d => d.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<StoreRefundRequest>()
                .Property(r => r.RequestDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<StoreTransaction>()
                .Property(t => t.TransactionDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}

