using DataLayer.Repository.IRepo;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class SiparisRepository:Repository<Siparis>,ISiparis
    {
        private ApplicationDbContext _context;
        public SiparisRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
