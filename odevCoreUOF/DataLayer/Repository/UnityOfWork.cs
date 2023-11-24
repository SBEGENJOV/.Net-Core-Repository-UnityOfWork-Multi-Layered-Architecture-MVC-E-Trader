using DataLayer.Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnityOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public void save()
        {
            _context.SaveChanges();
        }
        public ISiparis Siparis => new SiparisRepository(_context);

        public IKategory Kategori => new KategoryRepository(_context);

        public IMusteri Musteri => new MusteriRepository(_context);

        public IKargoSirket KargoSirket => new KargoSirketRepository(_context);

        public IAdres Adres => new AdresRepository(_context);

        public IOdemeYontem OdemeYontem => new OdemeYontemRepository(_context);

        public ISiparisDurum SiparisDurum => new SiparisDurumRepository(_context);

        public IUrun Urun => new UrunRepository(_context);
    }
}
