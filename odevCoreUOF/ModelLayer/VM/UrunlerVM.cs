using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.VM
{
    public class UrunlerVM
    {
        public Urun Urun {get; set;}
        public IEnumerable<SelectListItem> KategoriList { get; set; }
    }
}
