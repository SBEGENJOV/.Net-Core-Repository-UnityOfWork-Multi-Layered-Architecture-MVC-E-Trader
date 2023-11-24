using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Adresler
    {
        [Key]
        public int adresID { get; set; }
        public string ulke { get; set; }
        public string sehir { get; set; }
        public string sokak { get; set; }
        public string bina { get; set; }
        public int musteriID { get; set; }
        [ForeignKey("musteriID")]
        public Musteri Musteri { get; set; }
    }
}
