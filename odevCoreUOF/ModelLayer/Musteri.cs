using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Musteri
    {
        [Key]
        public int musteriID { get; set; }
        public string ad { get; set; }
        public string Soyad { get; set; }
        public string ePosta { get; set; }
        public string telefon { get; set; }
    }
}
