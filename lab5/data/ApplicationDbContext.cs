using CshartpLab5.Models;
using Microsoft.EntityFrameworkCore;

namespace CshartpLab5.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTHD>()
                .HasKey(cthd => new { cthd.MAHD, cthd.MAMA });
        }
        public DbSet<Monan> monan { get; set; } = default;
        public DbSet<CshartpLab5.Models.Account> Account { get; set; } = default!;

        public DbSet<HOADON> hoadon { get; set; }   
        public DbSet<CTHD> CTHD { get; set; }

        public DbSet<khachhang> khachhang { get; set; }
    }
}
