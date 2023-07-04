using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Entities
{
    public class AppDbConText : DbContext
    {
        public virtual DbSet<NhanVien> NhanVien { get; set; }  
        public virtual DbSet<PhanCong> PhanCong { get; set; }  
        public virtual DbSet<DuAn> DuAn { get; set; }  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server = THUOCLE\\THUOCLE; Database = QuanLyNhanVien; Trusted_Connection = True; " +
                $"TrustServerCertificate=True");
        }
    }
}
