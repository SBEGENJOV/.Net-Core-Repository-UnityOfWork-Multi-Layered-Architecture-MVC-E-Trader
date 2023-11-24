using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.VM
{
    public class AdreslerVM
    {
        public Adresler Adresler { get; set; }
        public IEnumerable<SelectListItem> MusteriList { get; set; }
    }
}
