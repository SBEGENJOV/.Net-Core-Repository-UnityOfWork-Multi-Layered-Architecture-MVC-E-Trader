using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Siparis> Siparis { get; set; }
        public DbSet<siparisDurum> SiparisDurums { get; set; }
        public DbSet<OdemeYontem> OdemeYontems { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Adresler> Adreslers { get; set; }
        public DbSet<Musteri> Musteris { get; set; }
        public DbSet<KargoSirketleri> KargoSirketleris { get; set; }
    }
}
