using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class siparisDurum
    {
        public int siparisDurumID { get; set; }
        public string ad { get; set; }
        public string aciklama { get; set; }
    }
}
