using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.IRepo
{
    public interface IUnityOfWork:IDisposable
    {
        ISiparis Siparis { get; }
        IKategory Kategori { get; }
        IMusteri Musteri { get; }
        IKargoSirket KargoSirket { get; }
        IAdres Adres { get; }
        IUrun Urun { get; }
        IOdemeYontem OdemeYontem { get; }
        ISiparisDurum SiparisDurum { get; }
        void save();
    }
}
