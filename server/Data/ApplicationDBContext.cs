using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<BanAccount> BanAccounts { get; set; }
        public DbSet<CotDiem> CotDiems { get; set; }
        public DbSet<GiaoVien> GiaoViens { get; set; }
        public DbSet<GiaoVienLopHoc> GiaoVienLopHocs { get; set; }
        public DbSet<HocSinh> HocSinhs { get; set; }
        public DbSet<HocSinhLopHoc> HocSinhLopHocs { get; set; }
        public DbSet<LopHoc> LopHocs { get; set; }
        public DbSet<NoiDungTraoDoi> NoiDungTraoDois { get; set; }
        public DbSet<PhucKhao> PhucKhaos { get; set; }
        public DbSet<ThongBao> ThongBaos { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<HocSinhLopHoc>()
        .HasKey(h => new { h.lopId, h.hocSinhId });
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }


    }
}