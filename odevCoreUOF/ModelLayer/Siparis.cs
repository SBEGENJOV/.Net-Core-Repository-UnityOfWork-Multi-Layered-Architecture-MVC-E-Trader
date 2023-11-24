using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Siparis
    {
        [Key]
        public int siparisID { get; set; }
        public int musteriID { get; set; }
        [ForeignKey("musteriID")]
        public Musteri Musteri { get; set; }
        public int odemeYontemID { get; set; }
        [ForeignKey("odemeYontemID")]
        public OdemeYontem OdemeYontem { get; set; }
        public int kargoSirketID { get; set; }
        [ForeignKey("kargoSirketID")]
        public KargoSirketleri KargoSirketleri { get; set; }
        public int urunID { get; set; }
        [ForeignKey("urunID")]
        public Urun Urun { get; set; }
        public int miktar { get; set; }
        public double fiyat { get; set; }
        public int siparisDurumID { get; set; }
        [ForeignKey("siparisDurumID")]
        public siparisDurum SiparisDurum { get; set; }

    }
}
