using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<CHUYENNGANH> CHUYENNGANH { get; set; }
        public DbSet<CTCHUYENNGANH> CTCHUYENNGANH { get; set; }
        public DbSet<CTDANGKY> CTDANGKY { get; set; }
        public DbSet<CTPHIEUTHU> CTPHIEUTHU { get; set; }
        public DbSet<DANGKY> DANGKY { get; set; }
        public DbSet<GIANGVIEN> GIANGVIEN { get; set; }
        public DbSet<KHOA> KHOA { get; set; }
        public DbSet<LOP> LOP { get; set; }
        public DbSet<LOPHOCPHAN> LOPHOCPHAN { get; set; }
        public DbSet<MONHOC> MONHOC { get; set; }
        public DbSet<NGUOIDUNG> NGUOIDUNG { get; set; }
        public DbSet<PHIEUTHU> PHIEUTHU { get; set; }
        public DbSet<SINHVIEN> SINHVIEN { get; set; }
    }
}