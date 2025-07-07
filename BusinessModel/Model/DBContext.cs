using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessModel.Model
{
    public class DBContext : IdentityDbContext
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
        public DbSet<StoreCart> Store_Cart { get; set; }
        public DbSet<StoreThread> Store_Threads { get; set; }
        public DbSet<StoreThreadReply> Store_ThreadReplies { get; set; }

        public DbSet<GamesMedia> Games_Media { get; set; }
        public DbSet<StoreLibrary> Store_Library { get; set; }
        public DbSet<SystemTokenRefresh> System_TokenRefreshes { get; set; }

        public DbSet<GamesDiscount> Games_Discount { get; set; }
        public DbSet<GamesBanner> Games_Banner { get; set; }
        public DbSet<GamesInfoDiscount> Games_InfoDiscounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Constraints
            modelBuilder.Entity<SystemTag>()
                .Property(t => t.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<SystemCategory>()
                .Property(c => c.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<GamesInfo>()
                .Property(g => g.CreatedAt)
                .HasDefaultValueSql("GETDATE()");


            modelBuilder.Entity<GamesMedia>()
           .Property(m => m.CreatedAt)
           .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<GamesMedia>()
                .HasOne(m => m.Game)
                .WithMany()
                .HasForeignKey(m => m.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StoreLibrary>()
            .Property(l => l.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<StoreLibrary>()
                .HasOne(l => l.Game)
                .WithMany()
                .HasForeignKey(l => l.GamesID)
                .OnDelete(DeleteBehavior.Cascade);

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
            modelBuilder.Entity<StoreThread>()
                 .Property(t => t.CreatedAt)
                 .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<StoreThread>()
                 .Property(t => t.ThreadTitle)
                 .IsRequired();

            modelBuilder.Entity<StoreThread>()
                .Property(t => t.ThreadDescription)
                .IsRequired();

            modelBuilder.Entity<StoreThread>()
                .Property(t => t.CreatedBy)
                .IsRequired();

            modelBuilder.Entity<StoreThreadReply>()
                .Property(r => r.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<StoreThreadReply>()
                .HasOne(r => r.StoreThread)
                .WithMany(t => t.Replies)
                .HasForeignKey(r => r.ThreadID)
                .OnDelete(DeleteBehavior.Cascade);

            // Optional: Add constraints
            modelBuilder.Entity<StoreThreadReply>()
                .Property(r => r.ThreadComment)
                .IsRequired();

            modelBuilder.Entity<StoreThreadReply>()
                .Property(r => r.CreatedBy)
                .IsRequired();

            modelBuilder.Entity<SystemTokenRefresh>()
                .Property(t => t.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<SystemTokenRefresh>()
                .Property(t => t.UpdatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<GamesInfoDiscount>()
    .HasKey(gid => new { gid.GamesInfoId, gid.GamesDiscountId });

            modelBuilder.Entity<GamesInfoDiscount>()
                .HasOne(gid => gid.GamesInfo)
                .WithMany(g => g.GamesInfoDiscounts)
                .HasForeignKey(gid => gid.GamesInfoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GamesInfoDiscount>()
                .HasOne(gid => gid.GamesDiscount)
                .WithMany(d => d.GamesInfoDiscounts)
                .HasForeignKey(gid => gid.GamesDiscountId)
                .OnDelete(DeleteBehavior.Cascade);



            // Seeding Datas

            // ROLES
            modelBuilder.Entity<IdentityRole>().HasData(
      new IdentityRole
      {
          Id = "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11",
          Name = "Admin",
          NormalizedName = "ADMIN"
      },
      new IdentityRole
      {
          Id = "0f6781b2-4564-4bb3-8d85-92e4c194a2cb",
          Name = "Staff",
          NormalizedName = "STAFF"
      },
      new IdentityRole
      {
          Id = "26e5f054-e9fd-489f-891f-cf2b57fa9a1c",
          Name = "User",
          NormalizedName = "USER"
      }
      );

            //Admin User
            var adminUserId = "bcbccc35-9a88-42cb-82d7-0c9e67f9d9af";
            var hasher = new PasswordHasher<IdentityUser>();

            var adminUser = new IdentityUser
            {
                Id = adminUserId,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gameshop.com",
                NormalizedEmail = "ADMIN@GAMESHOP.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null!, "AdminPassword@123")
            };

            modelBuilder.Entity<IdentityUser>().HasData(adminUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = adminUserId,
                    RoleId = "b7b9181c-ff61-4d8f-8f6d-5edb3a6d3a11"
                }
            );

            //System Tag
            modelBuilder.Entity<SystemTag>().HasData(
    new SystemTag
    {
        ID = 1,
        TagName = "Action",
        CreatedAt = DateTime.UtcNow,
        CreatedBy = adminUserId
    },
    new SystemTag
    {
        ID = 2,
        TagName = "Adventure",
        CreatedAt = DateTime.UtcNow,
        CreatedBy = adminUserId
    },
    new SystemTag
    {
        ID = 3,
        TagName = "Multiplayer",
        CreatedAt = DateTime.UtcNow,
        CreatedBy = adminUserId
    },
    new SystemTag
    {
        ID = 4,
        TagName = "Indie",
        CreatedAt = DateTime.UtcNow,
        CreatedBy = adminUserId
    },
    new SystemTag
    {
        ID = 5,
        TagName = "Strategy",
        CreatedAt = DateTime.UtcNow,
        CreatedBy = adminUserId
    }
);


            modelBuilder.Entity<SystemCategory>().HasData(
    new SystemCategory
    {
        ID = 1,
        CategoryName = "RPG",
        CreatedAt = DateTime.UtcNow,
       CreatedBy = adminUserId
    },
    new SystemCategory
    {
        ID = 2,
        CategoryName = "FPS",
        CreatedAt = DateTime.UtcNow,
       CreatedBy = adminUserId
    },
    new SystemCategory
    {
        ID = 3,
        CategoryName = "Puzzle",
        CreatedAt = DateTime.UtcNow,
       CreatedBy = adminUserId
    },
    new SystemCategory
    {
        ID = 4,
        CategoryName = "Simulation",
        CreatedAt = DateTime.UtcNow,
       CreatedBy = adminUserId
    },
    new SystemCategory
    {
        ID = 5,
        CategoryName = "Horror",
        CreatedAt = DateTime.UtcNow,
       CreatedBy = adminUserId
    }
);
        }
    }
}

