using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Urun
    {
        [Key]
        public int urunID { get; set; }
        public int kategoriID { get; set; }
        [ForeignKey("kategoriID")]
        public Kategori Kategori { get; set; }
        public string ad { get; set; }
        public string aciklama { get; set; }
        public double fiyat { get; set; }
    }
}
