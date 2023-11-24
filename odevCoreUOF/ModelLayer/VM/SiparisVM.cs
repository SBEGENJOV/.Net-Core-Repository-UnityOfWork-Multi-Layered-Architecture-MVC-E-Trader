using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.VM
{
    public class SiparisVM
    {
        public Siparis Siparis { get; set; }
        public IEnumerable<SelectListItem> MusteriList { get; set; }
        public IEnumerable<SelectListItem> OdemeYontemList { get; set; }
        public IEnumerable<SelectListItem> KargoSirketList { get; set; }
        public IEnumerable<SelectListItem> SiparisDurumList { get; set; }
        public IEnumerable<SelectListItem> UrunList { get; set; }
    }
}
