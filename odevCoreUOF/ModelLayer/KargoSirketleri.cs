using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class KargoSirketleri
    {
        [Key]
        public int kargoSirketID { get; set; }
        public string ad { get; set; }
        public string aciklama { get; set; }
    }
}
