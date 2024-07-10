using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
    public class ApplicationDBContext : DbContext
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
        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);

        // cot diem
        // 1 cot diem thuoc 1 lop hoc
        // 1 lop hoc co nhieu cot diem
        // builder.Entity<BangDiemThanhPhan>(x => x.HasKey(p => new { p.hocSinhId, p.cotDiemId }));
        // builder.Entity<CotDiem>(x => x.HasKey(p => new { p.id, p.lopId }));

        // builder.Entity<CotDiem>()
        //     .HasOne(cd => cd.LopHoc)
        //     .WithMany(lh => lh.CotDiems)
        //     .HasForeignKey(cd => cd.lopId)
        //     .IsRequired();

        // builder.Entity<BangDiemThanhPhan>(x => x.HasKey(p => new { p.hocSinhId, p.cotDiemId }));
        // //bdtp
        // // 1 bdtp thuoc 1 cot diem
        // // 1 cot diem thuoc nhieu bdtp
        // builder.Entity<BangDiemThanhPhan>()
        //     .HasOne(cd => cd.CotDiem)
        //     .WithMany(bdtp => bdtp.BangDiemThanhPhans)
        //     .HasForeignKey(cd => cd.cotDiemId)
        //     .IsRequired();

        // builder.Entity<BangDiemThanhPhan>()
        //     .HasMany(bdtp => bdtp.HocSinhs)
        //     .WithMany(hs => hs.BangDiemThanhPhans)
        //     .HasForeignKey(bdtp => bdtp.hocSinhId)
        //     .IsRequired();

        // builder.Entity<GiaoVien>()
        //     .HasOne(gv => gv.user)          // GiaoVien có một User
        //     .WithOne()                      // User cũng chỉ thuộc về duy nhất một GiaoVien
        //     .HasForeignKey<GiaoVien>(gv => gv.userId)  // Khóa ngoại là userId trong GiaoVien
        //     .IsRequired();                  // Bắt buộc phải có User



        // }
    }
}